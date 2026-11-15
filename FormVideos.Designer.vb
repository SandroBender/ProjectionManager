<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormVideos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormVideos))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbMinhasMusicas = New System.Windows.Forms.RadioButton()
        Me.btnVoltarPasta = New System.Windows.Forms.Button()
        Me.rbAudios = New System.Windows.Forms.RadioButton()
        Me.rbVideos = New System.Windows.Forms.RadioButton()
        Me.webPastas = New System.Windows.Forms.WebBrowser()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbApresentarImagem = New System.Windows.Forms.RadioButton()
        Me.rbReproduzirVideo = New System.Windows.Forms.RadioButton()
        Me.rbDesligado = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblArquivoSelecionado = New System.Windows.Forms.Label()
        Me.btnLimparLista = New System.Windows.Forms.Button()
        Me.lstReproducao = New System.Windows.Forms.ListBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.wmpPlayer = New AxWMPLib.AxWindowsMediaPlayer()
        Me.btnRetroceder = New System.Windows.Forms.Button()
        Me.lblIndiceImagem = New System.Windows.Forms.Label()
        Me.btnAvancar = New System.Windows.Forms.Button()
        Me.picImagem = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblArquivoImagem = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.wmpPlayer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picImagem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.webPastas, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox3, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox4, 1, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(1, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 290.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(843, 585)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.rbMinhasMusicas)
        Me.GroupBox2.Controls.Add(Me.btnVoltarPasta)
        Me.GroupBox2.Controls.Add(Me.rbAudios)
        Me.GroupBox2.Controls.Add(Me.rbVideos)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(437, 64)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "AUDIOS / VIDEOS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Do Gerenciador:"
        '
        'rbMinhasMusicas
        '
        Me.rbMinhasMusicas.AutoSize = True
        Me.rbMinhasMusicas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMinhasMusicas.Location = New System.Drawing.Point(183, 21)
        Me.rbMinhasMusicas.Name = "rbMinhasMusicas"
        Me.rbMinhasMusicas.Size = New System.Drawing.Size(64, 30)
        Me.rbMinhasMusicas.TabIndex = 9
        Me.rbMinhasMusicas.TabStop = True
        Me.rbMinhasMusicas.Text = "Minhas " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Músicas"
        Me.rbMinhasMusicas.UseVisualStyleBackColor = True
        '
        'btnVoltarPasta
        '
        Me.btnVoltarPasta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVoltarPasta.FlatAppearance.BorderSize = 0
        Me.btnVoltarPasta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVoltarPasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoltarPasta.Image = CType(resources.GetObject("btnVoltarPasta.Image"), System.Drawing.Image)
        Me.btnVoltarPasta.Location = New System.Drawing.Point(358, 21)
        Me.btnVoltarPasta.Name = "btnVoltarPasta"
        Me.btnVoltarPasta.Size = New System.Drawing.Size(68, 34)
        Me.btnVoltarPasta.TabIndex = 8
        Me.btnVoltarPasta.Text = "Voltar"
        Me.btnVoltarPasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVoltarPasta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVoltarPasta.UseVisualStyleBackColor = True
        '
        'rbAudios
        '
        Me.rbAudios.AutoSize = True
        Me.rbAudios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAudios.Location = New System.Drawing.Point(8, 30)
        Me.rbAudios.Name = "rbAudios"
        Me.rbAudios.Size = New System.Drawing.Size(66, 17)
        Me.rbAudios.TabIndex = 7
        Me.rbAudios.TabStop = True
        Me.rbAudios.Text = "AUDIOS"
        Me.rbAudios.UseVisualStyleBackColor = True
        '
        'rbVideos
        '
        Me.rbVideos.AutoSize = True
        Me.rbVideos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbVideos.Location = New System.Drawing.Point(80, 30)
        Me.rbVideos.Name = "rbVideos"
        Me.rbVideos.Size = New System.Drawing.Size(65, 17)
        Me.rbVideos.TabIndex = 6
        Me.rbVideos.TabStop = True
        Me.rbVideos.Text = "VIDEOS"
        Me.rbVideos.UseVisualStyleBackColor = True
        '
        'webPastas
        '
        Me.webPastas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.webPastas.Location = New System.Drawing.Point(3, 73)
        Me.webPastas.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webPastas.Name = "webPastas"
        Me.TableLayoutPanel1.SetRowSpan(Me.webPastas, 3)
        Me.webPastas.Size = New System.Drawing.Size(437, 509)
        Me.webPastas.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.rbApresentarImagem)
        Me.GroupBox1.Controls.Add(Me.rbReproduzirVideo)
        Me.GroupBox1.Controls.Add(Me.rbDesligado)
        Me.GroupBox1.Location = New System.Drawing.Point(446, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(394, 64)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'rbApresentarImagem
        '
        Me.rbApresentarImagem.BackColor = System.Drawing.Color.Transparent
        Me.rbApresentarImagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbApresentarImagem.Image = CType(resources.GetObject("rbApresentarImagem.Image"), System.Drawing.Image)
        Me.rbApresentarImagem.Location = New System.Drawing.Point(275, 14)
        Me.rbApresentarImagem.Name = "rbApresentarImagem"
        Me.rbApresentarImagem.Size = New System.Drawing.Size(115, 38)
        Me.rbApresentarImagem.TabIndex = 15
        Me.rbApresentarImagem.TabStop = True
        Me.rbApresentarImagem.Text = "Apresentar Imagem"
        Me.rbApresentarImagem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbApresentarImagem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rbApresentarImagem.UseVisualStyleBackColor = False
        '
        'rbReproduzirVideo
        '
        Me.rbReproduzirVideo.BackColor = System.Drawing.Color.Transparent
        Me.rbReproduzirVideo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbReproduzirVideo.Image = CType(resources.GetObject("rbReproduzirVideo.Image"), System.Drawing.Image)
        Me.rbReproduzirVideo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbReproduzirVideo.Location = New System.Drawing.Point(121, 14)
        Me.rbReproduzirVideo.Name = "rbReproduzirVideo"
        Me.rbReproduzirVideo.Size = New System.Drawing.Size(149, 41)
        Me.rbReproduzirVideo.TabIndex = 10
        Me.rbReproduzirVideo.TabStop = True
        Me.rbReproduzirVideo.Text = "Reproduzir VÍDEO Imediatamente"
        Me.rbReproduzirVideo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rbReproduzirVideo.UseVisualStyleBackColor = False
        '
        'rbDesligado
        '
        Me.rbDesligado.BackColor = System.Drawing.Color.AliceBlue
        Me.rbDesligado.Checked = True
        Me.rbDesligado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDesligado.Image = CType(resources.GetObject("rbDesligado.Image"), System.Drawing.Image)
        Me.rbDesligado.Location = New System.Drawing.Point(9, 12)
        Me.rbDesligado.Name = "rbDesligado"
        Me.rbDesligado.Size = New System.Drawing.Size(107, 43)
        Me.rbDesligado.TabIndex = 11
        Me.rbDesligado.TabStop = True
        Me.rbDesligado.Text = "Desligado"
        Me.rbDesligado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rbDesligado.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.lblArquivoSelecionado)
        Me.GroupBox3.Controls.Add(Me.btnLimparLista)
        Me.GroupBox3.Controls.Add(Me.lstReproducao)
        Me.GroupBox3.Location = New System.Drawing.Point(446, 73)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(394, 179)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Arraste e solte  aqui >>    LISTA DE REPRODUÇÃO -Audio e Vídeo"
        '
        'lblArquivoSelecionado
        '
        Me.lblArquivoSelecionado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblArquivoSelecionado.AutoSize = True
        Me.lblArquivoSelecionado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblArquivoSelecionado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblArquivoSelecionado.Location = New System.Drawing.Point(6, 143)
        Me.lblArquivoSelecionado.Name = "lblArquivoSelecionado"
        Me.lblArquivoSelecionado.Size = New System.Drawing.Size(103, 13)
        Me.lblArquivoSelecionado.TabIndex = 11
        Me.lblArquivoSelecionado.Text = "Arquivo selecionado"
        Me.lblArquivoSelecionado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnLimparLista
        '
        Me.btnLimparLista.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnLimparLista.FlatAppearance.BorderSize = 0
        Me.btnLimparLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimparLista.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimparLista.Image = CType(resources.GetObject("btnLimparLista.Image"), System.Drawing.Image)
        Me.btnLimparLista.Location = New System.Drawing.Point(286, 143)
        Me.btnLimparLista.Name = "btnLimparLista"
        Me.btnLimparLista.Size = New System.Drawing.Size(99, 33)
        Me.btnLimparLista.TabIndex = 8
        Me.btnLimparLista.Text = "Limpar Lista"
        Me.btnLimparLista.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimparLista.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLimparLista.UseVisualStyleBackColor = True
        '
        'lstReproducao
        '
        Me.lstReproducao.AllowDrop = True
        Me.lstReproducao.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstReproducao.FormattingEnabled = True
        Me.lstReproducao.Location = New System.Drawing.Point(6, 19)
        Me.lstReproducao.Name = "lstReproducao"
        Me.lstReproducao.Size = New System.Drawing.Size(379, 121)
        Me.lstReproducao.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.wmpPlayer)
        Me.GroupBox4.Controls.Add(Me.btnRetroceder)
        Me.GroupBox4.Controls.Add(Me.lblIndiceImagem)
        Me.GroupBox4.Controls.Add(Me.btnAvancar)
        Me.GroupBox4.Controls.Add(Me.picImagem)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.lblArquivoImagem)
        Me.GroupBox4.Location = New System.Drawing.Point(446, 258)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(394, 284)
        Me.GroupBox4.TabIndex = 19
        Me.GroupBox4.TabStop = False
        '
        'wmpPlayer
        '
        Me.wmpPlayer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.wmpPlayer.Enabled = True
        Me.wmpPlayer.Location = New System.Drawing.Point(0, 0)
        Me.wmpPlayer.Name = "wmpPlayer"
        Me.wmpPlayer.OcxState = CType(resources.GetObject("wmpPlayer.OcxState"), System.Windows.Forms.AxHost.State)
        Me.wmpPlayer.Size = New System.Drawing.Size(394, 100)
        Me.wmpPlayer.TabIndex = 15
        '
        'btnRetroceder
        '
        Me.btnRetroceder.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnRetroceder.FlatAppearance.BorderSize = 0
        Me.btnRetroceder.Image = CType(resources.GetObject("btnRetroceder.Image"), System.Drawing.Image)
        Me.btnRetroceder.Location = New System.Drawing.Point(3, 179)
        Me.btnRetroceder.Name = "btnRetroceder"
        Me.btnRetroceder.Size = New System.Drawing.Size(36, 34)
        Me.btnRetroceder.TabIndex = 32
        Me.btnRetroceder.UseVisualStyleBackColor = False
        '
        'lblIndiceImagem
        '
        Me.lblIndiceImagem.Location = New System.Drawing.Point(23, 223)
        Me.lblIndiceImagem.Name = "lblIndiceImagem"
        Me.lblIndiceImagem.Size = New System.Drawing.Size(38, 15)
        Me.lblIndiceImagem.TabIndex = 30
        Me.lblIndiceImagem.Text = "0"
        Me.lblIndiceImagem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnAvancar
        '
        Me.btnAvancar.FlatAppearance.BorderSize = 0
        Me.btnAvancar.Image = CType(resources.GetObject("btnAvancar.Image"), System.Drawing.Image)
        Me.btnAvancar.Location = New System.Drawing.Point(41, 179)
        Me.btnAvancar.Name = "btnAvancar"
        Me.btnAvancar.Size = New System.Drawing.Size(36, 34)
        Me.btnAvancar.TabIndex = 31
        Me.btnAvancar.UseVisualStyleBackColor = False
        '
        'picImagem
        '
        Me.picImagem.BackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.picImagem.Location = New System.Drawing.Point(81, 120)
        Me.picImagem.Margin = New System.Windows.Forms.Padding(0)
        Me.picImagem.Name = "picImagem"
        Me.picImagem.Size = New System.Drawing.Size(309, 160)
        Me.picImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImagem.TabIndex = 20
        Me.picImagem.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(2, 134)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 39)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "IMAGENS da" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pasta Principal" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Selecionada"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblArquivoImagem
        '
        Me.lblArquivoImagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArquivoImagem.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblArquivoImagem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblArquivoImagem.Location = New System.Drawing.Point(81, 103)
        Me.lblArquivoImagem.Name = "lblArquivoImagem"
        Me.lblArquivoImagem.Size = New System.Drawing.Size(307, 15)
        Me.lblArquivoImagem.TabIndex = 21
        Me.lblArquivoImagem.Text = "Nenhum arquivo"
        '
        'FormVideos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(844, 589)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormVideos"
        Me.Text = "Form Videos"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.wmpPlayer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picImagem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents webPastas As WebBrowser
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbReproduzirVideo As RadioButton
    Friend WithEvents rbDesligado As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnVoltarPasta As Button
    Friend WithEvents rbAudios As RadioButton
    Friend WithEvents rbVideos As RadioButton
    Friend WithEvents wmpPlayer As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lstReproducao As ListBox
    Friend WithEvents btnLimparLista As Button
    Friend WithEvents lblArquivoSelecionado As Label
    Friend WithEvents rbMinhasMusicas As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents picImagem As PictureBox
    Friend WithEvents lblArquivoImagem As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents rbApresentarImagem As RadioButton
    Friend WithEvents btnRetroceder As Button
    Friend WithEvents lblIndiceImagem As Label
    Friend WithEvents btnAvancar As Button
End Class
