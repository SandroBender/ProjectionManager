Imports System.IO
Public Class FormImagens
    Dim PastaImagens As String = LocalSystem & "\ProjectionManager\IMAGENS"
    Dim PMImagens As String() = {}
    Dim PCImagens As String = My.Computer.FileSystem.SpecialDirectories.MyPictures
    Dim CamSelect As String

    Private Sub FormFundo_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim I As Integer
        Dim P As Integer
        Dim Pasta As String
        If Directory.Exists(PastaImagens) Then
            PMImagens = Directory.GetDirectories(PastaImagens)
        Else
            MsgBox("Pasta de imagens não encontrada: " & PastaImagens, vbExclamation, "Imagens")
        End If
        For I = 0 To PMImagens.Count - 1
            P = InStrRev(PMImagens(I), "\", -1, vbTextCompare)
            Pasta = Mid(PMImagens(I), P + 1, 50)
            cboPastas.Items.Add(Pasta)
        Next
        picPreview.AllowDrop = True
        ConectarDados()
        CarregarImagens()
        DesconectarDados()
        Try
            picPreview.Image = CarregarImagem(RegImagens.Rows(0).Item("CamImagem"))
            ImageSobre = RegImagens.Rows(0).Item("CamImagem")
            lblArquivo.Text = RegImagens.Rows(0).Item("CamImagem")
        Catch ex As Exception
            lblArquivo.Text = "Não encontrada"
        End Try

    End Sub

    Private Sub rbGerenciador_CheckedChanged(sender As Object, e As EventArgs) Handles rbGerenciador.CheckedChanged
        If rbGerenciador.Checked = True Then
            webPastas.Stop()
            cboPastas.Visible = True
        End If
    End Sub
    Private Sub rbMinhasImagens_CheckedChanged(sender As Object, e As EventArgs) Handles rbMinhasImagens.CheckedChanged  'Minhas Imagens
        If rbMinhasImagens.Checked = True Then
            webPastas.Url = New Uri(PCImagens)
            CamSelect = PCImagens
        End If
    End Sub
    Private Sub cboPastas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPastas.SelectedIndexChanged
        Dim I As Integer = cboPastas.SelectedIndex
        webPastas.Url = New Uri(PMImagens(I))
        CamSelect = PMImagens(I)

    End Sub

    Private Sub picPreview_DragEnter_1(sender As Object, e As DragEventArgs) Handles picPreview.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub picPreview_DragDrop_1(sender As Object, e As DragEventArgs) Handles picPreview.DragDrop
        Dim Ext As String
        Dim P As Integer
        Try
            ImageSobre = e.Data.GetData(DataFormats.FileDrop)(0)
            If Not File.Exists(ImageSobre) Then Exit Sub
            Ext = Mid(ImageSobre, Len(ImageSobre) - 3, 5)
            P = InStrRev(ImageSobre, "\", -1, CompareMethod.Text)
            CamSelect = Mid(ImageSobre, 1, P - 1)
            'If Ext <> ".jpg" And Ext <> "jpeg" And Ext <> ".png" And Ext <> ".bmp" Then Exit Sub
            picPreview.Image = CarregarImagem(ImageSobre)
            lblArquivo.Text = ImageSobre
            Transferir()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Arrastar Imagem")
        End Try
    End Sub

    Private Sub btnRetroceder_Click(sender As Object, e As EventArgs) Handles btnRetroceder.Click 'Retornar
        Dim IA As Integer = lblIndiceImagem.Text 'indice atual
        If CamSelect = Nothing Then
            MsgBox("Arraste a 1° Imagem pra continuar.", vbCritical, "Alterar Imagem")
        Else
            If IA > 0 Then ProxArq(IP:=IA - 1, Pasta:=CamSelect)
        End If
    End Sub

    Private Sub btnAvancar_Click(sender As Object, e As EventArgs) Handles btnAvancar.Click 'avançar
        Dim IA As Integer = lblIndiceImagem.Text 'indice atual
        If CamSelect = Nothing Then
            MsgBox("Arraste a 1° Imagem pra continuar.", vbCritical, "Alterar Imagem")
        Else
            ProxArq(IP:=IA + 1, Pasta:=CamSelect)
        End If
    End Sub

    Private Sub ProxArq(IP As Integer, Pasta As String)
        Dim TA As Integer 'total arquivos
        Dim IC As Integer = 0 'indice contagem
        Dim Ext As String = "*.png,*.jpg,*.jpeg,*.bmp,*.JPG,*.JPEG,*.PNG"
        Dim Arquivos As String() = Directory.GetFiles(Pasta, "*.*")
        Array.Sort(Arquivos)
        For Each Arq As String In Arquivos
            If Ext.Contains(Path.GetExtension(Arq)) Then TA += 1
        Next
        For Each Arq As String In Arquivos
            If Ext.Contains(Path.GetExtension(Arq)) Then
                If IP >= TA Then
                    lblIndiceImagem.Text = "0"
                    picPreview.Image = CarregarImagem(Arq)
                    ImageSobre = Arq
                    lblArquivo.Text = Arq
                    Transferir()
                    Exit For
                End If
                'If IA = IC Then IP = IC + 1 'indice anterior encontrado
                If IP = IC Then 'próximo indice encontrado
                    picPreview.Image = CarregarImagem(Arq)
                    ImageSobre = Arq
                    lblArquivo.Text = Arq
                    lblIndiceImagem.Text = IP
                    Transferir()
                    Exit For
                End If
                IC += 1
            End If
        Next
    End Sub

    Private Sub rbDesligado_CheckedChanged(sender As Object, e As EventArgs) Handles rbDesligado.CheckedChanged 'imagem destivada
        rbDesligado.BackColor = Color.Transparent
        rbLigado.BackColor = Color.Transparent
        If rbDesligado.Checked = True Then
            rbDesligado.BackColor = Color.AliceBlue
            FormPrincipal.chkImagens.Checked = False
        End If
        Transferir()
    End Sub

    Private Sub rbLigado_CheckedChanged(sender As Object, e As EventArgs) Handles rbLigado.CheckedChanged 'IMAGEM ATIVADA
        rbDesligado.BackColor = Color.Transparent
        rbLigado.BackColor = Color.Transparent
        If rbLigado.Checked = True Then
            rbLigado.BackColor = Color.AliceBlue
            rbDesligado.BackColor = Color.Transparent
            FormPrincipal.chkImagens.Checked = True
        End If
        Transferir()
    End Sub

    Private Sub Transferir()
        ImageSobre = lblArquivo.Text
        If rbLigado.Checked = True Then
            ImageS = True
            If FormPrincipal.rbAtivada.Checked = True Then FormPrincipal.picSobreposicao.Image = picPreview.Image
        Else
            ImageS = False
            If FormPrincipal.rbAtivada.Checked = True Then FormPrincipal.picSobreposicao.Image = Nothing
        End If
        AtualizaApresentacao()
    End Sub

    Private Sub btnVoltarPasta_Click(sender As Object, e As EventArgs) Handles btnVoltarPasta.Click 'Voltar
        webPastas.GoBack()
    End Sub

    Private Sub rbTamanhoOriginal_CheckedChanged(sender As Object, e As EventArgs) Handles rbTamanhoOriginal.CheckedChanged
        picPreview.SizeMode = PictureBoxSizeMode.Normal 'Tamanho original
        AjusteDimensional = "N"
        If FormPrincipal.rbAtivada.Checked = True Then
            FormPrincipal.picSobreposicao.SizeMode = PictureBoxSizeMode.Normal
            AtualizaApresentacao()
        End If
    End Sub

    Private Sub rbAjustarTamanho_CheckedChanged(sender As Object, e As EventArgs) Handles rbAjustarTamanho.CheckedChanged
        picPreview.SizeMode = PictureBoxSizeMode.StretchImage 'Ajustar ao tamanho
        AjusteDimensional = "S"
        If FormPrincipal.rbAtivada.Checked = True Then
            FormPrincipal.picSobreposicao.SizeMode = PictureBoxSizeMode.StretchImage
            AtualizaApresentacao()
        End If
    End Sub

    Private Sub rbOriginalCentralizado_CheckedChanged(sender As Object, e As EventArgs) Handles rbOriginalCentralizado.CheckedChanged
        picPreview.SizeMode = PictureBoxSizeMode.CenterImage
        AjusteDimensional = "C"
        If FormPrincipal.rbAtivada.Checked = True Then
            FormPrincipal.picSobreposicao.SizeMode = PictureBoxSizeMode.CenterImage
            AtualizaApresentacao()
        End If
    End Sub

    Private Sub rbManterProporcao_CheckedChanged(sender As Object, e As EventArgs) Handles rbManterProporcao.CheckedChanged
        picPreview.SizeMode = PictureBoxSizeMode.Zoom 'Manter proporção
        AjusteDimensional = "Z"
        If FormPrincipal.rbAtivada.Checked = True Then
            FormPrincipal.picSobreposicao.SizeMode = PictureBoxSizeMode.Zoom
            AtualizaApresentacao()
        End If
    End Sub




End Class