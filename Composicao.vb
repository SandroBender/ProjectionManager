Imports System.Drawing.Text
Imports System.IO
Imports Microsoft.Web.WebView2.WinForms

'Composições da tela Fundo (editor visual em Web\composicao.html).
'Cada composição é um arquivo .json em <pasta do sistema>\ProjectionManager\COMPOSICOES,
'e as imagens usadas são copiadas para COMPOSICOES\imagens (basta copiar a pasta para outro computador).
Public Module Composicao

    Public Const HostApp As String = "app." & HostLocal                  'pasta Web do programa
    Public Const HostComposicoes As String = "composicoes." & HostLocal  'pasta COMPOSICOES
    Public Const EnderecoEditor As String = "https://" & HostApp & "/composicao.html?modo=editor"
    Public Const EnderecoProjecaoComposicao As String = "https://" & HostApp & "/composicao.html?modo=projecao"

    Public ComposicaoOn As Boolean          'tela Fundo "Ligado"
    Public ComposicaoJson As String = ""    'composição enviada para a projeção

    Public Function PastaWebApp() As String
        Return Path.Combine(Application.StartupPath, "Web")
    End Function

    Public Function PastaComposicoes() As String
        Return LocalSystem & "\ProjectionManager\COMPOSICOES"
    End Function

    Private Function PastaImagensComposicoes() As String
        Return Path.Combine(PastaComposicoes(), "imagens")
    End Function

    '---- arquivos ----
    Public Function ListarComposicoes() As List(Of Dictionary(Of String, Object))
        Dim Lista As New List(Of Dictionary(Of String, Object))
        If Not Directory.Exists(PastaComposicoes()) Then Return Lista
        For Each Arq As String In Directory.GetFiles(PastaComposicoes(), "*.json").OrderBy(Function(a) Path.GetFileNameWithoutExtension(a), StringComparer.CurrentCultureIgnoreCase)
            Try
                Lista.Add(New Dictionary(Of String, Object) From {{"nome", Path.GetFileNameWithoutExtension(Arq)}, {"docJson", File.ReadAllText(Arq, Text.Encoding.UTF8)}})
            Catch
                'arquivo em uso ou corrompido: ignora
            End Try
        Next
        Return Lista
    End Function

    Private Function NomeSeguro(Nome As String) As String
        For Each C As Char In Path.GetInvalidFileNameChars()
            Nome = Nome.Replace(C, " "c)
        Next
        Return Nome.Trim()
    End Function

    Public Sub SalvarComposicao(Nome As String, Json As String)
        Directory.CreateDirectory(PastaComposicoes())
        File.WriteAllText(Path.Combine(PastaComposicoes(), NomeSeguro(Nome) & ".json"), Json, Text.Encoding.UTF8)
    End Sub

    Public Sub ExcluirComposicao(Nome As String)
        Dim Arq As String = Path.Combine(PastaComposicoes(), NomeSeguro(Nome) & ".json")
        If File.Exists(Arq) Then File.Delete(Arq)
    End Sub

    'Copia a imagem para COMPOSICOES\imagens e devolve o endereço relativo ("imagens/foto.jpg").
    'Se já existir uma cópia idêntica, reaproveita.
    Public Function GuardarImagem(NomeOriginal As String, Bytes As Byte()) As String
        Directory.CreateDirectory(PastaImagensComposicoes())
        Dim Base As String = NomeSeguro(Path.GetFileNameWithoutExtension(NomeOriginal))
        If Base = "" Then Base = "imagem"
        Dim Ext As String = Path.GetExtension(NomeOriginal).ToLowerInvariant()
        For N As Integer = 1 To 9999
            Dim Nome As String = Base & If(N > 1, " (" & N & ")", "") & Ext
            Dim Destino As String = Path.Combine(PastaImagensComposicoes(), Nome)
            If Not File.Exists(Destino) Then
                File.WriteAllBytes(Destino, Bytes)
                Return "imagens/" & Nome
            End If
            If New FileInfo(Destino).Length = Bytes.Length AndAlso File.ReadAllBytes(Destino).SequenceEqual(Bytes) Then Return "imagens/" & Nome
        Next
        Throw New IOException("Não foi possível guardar a imagem " & NomeOriginal)
    End Function

    '---- dados para o editor ----
    Public Function Fontes() As List(Of String)
        Using Colecao As New InstalledFontCollection()
            Return Colecao.Families.Select(Function(f) f.Name).OrderBy(Function(n) n).ToList()
        End Using
    End Function

    Private Function CorHex(C As Color) As String
        Return "#" & C.R.ToString("x2") & C.G.ToString("x2") & C.B.ToString("x2")
    End Function

    'Textos da tela Fundo antiga (tabela Textos), para reaproveitar no editor
    Public Function TextosAntigos() As List(Of Dictionary(Of String, Object))
        Dim Lista As New List(Of Dictionary(Of String, Object))
        Try
            ConectarDados()
            CarregarTextos()
        Catch
            Return Lista
        Finally
            DesconectarDados()
        End Try
        For Each Linha As DataRow In RegTextos.Rows
            Try
                Dim T As New Dictionary(Of String, Object) From {
                    {"texto", Linha.Item(1).ToString()}, {"tipo", Linha.Item(2).ToString()}, {"alinhamento", Linha.Item(3).ToString()},
                    {"fonte", Linha.Item(5).ToString()}}
                Dim Tamanho As Double, Estilo As Integer, Argb As Integer
                If Double.TryParse(Linha.Item(6).ToString(), Tamanho) Then T("tamanho") = Tamanho
                If Integer.TryParse(Linha.Item(7).ToString(), Estilo) Then T("estilo") = Estilo
                If Integer.TryParse(Linha.Item(8).ToString(), Argb) Then T("cor") = CorHex(Color.FromArgb(Argb))
                If Integer.TryParse(Linha.Item(4).ToString(), Argb) Then
                    Dim Fundo As Color = Color.FromArgb(Argb)
                    T("fundo") = CorHex(Fundo)
                    T("fundoAlfa") = Math.Round(Fundo.A / 255.0, 2)
                End If
                If T("texto").ToString().Trim() <> "" Then Lista.Add(T)
            Catch
                'linha com dados inesperados: ignora
            End Try
        Next
        Return Lista
    End Function

    '---- projeção (telão) e prévia (tela principal) ----
    Private ReadOnly Paginas As New Dictionary(Of WebView2, Task(Of Boolean))

    'Abre a página de projeção uma vez por navegador
    Private Function CarregarPagina(Nav As WebView2) As Task(Of Boolean)
        Dim T As Task(Of Boolean) = Nothing
        If Not Paginas.TryGetValue(Nav, T) OrElse (T.IsCompleted AndAlso Not T.Result) Then
            T = NavegarPagina(Nav)
            Paginas(Nav) = T
            AddHandler Nav.Disposed, Sub() Paginas.Remove(Nav)
        End If
        Return T
    End Function

    Private Async Function NavegarPagina(Nav As WebView2) As Task(Of Boolean)
        If Not Await PrepararNavegador(Nav) OrElse Nav.IsDisposed Then Return False
        Dim Carregou As New TaskCompletionSource(Of Boolean)
        Dim Ao As EventHandler(Of Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs) = Sub(s, e) Carregou.TrySetResult(e.IsSuccess)
        AddHandler Nav.CoreWebView2.NavigationCompleted, Ao
        Nav.Tag = EnderecoProjecaoComposicao
        Nav.CoreWebView2.Navigate(EnderecoProjecaoComposicao)
        Dim Ok As Boolean = Await Carregou.Task
        RemoveHandler Nav.CoreWebView2.NavigationCompleted, Ao
        Return Ok
    End Function

    Private Async Sub Desenhar(Nav As WebView2, Fundo As PictureBox)
        If Not Await CarregarPagina(Nav) OrElse Nav.IsDisposed Then Exit Sub
        If ComposicaoJson = "" Then Exit Sub
        Fundo.Visible = False 'a composição substitui a imagem de fundo antiga
        Nav.Visible = True
        Await ExecutarScript(Nav, "renderizar(" & ComposicaoJson & ");")
    End Sub

    Private Sub Ocultar(Nav As WebView2, Fundo As PictureBox)
        If Nav Is Nothing OrElse Nav.IsDisposed OrElse Not Nav.Visible Then Exit Sub
        Nav.Visible = False
        Fundo.Visible = True
    End Sub

    Public Sub MostrarComposicao()
        Desenhar(FormApresentar.NavegadorComposicao, FormApresentar.picFundo)
        Desenhar(FormPrincipal.NavegadorPrevia, FormPrincipal.picFundo)
    End Sub

    Public Sub EsconderComposicao()
        If FormApresentar.TemNavegadorComposicao Then Ocultar(FormApresentar.NavegadorComposicao, FormApresentar.picFundo)
        If FormPrincipal.TemNavegadorPrevia Then Ocultar(FormPrincipal.NavegadorPrevia, FormPrincipal.picFundo)
    End Sub

    'Chamado pelo editor no modo "Ao vivo": só redesenha, sem passar por toda a atualização da projeção
    Public Sub AtualizarComposicaoAoVivo()
        If ComposicaoOn AndAlso FormPrincipal.rbAtivada.Checked Then MostrarComposicao()
    End Sub

End Module
