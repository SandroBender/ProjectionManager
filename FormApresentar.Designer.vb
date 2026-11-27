<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormApresentar
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.webProjecao = New Microsoft.Web.WebView2.WinForms.WebView2()
        CType(Me.webProjecao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'webProjecao
        '
        Me.webProjecao.AllowExternalDrop = False
        Me.webProjecao.CreationProperties = Nothing
        Me.webProjecao.DefaultBackgroundColor = System.Drawing.Color.Black
        Me.webProjecao.Dock = System.Windows.Forms.DockStyle.Fill
        Me.webProjecao.Location = New System.Drawing.Point(0, 0)
        Me.webProjecao.Name = "webProjecao"
        Me.webProjecao.Size = New System.Drawing.Size(900, 500)
        Me.webProjecao.TabIndex = 0
        Me.webProjecao.ZoomFactor = 1.0R
        '
        'FormApresentar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(900, 500)
        Me.Controls.Add(Me.webProjecao)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormApresentar"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Projeção"
        CType(Me.webProjecao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents webProjecao As Microsoft.Web.WebView2.WinForms.WebView2
End Class
