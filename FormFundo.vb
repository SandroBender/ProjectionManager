Imports System.IO
Imports System.Web.Script.Serialization
Imports Microsoft.Web.WebView2.Core

'Tela "Fundo": editor visual de composições (imagens, textos e formas) feito em Web\composicao.html.
'O editor conversa com o programa por mensagens (salvar, abrir, imagens, enviar para a projeção).
Public Class FormFundo
    Private ReadOnly Json As New JavaScriptSerializer With {.MaxJsonLength = Integer.MaxValue}

    Private Async Sub FormFundo_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not File.Exists(Path.Combine(PastaWebApp(), "composicao.html")) Then
            MsgBox("Arquivos do editor não encontrados em: " & PastaWebApp(), vbCritical, "Fundo")
            Exit Sub
        End If
        If Not Await PrepararNavegador(webEditor) Then Exit Sub
        webEditor.CoreWebView2.Settings.AreDefaultContextMenusEnabled = True 'copiar/colar no texto
        AddHandler webEditor.CoreWebView2.WebMessageReceived, AddressOf MensagemDoEditor
        webEditor.CoreWebView2.Navigate(EnderecoEditor)
    End Sub

    Private Sub Responder(Dados As Dictionary(Of String, Object))
        If webEditor.CoreWebView2 IsNot Nothing Then webEditor.CoreWebView2.PostWebMessageAsJson(Json.Serialize(Dados))
    End Sub

    Private Sub ResponderLista()
        Responder(New Dictionary(Of String, Object) From {{"tipo", "lista"}, {"composicoes", ListarComposicoes()}})
    End Sub

    Private Sub MensagemDoEditor(sender As Object, e As CoreWebView2WebMessageReceivedEventArgs)
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
                        {"textos", TextosAntigos()}, {"ligado", ComposicaoOn}}
                    If ComposicaoJson <> "" Then R("atual") = New Dictionary(Of String, Object) From {{"nome", ""}, {"docJson", ComposicaoJson}}
                    Responder(R)

                Case "salvar"
                    SalvarComposicao(Texto("nome"), Texto("docJson"))
                    Responder(New Dictionary(Of String, Object) From {{"tipo", "salvo"}, {"nome", Texto("nome")}})
                    ResponderLista()

                Case "excluir"
                    ExcluirComposicao(Texto("nome"))
                    ResponderLista()

                Case "escolherImagem"
                    Using Dlg As New OpenFileDialog With {
                            .Title = "Escolher imagens", .Multiselect = True,
                            .Filter = "Imagens|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.webp|Todos os arquivos|*.*",
                            .InitialDirectory = LocalSystem & "\ProjectionManager\IMAGENS"}
                        If Dlg.ShowDialog(Me) <> DialogResult.OK Then Exit Sub
                        Dim Srcs = Dlg.FileNames.Select(Function(f) GuardarImagem(Path.GetFileName(f), File.ReadAllBytes(f))).ToList()
                        Responder(New Dictionary(Of String, Object) From {{"tipo", "imagens"}, {"srcs", Srcs}, {"trocar", Texto("trocar")}})
                    End Using

                Case "salvarImagem" 'imagem arrastada do computador para a tela
                    Dim Src As String = GuardarImagem(Texto("nome"), Convert.FromBase64String(Texto("dados")))
                    Responder(New Dictionary(Of String, Object) From {{"tipo", "imagens"}, {"srcs", New List(Of String) From {Src}}})

                Case "enviar"
                    ComposicaoJson = Texto("docJson")
                    If Not ComposicaoOn Then 'enviar liga a tela Fundo
                        ComposicaoOn = True
                        FormPrincipal.chkFundo.Checked = True
                        Responder(New Dictionary(Of String, Object) From {{"tipo", "ligado"}, {"ligado", True}})
                    End If
                    AtualizaApresentacao()

                Case "aoVivo"
                    ComposicaoJson = Texto("docJson")
                    AtualizarComposicaoAoVivo()

                Case "operacao"
                    ComposicaoOn = CBool(M("ligado"))
                    If ComposicaoJson = "" Then ComposicaoJson = Texto("docJson")
                    FormPrincipal.chkFundo.Checked = ComposicaoOn
                    AtualizaApresentacao()
            End Select
        Catch ex As Exception
            Responder(New Dictionary(Of String, Object) From {{"tipo", "erro"}, {"mensagem", ex.Message}})
        End Try
    End Sub

End Class
