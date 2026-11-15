<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormBiblia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBiblia))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstLivros = New System.Windows.Forms.ListBox()
        Me.lstCapitulos = New System.Windows.Forms.ListBox()
        Me.lstVersiculos = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.trkZoom = New System.Windows.Forms.TrackBar()
        Me.lblZoom = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbNVI = New System.Windows.Forms.RadioButton()
        Me.rbACF = New System.Windows.Forms.RadioButton()
        Me.rbLigado = New System.Windows.Forms.RadioButton()
        Me.rbDesligado = New System.Windows.Forms.RadioButton()
        Me.rtbVersiculo = New System.Windows.Forms.RichTextBox()
        Me.lblLivro = New System.Windows.Forms.Label()
        Me.btnAvancar = New System.Windows.Forms.Button()
        Me.lblVersiculo = New System.Windows.Forms.Label()
        Me.btnRetroceder = New System.Windows.Forms.Button()
        Me.lblCapitulo = New System.Windows.Forms.Label()
        Me.txtLocalizar = New System.Windows.Forms.TextBox()
        Me.lblOcorrencias = New System.Windows.Forms.Label()
        Me.lstResultados = New System.Windows.Forms.ListBox()
        Me.tabPesquisa = New System.Windows.Forms.TabControl()
        Me.TabLocalizar = New System.Windows.Forms.TabPage()
        Me.cboLivroAssunto = New System.Windows.Forms.ComboBox()
        Me.rbAssuntosPorLivro = New System.Windows.Forms.RadioButton()
        Me.rbNoAssunto = New System.Windows.Forms.RadioButton()
        Me.rbNaBiblia = New System.Windows.Forms.RadioButton()
        Me.TabRef = New System.Windows.Forms.TabPage()
        Me.lstReferencias = New System.Windows.Forms.ListBox()
        Me.TabHistorico = New System.Windows.Forms.TabPage()
        Me.lstHistorico = New System.Windows.Forms.ListBox()
        Me.btnLimpar = New System.Windows.Forms.Button()
        Me.btnSubstituir = New System.Windows.Forms.Button()
        Me.btnAdicionar = New System.Windows.Forms.Button()
        Me.btnMostrarLocalizar = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.rtbAnteriores = New System.Windows.Forms.RichTextBox()
        Me.rtbPosteriores = New System.Windows.Forms.RichTextBox()
        Me.tlpLocalizar = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnAvancarAdicionando = New System.Windows.Forms.Button()
        Me.txtSelecionado = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.trkZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.tabPesquisa.SuspendLayout()
        Me.TabLocalizar.SuspendLayout()
        Me.TabRef.SuspendLayout()
        Me.TabHistorico.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.tlpLocalizar.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lstLivros, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lstCapitulos, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lstVersiculos, 2, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(2, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(225, 586)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(183, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Versíc"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(133, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Capít"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Livro"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lstLivros
        '
        Me.lstLivros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstLivros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstLivros.FormattingEnabled = True
        Me.lstLivros.ItemHeight = 15
        Me.lstLivros.Location = New System.Drawing.Point(3, 23)
        Me.lstLivros.Name = "lstLivros"
        Me.lstLivros.Size = New System.Drawing.Size(124, 559)
        Me.lstLivros.TabIndex = 4
        '
        'lstCapitulos
        '
        Me.lstCapitulos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstCapitulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCapitulos.FormattingEnabled = True
        Me.lstCapitulos.ItemHeight = 15
        Me.lstCapitulos.Location = New System.Drawing.Point(133, 23)
        Me.lstCapitulos.Name = "lstCapitulos"
        Me.lstCapitulos.Size = New System.Drawing.Size(44, 559)
        Me.lstCapitulos.TabIndex = 5
        '
        'lstVersiculos
        '
        Me.lstVersiculos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstVersiculos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstVersiculos.FormattingEnabled = True
        Me.lstVersiculos.ItemHeight = 15
        Me.lstVersiculos.Location = New System.Drawing.Point(183, 23)
        Me.lstVersiculos.Name = "lstVersiculos"
        Me.lstVersiculos.Size = New System.Drawing.Size(44, 559)
        Me.lstVersiculos.TabIndex = 6
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TableLayoutPanel2.SetColumnSpan(Me.GroupBox1, 4)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.rbLigado)
        Me.GroupBox1.Controls.Add(Me.rbDesligado)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(861, 64)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Operação:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.BackColor = System.Drawing.Color.Lavender
        Me.GroupBox4.Controls.Add(Me.trkZoom)
        Me.GroupBox4.Controls.Add(Me.lblZoom)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(685, 7)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(170, 51)
        Me.GroupBox4.TabIndex = 42
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Zoom da Projeção"
        '
        'trkZoom
        '
        Me.trkZoom.BackColor = System.Drawing.Color.White
        Me.trkZoom.Location = New System.Drawing.Point(6, 16)
        Me.trkZoom.Maximum = 78
        Me.trkZoom.Minimum = 38
        Me.trkZoom.Name = "trkZoom"
        Me.trkZoom.Size = New System.Drawing.Size(132, 45)
        Me.trkZoom.TabIndex = 41
        Me.trkZoom.Value = 58
        '
        'lblZoom
        '
        Me.lblZoom.AutoSize = True
        Me.lblZoom.BackColor = System.Drawing.Color.Lavender
        Me.lblZoom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZoom.ForeColor = System.Drawing.Color.DarkGray
        Me.lblZoom.Location = New System.Drawing.Point(141, 16)
        Me.lblZoom.Name = "lblZoom"
        Me.lblZoom.Size = New System.Drawing.Size(23, 16)
        Me.lblZoom.TabIndex = 35
        Me.lblZoom.Text = "58"
        Me.lblZoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Lavender
        Me.GroupBox2.Controls.Add(Me.rbNVI)
        Me.GroupBox2.Controls.Add(Me.rbACF)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(235, 15)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(103, 42)
        Me.GroupBox2.TabIndex = 40
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Versão:"
        '
        'rbNVI
        '
        Me.rbNVI.AutoSize = True
        Me.rbNVI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbNVI.Location = New System.Drawing.Point(56, 16)
        Me.rbNVI.Name = "rbNVI"
        Me.rbNVI.Size = New System.Drawing.Size(43, 17)
        Me.rbNVI.TabIndex = 1
        Me.rbNVI.Text = "NVI"
        Me.rbNVI.UseVisualStyleBackColor = True
        '
        'rbACF
        '
        Me.rbACF.AutoSize = True
        Me.rbACF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbACF.Location = New System.Drawing.Point(6, 16)
        Me.rbACF.Name = "rbACF"
        Me.rbACF.Size = New System.Drawing.Size(45, 17)
        Me.rbACF.TabIndex = 0
        Me.rbACF.Text = "ACF"
        Me.rbACF.UseVisualStyleBackColor = True
        '
        'rbLigado
        '
        Me.rbLigado.BackColor = System.Drawing.Color.Transparent
        Me.rbLigado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbLigado.Image = CType(resources.GetObject("rbLigado.Image"), System.Drawing.Image)
        Me.rbLigado.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbLigado.Location = New System.Drawing.Point(118, 17)
        Me.rbLigado.Name = "rbLigado"
        Me.rbLigado.Size = New System.Drawing.Size(100, 39)
        Me.rbLigado.TabIndex = 9
        Me.rbLigado.TabStop = True
        Me.rbLigado.Text = "Ligado"
        Me.rbLigado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rbLigado.UseVisualStyleBackColor = False
        '
        'rbDesligado
        '
        Me.rbDesligado.BackColor = System.Drawing.Color.AliceBlue
        Me.rbDesligado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDesligado.Image = CType(resources.GetObject("rbDesligado.Image"), System.Drawing.Image)
        Me.rbDesligado.Location = New System.Drawing.Point(8, 17)
        Me.rbDesligado.Name = "rbDesligado"
        Me.rbDesligado.Size = New System.Drawing.Size(107, 39)
        Me.rbDesligado.TabIndex = 9
        Me.rbDesligado.Text = "Desligado"
        Me.rbDesligado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rbDesligado.UseVisualStyleBackColor = False
        '
        'rtbVersiculo
        '
        Me.rtbVersiculo.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbVersiculo.Location = New System.Drawing.Point(18, 216)
        Me.rtbVersiculo.Name = "rtbVersiculo"
        Me.rtbVersiculo.Size = New System.Drawing.Size(410, 224)
        Me.rtbVersiculo.TabIndex = 39
        Me.rtbVersiculo.Text = ""
        '
        'lblLivro
        '
        Me.lblLivro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLivro.BackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.lblLivro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLivro.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblLivro.Location = New System.Drawing.Point(223, 3)
        Me.lblLivro.Margin = New System.Windows.Forms.Padding(3)
        Me.lblLivro.Name = "lblLivro"
        Me.lblLivro.Size = New System.Drawing.Size(119, 22)
        Me.lblLivro.TabIndex = 34
        Me.lblLivro.Text = "Livro"
        Me.lblLivro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAvancar
        '
        Me.btnAvancar.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnAvancar.FlatAppearance.BorderSize = 0
        Me.btnAvancar.Image = CType(resources.GetObject("btnAvancar.Image"), System.Drawing.Image)
        Me.btnAvancar.Location = New System.Drawing.Point(10, 0)
        Me.btnAvancar.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAvancar.Name = "btnAvancar"
        Me.btnAvancar.Size = New System.Drawing.Size(30, 30)
        Me.btnAvancar.TabIndex = 37
        Me.btnAvancar.UseVisualStyleBackColor = False
        '
        'lblVersiculo
        '
        Me.lblVersiculo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVersiculo.BackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.lblVersiculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersiculo.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblVersiculo.Location = New System.Drawing.Point(188, 3)
        Me.lblVersiculo.Margin = New System.Windows.Forms.Padding(3)
        Me.lblVersiculo.Name = "lblVersiculo"
        Me.lblVersiculo.Size = New System.Drawing.Size(29, 20)
        Me.lblVersiculo.TabIndex = 36
        Me.lblVersiculo.Text = "0"
        Me.lblVersiculo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnRetroceder
        '
        Me.btnRetroceder.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnRetroceder.FlatAppearance.BorderSize = 0
        Me.btnRetroceder.Image = CType(resources.GetObject("btnRetroceder.Image"), System.Drawing.Image)
        Me.btnRetroceder.Location = New System.Drawing.Point(95, 0)
        Me.btnRetroceder.Margin = New System.Windows.Forms.Padding(0)
        Me.btnRetroceder.Name = "btnRetroceder"
        Me.btnRetroceder.Size = New System.Drawing.Size(30, 30)
        Me.btnRetroceder.TabIndex = 38
        Me.btnRetroceder.UseVisualStyleBackColor = False
        '
        'lblCapitulo
        '
        Me.lblCapitulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCapitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.lblCapitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapitulo.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblCapitulo.Location = New System.Drawing.Point(143, 3)
        Me.lblCapitulo.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCapitulo.Name = "lblCapitulo"
        Me.lblCapitulo.Size = New System.Drawing.Size(29, 20)
        Me.lblCapitulo.TabIndex = 35
        Me.lblCapitulo.Text = "0"
        Me.lblCapitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLocalizar
        '
        Me.txtLocalizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocalizar.Location = New System.Drawing.Point(3, 27)
        Me.txtLocalizar.Name = "txtLocalizar"
        Me.txtLocalizar.Size = New System.Drawing.Size(159, 20)
        Me.txtLocalizar.TabIndex = 0
        Me.txtLocalizar.Visible = False
        '
        'lblOcorrencias
        '
        Me.lblOcorrencias.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOcorrencias.AutoSize = True
        Me.lblOcorrencias.BackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.lblOcorrencias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOcorrencias.ForeColor = System.Drawing.Color.SlateGray
        Me.lblOcorrencias.Location = New System.Drawing.Point(391, 31)
        Me.lblOcorrencias.Name = "lblOcorrencias"
        Me.lblOcorrencias.Size = New System.Drawing.Size(14, 16)
        Me.lblOcorrencias.TabIndex = 36
        Me.lblOcorrencias.Text = "0"
        '
        'lstResultados
        '
        Me.lstResultados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstResultados.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.lstResultados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstResultados.FormattingEnabled = True
        Me.lstResultados.IntegralHeight = False
        Me.lstResultados.ItemHeight = 15
        Me.lstResultados.Location = New System.Drawing.Point(3, 51)
        Me.lstResultados.Name = "lstResultados"
        Me.lstResultados.Size = New System.Drawing.Size(416, 144)
        Me.lstResultados.TabIndex = 43
        '
        'tabPesquisa
        '
        Me.tabPesquisa.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.SetColumnSpan(Me.tabPesquisa, 2)
        Me.tabPesquisa.Controls.Add(Me.TabLocalizar)
        Me.tabPesquisa.Controls.Add(Me.TabRef)
        Me.tabPesquisa.Controls.Add(Me.TabHistorico)
        Me.tabPesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabPesquisa.Location = New System.Drawing.Point(434, 216)
        Me.tabPesquisa.Name = "tabPesquisa"
        Me.tabPesquisa.SelectedIndex = 0
        Me.tabPesquisa.Size = New System.Drawing.Size(430, 224)
        Me.tabPesquisa.TabIndex = 44
        Me.tabPesquisa.Visible = False
        '
        'TabLocalizar
        '
        Me.TabLocalizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.TabLocalizar.Controls.Add(Me.cboLivroAssunto)
        Me.TabLocalizar.Controls.Add(Me.rbAssuntosPorLivro)
        Me.TabLocalizar.Controls.Add(Me.rbNoAssunto)
        Me.TabLocalizar.Controls.Add(Me.rbNaBiblia)
        Me.TabLocalizar.Controls.Add(Me.txtLocalizar)
        Me.TabLocalizar.Controls.Add(Me.lblOcorrencias)
        Me.TabLocalizar.Controls.Add(Me.lstResultados)
        Me.TabLocalizar.Location = New System.Drawing.Point(4, 22)
        Me.TabLocalizar.Margin = New System.Windows.Forms.Padding(0)
        Me.TabLocalizar.Name = "TabLocalizar"
        Me.TabLocalizar.Padding = New System.Windows.Forms.Padding(3)
        Me.TabLocalizar.Size = New System.Drawing.Size(422, 198)
        Me.TabLocalizar.TabIndex = 0
        Me.TabLocalizar.Text = "Localizar"
        '
        'cboLivroAssunto
        '
        Me.cboLivroAssunto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLivroAssunto.FormattingEnabled = True
        Me.cboLivroAssunto.Location = New System.Drawing.Point(168, 26)
        Me.cboLivroAssunto.Name = "cboLivroAssunto"
        Me.cboLivroAssunto.Size = New System.Drawing.Size(113, 21)
        Me.cboLivroAssunto.TabIndex = 47
        Me.cboLivroAssunto.Visible = False
        '
        'rbAssuntosPorLivro
        '
        Me.rbAssuntosPorLivro.AutoSize = True
        Me.rbAssuntosPorLivro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAssuntosPorLivro.Location = New System.Drawing.Point(168, 6)
        Me.rbAssuntosPorLivro.Name = "rbAssuntosPorLivro"
        Me.rbAssuntosPorLivro.Size = New System.Drawing.Size(108, 17)
        Me.rbAssuntosPorLivro.TabIndex = 46
        Me.rbAssuntosPorLivro.TabStop = True
        Me.rbAssuntosPorLivro.Text = "Assuntos por livro"
        Me.rbAssuntosPorLivro.UseVisualStyleBackColor = True
        '
        'rbNoAssunto
        '
        Me.rbNoAssunto.AutoSize = True
        Me.rbNoAssunto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbNoAssunto.Location = New System.Drawing.Point(82, 6)
        Me.rbNoAssunto.Name = "rbNoAssunto"
        Me.rbNoAssunto.Size = New System.Drawing.Size(80, 17)
        Me.rbNoAssunto.TabIndex = 45
        Me.rbNoAssunto.TabStop = True
        Me.rbNoAssunto.Text = "No Assunto"
        Me.rbNoAssunto.UseVisualStyleBackColor = True
        '
        'rbNaBiblia
        '
        Me.rbNaBiblia.AutoSize = True
        Me.rbNaBiblia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbNaBiblia.Location = New System.Drawing.Point(7, 6)
        Me.rbNaBiblia.Name = "rbNaBiblia"
        Me.rbNaBiblia.Size = New System.Drawing.Size(69, 17)
        Me.rbNaBiblia.TabIndex = 44
        Me.rbNaBiblia.TabStop = True
        Me.rbNaBiblia.Text = "Na Bíblia"
        Me.rbNaBiblia.UseVisualStyleBackColor = True
        '
        'TabRef
        '
        Me.TabRef.BackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.TabRef.Controls.Add(Me.lstReferencias)
        Me.TabRef.Location = New System.Drawing.Point(4, 22)
        Me.TabRef.Name = "TabRef"
        Me.TabRef.Size = New System.Drawing.Size(422, 198)
        Me.TabRef.TabIndex = 2
        Me.TabRef.Text = "Referências"
        '
        'lstReferencias
        '
        Me.lstReferencias.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstReferencias.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.lstReferencias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstReferencias.FormattingEnabled = True
        Me.lstReferencias.ItemHeight = 15
        Me.lstReferencias.Location = New System.Drawing.Point(3, 11)
        Me.lstReferencias.Name = "lstReferencias"
        Me.lstReferencias.Size = New System.Drawing.Size(416, 184)
        Me.lstReferencias.TabIndex = 45
        '
        'TabHistorico
        '
        Me.TabHistorico.BackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.TabHistorico.Controls.Add(Me.lstHistorico)
        Me.TabHistorico.Location = New System.Drawing.Point(4, 22)
        Me.TabHistorico.Name = "TabHistorico"
        Me.TabHistorico.Padding = New System.Windows.Forms.Padding(3)
        Me.TabHistorico.Size = New System.Drawing.Size(422, 198)
        Me.TabHistorico.TabIndex = 1
        Me.TabHistorico.Text = "Histórico de seleção"
        '
        'lstHistorico
        '
        Me.lstHistorico.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstHistorico.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.lstHistorico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstHistorico.FormattingEnabled = True
        Me.lstHistorico.ItemHeight = 15
        Me.lstHistorico.Location = New System.Drawing.Point(3, 11)
        Me.lstHistorico.Name = "lstHistorico"
        Me.lstHistorico.Size = New System.Drawing.Size(416, 184)
        Me.lstHistorico.TabIndex = 44
        '
        'btnLimpar
        '
        Me.btnLimpar.FlatAppearance.BorderSize = 0
        Me.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpar.Image = CType(resources.GetObject("btnLimpar.Image"), System.Drawing.Image)
        Me.btnLimpar.Location = New System.Drawing.Point(238, 1)
        Me.btnLimpar.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.btnLimpar.Name = "btnLimpar"
        Me.btnLimpar.Size = New System.Drawing.Size(68, 26)
        Me.btnLimpar.TabIndex = 45
        Me.btnLimpar.Text = "Limpar"
        Me.btnLimpar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnLimpar.UseVisualStyleBackColor = True
        Me.btnLimpar.Visible = False
        '
        'btnSubstituir
        '
        Me.btnSubstituir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSubstituir.FlatAppearance.BorderSize = 0
        Me.btnSubstituir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubstituir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubstituir.ForeColor = System.Drawing.SystemColors.InfoText
        Me.btnSubstituir.Image = CType(resources.GetObject("btnSubstituir.Image"), System.Drawing.Image)
        Me.btnSubstituir.Location = New System.Drawing.Point(123, 1)
        Me.btnSubstituir.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.btnSubstituir.Name = "btnSubstituir"
        Me.btnSubstituir.Size = New System.Drawing.Size(79, 26)
        Me.btnSubstituir.TabIndex = 37
        Me.btnSubstituir.Text = "Substituir"
        Me.btnSubstituir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnSubstituir.UseVisualStyleBackColor = False
        Me.btnSubstituir.Visible = False
        '
        'btnAdicionar
        '
        Me.btnAdicionar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdicionar.FlatAppearance.BorderSize = 0
        Me.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdicionar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdicionar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAdicionar.Image = CType(resources.GetObject("btnAdicionar.Image"), System.Drawing.Image)
        Me.btnAdicionar.Location = New System.Drawing.Point(14, 1)
        Me.btnAdicionar.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.btnAdicionar.Name = "btnAdicionar"
        Me.btnAdicionar.Size = New System.Drawing.Size(83, 26)
        Me.btnAdicionar.TabIndex = 37
        Me.btnAdicionar.Text = "Adicionar"
        Me.btnAdicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnAdicionar.UseVisualStyleBackColor = False
        Me.btnAdicionar.Visible = False
        '
        'btnMostrarLocalizar
        '
        Me.btnMostrarLocalizar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrarLocalizar.FlatAppearance.BorderSize = 0
        Me.btnMostrarLocalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMostrarLocalizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMostrarLocalizar.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.btnMostrarLocalizar.Image = CType(resources.GetObject("btnMostrarLocalizar.Image"), System.Drawing.Image)
        Me.btnMostrarLocalizar.Location = New System.Drawing.Point(381, 3)
        Me.btnMostrarLocalizar.Name = "btnMostrarLocalizar"
        Me.btnMostrarLocalizar.Size = New System.Drawing.Size(26, 24)
        Me.btnMostrarLocalizar.TabIndex = 37
        Me.btnMostrarLocalizar.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(78, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(101, Byte), Integer))
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 416.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.rtbVersiculo, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.rtbAnteriores, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.rtbPosteriores, 1, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.tabPesquisa, 2, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.tlpLocalizar, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel4, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txtSelecionado, 1, 4)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(233, 2)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 6
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 230.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(867, 586)
        Me.TableLayoutPanel2.TabIndex = 45
        '
        'rtbAnteriores
        '
        Me.rtbAnteriores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbAnteriores.BackColor = System.Drawing.Color.FromArgb(CType(CType(78, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(101, Byte), Integer))
        Me.rtbAnteriores.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TableLayoutPanel2.SetColumnSpan(Me.rtbAnteriores, 3)
        Me.rtbAnteriores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbAnteriores.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.rtbAnteriores.Location = New System.Drawing.Point(18, 73)
        Me.rtbAnteriores.Name = "rtbAnteriores"
        Me.rtbAnteriores.Size = New System.Drawing.Size(846, 107)
        Me.rtbAnteriores.TabIndex = 46
        Me.rtbAnteriores.Text = ""
        '
        'rtbPosteriores
        '
        Me.rtbPosteriores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbPosteriores.BackColor = System.Drawing.Color.FromArgb(CType(CType(78, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(101, Byte), Integer))
        Me.rtbPosteriores.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TableLayoutPanel2.SetColumnSpan(Me.rtbPosteriores, 3)
        Me.rtbPosteriores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbPosteriores.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.rtbPosteriores.Location = New System.Drawing.Point(18, 476)
        Me.rtbPosteriores.Name = "rtbPosteriores"
        Me.rtbPosteriores.Size = New System.Drawing.Size(846, 107)
        Me.rtbPosteriores.TabIndex = 47
        Me.rtbPosteriores.Text = ""
        '
        'tlpLocalizar
        '
        Me.tlpLocalizar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpLocalizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.tlpLocalizar.ColumnCount = 5
        Me.TableLayoutPanel2.SetColumnSpan(Me.tlpLocalizar, 2)
        Me.tlpLocalizar.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tlpLocalizar.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpLocalizar.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.tlpLocalizar.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpLocalizar.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpLocalizar.Controls.Add(Me.btnAdicionar, 0, 0)
        Me.tlpLocalizar.Controls.Add(Me.btnLimpar, 4, 0)
        Me.tlpLocalizar.Controls.Add(Me.btnSubstituir, 2, 0)
        Me.tlpLocalizar.Location = New System.Drawing.Point(434, 183)
        Me.tlpLocalizar.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.tlpLocalizar.Name = "tlpLocalizar"
        Me.tlpLocalizar.RowCount = 1
        Me.tlpLocalizar.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpLocalizar.Size = New System.Drawing.Size(430, 30)
        Me.tlpLocalizar.TabIndex = 50
        Me.tlpLocalizar.Visible = False
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.TableLayoutPanel4.ColumnCount = 12
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.lblLivro, 10, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.btnMostrarLocalizar, 11, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.btnAvancar, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label4, 8, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.lblCapitulo, 7, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.lblVersiculo, 9, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.btnRetroceder, 5, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.btnAvancarAdicionando, 3, 0)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(18, 183)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(410, 30)
        Me.TableLayoutPanel4.TabIndex = 51
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.AliceBlue
        Me.Label4.Location = New System.Drawing.Point(176, 3)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1, 3, 1, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(8, 20)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = ":"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnAvancarAdicionando
        '
        Me.btnAvancarAdicionando.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.btnAvancarAdicionando.FlatAppearance.BorderSize = 0
        Me.btnAvancarAdicionando.Image = CType(resources.GetObject("btnAvancarAdicionando.Image"), System.Drawing.Image)
        Me.btnAvancarAdicionando.Location = New System.Drawing.Point(45, 0)
        Me.btnAvancarAdicionando.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAvancarAdicionando.Name = "btnAvancarAdicionando"
        Me.btnAvancarAdicionando.Size = New System.Drawing.Size(30, 30)
        Me.btnAvancarAdicionando.TabIndex = 39
        Me.btnAvancarAdicionando.UseVisualStyleBackColor = False
        '
        'txtSelecionado
        '
        Me.txtSelecionado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSelecionado.BackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.TableLayoutPanel2.SetColumnSpan(Me.txtSelecionado, 3)
        Me.txtSelecionado.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtSelecionado.Location = New System.Drawing.Point(18, 443)
        Me.txtSelecionado.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.txtSelecionado.Multiline = True
        Me.txtSelecionado.Name = "txtSelecionado"
        Me.txtSelecionado.Size = New System.Drawing.Size(846, 30)
        Me.txtSelecionado.TabIndex = 49
        Me.txtSelecionado.Visible = False
        '
        'FormBiblia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1100, 591)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormBiblia"
        Me.Text = "Form Bíblia"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.trkZoom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tabPesquisa.ResumeLayout(False)
        Me.TabLocalizar.ResumeLayout(False)
        Me.TabLocalizar.PerformLayout()
        Me.TabRef.ResumeLayout(False)
        Me.TabHistorico.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.tlpLocalizar.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lstLivros As ListBox
    Friend WithEvents lstCapitulos As ListBox
    Friend WithEvents lstVersiculos As ListBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbLigado As RadioButton
    Friend WithEvents rbDesligado As RadioButton
    Friend WithEvents rtbVersiculo As RichTextBox
    Friend WithEvents lblLivro As Label
    Friend WithEvents btnAvancar As Button
    Friend WithEvents lblVersiculo As Label
    Friend WithEvents btnRetroceder As Button
    Friend WithEvents lblCapitulo As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rbACF As RadioButton
    Friend WithEvents rbNVI As RadioButton
    Friend WithEvents trkZoom As TrackBar
    Friend WithEvents lblZoom As Label
    Friend WithEvents txtLocalizar As TextBox
    Friend WithEvents lblOcorrencias As Label
    Friend WithEvents lstResultados As ListBox
    Friend WithEvents tabPesquisa As TabControl
    Friend WithEvents TabLocalizar As TabPage
    Friend WithEvents TabHistorico As TabPage
    Friend WithEvents lstHistorico As ListBox
    Friend WithEvents btnLimpar As Button
    Friend WithEvents btnAdicionar As Button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents rtbAnteriores As RichTextBox
    Friend WithEvents rtbPosteriores As RichTextBox
    Friend WithEvents btnSubstituir As Button
    Friend WithEvents btnMostrarLocalizar As Button
    Friend WithEvents txtSelecionado As TextBox
    Friend WithEvents tlpLocalizar As TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents rbAssuntosPorLivro As RadioButton
    Friend WithEvents rbNoAssunto As RadioButton
    Friend WithEvents rbNaBiblia As RadioButton
    Friend WithEvents cboLivroAssunto As ComboBox
    Friend WithEvents btnAvancarAdicionando As Button
    Friend WithEvents TabRef As TabPage
    Friend WithEvents lstReferencias As ListBox
End Class
