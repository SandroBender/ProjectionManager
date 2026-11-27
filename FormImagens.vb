'Tela "Imagens": editor visual da camada de sobreposição (imagens, textos e formas por cima do fundo).
Public Class FormImagens
    Private Editor As ControladorEditor

    Private Sub FormImagens_Load(sender As Object, e As EventArgs) Handles Me.Load
        Editor = New ControladorEditor(webEditor, Camada.Sobreposicao, Me)
        Editor.Iniciar()
    End Sub
End Class
