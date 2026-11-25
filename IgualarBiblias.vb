Imports System.Data.OleDb
Imports System.IO

'Rotina de uso único: completa a Bíblia NVI com as colunas que só existem na ACF
'(ex.: Assunto e Referências), copiando os dados da ACF pelo capítulo + versículo.
Public Module IgualarBiblias

    Private NviVerificada As Boolean 'só pergunta uma vez por execução do programa

    'Chamada ao escolher a NVI: se faltar coluna, pergunta e iguala. Retorna True se alterou o banco.
    Public Function VerificarIgualarNvi() As Boolean
        If NviVerificada Then Return False
        NviVerificada = True
        Dim Faltando As List(Of String)
        Try
            Faltando = ColunasFaltandoNaNvi("Genesis")
        Catch ex As Exception
            MsgBox("Não foi possível comparar as Bíblias ACF e NVI:" & vbCrLf & ex.Message, vbExclamation, "Bíblia NVI")
            Return False
        End Try
        If Faltando.Count = 0 Then Return False
        If MsgBox("A Bíblia NVI não tem as colunas: " & String.Join(", ", Faltando) & "." & vbCrLf & vbCrLf &
                  "Deseja completar a NVI com esses dados da ACF (pelo capítulo e versículo)?" & vbCrLf &
                  "Um backup do arquivo da NVI será criado antes. Pode levar alguns minutos.",
                  vbYesNo + vbQuestion, "Igualar Bíblias") <> MsgBoxResult.Yes Then Return False
        Return IgualarNviComAcf()
    End Function

    Private Function ArquivoBiblia(Arquivo As String) As String
        Return LocalSystem & My.Settings.PastaSistema & Arquivo
    End Function

    Private Function NovaConexao(Arquivo As String) As OleDbConnection
        Return New OleDbConnection(StringConexao(Arquivo))
    End Function

    'Colunas de uma tabela, na ordem do banco
    Private Function Colunas(Conex As OleDbConnection, Tabela As String) As List(Of DataRow)
        Dim Esquema As DataTable = Conex.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, New Object() {Nothing, Nothing, Tabela, Nothing})
        Return Esquema.Rows.Cast(Of DataRow)().OrderBy(Function(r) CInt(r("ORDINAL_POSITION"))).ToList()
    End Function

    Private Function NomesColunas(Lista As List(Of DataRow)) As List(Of String)
        Return Lista.Select(Function(r) r("COLUMN_NAME").ToString()).ToList()
    End Function

    Private Function ColunasFaltandoNaNvi(Livro As String) As List(Of String)
        Using Acf As OleDbConnection = NovaConexao(My.Settings.ArqBibliaACF), Nvi As OleDbConnection = NovaConexao(My.Settings.ArqBibliaNVI)
            Acf.Open()
            Nvi.Open()
            Dim NomesNvi As List(Of String) = NomesColunas(Colunas(Nvi, Livro))
            Return NomesColunas(Colunas(Acf, Livro)).Where(Function(n) Not NomesNvi.Contains(n, StringComparer.OrdinalIgnoreCase)).ToList()
        End Using
    End Function

    'Tipo do Access equivalente à coluna da ACF (para o ALTER TABLE)
    Private Function TipoAccess(Coluna As DataRow) As String
        Dim Tamanho As Long = If(IsDBNull(Coluna("CHARACTER_MAXIMUM_LENGTH")), 0, CLng(Coluna("CHARACTER_MAXIMUM_LENGTH")))
        Select Case CType(CInt(Coluna("DATA_TYPE")), OleDbType)
            Case OleDbType.WChar, OleDbType.VarWChar, OleDbType.Char, OleDbType.VarChar
                Return If(Tamanho > 0 AndAlso Tamanho <= 255, "TEXT(" & Tamanho & ")", "MEMO")
            Case OleDbType.Integer : Return "LONG"
            Case OleDbType.SmallInt : Return "SHORT"
            Case OleDbType.UnsignedTinyInt : Return "BYTE"
            Case OleDbType.Double : Return "DOUBLE"
            Case OleDbType.Single : Return "SINGLE"
            Case OleDbType.Currency : Return "CURRENCY"
            Case OleDbType.Date : Return "DATETIME"
            Case OleDbType.Boolean : Return "BIT"
            Case Else : Return "MEMO"
        End Select
    End Function

    Public Function IgualarNviComAcf() As Boolean
        Dim ArqNvi As String = ArquivoBiblia(My.Settings.ArqBibliaNVI)
        Dim Backup As String = Path.Combine(Path.GetDirectoryName(ArqNvi), Path.GetFileNameWithoutExtension(ArqNvi) & "_backup_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".accdb")
        Dim TituloOriginal As String = FormPrincipal.Text
        Dim Atualizados As Integer = 0, SemPar As Integer = 0, ColunasCriadas As Integer = 0
        Dim LivroAtual As String = ""
        Try
            File.Copy(ArqNvi, Backup) 'segurança: dá para voltar ao arquivo original
        Catch ex As Exception
            MsgBox("Não foi possível criar o backup da NVI. Nada foi alterado." & vbCrLf & ex.Message, vbCritical, "Igualar Bíblias")
            Return False
        End Try
        Cursor.Current = Cursors.WaitCursor
        Try
            Using Acf As OleDbConnection = NovaConexao(My.Settings.ArqBibliaACF), Nvi As OleDbConnection = NovaConexao(My.Settings.ArqBibliaNVI)
                Acf.Open()
                Nvi.Open()
                For L As Integer = 0 To LivrosBiblia.Length - 1
                    LivroAtual = LivrosBiblia(L)
                    FormPrincipal.Text = "Igualando Bíblia NVI: " & LivroAtual & " (" & (L + 1) & " de " & LivrosBiblia.Length & ")"
                    FormPrincipal.Refresh()
                    Dim ColsAcf As List(Of DataRow) = Colunas(Acf, LivroAtual)
                    Dim ColsNvi As List(Of DataRow) = Colunas(Nvi, LivroAtual)
                    Dim NomesNvi As List(Of String) = NomesColunas(ColsNvi)
                    Dim Novas As List(Of DataRow) = ColsAcf.Where(Function(c) Not NomesNvi.Contains(c("COLUMN_NAME").ToString(), StringComparer.OrdinalIgnoreCase)).ToList()
                    If Novas.Count = 0 OrElse ColsAcf.Count < 3 OrElse ColsNvi.Count < 3 Then Continue For
                    '1) cria as colunas na NVI (ficam no fim da tabela, na mesma ordem da ACF)
                    For Each Col As DataRow In Novas
                        Using Cmd As New OleDbCommand("ALTER TABLE [" & LivroAtual & "] ADD COLUMN [" & Col("COLUMN_NAME").ToString() & "] " & TipoAccess(Col), Nvi)
                            Cmd.ExecuteNonQuery()
                        End Using
                        ColunasCriadas += 1
                    Next
                    '2) copia os dados da ACF, casando capítulo (2ª coluna) e versículo (3ª coluna)
                    Dim CapAcf As String = ColsAcf(1)("COLUMN_NAME").ToString(), VerAcf As String = ColsAcf(2)("COLUMN_NAME").ToString()
                    Dim CapNvi As String = ColsNvi(1)("COLUMN_NAME").ToString(), VerNvi As String = ColsNvi(2)("COLUMN_NAME").ToString()
                    Dim NomesNovas As List(Of String) = NomesColunas(Novas)
                    Dim Origem As New DataTable
                    Using Adaptador As New OleDbDataAdapter("SELECT [" & CapAcf & "], [" & VerAcf & "], [" & String.Join("], [", NomesNovas) & "] FROM [" & LivroAtual & "]", Acf)
                        Adaptador.Fill(Origem)
                    End Using
                    Using Transacao As OleDbTransaction = Nvi.BeginTransaction()
                        Dim Sql As String = "UPDATE [" & LivroAtual & "] SET " & String.Join(", ", NomesNovas.Select(Function(n) "[" & n & "] = ?")) &
                                            " WHERE [" & CapNvi & "] = ? AND [" & VerNvi & "] = ?"
                        Using Cmd As New OleDbCommand(Sql, Nvi, Transacao)
                            For Each Linha As DataRow In Origem.Rows
                                If NomesNovas.All(Function(n) IsDBNull(Linha(n))) Then Continue For 'nada a copiar
                                Cmd.Parameters.Clear()
                                For Each N As String In NomesNovas
                                    Dim P As OleDbParameter = Cmd.Parameters.AddWithValue("@" & Cmd.Parameters.Count, Linha(N))
                                    If IsDBNull(Linha(N)) Then P.OleDbType = OleDbType.VarWChar 'valor vazio precisa de um tipo
                                Next
                                Cmd.Parameters.AddWithValue("@Cap", Linha(0))
                                Cmd.Parameters.AddWithValue("@Ver", Linha(1))
                                If Cmd.ExecuteNonQuery() > 0 Then Atualizados += 1 Else SemPar += 1
                            Next
                        End Using
                        Transacao.Commit()
                    End Using
                Next
            End Using
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            FormPrincipal.Text = TituloOriginal
            MsgBox("Erro ao igualar a NVI no livro " & LivroAtual & ":" & vbCrLf & ex.Message & vbCrLf & vbCrLf &
                   "O arquivo original foi salvo em:" & vbCrLf & Backup, vbCritical, "Igualar Bíblias")
            LimparCacheBiblia("NVI")
            Return ColunasCriadas > 0
        End Try
        Cursor.Current = Cursors.Default
        FormPrincipal.Text = TituloOriginal
        LimparCacheBiblia("NVI")
        MsgBox("Bíblia NVI completada." & vbCrLf &
               "Colunas criadas: " & ColunasCriadas & vbCrLf &
               "Versículos preenchidos com dados da ACF: " & Atualizados & vbCrLf &
               "Versículos da ACF sem correspondente na NVI: " & SemPar & vbCrLf & vbCrLf &
               "Backup do arquivo original: " & Backup, vbInformation, "Igualar Bíblias")
        Return True
    End Function

End Module
