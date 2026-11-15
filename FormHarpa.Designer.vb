<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormHarpa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormHarpa))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.trkZoom = New System.Windows.Forms.TrackBar()
        Me.lblZoom = New System.Windows.Forms.Label()
        Me.rbLigado = New System.Windows.Forms.RadioButton()
        Me.rbDesligado = New System.Windows.Forms.RadioButton()
        Me.chkAdicionarTitulo = New System.Windows.Forms.CheckBox()
        Me.rtbEstrofe = New System.Windows.Forms.RichTextBox()
        Me.btnAvancar = New System.Windows.Forms.Button()
        Me.btnRetroceder = New System.Windows.Forms.Button()
        Me.lblEstrofeAtual = New System.Windows.Forms.Label()
        Me.lblTotalEstrofes = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lstHinos = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtLocalizar = New System.Windows.Forms.TextBox()
        Me.lblOcorrencias = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lstResultados = New System.Windows.Forms.ListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbPlayback = New System.Windows.Forms.RadioButton()
        Me.rbVoz = New System.Windows.Forms.RadioButton()
        Me.wmpAudio = New AxWMPLib.AxWindowsMediaPlayer()
        Me.btnEscolherPasta = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblArquivoAudio = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblPastaAudio = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.trkZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.wmpAudio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TableLayoutPanel1.SetColumnSpan(Me.GroupBox1, 4)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.trkZoom)
        Me.GroupBox1.Controls.Add(Me.lblZoom)
        Me.GroupBox1.Controls.Add(Me.rbLigado)
        Me.GroupBox1.Controls.Add(Me.rbDesligado)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(555, 62)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Operação:"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(383, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(132, 14)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "Zoom da projeção:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'trkZoom
        '
        Me.trkZoom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trkZoom.BackColor = System.Drawing.Color.White
        Me.trkZoom.Location = New System.Drawing.Point(383, 12)
        Me.trkZoom.Maximum = 78
        Me.trkZoom.Minimum = 38
        Me.trkZoom.Name = "trkZoom"
        Me.trkZoom.Size = New System.Drawing.Size(132, 45)
        Me.trkZoom.TabIndex = 44
        Me.trkZoom.Value = 58
        '
        'lblZoom
        '
        Me.lblZoom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblZoom.AutoSize = True
        Me.lblZoom.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.lblZoom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZoom.ForeColor = System.Drawing.Color.DarkGray
        Me.lblZoom.Location = New System.Drawing.Point(520, 27)
        Me.lblZoom.Name = "lblZoom"
        Me.lblZoom.Size = New System.Drawing.Size(23, 16)
        Me.lblZoom.TabIndex = 43
        Me.lblZoom.Text = "58"
        Me.lblZoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rbLigado
        '
        Me.rbLigado.BackColor = System.Drawing.Color.Transparent
        Me.rbLigado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbLigado.Image = CType(resources.GetObject("rbLigado.Image"), System.Drawing.Image)
        Me.rbLigado.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbLigado.Location = New System.Drawing.Point(122, 15)
        Me.rbLigado.Name = "rbLigado"
        Me.rbLigado.Size = New System.Drawing.Size(100, 40)
        Me.rbLigado.TabIndex = 9
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
        Me.rbDesligado.Location = New System.Drawing.Point(8, 15)
        Me.rbDesligado.Name = "rbDesligado"
        Me.rbDesligado.Size = New System.Drawing.Size(107, 40)
        Me.rbDesligado.TabIndex = 9
        Me.rbDesligado.TabStop = True
        Me.rbDesligado.Text = "Desligado"
        Me.rbDesligado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rbDesligado.UseVisualStyleBackColor = False
        '
        'chkAdicionarTitulo
        '
        Me.chkAdicionarTitulo.AutoSize = True
        Me.chkAdicionarTitulo.Checked = True
        Me.chkAdicionarTitulo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAdicionarTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAdicionarTitulo.Location = New System.Drawing.Point(6, 67)
        Me.chkAdicionarTitulo.Name = "chkAdicionarTitulo"
        Me.chkAdicionarTitulo.Size = New System.Drawing.Size(101, 17)
        Me.chkAdicionarTitulo.TabIndex = 8
        Me.chkAdicionarTitulo.Text = "Adicionar Título"
        Me.chkAdicionarTitulo.UseVisualStyleBackColor = True
        '
        'rtbEstrofe
        '
        Me.rtbEstrofe.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.rtbEstrofe, 2)
        Me.rtbEstrofe.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbEstrofe.Location = New System.Drawing.Point(93, 199)
        Me.rtbEstrofe.Name = "rtbEstrofe"
        Me.TableLayoutPanel1.SetRowSpan(Me.rtbEstrofe, 2)
        Me.rtbEstrofe.Size = New System.Drawing.Size(404, 229)
        Me.rtbEstrofe.TabIndex = 28
        Me.rtbEstrofe.Text = ""
        '
        'btnAvancar
        '
        Me.btnAvancar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnAvancar.FlatAppearance.BorderSize = 0
        Me.btnAvancar.Image = CType(resources.GetObject("btnAvancar.Image"), System.Drawing.Image)
        Me.btnAvancar.Location = New System.Drawing.Point(23, 199)
        Me.btnAvancar.Name = "btnAvancar"
        Me.btnAvancar.Size = New System.Drawing.Size(44, 39)
        Me.btnAvancar.TabIndex = 26
        Me.btnAvancar.UseVisualStyleBackColor = False
        '
        'btnRetroceder
        '
        Me.btnRetroceder.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnRetroceder.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnRetroceder.FlatAppearance.BorderSize = 0
        Me.btnRetroceder.Image = CType(resources.GetObject("btnRetroceder.Image"), System.Drawing.Image)
        Me.btnRetroceder.Location = New System.Drawing.Point(23, 249)
        Me.btnRetroceder.Name = "btnRetroceder"
        Me.btnRetroceder.Size = New System.Drawing.Size(44, 39)
        Me.btnRetroceder.TabIndex = 27
        Me.btnRetroceder.UseVisualStyleBackColor = False
        '
        'lblEstrofeAtual
        '
        Me.lblEstrofeAtual.AutoSize = True
        Me.lblEstrofeAtual.BackColor = System.Drawing.SystemColors.Highlight
        Me.lblEstrofeAtual.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstrofeAtual.ForeColor = System.Drawing.Color.White
        Me.lblEstrofeAtual.Location = New System.Drawing.Point(22, 32)
        Me.lblEstrofeAtual.Name = "lblEstrofeAtual"
        Me.lblEstrofeAtual.Size = New System.Drawing.Size(19, 20)
        Me.lblEstrofeAtual.TabIndex = 24
        Me.lblEstrofeAtual.Text = "0"
        Me.lblEstrofeAtual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalEstrofes
        '
        Me.lblTotalEstrofes.AutoSize = True
        Me.lblTotalEstrofes.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalEstrofes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalEstrofes.ForeColor = System.Drawing.Color.Maroon
        Me.lblTotalEstrofes.Location = New System.Drawing.Point(72, 32)
        Me.lblTotalEstrofes.Name = "lblTotalEstrofes"
        Me.lblTotalEstrofes.Size = New System.Drawing.Size(19, 20)
        Me.lblTotalEstrofes.TabIndex = 25
        Me.lblTotalEstrofes.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Estrofe:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(63, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Total:"
        '
        'lstHinos
        '
        Me.lstHinos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstHinos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstHinos.FormattingEnabled = True
        Me.lstHinos.ItemHeight = 15
        Me.lstHinos.Location = New System.Drawing.Point(3, 22)
        Me.lstHinos.Name = "lstHinos"
        Me.lstHinos.Size = New System.Drawing.Size(269, 559)
        Me.lstHinos.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 15)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "HARPA CRISTÃ"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(47, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(19, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "de"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(2, -1)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lstHinos)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(840, 589)
        Me.SplitContainer1.SplitterDistance = 275
        Me.SplitContainer1.TabIndex = 30
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 340.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox3, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lstResultados, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.btnRetroceder, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAvancar, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.rtbEstrofe, 1, 3)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 185.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(561, 589)
        Me.TableLayoutPanel1.TabIndex = 52
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.GroupBox4, 2)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.lblEstrofeAtual)
        Me.GroupBox4.Controls.Add(Me.lblTotalEstrofes)
        Me.GroupBox4.Controls.Add(Me.chkAdicionarTitulo)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Location = New System.Drawing.Point(23, 71)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(114, 104)
        Me.GroupBox4.TabIndex = 53
        Me.GroupBox4.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.GroupBox3, 4)
        Me.GroupBox3.Controls.Add(Me.txtLocalizar)
        Me.GroupBox3.Controls.Add(Me.lblOcorrencias)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(3, 452)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(555, 44)
        Me.GroupBox3.TabIndex = 44
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Localizar:"
        '
        'txtLocalizar
        '
        Me.txtLocalizar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLocalizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocalizar.Location = New System.Drawing.Point(11, 17)
        Me.txtLocalizar.Name = "txtLocalizar"
        Me.txtLocalizar.Size = New System.Drawing.Size(385, 20)
        Me.txtLocalizar.TabIndex = 0
        '
        'lblOcorrencias
        '
        Me.lblOcorrencias.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOcorrencias.AutoSize = True
        Me.lblOcorrencias.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lblOcorrencias.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOcorrencias.ForeColor = System.Drawing.Color.Maroon
        Me.lblOcorrencias.Location = New System.Drawing.Point(502, 12)
        Me.lblOcorrencias.Name = "lblOcorrencias"
        Me.lblOcorrencias.Size = New System.Drawing.Size(19, 20)
        Me.lblOcorrencias.TabIndex = 36
        Me.lblOcorrencias.Text = "0"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(417, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 13)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "Ocorrências:"
        '
        'lstResultados
        '
        Me.lstResultados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.lstResultados, 4)
        Me.lstResultados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstResultados.FormattingEnabled = True
        Me.lstResultados.ItemHeight = 15
        Me.lstResultados.Location = New System.Drawing.Point(3, 502)
        Me.lstResultados.Name = "lstResultados"
        Me.lstResultados.Size = New System.Drawing.Size(555, 79)
        Me.lstResultados.TabIndex = 45
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.TableLayoutPanel1.SetColumnSpan(Me.GroupBox2, 2)
        Me.GroupBox2.Controls.Add(Me.rbPlayback)
        Me.GroupBox2.Controls.Add(Me.rbVoz)
        Me.GroupBox2.Controls.Add(Me.wmpAudio)
        Me.GroupBox2.Controls.Add(Me.btnEscolherPasta)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.lblArquivoAudio)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.lblPastaAudio)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(163, 71)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(395, 104)
        Me.GroupBox2.TabIndex = 51
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Audio Reprodutor"
        '
        'rbPlayback
        '
        Me.rbPlayback.AutoSize = True
        Me.rbPlayback.BackColor = System.Drawing.Color.Moccasin
        Me.rbPlayback.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPlayback.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbPlayback.Location = New System.Drawing.Point(12, 79)
        Me.rbPlayback.Name = "rbPlayback"
        Me.rbPlayback.Size = New System.Drawing.Size(69, 17)
        Me.rbPlayback.TabIndex = 51
        Me.rbPlayback.Text = "Playback"
        Me.rbPlayback.UseVisualStyleBackColor = False
        '
        'rbVoz
        '
        Me.rbVoz.AutoSize = True
        Me.rbVoz.BackColor = System.Drawing.Color.LightCyan
        Me.rbVoz.Checked = True
        Me.rbVoz.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbVoz.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbVoz.Location = New System.Drawing.Point(12, 57)
        Me.rbVoz.Name = "rbVoz"
        Me.rbVoz.Size = New System.Drawing.Size(43, 17)
        Me.rbVoz.TabIndex = 51
        Me.rbVoz.TabStop = True
        Me.rbVoz.Text = "Voz"
        Me.rbVoz.UseVisualStyleBackColor = False
        '
        'wmpAudio
        '
        Me.wmpAudio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.wmpAudio.Enabled = True
        Me.wmpAudio.Location = New System.Drawing.Point(119, 52)
        Me.wmpAudio.Name = "wmpAudio"
        Me.wmpAudio.OcxState = CType(resources.GetObject("wmpAudio.OcxState"), System.Windows.Forms.AxHost.State)
        Me.wmpAudio.Size = New System.Drawing.Size(270, 47)
        Me.wmpAudio.TabIndex = 47
        Me.wmpAudio.Visible = False
        '
        'btnEscolherPasta
        '
        Me.btnEscolherPasta.BackColor = System.Drawing.Color.DarkGray
        Me.btnEscolherPasta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEscolherPasta.Image = CType(resources.GetObject("btnEscolherPasta.Image"), System.Drawing.Image)
        Me.btnEscolherPasta.Location = New System.Drawing.Point(40, 15)
        Me.btnEscolherPasta.Name = "btnEscolherPasta"
        Me.btnEscolherPasta.Size = New System.Drawing.Size(18, 16)
        Me.btnEscolherPasta.TabIndex = 50
        Me.btnEscolherPasta.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(72, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 13)
        Me.Label11.TabIndex = 49
        Me.Label11.Text = "Arquivo:"
        '
        'lblArquivoAudio
        '
        Me.lblArquivoAudio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblArquivoAudio.BackColor = System.Drawing.Color.Transparent
        Me.lblArquivoAudio.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArquivoAudio.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblArquivoAudio.Location = New System.Drawing.Point(116, 16)
        Me.lblArquivoAudio.Name = "lblArquivoAudio"
        Me.lblArquivoAudio.Size = New System.Drawing.Size(267, 14)
        Me.lblArquivoAudio.TabIndex = 48
        Me.lblArquivoAudio.Text = "arquivo.mp3"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(8, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 49
        Me.Label8.Text = "Local:"
        '
        'lblPastaAudio
        '
        Me.lblPastaAudio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPastaAudio.BackColor = System.Drawing.Color.Transparent
        Me.lblPastaAudio.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPastaAudio.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblPastaAudio.Location = New System.Drawing.Point(8, 33)
        Me.lblPastaAudio.Name = "lblPastaAudio"
        Me.lblPastaAudio.Size = New System.Drawing.Size(381, 18)
        Me.lblPastaAudio.TabIndex = 48
        Me.lblPastaAudio.Text = "\AUDIOS\Harpa\"
        '
        'FormHarpa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(844, 589)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FormHarpa"
        Me.Text = "Form Harpa"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.trkZoom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.wmpAudio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbLigado As RadioButton
    Friend WithEvents rbDesligado As RadioButton
    Friend WithEvents chkAdicionarTitulo As CheckBox
    Friend WithEvents rtbEstrofe As RichTextBox
    Friend WithEvents btnAvancar As Button
    Friend WithEvents btnRetroceder As Button
    Friend WithEvents lblEstrofeAtual As Label
    Friend WithEvents lblTotalEstrofes As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lstHinos As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents trkZoom As TrackBar
    Friend WithEvents Label9 As Label
    Friend WithEvents lblZoom As Label
    Friend WithEvents lstResultados As ListBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtLocalizar As TextBox
    Friend WithEvents lblOcorrencias As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents wmpAudio As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents btnEscolherPasta As Button
    Friend WithEvents lblArquivoAudio As Label
    Friend WithEvents lblPastaAudio As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rbPlayback As RadioButton
    Friend WithEvents rbVoz As RadioButton
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents GroupBox4 As GroupBox
End Class
