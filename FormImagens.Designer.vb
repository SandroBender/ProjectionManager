<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormImagens
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormImagens))
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.btnRetroceder = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblArquivo = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbManterProporcao = New System.Windows.Forms.RadioButton()
        Me.rbOriginalCentralizado = New System.Windows.Forms.RadioButton()
        Me.rbAjustarTamanho = New System.Windows.Forms.RadioButton()
        Me.rbTamanhoOriginal = New System.Windows.Forms.RadioButton()
        Me.lblIndiceImagem = New System.Windows.Forms.Label()
        Me.btnAvancar = New System.Windows.Forms.Button()
        Me.webPastas = New System.Windows.Forms.WebBrowser()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbLigado = New System.Windows.Forms.RadioButton()
        Me.rbDesligado = New System.Windows.Forms.RadioButton()
        Me.rbMinhasImagens = New System.Windows.Forms.RadioButton()
        Me.rbGerenciador = New System.Windows.Forms.RadioButton()
        Me.btnVoltarPasta = New System.Windows.Forms.Button()
        Me.cboPastas = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.picPreview = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 416.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.GroupBox7, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.webPastas, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.GroupBox2, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.GroupBox4, 1, 2)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(1, 1)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 243.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(842, 586)
        Me.TableLayoutPanel3.TabIndex = 14
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox7.Controls.Add(Me.btnRetroceder)
        Me.GroupBox7.Controls.Add(Me.Label2)
        Me.GroupBox7.Controls.Add(Me.lblArquivo)
        Me.GroupBox7.Controls.Add(Me.GroupBox1)
        Me.GroupBox7.Controls.Add(Me.lblIndiceImagem)
        Me.GroupBox7.Controls.Add(Me.btnAvancar)
        Me.GroupBox7.Location = New System.Drawing.Point(429, 78)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(410, 262)
        Me.GroupBox7.TabIndex = 30
        Me.GroupBox7.TabStop = False
        '
        'btnRetroceder
        '
        Me.btnRetroceder.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnRetroceder.FlatAppearance.BorderSize = 0
        Me.btnRetroceder.Image = CType(resources.GetObject("btnRetroceder.Image"), System.Drawing.Image)
        Me.btnRetroceder.Location = New System.Drawing.Point(56, 19)
        Me.btnRetroceder.Name = "btnRetroceder"
        Me.btnRetroceder.Size = New System.Drawing.Size(44, 39)
        Me.btnRetroceder.TabIndex = 29
        Me.btnRetroceder.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 246)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Arrraste e solte aqui >>"
        '
        'lblArquivo
        '
        Me.lblArquivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArquivo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblArquivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblArquivo.Location = New System.Drawing.Point(19, 81)
        Me.lblArquivo.Name = "lblArquivo"
        Me.lblArquivo.Size = New System.Drawing.Size(177, 74)
        Me.lblArquivo.TabIndex = 15
        Me.lblArquivo.Text = "Nome do arquivo"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbManterProporcao)
        Me.GroupBox1.Controls.Add(Me.rbOriginalCentralizado)
        Me.GroupBox1.Controls.Add(Me.rbAjustarTamanho)
        Me.GroupBox1.Controls.Add(Me.rbTamanhoOriginal)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(211, 81)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(158, 127)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dimensionamento"
        '
        'rbManterProporcao
        '
        Me.rbManterProporcao.AutoSize = True
        Me.rbManterProporcao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbManterProporcao.Location = New System.Drawing.Point(16, 42)
        Me.rbManterProporcao.Name = "rbManterProporcao"
        Me.rbManterProporcao.Size = New System.Drawing.Size(110, 17)
        Me.rbManterProporcao.TabIndex = 0
        Me.rbManterProporcao.Text = "Manter Proporção"
        Me.rbManterProporcao.UseVisualStyleBackColor = True
        '
        'rbOriginalCentralizado
        '
        Me.rbOriginalCentralizado.AutoSize = True
        Me.rbOriginalCentralizado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbOriginalCentralizado.Location = New System.Drawing.Point(16, 88)
        Me.rbOriginalCentralizado.Name = "rbOriginalCentralizado"
        Me.rbOriginalCentralizado.Size = New System.Drawing.Size(121, 17)
        Me.rbOriginalCentralizado.TabIndex = 0
        Me.rbOriginalCentralizado.Text = "Original Centralizado"
        Me.rbOriginalCentralizado.UseVisualStyleBackColor = True
        '
        'rbAjustarTamanho
        '
        Me.rbAjustarTamanho.AutoSize = True
        Me.rbAjustarTamanho.Checked = True
        Me.rbAjustarTamanho.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAjustarTamanho.Location = New System.Drawing.Point(16, 19)
        Me.rbAjustarTamanho.Name = "rbAjustarTamanho"
        Me.rbAjustarTamanho.Size = New System.Drawing.Size(116, 17)
        Me.rbAjustarTamanho.TabIndex = 0
        Me.rbAjustarTamanho.TabStop = True
        Me.rbAjustarTamanho.Text = "Ajustar ao tamanho"
        Me.rbAjustarTamanho.UseVisualStyleBackColor = True
        '
        'rbTamanhoOriginal
        '
        Me.rbTamanhoOriginal.AutoSize = True
        Me.rbTamanhoOriginal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTamanhoOriginal.Location = New System.Drawing.Point(16, 65)
        Me.rbTamanhoOriginal.Name = "rbTamanhoOriginal"
        Me.rbTamanhoOriginal.Size = New System.Drawing.Size(108, 17)
        Me.rbTamanhoOriginal.TabIndex = 0
        Me.rbTamanhoOriginal.Text = "Tamanho Original"
        Me.rbTamanhoOriginal.UseVisualStyleBackColor = True
        '
        'lblIndiceImagem
        '
        Me.lblIndiceImagem.Location = New System.Drawing.Point(85, 60)
        Me.lblIndiceImagem.Name = "lblIndiceImagem"
        Me.lblIndiceImagem.Size = New System.Drawing.Size(38, 15)
        Me.lblIndiceImagem.TabIndex = 17
        Me.lblIndiceImagem.Text = "0"
        Me.lblIndiceImagem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnAvancar
        '
        Me.btnAvancar.FlatAppearance.BorderSize = 0
        Me.btnAvancar.Image = CType(resources.GetObject("btnAvancar.Image"), System.Drawing.Image)
        Me.btnAvancar.Location = New System.Drawing.Point(108, 19)
        Me.btnAvancar.Name = "btnAvancar"
        Me.btnAvancar.Size = New System.Drawing.Size(44, 39)
        Me.btnAvancar.TabIndex = 28
        Me.btnAvancar.UseVisualStyleBackColor = False
        '
        'webPastas
        '
        Me.webPastas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.webPastas.Location = New System.Drawing.Point(0, 75)
        Me.webPastas.Margin = New System.Windows.Forms.Padding(0)
        Me.webPastas.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webPastas.Name = "webPastas"
        Me.TableLayoutPanel3.SetRowSpan(Me.webPastas, 2)
        Me.webPastas.Size = New System.Drawing.Size(426, 511)
        Me.webPastas.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.SetColumnSpan(Me.GroupBox2, 2)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.rbMinhasImagens)
        Me.GroupBox2.Controls.Add(Me.rbGerenciador)
        Me.GroupBox2.Controls.Add(Me.btnVoltarPasta)
        Me.GroupBox2.Controls.Add(Me.cboPastas)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(836, 69)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "IMAGEM DE SOBREPOSIÇÃO"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.rbLigado)
        Me.GroupBox3.Controls.Add(Me.rbDesligado)
        Me.GroupBox3.Location = New System.Drawing.Point(561, 7)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(233, 58)
        Me.GroupBox3.TabIndex = 15
        Me.GroupBox3.TabStop = False
        '
        'rbLigado
        '
        Me.rbLigado.BackColor = System.Drawing.Color.Transparent
        Me.rbLigado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbLigado.Image = CType(resources.GetObject("rbLigado.Image"), System.Drawing.Image)
        Me.rbLigado.Location = New System.Drawing.Point(125, 12)
        Me.rbLigado.Name = "rbLigado"
        Me.rbLigado.Size = New System.Drawing.Size(100, 38)
        Me.rbLigado.TabIndex = 14
        Me.rbLigado.TabStop = True
        Me.rbLigado.Text = "  Ligado"
        Me.rbLigado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbLigado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rbLigado.UseVisualStyleBackColor = False
        '
        'rbDesligado
        '
        Me.rbDesligado.BackColor = System.Drawing.Color.AliceBlue
        Me.rbDesligado.Checked = True
        Me.rbDesligado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDesligado.Image = CType(resources.GetObject("rbDesligado.Image"), System.Drawing.Image)
        Me.rbDesligado.Location = New System.Drawing.Point(7, 12)
        Me.rbDesligado.Name = "rbDesligado"
        Me.rbDesligado.Size = New System.Drawing.Size(110, 38)
        Me.rbDesligado.TabIndex = 13
        Me.rbDesligado.TabStop = True
        Me.rbDesligado.Text = "Desligado"
        Me.rbDesligado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rbDesligado.UseVisualStyleBackColor = False
        '
        'rbMinhasImagens
        '
        Me.rbMinhasImagens.AutoSize = True
        Me.rbMinhasImagens.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMinhasImagens.Location = New System.Drawing.Point(271, 25)
        Me.rbMinhasImagens.Name = "rbMinhasImagens"
        Me.rbMinhasImagens.Size = New System.Drawing.Size(102, 17)
        Me.rbMinhasImagens.TabIndex = 10
        Me.rbMinhasImagens.TabStop = True
        Me.rbMinhasImagens.Text = "Minhas Imagens"
        Me.rbMinhasImagens.UseVisualStyleBackColor = True
        '
        'rbGerenciador
        '
        Me.rbGerenciador.AutoSize = True
        Me.rbGerenciador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbGerenciador.Location = New System.Drawing.Point(5, 26)
        Me.rbGerenciador.Name = "rbGerenciador"
        Me.rbGerenciador.Size = New System.Drawing.Size(83, 17)
        Me.rbGerenciador.TabIndex = 9
        Me.rbGerenciador.TabStop = True
        Me.rbGerenciador.Text = "Gerenciador"
        Me.rbGerenciador.UseVisualStyleBackColor = True
        '
        'btnVoltarPasta
        '
        Me.btnVoltarPasta.FlatAppearance.BorderSize = 0
        Me.btnVoltarPasta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVoltarPasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoltarPasta.Image = CType(resources.GetObject("btnVoltarPasta.Image"), System.Drawing.Image)
        Me.btnVoltarPasta.Location = New System.Drawing.Point(392, 22)
        Me.btnVoltarPasta.Name = "btnVoltarPasta"
        Me.btnVoltarPasta.Size = New System.Drawing.Size(72, 33)
        Me.btnVoltarPasta.TabIndex = 8
        Me.btnVoltarPasta.Text = "Voltar"
        Me.btnVoltarPasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVoltarPasta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVoltarPasta.UseVisualStyleBackColor = True
        '
        'cboPastas
        '
        Me.cboPastas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPastas.FormattingEnabled = True
        Me.cboPastas.Location = New System.Drawing.Point(91, 24)
        Me.cboPastas.Name = "cboPastas"
        Me.cboPastas.Size = New System.Drawing.Size(162, 21)
        Me.cboPastas.TabIndex = 5
        Me.cboPastas.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.picPreview)
        Me.GroupBox4.Location = New System.Drawing.Point(426, 343)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(416, 243)
        Me.GroupBox4.TabIndex = 33
        Me.GroupBox4.TabStop = False
        '
        'picPreview
        '
        Me.picPreview.BackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.picPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picPreview.Location = New System.Drawing.Point(3, 16)
        Me.picPreview.Margin = New System.Windows.Forms.Padding(0)
        Me.picPreview.Name = "picPreview"
        Me.picPreview.Size = New System.Drawing.Size(410, 224)
        Me.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picPreview.TabIndex = 1
        Me.picPreview.TabStop = False
        '
        'FormImagens
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(844, 589)
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Name = "FormImagens"
        Me.Text = "FormImagens"
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnVoltarPasta As Button
    Friend WithEvents cboPastas As ComboBox
    Friend WithEvents webPastas As WebBrowser
    Friend WithEvents rbLigado As RadioButton
    Friend WithEvents rbDesligado As RadioButton
    Friend WithEvents lblArquivo As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbManterProporcao As RadioButton
    Friend WithEvents rbOriginalCentralizado As RadioButton
    Friend WithEvents rbAjustarTamanho As RadioButton
    Friend WithEvents rbTamanhoOriginal As RadioButton
    Friend WithEvents lblIndiceImagem As Label
    Friend WithEvents btnAvancar As Button
    Friend WithEvents btnRetroceder As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents rbMinhasImagens As RadioButton
    Friend WithEvents rbGerenciador As RadioButton
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents picPreview As PictureBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox7 As GroupBox
End Class
