<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFundo
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
        Me.webEditor = New Microsoft.Web.WebView2.WinForms.WebView2()
        CType(Me.webEditor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'webEditor
        '
        Me.webEditor.AllowExternalDrop = True
        Me.webEditor.CreationProperties = Nothing
        Me.webEditor.DefaultBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.webEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.webEditor.Location = New System.Drawing.Point(0, 0)
        Me.webEditor.Name = "webEditor"
        Me.webEditor.Size = New System.Drawing.Size(844, 589)
        Me.webEditor.TabIndex = 0
        Me.webEditor.ZoomFactor = 1.0R
        '
        'FormFundo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(844, 589)
        Me.Controls.Add(Me.webEditor)
        Me.Name = "FormFundo"
        Me.Text = "Form Fundo"
        CType(Me.webEditor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents webEditor As Microsoft.Web.WebView2.WinForms.WebView2
End Class
