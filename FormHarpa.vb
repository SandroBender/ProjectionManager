Imports System.IO
Public Class FormHarpa
    Private Player As PlayerTela 'áudio do hino (voz/playback), tocado pelo operador
    Dim PastaAudios As String = LocalSystem & "\ProjectionManager\AUDIOS\Harpa"
    Dim EE As Integer 'Encremento de estrofe
    Private Sub FormHarpa_Load(sender As Object, e As EventArgs) Handles Me.Load
        ConectarDados()
        CarregarZoom()
        DesconectarDados()
        lblPastaAudio.Text = PastaAudios
        Dim Val As Integer = RegZoom.Rows(0).Item("TextoHarpa")
        lblZoom.Text = Val
        trkZoom.Value = Val
        ZoomHarpa = Val
        Player = New PlayerTela(webAudio)
        If lstHinos.DisplayMember = "" Then
            ConectarHarpa()
            CarregarHarpa()
            DesconectarHarpa()
            lstHinos.DataSource = ListaHarpa
            lstHinos.ValueMember = "Indice"
            lstHinos.DisplayMember = "Titulo"
        End If

    End Sub

    Private Sub btnEscolherPasta_Click(sender As Object, e As EventArgs) Handles btnEscolherPasta.Click
        Dim OFds As New FolderBrowserDialog With {.ShowNewFolderButton = False, .RootFolder = Environment.SpecialFolder.MyComputer}
        If OFds.ShowDialog = DialogResult.OK Then lblPastaAudio.Text = OFds.SelectedPath
    End Sub

    Private Sub lstHinos_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles lstHinos.SelectedIndexChanged
        Dim TE As Integer
        Dim I As Integer
        Dim C As Integer
        If lstHinos.DisplayMember <> "" Then
            I = lstHinos.SelectedIndex
            For C = 2 To 13
                If RegHarpa.Rows(I).Item(C) <> "-" Then TE += 1
            Next
            lblTotalEstrofes.Text = TE
            rtbEstrofe.Clear()
            TextoHarpa = vbTab & StrConv(ListaHarpa.Rows(I).Item(1), vbUpperCase)
            lblEstrofeAtual.Text = 0
            Transferir()
            lblArquivoAudio.Text = "Não Localizado"
            Player.Parar()
            webAudio.Visible = False
            LocalizarArquivo(I:=I)
        End If
    End Sub

    Private Sub rbVoz_Click(sender As Object, e As EventArgs) Handles rbVoz.Click

    End Sub

    Private Sub rbPlayback_Click(sender As Object, e As EventArgs) Handles rbPlayback.Click

    End Sub

    Private Sub LocalizarArquivo(I As String)
        Try
            Dim Pasta As String = lblPastaAudio.Text
            Dim Arquivos As String() = Directory.GetFiles(Pasta, "*.*")
            Dim Ext As String = "*.mp3"
            Dim Nome As String
            Dim P As Integer
            Dim ID As String = Format(I + 1, "000")
            Array.Sort(Arquivos)
            For Each Arq As String In Arquivos
                If Ext.Contains(Path.GetExtension(Arq)) Then
                    P = InStrRev(Arq, "\", -1, CompareMethod.Text)
                    Nome = Mid(Arq, P + 1, 50)
                    If ID = Mid(Nome, 1, 3) Then
                        If (rbVoz.Checked = True And InStr(Nome, "playback", CompareMethod.Text) = 0) Or (rbPlayback.Checked = True And InStr(Nome, "playback", CompareMethod.Text) > 0) Then 'voz
                            lblArquivoAudio.Text = Nome
                            If InStr(Nome, "playback", CompareMethod.Text) = 0 Then
                                lblArquivoAudio.BackColor = Color.LightCyan
                            Else
                                lblArquivoAudio.BackColor = Color.Moccasin
                            End If
                            webAudio.Visible = True
                            Player.Carregar(Arq) 'pronto para tocar, sem começar sozinho
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            lblArquivoAudio.Text = "Erro ao Localizar arquivo"
        End Try
    End Sub

    Private Sub rbDesligado_CheckedChanged(sender As Object, e As EventArgs) Handles rbDesligado.CheckedChanged 'desativado
        rbDesligado.BackColor = Color.Transparent
        btnRetroceder.BackColor = Color.FromArgb(204, 200, 215)
        btnAvancar.BackColor = Color.FromArgb(204, 200, 215)
        If rbDesligado.Checked = True Then
            rbDesligado.BackColor = Color.AliceBlue
            FormPrincipal.chkHarpa.Checked = False
        End If
        Transferir()
    End Sub

    Private Sub rbLigado_CheckedChanged(sender As Object, e As EventArgs) Handles rbLigado.CheckedChanged 'ativado
        rbLigado.BackColor = Color.Transparent
        btnRetroceder.BackColor = Color.FromArgb(204, 200, 215)
        btnAvancar.BackColor = Color.FromArgb(204, 200, 215)
        If rbLigado.Checked = True Then
            rbLigado.BackColor = Color.AliceBlue
            btnRetroceder.BackColor = Color.LightSteelBlue
            btnAvancar.BackColor = Color.LightSteelBlue
            FormPrincipal.chkHarpa.Checked = True
        End If
        Transferir()
    End Sub


    Private Sub btnRetroceder_Click(sender As Object, e As EventArgs) Handles btnRetroceder.Click  'Retroceder
        EE = -1
        Estrofes()
        Transferir()
    End Sub

    Private Sub btnAvancar_Click_1(sender As Object, e As EventArgs) Handles btnAvancar.Click 'avançar
        EE = 1
        Estrofes()
        Transferir()
    End Sub

    Private Sub Estrofes()
        Dim I As Integer
        Dim TE As Integer = lblTotalEstrofes.Text
        Dim IE As Integer = lblEstrofeAtual.Text
        I = lstHinos.SelectedIndex
        IE = IE + EE
        If IE > 0 And IE <= TE Then
            If chkAdicionarTitulo.Checked = True Then
                rtbEstrofe.Text = StrConv(RegHarpa.Rows(I).Item(IE + 1), vbUpperCase)
                TextoHarpa = vbTab & StrConv(ListaHarpa.Rows(I).Item(1), vbUpperCase) & vbLf & vbLf & rtbEstrofe.Text
            Else
                rtbEstrofe.Text = StrConv(RegHarpa.Rows(I).Item(IE + 1), vbUpperCase)
                TextoHarpa = StrConv(RegHarpa.Rows(I).Item(IE + 1), vbUpperCase)
            End If
            lblEstrofeAtual.Text = IE
            rtbEstrofe.SelectAll()
            rtbEstrofe.SelectionAlignment = HorizontalAlignment.Center
            rtbEstrofe.DeselectAll()
        End If
    End Sub
    Private Sub Transferir()
        Dim I As Integer = lstHinos.SelectedIndex
        Harpa = False
        If rbLigado.Checked = True Then Harpa = True
        AtualizaApresentacao()
    End Sub

    Private Sub trkZoom_Scroll(sender As Object, e As EventArgs) Handles trkZoom.Scroll
        Dim Val As Integer = trkZoom.Value
        lblZoom.Text = Val
        ZoomTHarpa = Val
        ZoomHarpa = Val
        If Harpa Then AtualizaApresentacao() 'o tamanho muda na projeção na hora
    End Sub

    Private Sub txtLocalizar_TextChanged(sender As Object, e As EventArgs) Handles txtLocalizar.TextChanged
        Dim LC As Long = 0
        Dim T As String = txtLocalizar.Text
        lblOcorrencias.Text = "0"
        If lstResultados.Items.Count > 0 Then lstResultados.Items.Clear()
        If Len(T) >= 3 Then
            For L As Long = 0 To RegHarpa.Rows.Count - 1
                For C As Integer = 1 To 13 'título (1) + estrofes (2 a 13)
                    If InStr(RegHarpa.Rows(L).Item(C).ToString, T, CompareMethod.Text) > 0 Then
                        lstResultados.Items.Add(RegHarpa.Rows(L).Item(0) & " - " & RegHarpa.Rows(L).Item(1) & ";" & RegHarpa.Rows(L).Item(C))
                        LC += 1
                        Exit For
                    End If
                Next
            Next
        End If
        lblOcorrencias.Text = LC
    End Sub

    Private Sub lstResultados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstResultados.SelectedIndexChanged
        Dim Texto As String = lstResultados.Text
        Dim Ref() As String
        Dim Selecao As String
        Ref = Texto.Split(";")
        Selecao = Ref(0).ToString
        For I As Integer = 0 To ListaHarpa.Rows.Count - 1
            If Selecao = ListaHarpa.Rows(I).Item(1) Then lstHinos.SelectedIndex = I
        Next
    End Sub


End Class