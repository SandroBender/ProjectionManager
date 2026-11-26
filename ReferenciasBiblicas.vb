Imports System.Data.OleDb
Imports System.IO

'Referências cruzadas dos versículos (coluna Ref das Bíblias, itens "Livro;Cap;Ver" separados por "|").
'Dados importados de OpenBible.info (licença Creative Commons Attribution - CC BY).
Public Module ReferenciasBiblicas

    Public Const CreditoReferencias As String = "Referências cruzadas: OpenBible.info (CC BY)"

    'Nomes para exibição, na mesma ordem de LivrosBiblia
    Public ReadOnly NomesLivros() As String = {"Gênesis", "Êxodo", "Levítico", "Números", "Deuteronômio", "Josué", "Juízes", "Rute", "1 Samuel", "2 Samuel", "1 Reis", "2 Reis", "1 Crônicas", "2 Crônicas", "Esdras", "Neemias", "Ester", "Jó", "Salmos", "Provérbios", "Eclesiastes", "Cantares", "Isaías", "Jeremias", "Lamentações", "Ezequiel", "Daniel", "Oséias", "Joel", "Amós", "Obadias", "Jonas", "Miquéias", "Naum", "Habacuque", "Sofonias", "Ageu", "Zacarias", "Malaquias", "Mateus", "Marcos", "Lucas", "João", "Atos", "Romanos", "1 Coríntios", "2 Coríntios", "Gálatas", "Efésios", "Filipenses", "Colossenses", "1 Tessalonicenses", "2 Tessalonicenses", "1 Timóteo", "2 Timóteo", "Tito", "Filemom", "Hebreus", "Tiago", "1 Pedro", "2 Pedro", "1 João", "2 João", "3 João", "Judas", "Apocalipse"}

    Public Function NomeLivro(Livro As String) As String
        Dim I As Integer = Array.FindIndex(LivrosBiblia, Function(l) l.Equals(Livro, StringComparison.OrdinalIgnoreCase))
        Return If(I >= 0, NomesLivros(I), Livro)
    End Function

    'Uma referência: "Livro;Cap;Ver", com fim opcional ";VerFim" ou ";CapFim:VerFim"
    Public Class ReferenciaBiblica
        Public Livro As String
        Public Cap As Integer
        Public Ver As Integer
        Public Fim As String = "" 'ex.: "17" ou "12:1"
        Public Texto As String = "" 'texto do 1º versículo, na versão atual

        Public Shared Function Interpretar(Item As String) As ReferenciaBiblica
            Dim P() As String = Item.Trim().Split(";"c)
            Dim R As New ReferenciaBiblica
            If P.Length < 3 OrElse Not Integer.TryParse(P(1), R.Cap) OrElse Not Integer.TryParse(P(2), R.Ver) Then Return Nothing
            R.Livro = P(0).Trim()
            If P.Length >= 4 AndAlso System.Text.RegularExpressions.Regex.IsMatch(P(3), "^\d+(:\d+)?$") Then R.Fim = P(3)
            Return R
        End Function

        Public ReadOnly Property Referencia As String 'ex.: "João 1:1-3" ou "Gênesis 11:32-12:1"
            Get
                Return NomeLivro(Livro) & " " & Cap & ":" & Ver & If(Fim = "", "", "-" & Fim)
            End Get
        End Property

        Public Overrides Function ToString() As String 'o que aparece na lista
            If Texto = "" Then Return Referencia
            Return Referencia & " - " & If(Texto.Length > 90, Texto.Substring(0, 90).TrimEnd() & "...", Texto)
        End Function
    End Class

    'Referências do versículo atual (texto da coluna Ref), já com o texto de cada uma
    Public Function ListarReferencias(Ref As String) As List(Of ReferenciaBiblica)
        Dim Lista As New List(Of ReferenciaBiblica)
        If String.IsNullOrWhiteSpace(Ref) Then Return Lista
        For Each Item As String In Ref.Split("|"c)
            Dim R As ReferenciaBiblica = ReferenciaBiblica.Interpretar(Item)
            If R Is Nothing Then Continue For
            R.Texto = TextoDoVersiculo(R.Livro, R.Cap, R.Ver)
            Lista.Add(R)
        Next
        Return Lista
    End Function

    'Texto de qualquer versículo da versão atual (usa a Bíblia completa já carregada)
    Private IndiceTextos As Dictionary(Of String, String)
    Private IndiceDe As DataTable
    Public Function TextoDoVersiculo(Livro As String, Cap As Integer, Ver As Integer) As String
        If RegBiblia Is Nothing OrElse RegBiblia.Rows.Count = 0 Then Return ""
        If IndiceDe IsNot RegBiblia Then 'monta o índice uma vez por versão
            IndiceTextos = New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
            For Each Linha As DataRow In RegBiblia.Rows
                IndiceTextos(Linha("Livro").ToString & "|" & Linha("Cap").ToString & "|" & Linha("Ver").ToString) = Linha("Texto").ToString
            Next
            IndiceDe = RegBiblia
        End If
        Dim Texto As String = Nothing
        IndiceTextos.TryGetValue(Livro & "|" & Cap & "|" & Ver, Texto)
        Return If(Texto, "")
    End Function

    '---- Importação (uso único): preenche a coluna Ref das Bíblias com o arquivo Dados\referencias.txt ----

    Private ImportacaoVerificada As Boolean

    Private Function ArquivoReferencias() As String
        Return Path.Combine(Application.StartupPath, "Dados", "referencias.txt")
    End Function

    'Lê o arquivo: livro -> (chave cap/ver -> referências)
    Private Function LerArquivoReferencias() As Dictionary(Of String, Dictionary(Of String, String))
        Dim Dados As New Dictionary(Of String, Dictionary(Of String, String))(StringComparer.OrdinalIgnoreCase)
        For Each Linha As String In File.ReadLines(ArquivoReferencias(), Text.Encoding.UTF8)
            If Linha.StartsWith("#") OrElse Linha.Trim() = "" Then Continue For
            Dim Partes() As String = Linha.Split(ControlChars.Tab)
            Dim Chave() As String = Partes(0).Split(";"c)
            If Partes.Length < 2 OrElse Chave.Length < 3 Then Continue For
            If Not Dados.ContainsKey(Chave(0)) Then Dados(Chave(0)) = New Dictionary(Of String, String)
            Dados(Chave(0))(CInt(Chave(1)) & "|" & CInt(Chave(2))) = Partes(1)
        Next
        Return Dados
    End Function

    'Junta as referências existentes com as novas, sem repetir (as existentes ficam primeiro)
    Public Function MesclarReferencias(Existentes As String, Novas As String) As String
        Dim Itens As New List(Of String)
        For Each Item As String In (If(Existentes, "") & "|" & If(Novas, "")).Split("|"c)
            Dim T As String = Item.Trim()
            If T <> "" AndAlso Not Itens.Contains(T, StringComparer.OrdinalIgnoreCase) Then Itens.Add(T)
        Next
        Return String.Join("|", Itens)
    End Function

    'Chamada ao abrir a tela da Bíblia: se faltar importar em alguma versão, pergunta e importa.
    Public Sub VerificarImportarReferencias()
        If ImportacaoVerificada Then Exit Sub
        ImportacaoVerificada = True
        If Not File.Exists(ArquivoReferencias()) Then Exit Sub 'arquivo não distribuído com o programa
        Dim Pendentes As New List(Of String)
        Try
            Dim Dados = LerArquivoReferencias()
            Dim Primeira = Dados("Genesis").First() 'ex.: Gênesis 1:1 -> "Hebreus;11;3|..."
            Dim CapVer() As String = Primeira.Key.Split("|"c)
            Dim Marca As String = Primeira.Value.Split("|"c)(0)
            For Each Arquivo As String In {My.Settings.ArqBibliaACF, My.Settings.ArqBibliaNVI}
                If Not ReferenciaJaImportada(Arquivo, CInt(CapVer(0)), CInt(CapVer(1)), Marca) Then Pendentes.Add(Arquivo)
            Next
        Catch ex As Exception
            MsgBox("Não foi possível verificar as referências das Bíblias:" & vbCrLf & ex.Message, vbExclamation, "Referências")
            Exit Sub
        End Try
        If Pendentes.Count = 0 Then Exit Sub
        If MsgBox("As Bíblias (" & String.Join(", ", Pendentes) & ") ainda não têm as referências cruzadas dos versículos." & vbCrLf & vbCrLf &
                  "Deseja importá-las agora? (até 10 referências por versículo, de OpenBible.info)" & vbCrLf &
                  "Um backup de cada arquivo será criado antes. Pode levar alguns minutos.",
                  vbYesNo + vbQuestion, "Referências") <> MsgBoxResult.Yes Then Exit Sub
        ImportarReferencias(Pendentes)
    End Sub

    'Verdadeiro se Gênesis 1:1 já tem a 1ª referência do arquivo (ou se a tabela não tem a coluna Ref)
    Private Function ReferenciaJaImportada(Arquivo As String, Cap As Integer, Ver As Integer, Marca As String) As Boolean
        Using Conex As New OleDbConnection(StringConexao(Arquivo))
            Conex.Open()
            Dim Cols As List(Of String) = ColunasTabela(Conex, "Genesis")
            If Cols.Count < 6 Then Return True 'sem a coluna Ref: nada a fazer aqui (ex.: NVI ainda não igualada)
            Using Cmd As New OleDbCommand("SELECT [" & Cols(5) & "] FROM [Genesis] WHERE [" & Cols(1) & "] = ? AND [" & Cols(2) & "] = ?", Conex)
                Cmd.Parameters.AddWithValue("@Cap", Cap)
                Cmd.Parameters.AddWithValue("@Ver", Ver)
                Dim Valor As Object = Cmd.ExecuteScalar()
                Return Valor IsNot Nothing AndAlso Not IsDBNull(Valor) AndAlso Valor.ToString().Split("|"c).Contains(Marca, StringComparer.OrdinalIgnoreCase)
            End Using
        End Using
    End Function

    Private Function ColunasEsquema(Conex As OleDbConnection, Tabela As String) As List(Of DataRow)
        Dim Esquema As DataTable = Conex.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, New Object() {Nothing, Nothing, Tabela, Nothing})
        Return Esquema.Rows.Cast(Of DataRow)().OrderBy(Function(r) CInt(r("ORDINAL_POSITION"))).ToList()
    End Function

    Private Function ColunasTabela(Conex As OleDbConnection, Tabela As String) As List(Of String)
        Return ColunasEsquema(Conex, Tabela).Select(Function(r) r("COLUMN_NAME").ToString()).ToList()
    End Function

    Private Sub ImportarReferencias(Arquivos As List(Of String))
        Dim TituloOriginal As String = FormPrincipal.Text
        Dim Resumo As New List(Of String)
        Dim Dados As Dictionary(Of String, Dictionary(Of String, String)) = LerArquivoReferencias()
        Cursor.Current = Cursors.WaitCursor
        For Each Arquivo As String In Arquivos
            Dim Caminho As String = LocalSystem & My.Settings.PastaSistema & Arquivo
            Dim Backup As String = Path.Combine(Path.GetDirectoryName(Caminho), Path.GetFileNameWithoutExtension(Caminho) & "_backup_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".accdb")
            Dim Atualizados As Integer = 0
            Dim LivroAtual As String = ""
            Try
                File.Copy(Caminho, Backup)
            Catch ex As Exception
                Resumo.Add(Arquivo & ": não foi possível criar o backup, nada foi alterado (" & ex.Message & ")")
                Continue For
            End Try
            Try
                Using Conex As New OleDbConnection(StringConexao(Arquivo))
                    Conex.Open()
                    For L As Integer = 0 To LivrosBiblia.Length - 1
                        LivroAtual = LivrosBiblia(L)
                        FormPrincipal.Text = "Importando referências em " & Arquivo & ": " & LivroAtual & " (" & (L + 1) & " de " & LivrosBiblia.Length & ")"
                        FormPrincipal.Refresh()
                        Dim DoLivro As Dictionary(Of String, String) = Nothing
                        If Not Dados.TryGetValue(LivroAtual, DoLivro) Then Continue For
                        Dim Esquema As List(Of DataRow) = ColunasEsquema(Conex, LivroAtual)
                        If Esquema.Count < 6 Then Continue For
                        Dim ColCap As String = Esquema(1)("COLUMN_NAME").ToString(), ColVer As String = Esquema(2)("COLUMN_NAME").ToString()
                        Dim ColRef As String = Esquema(5)("COLUMN_NAME").ToString()
                        'campo de texto curto (até 255) não comporta 10 referências: vira Memorando
                        Dim Tamanho As Long = If(IsDBNull(Esquema(5)("CHARACTER_MAXIMUM_LENGTH")), 0, CLng(Esquema(5)("CHARACTER_MAXIMUM_LENGTH")))
                        If Tamanho > 0 AndAlso Tamanho <= 255 Then
                            Using Cmd As New OleDbCommand("ALTER TABLE [" & LivroAtual & "] ALTER COLUMN [" & ColRef & "] MEMO", Conex)
                                Cmd.ExecuteNonQuery()
                            End Using
                        End If
                        Dim Atuais As New DataTable
                        Using Adaptador As New OleDbDataAdapter("SELECT [" & ColCap & "], [" & ColVer & "], [" & ColRef & "] FROM [" & LivroAtual & "]", Conex)
                            Adaptador.Fill(Atuais)
                        End Using
                        Using Transacao As OleDbTransaction = Conex.BeginTransaction()
                            Using Cmd As New OleDbCommand("UPDATE [" & LivroAtual & "] SET [" & ColRef & "] = ? WHERE [" & ColCap & "] = ? AND [" & ColVer & "] = ?", Conex, Transacao)
                                For Each Linha As DataRow In Atuais.Rows
                                    Dim Novas As String = Nothing
                                    If Not DoLivro.TryGetValue(CInt(Linha(0)) & "|" & CInt(Linha(1)), Novas) Then Continue For
                                    Dim Existentes As String = If(IsDBNull(Linha(2)), "", Linha(2).ToString())
                                    Dim Mescladas As String = MesclarReferencias(Existentes, Novas)
                                    If Mescladas = Existentes Then Continue For 'já estava completo
                                    Cmd.Parameters.Clear()
                                    Cmd.Parameters.AddWithValue("@Ref", Mescladas)
                                    Cmd.Parameters.AddWithValue("@Cap", Linha(0))
                                    Cmd.Parameters.AddWithValue("@Ver", Linha(1))
                                    Atualizados += Cmd.ExecuteNonQuery()
                                Next
                            End Using
                            Transacao.Commit()
                        End Using
                    Next
                End Using
                Resumo.Add(Arquivo & ": " & Atualizados & " versículos com referências")
            Catch ex As Exception
                Resumo.Add(Arquivo & ": erro no livro " & LivroAtual & " (" & ex.Message & "). Os livros anteriores foram gravados.")
            End Try
            Resumo.Add("   backup: " & Backup)
        Next
        Cursor.Current = Cursors.Default
        FormPrincipal.Text = TituloOriginal
        LimparCacheBiblia("ACF")
        LimparCacheBiblia("NVI")
        MsgBox("Importação das referências concluída:" & vbCrLf & vbCrLf & String.Join(vbCrLf, Resumo) & vbCrLf & vbCrLf & CreditoReferencias,
               vbInformation, "Referências")
    End Sub

End Module
