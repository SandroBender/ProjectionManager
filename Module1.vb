Imports System.Data.OleDb
Imports System.Drawing.Text
Imports System.IO
Module Module1
    Public MyDocSystem As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    Public AlternativeSystem As String = My.Settings.LocalAlternativoSistema
    Public LocalSystem As String
    Public ConexDados As New OleDbConnection
    Public ConexHarpa As New OleDbConnection
    Public ConexACF As New OleDbConnection
    Public ConexNVI As New OleDbConnection
    Public RegHarpa As New DataTable
    Public ListaHarpa As New DataTable
    Public ListaLivros As New DataTable
    Public ListaCap As New DataTable
    Public ListaVer As New DataTable
    Public RegLivro As New DataTable
    Public RegBiblia As New DataTable
    Public FilteredTable As New DataTable 'tabela consulta da biblia
    Public VersaoBiblia As String
    Public Livro As String
    Public Icap As Integer
    Public Iver As Integer
    Public ResultVers As String
    Public ResultRef1 As String 'Livro-Cap-vers
    Public ResultRef2 As String 'Cap-vers
    Public ResultReferencia As String 'Referencia bíblica
    Public BARef As Integer 'Botão avançar versículo
    Public RegTextos As New DataTable
    Public RegTipoTexto As New DataTable
    Public RegImagens As New DataTable
    Public RegZoom As New DataTable
    Public ImageFundo As String = String.Empty
    Public ImageSobre As String = String.Empty
    Public ImageAudio As String = String.Empty
    Public Video As String = String.Empty
    Public ImageF As Boolean 'imagem fundo
    Public ImageS As Boolean 'imagem sobreposição
    Public ImageA As Boolean 'imagem audio/video
    Public VideoOn As Boolean
    Public Harpa As Boolean
    Public TextoHarpa As String
    Public Biblia As Boolean
    Public TextoBiblia As String
    Public TextoBibliaCondensado As String
    Public TextoBibliaAnterior As String
    Public TextoBibliaPosterior As String
    Public Textos(3) As String
    Public TextActive(3) As Boolean
    Public Fonte(3) As Font
    Public FonteProj(3) As Font
    Public CorPrench(3) As Color
    Public CorFonte(3) As Color
    Public Alinham(3) As ContentAlignment
    Public IT As Integer = 10 'Indice do texto em edição
    Public AjusteDimensional As String = "S"
    Public TelaUnica As Boolean
    Public ZoomTFundo As Integer
    Public ZoomTHarpa As Integer
    Public ZoomTBiblia As Integer
    Public Aad As Boolean
    'Cache das imagens já carregadas (evita recarregar o arquivo a cada atualização)
    Private CacheFundoCam As String = String.Empty
    Private CacheFundoImg As Image
    Private CacheSobreCam As String = String.Empty
    Private CacheSobreImg As Image
    Private CacheAudioCam As String = String.Empty
    Private CacheAudioImg As Image

    'Monta a string de conexão do Access. A senha NÃO fica no código-fonte:
    'é lida do arquivo "senha.txt" (primeira linha) na pasta SISTEMA.
    Public Function StringConexao(Arquivo As String) As String
        Dim Pasta As String = LocalSystem & My.Settings.PastaSistema
        Return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Pasta & Arquivo & ";Jet OLEDB:Database Password=" & LerSenhaBanco(Pasta)
    End Function

    Private SenhaBanco As String = Nothing
    Private Function LerSenhaBanco(Pasta As String) As String
        If SenhaBanco IsNot Nothing Then Return SenhaBanco
        Dim Arq As String = Path.Combine(Pasta, "senha.txt")
        SenhaBanco = String.Empty
        Try
            If File.Exists(Arq) Then
                SenhaBanco = File.ReadAllLines(Arq).FirstOrDefault()?.Trim()
                If SenhaBanco Is Nothing Then SenhaBanco = String.Empty
            Else
                MsgBox("Arquivo de senha dos bancos não encontrado em: " & Arq & vbCrLf &
                       "Crie esse arquivo com a senha dos arquivos .accdb na primeira linha.", vbCritical, "Dados do systema")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Ler senha dos bancos")
        End Try
        Return SenhaBanco
    End Function

    'Carrega uma imagem sem deixar o arquivo bloqueado em disco.
    Public Function CarregarImagem(Caminho As String) As Image
        Using fs As New FileStream(Caminho, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
            Using Img As Image = Image.FromStream(fs)
                Return New Bitmap(Img)
            End Using
        End Using
    End Function

    'Igual a CarregarImagem, mas reaproveita a imagem se o caminho não mudou.
    Private Function ImagemEmCache(Caminho As String, ByRef CacheCam As String, ByRef CacheImg As Image) As Image
        If CacheImg Is Nothing OrElse Not String.Equals(CacheCam, Caminho, StringComparison.OrdinalIgnoreCase) Then
            CacheImg = CarregarImagem(Caminho)
            CacheCam = Caminho
        End If
        Return CacheImg
    End Function

    Public Sub ConectarHarpa()
        Try
            ConexHarpa.Open()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Acessar Harpa Cristã")
        End Try
    End Sub

    Public Sub DesconectarHarpa()
        ConexHarpa.Close()
    End Sub

    Public Sub ConectarACF()
        Try
            ConexACF.Open()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Acessar Biblia ACF")
        End Try
    End Sub

    Public Sub DesconectarACF()
        ConexACF.Close()
    End Sub

    Public Sub ConectarNVI()
        Try
            ConexNVI.Open()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Acessar Biblia NVI")
        End Try
    End Sub

    Public Sub DesconectarNVI()
        ConexNVI.Close()
    End Sub

    Public Sub ConectarDados()
        Try
            ConexDados.Open()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Acessar Dados do systema")
        End Try
    End Sub

    Public Sub DesconectarDados()
        ConexDados.Close()
    End Sub

    Public Sub CarregarImagens()
        Dim Adaptador As OleDbDataAdapter
        Dim SQL As String = "SELECT * FROM Imagens"
        Adaptador = New OleDbDataAdapter(SQL, ConexDados)
        RegImagens = New DataTable
        Adaptador.Fill(RegImagens)
    End Sub
    Public Sub CarregarTextos()
        Dim Adaptador As OleDbDataAdapter
        Dim SQL As String = "SELECT * FROM Textos"
        Adaptador = New OleDbDataAdapter(SQL, ConexDados)
        RegTextos = New DataTable
        Adaptador.Fill(RegTextos)
    End Sub
    Public Sub CarregarZoom()
        Dim Adaptador As OleDbDataAdapter
        Dim SQL As String = "SELECT * FROM Zoom"
        Adaptador = New OleDbDataAdapter(SQL, ConexDados)
        RegZoom = New DataTable
        Adaptador.Fill(RegZoom)
    End Sub
    Public Sub CarregarHarpa() 'Completa e lista resumida
        Dim Adaptador As OleDbDataAdapter
        Dim SQL As String = "SELECT * FROM Hinario"
        Dim Column As DataColumn
        Dim Row As DataRow
        Adaptador = New OleDbDataAdapter(SQL, ConexHarpa)
        RegHarpa = New DataTable
        Adaptador.Fill(RegHarpa)
        ListaHarpa = New DataTable
        Column = New DataColumn With {.DataType = Type.GetType("System.Int32"), .ColumnName = "Indice", .ReadOnly = True, .Unique = True}
        ListaHarpa.Columns.Add(Column)
        Column = New DataColumn With {.DataType = Type.GetType("System.String"), .ColumnName = "Titulo", .AutoIncrement = False, .Caption = "Titulo", .ReadOnly = False, .Unique = False}
        ListaHarpa.Columns.Add(Column)
        For L As Long = 0 To RegHarpa.Rows.Count - 1
            Row = ListaHarpa.NewRow
            Row("Indice") = RegHarpa.Rows(L).Item("Indice")
            Row("Titulo") = (RegHarpa.Rows(L).Item("Indice")) & " - " & RegHarpa.Rows(L).Item("Titulo")
            ListaHarpa.Rows.Add(Row)
        Next
    End Sub

    'Os 66 livros, na ordem e com os mesmos nomes das tabelas nos bancos ACF/NVI
    Public ReadOnly LivrosBiblia() As String = {"Genesis", "Exodo", "Levitico", "Numeros", "Deuteronomio", "Josue", "Juizes", "Rute", "1Samuel", "2Samuel", "1Reis", "2Reis", "1Cronicas", "2Cronicas", "Esdras", "Neemias", "Ester", "Jo", "Salmos", "Proverbios", "Eclesiastes", "Cantares", "Isaias", "Jeremias", "Lamentacoes", "Ezequiel", "Daniel", "Oseias", "Joel", "Amos", "Obadias", "Jonas", "Miqueias", "Naum", "Habacuque", "Sofonias", "Ageu", "Zacarias", "Malaquias", "Mateus", "Marcos", "Lucas", "Joao", "Atos", "Romanos", "1Corintios", "2Corintios", "Galatas", "Efesios", "Filipenses", "Colossenses", "1Tessalonicenses", "2Tessalonicenses", "1Timoteo", "2Timoteo", "Tito", "Filemom", "Hebreus", "Tiago", "1Pedro", "2Pedro", "1Joao", "2Joao", "3Joao", "Judas", "Apocalipse"}
    Private Const SeparadorTestamentos As String = "------------------------"

    'Cache: cada livro e cada Bíblia completa são lidos do banco uma única vez por versão
    Private ReadOnly CacheLivros As New Dictionary(Of String, DataTable)(StringComparer.OrdinalIgnoreCase) 'chave "ACF|Genesis"
    Private ReadOnly CacheBiblia As New Dictionary(Of String, DataTable)(StringComparer.OrdinalIgnoreCase) 'chave "ACF"
    Private IndiceLivro As New Dictionary(Of Integer, DataRow) 'versículos do livro atual por (capítulo, versículo)

    Private Function ChaveVersiculo(Cap As Integer, Ver As Integer) As Integer
        Return Cap * 1000 + Ver
    End Function

    Public Sub CarregarListaLivros()
        ListaLivros = New DataTable
        ListaLivros.Columns.Add(New DataColumn With {.DataType = GetType(Integer), .ColumnName = "Indice", .ReadOnly = True, .Unique = True})
        ListaLivros.Columns.Add(New DataColumn With {.DataType = GetType(String), .ColumnName = "Livro", .ReadOnly = False, .Unique = False})
        Dim Nomes As New List(Of String)(LivrosBiblia)
        Nomes.Insert(39, SeparadorTestamentos) 'entre Malaquias e Mateus
        For L As Integer = 0 To Nomes.Count - 1
            Dim Row As DataRow = ListaLivros.NewRow
            Row("Indice") = L + 1
            Row("Livro") = Nomes(L)
            ListaLivros.Rows.Add(Row)
        Next
    End Sub

    Private Function ConexaoVersao() As OleDbConnection
        If VersaoBiblia = "ACF" Then Return ConexACF
        If VersaoBiblia = "NVI" Then Return ConexNVI
        Return Nothing
    End Function

    'Lê um livro da versão atual (do cache, se já foi lido antes)
    Private Function ObterLivro(Lv As String) As DataTable
        Dim Chave As String = VersaoBiblia & "|" & Lv
        Dim Tabela As DataTable = Nothing
        If CacheLivros.TryGetValue(Chave, Tabela) Then Return Tabela
        Dim Conex As OleDbConnection = ConexaoVersao()
        If Conex Is Nothing Then Return Nothing
        Tabela = New DataTable
        Try
            Using Adaptador As New OleDbDataAdapter("SELECT * FROM [" & Lv & "]", Conex) 'Fill abre/fecha a conexão se estiver fechada
                Adaptador.Fill(Tabela)
            End Using
            CacheLivros(Chave) = Tabela
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Acessar Biblia " & VersaoBiblia)
        End Try
        Return Tabela
    End Function

    Public Sub CarregarLivro(Lv As String)
        If VersaoBiblia = "" Then Exit Sub
        Dim Tabela As DataTable = ObterLivro(Lv)
        If Tabela Is Nothing Then Exit Sub
        RegLivro = Tabela
        IndiceLivro = New Dictionary(Of Integer, DataRow)
        Dim MaiorCap As Integer = 0
        For Each Linha As DataRow In RegLivro.Rows
            Dim Cap As Integer = CInt(Linha.Item(1))
            IndiceLivro(ChaveVersiculo(Cap, CInt(Linha.Item(2)))) = Linha
            If Cap > MaiorCap Then MaiorCap = Cap
        Next
        ListaCap = New DataTable
        ListaCap.Columns.Add(New DataColumn With {.DataType = GetType(Integer), .ColumnName = "Indice", .ReadOnly = True, .Unique = True})
        For C As Integer = 1 To MaiorCap
            Dim Row As DataRow = ListaCap.NewRow
            Row("Indice") = C
            ListaCap.Rows.Add(Row)
        Next
    End Sub

    Public Sub CarregarVer(Cap As Integer)
        ListaVer = New DataTable
        ListaVer.Columns.Add(New DataColumn With {.DataType = GetType(Integer), .ColumnName = "Indice", .ReadOnly = True, .Unique = True})
        For Each Linha As DataRow In RegLivro.Rows
            If CInt(Linha.Item(1)) = Cap Then
                Dim Row As DataRow = ListaVer.NewRow
                Row("Indice") = Linha.Item(2)
                ListaVer.Rows.Add(Row)
            End If
        Next
    End Sub

    'Devolve a linha do versículo no livro atual (ou Nothing se não existir)
    Public Function BuscarVersiculo(Cap As Integer, Ver As Integer) As DataRow
        Dim Linha As DataRow = Nothing
        IndiceLivro.TryGetValue(ChaveVersiculo(Cap, Ver), Linha)
        Return Linha
    End Function

    Public Sub ResultadoVer(Cap As Integer, Ver As Integer)
        Dim Linha As DataRow = BuscarVersiculo(Cap, Ver)
        If Linha Is Nothing Then Exit Sub
        ResultVers = Linha.Item(3).ToString
        ResultRef1 = Livro & " - " & Cap & ":" & Ver
        ResultRef2 = Cap & ":" & Ver
        ResultReferencia = ""
        If Not IsDBNull(Linha.Item(5)) Then ResultReferencia = Linha.Item(5).ToString
    End Sub

    'Monta (uma vez por versão) a tabela com todos os versículos, usada nas pesquisas
    Public Sub CarregarBibliaCompleta()
        If VersaoBiblia = "" Then Exit Sub
        Dim Tabela As DataTable = Nothing
        If CacheBiblia.TryGetValue(VersaoBiblia, Tabela) Then
            RegBiblia = Tabela
            Exit Sub
        End If
        Dim Titulo() As String = {"ID", "Livro", "Cap", "Ver", "Texto", "Assunto", "Ref"}
        Tabela = New DataTable
        For C As Integer = 0 To Titulo.Length - 1
            Tabela.Columns.Add(New DataColumn With {.DataType = If(C = 0, GetType(Integer), GetType(String)), .ColumnName = Titulo(C), .ReadOnly = True, .Unique = False})
        Next
        Dim Conex As OleDbConnection = ConexaoVersao()
        Dim LL As Integer = 1
        Dim Completa As Boolean = True
        Tabela.BeginLoadData()
        Try
            Conex.Open() 'uma conexão só para os 66 livros
            For Each NomeLivro As String In LivrosBiblia
                Dim Livro As DataTable = ObterLivro(NomeLivro)
                If Livro Is Nothing OrElse Not CacheLivros.ContainsKey(VersaoBiblia & "|" & NomeLivro) Then Completa = False
                If Livro Is Nothing Then Continue For
                For Each Linha As DataRow In Livro.Rows
                    Tabela.Rows.Add(LL, NomeLivro, Linha.Item(1), Linha.Item(2), Linha.Item(3), Linha.Item(4), Linha.Item(5))
                    LL += 1
                Next
            Next
        Catch ex As Exception
            Completa = False
            MsgBox(ex.Message, vbCritical, "Acessar Biblia " & VersaoBiblia)
        Finally
            If Conex.State <> ConnectionState.Closed Then Conex.Close()
            Tabela.EndLoadData()
        End Try
        RegBiblia = Tabela
        If Completa Then CacheBiblia(VersaoBiblia) = Tabela 'só guarda se todos os livros foram lidos
    End Sub

    Public Sub AtualizaApresentacao()
        Dim IM As Integer
        If FormPrincipal.ComboMonitor.Text <> "" Then IM = Mid(FormPrincipal.ComboMonitor.Text, 1, 1)
        Try
            If FormPrincipal.RadioButton4.Checked = True Then Exit Sub 'FECHADA
            If FormApresentar.Visible = False Then
                If TelaUnica = True Then Exit Sub
                FormApresentar.Bounds = Screen.AllScreens(IM).Bounds
                FormApresentar.StartPosition = FormStartPosition.Manual
                FormApresentar.Show()
                'FormApresentar.Location = Screen.AllScreens(UBound(Screen.AllScreens)).Bounds.Location
                'FormApresentar.WindowState = FormWindowState.Maximized
                FormApresentar.PictureBox1.Image = Nothing 'imagem fundo
            End If
            FormPrincipal.PictureBox3.Visible = False
            FormPrincipal.PictureBox4.Visible = False
            FormPrincipal.PictureBox7.Visible = False
            If FormPrincipal.RadioButton1.Checked = True Then 'ATIVADA
                FormPrincipal.PictureBox4.Visible = True 'status
                If ImageA = True And File.Exists(ImageAudio) Then 'imagem de Audio
                    FormPrincipal.PictureBox8.Visible = True
                    FormPrincipal.PictureBox8.Image = ImagemEmCache(ImageAudio, CacheAudioCam, CacheAudioImg)
                    FormApresentar.PictureBox3.Visible = True
                    FormApresentar.PictureBox3.Image = FormPrincipal.PictureBox8.Image 'imagem audio
                Else
                    FormPrincipal.PictureBox8.Visible = False
                    FormApresentar.PictureBox3.Visible = False
                End If
                If ImageS = True And File.Exists(ImageSobre) Then 'imagem sobreposta
                    FormPrincipal.PictureBox6.Visible = True
                    FormPrincipal.PictureBox6.Image = ImagemEmCache(ImageSobre, CacheSobreCam, CacheSobreImg)
                    If AjusteDimensional = "S" Then FormPrincipal.PictureBox6.SizeMode = PictureBoxSizeMode.StretchImage
                    If AjusteDimensional = "Z" Then FormPrincipal.PictureBox6.SizeMode = PictureBoxSizeMode.Zoom
                    If AjusteDimensional = "N" Then FormPrincipal.PictureBox6.SizeMode = PictureBoxSizeMode.Normal
                    If AjusteDimensional = "C" Then FormPrincipal.PictureBox6.SizeMode = PictureBoxSizeMode.CenterImage
                    FormApresentar.PictureBox2.Visible = True
                    FormApresentar.PictureBox2.Image = FormPrincipal.PictureBox6.Image 'imagem sobreposta
                    If AjusteDimensional = "S" Then FormApresentar.PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
                    If AjusteDimensional = "Z" Then FormApresentar.PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
                    If AjusteDimensional = "N" Then FormApresentar.PictureBox2.SizeMode = PictureBoxSizeMode.Normal
                    If AjusteDimensional = "C" Then FormApresentar.PictureBox2.SizeMode = PictureBoxSizeMode.CenterImage
                Else
                    FormPrincipal.PictureBox6.Visible = False
                    FormApresentar.PictureBox2.Visible = False
                End If
                If ImageF = True And File.Exists(ImageFundo) Then 'imagem de fundo
                    FormPrincipal.PictureBox5.Visible = True
                    FormPrincipal.PictureBox5.Image = ImagemEmCache(ImageFundo, CacheFundoCam, CacheFundoImg)
                    FormApresentar.PictureBox1.Image = FormPrincipal.PictureBox5.Image 'imagem fundo
                Else
                    FormPrincipal.PictureBox5.Image = Nothing
                    FormApresentar.PictureBox1.Image = Nothing
                End If
                FormApresentar.PictureBox1.Image = FormPrincipal.PictureBox5.Image 'imagem fundo
                FormApresentar.Label1.Text = FormPrincipal.Label3.Text 'Texto título
                FormApresentar.Label1.TextAlign = FormPrincipal.Label3.TextAlign
                FormApresentar.Label1.Font = FonteProj(0)
                FormApresentar.Label1.ForeColor = FormPrincipal.Label3.ForeColor
                FormApresentar.Label1.BackColor = FormPrincipal.Label3.BackColor
                FormApresentar.Label2.Text = FormPrincipal.Label4.Text 'Texto subtítulo
                FormApresentar.Label2.TextAlign = FormPrincipal.Label4.TextAlign
                FormApresentar.Label2.Font = FonteProj(1)
                FormApresentar.Label2.ForeColor = FormPrincipal.Label4.ForeColor
                FormApresentar.Label2.BackColor = FormPrincipal.Label4.BackColor
                FormApresentar.Label3.Text = FormPrincipal.Label5.Text 'Texto corpo
                FormApresentar.Label3.TextAlign = FormPrincipal.Label5.TextAlign
                FormApresentar.Label3.Font = FonteProj(2)
                FormApresentar.Label3.ForeColor = FormPrincipal.Label5.ForeColor
                FormApresentar.Label3.BackColor = FormPrincipal.Label5.BackColor
                FormApresentar.Label4.Text = FormPrincipal.Label6.Text 'Texto rodapé
                FormApresentar.Label4.TextAlign = FormPrincipal.Label6.TextAlign
                FormApresentar.Label4.Font = FonteProj(3)
                FormApresentar.Label4.ForeColor = FormPrincipal.Label6.ForeColor
                FormApresentar.Label4.BackColor = FormPrincipal.Label6.BackColor
                If VideoOn = True And File.Exists(Video) Then 'Video
                    FormPrincipal.PictureBox5.Visible = False
                    FormPrincipal.PictureBox6.Visible = False
                    FormPrincipal.PictureBox8.Visible = False
                    FormPrincipal.Label11.Visible = True
                    'FormPrincipal.Label11.Text = "Video EM REPRODUÇÃO"
                    FormPrincipal.Label11.Location = New Point(8, 170) 'POSIÇÃO
                    'FormPrincipal.Label11.ForeColor = Color.Yellow
                    If FormApresentar.AxWindowsMediaPlayer1.Visible = True Then
                        If FormApresentar.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPaused Then FormApresentar.AxWindowsMediaPlayer1.Ctlcontrols.play()
                    Else
                        FormApresentar.AxWindowsMediaPlayer1.Visible = True
                        FormApresentar.AxWindowsMediaPlayer1.URL = Video
                        FormApresentar.AxWindowsMediaPlayer1.stretchToFit = True
                    End If
                Else
                    FormPrincipal.Label11.Visible = False
                    If FormApresentar.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPlaying Or FormApresentar.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPaused Then
                        FormApresentar.AxWindowsMediaPlayer1.Ctlcontrols.stop()
                    End If
                    FormApresentar.AxWindowsMediaPlayer1.Visible = False
                End If
                If Harpa = True Then 'Harpa
                    FormPrincipal.RichTextBox1.Visible = True
                    FormPrincipal.RichTextBox1.Text = TextoHarpa
                    FormPrincipal.RichTextBox1.SelectAll()
                    FormPrincipal.RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
                    FormPrincipal.RichTextBox1.DeselectAll()
                    FormApresentar.RichTextBox1.Visible = True
                    FormApresentar.RichTextBox1.Text = FormPrincipal.RichTextBox1.Text
                    FormApresentar.RichTextBox1.SelectAll()
                    FormApresentar.RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
                    FormApresentar.RichTextBox1.DeselectAll()
                Else
                    FormPrincipal.RichTextBox1.Clear()
                    FormPrincipal.RichTextBox1.Visible = False
                    FormApresentar.RichTextBox1.Clear()
                    FormApresentar.RichTextBox1.Visible = False
                End If
                If Biblia = True Then 'bíblia
                    FormPrincipal.RichTextBox2.Visible = True
                    If Aad = False Then
                        FormPrincipal.RichTextBox2.Text = TextoBiblia
                    Else
                        FormPrincipal.RichTextBox2.Text = TextoBibliaCondensado
                    End If
                    FormPrincipal.RichTextBox2.BringToFront()
                    FormApresentar.RichTextBox2.Visible = True
                    FormApresentar.RichTextBox2.Text = FormPrincipal.RichTextBox2.Text
                Else
                    FormPrincipal.RichTextBox2.Clear()
                    FormPrincipal.RichTextBox2.Visible = False
                    FormApresentar.RichTextBox2.Clear()
                    FormApresentar.RichTextBox2.Visible = False
                End If
            End If
            If FormPrincipal.RadioButton2.Checked = True Then 'PAUSADA
                FormPrincipal.PictureBox3.Visible = True 'status
            End If
            If FormPrincipal.RadioButton3.Checked = True Or FormPrincipal.RadioButton4.Checked = True Then 'NEUTRO
                FormPrincipal.Label11.Visible = False
                If FormApresentar.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPlaying Or FormApresentar.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPaused Then
                    FormApresentar.AxWindowsMediaPlayer1.Ctlcontrols.stop()
                End If
                FormApresentar.AxWindowsMediaPlayer1.Visible = False
                FormPrincipal.PictureBox6.Visible = False
                FormPrincipal.PictureBox8.Visible = False
                FormApresentar.PictureBox1.Image = Nothing 'imagem fundo
                FormApresentar.PictureBox2.Image = Nothing 'imagem sobreposta
                FormApresentar.PictureBox3.Image = Nothing 'imagem audio
                FormApresentar.Label1.Text = "" 'Texto título
                FormApresentar.Label1.BackColor = Color.Transparent
                FormApresentar.Label2.Text = "" 'Texto subtítulo
                FormApresentar.Label2.BackColor = Color.Transparent
                FormApresentar.Label3.Text = "" 'Texto corpo
                FormApresentar.Label3.BackColor = Color.Transparent
                FormApresentar.Label4.Text = "" 'Texto rodapé
                FormApresentar.Label4.BackColor = Color.Transparent
                FormPrincipal.RichTextBox1.Text = ""
                FormPrincipal.RichTextBox1.Visible = False
                FormPrincipal.RichTextBox2.Text = ""
                FormPrincipal.RichTextBox2.Visible = False
                FormApresentar.RichTextBox1.Text = ""
                FormApresentar.RichTextBox1.Visible = False
                FormApresentar.RichTextBox2.Text = ""
                FormApresentar.RichTextBox2.Visible = False
                If FormPrincipal.RadioButton4.Checked = True Then FormPrincipal.PictureBox7.Visible = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Atualizar apresentação")
        End Try
    End Sub

    Public Function FontF(FN As String) As FontFamily
        Dim fonts As New InstalledFontCollection()
        For Each ff As FontFamily In fonts.Families
            If ff.Name = FN.ToString Then
                Return ff
            End If
        Next
        Return Nothing 'fonte não instalada
    End Function

    Public Function FilterDataTable(UnfilteredTable As DataTable, Filter As String, FilteredColumns As Integer()) As DataTable
        Dim Filters As List(Of String) = Filter.Split(" ").ToList()
        Dim FilteredData As List(Of DataRow) = UnfilteredTable.AsEnumerable().Where(Function(w)
                                                                                        Dim JoinedRow As String = FilteredColumns.[Select](Function(x) w.ItemArray.ElementAtOrDefault(x - 1)?.ToString()).Aggregate("", Function(current, s) $"{current}{s}")
                                                                                        Return Filters.TrueForAll(Function(z) JoinedRow.ToUpperInvariant().Contains(z.ToUpperInvariant()))
                                                                                    End Function).ToList()
        Dim FilteredTable As DataTable = UnfilteredTable.Clone()
        For Each dr As DataRow In FilteredData
            FilteredTable.ImportRow(dr)
        Next
        Return FilteredTable
        'EXEMPLO Dim Filtered Table As DataTable = FilterDataTable(UnfilteredTable, Filter, {2, 3, 4, 5})
    End Function

End Module
