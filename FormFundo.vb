Imports System.IO
Public Class FormFundo
    Dim PastaPadrao As String = LocalSystem & "\ProjectionManager\IMAGENS"
    Dim PMImagens As String() = {}
    Dim PCImagens As String = My.Computer.FileSystem.SpecialDirectories.MyPictures
    Dim CamSelect As String
    Dim Alin As ContentAlignment = ContentAlignment.TopLeft
    Dim ValPerc As Integer 'Valor % de acrescimo da fonte

    Private Sub FormFundo_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim I As Integer
        Dim P As Integer
        Dim Pasta As String
        If Directory.Exists(PastaPadrao) Then
            PMImagens = Directory.GetDirectories(PastaPadrao)
        Else
            MsgBox("Pasta de imagens não encontrada: " & PastaPadrao, vbExclamation, "Imagens")
        End If
        For I = 0 To PMImagens.Count - 1
            P = InStrRev(PMImagens(I), "\", -1, vbTextCompare)
            Pasta = Mid(PMImagens(I), P + 1, 50)
            ComboBox1.Items.Add(Pasta)
        Next
        Label2.Size = New Point(403, 31)
        RadioButton1.Checked = True
        PictureBox1.AllowDrop = True
        ConectarDados()
        CarregarImagens()
        CarregarTextos()
        CarregarZoom()
        DesconectarDados()
        Try
            PictureBox1.Image = CarregarImagem(RegImagens.Rows(0).Item("CamImagem"))
            ImageFundo = RegImagens.Rows(0).Item("CamImagem")
            Label1.Text = RegImagens.Rows(0).Item("CamImagem")
        Catch ex As Exception
            Label1.Text = "Não encontrada"
        End Try
        Try
            Label18.Text = RegZoom.Rows(0).Item("TextoFundo")
            TrackBar1.Value = RegZoom.Rows(0).Item("TextoFundo")

        Catch ex As Exception
            Label18.Text = "16"
        End Try
        Label14.Parent = PictureBox1 'CRIAR transparencia dos textos
        Label15.Parent = PictureBox1
        Label16.Parent = PictureBox1
        Label13.Parent = PictureBox1
        'Label4.Location = New Point(10, 10) 'POSIÇÃO
        'Label15.Location = New Point(10, 40)
        'Label16.Location = New Point(10, 70)
    End Sub
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged 'Imagens P. Manager
        If RadioButton1.Checked = True Then
            WebBrowser1.Stop()
            ComboBox1.Visible = True
            'Button12.Visible = False
            Label6.Text = "0"
        End If
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged 'Minhas Imagens
        If RadioButton2.Checked = True Then
            ComboBox1.Visible = False
            'Button12.Visible = True
            WebBrowser1.Url = New Uri(PCImagens)
            CamSelect = PCImagens
            Label6.Text = "0"
        End If
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim I As Integer = ComboBox1.SelectedIndex
        Dim Cam As String = PMImagens(I)
        WebBrowser1.Url = New Uri(Cam)
        CamSelect = Cam
    End Sub

    Private Sub PictureBox1_DragEnter(sender As Object, e As DragEventArgs) Handles PictureBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
    Private Sub PictureBox1_DragDrop(sender As Object, e As DragEventArgs) Handles PictureBox1.DragDrop
        Dim Ext As String
        Dim P As Integer
        Try
            ImageFundo = e.Data.GetData(DataFormats.FileDrop)(0)
            If Not File.Exists(ImageFundo) Then Exit Sub
            Ext = Mid(ImageFundo, Len(ImageFundo) - 3, 5)
            P = InStrRev(ImageFundo, "\", -1, CompareMethod.Text)
            CamSelect = Mid(ImageFundo, 1, P - 1)
            'If Ext <> ".jpg" And Ext <> "jpeg" And Ext <> ".png" And Ext <> ".bmp" Then Exit Sub
            PictureBox1.Image = CarregarImagem(ImageFundo)
            Label1.Text = ImageFundo
            Transferir()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Arrastar Imagem")
        End Try
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click 'Nova imagem
        If CamSelect = Nothing Then
            MsgBox("Arraste a 1° Imagem pra continuar.", vbCritical, "Alterar Imagem")
        Else
            ProxArq(Pasta:=CamSelect)
        End If
    End Sub
    Private Sub ProxArq(Pasta As String)
        Dim TA As Integer 'total arquivos
        Dim IA As Integer = Label6.Text 'indice atual
        Dim IP As Integer 'Indice próximo
        Dim IC As Integer = 0 'indice contagem
        Dim Ext As String = "*.png,*.jpg,*.jpeg,*.bmp,*.JPG,*.JPEG,*.PNG"
        Dim Arquivos As String() = Directory.GetFiles(Pasta, "*.*")
        IP = IA + 1
        Array.Sort(Arquivos)
        For Each Arq As String In Arquivos
            If Ext.Contains(Path.GetExtension(Arq)) Then TA += 1
        Next
        For Each Arq As String In Arquivos
            If Ext.Contains(Path.GetExtension(Arq)) Then
                If IP = TA Then
                    Label6.Text = "0"
                    PictureBox1.Image = CarregarImagem(Arq)
                    ImageFundo = Arq
                    Label1.Text = Arq
                    Transferir()
                    Exit For
                End If
                'If IA = IC Then IP = IC + 1 'indice anterior encontrado
                If IP = IC Then 'próximo indice encontrado
                    PictureBox1.Image = CarregarImagem(Arq)
                    ImageFundo = Arq
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
        FormPrincipal.CheckBox1.Checked = False
        If RadioButton3.Checked = True Then
            RadioButton3.BackColor = Color.AliceBlue
            RadioButton4.BackColor = Color.Transparent
            FormPrincipal.CheckBox1.Checked = False
        End If
        Transferir()
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged 'IMAGEM ATIVADA
        RadioButton3.BackColor = Color.Transparent
        RadioButton4.BackColor = Color.Transparent
        FormPrincipal.CheckBox1.Checked = False
        If RadioButton4.Checked = True Then
            RadioButton4.BackColor = Color.AliceBlue
            RadioButton3.BackColor = Color.Transparent
            FormPrincipal.CheckBox1.Checked = True
        End If
        Transferir()
    End Sub

    Private Sub Transferir()
        ImageFundo = Label1.Text
        If RadioButton4.Checked = True Then
            ImageF = True
            If ImageFundo = "Não encontrada" Then ImageF = False
            If FormPrincipal.RadioButton1.Checked = True Then FormPrincipal.PictureBox5.Image = PictureBox1.Image
            FormPrincipal.PictureBox5.SizeMode = PictureBoxSizeMode.StretchImage
        Else
            ImageF = False
            If FormPrincipal.RadioButton1.Checked = True Then FormPrincipal.PictureBox5.Image = Nothing
        End If
        AtualizaApresentacao()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click 'Voltar
        WebBrowser1.GoBack()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click 'Editar Título
        Dim I As Long = 0
        IT = 0
        TabControl1.SelectedIndex = 1
        Label3.Text = CheckBox1.Text 'tipo
        TextBox9.Text = TextBox1.Text 'texto
        TextBox10.Text = TextBox5.Text 'indice
        If TextBox10.Text = "" Then
            TextBox10.Text = "N"
        Else
            I = TextBox10.Text
        End If
        CarregarTipoTexto(Tipo:=Label3.Text, I:=I)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click 'Editar Subtitulo
        Dim I As Long = 0
        IT = 1
        TabControl1.SelectedIndex = 1
        Label3.Text = CheckBox2.Text 'tipo
        TextBox9.Text = TextBox2.Text 'texto
        TextBox10.Text = TextBox6.Text 'indice
        If TextBox10.Text = "" Then
            TextBox10.Text = "N"
        Else
            I = TextBox10.Text
        End If
        CarregarTipoTexto(Tipo:=Label3.Text, I:=I)
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click 'Editar Corpo de texto
        Dim I As Long = 0
        IT = 2
        TabControl1.SelectedIndex = 1
        Label3.Text = CheckBox3.Text 'tipo
        TextBox9.Text = TextBox3.Text 'texto
        TextBox10.Text = TextBox7.Text 'indice
        If TextBox10.Text = "" Then
            TextBox10.Text = "N"
        Else
            I = TextBox10.Text
        End If
        CarregarTipoTexto(Tipo:=Label3.Text, I:=I)
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click 'Editar Rodapé
        Dim I As Long = 0
        IT = 3
        TabControl1.SelectedIndex = 1
        Label3.Text = CheckBox4.Text 'tipo
        TextBox9.Text = TextBox4.Text 'texto
        TextBox10.Text = TextBox8.Text 'indice
        If TextBox10.Text = "" Then
            TextBox10.Text = "N"
        Else
            I = TextBox10.Text
        End If
        CarregarTipoTexto(Tipo:=Label3.Text, I:=I)
    End Sub
    Public Sub CarregarTipoTexto(Tipo As String, I As Long) 'Completa e lista resumida
        Dim Column As DataColumn
        Dim Row As DataRow
        If RegTipoTexto IsNot Nothing Then RegTipoTexto.Clear()
        RegTipoTexto = New DataTable
        For C As Integer = 0 To RegTextos.Columns.Count - 1
            If C = 0 Then
                Column = New DataColumn With {.DataType = Type.GetType("System.Int32"), .ColumnName = RegTextos.Columns(C).ColumnName, .ReadOnly = True, .Unique = True}
                RegTipoTexto.Columns.Add(Column)
            Else
                Column = New DataColumn With {.DataType = Type.GetType("System.String"), .ColumnName = RegTextos.Columns(C).ColumnName, .ReadOnly = False, .Unique = False}
                RegTipoTexto.Columns.Add(Column)
            End If
        Next
        For L As Long = 0 To RegTextos.Rows.Count - 1
            If Tipo = RegTextos.Rows(L).Item(2) Then
                Row = RegTipoTexto.NewRow
                Row("ID") = RegTextos.Rows(L).Item(0) 'ID
                Row("Texto") = RegTextos.Rows(L).Item(1) 'Texto
                Row("Tipo") = RegTextos.Rows(L).Item(2) 'Tipo
                Row("Alinhamento") = RegTextos.Rows(L).Item(3) 'Alinhamento
                Row("CorPreenchim") = RegTextos.Rows(L).Item(4) 'Preenchimento
                Row("FonteNome") = RegTextos.Rows(L).Item(5) 'Fonte nome
                Row("FonteTamanho") = RegTextos.Rows(L).Item(6) 'Fonte Tamanho
                Row("FonteEstilo") = RegTextos.Rows(L).Item(7) 'Fonte Estilo
                Row("FonteCor") = RegTextos.Rows(L).Item(8) 'Fonte cor
                RegTipoTexto.Rows.Add(Row)
            End If
        Next
        DataGridView1.DataSource = RegTipoTexto
        If I = 0 Then 'Fonte Defauld
            Label4.Text = "Left" 'Alinhamento
            Label10.Text = "0" 'Preenchimento
            Label5.Text = "Calibri" 'Fonte nome
            Label8.Text = "20" 'Fonte tamanho
            Label7.Text = "0" 'Fonte estilo
            Label9.Text = "0" 'Fonte cor
        Else
            For L As Long = 0 To RegTextos.Rows.Count - 1
                If I = RegTextos.Rows(L).Item(0) Then
                    Label4.Text = RegTextos.Rows(L).Item(3) 'Alinhamento
                    Label10.Text = RegTextos.Rows(L).Item(4) 'Preenchimento
                    Label5.Text = RegTextos.Rows(L).Item(5) 'Fonte nome
                    Label8.Text = RegTextos.Rows(L).Item(6) 'Fonte Tamanho
                    Label7.Text = RegTextos.Rows(L).Item(7) 'Fonte Estilo
                    Label9.Text = RegTextos.Rows(L).Item(8) 'Fonte cor
                End If
            Next
        End If
        TextBox9.Select()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click 'Alinhamento superior esquerdo
        Label4.TextAlign = ContentAlignment.TopLeft
        Alinhar()
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click 'Alinhamento superior central
        Label4.TextAlign = ContentAlignment.TopCenter
        Alinhar()
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click 'Alinhamento superior direito
        Label4.TextAlign = ContentAlignment.TopRight
        Alinhar()
    End Sub
    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click 'alinhamento meio esquerdo
        Label4.TextAlign = ContentAlignment.MiddleLeft
        Alinhar()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click 'alinhamento meio central
        Label4.TextAlign = ContentAlignment.MiddleCenter
        Alinhar()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click 'alinhamento meio direito
        Label4.TextAlign = ContentAlignment.MiddleRight
        Alinhar()
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click 'alinhamento inferior esquerdo
        Label4.TextAlign = ContentAlignment.BottomLeft
        Alinhar()
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click 'alinhamento inferior central
        Label4.TextAlign = ContentAlignment.BottomCenter
        Alinhar()
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click 'alinhamento inferior direito
        Label4.TextAlign = ContentAlignment.BottomRight
        Alinhar()
    End Sub
    Private Sub Alinhar()
        Dim BA() As Button = {Button5, Button6, Button7, Button15, Button16, Button17, Button18, Button19, Button20}
        Dim IA As String() = {"TopLeft", "TopCenter", "TopRight", "MiddleLeft", "MiddleCenter", "MiddleRight", "BottomLeft", "BottomCenter", "BottomRight"}
        Dim Texto() As Label = {Label14, Label15, Label16, Label13}
        Dim TextoPrinc() As Label = {FormPrincipal.Label3, FormPrincipal.Label4, FormPrincipal.Label5, FormPrincipal.Label6}
        Dim TextoApres() As Label = {FormApresentar.Label1, FormApresentar.Label2, FormApresentar.Label3, FormApresentar.Label4}
        Alin = Label4.TextAlign
        Label4.Text = Alin.ToString
        For I As Integer = 0 To 8
            BA(I).BackColor = Color.Lavender
            If Alin.ToString = IA(I).ToString Then BA(I).BackColor = Color.SteelBlue
        Next
        Texto(IT).TextAlign = Alin
        Alinham(IT) = Alin
        If FormPrincipal.RadioButton1.Checked = True Then
            TextoPrinc(IT).TextAlign = Alin
            TextoApres(IT).TextAlign = Alin
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click 'Cor de fundo
        Dim Texto() As Label = {Label14, Label15, Label16, Label13}
        Dim TextoPrinc() As Label = {FormPrincipal.Label3, FormPrincipal.Label4, FormPrincipal.Label5, FormPrincipal.Label6}
        Dim TextoApres() As Label = {FormApresentar.Label1, FormApresentar.Label2, FormApresentar.Label3, FormApresentar.Label4}
        Dim dlg As ColorDialog = New ColorDialog()
        dlg.AllowFullOpen = True
        dlg.ShowHelp = True
        dlg.Color = Texto(IT).BackColor
        If dlg.ShowDialog() <> DialogResult.Cancel Then
            Label10.Text = dlg.Color.ToArgb
            Label11.BackColor = dlg.Color
            CorPrench(IT) = dlg.Color
            Texto(IT).BackColor = CorPrench(IT)
            If FormPrincipal.RadioButton1.Checked = True Then
                TextoPrinc(IT).BackColor = CorPrench(IT)
                TextoApres(IT).BackColor = CorPrench(IT)
            End If
        End If
    End Sub
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click 'Cor fundo transparente
        Dim Texto() As Label = {Label14, Label15, Label16, Label13}
        Dim TextoPrinc() As Label = {FormPrincipal.Label3, FormPrincipal.Label4, FormPrincipal.Label5, FormPrincipal.Label6}
        Dim TextoApres() As Label = {FormApresentar.Label1, FormApresentar.Label2, FormApresentar.Label3, FormApresentar.Label4}
        Label11.BackColor = Color.Transparent
        Label10.Text = Label11.BackColor.ToArgb
        Texto(IT).BackColor = Color.Transparent
        CorPrench(IT) = Texto(IT).BackColor
        If FormPrincipal.RadioButton1.Checked = True Then
            TextoPrinc(IT).BackColor = CorPrench(IT)
            TextoApres(IT).BackColor = CorPrench(IT)
        End If
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click 'Fonte
        Dim Texto() As Label = {Label14, Label15, Label16, Label13}
        Dim TextoPrinc() As Label = {FormPrincipal.Label3, FormPrincipal.Label4, FormPrincipal.Label5, FormPrincipal.Label6}
        Dim TextoApres() As Label = {FormApresentar.Label1, FormApresentar.Label2, FormApresentar.Label3, FormApresentar.Label4}
        Dim dlg As FontDialog = New FontDialog()
        dlg.ShowColor = True
        dlg.ShowEffects = True
        dlg.ShowHelp = True
        ValPerc = Label18.Text
        dlg.Font = Texto(IT).Font
        dlg.Color = Texto(IT).ForeColor
        If dlg.ShowDialog() <> DialogResult.Cancel Then
            Label5.Text = dlg.Font.Name
            Label5.Font = New Font(dlg.Font.Name, 11, dlg.Font.Style)
            Label7.Text = dlg.Font.Style
            Label8.Text = dlg.Font.Size
            Label9.Text = dlg.Color.ToArgb
            Label9.BackColor = dlg.Color
            Fonte(IT) = New Font(dlg.Font.Name, dlg.Font.Size, dlg.Font.Style)
            Dim vo As Single = ((dlg.Font.Size * 2) * (ValPerc / 100)) + (dlg.Font.Size * 2)
            FonteProj(IT) = New Font(dlg.Font.Name, vo, dlg.Font.Style)
            Texto(IT).Font = dlg.Font
            Texto(IT).ForeColor = dlg.Color
            If FormPrincipal.RadioButton1.Checked = True Then
                TextoPrinc(IT).Font = Fonte(IT)
                TextoPrinc(IT).ForeColor = dlg.Color
                TextoApres(IT).Font = FonteProj(IT)
                TextoApres(IT).ForeColor = dlg.Color
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim I As Long
        If DataGridView1.Rows.Count = 0 Then Exit Sub
        I = DataGridView1.CurrentRow.Index
        ValPerc = Label18.Text
        TextBox10.Text = DataGridView1.Rows(I).Cells(0).Value 'indice
        TextBox9.Text = DataGridView1.Rows(I).Cells(1).Value 'texto
        Label3.Text = DataGridView1.Rows(I).Cells(2).Value 'titulo
        Label4.Text = DataGridView1.Rows(I).Cells(3).Value 'Alinhamento
        Label10.Text = DataGridView1.Rows(I).Cells(4).Value 'Preenchimento
        Label5.Text = DataGridView1.Rows(I).Cells(5).Value  'Fonte nome
        Label8.Text = DataGridView1.Rows(I).Cells(6).Value 'Fonte tamanho
        Label7.Text = DataGridView1.Rows(I).Cells(7).Value 'Fonte estilo
        Label9.Text = DataGridView1.Rows(I).Cells(8).Value 'Fonte cor
        Button11.Visible = True
        Button10.Text = "Alterar"
        If Label4.Text = "TopLeft" Then Label4.TextAlign = ContentAlignment.TopLeft
        If Label4.Text = "TopCenter" Then Label4.TextAlign = ContentAlignment.TopCenter
        If Label4.Text = "TopRight" Then Label4.TextAlign = ContentAlignment.TopRight
        If Label4.Text = "MiddleLeft" Then Label4.TextAlign = ContentAlignment.MiddleLeft
        If Label4.Text = "MiddleCenter" Then Label4.TextAlign = ContentAlignment.MiddleCenter
        If Label4.Text = "MiddleRight" Then Label4.TextAlign = ContentAlignment.MiddleRight
        If Label4.Text = "BottomLeft" Then Label4.TextAlign = ContentAlignment.BottomLeft
        If Label4.Text = "BottomCenter" Then Label4.TextAlign = ContentAlignment.BottomCenter
        If Label4.Text = "BottomRight" Then Label4.TextAlign = ContentAlignment.BottomRight
        Alinhar()
        Label5.Font = New Font(Label5.Text, 11)
        Label9.BackColor = Color.FromArgb(Label9.Text)
        Label11.BackColor = Color.FromArgb(Label10.Text)
        ATualizarFonte()
    End Sub
    Private Sub ATualizarFonte()
        Dim Texto() As Label = {Label14, Label15, Label16, Label13}
        Dim TextoPrinc() As Label = {FormPrincipal.Label3, FormPrincipal.Label4, FormPrincipal.Label5, FormPrincipal.Label6}
        Dim TextoApres() As Label = {FormApresentar.Label1, FormApresentar.Label2, FormApresentar.Label3, FormApresentar.Label4}
        Dim f As FontFamily
        Try
            f = FontF(FN:=Label5.Text)
            Fonte(IT) = New Font(f, CSng(Label8.Text))
        Catch
            MsgBox("A fonte:" & Label5.Text & " não está instalada neste computador.", vbInformation, "Acessar Dados do systema")
            f = FontF(FN:="Arial")
            Fonte(IT) = New Font(f, CSng(Label8.Text))
        End Try
        Dim vo As Single = ((CSng(Label8.Text)) * 2 * (ValPerc / 100)) + ((CSng(Label8.Text)) * 2)
        FonteProj(IT) = New Font(f, vo)
        CorFonte(IT) = Color.FromArgb(Label9.Text)
        CorPrench(IT) = Color.FromArgb(Label10.Text)
        Texto(IT).Font = Fonte(IT)
        Texto(IT).ForeColor = CorFonte(IT)
        Texto(IT).BackColor = CorPrench(IT)
        If FormPrincipal.RadioButton1.Checked = True Then
            TextoPrinc(IT).Font = Fonte(IT)
            TextoPrinc(IT).ForeColor = CorFonte(IT)
            TextoPrinc(IT).BackColor = CorPrench(IT)
            TextoApres(IT).Font = FonteProj(IT)
            TextoApres(IT).ForeColor = CorFonte(IT)
            TextoApres(IT).BackColor = CorPrench(IT)
        End If
    End Sub
    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged 'Texto
        Dim Texto() As Label = {Label14, Label15, Label16, Label13}
        Dim TextoPrinc() As Label = {FormPrincipal.Label3, FormPrincipal.Label4, FormPrincipal.Label5, FormPrincipal.Label6}
        Dim TextoApres() As Label = {FormApresentar.Label1, FormApresentar.Label2, FormApresentar.Label3, FormApresentar.Label4}
        Button10.Text = "Voltar"
        If Len(TextBox9.Text) > 5 Then
            If TextBox10.Text = "N" Then
                Button10.Text = "Salvar"
            Else
                Button10.Text = "Alterar"
            End If
        End If
        Texto(IT).Text = TextBox9.Text
        Textos(IT) = TextBox9.Text
        If FormPrincipal.RadioButton1.Checked = True Then
            TextoPrinc(IT).Text = Textos(IT)
            TextoApres(IT).Text = Textos(IT)
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click 'NOVO
        Button10.Text = "Salvar"
        Button11.Visible = False
        TextBox10.Text = "N"
        TextBox9.Text = ""
        TextBox9.Select()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click 'Voltar/Salvar/Alterar
        TabControl1.SelectedIndex = 0
        If Button10.Text = "Voltar" Then Exit Sub
        If Label3.Text = "Título" Then
            TextBox1.Text = TextBox9.Text 'texto
            If TextBox10.Text = "N" Then
                TextBox5.Text = SalvarNovoTexto(Tx:=TextBox9.Text, Tp:=Label3.Text, Al:=Label4.Text, Pr:=Label10.Text, FN:=Label5.Text, FT:=Label8.Text, FE:=Label7.Text, FC:=Label9.Text)
            Else
                TextBox5.Text = TextBox10.Text 'numero
                SalvarAtualTexto(Nu:=TextBox5.Text, Tx:=TextBox9.Text, Tp:=Label3.Text, Al:=Label4.Text, Pr:=Label10.Text, FN:=Label5.Text, FT:=Label8.Text, FE:=Label7.Text, FC:=Label9.Text)
            End If
        ElseIf Label3.Text = "Subtítulo" Then
            TextBox2.Text = TextBox9.Text 'texto
            If TextBox10.Text = "N" Then
                TextBox6.Text = SalvarNovoTexto(Tx:=TextBox9.Text, Tp:=Label3.Text, Al:=Label4.Text, Pr:=Label10.Text, FN:=Label5.Text, FT:=Label8.Text, FE:=Label7.Text, FC:=Label9.Text)
            Else
                TextBox6.Text = TextBox10.Text 'numero
                SalvarAtualTexto(Nu:=TextBox6.Text, Tx:=TextBox9.Text, Tp:=Label3.Text, Al:=Label4.Text, Pr:=Label10.Text, FN:=Label5.Text, FT:=Label8.Text, FE:=Label7.Text, FC:=Label9.Text)
            End If
        ElseIf Label3.Text = "Corpo" Then
            TextBox3.Text = TextBox9.Text 'texto
            If TextBox10.Text = "N" Then
                TextBox7.Text = SalvarNovoTexto(Tx:=TextBox9.Text, Tp:=Label3.Text, Al:=Label4.Text, Pr:=Label10.Text, FN:=Label5.Text, FT:=Label8.Text, FE:=Label7.Text, FC:=Label9.Text)
            Else
                TextBox7.Text = TextBox10.Text 'numero 
                SalvarAtualTexto(Nu:=TextBox7.Text, Tx:=TextBox9.Text, Tp:=Label3.Text, Al:=Label4.Text, Pr:=Label10.Text, FN:=Label5.Text, FT:=Label8.Text, FE:=Label7.Text, FC:=Label9.Text)
            End If
        ElseIf Label3.Text = "Rodapé" Then
            TextBox4.Text = TextBox9.Text 'texto
            If TextBox10.Text = "N" Then
                TextBox8.Text = SalvarNovoTexto(Tx:=TextBox9.Text, Tp:=Label3.Text, Al:=Label4.Text, Pr:=Label10.Text, FN:=Label5.Text, FT:=Label8.Text, FE:=Label7.Text, FC:=Label9.Text)
            Else
                TextBox8.Text = TextBox10.Text 'numero 
                SalvarAtualTexto(Nu:=TextBox8.Text, Tx:=TextBox9.Text, Tp:=Label3.Text, Al:=Label4.Text, Pr:=Label10.Text, FN:=Label5.Text, FT:=Label8.Text, FE:=Label7.Text, FC:=Label9.Text)
            End If
        End If
        IT = 10
    End Sub
    'Insere o texto e devolve o ID gerado pelo Access (AutoNumeração)
    Private Function SalvarNovoTexto(Tx As String, Tp As String, Al As String, Pr As String, FN As String, FT As String, FE As String, FC As String) As String
        Dim NovoID As String = ""
        ConectarDados()
        Try
            Using Comando As New OleDb.OleDbCommand("INSERT INTO Textos (Texto,Tipo,Alinhamento,CorPreenchim,FonteNome,FonteTamanho,FonteEstilo,FonteCor) VALUES (?,?,?,?,?,?,?,?)", ConexDados)
                AdicionarParametros(Comando, Tx, Tp, Al, Pr, FN, FT, FE, FC)
                Comando.ExecuteNonQuery()
            End Using
            Using Comando As New OleDb.OleDbCommand("SELECT @@IDENTITY", ConexDados)
                NovoID = Comando.ExecuteScalar().ToString
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Acessar Dados do systema")
        End Try
        RegTextos.Clear()
        RegTipoTexto.Clear()
        CarregarTextos()
        DesconectarDados()
        Return NovoID
    End Function
    Private Sub SalvarAtualTexto(Nu As Long, Tx As String, Tp As String, Al As String, Pr As String, FN As String, FT As String, FE As String, FC As String)
        ConectarDados()
        Try
            Using Comando As New OleDb.OleDbCommand("UPDATE Textos SET Texto=?,Tipo=?,Alinhamento=?,CorPreenchim=?,FonteNome=?,FonteTamanho=?,FonteEstilo=?,FonteCor=? WHERE ID=?", ConexDados)
                AdicionarParametros(Comando, Tx, Tp, Al, Pr, FN, FT, FE, FC)
                Comando.Parameters.AddWithValue("@ID", Nu)
                Comando.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Acessar Dados do systema")
        End Try
        RegTextos.Clear()
        RegTipoTexto.Clear()
        CarregarTextos()
        DesconectarDados()
    End Sub
    'Parâmetros na mesma ordem dos "?" (OleDb usa a posição, não o nome)
    Private Sub AdicionarParametros(Comando As OleDb.OleDbCommand, ParamArray Valores() As String)
        For I As Integer = 0 To Valores.Length - 1
            Comando.Parameters.AddWithValue("@p" & I, If(Valores(I), ""))
        Next
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged 'Selecionar Titulo 
        Button1.Visible = False
        Label14.Visible = False
        If FormPrincipal.RadioButton1.Checked = True Then 'ATIVADO
            FormPrincipal.Label3.Text = ""
            FormApresentar.Label1.Text = ""
        End If
        If CheckBox1.Checked = True Then
            Button1.Visible = True
            Label14.Visible = True
            TextActive(0) = True
            If FormPrincipal.RadioButton1.Checked = True Then
                FormPrincipal.Label3.Text = TextBox1.Text
                FormPrincipal.Label3.Font = Fonte(0)
                FormPrincipal.Label3.ForeColor = CorFonte(0)
                FormPrincipal.Label3.BackColor = CorPrench(0)
                FormApresentar.Label1.Text = TextBox1.Text
                FormApresentar.Label1.Font = FonteProj(0)
                FormApresentar.Label1.ForeColor = CorFonte(0)
                FormApresentar.Label1.BackColor = CorPrench(0)
            End If
        Else
            If FormPrincipal.RadioButton1.Checked = True Then
                FormPrincipal.Label3.Text = ""
                FormPrincipal.Label3.BackColor = Color.Transparent
                FormApresentar.Label1.Text = ""
                FormApresentar.Label1.BackColor = Color.Transparent
            End If
            TextActive(0) = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged 'Selecionar Subtítulo
        Button2.Visible = False
        Label15.Visible = False
        If FormPrincipal.RadioButton1.Checked = True Then
            FormPrincipal.Label4.Text = ""
            FormApresentar.Label2.Text = ""
        End If
        If CheckBox2.Checked = True Then
            Button2.Visible = True
            Label15.Visible = True
            TextActive(1) = True
            If FormPrincipal.RadioButton1.Checked = True Then
                FormPrincipal.Label4.Text = TextBox2.Text
                FormPrincipal.Label4.Font = Fonte(1)
                FormPrincipal.Label4.ForeColor = CorFonte(1)
                FormPrincipal.Label4.BackColor = CorPrench(1)
                FormApresentar.Label2.Text = TextBox2.Text
                FormApresentar.Label2.Font = FonteProj(1)
                FormApresentar.Label2.ForeColor = CorFonte(1)
                FormApresentar.Label2.BackColor = CorPrench(1)
            End If
        Else
            If FormPrincipal.RadioButton1.Checked = True Then
                FormPrincipal.Label4.Text = ""
                FormPrincipal.Label4.BackColor = Color.Transparent
                FormApresentar.Label2.Text = ""
                FormApresentar.Label2.BackColor = Color.Transparent
            End If
            TextActive(1) = False
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged 'Selecionar Corpo
        Button3.Visible = False
        Label16.Visible = False
        If FormPrincipal.RadioButton1.Checked = True Then
            FormPrincipal.Label5.Text = ""
            FormApresentar.Label3.Text = ""
        End If
        If CheckBox3.Checked = True Then
            Button3.Visible = True
            Label16.Visible = True
            TextActive(2) = True
            If FormPrincipal.RadioButton1.Checked = True Then
                FormPrincipal.Label5.Text = TextBox3.Text
                FormPrincipal.Label5.Font = Fonte(2)
                FormPrincipal.Label5.ForeColor = CorFonte(2)
                FormPrincipal.Label5.BackColor = CorPrench(2)
                FormApresentar.Label3.Text = TextBox3.Text
                FormApresentar.Label3.Font = FonteProj(2)
                FormApresentar.Label3.ForeColor = CorFonte(2)
                FormApresentar.Label3.BackColor = CorPrench(2)
            End If
        Else
            If FormPrincipal.RadioButton1.Checked = True Then
                FormPrincipal.Label5.Text = ""
                FormPrincipal.Label5.BackColor = Color.Transparent
                FormApresentar.Label3.Text = ""
                FormApresentar.Label3.BackColor = Color.Transparent
            End If
            TextActive(2) = False
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged 'Selecionar Rodapé
        Button4.Visible = False
        Label13.Visible = False
        If FormPrincipal.RadioButton1.Checked = True Then
            FormPrincipal.Label6.Text = ""
            FormApresentar.Label4.Text = ""
        End If
        If CheckBox4.Checked = True Then
            Button4.Visible = True
            Label13.Visible = True
            TextActive(3) = True
            If FormPrincipal.RadioButton1.Checked = True Then
                FormPrincipal.Label6.Text = TextBox4.Text
                FormPrincipal.Label6.Font = Fonte(3)
                FormPrincipal.Label6.ForeColor = CorFonte(3)
                FormPrincipal.Label6.BackColor = CorPrench(3)
                FormApresentar.Label4.Text = TextBox4.Text
                FormApresentar.Label4.Font = FonteProj(3)
                FormApresentar.Label4.ForeColor = CorFonte(3)
                FormApresentar.Label4.BackColor = CorPrench(3)
            End If
        Else
            If FormPrincipal.RadioButton1.Checked = True Then
                FormPrincipal.Label6.Text = ""
                FormPrincipal.Label6.BackColor = Color.Transparent
                FormApresentar.Label4.Text = ""
                FormApresentar.Label4.BackColor = Color.Transparent
            End If
            TextActive(3) = False
        End If
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        ValPerc = TrackBar1.Value
        ZoomTFundo = ValPerc
        Label18.Text = TrackBar1.Value
        ATualizarFonteTextos()
    End Sub

    Private Sub ATualizarFonteTextos()
        Dim I As Long
        Dim Check() As CheckBox = {CheckBox1, CheckBox2, CheckBox3, CheckBox4}
        Dim IndText() As TextBox = {TextBox5, TextBox6, TextBox7, TextBox8}
        Dim TextoPrinc() As Label = {FormPrincipal.Label3, FormPrincipal.Label4, FormPrincipal.Label5, FormPrincipal.Label6}
        Dim TextoApres() As Label = {FormApresentar.Label1, FormApresentar.Label2, FormApresentar.Label3, FormApresentar.Label4}
        ValPerc = Label18.Text
        For II As Integer = 0 To 3
            If Check(II).Checked = True And IndText(II).Text <> "" Then
                I = IndText(II).Text
                For L As Long = 0 To RegTextos.Rows.Count - 1
                    If I = RegTextos.Rows(L).Item(0) Then
                        Dim f As FontFamily = FontF(FN:=RegTextos.Rows(L).Item(5))
                        If f Is Nothing Then f = FontFamily.GenericSansSerif 'fonte não instalada neste computador
                        Dim vo As Single = (CSng(RegTextos.Rows(L).Item(6)) * 2 * (ValPerc / 100)) + (CSng(RegTextos.Rows(L).Item(6)) * 2)
                        FonteProj(II) = New Font(f, vo)
                        CorFonte(II) = Color.FromArgb(RegTextos.Rows(L).Item(8))
                        CorPrench(II) = Color.FromArgb(RegTextos.Rows(L).Item(4))
                        If FormPrincipal.RadioButton1.Checked = True Then
                            TextoApres(II).Font = FonteProj(II)
                            TextoApres(II).ForeColor = CorFonte(II)
                            TextoApres(II).BackColor = CorPrench(II)
                        End If
                    End If
                Next
            End If
        Next
    End Sub

End Class