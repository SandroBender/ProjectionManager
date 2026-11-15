Imports System.IO
Imports AxWMPLib
Public Class FormVideos
    Dim PastaVideos As String = LocalSystem & "\ProjectionManager\VIDEOS"
    Dim PastaAudios As String = LocalSystem & "\ProjectionManager\AUDIOS"
    Dim PastaMinhasMusicas As String = My.Computer.FileSystem.SpecialDirectories.MyMusic
    Dim CamSelect As String
    Dim PlayLista As WMPLib.IWMPPlaylist

    Private Sub FormVideos_Load(sender As Object, e As EventArgs) Handles Me.Load
        rbVideos.Checked = True
    End Sub

    Private Sub rbVideos_CheckedChanged(sender As Object, e As EventArgs) Handles rbVideos.CheckedChanged
        If rbVideos.Checked = True Then
            webPastas.Url = New Uri(PastaVideos)
            CamSelect = PastaVideos
            wmpPlayer.Size = New Size(394, 280)
            wmpPlayer.Location = New Point(0, 0)
            rbDesligado.Checked = True
            rbReproduzirVideo.Visible = True
            rbApresentarImagem.Visible = False
            lblArquivoImagem.Text = "Nenhum arquivo"
            lblIndiceImagem.Text = "0"
            picImagem.Image = Nothing
            ProxArq(IP:=1, Pasta:=CamSelect)
        End If
    End Sub

    Private Sub rbAudios_CheckedChanged(sender As Object, e As EventArgs) Handles rbAudios.CheckedChanged
        If rbAudios.Checked = True Then
            webPastas.Url = New Uri(PastaAudios)
            CamSelect = PastaAudios
            wmpPlayer.Size = New Size(394, 100)
            wmpPlayer.Location = New Point(0, 0)
            rbDesligado.Checked = True
            rbReproduzirVideo.Visible = False
            rbApresentarImagem.Visible = True
            lblArquivoImagem.Text = "Nenhum arquivo"
            lblIndiceImagem.Text = "0"
            picImagem.Image = Nothing
            ProxArq(IP:=1, Pasta:=CamSelect)
        End If
    End Sub

    Private Sub rbMinhasMusicas_CheckedChanged(sender As Object, e As EventArgs) Handles rbMinhasMusicas.CheckedChanged
        If rbMinhasMusicas.Checked = True Then
            webPastas.Url = New Uri(PastaMinhasMusicas)
            CamSelect = PastaMinhasMusicas
            wmpPlayer.Size = New Size(394, 100)
            wmpPlayer.Location = New Point(0, 0)
            rbDesligado.Checked = True
            rbReproduzirVideo.Visible = False
            rbApresentarImagem.Visible = True
            lblArquivoImagem.Text = "Nenhum arquivo"
            lblIndiceImagem.Text = "0"
            picImagem.Image = Nothing
            ProxArq(IP:=1, Pasta:=CamSelect)
        End If
    End Sub

    Private Sub rbDesligado_CheckedChanged(sender As Object, e As EventArgs) Handles rbDesligado.CheckedChanged 'Desativado
        rbDesligado.BackColor = Color.Transparent
        If rbDesligado.Checked = True Then
            rbDesligado.BackColor = Color.AliceBlue
            FormPrincipal.chkAudioVideo.Checked = False
        End If
        Transferir()
    End Sub

    Private Sub rbReproduzirVideo_CheckedChanged(sender As Object, e As EventArgs) Handles rbReproduzirVideo.CheckedChanged 'Ativado Video
        rbReproduzirVideo.BackColor = Color.Transparent
        If rbReproduzirVideo.Checked = True Then
            rbReproduzirVideo.BackColor = Color.AliceBlue
            FormPrincipal.chkAudioVideo.Checked = True
        End If
        Transferir()
    End Sub

    Private Sub rbApresentarImagem_CheckedChanged(sender As Object, e As EventArgs) Handles rbApresentarImagem.CheckedChanged 'Ativado Imagem
        rbApresentarImagem.BackColor = Color.Transparent
        If rbApresentarImagem.Checked = True Then
            rbApresentarImagem.BackColor = Color.AliceBlue
            FormPrincipal.chkAudioVideo.Checked = True
        End If
        Transferir()
    End Sub

    Private Sub Transferir()
        ImageAudio = lblArquivoImagem.Text
        If rbReproduzirVideo.Checked = True Then 'video
            ImageA = False
            If FormPrincipal.rbAtivada.Checked = True Then FormPrincipal.picAudio.Image = Nothing
            VideoOn = True
            If wmpPlayer.playState = WMPLib.WMPPlayState.wmppsPlaying Then wmpPlayer.Ctlcontrols.pause()
        ElseIf rbApresentarImagem.Checked = True Then 'imagem
            VideoOn = False
            ImageA = False
            If FormPrincipal.rbAtivada.Checked = True Then FormPrincipal.picAudio.Image = Nothing
            If lblArquivoImagem.Text <> "Nenhum arquivo" Then
                ImageA = True
                If FormPrincipal.rbAtivada.Checked = True Then FormPrincipal.picAudio.Image = picImagem.Image
            End If
        Else
            ImageA = False
            If FormPrincipal.rbAtivada.Checked = True Then FormPrincipal.picAudio.Image = Nothing
            VideoOn = False
            'If FormPrincipal.rbAtivada.Checked = True Then FormPrincipal.lblStatusVideo.Visible = False
        End If
        AtualizaApresentacao()
    End Sub

    Private Sub lstReproducao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstReproducao.SelectedIndexChanged
        lblArquivoSelecionado.Text = ""
        Video = ""
        If lstReproducao.Items.Count > 0 Then
            Dim ArqVideo As String = lstReproducao.SelectedItem.ToString
            wmpPlayer.URL = ArqVideo
            Video = ArqVideo
            Dim P As Integer = InStrRev(ArqVideo, "\", -1, CompareMethod.Text) 'conferir se for arquivo
            lblArquivoSelecionado.Text = Mid(ArqVideo, P + 1, 50)
            'wmpPlayer.Ctlcontrols.play()
        End If
    End Sub

    Private Sub btnLimparLista_Click(sender As Object, e As EventArgs) Handles btnLimparLista.Click 'Limpar lista
        PararPlayer(wmpPlayer)
        lstReproducao.Items.Clear()
        lblArquivoSelecionado.Text = ""
    End Sub

    Private Sub lstReproducao_DragEnter(sender As Object, e As DragEventArgs) Handles lstReproducao.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub lstReproducao_DragDrop(sender As Object, e As DragEventArgs) Handles lstReproducao.DragDrop
        Dim Videos() As String
        Try
            Videos = e.Data.GetData(DataFormats.FileDrop)
            For I As Integer = 0 To Videos.Length - 1
                If File.Exists(Videos(I)) Then lstReproducao.Items.Add(Videos(I))
            Next
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Arrastar Video")
        End Try
    End Sub

    Private Sub btnVoltarPasta_Click(sender As Object, e As EventArgs) Handles btnVoltarPasta.Click
        webPastas.GoBack()
    End Sub

    Private Sub btnRetroceder_Click(sender As Object, e As EventArgs) Handles btnRetroceder.Click 'Retroceder
        Dim IA As Integer = lblIndiceImagem.Text 'indice atual
        If CamSelect <> Nothing Then
            If IA > 1 Then ProxArq(IP:=IA - 1, Pasta:=CamSelect)
        End If
    End Sub

    Private Sub btnAvancar_Click(sender As Object, e As EventArgs) Handles btnAvancar.Click 'Avançar
        Dim IA As Integer = lblIndiceImagem.Text 'indice atual
        If CamSelect <> Nothing Then
            ProxArq(IP:=IA + 1, Pasta:=CamSelect)
        End If
    End Sub

    Private Sub ProxArq(IP As Integer, Pasta As String)
        Dim Arq As String = Nothing
        Dim Indice As Integer = ImagemDaPasta(Pasta, IP, Arq) 'volta para a 1ª imagem depois da última
        If Indice < 0 Then Exit Sub 'pasta vazia ou inexistente
        picImagem.Image = CarregarImagem(Arq)
        ImageAudio = Arq
        lblArquivoImagem.Text = Arq
        lblIndiceImagem.Text = Indice
        Transferir()
    End Sub
End Class