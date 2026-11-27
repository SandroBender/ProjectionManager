Imports System.Data.OleDb
Imports System.Drawing.Text
Imports System.IO
Module Module1
    Public MyDocSystem As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments
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
    Public RegLocalSistema As New DataTable
    Public RegZoom As New DataTable
    Public ImageAudio As String = String.Empty
    Public Video As String = String.Empty
    Public ImageA As Boolean 'imagem audio/video
    Public VideoOn As Boolean
    Public Harpa As Boolean
    Public TextoHarpa As String
    Public Biblia As Boolean
    Public TextoBiblia As String
    Public TextoBibliaCondensado As String
    Public TextoBibliaAnterior As String
    Public TextoBibliaPosterior As String
    Public TelaUnica As Boolean
    Public ZoomTFundo As Integer
    Public ZoomTHarpa As Integer
    Public ZoomTBiblia As Integer
    Public Aad As Boolean

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
    '---- Local do sistema: pasta que CONTÉM a pasta "ProjectionManager" (ex.: Meus Documentos) ----
    Public SistemaCarregado As Boolean 'False se o usuário cancelou a escolha do local

    'Válido quando existe <Raiz>\ProjectionManager\SISTEMA\PMSystem.accdb
    Public Function LocalSistemaValido(Raiz As String) As Boolean
        If String.IsNullOrWhiteSpace(Raiz) Then Return False
        Return File.Exists(Raiz.TrimEnd("\"c) & My.Settings.PastaSistema & My.Settings.ArqDados)
    End Function

    'Aceita a pasta-mãe ou a própria pasta "ProjectionManager"; devolve a raiz ou Nothing
    Private Function AjustarRaiz(Pasta As String) As String
        Dim P As String = Pasta.TrimEnd("\"c)
        If LocalSistemaValido(P) Then Return P
        Dim Mae As String = Path.GetDirectoryName(P)
        If Mae IsNot Nothing AndAlso LocalSistemaValido(Mae) Then Return Mae.TrimEnd("\"c)
        Return Nothing
    End Function

    'Define LocalSystem: 1) local salvo nas configurações do usuário; 2) Meus Documentos;
    '3) pergunta ao usuário (e salva a escolha). Retorna False se o usuário cancelar.
    Public Function DefinirLocalSistema() As Boolean
        Dim Salvo As String = My.Settings.LocalSistema
        If LocalSistemaValido(Salvo) Then
            LocalSystem = Salvo.TrimEnd("\"c)
            Return True
        End If
        If String.IsNullOrWhiteSpace(Salvo) AndAlso LocalSistemaValido(MyDocSystem) Then
            LocalSystem = MyDocSystem.TrimEnd("\"c) 'instalação padrão: nada a perguntar
            Return True
        End If
        If String.IsNullOrWhiteSpace(Salvo) Then
            MsgBox("O conteúdo do sistema não foi encontrado em Meus Documentos." & vbCrLf & "Selecione o local da pasta principal do programa.", vbExclamation, "Dados do systema")
        Else
            MsgBox("O conteúdo do sistema não foi encontrado no local salvo:" & vbCrLf & Salvo & vbCrLf & "Selecione o local da pasta principal do programa.", vbExclamation, "Dados do systema")
        End If
        Return EscolherLocalSistema(If(Directory.Exists(Salvo), Salvo, MyDocSystem))
    End Function

    'Abre a seleção de pasta até o usuário escolher um local válido (True) ou cancelar (False)
    Public Function EscolherLocalSistema(PastaInicial As String) As Boolean
        Do
            Using Dlg As New FolderBrowserDialog With {.ShowNewFolderButton = False, .RootFolder = Environment.SpecialFolder.MyComputer,
                    .Description = "Selecione a pasta que contém a pasta ProjectionManager (ou a própria pasta ProjectionManager).",
                    .SelectedPath = PastaInicial}
                If Dlg.ShowDialog() <> DialogResult.OK Then Return False
                Dim Raiz As String = AjustarRaiz(Dlg.SelectedPath)
                If Raiz IsNot Nothing Then
                    LocalSystem = Raiz
                    My.Settings.LocalSistema = Raiz 'lido na próxima vez que o programa abrir
                    My.Settings.Save()
                    Return True
                End If
                MsgBox("A pasta escolhida não contém ProjectionManager\SISTEMA\" & My.Settings.ArqDados & "." & vbCrLf & "Escolha outra pasta.", vbExclamation, "Dados do systema")
                PastaInicial = Dlg.SelectedPath
            End Using
        Loop
    End Function

    Public Sub CarregarLocalSistema()
        Dim SQL As String = "SELECT * FROM [Local]"
        Using Adaptador As New OleDbDataAdapter(SQL, ConexDados)
            RegLocalSistema = New DataTable
            Adaptador.Fill(RegLocalSistema)
        End Using
    End Sub

    'Registra no banco (tabela Local, campo CamLocal) o local em uso, se mudou
    Public Sub GravarLocalSistema()
        ConectarDados()
        Try
            CarregarLocalSistema()
            Dim SQL As String
            If RegLocalSistema.Rows.Count = 0 Then
                SQL = "INSERT INTO [Local] (CamLocal) VALUES (?)"
            ElseIf RegLocalSistema.Rows(0).Item("CamLocal").ToString <> LocalSystem Then
                SQL = "UPDATE [Local] SET CamLocal = ?"
            Else
                Exit Sub 'já está registrado (o Finally fecha a conexão)
            End If
            Using Comando As New OleDbCommand(SQL, ConexDados)
                Comando.Parameters.AddWithValue("@CamLocal", LocalSystem)
                Comando.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Registrar local do sistema")
        Finally
            DesconectarDados()
        End Try
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

    'Assunto (4) e Referências (5) existem só em algumas versões (ex.: ACF tem, NVI não)
    Public Function ColunaOpcional(Linha As DataRow, Indice As Integer) As Object
        If Indice < Linha.Table.Columns.Count Then Return Linha.Item(Indice)
        Return DBNull.Value
    End Function

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

    'Descarta o que já foi lido de uma versão (ex.: depois de alterar o banco da NVI)
    Public Sub LimparCacheBiblia(Versao As String)
        For Each Chave As String In CacheLivros.Keys.Where(Function(k) k.StartsWith(Versao & "|", StringComparison.OrdinalIgnoreCase)).ToList()
            CacheLivros.Remove(Chave)
        Next
        CacheBiblia.Remove(Versao)
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
        If Not IsDBNull(ColunaOpcional(Linha, 5)) Then ResultReferencia = ColunaOpcional(Linha, 5).ToString
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
                    Tabela.Rows.Add(LL, NomeLivro, Linha.Item(1), Linha.Item(2), Linha.Item(3), ColunaOpcional(Linha, 4), ColunaOpcional(Linha, 5))
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

    'Atualiza o telão e a prévia conforme o estado escolhido na tela principal
    '(Ativada: mostra tudo o que estiver ligado; Pausada: congela e pausa o vídeo; Neutra: tela preta).
    Public Sub AtualizaApresentacao()
        Dim IM As Integer
        If FormPrincipal.ComboMonitor.Text <> "" Then IM = Mid(FormPrincipal.ComboMonitor.Text, 1, 1)
        Try
            If FormPrincipal.rbFechada.Checked = True Then Exit Sub 'FECHADA
            If FormApresentar.Visible = False Then
                If TelaUnica = True Then Exit Sub
                FormApresentar.Bounds = Screen.AllScreens(IM).Bounds
                FormApresentar.StartPosition = FormStartPosition.Manual
                FormApresentar.Show()
            End If
            FormPrincipal.picStatusPausada.Visible = FormPrincipal.rbPausada.Checked
            FormPrincipal.picStatusAtivada.Visible = FormPrincipal.rbAtivada.Checked
            FormPrincipal.picStatusFechada.Visible = False
            If FormPrincipal.rbAtivada.Checked = True Then 'ATIVADA
                MostrarNasTelas()
                If PaginaInternetAtiva() Then MostrarPaginaProjecao() Else EsconderPaginaProjecao() 'Internet: página por cima de tudo
            End If
            If FormPrincipal.rbNeutra.Checked = True Then 'NEUTRA
                LimparTelas()
                EsconderPaginaProjecao()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Atualizar apresentação")
        End Try
    End Sub

    Private ReadOnly ExtensoesImagem As New HashSet(Of String)({".png", ".jpg", ".jpeg", ".bmp"}, StringComparer.OrdinalIgnoreCase)

    'Imagens da pasta, em ordem alfabética
    Public Function ListarImagens(Pasta As String) As String()
        If String.IsNullOrEmpty(Pasta) OrElse Not Directory.Exists(Pasta) Then Return New String() {}
        Dim Arquivos() As String = Directory.GetFiles(Pasta).Where(Function(a) ExtensoesImagem.Contains(Path.GetExtension(a))).ToArray()
        Array.Sort(Arquivos)
        Return Arquivos
    End Function

    'Devolve em Arquivo a imagem de posição Indice da pasta (ou a 1ª, se Indice passar do fim).
    'Retorna a posição usada, ou -1 se a pasta não tiver imagens.
    Public Function ImagemDaPasta(Pasta As String, Indice As Integer, ByRef Arquivo As String) As Integer
        Dim Imagens() As String = ListarImagens(Pasta)
        If Imagens.Length = 0 Then Return -1
        If Indice < 0 OrElse Indice >= Imagens.Length Then Indice = 0
        Arquivo = Imagens(Indice)
        Return Indice
    End Function

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
