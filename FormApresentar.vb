Public Class FormApresentar
    Private Sub FormApresentar_Load(sender As Object, e As EventArgs) Handles Me.Load
        TableLayoutPanel1.Parent = picFundo
        'lblTitulo.Parent = TableLayoutPanel1 'CRIAR transparencia dos textos
        'lblSubtitulo.Parent = picFundo
        'lblCorpo.Parent = picFundo
        'lblRodape.Parent = picFundo
    End Sub
End Class