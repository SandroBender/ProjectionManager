Imports System.Security.Cryptography

Public Class FormBiblia
    Private Sub FormBiblia_Load(sender As Object, e As EventArgs) Handles Me.Load
        VerificarImportarReferencias() 'na 1ª vez: preenche as referências cruzadas nas Bíblias
        lblCreditoRef.Text = CreditoReferencias
        CarregarOpcoesImagem()
        ConectarDados()
        CarregarZoom()
        DesconectarDados()
        Dim Val As Integer = RegZoom.Rows(0).Item("TextoBiblia")
        lblZoom.Text = Val
        trkZoom.Value = Val
        FormApresentar.rtbBiblia.Font = New Font("Calibri", Val, style:=1)
        If lstLivros.DisplayMember = "" Then
            CarregarListaLivros()
            rbACF.Checked = True
            lstLivros.DataSource = ListaLivros
            lstLivros.ValueMember = "Indice"
            lstLivros.DisplayMember = "Livro"
        End If
        For i As Integer = 0 To ListaLivros.Rows.Count - 1
            cboLivroAssunto.Items.Add(ListaLivros.Rows(i).Item(1))
        Next
    End Sub

    Private Sub trkZoom_Scroll(sender As Object, e As EventArgs) Handles trkZoom.Scroll
        Dim Val As Integer = trkZoom.Value
        lblZoom.Text = Val
        ZoomTBiblia = Val
        FormApresentar.rtbBiblia.Font = New Font("Calibri", Val, style:=1)
    End Sub

    Private Sub lstLivros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstLivros.SelectedIndexChanged 'selecionar livro
        Dim I As Integer
        If lstLivros.DisplayMember <> "" Then
            I = lstLivros.SelectedIndex
            lblLivro.Text = ListaLivros.Rows(I).Item(1)
            Livro = lblLivro.Text
            rtbVersiculo.Clear()
            lblCapitulo.Text = "0"
            lblVersiculo.Text = "0"
            TextoBibliaCondensado = ""
            LivroCap()
        End If
    End Sub

    Private Sub rbACF_CheckedChanged(sender As Object, e As EventArgs) Handles rbACF.CheckedChanged 'Versão ACF
        If Not rbACF.Checked Then Exit Sub 'ignora o evento do botão que foi desmarcado
        VersaoBiblia = rbACF.Text
        TextoBibliaCondensado = ""
        If lblCapitulo.Text <> "0" Then Icap = CInt(lblCapitulo.Text) - 1
        If lblVersiculo.Text <> "0" Then Iver = CInt(lblVersiculo.Text) - 1
        CarregarBibliaCompleta()
        LivroCap()
        If Icap > 0 Then lstCapitulos.SelectedIndex = Icap
        If Iver > 0 Then lstVersiculos.SelectedIndex = Iver
    End Sub

    Private Sub rbNVI_CheckedChanged(sender As Object, e As EventArgs) Handles rbNVI.CheckedChanged 'Versão NVI
        If Not rbNVI.Checked Then Exit Sub 'ignora o evento do botão que foi desmarcado
        VerificarIgualarNvi() 'na 1ª vez: completa a NVI com as colunas que só a ACF tem
        VersaoBiblia = rbNVI.Text
        TextoBibliaCondensado = ""
        If lblCapitulo.Text <> "0" Then Icap = CInt(lblCapitulo.Text) - 1
        If lblVersiculo.Text <> "0" Then Iver = CInt(lblVersiculo.Text) - 1
        CarregarBibliaCompleta()
        LivroCap()
        If Icap > 0 Then lstCapitulos.SelectedIndex = Icap
        If Iver > 0 Then lstVersiculos.SelectedIndex = Iver
    End Sub

    Private Sub LivroCap()
        lstCapitulos.DataSource = Nothing
        lstVersiculos.DataSource = Nothing
        If Mid(lblLivro.Text, 1, 5) <> "Livro" And Mid(lblLivro.Text, 1, 5) <> "-----" Then
            CarregarLivro(Lv:=lblLivro.Text)
            lstCapitulos.DataSource = ListaCap
            lstCapitulos.ValueMember = "Indice"
            lstCapitulos.DisplayMember = "Indice"
        End If
    End Sub

    Private Sub lstCapitulos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCapitulos.SelectedIndexChanged 'Selecionar capítulo
        lstVersiculos.DataSource = Nothing
        Dim I As Integer = lstCapitulos.SelectedIndex
        If I > -1 Then
            lblCapitulo.Text = ListaCap.Rows(I).Item(0)
            rtbVersiculo.Clear()
            CarregarVer(Cap:=I + 1)
            lstVersiculos.DataSource = ListaVer
            lstVersiculos.ValueMember = "Indice"
            lstVersiculos.DisplayMember = "Indice"
        End If
    End Sub

    Private Sub lstVersiculos_Click(sender As Object, e As EventArgs) Handles lstVersiculos.Click 'Selecionar versículo(adicionar no histórico)
        If lstVersiculos.SelectedIndex > -1 Then
            ResultadoVer(Cap:=lstCapitulos.SelectedIndex + 1, Ver:=lstVersiculos.SelectedIndex + 1)
            lstHistorico.Items.Add(lstLivros.GetItemText(lstLivros.Text) & ";" & lstCapitulos.SelectedIndex + 1 & ";" & lstVersiculos.SelectedIndex + 1 & ";" & ResultVers)
        End If
    End Sub

    Private Sub lstVersiculos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstVersiculos.SelectedIndexChanged 'Selecionar versículo
        Resultado()
    End Sub

    Private Sub rbDesligado_CheckedChanged(sender As Object, e As EventArgs) Handles rbDesligado.CheckedChanged 'Desligado
        rbDesligado.BackColor = Color.Transparent
        rbLigado.BackColor = Color.Transparent
        btnRetroceder.BackColor = Color.FromArgb(204, 200, 215)
        btnAvancar.BackColor = Color.FromArgb(204, 200, 215)
        If rbDesligado.Checked = True Then
            rbDesligado.BackColor = Color.AliceBlue
            FormPrincipal.chkBiblia.Checked = False
        End If
        Transferir()
    End Sub

    Private Sub rbLigado_CheckedChanged(sender As Object, e As EventArgs) Handles rbLigado.CheckedChanged 'Ligado
        rbDesligado.BackColor = Color.Transparent
        rbLigado.BackColor = Color.Transparent
        btnRetroceder.BackColor = Color.FromArgb(204, 200, 215)
        btnAvancar.BackColor = Color.FromArgb(204, 200, 215)
        If rbLigado.Checked = True Then
            rbLigado.BackColor = Color.AliceBlue
            btnRetroceder.BackColor = Color.LightSteelBlue
            btnAvancar.BackColor = Color.LightSteelBlue
            FormPrincipal.chkBiblia.Checked = True
        End If
        Transferir()
    End Sub

    Private Sub Transferir()
        Dim I As Integer = lstLivros.SelectedIndex
        Biblia = False
        If rbLigado.Checked = True Then
            Biblia = True
            If FormPrincipal.rbAtivada.Checked = True Then
                FormPrincipal.rtbBiblia.Visible = True
                FormPrincipal.rtbBiblia.BringToFront()
                'FormPrincipal.rtbBiblia.Parent = FormPrincipal.picFundo
            End If
        ElseIf FormPrincipal.rbAtivada.Checked = True Then
            FormPrincipal.rtbBiblia.Visible = False
        End If
        AtualizaApresentacao()
    End Sub

    Private Sub btnRetroceder_Click(sender As Object, e As EventArgs) Handles btnRetroceder.Click 'Retroceder
        Dim I As Integer = lstVersiculos.SelectedIndex
        Aad = False
        If I > 0 Then
            I += -1
            lstVersiculos.SelectedIndex = I 'Aciona resultado
            txtSelecionado.Text = ""
        End If
    End Sub

    Private Sub btnAvancar_Click(sender As Object, e As EventArgs) Handles btnAvancar.Click 'Avançar
        Dim I As Integer = lstVersiculos.SelectedIndex
        Dim IT As Integer = lstVersiculos.Items.Count - 1
        Aad = False
        If I < IT Then
            I += 1
            lstVersiculos.SelectedIndex = I 'Aciona resultado
            txtSelecionado.Text = ""
        End If
    End Sub

    Private Sub btnAvancarAdicionando_Click(sender As Object, e As EventArgs) Handles btnAvancarAdicionando.Click 'Avançar Adicionando
        Dim I As Integer = lstVersiculos.SelectedIndex
        Dim IT As Integer = lstVersiculos.Items.Count - 1
        Aad = True
        If I < IT Then
            I += 1
            lstVersiculos.SelectedIndex = I 'Aciona resultado
            txtSelecionado.Text = ""
        End If
    End Sub

    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click 'Adicionar
        Dim AdicionarTexto As String = ""
        If tabPesquisa.SelectedIndex = 0 And lstResultados.Text <> "" Then AdicionarTexto = lstResultados.Text
        If tabPesquisa.SelectedIndex = 2 And lstHistorico.Text <> "" Then AdicionarTexto = lstHistorico.Text
        If tabPesquisa.SelectedIndex = 1 AndAlso ReferenciaSelecionada() IsNot Nothing AndAlso ReferenciaSelecionada().Texto <> "" Then
            AdicionarTexto = ReferenciaSelecionada().Livro & ";" & ReferenciaSelecionada().Cap & ";" & ReferenciaSelecionada().Ver & ";" & ReferenciaSelecionada().Texto
        End If
        Dim Ref() As String
        Ref = AdicionarTexto.Split(";")
        If Ref.Length < 4 Then Exit Sub 'nada selecionado ou formato inesperado
        Dim Livro As String = Ref(0).ToString
        Dim Cap As Integer = Ref(1).ToString
        Dim Ver As Integer = Ref(2).ToString
        Dim TextoVersiculo As String = String.Join(";", Ref, 3, Ref.Length - 3) 'o texto pode conter ";"
        TextoBibliaCondensado = TextoBibliaCondensado & "[" & Livro & " - " & Cap & ":" & Ver & "] " & TextoVersiculo
        rtbVersiculo.Text = TextoBibliaCondensado
        Aad = True
        Transferir()
        Aad = False
    End Sub

    Private Sub btnSubstituir_Click(sender As Object, e As EventArgs) Handles btnSubstituir.Click 'Substituir
        SubstituirResultado()
    End Sub

    Private Sub btnMostrarLocalizar_Click(sender As Object, e As EventArgs) Handles btnMostrarLocalizar.Click 'Ativar localizar
        If txtSelecionado.Visible = False Then
            tabPesquisa.Visible = True
            txtSelecionado.Visible = True
            tlpLocalizar.Visible = True
        Else
            tabPesquisa.Visible = False
            txtSelecionado.Visible = False
            tlpLocalizar.Visible = False
        End If
        FormPrincipal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub rbNaBiblia_CheckedChanged(sender As Object, e As EventArgs) Handles rbNaBiblia.CheckedChanged 'Localizar - Na bíblia
        If rbNaBiblia.Checked = True Then
            txtLocalizar.Visible = True
            'txtLocalizar.Text = ""
            LimparPesquisa()
            cboLivroAssunto.Visible = False
        End If
    End Sub

    Private Sub rbNoAssunto_CheckedChanged(sender As Object, e As EventArgs) Handles rbNoAssunto.CheckedChanged 'Localizar - No assunto
        If rbNoAssunto.Checked = True Then
            txtLocalizar.Visible = True
            'txtLocalizar.Text = ""
            LimparPesquisa()
            cboLivroAssunto.Visible = False
        End If
    End Sub

    Private Sub rbAssuntosPorLivro_CheckedChanged(sender As Object, e As EventArgs) Handles rbAssuntosPorLivro.CheckedChanged 'Localizar - Assuntos por livro
        If rbAssuntosPorLivro.Checked = True Then
            txtLocalizar.Text = ""
            LimparPesquisa()
            txtLocalizar.Visible = False
            cboLivroAssunto.Visible = True
        End If
    End Sub

    Private Sub txtLocalizar_TextChanged(sender As Object, e As EventArgs) Handles txtLocalizar.TextChanged 'Localizar texto
        Dim LC As Long = 0
        Dim T As String = txtLocalizar.Text
        LimparPesquisa()
        If Len(T) >= 3 Then
            If rbNaBiblia.Checked = True Then 'Na bíblia
                For L As Long = 0 To RegBiblia.Rows.Count - 1
                    If InStr(RegBiblia.Rows(L).Item(4), T, CompareMethod.Text) > 0 Then
                        lstResultados.Items.Add(RegBiblia.Rows(L).Item(1) & ";" & RegBiblia.Rows(L).Item(2) & ";" & RegBiblia.Rows(L).Item(3) & ";" & RegBiblia.Rows(L).Item(4))
                        LC += 1
                    End If
                Next
            End If
            If rbNoAssunto.Checked = True Then 'No assunto
                For L As Long = 0 To RegBiblia.Rows.Count - 1
                    If Not IsDBNull(RegBiblia.Rows(L).Item(5)) Then
                        If InStr(RegBiblia.Rows(L).Item(5), T, CompareMethod.Text) > 0 Then
                            lstResultados.Items.Add(RegBiblia.Rows(L).Item(1) & ";" & RegBiblia.Rows(L).Item(2) & ";" & RegBiblia.Rows(L).Item(3) & ";" & RegBiblia.Rows(L).Item(5))
                            LC += 1
                        End If
                    End If
                Next
            End If
        End If
        lblOcorrencias.Text = LC
        If LC > 0 Then
            btnLimpar.Visible = True
            btnAdicionar.Visible = True
            btnSubstituir.Visible = True
        End If
    End Sub


    Private Sub cboLivroAssunto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLivroAssunto.SelectedIndexChanged 'Seleção livro para assunto
        Dim LC As Long = 0
        Dim T As String = cboLivroAssunto.Text
        LimparPesquisa()
        If Len(T) >= 3 Then
            For L As Long = 0 To RegBiblia.Rows.Count - 1
                If Not IsDBNull(RegBiblia.Rows(L).Item(5)) Then
                    If T = RegBiblia.Rows(L).Item(1) Then
                        lstResultados.Items.Add(RegBiblia.Rows(L).Item(1) & ";" & RegBiblia.Rows(L).Item(2) & ";" & RegBiblia.Rows(L).Item(3) & ";" & RegBiblia.Rows(L).Item(5))
                        LC += 1
                    End If
                End If
            Next
        End If
        lblOcorrencias.Text = LC
        If LC > 0 Then
            btnLimpar.Visible = True
            btnAdicionar.Visible = True
            btnSubstituir.Visible = True
        End If
    End Sub

    Private Sub LimparPesquisa()
        lblOcorrencias.Text = "0"
        txtSelecionado.Text = ""
        btnLimpar.Visible = False
        btnAdicionar.Visible = False
        btnSubstituir.Visible = False
        If lstResultados.Items.Count > 0 Then lstResultados.Items.Clear()
    End Sub

    Private Sub tabPesquisa_Click(sender As Object, e As EventArgs) Handles tabPesquisa.Click 'Pequisa/Histórico
        btnLimpar.Visible = False
        btnAdicionar.Visible = False
        btnSubstituir.Visible = False
        If (tabPesquisa.SelectedIndex = 0 And lstResultados.Text <> "") Or (tabPesquisa.SelectedIndex = 2 And lstHistorico.Text <> "") Then
            btnLimpar.Visible = True
            btnAdicionar.Visible = True
            btnSubstituir.Visible = True
        End If
    End Sub


    Private Sub lstResultados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstResultados.SelectedIndexChanged 'Selecionar texto localizado
        txtSelecionado.Text = lstResultados.Text
        btnLimpar.Visible = True
        btnAdicionar.Visible = True
        btnSubstituir.Visible = True
    End Sub

    Private Sub lstHistorico_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstHistorico.SelectedIndexChanged 'Selecionar texto do histórico
        txtSelecionado.Text = lstHistorico.Text
        btnLimpar.Visible = True
        btnAdicionar.Visible = True
        btnSubstituir.Visible = True
    End Sub

    '---- Aba "Imagem": imagem ilustrativa do versículo na projeção ----
    Private OpcoesProntas As Boolean 'False enquanto a tela é criada/carregada (os eventos não podem gravar nada)
    Private BaixandoDore As Threading.CancellationTokenSource

    Private Sub CarregarOpcoesImagem()
        cboModoImagem.Items.AddRange({"Sem imagem", "Foco alternado", "Fundo esmaecido"})
        cboPosicaoTexto.Items.AddRange({"Topo", "Centro", "Embaixo"})
        cboModoImagem.SelectedItem = My.Settings.BibliaModoImagem
        If cboModoImagem.SelectedIndex < 0 Then cboModoImagem.SelectedIndex = 1
        cboPosicaoTexto.SelectedItem = My.Settings.BibliaPosicaoTexto
        If cboPosicaoTexto.SelectedIndex < 0 Then cboPosicaoTexto.SelectedIndex = 1
        nudTempoFoco.Value = Math.Max(nudTempoFoco.Minimum, Math.Min(nudTempoFoco.Maximum, My.Settings.BibliaTempoFoco))
        AtualizarEstadoOpcoes()
        OpcoesProntas = True
    End Sub

    Private Sub AtualizarEstadoOpcoes()
        nudTempoFoco.Enabled = cboModoImagem.Text = "Foco alternado"
        lblTempoFoco.Enabled = nudTempoFoco.Enabled
    End Sub

    'Salva a escolha e atualiza a projeção na hora
    Private Sub OpcaoImagem_Changed(sender As Object, e As EventArgs) Handles cboModoImagem.SelectedIndexChanged, cboPosicaoTexto.SelectedIndexChanged, nudTempoFoco.ValueChanged
        If Not OpcoesProntas Then Exit Sub
        AtualizarEstadoOpcoes()
        My.Settings.BibliaModoImagem = cboModoImagem.Text
        My.Settings.BibliaPosicaoTexto = cboPosicaoTexto.Text
        My.Settings.BibliaTempoFoco = CInt(nudTempoFoco.Value)
        My.Settings.Save()
        If Biblia Then AtualizaApresentacao()
    End Sub

    'Assunto mais próximo (o título de seção vale para os versículos seguintes)
    Private Function AssuntoDoVersiculo(Cap As Integer, Ver As Integer) As String
        Dim Assunto As String = ""
        If RegLivro Is Nothing Then Return Assunto
        For Each Linha As DataRow In RegLivro.Rows
            Dim C As Integer = CInt(Linha.Item(1)), V As Integer = CInt(Linha.Item(2))
            If C > Cap OrElse (C = Cap AndAlso V > Ver) Then Continue For
            Dim A As Object = ColunaOpcional(Linha, 4)
            If Not IsDBNull(A) AndAlso A.ToString().Trim() <> "" AndAlso (C < Cap OrElse V <= Ver) Then Assunto = A.ToString()
        Next
        Return Assunto
    End Function

    Private Sub EscolherImagem(Cap As Integer, Ver As Integer)
        ImagemBibliaAtual = ImagemPara(Livro, Cap, Ver, AssuntoDoVersiculo(Cap, Ver))
        MostrarPreviaImagem()
    End Sub

    Private Sub MostrarPreviaImagem()
        Dim Antiga As Image = picImagemBiblia.Image
        picImagemBiblia.Image = Nothing
        If Antiga IsNot Nothing Then Antiga.Dispose()
        If ImagemBibliaAtual Is Nothing Then
            lblImagemOrigem.Text = "Nenhuma imagem para este versículo."
            Exit Sub
        End If
        lblImagemOrigem.Text = ImagemBibliaAtual.Descricao
        Try
            picImagemBiblia.Image = CarregarImagem(ImagemBibliaAtual.Caminho)
        Catch ex As Exception
            lblImagemOrigem.Text = "Não foi possível abrir: " & IO.Path.GetFileName(ImagemBibliaAtual.Caminho)
        End Try
    End Sub

    Private Sub btnPastaImagens_Click(sender As Object, e As EventArgs) Handles btnPastaImagens.Click
        Dim Pasta As String = PastaImagensBiblia()
        IO.Directory.CreateDirectory(Pasta)
        Process.Start("explorer.exe", """" & Pasta & """")
    End Sub

    Private Sub btnRecarregarImagens_Click(sender As Object, e As EventArgs) Handles btnRecarregarImagens.Click
        RecarregarBiblioteca()
        If lstVersiculos.SelectedIndex > -1 Then EscolherImagem(CInt(lblCapitulo.Text), CInt(lblVersiculo.Text))
        lblImagemStatus.Text = "Biblioteca recarregada."
        If Biblia Then AtualizaApresentacao()
    End Sub

    Private Async Sub btnBaixarDore_Click(sender As Object, e As EventArgs) Handles btnBaixarDore.Click
        If BaixandoDore IsNot Nothing Then
            BaixandoDore.Cancel() 'o botão vira "Cancelar" durante o download
            Exit Sub
        End If
        If MsgBox("Baixar as 221 gravuras de Gustave Doré (domínio público) do Wikimedia Commons para a biblioteca de imagens?" & vbCrLf &
                  "São cerca de 100 MB; as que já existirem serão mantidas.", vbYesNo + vbQuestion, "Gravuras de Doré") <> MsgBoxResult.Yes Then Exit Sub
        BaixandoDore = New Threading.CancellationTokenSource()
        btnBaixarDore.Text = "Cancelar download"
        Try
            Dim R() As Integer = Await BaixarGravurasDore(Sub(t) lblImagemStatus.Text = t, BaixandoDore.Token)
            lblImagemStatus.Text = "Doré: " & R(0) & " baixadas, " & R(1) & " já existiam" & If(R(2) > 0, ", " & R(2) & " falharam (tente de novo)", "") &
                                   If(BaixandoDore.IsCancellationRequested, " - cancelado", "") & "."
        Catch ex As Exception
            lblImagemStatus.Text = "Erro no download: " & ex.Message
        Finally
            BaixandoDore.Dispose()
            BaixandoDore = Nothing
            btnBaixarDore.Text = "Baixar gravuras de Doré"
        End Try
        If lstVersiculos.SelectedIndex > -1 Then EscolherImagem(CInt(lblCapitulo.Text), CInt(lblVersiculo.Text))
        If Biblia Then AtualizaApresentacao()
    End Sub

    'Referências cruzadas do versículo exibido
    Private Sub MostrarReferencias()
        Dim Lista As List(Of ReferenciaBiblica) = ListarReferencias(ResultReferencia)
        lstReferencias.BeginUpdate()
        lstReferencias.Items.Clear()
        For Each R As ReferenciaBiblica In Lista
            lstReferencias.Items.Add(R)
        Next
        lstReferencias.EndUpdate()
        TabRef.Text = If(Lista.Count > 0, "Referências (" & Lista.Count & ")", "Referências")
    End Sub

    Private Function ReferenciaSelecionada() As ReferenciaBiblica
        Return TryCast(lstReferencias.SelectedItem, ReferenciaBiblica)
    End Function

    'Duplo clique: vai até o versículo referenciado
    Private Sub lstReferencias_DoubleClick(sender As Object, e As EventArgs) Handles lstReferencias.DoubleClick
        Dim R As ReferenciaBiblica = ReferenciaSelecionada()
        If R Is Nothing Then Exit Sub
        GuardarOrigem()
        IrParaVersiculo(R.Livro, R.Cap, R.Ver)
    End Sub

    '---- Voltar ao versículo de origem (pilha: dá para voltar passo a passo numa sequência de referências) ----
    Private Class Origem
        Public Livro As String
        Public Cap As Integer
        Public Ver As Integer
        Public IndiceRef As Integer 'referência que foi seguida (volta selecionada)
        Public Overrides Function ToString() As String
            Return NomeLivro(Livro) & " " & Cap & ":" & Ver
        End Function
    End Class
    Private ReadOnly Origens As New Stack(Of Origem)

    'Guarda o versículo atual antes de seguir uma referência
    Private Sub GuardarOrigem()
        If lstVersiculos.SelectedIndex < 0 OrElse lblCapitulo.Text = "0" OrElse lblVersiculo.Text = "0" Then Exit Sub
        Origens.Push(New Origem With {.Livro = Livro, .Cap = CInt(lblCapitulo.Text), .Ver = CInt(lblVersiculo.Text), .IndiceRef = lstReferencias.SelectedIndex})
        AtualizarBotaoVoltar()
    End Sub

    Private Sub AtualizarBotaoVoltar()
        btnVoltarOrigem.Visible = Origens.Count > 0
        If Origens.Count > 0 Then btnVoltarOrigem.Text = "« Voltar para " & Origens.Peek().ToString() & If(Origens.Count > 1, "  (" & Origens.Count & ")", "")
    End Sub

    Private Sub btnVoltarOrigem_Click(sender As Object, e As EventArgs) Handles btnVoltarOrigem.Click
        If Origens.Count = 0 Then Exit Sub
        Dim O As Origem = Origens.Pop()
        AtualizarBotaoVoltar()
        IrParaVersiculo(O.Livro, O.Cap, O.Ver)
        tabPesquisa.SelectedIndex = 1 'continua na aba Referências
        If O.IndiceRef >= 0 AndAlso O.IndiceRef < lstReferencias.Items.Count Then lstReferencias.SelectedIndex = O.IndiceRef
    End Sub

    Private Sub lstReferencias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstReferencias.SelectedIndexChanged 'Selecionar Referencia de versículo
        Dim R As ReferenciaBiblica = ReferenciaSelecionada()
        If R Is Nothing Then Exit Sub
        txtSelecionado.Text = R.Referencia & "  " & R.Texto
        btnLimpar.Visible = True
        btnAdicionar.Visible = True
        btnSubstituir.Visible = True
    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click 'Limpar histórico
        If tabPesquisa.SelectedIndex = 0 Then
            txtLocalizar.Text = ""
        Else
            lstHistorico.Items.Clear()
        End If
        txtSelecionado.Text = ""
        btnLimpar.Visible = False
        btnAdicionar.Visible = False
        btnSubstituir.Visible = False
    End Sub

    Private Sub Resultado()
        Dim V As Integer = lstVersiculos.SelectedIndex
        Dim VI As Integer = V + 2
        Dim VF As Integer = lstVersiculos.Items.Count
        Dim C As Integer = lstCapitulos.SelectedIndex
        If V > -1 Then
            lblVersiculo.Text = ListaVer.Rows(V).Item(0)
            rtbVersiculo.Clear()
            rtbAnteriores.Clear()
            rtbPosteriores.Clear()
            ResultadoVer(Cap:=C + 1, Ver:=V + 1)
            MostrarReferencias()
            EscolherImagem(C + 1, V + 1)
            TextoBiblia = vbTab & vbTab & ResultRef1 & " [" & VersaoBiblia & "]" & vbLf & vbLf & ResultVers
            If Aad = False Then
                rtbVersiculo.Text = TextoBiblia
                TextoBibliaCondensado = "[" & ResultRef1 & "] " & ResultVers
            Else
                rtbVersiculo.Text = TextoBibliaCondensado & "[" & ResultRef1 & "] " & ResultVers
                TextoBibliaCondensado = TextoBibliaCondensado & "[" & ResultRef1 & "] " & ResultVers
            End If
            TextoBibliaAnterior = ""
            TextoBibliaPosterior = ""
            Dim Anterior As New System.Text.StringBuilder
            For I As Integer = 1 To V 'versículos antes do selecionado
                Dim Linha As DataRow = BuscarVersiculo(C + 1, I)
                If Linha IsNot Nothing Then Anterior.Append(" [ " & I & " ] " & Linha.Item(3).ToString)
            Next
            Dim Posterior As New System.Text.StringBuilder
            For I As Integer = VI To VF 'versículos depois do selecionado
                Dim Linha As DataRow = BuscarVersiculo(C + 1, I)
                If Linha IsNot Nothing Then Posterior.Append(" [ " & I & " ] " & Linha.Item(3).ToString)
            Next
            TextoBibliaAnterior = Anterior.ToString
            TextoBibliaPosterior = Posterior.ToString
            rtbAnteriores.Text = TextoBibliaAnterior
            rtbPosteriores.Text = TextoBibliaPosterior
        End If
        Transferir()
        Aad = False
    End Sub

    Private Sub SubstituirResultado()
        Dim SubstituirTexto As String = ""
        If tabPesquisa.SelectedIndex = 0 And lstResultados.Text <> "" Then SubstituirTexto = lstResultados.Text 'localizar
        If tabPesquisa.SelectedIndex = 2 And lstHistorico.Text <> "" Then SubstituirTexto = lstHistorico.Text 'histórico
        If tabPesquisa.SelectedIndex = 1 AndAlso ReferenciaSelecionada() IsNot Nothing Then 'referencia bíblica
            Dim R As ReferenciaBiblica = ReferenciaSelecionada()
            SubstituirTexto = R.Livro & ";" & R.Cap & ";" & R.Ver
            GuardarOrigem()
        End If
        Dim Ref() As String = SubstituirTexto.Split(";")
        If Ref.Length < 3 Then Exit Sub 'nada selecionado ou formato inesperado
        IrParaVersiculo(Ref(0), CInt(Ref(1)), CInt(Ref(2)))
        txtSelecionado.Text = SubstituirTexto
        btnLimpar.Visible = True
        btnAdicionar.Visible = True
        btnSubstituir.Visible = True
    End Sub

    'Seleciona livro, capítulo e versículo nas listas (o que dispara a exibição do versículo)
    Private Sub IrParaVersiculo(Livro As String, Cap As Integer, Ver As Integer)
        For I As Integer = 0 To ListaLivros.Rows.Count - 1
            If Livro.Equals(ListaLivros.Rows(I).Item(1).ToString, StringComparison.OrdinalIgnoreCase) Then lstLivros.SelectedIndex = I
        Next
        For I As Integer = 0 To ListaCap.Rows.Count - 1
            If Cap = ListaCap.Rows(I).Item(0) Then lstCapitulos.SelectedIndex = I
        Next
        For I As Integer = 0 To ListaVer.Rows.Count - 1
            If Ver = ListaVer.Rows(I).Item(0) Then lstVersiculos.SelectedIndex = I 'Aciona Resultado
        Next
    End Sub

End Class