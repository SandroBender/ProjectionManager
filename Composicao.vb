Imports System.Drawing.Text
Imports System.IO
Imports System.Web.Script.Serialization
Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Web.WebView2.WinForms

'Composições da tela Fundo (editor visual em Web\composicao.html).
'Cada composição é um arquivo .json em <pasta do sistema>\ProjectionManager\COMPOSICOES,
'e as imagens usadas são copiadas para COMPOSICOES\imagens (basta copiar a pasta para outro computador).
Public Module Composicao

    Public Const HostApp As String = "app." & HostLocal                  'pasta Web do programa
    Public Const HostComposicoes As String = "composicoes." & HostLocal  'pasta COMPOSICOES
    Public Const EnderecoProjecaoComposicao As String = "https://" & HostApp & "/composicao.html?modo=projecao"

    'As duas camadas: Fundo (tela Fundo) e Sobreposição (tela Imagens, desenhada por cima do fundo)
    Public Enum Camada
        Fundo
        Sobreposicao
    End Enum

    Public ComposicaoOn As Boolean          'tela Fundo "Ligado"
    Public ComposicaoJson As String = ""    'fundo enviado para a projeção
    Public SobreposicaoOn As Boolean        'tela Imagens "Ligado"
    Public SobreposicaoJson As String = ""  'sobreposição enviada para a projeção

    Public Function EnderecoEditor(C As Camada) As String
        Return "https://" & HostApp & "/composicao.html?modo=editor&camada=" & If(C = Camada.Sobreposicao, "sobreposicao", "fundo")
    End Function

    Public Function AlgumaCamadaAtiva() As Boolean
        Return (ComposicaoOn AndAlso ComposicaoJson <> "") OrElse (SobreposicaoOn AndAlso SobreposicaoJson <> "")
    End Function

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

    'Desenha as camadas ligadas na mesma página (um navegador não fica transparente sobre outro)
    Private Async Sub Desenhar(Nav As WebView2, Fundo As PictureBox)
        If Not Await CarregarPagina(Nav) OrElse Nav.IsDisposed Then Exit Sub
        If Not AlgumaCamadaAtiva() Then Exit Sub
        Fundo.Visible = False 'a composição substitui a imagem de fundo antiga
        Nav.Visible = True
        Dim F As String = If(ComposicaoOn AndAlso ComposicaoJson <> "", ComposicaoJson, "null")
        Dim S As String = If(SobreposicaoOn AndAlso SobreposicaoJson <> "", SobreposicaoJson, "null")
        Await ExecutarScript(Nav, "renderizarCamadas(" & F & "," & S & ");")
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
        If AlgumaCamadaAtiva() AndAlso FormPrincipal.rbAtivada.Checked Then MostrarComposicao()
    End Sub

    '---- conversa com o editor (tela Fundo e tela Imagens) ----
    Public Class ControladorEditor
        Private ReadOnly Web As WebView2
        Private ReadOnly Minha As Camada
        Private ReadOnly Dono As Form
        Private ReadOnly Json As New JavaScriptSerializer With {.MaxJsonLength = Integer.MaxValue}
        Private Shared ReadOnly Abertos As New List(Of ControladorEditor)

        Public Sub New(Web As WebView2, C As Camada, Dono As Form)
            Me.Web = Web
            Minha = C
            Me.Dono = Dono
            Abertos.Add(Me)
            AddHandler Dono.Disposed, Sub() Abertos.Remove(Me)
        End Sub

        Private Property Ligado As Boolean
            Get
                Return If(Minha = Camada.Fundo, ComposicaoOn, SobreposicaoOn)
            End Get
            Set(Valor As Boolean)
                If Minha = Camada.Fundo Then ComposicaoOn = Valor : FormPrincipal.chkFundo.Checked = Valor Else SobreposicaoOn = Valor : FormPrincipal.chkImagens.Checked = Valor
            End Set
        End Property

        Private Property DocJson As String
            Get
                Return If(Minha = Camada.Fundo, ComposicaoJson, SobreposicaoJson)
            End Get
            Set(Valor As String)
                If Minha = Camada.Fundo Then ComposicaoJson = Valor Else SobreposicaoJson = Valor
                If Minha = Camada.Fundo Then AvisarFundoMudou() 'o editor da sobreposição mostra o fundo como referência
            End Set
        End Property

        Public Async Sub Iniciar()
            If Not File.Exists(Path.Combine(PastaWebApp(), "composicao.html")) Then
                MsgBox("Arquivos do editor não encontrados em: " & PastaWebApp(), vbCritical, Dono.Text)
                Exit Sub
            End If
            If Not Await PrepararNavegador(Web) Then Exit Sub
            Web.CoreWebView2.Settings.AreDefaultContextMenusEnabled = True 'copiar/colar no texto
            AddHandler Web.CoreWebView2.WebMessageReceived, AddressOf Mensagem
            Web.CoreWebView2.Navigate(EnderecoEditor(Minha))
        End Sub

        Private Sub Responder(Dados As Dictionary(Of String, Object))
            If Web.CoreWebView2 IsNot Nothing Then Web.CoreWebView2.PostWebMessageAsJson(Json.Serialize(Dados))
        End Sub

        Private Shared Sub AvisarFundoMudou()
            For Each C As ControladorEditor In Abertos.Where(Function(x) x.Minha = Camada.Sobreposicao)
                C.Responder(New Dictionary(Of String, Object) From {{"tipo", "referencia"}, {"referencia", If(ComposicaoJson = "", Nothing, ComposicaoJson)}})
            Next
        End Sub

        Private Sub AvisarLista()
            For Each C As ControladorEditor In Abertos 'as duas telas usam a mesma pasta de composições
                C.Responder(New Dictionary(Of String, Object) From {{"tipo", "lista"}, {"composicoes", ListarComposicoes()}})
            Next
        End Sub

        Private Sub Mensagem(sender As Object, e As CoreWebView2WebMessageReceivedEventArgs)
            Dim M As Dictionary(Of String, Object)
            Try
                M = Json.Deserialize(Of Dictionary(Of String, Object))(e.WebMessageAsJson)
            Catch
                Exit Sub
            End Try
            Dim Texto = Function(Chave As String) If(M.ContainsKey(Chave) AndAlso M(Chave) IsNot Nothing, M(Chave).ToString(), "")
            Try
                Select Case Texto("acao")
                    Case "iniciar"
                        Dim R As New Dictionary(Of String, Object) From {
                            {"tipo", "iniciar"}, {"fontes", Fontes()}, {"composicoes", ListarComposicoes()},
                            {"textos", TextosAntigos()}, {"ligado", Ligado}}
                        If DocJson <> "" Then R("atual") = New Dictionary(Of String, Object) From {{"nome", ""}, {"docJson", DocJson}}
                        If Minha = Camada.Sobreposicao AndAlso ComposicaoJson <> "" Then R("referencia") = ComposicaoJson
                        Responder(R)

                    Case "salvar"
                        SalvarComposicao(Texto("nome"), Texto("docJson"))
                        Responder(New Dictionary(Of String, Object) From {{"tipo", "salvo"}, {"nome", Texto("nome")}})
                        AvisarLista()

                    Case "excluir"
                        ExcluirComposicao(Texto("nome"))
                        AvisarLista()

                    Case "escolherImagem"
                        Using Dlg As New OpenFileDialog With {
                                .Title = "Escolher imagens", .Multiselect = True,
                                .Filter = "Imagens|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.webp|Todos os arquivos|*.*",
                                .InitialDirectory = LocalSystem & "\ProjectionManager\IMAGENS"}
                            If Dlg.ShowDialog(Dono) <> DialogResult.OK Then Exit Sub
                            Dim Srcs = Dlg.FileNames.Select(Function(f) GuardarImagem(Path.GetFileName(f), File.ReadAllBytes(f))).ToList()
                            Responder(New Dictionary(Of String, Object) From {{"tipo", "imagens"}, {"srcs", Srcs}, {"trocar", Texto("trocar")}})
                        End Using

                    Case "salvarImagem" 'imagem arrastada do computador para a tela
                        Dim Src As String = GuardarImagem(Texto("nome"), Convert.FromBase64String(Texto("dados")))
                        Responder(New Dictionary(Of String, Object) From {{"tipo", "imagens"}, {"srcs", New List(Of String) From {Src}}})

                    Case "enviar"
                        DocJson = Texto("docJson")
                        If Not Ligado Then 'enviar liga a camada
                            Ligado = True
                            Responder(New Dictionary(Of String, Object) From {{"tipo", "ligado"}, {"ligado", True}})
                        End If
                        AtualizaApresentacao()

                    Case "aoVivo"
                        DocJson = Texto("docJson")
                        AtualizarComposicaoAoVivo()

                    Case "operacao"
                        If DocJson = "" Then DocJson = Texto("docJson")
                        Ligado = CBool(M("ligado"))
                        AtualizaApresentacao()
                End Select
            Catch ex As Exception
                Responder(New Dictionary(Of String, Object) From {{"tipo", "erro"}, {"mensagem", ex.Message}})
            End Try
        End Sub
    End Class

End Module
