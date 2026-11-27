'Tela "Fundo": editor visual da camada de fundo (Web\composicao.html).
Public Class FormFundo
    Private Editor As ControladorEditor

    Private Sub FormFundo_Load(sender As Object, e As EventArgs) Handles Me.Load
        Editor = New ControladorEditor(webEditor, Camada.Fundo, Me)
        Editor.Iniciar()
    End Sub
End Class
