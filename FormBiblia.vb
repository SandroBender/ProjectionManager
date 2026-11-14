Imports System.Security.Cryptography

Public Class FormBiblia
    Private Sub FormBiblia_Load(sender As Object, e As EventArgs) Handles Me.Load
        ConectarDados()
        CarregarZoom()
        DesconectarDados()
        Dim Val As Integer = RegZoom.Rows(0).Item("TextoBiblia")
        Label10.Text = Val
        TrackBar1.Value = Val
        FormApresentar.RichTextBox2.Font = New Font("Calibri", Val, style:=1)
        If ListBox1.DisplayMember = "" Then
            CarregarListaLivros()
            RadioButton3.Checked = True
            ListBox1.DataSource = ListaLivros
            ListBox1.ValueMember = "Indice"
            ListBox1.DisplayMember = "Livro"
        End If
        For i As Integer = 0 To ListaLivros.Rows.Count - 1
            ComboBox1.Items.Add(ListaLivros.Rows(i).Item(1))
        Next
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Dim Val As Integer = TrackBar1.Value
        Label10.Text = Val
        ZoomTBiblia = Val
        FormApresentar.RichTextBox2.Font = New Font("Calibri", Val, style:=1)
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged 'selecionar livro
        Dim I As Integer
        If ListBox1.DisplayMember <> "" Then
            I = ListBox1.SelectedIndex
            Label6.Text = ListaLivros.Rows(I).Item(1)
            Livro = Label6.Text
            RichTextBox1.Clear()
            Label8.Text = "0"
            Label7.Text = "0"
            TextoBibliaCondensado = ""
            LivroCap()
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged 'Versão ACF
        VersaoBiblia = RadioButton3.Text
        TextoBibliaCondensado = ""
        If Label8.Text <> "0" Then Icap = CInt(Label8.Text) - 1
        If Label7.Text <> "0" Then Iver = CInt(Label7.Text) - 1
        CarregarBibliaCompleta()
        LivroCap()
        If Icap > 0 Then ListBox2.SelectedIndex = Icap
        If Iver > 0 Then ListBox3.SelectedIndex = Iver
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged 'Versão NVI
        VersaoBiblia = RadioButton4.Text
        TextoBibliaCondensado = ""
        If Label8.Text <> "0" Then Icap = CInt(Label8.Text) - 1
        If Label7.Text <> "0" Then Iver = CInt(Label7.Text) - 1
        CarregarBibliaCompleta()
        LivroCap()
        If Icap > 0 Then ListBox2.SelectedIndex = Icap
        If Iver > 0 Then ListBox3.SelectedIndex = Iver
    End Sub

    Private Sub LivroCap()
        ListBox2.DataSource = Nothing
        ListBox3.DataSource = Nothing
        If Mid(Label6.Text, 1, 5) <> "Livro" And Mid(Label6.Text, 1, 5) <> "-----" Then
            CarregarLivro(Lv:=Label6.Text)
            ListBox2.DataSource = ListaCap
            ListBox2.ValueMember = "Indice"
            ListBox2.DisplayMember = "Indice"
        End If
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged 'Selecionar capítulo
        ListBox3.DataSource = Nothing
        Dim I As Integer = ListBox2.SelectedIndex
        If I > -1 Then
            Label8.Text = ListaCap.Rows(I).Item(0)
            RichTextBox1.Clear()
            CarregarVer(Cap:=I + 1)
            ListBox3.DataSource = ListaVer
            ListBox3.ValueMember = "Indice"
            ListBox3.DisplayMember = "Indice"
        End If
    End Sub

    Private Sub ListBox3_Click(sender As Object, e As EventArgs) Handles ListBox3.Click 'Selecionar versículo(adicionar no histórico)
        If ListBox3.SelectedIndex > -1 Then
            ResultadoVer(Cap:=ListBox2.SelectedIndex + 1, Ver:=ListBox3.SelectedIndex + 1)
            ListBox5.Items.Add(ListBox1.GetItemText(ListBox1.Text) & ";" & ListBox2.SelectedIndex + 1 & ";" & ListBox3.SelectedIndex + 1 & ";" & ResultVers)
            If ResultReferencia <> "" Then
                Dim Ref() As String
                Ref = ResultReferencia.Split("|")
                For I As Integer = 0 To Ref.Count - 1
                    ListBox6.Items.Add(Ref(I).ToString)
                Next
            End If
        End If
    End Sub

    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox3.SelectedIndexChanged 'Selecionar versículo
        Resultado()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged 'Desligado
        RadioButton1.BackColor = Color.Transparent
        RadioButton2.BackColor = Color.Transparent
        Button1.BackColor = Color.FromArgb(204, 200, 215)
        Button2.BackColor = Color.FromArgb(204, 200, 215)
        If RadioButton1.Checked = True Then
            RadioButton1.BackColor = Color.AliceBlue
            FormPrincipal.CheckBox3.Checked = False
        End If
        Transferir()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged 'Ligado
        RadioButton1.BackColor = Color.Transparent
        RadioButton2.BackColor = Color.Transparent
        Button1.BackColor = Color.FromArgb(204, 200, 215)
        Button2.BackColor = Color.FromArgb(204, 200, 215)
        If RadioButton2.Checked = True Then
            RadioButton2.BackColor = Color.AliceBlue
            Button1.BackColor = Color.LightSteelBlue
            Button2.BackColor = Color.LightSteelBlue
            FormPrincipal.CheckBox3.Checked = True
        End If
        Transferir()
    End Sub

    Private Sub Transferir()
        Dim I As Integer = ListBox1.SelectedIndex
        Biblia = False
        If RadioButton2.Checked = True Then
            Biblia = True
            If FormPrincipal.RadioButton1.Checked = True Then
                FormPrincipal.RichTextBox2.Visible = True
                FormPrincipal.RichTextBox2.BringToFront()
                'FormPrincipal.RichTextBox2.Parent = FormPrincipal.PictureBox5
            End If
        ElseIf FormPrincipal.RadioButton1.Checked = True Then
            FormPrincipal.RichTextBox2.Visible = False
        End If
        AtualizaApresentacao()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click 'Retroceder
        Dim I As Integer = ListBox3.SelectedIndex
        Aad = False
        If I > 0 Then
            I += -1
            ListBox3.SelectedIndex = I 'Aciona resultado
            TextBox2.Text = ""
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click 'Avançar
        Dim I As Integer = ListBox3.SelectedIndex
        Dim IT As Integer = ListBox3.Items.Count - 1
        Aad = False
        If I < IT Then
            I += 1
            ListBox3.SelectedIndex = I 'Aciona resultado
            TextBox2.Text = ""
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click 'Avançar Adicionando
        Dim I As Integer = ListBox3.SelectedIndex
        Dim IT As Integer = ListBox3.Items.Count - 1
        Aad = True
        If I < IT Then
            I += 1
            ListBox3.SelectedIndex = I 'Aciona resultado
            TextBox2.Text = ""
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click 'Adicionar
        Dim AdicionarTexto As String = ""
        If TabControl1.SelectedIndex = 0 And ListBox4.Text <> "" Then AdicionarTexto = ListBox4.Text
        If TabControl1.SelectedIndex = 2 And ListBox5.Text <> "" Then AdicionarTexto = ListBox5.Text
        Dim Ref() As String
        Ref = AdicionarTexto.Split(";")
        If Ref.Length < 4 Then Exit Sub 'nada selecionado ou formato inesperado
        Dim Livro As String = Ref(0).ToString
        Dim Cap As Integer = Ref(1).ToString
        Dim Ver As Integer = Ref(2).ToString
        Dim TextoVersiculo As String = String.Join(";", Ref, 3, Ref.Length - 3) 'o texto pode conter ";"
        TextoBibliaCondensado = TextoBibliaCondensado & "[" & Livro & " - " & Cap & ":" & Ver & "] " & TextoVersiculo
        RichTextBox1.Text = TextoBibliaCondensado
        Aad = True
        Transferir()
        Aad = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click 'Substituir
        SubstituirResultado()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click 'Ativar localizar
        If TextBox2.Visible = False Then
            TabControl1.Visible = True
            TextBox2.Visible = True
            TableLayoutPanel3.Visible = True
        Else
            TabControl1.Visible = False
            TextBox2.Visible = False
            TableLayoutPanel3.Visible = False
        End If
        FormPrincipal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged 'Localizar - Na bíblia
        If RadioButton5.Checked = True Then
            TextBox1.Visible = True
            'TextBox1.Text = ""
            LimparPesquisa()
            ComboBox1.Visible = False
        End If
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged 'Localizar - No assunto
        If RadioButton6.Checked = True Then
            TextBox1.Visible = True
            'TextBox1.Text = ""
            LimparPesquisa()
            ComboBox1.Visible = False
        End If
    End Sub

    Private Sub RadioButton7_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton7.CheckedChanged 'Localizar - Assuntos por livro
        If RadioButton7.Checked = True Then
            TextBox1.Text = ""
            LimparPesquisa()
            TextBox1.Visible = False
            ComboBox1.Visible = True
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged 'Localizar texto
        Dim LC As Long = 0
        Dim T As String = TextBox1.Text
        LimparPesquisa()
        If Len(T) >= 3 Then
            If RadioButton5.Checked = True Then 'Na bíblia
                For L As Long = 0 To RegBiblia.Rows.Count - 1
                    If InStr(RegBiblia.Rows(L).Item(4), T, CompareMethod.Text) > 0 Then
                        ListBox4.Items.Add(RegBiblia.Rows(L).Item(1) & ";" & RegBiblia.Rows(L).Item(2) & ";" & RegBiblia.Rows(L).Item(3) & ";" & RegBiblia.Rows(L).Item(4))
                        LC += 1
                    End If
                Next
            End If
            If RadioButton6.Checked = True Then 'No assunto
                For L As Long = 0 To RegBiblia.Rows.Count - 1
                    If Not IsDBNull(RegBiblia.Rows(L).Item(5)) Then
                        If InStr(RegBiblia.Rows(L).Item(5), T, CompareMethod.Text) > 0 Then
                            ListBox4.Items.Add(RegBiblia.Rows(L).Item(1) & ";" & RegBiblia.Rows(L).Item(2) & ";" & RegBiblia.Rows(L).Item(3) & ";" & RegBiblia.Rows(L).Item(5))
                            LC += 1
                        End If
                    End If
                Next
            End If
        End If
        Label12.Text = LC
        If LC > 0 Then
            Button3.Visible = True
            Button4.Visible = True
            Button5.Visible = True
        End If
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged 'Seleção livro para assunto
        Dim LC As Long = 0
        Dim T As String = ComboBox1.Text
        LimparPesquisa()
        If Len(T) >= 3 Then
            For L As Long = 0 To RegBiblia.Rows.Count - 1
                If Not IsDBNull(RegBiblia.Rows(L).Item(5)) Then
                    If T = RegBiblia.Rows(L).Item(1) Then
                        ListBox4.Items.Add(RegBiblia.Rows(L).Item(1) & ";" & RegBiblia.Rows(L).Item(2) & ";" & RegBiblia.Rows(L).Item(3) & ";" & RegBiblia.Rows(L).Item(5))
                        LC += 1
                    End If
                End If
            Next
        End If
        Label12.Text = LC
        If LC > 0 Then
            Button3.Visible = True
            Button4.Visible = True
            Button5.Visible = True
        End If
    End Sub

    Private Sub LimparPesquisa()
        Label12.Text = "0"
        TextBox2.Text = ""
        Button3.Visible = False
        Button4.Visible = False
        Button5.Visible = False
        If ListBox4.Items.Count > 0 Then ListBox4.Items.Clear()
    End Sub

    Private Sub TabControl1_Click(sender As Object, e As EventArgs) Handles TabControl1.Click 'Pequisa/Histórico
        Button3.Visible = False
        Button4.Visible = False
        Button5.Visible = False
        If (TabControl1.SelectedIndex = 0 And ListBox4.Text <> "") Or (TabControl1.SelectedIndex = 2 And ListBox5.Text <> "") Then
            Button3.Visible = True
            Button4.Visible = True
            Button5.Visible = True
        End If
    End Sub


    Private Sub ListBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox4.SelectedIndexChanged 'Selecionar texto localizado
        TextBox2.Text = ListBox4.Text
        Button3.Visible = True
        Button4.Visible = True
        Button5.Visible = True
    End Sub

    Private Sub ListBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox5.SelectedIndexChanged 'Selecionar texto do histórico
        TextBox2.Text = ListBox5.Text
        Button3.Visible = True
        Button4.Visible = True
        Button5.Visible = True
    End Sub

    Private Sub ListBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox6.SelectedIndexChanged 'Selecionar Referencia de versículo
        TextBox2.Text = ListBox6.Text
        Button3.Visible = True
        Button4.Visible = True
        Button5.Visible = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click 'Limpar histórico
        If TabControl1.SelectedIndex = 0 Then
            TextBox1.Text = ""
        Else
            ListBox5.Items.Clear()
        End If
        TextBox2.Text = ""
        Button3.Visible = False
        Button4.Visible = False
        Button5.Visible = False
    End Sub

    Private Sub Resultado()
        Dim V As Integer = ListBox3.SelectedIndex
        Dim VI As Integer = V + 2
        Dim VF As Integer = ListBox3.Items.Count
        Dim C As Integer = ListBox2.SelectedIndex
        If V > -1 Then
            Label7.Text = ListaVer.Rows(V).Item(0)
            RichTextBox1.Clear()
            RichTextBox2.Clear()
            RichTextBox3.Clear()
            ResultadoVer(Cap:=C + 1, Ver:=V + 1)
            TextoBiblia = vbTab & vbTab & ResultRef1 & " [" & VersaoBiblia & "]" & vbLf & vbLf & ResultVers
            If Aad = False Then
                RichTextBox1.Text = TextoBiblia
                TextoBibliaCondensado = "[" & ResultRef1 & "] " & ResultVers
            Else
                RichTextBox1.Text = TextoBibliaCondensado & "[" & ResultRef1 & "] " & ResultVers
                TextoBibliaCondensado = TextoBibliaCondensado & "[" & ResultRef1 & "] " & ResultVers
            End If
            If V > 0 Then
                TextoBibliaAnterior = ""
                For I As Integer = 1 To V
                    ResultadoVer(Cap:=C + 1, Ver:=I)
                    TextoBibliaAnterior = TextoBibliaAnterior & " [ " & I & " ] " & ResultVers
                    RichTextBox2.Text = TextoBibliaAnterior
                Next
            End If
            If VI <= VF Then
                TextoBibliaPosterior = ""
                For I As Integer = VI To VF
                    ResultadoVer(Cap:=C + 1, Ver:=I)
                    TextoBibliaPosterior = TextoBibliaPosterior & " [ " & I & " ] " & ResultVers
                    RichTextBox3.Text = TextoBibliaPosterior
                Next
            End If
        End If
        Transferir()
        Aad = False
    End Sub

    Private Sub SubstituirResultado()
        Dim SubstituirTexto As String
        If TabControl1.SelectedIndex = 0 And ListBox4.Text <> "" Then SubstituirTexto = ListBox4.Text 'localizar
        If TabControl1.SelectedIndex = 2 And ListBox5.Text <> "" Then SubstituirTexto = ListBox5.Text 'histórico
        If TabControl1.SelectedIndex = 1 And ListBox6.Text <> "" Then SubstituirTexto = ListBox6.Text 'referencia bíblica
        Dim Ref() As String
        Dim Livro As String
        Dim Cap As Integer
        Dim Ver As Integer
        Ref = SubstituirTexto.Split(";")
        Livro = Ref(0).ToString
        Cap = Ref(1).ToString
        Ver = Ref(2).ToString
        For I As Integer = 0 To ListaLivros.Rows.Count - 1
            If Livro = ListaLivros.Rows(I).Item(1) Then ListBox1.SelectedIndex = I
        Next
        For I As Integer = 0 To ListaCap.Rows.Count - 1
            If Cap = ListaCap.Rows(I).Item(0) Then ListBox2.SelectedIndex = I
        Next
        For I As Integer = 0 To ListaVer.Rows.Count - 1
            If Ver = ListaVer.Rows(I).Item(0) Then ListBox3.SelectedIndex = I 'Aciona Resultado
        Next
        TextBox2.Text = SubstituirTexto
        Button3.Visible = True
        Button4.Visible = True
        Button5.Visible = True
    End Sub

End Class