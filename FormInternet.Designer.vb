<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInternet
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
        Me.grpLink = New System.Windows.Forms.GroupBox()
        Me.lblTipoLink = New System.Windows.Forms.Label()
        Me.btnColar = New System.Windows.Forms.Button()
        Me.btnAbrir = New System.Windows.Forms.Button()
        Me.txtLink = New System.Windows.Forms.TextBox()
        Me.grpOperacao = New System.Windows.Forms.GroupBox()
        Me.rbLigado = New System.Windows.Forms.RadioButton()
        Me.rbDesligado = New System.Windows.Forms.RadioButton()
        Me.grpFavoritos = New System.Windows.Forms.GroupBox()
        Me.lblDicaFavoritos = New System.Windows.Forms.Label()
        Me.btnRemoverFavorito = New System.Windows.Forms.Button()
        Me.btnFavoritar = New System.Windows.Forms.Button()
        Me.lstFavoritos = New System.Windows.Forms.ListBox()
        Me.grpPrevia = New System.Windows.Forms.GroupBox()
        Me.webPrevia = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.grpLink.SuspendLayout()
        Me.grpOperacao.SuspendLayout()
        Me.grpFavoritos.SuspendLayout()
        Me.grpPrevia.SuspendLayout()
        CType(Me.webPrevia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpLink
        '
        Me.grpLink.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpLink.Controls.Add(Me.lblTipoLink)
        Me.grpLink.Controls.Add(Me.btnColar)
        Me.grpLink.Controls.Add(Me.btnAbrir)
        Me.grpLink.Controls.Add(Me.txtLink)
        Me.grpLink.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpLink.Location = New System.Drawing.Point(8, 8)
        Me.grpLink.Name = "grpLink"
        Me.grpLink.Size = New System.Drawing.Size(828, 84)
        Me.grpLink.TabIndex = 0
        Me.grpLink.TabStop = False
        Me.grpLink.Text = "INTERNET - página, vídeo do YouTube ou arquivo de vídeo/áudio"
        '
        'lblTipoLink
        '
        Me.lblTipoLink.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTipoLink.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoLink.Location = New System.Drawing.Point(10, 52)
        Me.lblTipoLink.Name = "lblTipoLink"
        Me.lblTipoLink.Size = New System.Drawing.Size(808, 22)
        Me.lblTipoLink.TabIndex = 3
        Me.lblTipoLink.Text = "Cole ou digite um link e clique em Abrir (ou tecle Enter)."
        Me.lblTipoLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnColar
        '
        Me.btnColar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnColar.BackColor = System.Drawing.Color.Lavender
        Me.btnColar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnColar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnColar.Location = New System.Drawing.Point(728, 19)
        Me.btnColar.Name = "btnColar"
        Me.btnColar.Size = New System.Drawing.Size(90, 26)
        Me.btnColar.TabIndex = 2
        Me.btnColar.Text = "Colar e abrir"
        Me.btnColar.UseVisualStyleBackColor = False
        '
        'btnAbrir
        '
        Me.btnAbrir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbrir.BackColor = System.Drawing.Color.Lavender
        Me.btnAbrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbrir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAbrir.Location = New System.Drawing.Point(632, 19)
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(90, 26)
        Me.btnAbrir.TabIndex = 1
        Me.btnAbrir.Text = "Abrir"
        Me.btnAbrir.UseVisualStyleBackColor = False
        '
        'txtLink
        '
        Me.txtLink.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLink.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLink.Location = New System.Drawing.Point(10, 21)
        Me.txtLink.Name = "txtLink"
        Me.txtLink.Size = New System.Drawing.Size(614, 22)
        Me.txtLink.TabIndex = 0
        '
        'grpOperacao
        '
        Me.grpOperacao.Controls.Add(Me.rbLigado)
        Me.grpOperacao.Controls.Add(Me.rbDesligado)
        Me.grpOperacao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpOperacao.Location = New System.Drawing.Point(8, 98)
        Me.grpOperacao.Name = "grpOperacao"
        Me.grpOperacao.Size = New System.Drawing.Size(250, 52)
        Me.grpOperacao.TabIndex = 1
        Me.grpOperacao.TabStop = False
        Me.grpOperacao.Text = "Operação:"
        '
        'rbLigado
        '
        Me.rbLigado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbLigado.Location = New System.Drawing.Point(130, 20)
        Me.rbLigado.Name = "rbLigado"
        Me.rbLigado.Size = New System.Drawing.Size(108, 24)
        Me.rbLigado.TabIndex = 1
        Me.rbLigado.Text = "Ligado"
        Me.rbLigado.UseVisualStyleBackColor = False
        '
        'rbDesligado
        '
        Me.rbDesligado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDesligado.Location = New System.Drawing.Point(12, 20)
        Me.rbDesligado.Name = "rbDesligado"
        Me.rbDesligado.Size = New System.Drawing.Size(108, 24)
        Me.rbDesligado.TabIndex = 0
        Me.rbDesligado.Text = "Desligado"
        Me.rbDesligado.UseVisualStyleBackColor = False
        '
        'grpFavoritos
        '
        Me.grpFavoritos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpFavoritos.Controls.Add(Me.lblDicaFavoritos)
        Me.grpFavoritos.Controls.Add(Me.btnRemoverFavorito)
        Me.grpFavoritos.Controls.Add(Me.btnFavoritar)
        Me.grpFavoritos.Controls.Add(Me.lstFavoritos)
        Me.grpFavoritos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpFavoritos.Location = New System.Drawing.Point(8, 156)
        Me.grpFavoritos.Name = "grpFavoritos"
        Me.grpFavoritos.Size = New System.Drawing.Size(250, 425)
        Me.grpFavoritos.TabIndex = 2
        Me.grpFavoritos.TabStop = False
        Me.grpFavoritos.Text = "FAVORITOS"
        '
        'lblDicaFavoritos
        '
        Me.lblDicaFavoritos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDicaFavoritos.Location = New System.Drawing.Point(8, 18)
        Me.lblDicaFavoritos.Name = "lblDicaFavoritos"
        Me.lblDicaFavoritos.Size = New System.Drawing.Size(234, 16)
        Me.lblDicaFavoritos.TabIndex = 3
        Me.lblDicaFavoritos.Text = "Duplo clique para abrir"
        '
        'btnRemoverFavorito
        '
        Me.btnRemoverFavorito.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemoverFavorito.BackColor = System.Drawing.Color.Lavender
        Me.btnRemoverFavorito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoverFavorito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoverFavorito.Location = New System.Drawing.Point(130, 387)
        Me.btnRemoverFavorito.Name = "btnRemoverFavorito"
        Me.btnRemoverFavorito.Size = New System.Drawing.Size(112, 30)
        Me.btnRemoverFavorito.TabIndex = 2
        Me.btnRemoverFavorito.Text = "Remover"
        Me.btnRemoverFavorito.UseVisualStyleBackColor = False
        '
        'btnFavoritar
        '
        Me.btnFavoritar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnFavoritar.BackColor = System.Drawing.Color.Lavender
        Me.btnFavoritar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFavoritar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFavoritar.Location = New System.Drawing.Point(8, 387)
        Me.btnFavoritar.Name = "btnFavoritar"
        Me.btnFavoritar.Size = New System.Drawing.Size(112, 30)
        Me.btnFavoritar.TabIndex = 1
        Me.btnFavoritar.Text = "Adicionar atual"
        Me.btnFavoritar.UseVisualStyleBackColor = False
        '
        'lstFavoritos
        '
        Me.lstFavoritos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstFavoritos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstFavoritos.IntegralHeight = False
        Me.lstFavoritos.ItemHeight = 16
        Me.lstFavoritos.Location = New System.Drawing.Point(8, 36)
        Me.lstFavoritos.Name = "lstFavoritos"
        Me.lstFavoritos.Size = New System.Drawing.Size(234, 343)
        Me.lstFavoritos.TabIndex = 0
        '
        'grpPrevia
        '
        Me.grpPrevia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpPrevia.Controls.Add(Me.webPrevia)
        Me.grpPrevia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPrevia.Location = New System.Drawing.Point(266, 98)
        Me.grpPrevia.Name = "grpPrevia"
        Me.grpPrevia.Size = New System.Drawing.Size(570, 483)
        Me.grpPrevia.TabIndex = 3
        Me.grpPrevia.TabStop = False
        Me.grpPrevia.Text = "PRÉVIA (sem som)"
        '
        'webPrevia
        '
        Me.webPrevia.AllowExternalDrop = False
        Me.webPrevia.CreationProperties = Nothing
        Me.webPrevia.DefaultBackgroundColor = System.Drawing.Color.White
        Me.webPrevia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.webPrevia.Location = New System.Drawing.Point(3, 16)
        Me.webPrevia.Name = "webPrevia"
        Me.webPrevia.Size = New System.Drawing.Size(564, 464)
        Me.webPrevia.TabIndex = 0
        Me.webPrevia.ZoomFactor = 1.0R
        '
        'FormInternet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(844, 589)
        Me.Controls.Add(Me.grpPrevia)
        Me.Controls.Add(Me.grpFavoritos)
        Me.Controls.Add(Me.grpOperacao)
        Me.Controls.Add(Me.grpLink)
        Me.Name = "FormInternet"
        Me.Text = "Form Internet"
        Me.grpLink.ResumeLayout(False)
        Me.grpLink.PerformLayout()
        Me.grpOperacao.ResumeLayout(False)
        Me.grpFavoritos.ResumeLayout(False)
        Me.grpPrevia.ResumeLayout(False)
        CType(Me.webPrevia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpLink As GroupBox
    Friend WithEvents lblTipoLink As Label
    Friend WithEvents btnColar As Button
    Friend WithEvents btnAbrir As Button
    Friend WithEvents txtLink As TextBox
    Friend WithEvents grpOperacao As GroupBox
    Friend WithEvents rbLigado As RadioButton
    Friend WithEvents rbDesligado As RadioButton
    Friend WithEvents grpFavoritos As GroupBox
    Friend WithEvents lblDicaFavoritos As Label
    Friend WithEvents btnRemoverFavorito As Button
    Friend WithEvents btnFavoritar As Button
    Friend WithEvents lstFavoritos As ListBox
    Friend WithEvents grpPrevia As GroupBox
    Friend WithEvents webPrevia As Microsoft.Web.WebView2.WinForms.WebView2
End Class
