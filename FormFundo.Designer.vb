<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormFundo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFundo))
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.webPastas = New System.Windows.Forms.WebBrowser()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblTituloTextos = New System.Windows.Forms.Label()
        Me.tabTextos = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnEditarRodape = New System.Windows.Forms.Button()
        Me.btnEditarCorpo = New System.Windows.Forms.Button()
        Me.btnEditarSubtitulo = New System.Windows.Forms.Button()
        Me.txtIdRodape = New System.Windows.Forms.TextBox()
        Me.txtIdCorpo = New System.Windows.Forms.TextBox()
        Me.txtIdTitulo = New System.Windows.Forms.TextBox()
        Me.txtIdSubtitulo = New System.Windows.Forms.TextBox()
        Me.txtRodape = New System.Windows.Forms.TextBox()
        Me.chkTitulo = New System.Windows.Forms.CheckBox()
        Me.chkSubtitulo = New System.Windows.Forms.CheckBox()
        Me.chkRodape = New System.Windows.Forms.CheckBox()
        Me.txtTitulo = New System.Windows.Forms.TextBox()
        Me.txtCorpo = New System.Windows.Forms.TextBox()
        Me.txtSubtitulo = New System.Windows.Forms.TextBox()
        Me.chkCorpo = New System.Windows.Forms.CheckBox()
        Me.btnEditarTitulo = New System.Windows.Forms.Button()
        Me.trkZoom = New System.Windows.Forms.TrackBar()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblZoom = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnNovoTexto = New System.Windows.Forms.Button()
        Me.btnVoltarSalvar = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.btnFundoTransparente = New System.Windows.Forms.Button()
        Me.lblCorPreenchimento = New System.Windows.Forms.Label()
        Me.btnCorFundo = New System.Windows.Forms.Button()
        Me.lblAmostraFundo = New System.Windows.Forms.Label()
        Me.lblTipoTexto = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.lblFonteCor = New System.Windows.Forms.Label()
        Me.lblFonteNome = New System.Windows.Forms.Label()
        Me.btnFonte = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblFonteTamanho = New System.Windows.Forms.Label()
        Me.lblFonteEstilo = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnAlinhaInfDir = New System.Windows.Forms.Button()
        Me.btnAlinhaInfCentro = New System.Windows.Forms.Button()
        Me.btnAlinhaInfEsq = New System.Windows.Forms.Button()
        Me.btnAlinhaMeioDir = New System.Windows.Forms.Button()
        Me.btnAlinhaMeioCentro = New System.Windows.Forms.Button()
        Me.btnAlinhaMeioEsq = New System.Windows.Forms.Button()
        Me.btnAlinhaSupCentro = New System.Windows.Forms.Button()
        Me.lblAlinhamento = New System.Windows.Forms.Label()
        Me.btnAlinhaSupDir = New System.Windows.Forms.Button()
        Me.btnAlinhaSupEsq = New System.Windows.Forms.Button()
        Me.dgvTextos = New System.Windows.Forms.DataGridView()
        Me.txtEdicaoId = New System.Windows.Forms.TextBox()
        Me.txtEdicaoTexto = New System.Windows.Forms.TextBox()
        Me.cboPastas = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnVoltarPasta = New System.Windows.Forms.Button()
        Me.rbMinhasImagens = New System.Windows.Forms.RadioButton()
        Me.rbGerenciador = New System.Windows.Forms.RadioButton()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblPrevCorpo = New System.Windows.Forms.Label()
        Me.lblPrevSubtitulo = New System.Windows.Forms.Label()
        Me.lblPrevTitulo = New System.Windows.Forms.Label()
        Me.lblPrevRodape = New System.Windows.Forms.Label()
        Me.picPreview = New System.Windows.Forms.PictureBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbLigado = New System.Windows.Forms.RadioButton()
        Me.rbDesligado = New System.Windows.Forms.RadioButton()
        Me.btnNovaImagem = New System.Windows.Forms.Button()
        Me.lblArquivo = New System.Windows.Forms.Label()
        Me.lblIndiceImagem = New System.Windows.Forms.Label()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox1.SuspendLayout()
        Me.tabTextos.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        CType(Me.trkZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgvTextos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'webPastas
        '
        Me.webPastas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.webPastas.Location = New System.Drawing.Point(0, 68)
        Me.webPastas.Margin = New System.Windows.Forms.Padding(0)
        Me.webPastas.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webPastas.Name = "webPastas"
        Me.webPastas.Size = New System.Drawing.Size(418, 512)
        Me.webPastas.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.lblTituloTextos)
        Me.GroupBox1.Controls.Add(Me.tabTextos)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(410, 250)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'lblTituloTextos
        '
        Me.lblTituloTextos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloTextos.Location = New System.Drawing.Point(-3, -6)
        Me.lblTituloTextos.Name = "lblTituloTextos"
        Me.lblTituloTextos.Size = New System.Drawing.Size(403, 13)
        Me.lblTituloTextos.TabIndex = 13
        Me.lblTituloTextos.Text = "    TEXTOS"
        Me.lblTituloTextos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabTextos
        '
        Me.tabTextos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabTextos.Controls.Add(Me.TabPage1)
        Me.tabTextos.Controls.Add(Me.TabPage2)
        Me.tabTextos.ItemSize = New System.Drawing.Size(44, 18)
        Me.tabTextos.Location = New System.Drawing.Point(3, 3)
        Me.tabTextos.Name = "tabTextos"
        Me.tabTextos.SelectedIndex = 0
        Me.tabTextos.Size = New System.Drawing.Size(404, 247)
        Me.tabTextos.TabIndex = 13
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Lavender
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel5)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(396, 221)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TEXTOS"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel5.ColumnCount = 4
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.btnEditarRodape, 3, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.btnEditarCorpo, 3, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.btnEditarSubtitulo, 3, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.txtIdRodape, 1, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.txtIdCorpo, 1, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.txtIdTitulo, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.txtIdSubtitulo, 1, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.txtRodape, 2, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.chkTitulo, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.chkSubtitulo, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.chkRodape, 0, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.txtTitulo, 2, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.txtCorpo, 2, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.txtSubtitulo, 2, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.chkCorpo, 0, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.btnEditarTitulo, 3, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.trkZoom, 2, 5)
        Me.TableLayoutPanel5.Controls.Add(Me.Label17, 2, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.lblZoom, 1, 5)
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 6
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(390, 216)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'btnEditarRodape
        '
        Me.btnEditarRodape.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditarRodape.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnEditarRodape.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditarRodape.Image = CType(resources.GetObject("btnEditarRodape.Image"), System.Drawing.Image)
        Me.btnEditarRodape.Location = New System.Drawing.Point(369, 115)
        Me.btnEditarRodape.Name = "btnEditarRodape"
        Me.btnEditarRodape.Size = New System.Drawing.Size(18, 22)
        Me.btnEditarRodape.TabIndex = 15
        Me.btnEditarRodape.UseVisualStyleBackColor = False
        Me.btnEditarRodape.Visible = False
        '
        'btnEditarCorpo
        '
        Me.btnEditarCorpo.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnEditarCorpo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditarCorpo.Image = CType(resources.GetObject("btnEditarCorpo.Image"), System.Drawing.Image)
        Me.btnEditarCorpo.Location = New System.Drawing.Point(369, 59)
        Me.btnEditarCorpo.Name = "btnEditarCorpo"
        Me.btnEditarCorpo.Size = New System.Drawing.Size(18, 22)
        Me.btnEditarCorpo.TabIndex = 14
        Me.btnEditarCorpo.UseVisualStyleBackColor = False
        Me.btnEditarCorpo.Visible = False
        '
        'btnEditarSubtitulo
        '
        Me.btnEditarSubtitulo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditarSubtitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnEditarSubtitulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditarSubtitulo.Image = CType(resources.GetObject("btnEditarSubtitulo.Image"), System.Drawing.Image)
        Me.btnEditarSubtitulo.Location = New System.Drawing.Point(369, 31)
        Me.btnEditarSubtitulo.Name = "btnEditarSubtitulo"
        Me.btnEditarSubtitulo.Size = New System.Drawing.Size(18, 22)
        Me.btnEditarSubtitulo.TabIndex = 13
        Me.btnEditarSubtitulo.UseVisualStyleBackColor = False
        Me.btnEditarSubtitulo.Visible = False
        '
        'txtIdRodape
        '
        Me.txtIdRodape.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIdRodape.BackColor = System.Drawing.Color.Lavender
        Me.txtIdRodape.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdRodape.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtIdRodape.Location = New System.Drawing.Point(78, 115)
        Me.txtIdRodape.Multiline = True
        Me.txtIdRodape.Name = "txtIdRodape"
        Me.txtIdRodape.ReadOnly = True
        Me.txtIdRodape.Size = New System.Drawing.Size(29, 22)
        Me.txtIdRodape.TabIndex = 8
        '
        'txtIdCorpo
        '
        Me.txtIdCorpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIdCorpo.BackColor = System.Drawing.Color.Lavender
        Me.txtIdCorpo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdCorpo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtIdCorpo.Location = New System.Drawing.Point(78, 59)
        Me.txtIdCorpo.Multiline = True
        Me.txtIdCorpo.Name = "txtIdCorpo"
        Me.txtIdCorpo.ReadOnly = True
        Me.txtIdCorpo.Size = New System.Drawing.Size(29, 50)
        Me.txtIdCorpo.TabIndex = 8
        '
        'txtIdTitulo
        '
        Me.txtIdTitulo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIdTitulo.BackColor = System.Drawing.Color.Lavender
        Me.txtIdTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtIdTitulo.Location = New System.Drawing.Point(78, 3)
        Me.txtIdTitulo.Multiline = True
        Me.txtIdTitulo.Name = "txtIdTitulo"
        Me.txtIdTitulo.ReadOnly = True
        Me.txtIdTitulo.Size = New System.Drawing.Size(29, 22)
        Me.txtIdTitulo.TabIndex = 8
        '
        'txtIdSubtitulo
        '
        Me.txtIdSubtitulo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIdSubtitulo.BackColor = System.Drawing.Color.Lavender
        Me.txtIdSubtitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdSubtitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtIdSubtitulo.Location = New System.Drawing.Point(78, 31)
        Me.txtIdSubtitulo.Multiline = True
        Me.txtIdSubtitulo.Name = "txtIdSubtitulo"
        Me.txtIdSubtitulo.ReadOnly = True
        Me.txtIdSubtitulo.Size = New System.Drawing.Size(29, 22)
        Me.txtIdSubtitulo.TabIndex = 8
        '
        'txtRodape
        '
        Me.txtRodape.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRodape.BackColor = System.Drawing.Color.Lavender
        Me.txtRodape.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRodape.Location = New System.Drawing.Point(113, 115)
        Me.txtRodape.Multiline = True
        Me.txtRodape.Name = "txtRodape"
        Me.txtRodape.ReadOnly = True
        Me.txtRodape.Size = New System.Drawing.Size(250, 22)
        Me.txtRodape.TabIndex = 8
        '
        'chkTitulo
        '
        Me.chkTitulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkTitulo.AutoSize = True
        Me.chkTitulo.Location = New System.Drawing.Point(3, 3)
        Me.chkTitulo.Name = "chkTitulo"
        Me.chkTitulo.Size = New System.Drawing.Size(54, 22)
        Me.chkTitulo.TabIndex = 10
        Me.chkTitulo.Text = "Título"
        Me.chkTitulo.UseVisualStyleBackColor = True
        '
        'chkSubtitulo
        '
        Me.chkSubtitulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkSubtitulo.AutoSize = True
        Me.chkSubtitulo.Location = New System.Drawing.Point(3, 31)
        Me.chkSubtitulo.Name = "chkSubtitulo"
        Me.chkSubtitulo.Size = New System.Drawing.Size(69, 22)
        Me.chkSubtitulo.TabIndex = 10
        Me.chkSubtitulo.Text = "Subtítulo"
        Me.chkSubtitulo.UseVisualStyleBackColor = True
        '
        'chkRodape
        '
        Me.chkRodape.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkRodape.AutoSize = True
        Me.chkRodape.Location = New System.Drawing.Point(3, 115)
        Me.chkRodape.Name = "chkRodape"
        Me.chkRodape.Size = New System.Drawing.Size(64, 22)
        Me.chkRodape.TabIndex = 10
        Me.chkRodape.Text = "Rodapé"
        Me.chkRodape.UseVisualStyleBackColor = True
        '
        'txtTitulo
        '
        Me.txtTitulo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTitulo.BackColor = System.Drawing.Color.Lavender
        Me.txtTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTitulo.Location = New System.Drawing.Point(113, 3)
        Me.txtTitulo.Multiline = True
        Me.txtTitulo.Name = "txtTitulo"
        Me.txtTitulo.ReadOnly = True
        Me.txtTitulo.Size = New System.Drawing.Size(250, 22)
        Me.txtTitulo.TabIndex = 8
        '
        'txtCorpo
        '
        Me.txtCorpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCorpo.BackColor = System.Drawing.Color.Lavender
        Me.txtCorpo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCorpo.Location = New System.Drawing.Point(113, 59)
        Me.txtCorpo.Multiline = True
        Me.txtCorpo.Name = "txtCorpo"
        Me.txtCorpo.ReadOnly = True
        Me.txtCorpo.Size = New System.Drawing.Size(250, 50)
        Me.txtCorpo.TabIndex = 8
        '
        'txtSubtitulo
        '
        Me.txtSubtitulo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubtitulo.BackColor = System.Drawing.Color.Lavender
        Me.txtSubtitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubtitulo.Location = New System.Drawing.Point(113, 31)
        Me.txtSubtitulo.Multiline = True
        Me.txtSubtitulo.Name = "txtSubtitulo"
        Me.txtSubtitulo.ReadOnly = True
        Me.txtSubtitulo.Size = New System.Drawing.Size(250, 22)
        Me.txtSubtitulo.TabIndex = 8
        '
        'chkCorpo
        '
        Me.chkCorpo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkCorpo.AutoSize = True
        Me.chkCorpo.Location = New System.Drawing.Point(3, 59)
        Me.chkCorpo.Name = "chkCorpo"
        Me.chkCorpo.Size = New System.Drawing.Size(54, 50)
        Me.chkCorpo.TabIndex = 10
        Me.chkCorpo.Text = "Corpo"
        Me.chkCorpo.UseVisualStyleBackColor = True
        '
        'btnEditarTitulo
        '
        Me.btnEditarTitulo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditarTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnEditarTitulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditarTitulo.Image = CType(resources.GetObject("btnEditarTitulo.Image"), System.Drawing.Image)
        Me.btnEditarTitulo.Location = New System.Drawing.Point(369, 3)
        Me.btnEditarTitulo.Name = "btnEditarTitulo"
        Me.btnEditarTitulo.Size = New System.Drawing.Size(18, 22)
        Me.btnEditarTitulo.TabIndex = 12
        Me.btnEditarTitulo.UseVisualStyleBackColor = False
        Me.btnEditarTitulo.Visible = False
        '
        'trkZoom
        '
        Me.trkZoom.BackColor = System.Drawing.Color.White
        Me.trkZoom.Location = New System.Drawing.Point(113, 171)
        Me.trkZoom.Maximum = 128
        Me.trkZoom.Minimum = 50
        Me.trkZoom.Name = "trkZoom"
        Me.trkZoom.Size = New System.Drawing.Size(123, 42)
        Me.trkZoom.TabIndex = 45
        Me.trkZoom.Value = 88
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label17.Location = New System.Drawing.Point(113, 155)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(106, 13)
        Me.Label17.TabIndex = 10
        Me.Label17.Text = "   Zoom da Projeção:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblZoom
        '
        Me.lblZoom.AutoSize = True
        Me.lblZoom.BackColor = System.Drawing.Color.Lavender
        Me.lblZoom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZoom.ForeColor = System.Drawing.Color.DarkGray
        Me.lblZoom.Location = New System.Drawing.Point(78, 171)
        Me.lblZoom.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblZoom.Name = "lblZoom"
        Me.lblZoom.Size = New System.Drawing.Size(21, 13)
        Me.lblZoom.TabIndex = 46
        Me.lblZoom.Text = "88"
        Me.lblZoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.LightGray
        Me.TabPage2.Controls.Add(Me.btnNovoTexto)
        Me.TabPage2.Controls.Add(Me.btnVoltarSalvar)
        Me.TabPage2.Controls.Add(Me.GroupBox7)
        Me.TabPage2.Controls.Add(Me.lblTipoTexto)
        Me.TabPage2.Controls.Add(Me.GroupBox6)
        Me.TabPage2.Controls.Add(Me.GroupBox5)
        Me.TabPage2.Controls.Add(Me.dgvTextos)
        Me.TabPage2.Controls.Add(Me.txtEdicaoId)
        Me.TabPage2.Controls.Add(Me.txtEdicaoTexto)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(396, 221)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Edição"
        '
        'btnNovoTexto
        '
        Me.btnNovoTexto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNovoTexto.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnNovoTexto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNovoTexto.Location = New System.Drawing.Point(223, 1)
        Me.btnNovoTexto.Name = "btnNovoTexto"
        Me.btnNovoTexto.Size = New System.Drawing.Size(44, 23)
        Me.btnNovoTexto.TabIndex = 18
        Me.btnNovoTexto.Text = "Novo"
        Me.btnNovoTexto.UseVisualStyleBackColor = False
        Me.btnNovoTexto.Visible = False
        '
        'btnVoltarSalvar
        '
        Me.btnVoltarSalvar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVoltarSalvar.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnVoltarSalvar.FlatAppearance.BorderSize = 0
        Me.btnVoltarSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVoltarSalvar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoltarSalvar.Image = CType(resources.GetObject("btnVoltarSalvar.Image"), System.Drawing.Image)
        Me.btnVoltarSalvar.Location = New System.Drawing.Point(311, 7)
        Me.btnVoltarSalvar.Name = "btnVoltarSalvar"
        Me.btnVoltarSalvar.Size = New System.Drawing.Size(83, 38)
        Me.btnVoltarSalvar.TabIndex = 8
        Me.btnVoltarSalvar.Text = "Voltar"
        Me.btnVoltarSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVoltarSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVoltarSalvar.UseVisualStyleBackColor = False
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.Lavender
        Me.GroupBox7.Controls.Add(Me.btnFundoTransparente)
        Me.GroupBox7.Controls.Add(Me.lblCorPreenchimento)
        Me.GroupBox7.Controls.Add(Me.btnCorFundo)
        Me.GroupBox7.Controls.Add(Me.lblAmostraFundo)
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(98, 52)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(87, 72)
        Me.GroupBox7.TabIndex = 17
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Fundo:"
        '
        'btnFundoTransparente
        '
        Me.btnFundoTransparente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFundoTransparente.Location = New System.Drawing.Point(5, 39)
        Me.btnFundoTransparente.Name = "btnFundoTransparente"
        Me.btnFundoTransparente.Size = New System.Drawing.Size(78, 22)
        Me.btnFundoTransparente.TabIndex = 13
        Me.btnFundoTransparente.Text = "Transparente"
        Me.btnFundoTransparente.UseVisualStyleBackColor = True
        '
        'lblCorPreenchimento
        '
        Me.lblCorPreenchimento.BackColor = System.Drawing.Color.Lavender
        Me.lblCorPreenchimento.Font = New System.Drawing.Font("Microsoft Sans Serif", 3.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorPreenchimento.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblCorPreenchimento.Location = New System.Drawing.Point(8, 31)
        Me.lblCorPreenchimento.Name = "lblCorPreenchimento"
        Me.lblCorPreenchimento.Size = New System.Drawing.Size(51, 10)
        Me.lblCorPreenchimento.TabIndex = 12
        Me.lblCorPreenchimento.Text = "Cor"
        '
        'btnCorFundo
        '
        Me.btnCorFundo.FlatAppearance.BorderSize = 0
        Me.btnCorFundo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCorFundo.Image = CType(resources.GetObject("btnCorFundo.Image"), System.Drawing.Image)
        Me.btnCorFundo.Location = New System.Drawing.Point(51, 0)
        Me.btnCorFundo.Name = "btnCorFundo"
        Me.btnCorFundo.Size = New System.Drawing.Size(23, 25)
        Me.btnCorFundo.TabIndex = 11
        Me.btnCorFundo.UseVisualStyleBackColor = True
        '
        'lblAmostraFundo
        '
        Me.lblAmostraFundo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAmostraFundo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmostraFundo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblAmostraFundo.Location = New System.Drawing.Point(8, 14)
        Me.lblAmostraFundo.Name = "lblAmostraFundo"
        Me.lblAmostraFundo.Size = New System.Drawing.Size(37, 15)
        Me.lblAmostraFundo.TabIndex = 12
        '
        'lblTipoTexto
        '
        Me.lblTipoTexto.AutoSize = True
        Me.lblTipoTexto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoTexto.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTipoTexto.Location = New System.Drawing.Point(11, 7)
        Me.lblTipoTexto.Name = "lblTipoTexto"
        Me.lblTipoTexto.Size = New System.Drawing.Size(188, 13)
        Me.lblTipoTexto.TabIndex = 12
        Me.lblTipoTexto.Text = "Defina o tipo na aba:""TEXTOS"""
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.BackColor = System.Drawing.Color.Lavender
        Me.GroupBox6.Controls.Add(Me.lblFonteCor)
        Me.GroupBox6.Controls.Add(Me.lblFonteNome)
        Me.GroupBox6.Controls.Add(Me.btnFonte)
        Me.GroupBox6.Controls.Add(Me.Label12)
        Me.GroupBox6.Controls.Add(Me.lblFonteTamanho)
        Me.GroupBox6.Controls.Add(Me.lblFonteEstilo)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(187, 52)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(208, 72)
        Me.GroupBox6.TabIndex = 16
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Fonte:"
        '
        'lblFonteCor
        '
        Me.lblFonteCor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFonteCor.Font = New System.Drawing.Font("Microsoft Sans Serif", 3.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFonteCor.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblFonteCor.Location = New System.Drawing.Point(108, 13)
        Me.lblFonteCor.Name = "lblFonteCor"
        Me.lblFonteCor.Size = New System.Drawing.Size(41, 15)
        Me.lblFonteCor.TabIndex = 12
        Me.lblFonteCor.Text = "Cor"
        '
        'lblFonteNome
        '
        Me.lblFonteNome.AutoSize = True
        Me.lblFonteNome.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFonteNome.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblFonteNome.Location = New System.Drawing.Point(6, 36)
        Me.lblFonteNome.Name = "lblFonteNome"
        Me.lblFonteNome.Size = New System.Drawing.Size(49, 18)
        Me.lblFonteNome.TabIndex = 12
        Me.lblFonteNome.Text = "Nome"
        '
        'btnFonte
        '
        Me.btnFonte.FlatAppearance.BorderSize = 0
        Me.btnFonte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFonte.Image = CType(resources.GetObject("btnFonte.Image"), System.Drawing.Image)
        Me.btnFonte.Location = New System.Drawing.Point(51, -1)
        Me.btnFonte.Name = "btnFonte"
        Me.btnFonte.Size = New System.Drawing.Size(25, 25)
        Me.btnFonte.TabIndex = 11
        Me.btnFonte.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label12.Location = New System.Drawing.Point(82, 12)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 15)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Cor:"
        '
        'lblFonteTamanho
        '
        Me.lblFonteTamanho.AutoSize = True
        Me.lblFonteTamanho.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFonteTamanho.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblFonteTamanho.Location = New System.Drawing.Point(6, 16)
        Me.lblFonteTamanho.Name = "lblFonteTamanho"
        Me.lblFonteTamanho.Size = New System.Drawing.Size(32, 15)
        Me.lblFonteTamanho.TabIndex = 12
        Me.lblFonteTamanho.Text = "Tam"
        '
        'lblFonteEstilo
        '
        Me.lblFonteEstilo.AutoSize = True
        Me.lblFonteEstilo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFonteEstilo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblFonteEstilo.Location = New System.Drawing.Point(155, 13)
        Me.lblFonteEstilo.Name = "lblFonteEstilo"
        Me.lblFonteEstilo.Size = New System.Drawing.Size(37, 15)
        Me.lblFonteEstilo.TabIndex = 12
        Me.lblFonteEstilo.Text = "Estilo"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Lavender
        Me.GroupBox5.Controls.Add(Me.btnAlinhaInfDir)
        Me.GroupBox5.Controls.Add(Me.btnAlinhaInfCentro)
        Me.GroupBox5.Controls.Add(Me.btnAlinhaInfEsq)
        Me.GroupBox5.Controls.Add(Me.btnAlinhaMeioDir)
        Me.GroupBox5.Controls.Add(Me.btnAlinhaMeioCentro)
        Me.GroupBox5.Controls.Add(Me.btnAlinhaMeioEsq)
        Me.GroupBox5.Controls.Add(Me.btnAlinhaSupCentro)
        Me.GroupBox5.Controls.Add(Me.lblAlinhamento)
        Me.GroupBox5.Controls.Add(Me.btnAlinhaSupDir)
        Me.GroupBox5.Controls.Add(Me.btnAlinhaSupEsq)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(5, 51)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(91, 73)
        Me.GroupBox5.TabIndex = 15
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Alinhamento:"
        '
        'btnAlinhaInfDir
        '
        Me.btnAlinhaInfDir.FlatAppearance.BorderSize = 0
        Me.btnAlinhaInfDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAlinhaInfDir.Image = CType(resources.GetObject("btnAlinhaInfDir.Image"), System.Drawing.Image)
        Me.btnAlinhaInfDir.Location = New System.Drawing.Point(43, 49)
        Me.btnAlinhaInfDir.Name = "btnAlinhaInfDir"
        Me.btnAlinhaInfDir.Size = New System.Drawing.Size(19, 19)
        Me.btnAlinhaInfDir.TabIndex = 18
        Me.btnAlinhaInfDir.UseVisualStyleBackColor = True
        '
        'btnAlinhaInfCentro
        '
        Me.btnAlinhaInfCentro.FlatAppearance.BorderSize = 0
        Me.btnAlinhaInfCentro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAlinhaInfCentro.Image = CType(resources.GetObject("btnAlinhaInfCentro.Image"), System.Drawing.Image)
        Me.btnAlinhaInfCentro.Location = New System.Drawing.Point(25, 49)
        Me.btnAlinhaInfCentro.Name = "btnAlinhaInfCentro"
        Me.btnAlinhaInfCentro.Size = New System.Drawing.Size(19, 19)
        Me.btnAlinhaInfCentro.TabIndex = 17
        Me.btnAlinhaInfCentro.UseVisualStyleBackColor = True
        '
        'btnAlinhaInfEsq
        '
        Me.btnAlinhaInfEsq.FlatAppearance.BorderSize = 0
        Me.btnAlinhaInfEsq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAlinhaInfEsq.Image = CType(resources.GetObject("btnAlinhaInfEsq.Image"), System.Drawing.Image)
        Me.btnAlinhaInfEsq.Location = New System.Drawing.Point(6, 49)
        Me.btnAlinhaInfEsq.Name = "btnAlinhaInfEsq"
        Me.btnAlinhaInfEsq.Size = New System.Drawing.Size(19, 19)
        Me.btnAlinhaInfEsq.TabIndex = 16
        Me.btnAlinhaInfEsq.UseVisualStyleBackColor = True
        '
        'btnAlinhaMeioDir
        '
        Me.btnAlinhaMeioDir.FlatAppearance.BorderSize = 0
        Me.btnAlinhaMeioDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAlinhaMeioDir.Image = CType(resources.GetObject("btnAlinhaMeioDir.Image"), System.Drawing.Image)
        Me.btnAlinhaMeioDir.Location = New System.Drawing.Point(43, 31)
        Me.btnAlinhaMeioDir.Name = "btnAlinhaMeioDir"
        Me.btnAlinhaMeioDir.Size = New System.Drawing.Size(19, 19)
        Me.btnAlinhaMeioDir.TabIndex = 15
        Me.btnAlinhaMeioDir.UseVisualStyleBackColor = True
        '
        'btnAlinhaMeioCentro
        '
        Me.btnAlinhaMeioCentro.FlatAppearance.BorderSize = 0
        Me.btnAlinhaMeioCentro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAlinhaMeioCentro.Image = CType(resources.GetObject("btnAlinhaMeioCentro.Image"), System.Drawing.Image)
        Me.btnAlinhaMeioCentro.Location = New System.Drawing.Point(25, 31)
        Me.btnAlinhaMeioCentro.Name = "btnAlinhaMeioCentro"
        Me.btnAlinhaMeioCentro.Size = New System.Drawing.Size(19, 19)
        Me.btnAlinhaMeioCentro.TabIndex = 14
        Me.btnAlinhaMeioCentro.UseVisualStyleBackColor = True
        '
        'btnAlinhaMeioEsq
        '
        Me.btnAlinhaMeioEsq.FlatAppearance.BorderSize = 0
        Me.btnAlinhaMeioEsq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAlinhaMeioEsq.Image = CType(resources.GetObject("btnAlinhaMeioEsq.Image"), System.Drawing.Image)
        Me.btnAlinhaMeioEsq.Location = New System.Drawing.Point(6, 31)
        Me.btnAlinhaMeioEsq.Name = "btnAlinhaMeioEsq"
        Me.btnAlinhaMeioEsq.Size = New System.Drawing.Size(19, 19)
        Me.btnAlinhaMeioEsq.TabIndex = 13
        Me.btnAlinhaMeioEsq.UseVisualStyleBackColor = True
        '
        'btnAlinhaSupCentro
        '
        Me.btnAlinhaSupCentro.FlatAppearance.BorderSize = 0
        Me.btnAlinhaSupCentro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAlinhaSupCentro.Image = CType(resources.GetObject("btnAlinhaSupCentro.Image"), System.Drawing.Image)
        Me.btnAlinhaSupCentro.Location = New System.Drawing.Point(25, 13)
        Me.btnAlinhaSupCentro.Name = "btnAlinhaSupCentro"
        Me.btnAlinhaSupCentro.Size = New System.Drawing.Size(19, 19)
        Me.btnAlinhaSupCentro.TabIndex = 11
        Me.btnAlinhaSupCentro.UseVisualStyleBackColor = True
        '
        'lblAlinhamento
        '
        Me.lblAlinhamento.AutoSize = True
        Me.lblAlinhamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlinhamento.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblAlinhamento.Location = New System.Drawing.Point(62, 19)
        Me.lblAlinhamento.Name = "lblAlinhamento"
        Me.lblAlinhamento.Size = New System.Drawing.Size(17, 9)
        Me.lblAlinhamento.TabIndex = 12
        Me.lblAlinhamento.Text = "Left"
        '
        'btnAlinhaSupDir
        '
        Me.btnAlinhaSupDir.FlatAppearance.BorderSize = 0
        Me.btnAlinhaSupDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAlinhaSupDir.Image = CType(resources.GetObject("btnAlinhaSupDir.Image"), System.Drawing.Image)
        Me.btnAlinhaSupDir.Location = New System.Drawing.Point(43, 13)
        Me.btnAlinhaSupDir.Name = "btnAlinhaSupDir"
        Me.btnAlinhaSupDir.Size = New System.Drawing.Size(19, 19)
        Me.btnAlinhaSupDir.TabIndex = 11
        Me.btnAlinhaSupDir.UseVisualStyleBackColor = True
        '
        'btnAlinhaSupEsq
        '
        Me.btnAlinhaSupEsq.BackColor = System.Drawing.Color.SteelBlue
        Me.btnAlinhaSupEsq.FlatAppearance.BorderSize = 0
        Me.btnAlinhaSupEsq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAlinhaSupEsq.Image = CType(resources.GetObject("btnAlinhaSupEsq.Image"), System.Drawing.Image)
        Me.btnAlinhaSupEsq.Location = New System.Drawing.Point(6, 13)
        Me.btnAlinhaSupEsq.Name = "btnAlinhaSupEsq"
        Me.btnAlinhaSupEsq.Size = New System.Drawing.Size(19, 19)
        Me.btnAlinhaSupEsq.TabIndex = 11
        Me.btnAlinhaSupEsq.UseVisualStyleBackColor = False
        '
        'dgvTextos
        '
        Me.dgvTextos.AllowUserToAddRows = False
        Me.dgvTextos.AllowUserToDeleteRows = False
        Me.dgvTextos.AllowUserToResizeColumns = False
        Me.dgvTextos.AllowUserToResizeRows = False
        Me.dgvTextos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTextos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTextos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvTextos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTextos.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvTextos.Location = New System.Drawing.Point(3, 125)
        Me.dgvTextos.Name = "dgvTextos"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTextos.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvTextos.Size = New System.Drawing.Size(394, 90)
        Me.dgvTextos.TabIndex = 14
        '
        'txtEdicaoId
        '
        Me.txtEdicaoId.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEdicaoId.BackColor = System.Drawing.Color.Gainsboro
        Me.txtEdicaoId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEdicaoId.Location = New System.Drawing.Point(269, 3)
        Me.txtEdicaoId.Name = "txtEdicaoId"
        Me.txtEdicaoId.Size = New System.Drawing.Size(36, 21)
        Me.txtEdicaoId.TabIndex = 13
        '
        'txtEdicaoTexto
        '
        Me.txtEdicaoTexto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEdicaoTexto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEdicaoTexto.Location = New System.Drawing.Point(6, 24)
        Me.txtEdicaoTexto.Name = "txtEdicaoTexto"
        Me.txtEdicaoTexto.Size = New System.Drawing.Size(299, 21)
        Me.txtEdicaoTexto.TabIndex = 13
        '
        'cboPastas
        '
        Me.cboPastas.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboPastas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPastas.FormattingEnabled = True
        Me.cboPastas.Location = New System.Drawing.Point(4, 35)
        Me.cboPastas.Name = "cboPastas"
        Me.cboPastas.Size = New System.Drawing.Size(182, 21)
        Me.cboPastas.TabIndex = 5
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 418.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.webPastas, 0, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(418, 580)
        Me.TableLayoutPanel1.TabIndex = 11
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnVoltarPasta)
        Me.GroupBox2.Controls.Add(Me.rbMinhasImagens)
        Me.GroupBox2.Controls.Add(Me.rbGerenciador)
        Me.GroupBox2.Controls.Add(Me.cboPastas)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(412, 62)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "IMAGEM DE FUNDO"
        '
        'btnVoltarPasta
        '
        Me.btnVoltarPasta.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnVoltarPasta.FlatAppearance.BorderSize = 0
        Me.btnVoltarPasta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVoltarPasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoltarPasta.Image = CType(resources.GetObject("btnVoltarPasta.Image"), System.Drawing.Image)
        Me.btnVoltarPasta.Location = New System.Drawing.Point(272, 32)
        Me.btnVoltarPasta.Name = "btnVoltarPasta"
        Me.btnVoltarPasta.Size = New System.Drawing.Size(68, 27)
        Me.btnVoltarPasta.TabIndex = 8
        Me.btnVoltarPasta.Text = "Voltar"
        Me.btnVoltarPasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVoltarPasta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVoltarPasta.UseVisualStyleBackColor = True
        '
        'rbMinhasImagens
        '
        Me.rbMinhasImagens.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.rbMinhasImagens.AutoSize = True
        Me.rbMinhasImagens.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMinhasImagens.Location = New System.Drawing.Point(232, 15)
        Me.rbMinhasImagens.Name = "rbMinhasImagens"
        Me.rbMinhasImagens.Size = New System.Drawing.Size(102, 17)
        Me.rbMinhasImagens.TabIndex = 7
        Me.rbMinhasImagens.TabStop = True
        Me.rbMinhasImagens.Text = "Minhas Imagens"
        Me.rbMinhasImagens.UseVisualStyleBackColor = True
        '
        'rbGerenciador
        '
        Me.rbGerenciador.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbGerenciador.AutoSize = True
        Me.rbGerenciador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbGerenciador.Location = New System.Drawing.Point(7, 15)
        Me.rbGerenciador.Name = "rbGerenciador"
        Me.rbGerenciador.Size = New System.Drawing.Size(83, 17)
        Me.rbGerenciador.TabIndex = 6
        Me.rbGerenciador.TabStop = True
        Me.rbGerenciador.Text = "Gerenciador"
        Me.rbGerenciador.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox3, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox4, 0, 1)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(425, 1)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(1)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 242.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(416, 584)
        Me.TableLayoutPanel2.TabIndex = 12
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.lblPrevCorpo)
        Me.GroupBox3.Controls.Add(Me.lblPrevSubtitulo)
        Me.GroupBox3.Controls.Add(Me.lblPrevTitulo)
        Me.GroupBox3.Controls.Add(Me.lblPrevRodape)
        Me.GroupBox3.Controls.Add(Me.picPreview)
        Me.GroupBox3.Location = New System.Drawing.Point(0, 341)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(416, 243)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        '
        'lblPrevCorpo
        '
        Me.lblPrevCorpo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPrevCorpo.BackColor = System.Drawing.Color.Transparent
        Me.lblPrevCorpo.Location = New System.Drawing.Point(2, 60)
        Me.lblPrevCorpo.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPrevCorpo.Name = "lblPrevCorpo"
        Me.lblPrevCorpo.Size = New System.Drawing.Size(410, 138)
        Me.lblPrevCorpo.TabIndex = 7
        '
        'lblPrevSubtitulo
        '
        Me.lblPrevSubtitulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPrevSubtitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblPrevSubtitulo.Location = New System.Drawing.Point(2, 33)
        Me.lblPrevSubtitulo.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPrevSubtitulo.Name = "lblPrevSubtitulo"
        Me.lblPrevSubtitulo.Size = New System.Drawing.Size(410, 27)
        Me.lblPrevSubtitulo.TabIndex = 6
        '
        'lblPrevTitulo
        '
        Me.lblPrevTitulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPrevTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblPrevTitulo.Location = New System.Drawing.Point(2, 2)
        Me.lblPrevTitulo.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPrevTitulo.Name = "lblPrevTitulo"
        Me.lblPrevTitulo.Size = New System.Drawing.Size(410, 31)
        Me.lblPrevTitulo.TabIndex = 5
        '
        'lblPrevRodape
        '
        Me.lblPrevRodape.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPrevRodape.BackColor = System.Drawing.Color.Transparent
        Me.lblPrevRodape.Location = New System.Drawing.Point(2, 196)
        Me.lblPrevRodape.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPrevRodape.Name = "lblPrevRodape"
        Me.lblPrevRodape.Size = New System.Drawing.Size(410, 27)
        Me.lblPrevRodape.TabIndex = 4
        '
        'picPreview
        '
        Me.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picPreview.Location = New System.Drawing.Point(3, 16)
        Me.picPreview.Margin = New System.Windows.Forms.Padding(2, 3, 2, 2)
        Me.picPreview.Name = "picPreview"
        Me.picPreview.Size = New System.Drawing.Size(410, 224)
        Me.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picPreview.TabIndex = 0
        Me.picPreview.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.rbLigado)
        Me.GroupBox4.Controls.Add(Me.rbDesligado)
        Me.GroupBox4.Controls.Add(Me.btnNovaImagem)
        Me.GroupBox4.Controls.Add(Me.lblArquivo)
        Me.GroupBox4.Controls.Add(Me.lblIndiceImagem)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 259)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(410, 79)
        Me.GroupBox4.TabIndex = 12
        Me.GroupBox4.TabStop = False
        '
        'rbLigado
        '
        Me.rbLigado.BackColor = System.Drawing.Color.Transparent
        Me.rbLigado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbLigado.Image = CType(resources.GetObject("rbLigado.Image"), System.Drawing.Image)
        Me.rbLigado.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbLigado.Location = New System.Drawing.Point(284, 12)
        Me.rbLigado.Name = "rbLigado"
        Me.rbLigado.Size = New System.Drawing.Size(93, 38)
        Me.rbLigado.TabIndex = 14
        Me.rbLigado.TabStop = True
        Me.rbLigado.Text = "Ligado"
        Me.rbLigado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rbLigado.UseVisualStyleBackColor = False
        '
        'rbDesligado
        '
        Me.rbDesligado.BackColor = System.Drawing.Color.AliceBlue
        Me.rbDesligado.Checked = True
        Me.rbDesligado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDesligado.Image = CType(resources.GetObject("rbDesligado.Image"), System.Drawing.Image)
        Me.rbDesligado.Location = New System.Drawing.Point(156, 12)
        Me.rbDesligado.Name = "rbDesligado"
        Me.rbDesligado.Size = New System.Drawing.Size(111, 38)
        Me.rbDesligado.TabIndex = 13
        Me.rbDesligado.TabStop = True
        Me.rbDesligado.Text = "Desligado"
        Me.rbDesligado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rbDesligado.UseVisualStyleBackColor = False
        '
        'btnNovaImagem
        '
        Me.btnNovaImagem.Image = CType(resources.GetObject("btnNovaImagem.Image"), System.Drawing.Image)
        Me.btnNovaImagem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNovaImagem.Location = New System.Drawing.Point(0, 6)
        Me.btnNovaImagem.Name = "btnNovaImagem"
        Me.btnNovaImagem.Size = New System.Drawing.Size(98, 25)
        Me.btnNovaImagem.TabIndex = 11
        Me.btnNovaImagem.Text = "Nova Imagem"
        Me.btnNovaImagem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNovaImagem.UseVisualStyleBackColor = True
        '
        'lblArquivo
        '
        Me.lblArquivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblArquivo.AutoSize = True
        Me.lblArquivo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblArquivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblArquivo.Location = New System.Drawing.Point(3, 58)
        Me.lblArquivo.Name = "lblArquivo"
        Me.lblArquivo.Size = New System.Drawing.Size(88, 13)
        Me.lblArquivo.TabIndex = 10
        Me.lblArquivo.Text = "Nome do arquivo"
        Me.lblArquivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIndiceImagem
        '
        Me.lblIndiceImagem.AutoSize = True
        Me.lblIndiceImagem.Location = New System.Drawing.Point(104, 12)
        Me.lblIndiceImagem.Name = "lblIndiceImagem"
        Me.lblIndiceImagem.Size = New System.Drawing.Size(13, 13)
        Me.lblIndiceImagem.TabIndex = 12
        Me.lblIndiceImagem.Text = "0"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 418.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel1, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel2, 1, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(2, 2)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(1)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(842, 586)
        Me.TableLayoutPanel3.TabIndex = 13
        '
        'FormFundo
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(844, 589)
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Name = "FormFundo"
        Me.Text = "Form Fundo"
        Me.GroupBox1.ResumeLayout(False)
        Me.tabTextos.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        CType(Me.trkZoom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.dgvTextos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents webPastas As WebBrowser
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnAlinhaSupDir As Button
    Friend WithEvents btnAlinhaSupCentro As Button
    Friend WithEvents btnAlinhaSupEsq As Button
    Friend WithEvents txtCorpo As TextBox
    Friend WithEvents cboPastas As ComboBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rbMinhasImagens As RadioButton
    Friend WithEvents rbGerenciador As RadioButton
    Friend WithEvents btnVoltarPasta As Button
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents lblArquivo As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents picPreview As PictureBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btnNovaImagem As Button
    Friend WithEvents lblIndiceImagem As Label
    Friend WithEvents rbDesligado As RadioButton
    Friend WithEvents rbLigado As RadioButton
    Friend WithEvents tabTextos As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents txtIdRodape As TextBox
    Friend WithEvents txtIdCorpo As TextBox
    Friend WithEvents txtIdSubtitulo As TextBox
    Friend WithEvents chkRodape As CheckBox
    Friend WithEvents chkCorpo As CheckBox
    Friend WithEvents chkSubtitulo As CheckBox
    Friend WithEvents chkTitulo As CheckBox
    Friend WithEvents txtTitulo As TextBox
    Friend WithEvents txtSubtitulo As TextBox
    Friend WithEvents txtIdTitulo As TextBox
    Friend WithEvents txtRodape As TextBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents btnEditarTitulo As Button
    Friend WithEvents btnEditarRodape As Button
    Friend WithEvents btnEditarCorpo As Button
    Friend WithEvents btnEditarSubtitulo As Button
    Friend WithEvents txtEdicaoId As TextBox
    Friend WithEvents txtEdicaoTexto As TextBox
    Friend WithEvents dgvTextos As DataGridView
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents btnFonte As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents btnCorFundo As Button
    Friend WithEvents btnVoltarSalvar As Button
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents lblCorPreenchimento As Label
    Friend WithEvents lblTipoTexto As Label
    Friend WithEvents lblFonteCor As Label
    Friend WithEvents lblFonteTamanho As Label
    Friend WithEvents lblFonteEstilo As Label
    Friend WithEvents lblFonteNome As Label
    Friend WithEvents lblAlinhamento As Label
    Friend WithEvents btnNovoTexto As Button
    Friend WithEvents lblPrevRodape As Label
    Friend WithEvents lblPrevCorpo As Label
    Friend WithEvents lblPrevSubtitulo As Label
    Friend WithEvents lblPrevTitulo As Label
    Friend WithEvents btnFundoTransparente As Button
    Friend WithEvents lblTituloTextos As Label
    Friend WithEvents btnAlinhaInfDir As Button
    Friend WithEvents btnAlinhaInfCentro As Button
    Friend WithEvents btnAlinhaInfEsq As Button
    Friend WithEvents btnAlinhaMeioDir As Button
    Friend WithEvents btnAlinhaMeioCentro As Button
    Friend WithEvents btnAlinhaMeioEsq As Button
    Friend WithEvents lblAmostraFundo As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents trkZoom As TrackBar
    Friend WithEvents lblZoom As Label
End Class
