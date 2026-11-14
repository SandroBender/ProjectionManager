Imports System.IO
Imports AxWMPLib
Public Class FormHarpa
    Dim PastaAudios As String = LocalSystem & "\ProjectionManager\AUDIOS\Harpa"
    Dim EE As Integer 'Encremento de estrofe
    Private Sub FormHarpa_Load(sender As Object, e As EventArgs) Handles Me.Load
        ConectarDados()
        CarregarZoom()
        DesconectarDados()
        Label7.Text = PastaAudios
        Dim Val As Integer = RegZoom.Rows(0).Item("TextoHarpa")
        Label10.Text = Val
        TrackBar1.Value = Val
        FormApresentar.RichTextBox1.Font = New Font("Calibri", Val, style:=1)
        If ListBox1.DisplayMember = "" Then
            ConectarHarpa()
            CarregarHarpa()
            DesconectarHarpa()
            ListBox1.DataSource = ListaHarpa
            ListBox1.ValueMember = "Indice"
            ListBox1.DisplayMember = "Titulo"
        End If

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim OFds As New FolderBrowserDialog With {.ShowNewFolderButton = False, .RootFolder = Environment.SpecialFolder.MyComputer}
        If OFds.ShowDialog = DialogResult.OK Then Label7.Text = OFds.SelectedPath
    End Sub

    Private Sub ListBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim TE As Integer
        Dim I As Integer
        Dim C As Integer
        If ListBox1.DisplayMember <> "" Then
            I = ListBox1.SelectedIndex
            For C = 2 To 13
                If RegHarpa.Rows(I).Item(C) <> "-" Then TE += 1
            Next
            Label3.Text = TE
            RichTextBox1.Clear()
            TextoHarpa = vbTab & StrConv(ListaHarpa.Rows(I).Item(1), vbUpperCase)
            Label5.Text = 0
            Transferir()
            Label14.Text = "Não Localizado"
            If AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPlaying Or AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPaused Then
                AxWindowsMediaPlayer1.Ctlcontrols.stop()
            End If
            AxWindowsMediaPlayer1.Visible = False
            LocalizarArquivo(I:=I)
        End If
    End Sub

    Private Sub RadioButton3_Click(sender As Object, e As EventArgs) Handles RadioButton3.Click

    End Sub

    Private Sub RadioButton4_Click(sender As Object, e As EventArgs) Handles RadioButton4.Click

    End Sub

    Private Sub LocalizarArquivo(I As String)
        Try
            Dim Pasta As String = Label7.Text
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
                        If (RadioButton3.Checked = True And InStr(Nome, "playback", CompareMethod.Text) = 0) Or (RadioButton4.Checked = True And InStr(Nome, "playback", CompareMethod.Text) > 0) Then 'voz
                            Label14.Text = Nome
                            If InStr(Nome, "playback", CompareMethod.Text) = 0 Then
                                Label14.BackColor = Color.LightCyan
                            Else
                                Label14.BackColor = Color.Moccasin
                            End If
                            AxWindowsMediaPlayer1.Visible = True
                            AxWindowsMediaPlayer1.URL = Arq
                            AxWindowsMediaPlayer1.Ctlcontrols.stop()
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            Label14.Text = "Erro ao Localizar arquivo"
        End Try
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged 'desativado
        RadioButton1.BackColor = Color.Transparent
        Button1.BackColor = Color.FromArgb(204, 200, 215)
        Button2.BackColor = Color.FromArgb(204, 200, 215)
        If RadioButton1.Checked = True Then
            RadioButton1.BackColor = Color.AliceBlue
            FormPrincipal.CheckBox2.Checked = False
        End If
        Transferir()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged 'ativado
        RadioButton2.BackColor = Color.Transparent
        Button1.BackColor = Color.FromArgb(204, 200, 215)
        Button2.BackColor = Color.FromArgb(204, 200, 215)
        If RadioButton2.Checked = True Then
            RadioButton2.BackColor = Color.AliceBlue
            Button1.BackColor = Color.LightSteelBlue
            Button2.BackColor = Color.LightSteelBlue
            FormPrincipal.CheckBox2.Checked = True
        End If
        Transferir()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click  'Retroceder
        EE = -1
        Estrofes()
        Transferir()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click 'avançar
        EE = 1
        Estrofes()
        Transferir()
    End Sub

    Private Sub Estrofes()
        Dim I As Integer
        Dim TE As Integer = Label3.Text
        Dim IE As Integer = Label5.Text
        I = ListBox1.SelectedIndex
        IE = IE + EE
        If IE > 0 And IE <= TE Then
            If CheckBox1.Checked = True Then
                RichTextBox1.Text = StrConv(RegHarpa.Rows(I).Item(IE + 1), vbUpperCase)
                TextoHarpa = vbTab & StrConv(ListaHarpa.Rows(I).Item(1), vbUpperCase) & vbLf & vbLf & RichTextBox1.Text
            Else
                RichTextBox1.Text = StrConv(RegHarpa.Rows(I).Item(IE + 1), vbUpperCase)
                TextoHarpa = StrConv(RegHarpa.Rows(I).Item(IE + 1), vbUpperCase)
            End If
            Label5.Text = IE
            RichTextBox1.SelectAll()
            RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
            RichTextBox1.DeselectAll()
        End If
    End Sub
    Private Sub Transferir()
        Dim I As Integer = ListBox1.SelectedIndex
        Harpa = False
        If RadioButton2.Checked = True Then
            Harpa = True
            If FormPrincipal.RadioButton1.Checked = True Then FormPrincipal.RichTextBox1.Visible = True
        ElseIf FormPrincipal.RadioButton1.Checked = True Then
            FormPrincipal.RichTextBox1.Visible = False
        End If
        AtualizaApresentacao()
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Dim Val As Integer = TrackBar1.Value
        Label10.Text = Val
        ZoomTHarpa = Val
        FormApresentar.RichTextBox1.Font = New Font("Calibri", Val, style:=1)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim LC As Long = 0
        Dim T As String = TextBox1.Text
        Label12.Text = "0"
        If ListBox2.Items.Count > 0 Then ListBox2.Items.Clear()
        If Len(T) >= 3 Then
            For L As Long = 0 To RegHarpa.Rows.Count - 1
                For C As Integer = 1 To 13 'título (1) + estrofes (2 a 13)
                    If InStr(RegHarpa.Rows(L).Item(C).ToString, T, CompareMethod.Text) > 0 Then
                        ListBox2.Items.Add(RegHarpa.Rows(L).Item(0) & " - " & RegHarpa.Rows(L).Item(1) & ";" & RegHarpa.Rows(L).Item(C))
                        LC += 1
                        Exit For
                    End If
                Next
            Next
        End If
        Label12.Text = LC
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        Dim Texto As String = ListBox2.Text
        Dim Ref() As String
        Dim Selecao As String
        Ref = Texto.Split(";")
        Selecao = Ref(0).ToString
        For I As Integer = 0 To ListaHarpa.Rows.Count - 1
            If Selecao = ListaHarpa.Rows(I).Item(1) Then ListBox1.SelectedIndex = I
        Next
    End Sub


End Class