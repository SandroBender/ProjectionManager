Imports System.Drawing.Text
Imports System.IO
Imports System.Web.Script.Serialization
Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Web.WebView2.WinForms

'Camadas da projeção montadas no navegador embutido:
'  Fundo        - tela Fundo (Web\fundo.html): uma imagem fixa com margem e moldura; lembrada em COMPOSICOES\fundo.json
'  Sobreposição - tela Imagens (Web\composicao.html): editor de imagens, textos e formas; temporária
'As imagens usadas são copiadas para <pasta do sistema>\ProjectionManager\COMPOSICOES\imagens.
Public Module Composicao

    Public Const HostApp As String = "app." & HostLocal                  'pasta Web do programa
    Public Const HostComposicoes As String = "composicoes." & HostLocal  'pasta COMPOSICOES

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
        If C = Camada.Fundo Then Return "https://" & HostApp & "/fundo.html?modo=fundo"
        Return "https://" & HostApp & "/composicao.html?modo=editor&camada=sobreposicao"
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

    '---- fundo atual: lembrado ao reabrir o programa ----
    Private Function ArquivoFundo() As String
        Return Path.Combine(PastaComposicoes(), "fundo.json")
    End Function

    Public Sub GravarFundo()
        Directory.CreateDirectory(PastaComposicoes())
        Dim Dados As New Dictionary(Of String, Object) From {{"ligado", ComposicaoOn}, {"docJson", ComposicaoJson}}
        File.WriteAllText(ArquivoFundo(), New JavaScriptSerializer With {.MaxJsonLength = Integer.MaxValue}.Serialize(Dados), Text.Encoding.UTF8)
    End Sub

    'Chamado ao abrir o programa (depois de definir a pasta do sistema)
    Public Sub CarregarFundoSalvo()
        Try
            If Not File.Exists(ArquivoFundo()) Then Exit Sub
            Dim Dados = New JavaScriptSerializer With {.MaxJsonLength = Integer.MaxValue}.Deserialize(Of Dictionary(Of String, Object))(File.ReadAllText(ArquivoFundo(), Text.Encoding.UTF8))
            ComposicaoJson = If(Dados.ContainsKey("docJson") AndAlso Dados("docJson") IsNot Nothing, Dados("docJson").ToString(), "")
            ComposicaoOn = Dados.ContainsKey("ligado") AndAlso CBool(Dados("ligado")) AndAlso ComposicaoJson <> ""
            FormPrincipal.chkFundo.Checked = ComposicaoOn
        Catch ex As Exception
            MsgBox("Não foi possível ler o fundo salvo:" & vbCrLf & ex.Message, vbExclamation, "Fundo")
        End Try
    End Sub

    Private Function NomeSeguro(Nome As String) As String
        For Each C As Char In Path.GetInvalidFileNameChars()
            Nome = Nome.Replace(C, " "c)
        Next
        Return Nome.Trim()
    End Function

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

    'Chamado pelo editor no modo "Ao vivo": só redesenha, sem passar por toda a atualização da projeção
    Public Sub AtualizarComposicaoAoVivo()
        If FormPrincipal.rbAtivada.Checked Then MostrarNasTelas()
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
                        Dim R As New Dictionary(Of String, Object) From {{"tipo", "iniciar"}, {"ligado", Ligado}}
                        If Minha = Camada.Sobreposicao Then R("fontes") = Fontes()
                        If DocJson <> "" Then R("atual") = New Dictionary(Of String, Object) From {{"nome", ""}, {"docJson", DocJson}}
                        If Minha = Camada.Sobreposicao AndAlso ComposicaoJson <> "" Then R("referencia") = ComposicaoJson
                        Responder(R)

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

                    Case "atualizar" 'tela Fundo: cada mudança vale na hora e fica gravada
                        DocJson = Texto("docJson")
                        Ligado = CBool(M("ligado"))
                        GravarFundo()
                        AtualizaApresentacao()
                End Select
            Catch ex As Exception
                Responder(New Dictionary(Of String, Object) From {{"tipo", "erro"}, {"mensagem", ex.Message}})
            End Try
        End Sub
    End Class

End Module
