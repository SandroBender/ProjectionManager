Imports System.IO
Public Class FormImagens
    Dim PastaImagens As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\ProjectionManager\IMAGENS"
    Dim PMImagens As String() = Directory.GetDirectories(PastaImagens)
    Dim PCImagens As String = My.Computer.FileSystem.SpecialDirectories.MyPictures
    Dim CamSelect As String

    Private Sub FormFundo_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim I As Integer
        Dim P As Integer
        Dim Pasta As String
        For I = 0 To PMImagens.Count - 1
            P = InStrRev(PMImagens(I), "\", -1, vbTextCompare)
            Pasta = Mid(PMImagens(I), P + 1, 50)
            ComboBox1.Items.Add(Pasta)
        Next
        PictureBox1.AllowDrop = True
        ConectarDados()
        CarregarImagens()
        DesconectarDados()
        Try
            PictureBox1.Image = Image.FromFile(RegImagens.Rows(0).Item("CamImagem"))
            ImageSobre = RegImagens.Rows(0).Item("CamImagem")
            Label1.Text = RegImagens.Rows(0).Item("CamImagem")
        Catch ex As Exception
            Label1.Text = RegImagens.Rows(0).Item("CamImagem")
        End Try

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            WebBrowser1.Stop()
            ComboBox1.Visible = True
        End If
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged  'Minhas Imagens
        If RadioButton2.Checked = True Then
            WebBrowser1.Url = New Uri(PCImagens)
            CamSelect = PCImagens
        End If
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim I As Integer = ComboBox1.SelectedIndex
        WebBrowser1.Url = New Uri(PMImagens(I))
        CamSelect = PMImagens(I)

    End Sub

    Private Sub PictureBox1_DragEnter_1(sender As Object, e As DragEventArgs) Handles PictureBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub PictureBox1_DragDrop_1(sender As Object, e As DragEventArgs) Handles PictureBox1.DragDrop
        Dim Ext As String
        Dim P As Integer
        Try
            ImageSobre = e.Data.GetData(DataFormats.FileDrop)(0)
            If Not File.Exists(ImageSobre) Then Exit Sub
            Ext = Mid(ImageSobre, Len(ImageSobre) - 3, 5)
            P = InStrRev(ImageSobre, "\", -1, CompareMethod.Text)
            CamSelect = Mid(ImageSobre, 1, P - 1)
            'If Ext <> ".jpg" And Ext <> "jpeg" And Ext <> ".png" And Ext <> ".bmp" Then Exit Sub
            PictureBox1.Image = Image.FromFile(ImageSobre)
            Label1.Text = ImageSobre
            Transferir()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Arrastar Imagem")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'Retornar
        Dim IA As Integer = Label6.Text 'indice atual
        If CamSelect = Nothing Then
            MsgBox("Arraste a 1° Imagem pra continuar.", vbCritical, "Alterar Imagem")
        Else
            If IA > 0 Then ProxArq(IP:=IA - 1, Pasta:=CamSelect)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click 'avançar
        Dim IA As Integer = Label6.Text 'indice atual
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
                    Label6.Text = "0"
                    PictureBox1.Image = Image.FromFile(Arq)
                    ImageSobre = Arq
                    Label1.Text = Arq
                    Transferir()
                    Exit For
                End If
                'If IA = IC Then IP = IC + 1 'indice anterior encontrado
                If IP = IC Then 'próximo indice encontrado
                    PictureBox1.Image = Image.FromFile(Arq)
                    ImageSobre = Arq
                    Label1.Text = Arq
                    Label6.Text = IP
                    Transferir()
                    Exit For
                End If
                IC += 1
            End If
        Next
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged 'imagem destivada
        RadioButton3.BackColor = Color.Transparent
        RadioButton4.BackColor = Color.Transparent
        If RadioButton3.Checked = True Then
            RadioButton3.BackColor = Color.AliceBlue
            FormPrincipal.CheckBox4.Checked = False
        End If
        Transferir()
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged 'IMAGEM ATIVADA
        RadioButton3.BackColor = Color.Transparent
        RadioButton4.BackColor = Color.Transparent
        If RadioButton4.Checked = True Then
            RadioButton4.BackColor = Color.AliceBlue
            RadioButton3.BackColor = Color.Transparent
            FormPrincipal.CheckBox4.Checked = True
        End If
        Transferir()
    End Sub

    Private Sub Transferir()
        ImageSobre = Label1.Text
        If RadioButton4.Checked = True Then
            ImageS = True
            If FormPrincipal.RadioButton1.Checked = True Then FormPrincipal.PictureBox6.Image = PictureBox1.Image
        Else
            ImageS = False
            If FormPrincipal.RadioButton1.Checked = True Then FormPrincipal.PictureBox6.Image = Nothing
        End If
        AtualizaApresentacao()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click 'Voltar
        WebBrowser1.GoBack()
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        PictureBox1.SizeMode = PictureBoxSizeMode.Normal 'Tamanho original
        AjusteDimensional = "N"
        If FormPrincipal.RadioButton1.Checked = True Then
            FormPrincipal.PictureBox6.SizeMode = PictureBoxSizeMode.Normal
            AtualizaApresentacao()
        End If
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage 'Ajustar ao tamanho
        AjusteDimensional = "S"
        If FormPrincipal.RadioButton1.Checked = True Then
            FormPrincipal.PictureBox6.SizeMode = PictureBoxSizeMode.StretchImage
            AtualizaApresentacao()
        End If
    End Sub

    Private Sub RadioButton7_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton7.CheckedChanged
        PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
        AjusteDimensional = "C"
        If FormPrincipal.RadioButton1.Checked = True Then
            FormPrincipal.PictureBox6.SizeMode = PictureBoxSizeMode.CenterImage
            AtualizaApresentacao()
        End If
    End Sub

    Private Sub RadioButton8_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton8.CheckedChanged
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom 'Manter proporção
        AjusteDimensional = "Z"
        If FormPrincipal.RadioButton1.Checked = True Then
            FormPrincipal.PictureBox6.SizeMode = PictureBoxSizeMode.Zoom
            AtualizaApresentacao()
        End If
    End Sub




End Class