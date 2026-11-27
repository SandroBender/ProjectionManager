Imports Microsoft.Web.WebView2.WinForms

'Janela de projeção (segundo monitor): tudo é desenhado pela página Web\projecao.html em webProjecao.
'Só as páginas comuns da Internet usam um segundo navegador por cima (sites não deixam ser exibidos dentro de outra página).
Public Class FormApresentar
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

    Private Sub FormApresentar_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        AtualizaApresentacao() 'ao abrir (ou reabrir em outro monitor), desenha o estado atual
    End Sub
End Class
