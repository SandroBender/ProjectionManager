<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPrincipal))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboMonitor = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.picStatusFechada = New System.Windows.Forms.PictureBox()
        Me.picStatusAtivada = New System.Windows.Forms.PictureBox()
        Me.picStatusPausada = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.rbFechada = New System.Windows.Forms.RadioButton()
        Me.webPrevia = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.rbNeutra = New System.Windows.Forms.RadioButton()
        Me.rbPausada = New System.Windows.Forms.RadioButton()
        Me.rbAtivada = New System.Windows.Forms.RadioButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PainelMenu = New System.Windows.Forms.Panel()
        Me.btnEscolherPasta = New System.Windows.Forms.Button()
        Me.lblLocalSalvamento = New System.Windows.Forms.Label()
        Me.lblPastaPadrao = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkAudioVideo = New System.Windows.Forms.CheckBox()
        Me.chkImagens = New System.Windows.Forms.CheckBox()
        Me.chkBiblia = New System.Windows.Forms.CheckBox()
        Me.chkHarpa = New System.Windows.Forms.CheckBox()
        Me.chkInternet = New System.Windows.Forms.CheckBox()
        Me.chkFundo = New System.Windows.Forms.CheckBox()
        Me.btnSalvarImagem = New System.Windows.Forms.Button()
        Me.btnOpcoes = New System.Windows.Forms.Button()
        Me.btnAudioVideo = New System.Windows.Forms.Button()
        Me.btnImagens = New System.Windows.Forms.Button()
        Me.btnBiblia = New System.Windows.Forms.Button()
        Me.btnHarpa = New System.Windows.Forms.Button()
        Me.btnInternet = New System.Windows.Forms.Button()
        Me.btnFundo = New System.Windows.Forms.Button()
        Me.PainelControle = New System.Windows.Forms.Panel()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picStatusFechada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picStatusAtivada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picStatusPausada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PainelMenu.SuspendLayout()
        CType(Me.webPrevia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(80, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(248, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "GERENCIADOR DE PROJEÇÃO"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(90, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Monitor de projeção:"
        '
        'ComboMonitor
        '
        Me.ComboMonitor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboMonitor.FormattingEnabled = True
        Me.ComboMonitor.Location = New System.Drawing.Point(209, 34)
        Me.ComboMonitor.Name = "ComboMonitor"
        Me.ComboMonitor.Size = New System.Drawing.Size(167, 21)
        Me.ComboMonitor.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(143, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.picStatusFechada)
        Me.GroupBox1.Controls.Add(Me.picStatusAtivada)
        Me.GroupBox1.Controls.Add(Me.picStatusPausada)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.rbFechada)
        Me.GroupBox1.Controls.Add(Me.webPrevia)
        Me.GroupBox1.Controls.Add(Me.rbNeutra)
        Me.GroupBox1.Controls.Add(Me.rbPausada)
        Me.GroupBox1.Controls.Add(Me.rbAtivada)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(7, 161)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(423, 307)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "JANELA DE PROJEÇÃO:"
        '
        'picStatusFechada
        '
        Me.picStatusFechada.Image = CType(resources.GetObject("picStatusFechada.Image"), System.Drawing.Image)
        Me.picStatusFechada.Location = New System.Drawing.Point(6, 14)
        Me.picStatusFechada.Name = "picStatusFechada"
        Me.picStatusFechada.Size = New System.Drawing.Size(74, 62)
        Me.picStatusFechada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picStatusFechada.TabIndex = 23
        Me.picStatusFechada.TabStop = False
        Me.picStatusFechada.Visible = False
        '
        'picStatusAtivada
        '
        Me.picStatusAtivada.Image = CType(resources.GetObject("picStatusAtivada.Image"), System.Drawing.Image)
        Me.picStatusAtivada.Location = New System.Drawing.Point(6, 14)
        Me.picStatusAtivada.Name = "picStatusAtivada"
        Me.picStatusAtivada.Size = New System.Drawing.Size(74, 62)
        Me.picStatusAtivada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picStatusAtivada.TabIndex = 10
        Me.picStatusAtivada.TabStop = False
        Me.picStatusAtivada.Visible = False
        '
        'picStatusPausada
        '
        Me.picStatusPausada.Image = CType(resources.GetObject("picStatusPausada.Image"), System.Drawing.Image)
        Me.picStatusPausada.Location = New System.Drawing.Point(6, 14)
        Me.picStatusPausada.Name = "picStatusPausada"
        Me.picStatusPausada.Size = New System.Drawing.Size(74, 62)
        Me.picStatusPausada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picStatusPausada.TabIndex = 9
        Me.picStatusPausada.TabStop = False
        Me.picStatusPausada.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(6, 14)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(74, 62)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox2.TabIndex = 7
        Me.PictureBox2.TabStop = False
        '
        'webPrevia
        '
        Me.webPrevia.AllowExternalDrop = False
        Me.webPrevia.CreationProperties = Nothing
        Me.webPrevia.DefaultBackgroundColor = System.Drawing.Color.Black
        Me.webPrevia.Location = New System.Drawing.Point(6, 77)
        Me.webPrevia.Name = "webPrevia"
        Me.webPrevia.Size = New System.Drawing.Size(410, 224)
        Me.webPrevia.TabIndex = 30
        Me.webPrevia.ZoomFactor = 1.0R
        '
        'rbFechada
        '
        Me.rbFechada.AutoSize = True
        Me.rbFechada.BackColor = System.Drawing.Color.FromArgb(CType(CType(143, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.rbFechada.ForeColor = System.Drawing.Color.DarkRed
        Me.rbFechada.Location = New System.Drawing.Point(344, 36)
        Me.rbFechada.Name = "rbFechada"
        Me.rbFechada.Size = New System.Drawing.Size(67, 17)
        Me.rbFechada.TabIndex = 8
        Me.rbFechada.Text = "Fechada"
        Me.rbFechada.UseVisualStyleBackColor = False
        '
        'rbNeutra
        '
        Me.rbNeutra.AutoSize = True
        Me.rbNeutra.ForeColor = System.Drawing.Color.Black
        Me.rbNeutra.Location = New System.Drawing.Point(268, 35)
        Me.rbNeutra.Name = "rbNeutra"
        Me.rbNeutra.Size = New System.Drawing.Size(57, 17)
        Me.rbNeutra.TabIndex = 8
        Me.rbNeutra.Text = "Neutra"
        Me.rbNeutra.UseVisualStyleBackColor = True
        '
        'rbPausada
        '
        Me.rbPausada.AutoSize = True
        Me.rbPausada.ForeColor = System.Drawing.Color.Black
        Me.rbPausada.Location = New System.Drawing.Point(180, 35)
        Me.rbPausada.Name = "rbPausada"
        Me.rbPausada.Size = New System.Drawing.Size(67, 17)
        Me.rbPausada.TabIndex = 8
        Me.rbPausada.Text = "Pausada"
        Me.rbPausada.UseVisualStyleBackColor = True
        '
        'rbAtivada
        '
        Me.rbAtivada.AutoSize = True
        Me.rbAtivada.ForeColor = System.Drawing.Color.Black
        Me.rbAtivada.Location = New System.Drawing.Point(98, 36)
        Me.rbAtivada.Name = "rbAtivada"
        Me.rbAtivada.Size = New System.Drawing.Size(61, 17)
        Me.rbAtivada.TabIndex = 8
        Me.rbAtivada.Text = "Ativada"
        Me.rbAtivada.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(4, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(70, 61)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PainelMenu
        '
        Me.PainelMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(67, Byte), Integer))
        Me.PainelMenu.BackgroundImage = CType(resources.GetObject("PainelMenu.BackgroundImage"), System.Drawing.Image)
        Me.PainelMenu.Controls.Add(Me.btnEscolherPasta)
        Me.PainelMenu.Controls.Add(Me.lblLocalSalvamento)
        Me.PainelMenu.Controls.Add(Me.lblPastaPadrao)
        Me.PainelMenu.Controls.Add(Me.Label9)
        Me.PainelMenu.Controls.Add(Me.Label7)
        Me.PainelMenu.Controls.Add(Me.Label1)
        Me.PainelMenu.Controls.Add(Me.chkAudioVideo)
        Me.PainelMenu.Controls.Add(Me.chkImagens)
        Me.PainelMenu.Controls.Add(Me.chkBiblia)
        Me.PainelMenu.Controls.Add(Me.chkHarpa)
        Me.PainelMenu.Controls.Add(Me.chkInternet)
        Me.PainelMenu.Controls.Add(Me.chkFundo)
        Me.PainelMenu.Controls.Add(Me.btnSalvarImagem)
        Me.PainelMenu.Controls.Add(Me.btnOpcoes)
        Me.PainelMenu.Controls.Add(Me.ComboMonitor)
        Me.PainelMenu.Controls.Add(Me.GroupBox1)
        Me.PainelMenu.Controls.Add(Me.Label2)
        Me.PainelMenu.Controls.Add(Me.btnAudioVideo)
        Me.PainelMenu.Controls.Add(Me.btnImagens)
        Me.PainelMenu.Controls.Add(Me.PictureBox1)
        Me.PainelMenu.Controls.Add(Me.btnBiblia)
        Me.PainelMenu.Controls.Add(Me.btnHarpa)
        Me.PainelMenu.Controls.Add(Me.btnInternet)
        Me.PainelMenu.Controls.Add(Me.btnFundo)
        Me.PainelMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.PainelMenu.Location = New System.Drawing.Point(0, 0)
        Me.PainelMenu.Name = "PainelMenu"
        Me.PainelMenu.Size = New System.Drawing.Size(436, 621)
        Me.PainelMenu.TabIndex = 1
        '
        'btnEscolherPasta
        '
        Me.btnEscolherPasta.BackColor = System.Drawing.Color.DarkGray
        Me.btnEscolherPasta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEscolherPasta.Image = CType(resources.GetObject("btnEscolherPasta.Image"), System.Drawing.Image)
        Me.btnEscolherPasta.Location = New System.Drawing.Point(122, 555)
        Me.btnEscolherPasta.Name = "btnEscolherPasta"
        Me.btnEscolherPasta.Size = New System.Drawing.Size(18, 16)
        Me.btnEscolherPasta.TabIndex = 21
        Me.btnEscolherPasta.UseVisualStyleBackColor = False
        '
        'lblLocalSalvamento
        '
        Me.lblLocalSalvamento.BackColor = System.Drawing.Color.Transparent
        Me.lblLocalSalvamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLocalSalvamento.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblLocalSalvamento.Location = New System.Drawing.Point(4, 573)
        Me.lblLocalSalvamento.Name = "lblLocalSalvamento"
        Me.lblLocalSalvamento.Size = New System.Drawing.Size(426, 42)
        Me.lblLocalSalvamento.TabIndex = 20
        Me.lblLocalSalvamento.Text = "Caminho padrão não localizado."
        '
        'lblPastaPadrao
        '
        Me.lblPastaPadrao.AutoSize = True
        Me.lblPastaPadrao.BackColor = System.Drawing.Color.Transparent
        Me.lblPastaPadrao.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblPastaPadrao.Location = New System.Drawing.Point(83, 536)
        Me.lblPastaPadrao.Name = "lblPastaPadrao"
        Me.lblPastaPadrao.Size = New System.Drawing.Size(287, 13)
        Me.lblPastaPadrao.TabIndex = 19
        Me.lblPastaPadrao.Text = "\ProjectionManager\IMAGENS\2-Imagens Caracterizadas\"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(14, 536)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Pasta padrão:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(14, 558)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Local de salvamento:"
        '
        'chkAudioVideo
        '
        Me.chkAudioVideo.BackColor = System.Drawing.Color.Transparent
        Me.chkAudioVideo.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkAudioVideo.Enabled = False
        Me.chkAudioVideo.Location = New System.Drawing.Point(183, 135)
        Me.chkAudioVideo.Name = "chkAudioVideo"
        Me.chkAudioVideo.Size = New System.Drawing.Size(92, 18)
        Me.chkAudioVideo.TabIndex = 17
        Me.chkAudioVideo.UseVisualStyleBackColor = False
        '
        'chkImagens
        '
        Me.chkImagens.BackColor = System.Drawing.Color.Transparent
        Me.chkImagens.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkImagens.Enabled = False
        Me.chkImagens.Location = New System.Drawing.Point(122, 135)
        Me.chkImagens.Name = "chkImagens"
        Me.chkImagens.Size = New System.Drawing.Size(55, 18)
        Me.chkImagens.TabIndex = 16
        Me.chkImagens.UseVisualStyleBackColor = False
        '
        'chkBiblia
        '
        Me.chkBiblia.BackColor = System.Drawing.Color.Transparent
        Me.chkBiblia.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkBiblia.Enabled = False
        Me.chkBiblia.Location = New System.Drawing.Point(343, 135)
        Me.chkBiblia.Name = "chkBiblia"
        Me.chkBiblia.Size = New System.Drawing.Size(50, 18)
        Me.chkBiblia.TabIndex = 15
        Me.chkBiblia.UseVisualStyleBackColor = False
        '
        'chkInternet
        '
        Me.chkInternet.BackColor = System.Drawing.Color.Transparent
        Me.chkInternet.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkInternet.Enabled = False
        Me.chkInternet.Location = New System.Drawing.Point(2, 135)
        Me.chkInternet.Name = "chkInternet"
        Me.chkInternet.Size = New System.Drawing.Size(55, 18)
        Me.chkInternet.TabIndex = 19
        Me.chkInternet.UseVisualStyleBackColor = False
        '
        'chkHarpa
        '
        Me.chkHarpa.BackColor = System.Drawing.Color.Transparent
        Me.chkHarpa.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkHarpa.Enabled = False
        Me.chkHarpa.Location = New System.Drawing.Point(285, 135)
        Me.chkHarpa.Name = "chkHarpa"
        Me.chkHarpa.Size = New System.Drawing.Size(50, 18)
        Me.chkHarpa.TabIndex = 14
        Me.chkHarpa.UseVisualStyleBackColor = False
        '
        'chkFundo
        '
        Me.chkFundo.BackColor = System.Drawing.Color.Transparent
        Me.chkFundo.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkFundo.Enabled = False
        Me.chkFundo.Location = New System.Drawing.Point(59, 135)
        Me.chkFundo.Name = "chkFundo"
        Me.chkFundo.Size = New System.Drawing.Size(54, 18)
        Me.chkFundo.TabIndex = 13
        Me.chkFundo.UseVisualStyleBackColor = False
        '
        'btnSalvarImagem
        '
        Me.btnSalvarImagem.BackColor = System.Drawing.Color.Transparent
        Me.btnSalvarImagem.FlatAppearance.BorderSize = 0
        Me.btnSalvarImagem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue
        Me.btnSalvarImagem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue
        Me.btnSalvarImagem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalvarImagem.ForeColor = System.Drawing.SystemColors.Window
        Me.btnSalvarImagem.Image = CType(resources.GetObject("btnSalvarImagem.Image"), System.Drawing.Image)
        Me.btnSalvarImagem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalvarImagem.Location = New System.Drawing.Point(15, 486)
        Me.btnSalvarImagem.Name = "btnSalvarImagem"
        Me.btnSalvarImagem.Size = New System.Drawing.Size(131, 47)
        Me.btnSalvarImagem.TabIndex = 11
        Me.btnSalvarImagem.Text = "Salvar Imagem Projetada"
        Me.btnSalvarImagem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalvarImagem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalvarImagem.UseVisualStyleBackColor = False
        '
        'btnOpcoes
        '
        Me.btnOpcoes.BackColor = System.Drawing.Color.Transparent
        Me.btnOpcoes.FlatAppearance.BorderSize = 0
        Me.btnOpcoes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue
        Me.btnOpcoes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue
        Me.btnOpcoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpcoes.ForeColor = System.Drawing.SystemColors.Window
        Me.btnOpcoes.Image = CType(resources.GetObject("btnOpcoes.Image"), System.Drawing.Image)
        Me.btnOpcoes.Location = New System.Drawing.Point(370, 473)
        Me.btnOpcoes.Name = "btnOpcoes"
        Me.btnOpcoes.Size = New System.Drawing.Size(60, 60)
        Me.btnOpcoes.TabIndex = 11
        Me.btnOpcoes.Text = "Opções"
        Me.btnOpcoes.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btnOpcoes.UseVisualStyleBackColor = False
        '
        'btnAudioVideo
        '
        Me.btnAudioVideo.BackColor = System.Drawing.Color.Transparent
        Me.btnAudioVideo.FlatAppearance.BorderSize = 0
        Me.btnAudioVideo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue
        Me.btnAudioVideo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue
        Me.btnAudioVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAudioVideo.ForeColor = System.Drawing.SystemColors.Window
        Me.btnAudioVideo.Image = CType(resources.GetObject("btnAudioVideo.Image"), System.Drawing.Image)
        Me.btnAudioVideo.Location = New System.Drawing.Point(183, 61)
        Me.btnAudioVideo.Name = "btnAudioVideo"
        Me.btnAudioVideo.Size = New System.Drawing.Size(92, 72)
        Me.btnAudioVideo.TabIndex = 10
        Me.btnAudioVideo.Text = "Audio/Imagem" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Vídeos"
        Me.btnAudioVideo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btnAudioVideo.UseVisualStyleBackColor = False
        '
        'btnImagens
        '
        Me.btnImagens.BackColor = System.Drawing.Color.Transparent
        Me.btnImagens.FlatAppearance.BorderSize = 0
        Me.btnImagens.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue
        Me.btnImagens.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue
        Me.btnImagens.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImagens.ForeColor = System.Drawing.SystemColors.Window
        Me.btnImagens.Image = CType(resources.GetObject("btnImagens.Image"), System.Drawing.Image)
        Me.btnImagens.Location = New System.Drawing.Point(122, 73)
        Me.btnImagens.Name = "btnImagens"
        Me.btnImagens.Size = New System.Drawing.Size(55, 60)
        Me.btnImagens.TabIndex = 9
        Me.btnImagens.Text = "Imagens"
        Me.btnImagens.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btnImagens.UseVisualStyleBackColor = False
        '
        'btnBiblia
        '
        Me.btnBiblia.BackColor = System.Drawing.Color.Transparent
        Me.btnBiblia.FlatAppearance.BorderSize = 0
        Me.btnBiblia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue
        Me.btnBiblia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue
        Me.btnBiblia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBiblia.ForeColor = System.Drawing.SystemColors.Window
        Me.btnBiblia.Image = CType(resources.GetObject("btnBiblia.Image"), System.Drawing.Image)
        Me.btnBiblia.Location = New System.Drawing.Point(343, 73)
        Me.btnBiblia.Name = "btnBiblia"
        Me.btnBiblia.Size = New System.Drawing.Size(50, 60)
        Me.btnBiblia.TabIndex = 8
        Me.btnBiblia.Text = " Bíblia"
        Me.btnBiblia.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btnBiblia.UseVisualStyleBackColor = False
        '
        'btnInternet
        '
        Me.btnInternet.BackColor = System.Drawing.Color.Transparent
        Me.btnInternet.FlatAppearance.BorderSize = 0
        Me.btnInternet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue
        Me.btnInternet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue
        Me.btnInternet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInternet.ForeColor = System.Drawing.SystemColors.Window
        Me.btnInternet.Image = CType(resources.GetObject("btnInternet.Image"), System.Drawing.Image)
        Me.btnInternet.Location = New System.Drawing.Point(2, 73)
        Me.btnInternet.Name = "btnInternet"
        Me.btnInternet.Size = New System.Drawing.Size(55, 60)
        Me.btnInternet.TabIndex = 18
        Me.btnInternet.Text = "Internet"
        Me.btnInternet.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btnInternet.UseVisualStyleBackColor = False
        '
        'btnHarpa
        '
        Me.btnHarpa.BackColor = System.Drawing.Color.Transparent
        Me.btnHarpa.FlatAppearance.BorderSize = 0
        Me.btnHarpa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue
        Me.btnHarpa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue
        Me.btnHarpa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHarpa.ForeColor = System.Drawing.SystemColors.Window
        Me.btnHarpa.Image = CType(resources.GetObject("btnHarpa.Image"), System.Drawing.Image)
        Me.btnHarpa.Location = New System.Drawing.Point(285, 73)
        Me.btnHarpa.Name = "btnHarpa"
        Me.btnHarpa.Size = New System.Drawing.Size(50, 60)
        Me.btnHarpa.TabIndex = 7
        Me.btnHarpa.Text = "Harpa"
        Me.btnHarpa.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btnHarpa.UseVisualStyleBackColor = False
        '
        'btnFundo
        '
        Me.btnFundo.BackColor = System.Drawing.Color.Transparent
        Me.btnFundo.FlatAppearance.BorderSize = 0
        Me.btnFundo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue
        Me.btnFundo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateBlue
        Me.btnFundo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFundo.ForeColor = System.Drawing.SystemColors.Window
        Me.btnFundo.Image = CType(resources.GetObject("btnFundo.Image"), System.Drawing.Image)
        Me.btnFundo.Location = New System.Drawing.Point(59, 73)
        Me.btnFundo.Name = "btnFundo"
        Me.btnFundo.Size = New System.Drawing.Size(54, 60)
        Me.btnFundo.TabIndex = 6
        Me.btnFundo.Text = "Fundo"
        Me.btnFundo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btnFundo.UseVisualStyleBackColor = False
        '
        'PainelControle
        '
        Me.PainelControle.BackColor = System.Drawing.Color.FromArgb(CType(CType(143, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.PainelControle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PainelControle.Location = New System.Drawing.Point(436, 0)
        Me.PainelControle.Name = "PainelControle"
        Me.PainelControle.Size = New System.Drawing.Size(758, 621)
        Me.PainelControle.TabIndex = 2
        '
        'FormPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1194, 621)
        Me.Controls.Add(Me.PainelControle)
        Me.Controls.Add(Me.PainelMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1210, 660)
        Me.Name = "FormPrincipal"
        Me.Text = "Projection Manager"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.picStatusFechada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picStatusAtivada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picStatusPausada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PainelMenu.ResumeLayout(False)
        Me.PainelMenu.PerformLayout()
        CType(Me.webPrevia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PainelMenu As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PainelControle As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ComboMonitor As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnFundo As Button
    Friend WithEvents btnAudioVideo As Button
    Friend WithEvents btnImagens As Button
    Friend WithEvents btnBiblia As Button
    Friend WithEvents btnHarpa As Button
    Friend WithEvents btnInternet As Button
    Friend WithEvents btnOpcoes As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents rbNeutra As RadioButton
    Friend WithEvents rbPausada As RadioButton
    Friend WithEvents rbAtivada As RadioButton
    Friend WithEvents picStatusAtivada As PictureBox
    Friend WithEvents picStatusPausada As PictureBox
    Friend WithEvents chkFundo As CheckBox
    Friend WithEvents chkAudioVideo As CheckBox
    Friend WithEvents chkImagens As CheckBox
    Friend WithEvents chkBiblia As CheckBox
    Friend WithEvents chkHarpa As CheckBox
    Friend WithEvents chkInternet As CheckBox
    Friend WithEvents lblLocalSalvamento As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btnSalvarImagem As Button
    Friend WithEvents btnEscolherPasta As Button
    Friend WithEvents lblPastaPadrao As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents rbFechada As RadioButton
    Friend WithEvents webPrevia As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents picStatusFechada As PictureBox
End Class
