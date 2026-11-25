Imports Microsoft.Web.WebView2.WinForms

Public Class FormApresentar
    'Navegador da Internet: criado só quando for usado, ocupa a tela toda por cima dos outros itens
    Private _Navegador As WebView2
    Public ReadOnly Property Navegador As WebView2
        Get
            If Not TemNavegador Then
                _Navegador = New WebView2 With {.Dock = DockStyle.Fill, .Visible = False, .DefaultBackgroundColor = Color.Black}
                Controls.Add(_Navegador)
            End If
            Return _Navegador
        End Get
    End Property
    Public ReadOnly Property TemNavegador As Boolean
        Get
            Return _Navegador IsNot Nothing AndAlso Not _Navegador.IsDisposed
        End Get
    End Property

    Private Sub FormApresentar_Load(sender As Object, e As EventArgs) Handles Me.Load
        TableLayoutPanel1.Parent = picFundo
        'lblTitulo.Parent = TableLayoutPanel1 'CRIAR transparencia dos textos
        'lblSubtitulo.Parent = picFundo
        'lblCorpo.Parent = picFundo
        'lblRodape.Parent = picFundo
    End Sub
End Class