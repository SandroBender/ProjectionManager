Imports System.ComponentModel
Imports System.IO

Public Class FormPrincipal
    Private Sub FormPrincipal_Load(sender As Object, e As EventArgs) Handles Me.Load
        SistemaCarregado = DefinirLocalSistema()
        If Not SistemaCarregado Then
            MsgBox("Sem a pasta do sistema o programa não pode continuar e será fechado.", vbCritical, "Dados do systema")
            Close()
            Exit Sub
        End If
        ConexDados = New OleDb.OleDbConnection(StringConexao(My.Settings.ArqDados))
        ConexHarpa = New OleDb.OleDbConnection(StringConexao(My.Settings.ArqHarpa))
        ConexNVI = New OleDb.OleDbConnection(StringConexao(My.Settings.ArqBibliaNVI))
        ConexACF = New OleDb.OleDbConnection(StringConexao(My.Settings.ArqBibliaACF))
        GravarLocalSistema()
        Dim I As Integer
        'Dim Monitor() As Screen = Screen.AllScreens
        'Dim TM As Integer = Screen.AllScreens.Count
        'Dim SecondaryMonitor = Screen.AllScreens.FirstOrDefault(Function(x) Not x.Primary)
        Dim primaryScreen = Screen.PrimaryScreen
        Dim allScreens = Screen.AllScreens
        For Each screen In allScreens
            If screen IsNot primaryScreen Then
                ComboMonitor.Items.Add(I & " - " & screen.DeviceName)
            End If
            I += 1
        Next
        If ComboMonitor.Items.Count = 0 Then
            'TelaUnica = True
            ComboMonitor.Items.Add("0-Apenas monitor principal")
            MsgBox("Apenas monitor principal detectado.", vbExclamation, "Gerenciador de Projeção")
        End If
        ComboMonitor.SelectedIndex = 0
        'If SecondaryMonitor IsNot Nothing Then
        '    'Dim newLocation = SecondaryMonitor.Bounds.Location
        '    'newLocation.Offset(100, 100) ' adjust as needed
        '    'Me.Location = newLocation
        '    TelaUnica = False
        '    For I = 0 To TM - 1
        '        ComboMonitor.Items.Add(Monitor(I).DeviceName)
        '    Next
        '    ComboMonitor.SelectedIndex = 1
        'Else
        '    'TelaUnica = True
        '    ComboMonitor.Items.Add("Apenas 1 monitor detectado")
        '    MsgBox("Apenas monitor principal detectado.", vbExclamation, "Gerenciador de Projeção")
        'End If
        lblTitulo.Parent = picFundo 'CRIAR transparencia dos textos
        lblSubtitulo.Parent = picFundo
        lblCorpo.Parent = picFundo
        lblRodape.Parent = picFundo
        'lblStatusVideo.Parent = picSobreposicao
        lblTitulo.Location = New Point(2, 2) 'POSIÇÃO
        lblSubtitulo.Location = New Point(2, 33)
        lblCorpo.Location = New Point(2, 58)
        lblRodape.Location = New Point(2, 196)
        If Not Directory.Exists(LocalSystem & lblPastaPadrao.Text) Then
            MsgBox("Pasta padrão de salvamento não encontrada. Reestabeleça o caminho ou selecione outra pasta.", vbCritical, "Salvar Dados do systema")
            btnSalvarImagem.Enabled = False
        Else
            lblLocalSalvamento.Text = LocalSystem & lblPastaPadrao.Text
        End If
        rbNeutra.Checked = True
    End Sub
    Private Sub AbrirFormNoPainel(Of Miform As {Form, New})()
        Dim Formulario As Form
        Formulario = PainelControle.Controls.OfType(Of Miform)().FirstOrDefault() 'Selecionar formulario
        If Formulario Is Nothing Then
            Formulario = New Miform()
            Formulario.TopLevel = False
            Formulario.FormBorderStyle = FormBorderStyle.None
            Formulario.Dock = DockStyle.Fill
            PainelControle.Controls.Add(Formulario)
            PainelControle.Tag = Formulario
            Formulario.Show()
            Formulario.BringToFront()
        Else
            Formulario.BringToFront()
        End If
    End Sub
    Private Sub ComboMonitor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboMonitor.SelectedIndexChanged
        Dim Im As Integer
        If ComboMonitor.Text <> "" Then
            If FormApresentar.Visible = True Then FormApresentar.Close()
            Im = Mid(ComboMonitor.Text, 1, 1)
            FormApresentar.Bounds = Screen.AllScreens(Im).Bounds
            FormApresentar.StartPosition = FormStartPosition.Manual
            FormApresentar.Show()
        End If
    End Sub
    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnFundo.Click, btnHarpa.Click, btnBiblia.Click, btnImagens.Click, btnAudioVideo.Click, btnInternet.Click
        If sender Is btnFundo Then AbrirFormNoPainel(Of FormFundo)()
        If sender Is btnHarpa Then AbrirFormNoPainel(Of FormHarpa)()
        If sender Is btnBiblia Then AbrirFormNoPainel(Of FormBiblia)()
        If sender Is btnImagens Then AbrirFormNoPainel(Of FormImagens)()
        If sender Is btnAudioVideo Then AbrirFormNoPainel(Of FormVideos)()
        If sender Is btnInternet Then AbrirFormNoPainel(Of FormInternet)()
        For Each Botao As Button In {btnFundo, btnHarpa, btnBiblia, btnImagens, btnAudioVideo, btnInternet} 'destaca o botão do painel aberto
            Botao.BackColor = If(Botao Is sender, Color.DarkSlateBlue, Color.Transparent)
        Next
    End Sub

    Private Sub DestacarEstado() 'destaca o estado selecionado da janela de projeção
        For Each Estado As RadioButton In {rbAtivada, rbPausada, rbNeutra, rbFechada}
            Estado.BackColor = If(Estado.Checked, Color.LightSteelBlue, Color.FromArgb(143, 134, 153))
        Next
    End Sub
    Private Sub LimparTextos()
        picFundo.Image = Nothing 'imagem fundo
        For Each Rotulo As Label In TextosPrincipal()
            Rotulo.Text = ""
            Rotulo.BackColor = Color.Transparent
        Next
    End Sub

    Private Sub btnEscolherPasta_Click(sender As Object, e As EventArgs) Handles btnEscolherPasta.Click 'Selecionar outra pasta
        Dim OFds As New FolderBrowserDialog With {.ShowNewFolderButton = False, .RootFolder = Environment.SpecialFolder.MyComputer}
        If OFds.ShowDialog = DialogResult.OK Then lblLocalSalvamento.Text = OFds.SelectedPath
        btnSalvarImagem.Enabled = True
    End Sub
    Private Sub rbAtivada_CheckedChanged(sender As Object, e As EventArgs) Handles rbAtivada.CheckedChanged 'ATIVADA
        DestacarEstado()
        If rbAtivada.Checked = True Then
            If ImageF = True And File.Exists(ImageFundo) Then picFundo.Image = CarregarImagem(ImageFundo)
            If ImageS = True And picSobreposicao.Visible = True And File.Exists(ImageSobre) Then picSobreposicao.Image = CarregarImagem(ImageSobre)
            If ImageA = True And picAudio.Visible = True And File.Exists(ImageAudio) Then picAudio.Image = CarregarImagem(ImageAudio)
            For I As Integer = 0 To 3
                Dim Rotulo As Label = TextosPrincipal()(I)
                If TextActive(I) = True And Textos(I) IsNot Nothing Then
                    Rotulo.Text = Textos(I)
                    Rotulo.TextAlign = Alinham(I)
                    Rotulo.Font = Fonte(I)
                    Rotulo.ForeColor = CorFonte(I)
                    Rotulo.BackColor = CorPrench(I)
                Else
                    Rotulo.Text = ""
                End If
            Next
        End If
        AtualizaApresentacao()
    End Sub
    Private Sub rbPausada_CheckedChanged(sender As Object, e As EventArgs) Handles rbPausada.CheckedChanged 'PAUSADA
        DestacarEstado()
        If Not rbPausada.Checked Then Exit Sub 'ignora o evento de quando "Pausada" é desmarcada
        If MidiaAtual() <> "" Then
            lblStatusVideo.Text = "VIDEO PAUSADO"
            If FormApresentar.wmpVideo.playState = WMPLib.WMPPlayState.wmppsPlaying Then FormApresentar.wmpVideo.Ctlcontrols.pause()
        End If
        If PaginaInternetAtiva() Then
            lblStatusVideo.Text = "INTERNET PAUSADA"
            PausarPaginaProjecao()
        End If
    End Sub
    Private Sub rbNeutra_CheckedChanged(sender As Object, e As EventArgs) Handles rbNeutra.CheckedChanged 'NEUTRO
        DestacarEstado()
        If rbNeutra.Checked = True Then
            LimparTextos()
        End If
        AtualizaApresentacao()
    End Sub
    Private Sub rbFechada_CheckedChanged(sender As Object, e As EventArgs) Handles rbFechada.CheckedChanged ' FECHADO
        DestacarEstado()
        If rbFechada.Checked = True Then
            LimparTextos()
        End If
        FormApresentar.Close()
    End Sub


    Private Sub rtbHarpa_TextChanged(sender As Object, e As EventArgs) Handles rtbHarpa.TextChanged
        If rbAtivada.Checked = True Then
            FormApresentar.rtbHarpa.Text = rtbHarpa.Text
            FormApresentar.rtbHarpa.SelectAll()
            FormApresentar.rtbHarpa.SelectionAlignment = HorizontalAlignment.Center
            FormApresentar.rtbHarpa.DeselectAll()
        End If
    End Sub

    Private Sub chkFundo_CheckedChanged(sender As Object, e As EventArgs) Handles chkFundo.CheckedChanged
        chkFundo.BackColor = Color.Transparent
        If chkFundo.Checked = True Then chkFundo.BackColor = Color.SlateBlue
    End Sub

    Private Sub chkHarpa_CheckedChanged(sender As Object, e As EventArgs) Handles chkHarpa.CheckedChanged 'Harpa
        chkHarpa.BackColor = Color.Transparent
        If chkHarpa.Checked = True Then chkHarpa.BackColor = Color.SlateBlue
    End Sub

    Private Sub chkBiblia_CheckedChanged(sender As Object, e As EventArgs) Handles chkBiblia.CheckedChanged
        chkBiblia.BackColor = Color.Transparent
        If chkBiblia.Checked = True Then chkBiblia.BackColor = Color.SlateBlue
    End Sub

    Private Sub chkImagens_CheckedChanged(sender As Object, e As EventArgs) Handles chkImagens.CheckedChanged
        chkImagens.BackColor = Color.Transparent
        If chkImagens.Checked = True Then chkImagens.BackColor = Color.SlateBlue
    End Sub

    Private Sub chkInternet_CheckedChanged(sender As Object, e As EventArgs) Handles chkInternet.CheckedChanged
        chkInternet.BackColor = Color.Transparent
        If chkInternet.Checked = True Then chkInternet.BackColor = Color.SlateBlue
    End Sub

    Private Sub chkAudioVideo_CheckedChanged(sender As Object, e As EventArgs) Handles chkAudioVideo.CheckedChanged
        chkAudioVideo.BackColor = Color.Transparent
        If chkAudioVideo.Checked = True Then chkAudioVideo.BackColor = Color.SlateBlue
    End Sub

    Private Sub btnSalvarImagem_Click(sender As Object, e As EventArgs) Handles btnSalvarImagem.Click 'Salvar imagem
        If FormApresentar.Visible = True Then
            Dim Local As String = lblLocalSalvamento.Text
            Dim Nome As String = "Imagem " & DateTime.Now.ToString("dd-MM-yyyy HHmmss") & ".jpeg"
            Dim Frm As Form = FormApresentar
            Try
                Using Img As New Bitmap(Frm.Bounds.Width, Frm.Bounds.Height) 'tamanho real da tela de projeção
                    Using Gph As Graphics = Graphics.FromImage(Img)
                        Gph.CopyFromScreen(Frm.Bounds.Location, Point.Empty, Img.Size)
                    End Using
                    Img.Save(Path.Combine(Local, Nome), Imaging.ImageFormat.Jpeg)
                End Using
            Catch ex As Exception
                MsgBox(ex.Message, vbCritical, "Salvar imagem")
            End Try
        End If
    End Sub

    Private Sub btnOpcoes_Click(sender As Object, e As EventArgs) Handles btnOpcoes.Click 'Opções

    End Sub

    Private Sub FormPrincipal_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If FormApresentar.Visible = True Then FormApresentar.Close()
    End Sub

    Private Sub FormPrincipal_Closed(sender As Object, e As EventArgs) Handles Me.Closed 'Fechar programa
        If Not SistemaCarregado Then Exit Sub 'nada foi aberto
        ConectarDados()
        If ZoomTFundo > 0 Then SalvarZoom("TextoFundo", ZoomTFundo)
        If ZoomTHarpa > 0 Then SalvarZoom("TextoHarpa", ZoomTHarpa)
        If ZoomTBiblia > 0 Then SalvarZoom("TextoBiblia", ZoomTBiblia)
        DesconectarDados()
    End Sub

    Private Sub SalvarZoom(Coluna As String, Valor As Integer) 'Coluna vem apenas do código (não do usuário)
        Try
            Using Comando As New OleDb.OleDbCommand("UPDATE Zoom SET " & Coluna & " = ? WHERE ID = 1", ConexDados)
                Comando.Parameters.AddWithValue("@Valor", Valor)
                Comando.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Salvar Dados do systema")
        End Try
    End Sub


End Class
