Public Class FormApresentar
    Private Sub FormApresentar_Load(sender As Object, e As EventArgs) Handles Me.Load
        TableLayoutPanel1.Parent = PictureBox1
        'Label1.Parent = TableLayoutPanel1 'CRIAR transparencia dos textos
        'Label2.Parent = PictureBox1
        'Label3.Parent = PictureBox1
        'Label4.Parent = PictureBox1
    End Sub
End Class