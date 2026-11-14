Imports System.ComponentModel
Imports System.IO

Public Class FormPrincipal
    Private Sub FormPrincipal_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Directory.Exists(MyDocSystem & "\ProjectionManager") Then
            If Not Directory.Exists(AlternativeSystem) Then
                MsgBox("O conteúdo do sistema não foi encontrado em: " & AlternativeSystem, vbCritical, "Dados do systema")
                Exit Sub
            Else
                LocalSystem = AlternativeSystem
            End If
        Else
            LocalSystem = MyDocSystem
        End If
        Dim I As Integer
        'Dim Monitor() As Screen = Screen.AllScreens
        'Dim TM As Integer = Screen.AllScreens.Count
        'Dim SecondaryMonitor = Screen.AllScreens.FirstOrDefault(Function(x) Not x.Primary)
        Dim primaryScreen = Screen.PrimaryScreen
        Dim allScreens = Screen.AllScreens
        For Each screen In allScreens
            If screen IsNot primaryScreen Then
                ComboMonitor.Items.Add(I & " - " & screen.DeviceName)
            End If
            I += 1
        Next
        If ComboMonitor.Items.Count = 0 Then
            'TelaUnica = True
            ComboMonitor.Items.Add("0-Apenas monitor principal")
            MsgBox("Apenas monitor principal detectado.", vbExclamation, "Gerenciador de Projeção")
        End If
        ComboMonitor.SelectedIndex = 0
        'If SecondaryMonitor IsNot Nothing Then
        '    'Dim newLocation = SecondaryMonitor.Bounds.Location
        '    'newLocation.Offset(100, 100) ' adjust as needed
        '    'Me.Location = newLocation
        '    TelaUnica = False
        '    For I = 0 To TM - 1
        '        ComboMonitor.Items.Add(Monitor(I).DeviceName)
        '    Next
        '    ComboMonitor.SelectedIndex = 1
        'Else
        '    'TelaUnica = True
        '    ComboMonitor.Items.Add("Apenas 1 monitor detectado")
        '    MsgBox("Apenas monitor principal detectado.", vbExclamation, "Gerenciador de Projeção")
        'End If
        Label3.Parent = PictureBox5 'CRIAR transparencia dos textos
        Label4.Parent = PictureBox5
        Label5.Parent = PictureBox5
        Label6.Parent = PictureBox5
        'Label11.Parent = PictureBox6
        Label3.Location = New Point(2, 2) 'POSIÇÃO
        Label4.Location = New Point(2, 33)
        Label5.Location = New Point(2, 58)
        Label6.Location = New Point(2, 196)
        ConexDados = New OleDb.OleDbConnection(StringConexao(My.Settings.ArqDados))
        ConexHarpa = New OleDb.OleDbConnection(StringConexao(My.Settings.ArqHarpa))
        ConexNVI = New OleDb.OleDbConnection(StringConexao(My.Settings.ArqBibliaNVI))
        ConexACF = New OleDb.OleDbConnection(StringConexao(My.Settings.ArqBibliaACF))
        If Not Directory.Exists(LocalSystem & Label10.Text) Then
            MsgBox("Pasta padrão de salvamento não encontrada. Reestabeleça o caminho ou selecione outra pasta.", vbCritical, "Salvar Dados do systema")
            Button7.Enabled = False
        Else
            Label8.Text = LocalSystem & Label10.Text
        End If
        RadioButton3.Checked = True
    End Sub
    Private Sub AbrirFormNoPainel(Of Miform As {Form, New})()
        Dim Formulario As Form
        Formulario = PainelControle.Controls.OfType(Of Miform)().FirstOrDefault() 'Selecionar formulario
        If Formulario Is Nothing Then
            Formulario = New Miform()
            Formulario.TopLevel = False
            Formulario.FormBorderStyle = FormBorderStyle.None
            Formulario.Dock = DockStyle.Fill
            PainelControle.Controls.Add(Formulario)
            PainelControle.Tag = Formulario
            Formulario.Show()
            Formulario.BringToFront()
        Else
            Formulario.BringToFront()
        End If
    End Sub
    Private Sub ComboMonitor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboMonitor.SelectedIndexChanged
        Dim Im As Integer
        If ComboMonitor.Text <> "" Then
            If FormApresentar.Visible = True Then FormApresentar.Close()
            Im = Mid(ComboMonitor.Text, 1, 1)
            FormApresentar.Bounds = Screen.AllScreens(Im).Bounds
            FormApresentar.StartPosition = FormStartPosition.Manual
            FormApresentar.Show()
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'Selecionar Fundo
        AbrirFormNoPainel(Of FormFundo)()
        Button1.BackColor = Color.DarkSlateBlue
        Button2.BackColor = Color.Transparent
        Button3.BackColor = Color.Transparent
        Button4.BackColor = Color.Transparent
        Button5.BackColor = Color.Transparent
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click ''Selecionar Harpa
        AbrirFormNoPainel(Of FormHarpa)()
        Button1.BackColor = Color.Transparent
        Button2.BackColor = Color.DarkSlateBlue
        Button3.BackColor = Color.Transparent
        Button4.BackColor = Color.Transparent
        Button5.BackColor = Color.Transparent
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click 'Selecionar Bíblia
        AbrirFormNoPainel(Of FormBiblia)()
        Button1.BackColor = Color.Transparent
        Button2.BackColor = Color.Transparent
        Button3.BackColor = Color.DarkSlateBlue
        Button4.BackColor = Color.Transparent
        Button5.BackColor = Color.Transparent
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click 'Selecionar Imagens/audio
        AbrirFormNoPainel(Of FormImagens)()
        Button1.BackColor = Color.Transparent
        Button2.BackColor = Color.Transparent
        Button3.BackColor = Color.Transparent
        Button4.BackColor = Color.DarkSlateBlue
        Button5.BackColor = Color.Transparent
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click 'Selecionar Videos
        AbrirFormNoPainel(Of FormVideos)()
        Button1.BackColor = Color.Transparent
        Button2.BackColor = Color.Transparent
        Button3.BackColor = Color.Transparent
        Button4.BackColor = Color.Transparent
        Button5.BackColor = Color.DarkSlateBlue
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click 'Selecionar outra pasta
        Dim OFds As New FolderBrowserDialog With {.ShowNewFolderButton = False, .RootFolder = Environment.SpecialFolder.MyComputer}
        If OFds.ShowDialog = DialogResult.OK Then Label8.Text = OFds.SelectedPath
        Button7.Enabled = True
    End Sub
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged 'ATIVADA
        RadioButton1.BackColor = Color.FromArgb(143, 134, 153)
        RadioButton2.BackColor = Color.FromArgb(143, 134, 153)
        RadioButton3.BackColor = Color.FromArgb(143, 134, 153)
        RadioButton4.BackColor = Color.FromArgb(143, 134, 153)
        If RadioButton1.Checked = True Then
            If ImageF = True And File.Exists(ImageFundo) Then PictureBox5.Image = CarregarImagem(ImageFundo)
            If ImageS = True And PictureBox6.Visible = True And File.Exists(ImageSobre) Then PictureBox6.Image = CarregarImagem(ImageSobre)
            If ImageA = True And PictureBox8.Visible = True And File.Exists(ImageAudio) Then PictureBox8.Image = CarregarImagem(ImageAudio)
            If TextActive(0) = True And Textos(0) IsNot Nothing Then
                Label3.Text = Textos(0)
                Label3.TextAlign = Alinham(0)
                Label3.Font = Fonte(0)
                Label3.ForeColor = CorFonte(0)
                Label3.BackColor = CorPrench(0)
            Else
                Label3.Text = ""
            End If
            If TextActive(1) = True And Textos(1) IsNot Nothing Then
                Label4.Text = Textos(1)
                Label4.TextAlign = Alinham(1)
                Label4.Font = Fonte(1)
                Label4.ForeColor = CorFonte(1)
                Label4.BackColor = CorPrench(1)
            Else
                Label4.Text = ""
            End If
            If TextActive(2) = True And Textos(2) IsNot Nothing Then
                Label5.Text = Textos(2)
                Label5.TextAlign = Alinham(2)
                Label5.Font = Fonte(2)
                Label5.ForeColor = CorFonte(2)
                Label5.BackColor = CorPrench(2)
            Else
                Label5.Text = ""
            End If
            If TextActive(3) = True And Textos(3) IsNot Nothing Then
                Label6.Text = Textos(3)
                Label6.TextAlign = Alinham(3)
                Label6.Font = Fonte(3)
                Label6.ForeColor = CorFonte(3)
                Label6.BackColor = CorPrench(3)
            Else
                Label6.Text = ""
            End If
            If VideoOn = True Then Label11.Text = "VIDEO EM REPRODUÇÃO"
            RadioButton1.BackColor = Color.LightSteelBlue
        End If
        AtualizaApresentacao()
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged 'PAUSADA
        RadioButton1.BackColor = Color.FromArgb(143, 134, 153)
        RadioButton2.BackColor = Color.FromArgb(143, 134, 153)
        RadioButton3.BackColor = Color.FromArgb(143, 134, 153)
        RadioButton4.BackColor = Color.FromArgb(143, 134, 153)
        If RadioButton2.Checked = True Then
            RadioButton2.BackColor = Color.LightSteelBlue
        End If
        If VideoOn = True Then
            Label11.Text = "VIDEO PAUSADO"
            If FormApresentar.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPlaying Then FormApresentar.AxWindowsMediaPlayer1.Ctlcontrols.pause()
        End If
    End Sub
    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged 'NEUTRO
        RadioButton1.BackColor = Color.FromArgb(143, 134, 153)
        RadioButton2.BackColor = Color.FromArgb(143, 134, 153)
        RadioButton3.BackColor = Color.FromArgb(143, 134, 153)
        RadioButton4.BackColor = Color.FromArgb(143, 134, 153)
        If RadioButton3.Checked = True Then
            PictureBox5.Image = Nothing 'imagem fundo
            Label3.Text = ""
            Label3.BackColor = Color.Transparent
            Label4.Text = ""
            Label4.BackColor = Color.Transparent
            Label5.Text = ""
            Label5.BackColor = Color.Transparent
            Label6.Text = ""
            Label6.BackColor = Color.Transparent
            RadioButton3.BackColor = Color.LightSteelBlue
        End If
        AtualizaApresentacao()
    End Sub
    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged ' FECHADO
        RadioButton1.BackColor = Color.FromArgb(143, 134, 153)
        RadioButton2.BackColor = Color.FromArgb(143, 134, 153)
        RadioButton3.BackColor = Color.FromArgb(143, 134, 153)
        RadioButton4.BackColor = Color.FromArgb(143, 134, 153)
        If RadioButton4.Checked = True Then
            PictureBox5.Image = Nothing 'imagem fundo
            Label3.Text = ""
            Label3.BackColor = Color.Transparent
            Label4.Text = ""
            Label4.BackColor = Color.Transparent
            Label5.Text = ""
            Label5.BackColor = Color.Transparent
            Label6.Text = ""
            Label6.BackColor = Color.Transparent
            RadioButton4.BackColor = Color.LightSteelBlue
        End If
        FormApresentar.Close()
    End Sub


    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        If RadioButton1.Checked = True Then
            FormApresentar.RichTextBox1.Text = RichTextBox1.Text
            FormApresentar.RichTextBox1.SelectAll()
            FormApresentar.RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
            FormApresentar.RichTextBox1.DeselectAll()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        CheckBox1.BackColor = Color.Transparent
        If CheckBox1.Checked = True Then CheckBox1.BackColor = Color.SlateBlue
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged 'Harpa
        CheckBox2.BackColor = Color.Transparent
        If CheckBox2.Checked = True Then CheckBox2.BackColor = Color.SlateBlue
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        CheckBox3.BackColor = Color.Transparent
        If CheckBox3.Checked = True Then CheckBox3.BackColor = Color.SlateBlue
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        CheckBox4.BackColor = Color.Transparent
        If CheckBox4.Checked = True Then CheckBox4.BackColor = Color.SlateBlue
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        CheckBox5.BackColor = Color.Transparent
        If CheckBox5.Checked = True Then CheckBox5.BackColor = Color.SlateBlue
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click 'Salvar imagem
        If FormApresentar.Visible = True Then
            Dim Local As String = Label8.Text
            Dim Nome As String = "Imagem " & DateTime.Now.ToString("dd-MM-yyyy HHmmss") & ".jpeg"
            Dim Frm As Form = FormApresentar
            Try
                Using Img As New Bitmap(Frm.Bounds.Width, Frm.Bounds.Height) 'tamanho real da tela de projeção
                    Using Gph As Graphics = Graphics.FromImage(Img)
                        Gph.CopyFromScreen(Frm.Bounds.Location, Point.Empty, Img.Size)
                    End Using
                    Img.Save(Path.Combine(Local, Nome), Imaging.ImageFormat.Jpeg)
                End Using
            Catch ex As Exception
                MsgBox(ex.Message, vbCritical, "Salvar imagem")
            End Try
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click 'Opções

    End Sub

    Private Sub FormPrincipal_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If FormApresentar.Visible = True Then FormApresentar.Close()
    End Sub

    Private Sub FormPrincipal_Closed(sender As Object, e As EventArgs) Handles Me.Closed 'Fechar programa
        ConectarDados()
        If ZoomTFundo > 0 Then SalvarZoom("TextoFundo", ZoomTFundo)
        If ZoomTHarpa > 0 Then SalvarZoom("TextoHarpa", ZoomTHarpa)
        If ZoomTBiblia > 0 Then SalvarZoom("TextoBiblia", ZoomTBiblia)
        DesconectarDados()
    End Sub

    Private Sub SalvarZoom(Coluna As String, Valor As Integer) 'Coluna vem apenas do código (não do usuário)
        Try
            Using Comando As New OleDb.OleDbCommand("UPDATE Zoom SET " & Coluna & " = ? WHERE ID = 1", ConexDados)
                Comando.Parameters.AddWithValue("@Valor", Valor)
                Comando.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Salvar Dados do systema")
        End Try
    End Sub


End Class
