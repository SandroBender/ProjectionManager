Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Text.RegularExpressions

'Biblioteca de imagens dos versículos: <pasta do sistema>\ProjectionManager\IMAGENS\Biblia
'
'  Biblia\<Livro>\3.jpg            capítulo 3 inteiro
'  Biblia\<Livro>\6-8.jpg          capítulos 6 a 8
'  Biblia\<Livro>\3_16.jpg         versículo 3:16
'  Biblia\<Livro>\3_1-8.jpg        versículos 3:1 a 3:8
'  Biblia\<Livro>\11_32-12_1.jpg   de 11:32 até 12:1
'  (depois do número pode vir um título: "3_16 Deus amou o mundo.jpg")
'  Biblia\<Livro>\capa.jpg         qualquer nome que não comece com número = imagem do livro todo
'  Biblia\Assuntos\pastor.jpg      usada quando o assunto do versículo contém a palavra "pastor"
'  Biblia\padrao.jpg               usada quando nada mais servir
Public Module ImagensBiblia

    Public Class ImagemVersiculo
        Public Caminho As String
        Public Descricao As String
    End Class

    Private Class EntradaImagem
        Public Caminho As String
        Public Titulo As String
        Public CapIni, VerIni, CapFim, VerFim As Integer 'VerIni = 0: capítulos inteiros
        Public ReadOnly Property PorVersiculo As Boolean
            Get
                Return VerIni > 0
            End Get
        End Property
        Public ReadOnly Property Inicio As Integer
            Get
                Return CapIni * 1000 + VerIni
            End Get
        End Property
        Public ReadOnly Property Fim As Integer
            Get
                Return CapFim * 1000 + If(PorVersiculo, VerFim, 999)
            End Get
        End Property
    End Class

    Public ImagemBibliaAtual As ImagemVersiculo 'imagem do versículo exibido (Nothing = nenhuma)

    Private ReadOnly ExtensoesImagem As New HashSet(Of String)({".jpg", ".jpeg", ".png", ".bmp", ".gif", ".webp"}, StringComparer.OrdinalIgnoreCase)
    Private ReadOnly RegexNome As New Regex("^(?<c1>\d+)(?:_(?<v1>\d+))?(?:-(?:(?<c2>\d+)_)?(?<e>\d+))?(?:\s+(?<t>.*))?$")
    Private Const DistanciaMaxima As Integer = 10 'versículos: gravura "vizinha" no mesmo capítulo

    Private PorLivro As New Dictionary(Of String, List(Of EntradaImagem))(StringComparer.OrdinalIgnoreCase)
    Private ImagemDoLivro As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
    Private Assuntos As New List(Of KeyValuePair(Of String, String)) 'palavra -> caminho
    Private ImagemPadrao As String
    Private Carregada As Boolean

    Public Function PastaImagensBiblia() As String
        Return Path.Combine(LocalSystem & "\ProjectionManager\IMAGENS", "Biblia")
    End Function

    Private Function EhImagem(Arquivo As String) As Boolean
        Return ExtensoesImagem.Contains(Path.GetExtension(Arquivo))
    End Function

    'Lê (de novo) a pasta da biblioteca
    Public Sub RecarregarBiblioteca()
        PorLivro = New Dictionary(Of String, List(Of EntradaImagem))(StringComparer.OrdinalIgnoreCase)
        ImagemDoLivro = New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
        Assuntos = New List(Of KeyValuePair(Of String, String))
        ImagemPadrao = Nothing
        Carregada = True
        Dim Raiz As String = PastaImagensBiblia()
        If Not Directory.Exists(Raiz) Then Exit Sub
        For Each Arq As String In Directory.GetFiles(Raiz).Where(AddressOf EhImagem).OrderBy(Function(a) a)
            If Path.GetFileNameWithoutExtension(Arq).StartsWith("padrao", StringComparison.OrdinalIgnoreCase) Then ImagemPadrao = Arq : Exit For
        Next
        For Each Pasta As String In Directory.GetDirectories(Raiz)
            Dim Nome As String = Path.GetFileName(Pasta)
            Dim Arquivos = Directory.GetFiles(Pasta).Where(AddressOf EhImagem).OrderBy(Function(a) a).ToList()
            If Nome.Equals("Assuntos", StringComparison.OrdinalIgnoreCase) Then
                For Each Arq As String In Arquivos
                    Assuntos.Add(New KeyValuePair(Of String, String)(SemAcentos(Path.GetFileNameWithoutExtension(Arq)), Arq))
                Next
                Assuntos = Assuntos.OrderByDescending(Function(p) p.Key.Length).ToList() 'palavra mais específica primeiro
                Continue For
            End If
            Dim Livro As String = LivrosBiblia.FirstOrDefault(Function(l) l.Equals(Nome, StringComparison.OrdinalIgnoreCase))
            If Livro Is Nothing Then Continue For
            Dim Lista As New List(Of EntradaImagem)
            For Each Arq As String In Arquivos
                Dim E As EntradaImagem = InterpretarNome(Arq)
                If E IsNot Nothing Then
                    Lista.Add(E)
                ElseIf Not ImagemDoLivro.ContainsKey(Livro) Then
                    ImagemDoLivro(Livro) = Arq 'nome sem número: imagem do livro
                End If
            Next
            PorLivro(Livro) = Lista
        Next
    End Sub

    Private Function InterpretarNome(Arq As String) As EntradaImagem
        Dim M As Match = RegexNome.Match(Path.GetFileNameWithoutExtension(Arq))
        If Not M.Success Then Return Nothing
        Dim E As New EntradaImagem With {.Caminho = Arq, .Titulo = M.Groups("t").Value.Trim(), .CapIni = CInt(M.Groups("c1").Value)}
        Dim Final As Integer = If(M.Groups("e").Success, CInt(M.Groups("e").Value), -1)
        If M.Groups("v1").Success Then
            E.VerIni = CInt(M.Groups("v1").Value)
            E.CapFim = If(M.Groups("c2").Success, CInt(M.Groups("c2").Value), E.CapIni)
            E.VerFim = If(Final > 0, Final, E.VerIni)
        Else
            E.CapFim = If(Final > 0, Final, E.CapIni) 'capítulos inteiros
        End If
        If E.Fim < E.Inicio Then Return Nothing
        Return E
    End Function

    'Escolhe a imagem mais específica para o versículo
    Public Function ImagemPara(Livro As String, Cap As Integer, Ver As Integer, Assunto As String) As ImagemVersiculo
        If Not Carregada Then RecarregarBiblioteca()
        Dim Pos As Integer = Cap * 1000 + Ver
        Dim Lista As List(Of EntradaImagem) = Nothing
        If PorLivro.TryGetValue(Livro, Lista) Then
            '1) versículo/trecho que contém o versículo (o menor trecho vence)
            Dim E = Lista.Where(Function(x) x.PorVersiculo AndAlso x.Inicio <= Pos AndAlso Pos <= x.Fim).OrderBy(Function(x) x.Fim - x.Inicio).FirstOrDefault()
            '2) capítulo(s) que contêm o versículo
            If E Is Nothing Then E = Lista.Where(Function(x) Not x.PorVersiculo AndAlso x.CapIni <= Cap AndAlso Cap <= x.CapFim).OrderBy(Function(x) x.CapFim - x.CapIni).FirstOrDefault()
            '3) trecho vizinho no mesmo capítulo (a cena costuma ser a mesma)
            If E Is Nothing Then
                E = Lista.Where(Function(x) x.PorVersiculo AndAlso x.CapIni = Cap AndAlso x.CapFim = Cap AndAlso Distancia(x, Ver) <= DistanciaMaxima).
                          OrderBy(Function(x) Distancia(x, Ver)).FirstOrDefault()
            End If
            If E IsNot Nothing Then Return Descrever(E.Caminho, Livro, E)
        End If
        '4) assunto do versículo
        If Not String.IsNullOrWhiteSpace(Assunto) Then
            Dim A As String = SemAcentos(Assunto)
            For Each P In Assuntos
                If A.Contains(P.Key) Then Return New ImagemVersiculo With {.Caminho = P.Value, .Descricao = "Assunto: " & Path.GetFileNameWithoutExtension(P.Value)}
            Next
        End If
        '5) livro  6) padrão
        Dim DoLivro As String = Nothing
        If ImagemDoLivro.TryGetValue(Livro, DoLivro) Then Return New ImagemVersiculo With {.Caminho = DoLivro, .Descricao = "Imagem do livro de " & NomeLivro(Livro)}
        If ImagemPadrao IsNot Nothing Then Return New ImagemVersiculo With {.Caminho = ImagemPadrao, .Descricao = "Imagem padrão"}
        Return Nothing
    End Function

    Private Function Distancia(E As EntradaImagem, Ver As Integer) As Integer
        If Ver < E.VerIni Then Return E.VerIni - Ver
        If Ver > E.VerFim Then Return Ver - E.VerFim
        Return 0
    End Function

    Private Function Descrever(Caminho As String, Livro As String, E As EntradaImagem) As ImagemVersiculo
        Dim Trecho As String = NomeLivro(Livro) & " " & E.CapIni &
            If(E.PorVersiculo, ":" & E.VerIni & If(E.CapFim <> E.CapIni, "-" & E.CapFim & ":" & E.VerFim, If(E.VerFim <> E.VerIni, "-" & E.VerFim, "")),
               If(E.CapFim <> E.CapIni, "-" & E.CapFim, ""))
        Return New ImagemVersiculo With {.Caminho = Caminho, .Descricao = If(E.Titulo = "", Trecho, E.Titulo & " (" & Trecho & ")")}
    End Function

    Public Function SemAcentos(Texto As String) As String
        Dim D As String = Texto.ToLowerInvariant().Normalize(Text.NormalizationForm.FormD)
        Return New String(D.Where(Function(c) Globalization.CharUnicodeInfo.GetUnicodeCategory(c) <> Globalization.UnicodeCategory.NonSpacingMark).ToArray())
    End Function

    '---- Gravuras de Doré (Dados\dore.txt): baixadas uma vez do Wikimedia Commons ----

    Public Class GravuraDore
        Public Livro As String
        Public Cap, Ver, VerFim As Integer
        Public Titulo As String
        Public ArquivoCommons As String

        Public ReadOnly Property NomeArquivo As String 'ex.: "1_3-5 A criação da luz.jpg"
            Get
                Dim Titulo2 As String = Regex.Replace(Titulo, "[\\/:*?""<>|]", " -").Replace("  ", " ").Trim()
                Return Cap & "_" & Ver & If(VerFim > Ver, "-" & VerFim, "") & " " & Titulo2 & ".jpg"
            End Get
        End Property
    End Class

    Public Function ListarGravurasDore() As List(Of GravuraDore)
        Dim Lista As New List(Of GravuraDore)
        Dim Arq As String = Path.Combine(Application.StartupPath, "Dados", "dore.txt")
        If Not File.Exists(Arq) Then Return Lista
        For Each Linha As String In File.ReadLines(Arq, Text.Encoding.UTF8)
            If Linha.StartsWith("#") OrElse Linha.Trim() = "" Then Continue For
            Dim P() As String = Linha.Split(ControlChars.Tab)
            Dim R() As String = P(0).Split(";"c)
            If P.Length < 3 OrElse R.Length < 3 Then Continue For
            Lista.Add(New GravuraDore With {.Livro = R(0), .Cap = CInt(R(1)), .Ver = CInt(R(2)), .VerFim = If(R.Length > 3, CInt(R(3)), CInt(R(2))),
                                           .Titulo = P(1), .ArquivoCommons = P(2)})
        Next
        Return Lista
    End Function

    'Endereço da imagem no Wikimedia Commons (largura 1920 ou o original)
    Private Function EnderecoCommons(Arquivo As String, Largura As Integer) As String
        Dim Nome As String = Arquivo.Replace(" ", "_")
        Dim Hash As String
        Using Md5 As System.Security.Cryptography.MD5 = System.Security.Cryptography.MD5.Create()
            Hash = BitConverter.ToString(Md5.ComputeHash(Text.Encoding.UTF8.GetBytes(Nome))).Replace("-", "").ToLowerInvariant()
        End Using
        'Mesma codificação do encodeURIComponent do JavaScript (não codifica ' ( ) ! *)
        Dim Cod As String = Uri.EscapeDataString(Nome).Replace("%27", "'").Replace("%28", "(").Replace("%29", ")").Replace("%21", "!").Replace("%2A", "*")
        Dim Base As String = "https://upload.wikimedia.org/wikipedia/commons/"
        If Largura <= 0 Then Return Base & Hash(0) & "/" & Hash.Substring(0, 2) & "/" & Cod
        Return Base & "thumb/" & Hash(0) & "/" & Hash.Substring(0, 2) & "/" & Cod & "/" & Largura & "px-" & Cod
    End Function

    'Baixa as gravuras que ainda não estão na biblioteca. Retorna (baixadas, já existiam, falhas).
    Public Async Function BaixarGravurasDore(Progresso As Action(Of String), Cancelar As Threading.CancellationToken) As Task(Of Integer())
        ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol Or SecurityProtocolType.Tls12
        Dim Gravuras As List(Of GravuraDore) = ListarGravurasDore()
        Dim Baixadas As Integer = 0, Existentes As Integer = 0, Falhas As Integer = 0
        Using Cliente As New HttpClient With {.Timeout = TimeSpan.FromSeconds(90)}
            'O Wikimedia pede que programas se identifiquem
            Cliente.DefaultRequestHeaders.UserAgent.ParseAdd("ProjectionManager/1.0 (programa de projecao para igrejas)")
            For I As Integer = 0 To Gravuras.Count - 1
                If Cancelar.IsCancellationRequested Then Exit For
                Dim G As GravuraDore = Gravuras(I)
                Dim Pasta As String = Path.Combine(PastaImagensBiblia(), G.Livro)
                Dim Destino As String = Path.Combine(Pasta, G.NomeArquivo)
                Progresso("Baixando gravura " & (I + 1) & " de " & Gravuras.Count & ": " & G.Titulo)
                If File.Exists(Destino) Then Existentes += 1 : Continue For
                Try
                    Directory.CreateDirectory(Pasta)
                    Dim Bytes As Byte() = Nothing
                    For Each Url As String In {EnderecoCommons(G.ArquivoCommons, 1920), EnderecoCommons(G.ArquivoCommons, 0)}
                        Using Resp As HttpResponseMessage = Await Cliente.GetAsync(Url, Cancelar)
                            If Resp.IsSuccessStatusCode Then Bytes = Await Resp.Content.ReadAsByteArrayAsync() : Exit For
                        End Using
                    Next
                    If Bytes Is Nothing OrElse Bytes.Length < 1000 Then Falhas += 1 : Continue For
                    Dim Temp As String = Destino & ".baixando"
                    File.WriteAllBytes(Temp, Bytes)
                    File.Move(Temp, Destino) 'só aparece na biblioteca quando estiver completa
                    Baixadas += 1
                    Await Task.Delay(150, Cancelar) 'não sobrecarrega o servidor
                Catch ex As OperationCanceledException
                    Exit For
                Catch
                    Falhas += 1
                End Try
            Next
        End Using
        RecarregarBiblioteca()
        Return {Baixadas, Existentes, Falhas}
    End Function

End Module
