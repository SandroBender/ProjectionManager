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
        Dim IP As Integer = CInt(lblIndiceImagem.Text) + 1 'próxima imagem
        Dim Arq As String = Nothing
        Dim Indice As Integer = ImagemDaPasta(Pasta, IP, Arq) 'volta para a 1ª imagem depois da última
        If Indice < 0 Then Exit Sub 'pasta vazia ou inexistente
        picPreview.Image = CarregarImagem(Arq)
        ImageFundo = Arq
        lblArquivo.Text = Arq
        lblIndiceImagem.Text = Indice
        Transferir()
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

    '---- Os 4 textos (0=Título, 1=Subtítulo, 2=Corpo, 3=Rodapé) ----
    Private Function ChecksTexto() As CheckBox()
        Return {chkTitulo, chkSubtitulo, chkCorpo, chkRodape}
    End Function
    Private Function CaixasTexto() As TextBox()
        Return {txtTitulo, txtSubtitulo, txtCorpo, txtRodape}
    End Function
    Private Function CaixasId() As TextBox()
        Return {txtIdTitulo, txtIdSubtitulo, txtIdCorpo, txtIdRodape}
    End Function
    Private Function BotoesEditar() As Button()
        Return {btnEditarTitulo, btnEditarSubtitulo, btnEditarCorpo, btnEditarRodape}
    End Function
    Private Function TextosPrevia() As Label()
        Return {lblPrevTitulo, lblPrevSubtitulo, lblPrevCorpo, lblPrevRodape}
    End Function
    Private Function ProjecaoAtivada() As Boolean
        Return FormPrincipal.rbAtivada.Checked
    End Function
    Private Function EditandoTexto() As Boolean 'IT = 10 quando nenhum texto está em edição
        Return IT >= 0 AndAlso IT <= 3
    End Function

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditarTitulo.Click, btnEditarSubtitulo.Click, btnEditarCorpo.Click, btnEditarRodape.Click
        Dim I As Long = 0
        IT = Array.IndexOf(BotoesEditar(), sender)
        tabTextos.SelectedIndex = 1
        lblTipoTexto.Text = ChecksTexto()(IT).Text 'tipo
        txtEdicaoTexto.Text = CaixasTexto()(IT).Text 'texto
        txtEdicaoId.Text = CaixasId()(IT).Text 'indice
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
    '---- Alinhamento: os 9 botões na mesma ordem dos valores abaixo ----
    Private ReadOnly Alinhamentos() As ContentAlignment = {ContentAlignment.TopLeft, ContentAlignment.TopCenter, ContentAlignment.TopRight,
        ContentAlignment.MiddleLeft, ContentAlignment.MiddleCenter, ContentAlignment.MiddleRight,
        ContentAlignment.BottomLeft, ContentAlignment.BottomCenter, ContentAlignment.BottomRight}
    Private Function BotoesAlinhamento() As Button()
        Return {btnAlinhaSupEsq, btnAlinhaSupCentro, btnAlinhaSupDir, btnAlinhaMeioEsq, btnAlinhaMeioCentro, btnAlinhaMeioDir, btnAlinhaInfEsq, btnAlinhaInfCentro, btnAlinhaInfDir}
    End Function

    Private Sub btnAlinhamento_Click(sender As Object, e As EventArgs) Handles btnAlinhaSupEsq.Click, btnAlinhaSupCentro.Click, btnAlinhaSupDir.Click,
            btnAlinhaMeioEsq.Click, btnAlinhaMeioCentro.Click, btnAlinhaMeioDir.Click, btnAlinhaInfEsq.Click, btnAlinhaInfCentro.Click, btnAlinhaInfDir.Click
        lblAlinhamento.TextAlign = Alinhamentos(Array.IndexOf(BotoesAlinhamento(), sender))
        Alinhar()
    End Sub
    Private Sub Alinhar()
        Dim Botoes() As Button = BotoesAlinhamento()
        Alin = lblAlinhamento.TextAlign
        lblAlinhamento.Text = Alin.ToString
        For I As Integer = 0 To Alinhamentos.Length - 1
            Botoes(I).BackColor = If(Alinhamentos(I) = Alin, Color.SteelBlue, Color.Lavender)
        Next
        If Not EditandoTexto() Then Exit Sub
        TextosPrevia()(IT).TextAlign = Alin
        Alinham(IT) = Alin
        If ProjecaoAtivada() Then
            TextosPrincipal()(IT).TextAlign = Alin
            TextosApresentacao()(IT).TextAlign = Alin
        End If
    End Sub

    'Aplica a cor de preenchimento atual (CorPrench) ao texto em edição
    Private Sub AplicarPreenchimento()
        TextosPrevia()(IT).BackColor = CorPrench(IT)
        If ProjecaoAtivada() Then
            TextosPrincipal()(IT).BackColor = CorPrench(IT)
            TextosApresentacao()(IT).BackColor = CorPrench(IT)
        End If
    End Sub
    Private Sub btnCorFundo_Click(sender As Object, e As EventArgs) Handles btnCorFundo.Click 'Cor de fundo
        If Not EditandoTexto() Then Exit Sub
        Using dlg As New ColorDialog With {.AllowFullOpen = True, .ShowHelp = True, .Color = TextosPrevia()(IT).BackColor}
            If dlg.ShowDialog() <> DialogResult.Cancel Then
                lblCorPreenchimento.Text = dlg.Color.ToArgb
                lblAmostraFundo.BackColor = dlg.Color
                CorPrench(IT) = dlg.Color
                AplicarPreenchimento()
            End If
        End Using
    End Sub
    Private Sub btnFundoTransparente_Click(sender As Object, e As EventArgs) Handles btnFundoTransparente.Click 'Cor fundo transparente
        If Not EditandoTexto() Then Exit Sub
        lblAmostraFundo.BackColor = Color.Transparent
        lblCorPreenchimento.Text = lblAmostraFundo.BackColor.ToArgb
        CorPrench(IT) = Color.Transparent
        AplicarPreenchimento()
    End Sub
    Private Sub btnFonte_Click(sender As Object, e As EventArgs) Handles btnFonte.Click 'Fonte
        If Not EditandoTexto() Then Exit Sub
        ValPerc = lblZoom.Text
        Using dlg As New FontDialog With {.ShowColor = True, .ShowEffects = True, .ShowHelp = True, .Font = TextosPrevia()(IT).Font, .Color = TextosPrevia()(IT).ForeColor}
            If dlg.ShowDialog() <> DialogResult.Cancel Then
                lblFonteNome.Text = dlg.Font.Name
                lblFonteNome.Font = New Font(dlg.Font.Name, 11, dlg.Font.Style)
                lblFonteEstilo.Text = dlg.Font.Style
                lblFonteTamanho.Text = dlg.Font.Size
                lblFonteCor.Text = dlg.Color.ToArgb
                lblFonteCor.BackColor = dlg.Color
                Fonte(IT) = New Font(dlg.Font.Name, dlg.Font.Size, dlg.Font.Style)
                FonteProj(IT) = New Font(dlg.Font.Name, TamanhoProjecao(dlg.Font.Size), dlg.Font.Style)
                TextosPrevia()(IT).Font = dlg.Font
                TextosPrevia()(IT).ForeColor = dlg.Color
                If ProjecaoAtivada() Then
                    TextosPrincipal()(IT).Font = Fonte(IT)
                    TextosPrincipal()(IT).ForeColor = dlg.Color
                    TextosApresentacao()(IT).Font = FonteProj(IT)
                    TextosApresentacao()(IT).ForeColor = dlg.Color
                End If
            End If
        End Using
    End Sub
    'Tamanho da fonte na tela de projeção: o dobro do tamanho de edição + o zoom (%)
    Private Function TamanhoProjecao(Tamanho As Single) As Single
        Return (Tamanho * 2 * (ValPerc / 100)) + (Tamanho * 2)
    End Function

    Private Sub dgvTextos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTextos.CellClick
        If dgvTextos.Rows.Count = 0 OrElse dgvTextos.CurrentRow Is Nothing Then Exit Sub
        Dim Celulas As DataGridViewCellCollection = dgvTextos.CurrentRow.Cells
        ValPerc = lblZoom.Text
        txtEdicaoId.Text = Celulas(0).Value 'indice
        txtEdicaoTexto.Text = Celulas(1).Value 'texto
        lblTipoTexto.Text = Celulas(2).Value 'titulo
        lblAlinhamento.Text = Celulas(3).Value 'Alinhamento
        lblCorPreenchimento.Text = Celulas(4).Value 'Preenchimento
        lblFonteNome.Text = Celulas(5).Value  'Fonte nome
        lblFonteTamanho.Text = Celulas(6).Value 'Fonte tamanho
        lblFonteEstilo.Text = Celulas(7).Value 'Fonte estilo
        lblFonteCor.Text = Celulas(8).Value 'Fonte cor
        btnNovoTexto.Visible = True
        btnVoltarSalvar.Text = "Alterar"
        For Each A As ContentAlignment In Alinhamentos
            If lblAlinhamento.Text = A.ToString Then lblAlinhamento.TextAlign = A
        Next
        Alinhar()
        lblFonteNome.Font = New Font(lblFonteNome.Text, 11)
        lblFonteCor.BackColor = Color.FromArgb(lblFonteCor.Text)
        lblAmostraFundo.BackColor = Color.FromArgb(lblCorPreenchimento.Text)
        ATualizarFonte()
    End Sub
    Private Sub ATualizarFonte()
        If Not EditandoTexto() Then Exit Sub
        Dim f As FontFamily = FontF(FN:=lblFonteNome.Text)
        If f Is Nothing Then
            MsgBox("A fonte:" & lblFonteNome.Text & " não está instalada neste computador.", vbInformation, "Acessar Dados do systema")
            f = If(FontF(FN:="Arial"), FontFamily.GenericSansSerif)
        End If
        Fonte(IT) = New Font(f, CSng(lblFonteTamanho.Text))
        FonteProj(IT) = New Font(f, TamanhoProjecao(CSng(lblFonteTamanho.Text)))
        CorFonte(IT) = Color.FromArgb(lblFonteCor.Text)
        CorPrench(IT) = Color.FromArgb(lblCorPreenchimento.Text)
        AplicarFonte(TextosPrevia()(IT), Fonte(IT), IT)
        If ProjecaoAtivada() Then
            AplicarFonte(TextosPrincipal()(IT), Fonte(IT), IT)
            AplicarFonte(TextosApresentacao()(IT), FonteProj(IT), IT)
        End If
    End Sub
    Private Sub AplicarFonte(Rotulo As Label, F As Font, Indice As Integer)
        Rotulo.Font = F
        Rotulo.ForeColor = CorFonte(Indice)
        Rotulo.BackColor = CorPrench(Indice)
    End Sub
    Private Sub txtEdicaoTexto_TextChanged(sender As Object, e As EventArgs) Handles txtEdicaoTexto.TextChanged 'Texto
        btnVoltarSalvar.Text = "Voltar"
        If Len(txtEdicaoTexto.Text) > 5 Then
            btnVoltarSalvar.Text = If(txtEdicaoId.Text = "N", "Salvar", "Alterar")
        End If
        If Not EditandoTexto() Then Exit Sub
        TextosPrevia()(IT).Text = txtEdicaoTexto.Text
        Textos(IT) = txtEdicaoTexto.Text
        If ProjecaoAtivada() Then
            TextosPrincipal()(IT).Text = Textos(IT)
            TextosApresentacao()(IT).Text = Textos(IT)
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
        Dim I As Integer = Array.FindIndex(ChecksTexto(), Function(c) c.Text = lblTipoTexto.Text) 'Título/Subtítulo/Corpo/Rodapé
        If I >= 0 Then
            CaixasTexto()(I).Text = txtEdicaoTexto.Text 'texto
            If txtEdicaoId.Text = "N" Then
                CaixasId()(I).Text = SalvarNovoTexto(Tx:=txtEdicaoTexto.Text, Tp:=lblTipoTexto.Text, Al:=lblAlinhamento.Text, Pr:=lblCorPreenchimento.Text, FN:=lblFonteNome.Text, FT:=lblFonteTamanho.Text, FE:=lblFonteEstilo.Text, FC:=lblFonteCor.Text)
            Else
                CaixasId()(I).Text = txtEdicaoId.Text 'numero
                SalvarAtualTexto(Nu:=CaixasId()(I).Text, Tx:=txtEdicaoTexto.Text, Tp:=lblTipoTexto.Text, Al:=lblAlinhamento.Text, Pr:=lblCorPreenchimento.Text, FN:=lblFonteNome.Text, FT:=lblFonteTamanho.Text, FE:=lblFonteEstilo.Text, FC:=lblFonteCor.Text)
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

    Private Sub chkTexto_CheckedChanged(sender As Object, e As EventArgs) Handles chkTitulo.CheckedChanged, chkSubtitulo.CheckedChanged, chkCorpo.CheckedChanged, chkRodape.CheckedChanged 'Selecionar Título/Subtítulo/Corpo/Rodapé
        Dim I As Integer = Array.IndexOf(ChecksTexto(), sender)
        If I < 0 Then Exit Sub
        Dim Ativo As Boolean = ChecksTexto()(I).Checked
        Dim Principal As Label = TextosPrincipal()(I)
        Dim Apresentacao As Label = TextosApresentacao()(I)
        BotoesEditar()(I).Visible = Ativo
        TextosPrevia()(I).Visible = Ativo
        TextActive(I) = Ativo
        If Not ProjecaoAtivada() Then Exit Sub
        If Ativo Then
            Principal.Text = CaixasTexto()(I).Text
            AplicarFonte(Principal, Fonte(I), I)
            Apresentacao.Text = CaixasTexto()(I).Text
            AplicarFonte(Apresentacao, FonteProj(I), I)
        Else
            Principal.Text = ""
            Principal.BackColor = Color.Transparent
            Apresentacao.Text = ""
            Apresentacao.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub trkZoom_Scroll(sender As Object, e As EventArgs) Handles trkZoom.Scroll
        ValPerc = trkZoom.Value
        ZoomTFundo = ValPerc
        lblZoom.Text = trkZoom.Value
        ATualizarFonteTextos()
    End Sub

    Private Sub ATualizarFonteTextos()
        Dim Apresentacao() As Label = TextosApresentacao()
        ValPerc = lblZoom.Text
        For II As Integer = 0 To 3
            If ChecksTexto()(II).Checked AndAlso CaixasId()(II).Text <> "" Then
                Dim Linha As DataRow = BuscarTexto(CLng(CaixasId()(II).Text))
                If Linha Is Nothing Then Continue For
                Dim f As FontFamily = If(FontF(FN:=Linha.Item(5).ToString), FontFamily.GenericSansSerif) 'fonte não instalada -> padrão
                FonteProj(II) = New Font(f, TamanhoProjecao(CSng(Linha.Item(6))))
                CorFonte(II) = Color.FromArgb(Linha.Item(8))
                CorPrench(II) = Color.FromArgb(Linha.Item(4))
                If ProjecaoAtivada() Then AplicarFonte(Apresentacao(II), FonteProj(II), II)
            End If
        Next
    End Sub
    'Procura um texto pelo ID (coluna 0) na tabela Textos
    Private Function BuscarTexto(ID As Long) As DataRow
        For Each Linha As DataRow In RegTextos.Rows
            If CLng(Linha.Item(0)) = ID Then Return Linha
        Next
        Return Nothing
    End Function

End Class