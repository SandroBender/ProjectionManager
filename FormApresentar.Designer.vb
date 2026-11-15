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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormApresentar))
        Me.rtbHarpa = New System.Windows.Forms.RichTextBox()
        Me.picFundo = New System.Windows.Forms.PictureBox()
        Me.LabelA = New System.Windows.Forms.Label()
        Me.picSobreposicao = New System.Windows.Forms.PictureBox()
        Me.rtbBiblia = New System.Windows.Forms.RichTextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblCorpo = New System.Windows.Forms.Label()
        Me.lblSubtitulo = New System.Windows.Forms.Label()
        Me.lblRodape = New System.Windows.Forms.Label()
        Me.wmpVideo = New AxWMPLib.AxWindowsMediaPlayer()
        Me.picAudio = New System.Windows.Forms.PictureBox()
        CType(Me.picFundo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSobreposicao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.wmpVideo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAudio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rtbHarpa
        '
        Me.rtbHarpa.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbHarpa.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        Me.rtbHarpa.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbHarpa.Font = New System.Drawing.Font("Calibri", 54.0!, System.Drawing.FontStyle.Bold)
        Me.rtbHarpa.ForeColor = System.Drawing.Color.White
        Me.rtbHarpa.Location = New System.Drawing.Point(0, 0)
        Me.rtbHarpa.Margin = New System.Windows.Forms.Padding(0)
        Me.rtbHarpa.Name = "rtbHarpa"
        Me.rtbHarpa.Size = New System.Drawing.Size(900, 500)
        Me.rtbHarpa.TabIndex = 5
        Me.rtbHarpa.Text = ""
        '
        'picFundo
        '
        Me.picFundo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picFundo.Location = New System.Drawing.Point(0, 0)
        Me.picFundo.Margin = New System.Windows.Forms.Padding(0)
        Me.picFundo.Name = "picFundo"
        Me.picFundo.Size = New System.Drawing.Size(900, 500)
        Me.picFundo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picFundo.TabIndex = 6
        Me.picFundo.TabStop = False
        '
        'LabelA
        '
        Me.LabelA.BackColor = System.Drawing.Color.Transparent
        Me.LabelA.Location = New System.Drawing.Point(10, 10)
        Me.LabelA.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelA.Name = "LabelA"
        Me.LabelA.Size = New System.Drawing.Size(10, 50)
        Me.LabelA.TabIndex = 8
        '
        'picSobreposicao
        '
        Me.picSobreposicao.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picSobreposicao.Location = New System.Drawing.Point(0, 0)
        Me.picSobreposicao.Margin = New System.Windows.Forms.Padding(0)
        Me.picSobreposicao.Name = "picSobreposicao"
        Me.picSobreposicao.Size = New System.Drawing.Size(900, 500)
        Me.picSobreposicao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picSobreposicao.TabIndex = 12
        Me.picSobreposicao.TabStop = False
        '
        'rtbBiblia
        '
        Me.rtbBiblia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbBiblia.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        Me.rtbBiblia.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbBiblia.Font = New System.Drawing.Font("Calibri", 54.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbBiblia.ForeColor = System.Drawing.Color.White
        Me.rtbBiblia.Location = New System.Drawing.Point(0, 0)
        Me.rtbBiblia.Margin = New System.Windows.Forms.Padding(0)
        Me.rtbBiblia.Name = "rtbBiblia"
        Me.rtbBiblia.Size = New System.Drawing.Size(900, 500)
        Me.rtbBiblia.TabIndex = 13
        Me.rtbBiblia.Text = ""
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblTitulo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCorpo, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSubtitulo, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblRodape, 0, 3)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(899, 500)
        Me.TableLayoutPanel1.TabIndex = 14
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Location = New System.Drawing.Point(3, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(893, 75)
        Me.lblTitulo.TabIndex = 0
        '
        'lblCorpo
        '
        Me.lblCorpo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCorpo.BackColor = System.Drawing.Color.Transparent
        Me.lblCorpo.Location = New System.Drawing.Point(3, 135)
        Me.lblCorpo.Name = "lblCorpo"
        Me.lblCorpo.Size = New System.Drawing.Size(893, 315)
        Me.lblCorpo.TabIndex = 0
        '
        'lblSubtitulo
        '
        Me.lblSubtitulo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSubtitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblSubtitulo.Location = New System.Drawing.Point(3, 75)
        Me.lblSubtitulo.Name = "lblSubtitulo"
        Me.lblSubtitulo.Size = New System.Drawing.Size(893, 60)
        Me.lblSubtitulo.TabIndex = 0
        '
        'lblRodape
        '
        Me.lblRodape.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRodape.BackColor = System.Drawing.Color.Transparent
        Me.lblRodape.Location = New System.Drawing.Point(3, 450)
        Me.lblRodape.Name = "lblRodape"
        Me.lblRodape.Size = New System.Drawing.Size(893, 50)
        Me.lblRodape.TabIndex = 0
        '
        'wmpVideo
        '
        Me.wmpVideo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.wmpVideo.Enabled = True
        Me.wmpVideo.Location = New System.Drawing.Point(0, 0)
        Me.wmpVideo.Name = "wmpVideo"
        Me.wmpVideo.OcxState = CType(resources.GetObject("wmpVideo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.wmpVideo.Size = New System.Drawing.Size(900, 500)
        Me.wmpVideo.TabIndex = 15
        '
        'picAudio
        '
        Me.picAudio.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picAudio.Location = New System.Drawing.Point(0, 0)
        Me.picAudio.Margin = New System.Windows.Forms.Padding(0)
        Me.picAudio.Name = "picAudio"
        Me.picAudio.Size = New System.Drawing.Size(900, 500)
        Me.picAudio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picAudio.TabIndex = 16
        Me.picAudio.TabStop = False
        '
        'FormApresentar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(900, 500)
        Me.Controls.Add(Me.rtbBiblia)
        Me.Controls.Add(Me.rtbHarpa)
        Me.Controls.Add(Me.wmpVideo)
        Me.Controls.Add(Me.picAudio)
        Me.Controls.Add(Me.picSobreposicao)
        Me.Controls.Add(Me.picFundo)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "FormApresentar"
        Me.ShowIcon = False
        Me.Text = "FormApresentar"
        CType(Me.picFundo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSobreposicao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.wmpVideo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAudio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rtbHarpa As RichTextBox
    Friend WithEvents picFundo As PictureBox
    Friend WithEvents LabelA As Label
    Friend WithEvents picSobreposicao As PictureBox
    Friend WithEvents rtbBiblia As RichTextBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents lblCorpo As Label
    Friend WithEvents lblSubtitulo As Label
    Friend WithEvents lblRodape As Label
    Friend WithEvents wmpVideo As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents picAudio As PictureBox
End Class
