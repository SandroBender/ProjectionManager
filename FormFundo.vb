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
            cboPastas.Items.Add(Pasta)
        Next
        lblTituloTextos.Size = New Point(403, 31)
        rbGerenciador.Checked = True
        picPreview.AllowDrop = True
        ConectarDados()
        CarregarImagens()
        CarregarTextos()
        CarregarZoom()
        DesconectarDados()
        Try
            picPreview.Image = CarregarImagem(RegImagens.Rows(0).Item("CamImagem"))
            ImageFundo = RegImagens.Rows(0).Item("CamImagem")
            lblArquivo.Text = RegImagens.Rows(0).Item("CamImagem")
        Catch ex As Exception
            lblArquivo.Text = "Não encontrada"
        End Try
        Try
            lblZoom.Text = RegZoom.Rows(0).Item("TextoFundo")
            trkZoom.Value = RegZoom.Rows(0).Item("TextoFundo")

        Catch ex As Exception
            lblZoom.Text = "16"
        End Try
        lblPrevTitulo.Parent = picPreview 'CRIAR transparencia dos textos
        lblPrevSubtitulo.Parent = picPreview
        lblPrevCorpo.Parent = picPreview
        lblPrevRodape.Parent = picPreview
        'lblAlinhamento.Location = New Point(10, 10) 'POSIÇÃO
        'lblPrevSubtitulo.Location = New Point(10, 40)
        'lblPrevCorpo.Location = New Point(10, 70)
    End Sub
    Private Sub rbGerenciador_CheckedChanged(sender As Object, e As EventArgs) Handles rbGerenciador.CheckedChanged 'Imagens P. Manager
        If rbGerenciador.Checked = True Then
            webPastas.Stop()
            cboPastas.Visible = True
            'btnVoltarPasta.Visible = False
            lblIndiceImagem.Text = "0"
        End If
    End Sub
    Private Sub rbMinhasImagens_CheckedChanged(sender As Object, e As EventArgs) Handles rbMinhasImagens.CheckedChanged 'Minhas Imagens
        If rbMinhasImagens.Checked = True Then
            cboPastas.Visible = False
            'btnVoltarPasta.Visible = True
            webPastas.Url = New Uri(PCImagens)
            CamSelect = PCImagens
            lblIndiceImagem.Text = "0"
        End If
    End Sub
    Private Sub cboPastas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPastas.SelectedIndexChanged
        Dim I As Integer = cboPastas.SelectedIndex
        Dim Cam As String = PMImagens(I)
        webPastas.Url = New Uri(Cam)
        CamSelect = Cam
    End Sub

    Private Sub picPreview_DragEnter(sender As Object, e As DragEventArgs) Handles picPreview.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
    Private Sub picPreview_DragDrop(sender As Object, e As DragEventArgs) Handles picPreview.DragDrop
        Dim Ext As String
        Dim P As Integer
        Try
            ImageFundo = e.Data.GetData(DataFormats.FileDrop)(0)
            If Not File.Exists(ImageFundo) Then Exit Sub
            Ext = Mid(ImageFundo, Len(ImageFundo) - 3, 5)
            P = InStrRev(ImageFundo, "\", -1, CompareMethod.Text)
            CamSelect = Mid(ImageFundo, 1, P - 1)
            'If Ext <> ".jpg" And Ext <> "jpeg" And Ext <> ".png" And Ext <> ".bmp" Then Exit Sub
            picPreview.Image = CarregarImagem(ImageFundo)
            lblArquivo.Text = ImageFundo
            Transferir()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Arrastar Imagem")
        End Try
    End Sub

    Private Sub btnNovaImagem_Click(sender As Object, e As EventArgs) Handles btnNovaImagem.Click 'Nova imagem
        If CamSelect = Nothing Then
            MsgBox("Arraste a 1° Imagem pra continuar.", vbCritical, "Alterar Imagem")
        Else
            ProxArq(Pasta:=CamSelect)
        End If
    End Sub
    Private Sub ProxArq(Pasta As String)
        Dim TA As Integer 'total arquivos
        Dim IA As Integer = lblIndiceImagem.Text 'indice atual
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
                    lblIndiceImagem.Text = "0"
                    picPreview.Image = CarregarImagem(Arq)
                    ImageFundo = Arq
                    lblArquivo.Text = Arq
                    Transferir()
                    Exit For
                End If
                'If IA = IC Then IP = IC + 1 'indice anterior encontrado
                If IP = IC Then 'próximo indice encontrado
                    picPreview.Image = CarregarImagem(Arq)
                    ImageFundo = Arq
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
        FormPrincipal.chkFundo.Checked = False
        If rbDesligado.Checked = True Then
            rbDesligado.BackColor = Color.AliceBlue
            rbLigado.BackColor = Color.Transparent
            FormPrincipal.chkFundo.Checked = False
        End If
        Transferir()
    End Sub

    Private Sub rbLigado_CheckedChanged(sender As Object, e As EventArgs) Handles rbLigado.CheckedChanged 'IMAGEM ATIVADA
        rbDesligado.BackColor = Color.Transparent
        rbLigado.BackColor = Color.Transparent
        FormPrincipal.chkFundo.Checked = False
        If rbLigado.Checked = True Then
            rbLigado.BackColor = Color.AliceBlue
            rbDesligado.BackColor = Color.Transparent
            FormPrincipal.chkFundo.Checked = True
        End If
        Transferir()
    End Sub

    Private Sub Transferir()
        ImageFundo = lblArquivo.Text
        If rbLigado.Checked = True Then
            ImageF = True
            If ImageFundo = "Não encontrada" Then ImageF = False
            If FormPrincipal.rbAtivada.Checked = True Then FormPrincipal.picFundo.Image = picPreview.Image
            FormPrincipal.picFundo.SizeMode = PictureBoxSizeMode.StretchImage
        Else
            ImageF = False
            If FormPrincipal.rbAtivada.Checked = True Then FormPrincipal.picFundo.Image = Nothing
        End If
        AtualizaApresentacao()
    End Sub

    Private Sub btnVoltarPasta_Click(sender As Object, e As EventArgs) Handles btnVoltarPasta.Click 'Voltar
        webPastas.GoBack()
    End Sub

    Private Sub btnEditarTitulo_Click_1(sender As Object, e As EventArgs) Handles btnEditarTitulo.Click 'Editar Título
        Dim I As Long = 0
        IT = 0
        tabTextos.SelectedIndex = 1
        lblTipoTexto.Text = chkTitulo.Text 'tipo
        txtEdicaoTexto.Text = txtTitulo.Text 'texto
        txtEdicaoId.Text = txtIdTitulo.Text 'indice
        If txtEdicaoId.Text = "" Then
            txtEdicaoId.Text = "N"
        Else
            I = txtEdicaoId.Text
        End If
        CarregarTipoTexto(Tipo:=lblTipoTexto.Text, I:=I)
    End Sub
    Private Sub btnEditarSubtitulo_Click(sender As Object, e As EventArgs) Handles btnEditarSubtitulo.Click 'Editar Subtitulo
        Dim I As Long = 0
        IT = 1
        tabTextos.SelectedIndex = 1
        lblTipoTexto.Text = chkSubtitulo.Text 'tipo
        txtEdicaoTexto.Text = txtSubtitulo.Text 'texto
        txtEdicaoId.Text = txtIdSubtitulo.Text 'indice
        If txtEdicaoId.Text = "" Then
            txtEdicaoId.Text = "N"
        Else
            I = txtEdicaoId.Text
        End If
        CarregarTipoTexto(Tipo:=lblTipoTexto.Text, I:=I)
    End Sub
    Private Sub btnEditarCorpo_Click(sender As Object, e As EventArgs) Handles btnEditarCorpo.Click 'Editar Corpo de texto
        Dim I As Long = 0
        IT = 2
        tabTextos.SelectedIndex = 1
        lblTipoTexto.Text = chkCorpo.Text 'tipo
        txtEdicaoTexto.Text = txtCorpo.Text 'texto
        txtEdicaoId.Text = txtIdCorpo.Text 'indice
        If txtEdicaoId.Text = "" Then
            txtEdicaoId.Text = "N"
        Else
            I = txtEdicaoId.Text
        End If
        CarregarTipoTexto(Tipo:=lblTipoTexto.Text, I:=I)
    End Sub
    Private Sub btnEditarRodape_Click(sender As Object, e As EventArgs) Handles btnEditarRodape.Click 'Editar Rodapé
        Dim I As Long = 0
        IT = 3
        tabTextos.SelectedIndex = 1
        lblTipoTexto.Text = chkRodape.Text 'tipo
        txtEdicaoTexto.Text = txtRodape.Text 'texto
        txtEdicaoId.Text = txtIdRodape.Text 'indice
        If txtEdicaoId.Text = "" Then
            txtEdicaoId.Text = "N"
        Else
            I = txtEdicaoId.Text
        End If
        CarregarTipoTexto(Tipo:=lblTipoTexto.Text, I:=I)
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
        dgvTextos.DataSource = RegTipoTexto
        If I = 0 Then 'Fonte Defauld
            lblAlinhamento.Text = "Left" 'Alinhamento
            lblCorPreenchimento.Text = "0" 'Preenchimento
            lblFonteNome.Text = "Calibri" 'Fonte nome
            lblFonteTamanho.Text = "20" 'Fonte tamanho
            lblFonteEstilo.Text = "0" 'Fonte estilo
            lblFonteCor.Text = "0" 'Fonte cor
        Else
            For L As Long = 0 To RegTextos.Rows.Count - 1
                If I = RegTextos.Rows(L).Item(0) Then
                    lblAlinhamento.Text = RegTextos.Rows(L).Item(3) 'Alinhamento
                    lblCorPreenchimento.Text = RegTextos.Rows(L).Item(4) 'Preenchimento
                    lblFonteNome.Text = RegTextos.Rows(L).Item(5) 'Fonte nome
                    lblFonteTamanho.Text = RegTextos.Rows(L).Item(6) 'Fonte Tamanho
                    lblFonteEstilo.Text = RegTextos.Rows(L).Item(7) 'Fonte Estilo
                    lblFonteCor.Text = RegTextos.Rows(L).Item(8) 'Fonte cor
                End If
            Next
        End If
        txtEdicaoTexto.Select()
    End Sub
    Private Sub btnAlinhaSupEsq_Click(sender As Object, e As EventArgs) Handles btnAlinhaSupEsq.Click 'Alinhamento superior esquerdo
        lblAlinhamento.TextAlign = ContentAlignment.TopLeft
        Alinhar()
    End Sub
    Private Sub btnAlinhaSupCentro_Click(sender As Object, e As EventArgs) Handles btnAlinhaSupCentro.Click 'Alinhamento superior central
        lblAlinhamento.TextAlign = ContentAlignment.TopCenter
        Alinhar()
    End Sub
    Private Sub btnAlinhaSupDir_Click(sender As Object, e As EventArgs) Handles btnAlinhaSupDir.Click 'Alinhamento superior direito
        lblAlinhamento.TextAlign = ContentAlignment.TopRight
        Alinhar()
    End Sub
    Private Sub btnAlinhaMeioEsq_Click(sender As Object, e As EventArgs) Handles btnAlinhaMeioEsq.Click 'alinhamento meio esquerdo
        lblAlinhamento.TextAlign = ContentAlignment.MiddleLeft
        Alinhar()
    End Sub

    Private Sub btnAlinhaMeioCentro_Click(sender As Object, e As EventArgs) Handles btnAlinhaMeioCentro.Click 'alinhamento meio central
        lblAlinhamento.TextAlign = ContentAlignment.MiddleCenter
        Alinhar()
    End Sub

    Private Sub btnAlinhaMeioDir_Click(sender As Object, e As EventArgs) Handles btnAlinhaMeioDir.Click 'alinhamento meio direito
        lblAlinhamento.TextAlign = ContentAlignment.MiddleRight
        Alinhar()
    End Sub

    Private Sub btnAlinhaInfEsq_Click(sender As Object, e As EventArgs) Handles btnAlinhaInfEsq.Click 'alinhamento inferior esquerdo
        lblAlinhamento.TextAlign = ContentAlignment.BottomLeft
        Alinhar()
    End Sub

    Private Sub btnAlinhaInfCentro_Click(sender As Object, e As EventArgs) Handles btnAlinhaInfCentro.Click 'alinhamento inferior central
        lblAlinhamento.TextAlign = ContentAlignment.BottomCenter
        Alinhar()
    End Sub

    Private Sub btnAlinhaInfDir_Click(sender As Object, e As EventArgs) Handles btnAlinhaInfDir.Click 'alinhamento inferior direito
        lblAlinhamento.TextAlign = ContentAlignment.BottomRight
        Alinhar()
    End Sub
    Private Sub Alinhar()
        Dim BA() As Button = {btnAlinhaSupEsq, btnAlinhaSupCentro, btnAlinhaSupDir, btnAlinhaMeioEsq, btnAlinhaMeioCentro, btnAlinhaMeioDir, btnAlinhaInfEsq, btnAlinhaInfCentro, btnAlinhaInfDir}
        Dim IA As String() = {"TopLeft", "TopCenter", "TopRight", "MiddleLeft", "MiddleCenter", "MiddleRight", "BottomLeft", "BottomCenter", "BottomRight"}
        Dim Texto() As Label = {lblPrevTitulo, lblPrevSubtitulo, lblPrevCorpo, lblPrevRodape}
        Dim TextoPrinc() As Label = {FormPrincipal.lblTitulo, FormPrincipal.lblSubtitulo, FormPrincipal.lblCorpo, FormPrincipal.lblRodape}
        Dim TextoApres() As Label = {FormApresentar.lblTitulo, FormApresentar.lblSubtitulo, FormApresentar.lblCorpo, FormApresentar.lblRodape}
        Alin = lblAlinhamento.TextAlign
        lblAlinhamento.Text = Alin.ToString
        For I As Integer = 0 To 8
            BA(I).BackColor = Color.Lavender
            If Alin.ToString = IA(I).ToString Then BA(I).BackColor = Color.SteelBlue
        Next
        Texto(IT).TextAlign = Alin
        Alinham(IT) = Alin
        If FormPrincipal.rbAtivada.Checked = True Then
            TextoPrinc(IT).TextAlign = Alin
            TextoApres(IT).TextAlign = Alin
        End If
    End Sub

    Private Sub btnCorFundo_Click(sender As Object, e As EventArgs) Handles btnCorFundo.Click 'Cor de fundo
        Dim Texto() As Label = {lblPrevTitulo, lblPrevSubtitulo, lblPrevCorpo, lblPrevRodape}
        Dim TextoPrinc() As Label = {FormPrincipal.lblTitulo, FormPrincipal.lblSubtitulo, FormPrincipal.lblCorpo, FormPrincipal.lblRodape}
        Dim TextoApres() As Label = {FormApresentar.lblTitulo, FormApresentar.lblSubtitulo, FormApresentar.lblCorpo, FormApresentar.lblRodape}
        Dim dlg As ColorDialog = New ColorDialog()
        dlg.AllowFullOpen = True
        dlg.ShowHelp = True
        dlg.Color = Texto(IT).BackColor
        If dlg.ShowDialog() <> DialogResult.Cancel Then
            lblCorPreenchimento.Text = dlg.Color.ToArgb
            lblAmostraFundo.BackColor = dlg.Color
            CorPrench(IT) = dlg.Color
            Texto(IT).BackColor = CorPrench(IT)
            If FormPrincipal.rbAtivada.Checked = True Then
                TextoPrinc(IT).BackColor = CorPrench(IT)
                TextoApres(IT).BackColor = CorPrench(IT)
            End If
        End If
    End Sub
    Private Sub btnFundoTransparente_Click(sender As Object, e As EventArgs) Handles btnFundoTransparente.Click 'Cor fundo transparente
        Dim Texto() As Label = {lblPrevTitulo, lblPrevSubtitulo, lblPrevCorpo, lblPrevRodape}
        Dim TextoPrinc() As Label = {FormPrincipal.lblTitulo, FormPrincipal.lblSubtitulo, FormPrincipal.lblCorpo, FormPrincipal.lblRodape}
        Dim TextoApres() As Label = {FormApresentar.lblTitulo, FormApresentar.lblSubtitulo, FormApresentar.lblCorpo, FormApresentar.lblRodape}
        lblAmostraFundo.BackColor = Color.Transparent
        lblCorPreenchimento.Text = lblAmostraFundo.BackColor.ToArgb
        Texto(IT).BackColor = Color.Transparent
        CorPrench(IT) = Texto(IT).BackColor
        If FormPrincipal.rbAtivada.Checked = True Then
            TextoPrinc(IT).BackColor = CorPrench(IT)
            TextoApres(IT).BackColor = CorPrench(IT)
        End If
    End Sub
    Private Sub btnFonte_Click(sender As Object, e As EventArgs) Handles btnFonte.Click 'Fonte
        Dim Texto() As Label = {lblPrevTitulo, lblPrevSubtitulo, lblPrevCorpo, lblPrevRodape}
        Dim TextoPrinc() As Label = {FormPrincipal.lblTitulo, FormPrincipal.lblSubtitulo, FormPrincipal.lblCorpo, FormPrincipal.lblRodape}
        Dim TextoApres() As Label = {FormApresentar.lblTitulo, FormApresentar.lblSubtitulo, FormApresentar.lblCorpo, FormApresentar.lblRodape}
        Dim dlg As FontDialog = New FontDialog()
        dlg.ShowColor = True
        dlg.ShowEffects = True
        dlg.ShowHelp = True
        ValPerc = lblZoom.Text
        dlg.Font = Texto(IT).Font
        dlg.Color = Texto(IT).ForeColor
        If dlg.ShowDialog() <> DialogResult.Cancel Then
            lblFonteNome.Text = dlg.Font.Name
            lblFonteNome.Font = New Font(dlg.Font.Name, 11, dlg.Font.Style)
            lblFonteEstilo.Text = dlg.Font.Style
            lblFonteTamanho.Text = dlg.Font.Size
            lblFonteCor.Text = dlg.Color.ToArgb
            lblFonteCor.BackColor = dlg.Color
            Fonte(IT) = New Font(dlg.Font.Name, dlg.Font.Size, dlg.Font.Style)
            Dim vo As Single = ((dlg.Font.Size * 2) * (ValPerc / 100)) + (dlg.Font.Size * 2)
            FonteProj(IT) = New Font(dlg.Font.Name, vo, dlg.Font.Style)
            Texto(IT).Font = dlg.Font
            Texto(IT).ForeColor = dlg.Color
            If FormPrincipal.rbAtivada.Checked = True Then
                TextoPrinc(IT).Font = Fonte(IT)
                TextoPrinc(IT).ForeColor = dlg.Color
                TextoApres(IT).Font = FonteProj(IT)
                TextoApres(IT).ForeColor = dlg.Color
            End If
        End If
    End Sub

    Private Sub dgvTextos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTextos.CellClick
        Dim I As Long
        If dgvTextos.Rows.Count = 0 Then Exit Sub
        I = dgvTextos.CurrentRow.Index
        ValPerc = lblZoom.Text
        txtEdicaoId.Text = dgvTextos.Rows(I).Cells(0).Value 'indice
        txtEdicaoTexto.Text = dgvTextos.Rows(I).Cells(1).Value 'texto
        lblTipoTexto.Text = dgvTextos.Rows(I).Cells(2).Value 'titulo
        lblAlinhamento.Text = dgvTextos.Rows(I).Cells(3).Value 'Alinhamento
        lblCorPreenchimento.Text = dgvTextos.Rows(I).Cells(4).Value 'Preenchimento
        lblFonteNome.Text = dgvTextos.Rows(I).Cells(5).Value  'Fonte nome
        lblFonteTamanho.Text = dgvTextos.Rows(I).Cells(6).Value 'Fonte tamanho
        lblFonteEstilo.Text = dgvTextos.Rows(I).Cells(7).Value 'Fonte estilo
        lblFonteCor.Text = dgvTextos.Rows(I).Cells(8).Value 'Fonte cor
        btnNovoTexto.Visible = True
        btnVoltarSalvar.Text = "Alterar"
        If lblAlinhamento.Text = "TopLeft" Then lblAlinhamento.TextAlign = ContentAlignment.TopLeft
        If lblAlinhamento.Text = "TopCenter" Then lblAlinhamento.TextAlign = ContentAlignment.TopCenter
        If lblAlinhamento.Text = "TopRight" Then lblAlinhamento.TextAlign = ContentAlignment.TopRight
        If lblAlinhamento.Text = "MiddleLeft" Then lblAlinhamento.TextAlign = ContentAlignment.MiddleLeft
        If lblAlinhamento.Text = "MiddleCenter" Then lblAlinhamento.TextAlign = ContentAlignment.MiddleCenter
        If lblAlinhamento.Text = "MiddleRight" Then lblAlinhamento.TextAlign = ContentAlignment.MiddleRight
        If lblAlinhamento.Text = "BottomLeft" Then lblAlinhamento.TextAlign = ContentAlignment.BottomLeft
        If lblAlinhamento.Text = "BottomCenter" Then lblAlinhamento.TextAlign = ContentAlignment.BottomCenter
        If lblAlinhamento.Text = "BottomRight" Then lblAlinhamento.TextAlign = ContentAlignment.BottomRight
        Alinhar()
        lblFonteNome.Font = New Font(lblFonteNome.Text, 11)
        lblFonteCor.BackColor = Color.FromArgb(lblFonteCor.Text)
        lblAmostraFundo.BackColor = Color.FromArgb(lblCorPreenchimento.Text)
        ATualizarFonte()
    End Sub
    Private Sub ATualizarFonte()
        Dim Texto() As Label = {lblPrevTitulo, lblPrevSubtitulo, lblPrevCorpo, lblPrevRodape}
        Dim TextoPrinc() As Label = {FormPrincipal.lblTitulo, FormPrincipal.lblSubtitulo, FormPrincipal.lblCorpo, FormPrincipal.lblRodape}
        Dim TextoApres() As Label = {FormApresentar.lblTitulo, FormApresentar.lblSubtitulo, FormApresentar.lblCorpo, FormApresentar.lblRodape}
        Dim f As FontFamily
        Try
            f = FontF(FN:=lblFonteNome.Text)
            Fonte(IT) = New Font(f, CSng(lblFonteTamanho.Text))
        Catch
            MsgBox("A fonte:" & lblFonteNome.Text & " não está instalada neste computador.", vbInformation, "Acessar Dados do systema")
            f = FontF(FN:="Arial")
            Fonte(IT) = New Font(f, CSng(lblFonteTamanho.Text))
        End Try
        Dim vo As Single = ((CSng(lblFonteTamanho.Text)) * 2 * (ValPerc / 100)) + ((CSng(lblFonteTamanho.Text)) * 2)
        FonteProj(IT) = New Font(f, vo)
        CorFonte(IT) = Color.FromArgb(lblFonteCor.Text)
        CorPrench(IT) = Color.FromArgb(lblCorPreenchimento.Text)
        Texto(IT).Font = Fonte(IT)
        Texto(IT).ForeColor = CorFonte(IT)
        Texto(IT).BackColor = CorPrench(IT)
        If FormPrincipal.rbAtivada.Checked = True Then
            TextoPrinc(IT).Font = Fonte(IT)
            TextoPrinc(IT).ForeColor = CorFonte(IT)
            TextoPrinc(IT).BackColor = CorPrench(IT)
            TextoApres(IT).Font = FonteProj(IT)
            TextoApres(IT).ForeColor = CorFonte(IT)
            TextoApres(IT).BackColor = CorPrench(IT)
        End If
    End Sub
    Private Sub txtEdicaoTexto_TextChanged(sender As Object, e As EventArgs) Handles txtEdicaoTexto.TextChanged 'Texto
        Dim Texto() As Label = {lblPrevTitulo, lblPrevSubtitulo, lblPrevCorpo, lblPrevRodape}
        Dim TextoPrinc() As Label = {FormPrincipal.lblTitulo, FormPrincipal.lblSubtitulo, FormPrincipal.lblCorpo, FormPrincipal.lblRodape}
        Dim TextoApres() As Label = {FormApresentar.lblTitulo, FormApresentar.lblSubtitulo, FormApresentar.lblCorpo, FormApresentar.lblRodape}
        btnVoltarSalvar.Text = "Voltar"
        If Len(txtEdicaoTexto.Text) > 5 Then
            If txtEdicaoId.Text = "N" Then
                btnVoltarSalvar.Text = "Salvar"
            Else
                btnVoltarSalvar.Text = "Alterar"
            End If
        End If
        Texto(IT).Text = txtEdicaoTexto.Text
        Textos(IT) = txtEdicaoTexto.Text
        If FormPrincipal.rbAtivada.Checked = True Then
            TextoPrinc(IT).Text = Textos(IT)
            TextoApres(IT).Text = Textos(IT)
        End If
    End Sub

    Private Sub btnNovoTexto_Click(sender As Object, e As EventArgs) Handles btnNovoTexto.Click 'NOVO
        btnVoltarSalvar.Text = "Salvar"
        btnNovoTexto.Visible = False
        txtEdicaoId.Text = "N"
        txtEdicaoTexto.Text = ""
        txtEdicaoTexto.Select()
    End Sub

    Private Sub btnVoltarSalvar_Click(sender As Object, e As EventArgs) Handles btnVoltarSalvar.Click 'Voltar/Salvar/Alterar
        tabTextos.SelectedIndex = 0
        If btnVoltarSalvar.Text = "Voltar" Then Exit Sub
        If lblTipoTexto.Text = "Título" Then
            txtTitulo.Text = txtEdicaoTexto.Text 'texto
            If txtEdicaoId.Text = "N" Then
                txtIdTitulo.Text = SalvarNovoTexto(Tx:=txtEdicaoTexto.Text, Tp:=lblTipoTexto.Text, Al:=lblAlinhamento.Text, Pr:=lblCorPreenchimento.Text, FN:=lblFonteNome.Text, FT:=lblFonteTamanho.Text, FE:=lblFonteEstilo.Text, FC:=lblFonteCor.Text)
            Else
                txtIdTitulo.Text = txtEdicaoId.Text 'numero
                SalvarAtualTexto(Nu:=txtIdTitulo.Text, Tx:=txtEdicaoTexto.Text, Tp:=lblTipoTexto.Text, Al:=lblAlinhamento.Text, Pr:=lblCorPreenchimento.Text, FN:=lblFonteNome.Text, FT:=lblFonteTamanho.Text, FE:=lblFonteEstilo.Text, FC:=lblFonteCor.Text)
            End If
        ElseIf lblTipoTexto.Text = "Subtítulo" Then
            txtSubtitulo.Text = txtEdicaoTexto.Text 'texto
            If txtEdicaoId.Text = "N" Then
                txtIdSubtitulo.Text = SalvarNovoTexto(Tx:=txtEdicaoTexto.Text, Tp:=lblTipoTexto.Text, Al:=lblAlinhamento.Text, Pr:=lblCorPreenchimento.Text, FN:=lblFonteNome.Text, FT:=lblFonteTamanho.Text, FE:=lblFonteEstilo.Text, FC:=lblFonteCor.Text)
            Else
                txtIdSubtitulo.Text = txtEdicaoId.Text 'numero
                SalvarAtualTexto(Nu:=txtIdSubtitulo.Text, Tx:=txtEdicaoTexto.Text, Tp:=lblTipoTexto.Text, Al:=lblAlinhamento.Text, Pr:=lblCorPreenchimento.Text, FN:=lblFonteNome.Text, FT:=lblFonteTamanho.Text, FE:=lblFonteEstilo.Text, FC:=lblFonteCor.Text)
            End If
        ElseIf lblTipoTexto.Text = "Corpo" Then
            txtCorpo.Text = txtEdicaoTexto.Text 'texto
            If txtEdicaoId.Text = "N" Then
                txtIdCorpo.Text = SalvarNovoTexto(Tx:=txtEdicaoTexto.Text, Tp:=lblTipoTexto.Text, Al:=lblAlinhamento.Text, Pr:=lblCorPreenchimento.Text, FN:=lblFonteNome.Text, FT:=lblFonteTamanho.Text, FE:=lblFonteEstilo.Text, FC:=lblFonteCor.Text)
            Else
                txtIdCorpo.Text = txtEdicaoId.Text 'numero 
                SalvarAtualTexto(Nu:=txtIdCorpo.Text, Tx:=txtEdicaoTexto.Text, Tp:=lblTipoTexto.Text, Al:=lblAlinhamento.Text, Pr:=lblCorPreenchimento.Text, FN:=lblFonteNome.Text, FT:=lblFonteTamanho.Text, FE:=lblFonteEstilo.Text, FC:=lblFonteCor.Text)
            End If
        ElseIf lblTipoTexto.Text = "Rodapé" Then
            txtRodape.Text = txtEdicaoTexto.Text 'texto
            If txtEdicaoId.Text = "N" Then
                txtIdRodape.Text = SalvarNovoTexto(Tx:=txtEdicaoTexto.Text, Tp:=lblTipoTexto.Text, Al:=lblAlinhamento.Text, Pr:=lblCorPreenchimento.Text, FN:=lblFonteNome.Text, FT:=lblFonteTamanho.Text, FE:=lblFonteEstilo.Text, FC:=lblFonteCor.Text)
            Else
                txtIdRodape.Text = txtEdicaoId.Text 'numero 
                SalvarAtualTexto(Nu:=txtIdRodape.Text, Tx:=txtEdicaoTexto.Text, Tp:=lblTipoTexto.Text, Al:=lblAlinhamento.Text, Pr:=lblCorPreenchimento.Text, FN:=lblFonteNome.Text, FT:=lblFonteTamanho.Text, FE:=lblFonteEstilo.Text, FC:=lblFonteCor.Text)
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

    Private Sub chkTitulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkTitulo.CheckedChanged 'Selecionar Titulo 
        btnEditarTitulo.Visible = False
        lblPrevTitulo.Visible = False
        If FormPrincipal.rbAtivada.Checked = True Then 'ATIVADO
            FormPrincipal.lblTitulo.Text = ""
            FormApresentar.lblTitulo.Text = ""
        End If
        If chkTitulo.Checked = True Then
            btnEditarTitulo.Visible = True
            lblPrevTitulo.Visible = True
            TextActive(0) = True
            If FormPrincipal.rbAtivada.Checked = True Then
                FormPrincipal.lblTitulo.Text = txtTitulo.Text
                FormPrincipal.lblTitulo.Font = Fonte(0)
                FormPrincipal.lblTitulo.ForeColor = CorFonte(0)
                FormPrincipal.lblTitulo.BackColor = CorPrench(0)
                FormApresentar.lblTitulo.Text = txtTitulo.Text
                FormApresentar.lblTitulo.Font = FonteProj(0)
                FormApresentar.lblTitulo.ForeColor = CorFonte(0)
                FormApresentar.lblTitulo.BackColor = CorPrench(0)
            End If
        Else
            If FormPrincipal.rbAtivada.Checked = True Then
                FormPrincipal.lblTitulo.Text = ""
                FormPrincipal.lblTitulo.BackColor = Color.Transparent
                FormApresentar.lblTitulo.Text = ""
                FormApresentar.lblTitulo.BackColor = Color.Transparent
            End If
            TextActive(0) = False
        End If
    End Sub

    Private Sub chkSubtitulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSubtitulo.CheckedChanged 'Selecionar Subtítulo
        btnEditarSubtitulo.Visible = False
        lblPrevSubtitulo.Visible = False
        If FormPrincipal.rbAtivada.Checked = True Then
            FormPrincipal.lblSubtitulo.Text = ""
            FormApresentar.lblSubtitulo.Text = ""
        End If
        If chkSubtitulo.Checked = True Then
            btnEditarSubtitulo.Visible = True
            lblPrevSubtitulo.Visible = True
            TextActive(1) = True
            If FormPrincipal.rbAtivada.Checked = True Then
                FormPrincipal.lblSubtitulo.Text = txtSubtitulo.Text
                FormPrincipal.lblSubtitulo.Font = Fonte(1)
                FormPrincipal.lblSubtitulo.ForeColor = CorFonte(1)
                FormPrincipal.lblSubtitulo.BackColor = CorPrench(1)
                FormApresentar.lblSubtitulo.Text = txtSubtitulo.Text
                FormApresentar.lblSubtitulo.Font = FonteProj(1)
                FormApresentar.lblSubtitulo.ForeColor = CorFonte(1)
                FormApresentar.lblSubtitulo.BackColor = CorPrench(1)
            End If
        Else
            If FormPrincipal.rbAtivada.Checked = True Then
                FormPrincipal.lblSubtitulo.Text = ""
                FormPrincipal.lblSubtitulo.BackColor = Color.Transparent
                FormApresentar.lblSubtitulo.Text = ""
                FormApresentar.lblSubtitulo.BackColor = Color.Transparent
            End If
            TextActive(1) = False
        End If
    End Sub

    Private Sub chkCorpo_CheckedChanged(sender As Object, e As EventArgs) Handles chkCorpo.CheckedChanged 'Selecionar Corpo
        btnEditarCorpo.Visible = False
        lblPrevCorpo.Visible = False
        If FormPrincipal.rbAtivada.Checked = True Then
            FormPrincipal.lblCorpo.Text = ""
            FormApresentar.lblCorpo.Text = ""
        End If
        If chkCorpo.Checked = True Then
            btnEditarCorpo.Visible = True
            lblPrevCorpo.Visible = True
            TextActive(2) = True
            If FormPrincipal.rbAtivada.Checked = True Then
                FormPrincipal.lblCorpo.Text = txtCorpo.Text
                FormPrincipal.lblCorpo.Font = Fonte(2)
                FormPrincipal.lblCorpo.ForeColor = CorFonte(2)
                FormPrincipal.lblCorpo.BackColor = CorPrench(2)
                FormApresentar.lblCorpo.Text = txtCorpo.Text
                FormApresentar.lblCorpo.Font = FonteProj(2)
                FormApresentar.lblCorpo.ForeColor = CorFonte(2)
                FormApresentar.lblCorpo.BackColor = CorPrench(2)
            End If
        Else
            If FormPrincipal.rbAtivada.Checked = True Then
                FormPrincipal.lblCorpo.Text = ""
                FormPrincipal.lblCorpo.BackColor = Color.Transparent
                FormApresentar.lblCorpo.Text = ""
                FormApresentar.lblCorpo.BackColor = Color.Transparent
            End If
            TextActive(2) = False
        End If
    End Sub

    Private Sub chkRodape_CheckedChanged(sender As Object, e As EventArgs) Handles chkRodape.CheckedChanged 'Selecionar Rodapé
        btnEditarRodape.Visible = False
        lblPrevRodape.Visible = False
        If FormPrincipal.rbAtivada.Checked = True Then
            FormPrincipal.lblRodape.Text = ""
            FormApresentar.lblRodape.Text = ""
        End If
        If chkRodape.Checked = True Then
            btnEditarRodape.Visible = True
            lblPrevRodape.Visible = True
            TextActive(3) = True
            If FormPrincipal.rbAtivada.Checked = True Then
                FormPrincipal.lblRodape.Text = txtRodape.Text
                FormPrincipal.lblRodape.Font = Fonte(3)
                FormPrincipal.lblRodape.ForeColor = CorFonte(3)
                FormPrincipal.lblRodape.BackColor = CorPrench(3)
                FormApresentar.lblRodape.Text = txtRodape.Text
                FormApresentar.lblRodape.Font = FonteProj(3)
                FormApresentar.lblRodape.ForeColor = CorFonte(3)
                FormApresentar.lblRodape.BackColor = CorPrench(3)
            End If
        Else
            If FormPrincipal.rbAtivada.Checked = True Then
                FormPrincipal.lblRodape.Text = ""
                FormPrincipal.lblRodape.BackColor = Color.Transparent
                FormApresentar.lblRodape.Text = ""
                FormApresentar.lblRodape.BackColor = Color.Transparent
            End If
            TextActive(3) = False
        End If
    End Sub

    Private Sub trkZoom_Scroll(sender As Object, e As EventArgs) Handles trkZoom.Scroll
        ValPerc = trkZoom.Value
        ZoomTFundo = ValPerc
        lblZoom.Text = trkZoom.Value
        ATualizarFonteTextos()
    End Sub

    Private Sub ATualizarFonteTextos()
        Dim I As Long
        Dim Check() As CheckBox = {chkTitulo, chkSubtitulo, chkCorpo, chkRodape}
        Dim IndText() As TextBox = {txtIdTitulo, txtIdSubtitulo, txtIdCorpo, txtIdRodape}
        Dim TextoPrinc() As Label = {FormPrincipal.lblTitulo, FormPrincipal.lblSubtitulo, FormPrincipal.lblCorpo, FormPrincipal.lblRodape}
        Dim TextoApres() As Label = {FormApresentar.lblTitulo, FormApresentar.lblSubtitulo, FormApresentar.lblCorpo, FormApresentar.lblRodape}
        ValPerc = lblZoom.Text
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
                        If FormPrincipal.rbAtivada.Checked = True Then
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