Imports System.Data.OleDb

'Tela "Internet": abre páginas, vídeos do YouTube e arquivos de vídeo/áudio da internet
'e envia para a projeção, seguindo os estados Ativada/Pausada/Neutra/Fechada.
Public Class FormInternet
    Private LinkAtual As InfoLink 'link aberto nesta tela (Nothing = nenhum)

    Private Sub FormInternet_Load(sender As Object, e As EventArgs) Handles Me.Load
        rbDesligado.Checked = True
        CarregarFavoritos()
    End Sub

    '---- Abrir link ----
    Private Sub btnAbrir_Click(sender As Object, e As EventArgs) Handles btnAbrir.Click
        AbrirLink(txtLink.Text)
    End Sub

    Private Sub txtLink_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLink.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True 'evita o "bip" do Enter
            AbrirLink(txtLink.Text)
        End If
    End Sub

    Private Sub btnColar_Click(sender As Object, e As EventArgs) Handles btnColar.Click
        If Not Clipboard.ContainsText() Then
            MsgBox("A área de transferência não tem nenhum link copiado.", vbInformation, "Internet")
            Exit Sub
        End If
        txtLink.Text = Clipboard.GetText().Trim()
        AbrirLink(txtLink.Text)
    End Sub

    Private Async Sub AbrirLink(Texto As String)
        Dim Info As InfoLink = InterpretarLink(Texto)
        If Info Is Nothing Then
            lblTipoLink.ForeColor = Color.DarkRed
            lblTipoLink.Text = "Link inválido. Exemplos: https://www.youtube.com/watch?v=...   www.site.com.br   https://site.com/video.mp4"
            Exit Sub
        End If
        If Info.EhMidia AndAlso Not FormatoSuportado(Info.Projetar) Then
            lblTipoLink.ForeColor = Color.DarkRed
            lblTipoLink.Text = Info.Descricao & " - formato não suportado: converta para MP4 (vídeo) ou MP3 (áudio)"
            AvisarFormato(Info.Projetar)
            Exit Sub
        End If
        lblTipoLink.ForeColor = Color.Black
        lblTipoLink.Text = Info.Descricao & If(Info.EhMidia, " - toca na projeção", "")
        txtLink.Text = Info.Original
        LinkAtual = Info
        Transferir() 'se estiver Ligado, a projeção passa para o novo link
        Await Navegar(webPrevia, Info.Previa, True)
    End Sub

    '---- Ligado / Desligado ----
    Private Sub rbOperacao_CheckedChanged(sender As Object, e As EventArgs) Handles rbDesligado.CheckedChanged, rbLigado.CheckedChanged
        If Not DirectCast(sender, RadioButton).Checked Then Exit Sub 'ignora o botão desmarcado
        rbDesligado.BackColor = If(rbDesligado.Checked, Color.AliceBlue, Color.Transparent)
        rbLigado.BackColor = If(rbLigado.Checked, Color.AliceBlue, Color.Transparent)
        If rbLigado.Checked AndAlso LinkAtual Is Nothing Then
            lblTipoLink.ForeColor = Color.DarkRed
            lblTipoLink.Text = "Abra um link para enviá-lo à projeção."
        End If
        Transferir()
    End Sub

    Private Sub Transferir()
        InternetLink = LinkAtual
        InternetOn = rbLigado.Checked AndAlso LinkAtual IsNot Nothing
        FormPrincipal.chkInternet.Checked = InternetOn
        AtualizaApresentacao()
    End Sub

    '---- Favoritos (tabela Links do banco PMSystem) ----
    Private Sub CarregarFavoritos()
        ConectarDados()
        Try
            GarantirTabelaLinks()
            Using Adaptador As New OleDbDataAdapter("SELECT [ID], [Titulo], [Link] FROM [Links] ORDER BY [Titulo]", ConexDados)
                Dim Tabela As New DataTable
                Adaptador.Fill(Tabela)
                lstFavoritos.DataSource = Nothing
                lstFavoritos.DisplayMember = "Titulo"
                lstFavoritos.ValueMember = "ID"
                lstFavoritos.DataSource = Tabela
                lstFavoritos.SelectedIndex = -1
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Favoritos da Internet")
        Finally
            DesconectarDados()
        End Try
    End Sub

    'Cria a tabela de favoritos na primeira vez que a tela é usada
    Private Sub GarantirTabelaLinks()
        Dim Tabelas As DataTable = ConexDados.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, "Links", "TABLE"})
        If Tabelas.Rows.Count > 0 Then Exit Sub
        Using Comando As New OleDbCommand("CREATE TABLE [Links] ([ID] COUNTER PRIMARY KEY, [Titulo] TEXT(255), [Link] MEMO)", ConexDados)
            Comando.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub btnFavoritar_Click(sender As Object, e As EventArgs) Handles btnFavoritar.Click
        If LinkAtual Is Nothing Then
            MsgBox("Abra um link antes de adicioná-lo aos favoritos.", vbInformation, "Favoritos da Internet")
            Exit Sub
        End If
        Dim Titulo As String = InputBox("Nome do favorito:", "Favoritos da Internet", LinkAtual.Descricao).Trim()
        If Titulo = "" Then Exit Sub 'cancelado
        If Titulo.Length > 255 Then Titulo = Titulo.Substring(0, 255)
        ConectarDados()
        Try
            Using Comando As New OleDbCommand("INSERT INTO [Links] ([Titulo], [Link]) VALUES (?, ?)", ConexDados)
                Comando.Parameters.AddWithValue("@Titulo", Titulo)
                Comando.Parameters.AddWithValue("@Link", LinkAtual.Original)
                Comando.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Favoritos da Internet")
        Finally
            DesconectarDados()
        End Try
        CarregarFavoritos()
    End Sub

    Private Sub btnRemoverFavorito_Click(sender As Object, e As EventArgs) Handles btnRemoverFavorito.Click
        Dim Item As DataRowView = TryCast(lstFavoritos.SelectedItem, DataRowView)
        If Item Is Nothing Then
            MsgBox("Selecione um favorito para remover.", vbInformation, "Favoritos da Internet")
            Exit Sub
        End If
        If MsgBox("Remover o favorito """ & Item("Titulo").ToString & """?", vbYesNo + vbQuestion, "Favoritos da Internet") <> MsgBoxResult.Yes Then Exit Sub
        ConectarDados()
        Try
            Using Comando As New OleDbCommand("DELETE FROM [Links] WHERE [ID] = ?", ConexDados)
                Comando.Parameters.AddWithValue("@ID", Item("ID"))
                Comando.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Favoritos da Internet")
        Finally
            DesconectarDados()
        End Try
        CarregarFavoritos()
    End Sub

    'Duplo clique abre (um clique só seleciona, para não trocar a projeção sem querer)
    Private Sub lstFavoritos_DoubleClick(sender As Object, e As EventArgs) Handles lstFavoritos.DoubleClick
        Dim Item As DataRowView = TryCast(lstFavoritos.SelectedItem, DataRowView)
        If Item Is Nothing Then Exit Sub
        txtLink.Text = Item("Link").ToString
        AbrirLink(txtLink.Text)
    End Sub

End Class
