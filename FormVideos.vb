Imports System.IO
Imports AxWMPLib
Public Class FormVideos
    Dim PastaVideos As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ProjectionManager\VIDEOS"
    Dim PastaAudios As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ProjectionManager\AUDIOS"
    Dim PastaMinhasMusicas As String = My.Computer.FileSystem.SpecialDirectories.MyMusic
    Dim CamSelect As String
    Dim PlayLista As WMPLib.IWMPPlaylist

    Private Sub FormVideos_Load(sender As Object, e As EventArgs) Handles Me.Load
        RadioButton1.Checked = True
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            WebBrowser1.Url = New Uri(PastaVideos)
            CamSelect = PastaVideos
            AxWindowsMediaPlayer1.Size = New Size(394, 280)
            AxWindowsMediaPlayer1.Location = New Point(0, 0)
            RadioButton3.Checked = True
            RadioButton4.Visible = True
            RadioButton6.Visible = False
            Label3.Text = "Nenhum arquivo"
            Label6.Text = "0"
            PictureBox1.Image = Nothing
            ProxArq(IP:=1, Pasta:=CamSelect)
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            WebBrowser1.Url = New Uri(PastaAudios)
            CamSelect = PastaAudios
            AxWindowsMediaPlayer1.Size = New Size(394, 100)
            AxWindowsMediaPlayer1.Location = New Point(0, 0)
            RadioButton3.Checked = True
            RadioButton4.Visible = False
            RadioButton6.Visible = True
            Label3.Text = "Nenhum arquivo"
            Label6.Text = "0"
            PictureBox1.Image = Nothing
            ProxArq(IP:=1, Pasta:=CamSelect)
        End If
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        If RadioButton5.Checked = True Then
            WebBrowser1.Url = New Uri(PastaMinhasMusicas)
            CamSelect = PastaMinhasMusicas
            AxWindowsMediaPlayer1.Size = New Size(394, 100)
            AxWindowsMediaPlayer1.Location = New Point(0, 0)
            RadioButton3.Checked = True
            RadioButton4.Visible = False
            RadioButton6.Visible = True
            Label3.Text = "Nenhum arquivo"
            Label6.Text = "0"
            PictureBox1.Image = Nothing
            ProxArq(IP:=1, Pasta:=CamSelect)
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged 'Desativado
        RadioButton3.BackColor = Color.Transparent
        If RadioButton3.Checked = True Then
            RadioButton3.BackColor = Color.AliceBlue
            FormPrincipal.CheckBox5.Checked = False
        End If
        Transferir()
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged 'Ativado Video
        RadioButton4.BackColor = Color.Transparent
        If RadioButton4.Checked = True Then
            RadioButton4.BackColor = Color.AliceBlue
            FormPrincipal.CheckBox5.Checked = True
        End If
        Transferir()
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged 'Ativado Imagem
        RadioButton6.BackColor = Color.Transparent
        If RadioButton6.Checked = True Then
            RadioButton6.BackColor = Color.AliceBlue
            FormPrincipal.CheckBox5.Checked = True
        End If
        Transferir()
    End Sub

    Private Sub Transferir()
        ImageAudio = Label3.Text
        If RadioButton4.Checked = True Then 'video
            ImageA = False
            If FormPrincipal.RadioButton1.Checked = True Then FormPrincipal.PictureBox8.Image = Nothing
            VideoOn = True
            If AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPlaying Then AxWindowsMediaPlayer1.Ctlcontrols.pause()
        ElseIf RadioButton6.Checked = True Then 'imagem
            VideoOn = False
            ImageA = False
            If FormPrincipal.RadioButton1.Checked = True Then FormPrincipal.PictureBox8.Image = Nothing
            If Label3.Text <> "Nenhum arquivo" Then
                ImageA = True
                If FormPrincipal.RadioButton1.Checked = True Then FormPrincipal.PictureBox8.Image = PictureBox1.Image
            End If
        Else
            ImageA = False
            If FormPrincipal.RadioButton1.Checked = True Then FormPrincipal.PictureBox8.Image = Nothing
            VideoOn = False
            'If FormPrincipal.RadioButton1.Checked = True Then FormPrincipal.Label11.Visible = False
        End If
        AtualizaApresentacao()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Label1.Text = ""
        Video = ""
        If ListBox1.Items.Count > 0 Then
            Dim ArqVideo As String = ListBox1.SelectedItem.ToString
            AxWindowsMediaPlayer1.URL = ArqVideo
            Video = ArqVideo
            Dim P As Integer = InStrRev(ArqVideo, "\", -1, CompareMethod.Text) 'conferir se for arquivo
            Label1.Text = Mid(ArqVideo, P + 1, 50)
            'AxWindowsMediaPlayer1.Ctlcontrols.play()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click 'Limpar lista
        If AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPlaying Or AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPaused Then
            AxWindowsMediaPlayer1.Ctlcontrols.stop()
        End If
        ListBox1.Items.Clear()
        Label1.Text = ""
    End Sub

    Private Sub ListBox1_DragEnter(sender As Object, e As DragEventArgs) Handles ListBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub ListBox1_DragDrop(sender As Object, e As DragEventArgs) Handles ListBox1.DragDrop
        Dim Videos() As String
        Try
            Videos = e.Data.GetData(DataFormats.FileDrop)
            For I As Integer = 0 To Videos.Length - 1
                If File.Exists(Videos(I)) Then ListBox1.Items.Add(Videos(I))
            Next
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Arrastar Video")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        WebBrowser1.GoBack()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click 'Retroceder
        Dim IA As Integer = Label6.Text 'indice atual
        If CamSelect <> Nothing Then
            If IA > 1 Then ProxArq(IP:=IA - 1, Pasta:=CamSelect)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click 'Avançar
        Dim IA As Integer = Label6.Text 'indice atual
        If CamSelect <> Nothing Then
            ProxArq(IP:=IA + 1, Pasta:=CamSelect)
        End If
    End Sub

    Private Sub ProxArq(IP As Integer, Pasta As String)
        Dim TA As Integer 'total arquivos
        Dim IC As Integer = 0 'indice contagem
        Dim Ext As String = "*.png,*.jpg,*.jpeg,*.bmp,*.JPG,*.JPEG,*.PNG"
        Dim Arquivos As String() = Directory.GetFiles(Pasta, "*.*")
        If Arquivos.Count = 0 Then Exit Sub
        Array.Sort(Arquivos)
        For Each Arq As String In Arquivos
            If Ext.Contains(Path.GetExtension(Arq)) Then TA += 1
        Next
        For Each Arq As String In Arquivos
            If Ext.Contains(Path.GetExtension(Arq)) Then
                If IP >= TA Then
                    Label6.Text = "0"
                    PictureBox1.Image = Image.FromFile(Arq)
                    ImageAudio = Arq
                    Label3.Text = Arq
                    Transferir()
                    Exit For
                End If
                'If IA = IC Then IP = IC + 1 'indice anterior encontrado
                If IP = IC Then 'próximo indice encontrado
                    PictureBox1.Image = Image.FromFile(Arq)
                    ImageAudio = Arq
                    Label3.Text = Arq
                    Label6.Text = IP
                    Transferir()
                    Exit For
                End If
                IC += 1
            End If
        Next
    End Sub
End Class