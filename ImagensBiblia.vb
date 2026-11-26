Imports System.IO
Imports System.Text.RegularExpressions

'Biblioteca de imagens dos versículos: <pasta do sistema>\ProjectionManager\IMAGENS\Biblia
'
'  Biblia\<Livro>\3.jpg            capítulo 3 inteiro
'  Biblia\<Livro>\6-8.jpg          capítulos 6 a 8
'  Biblia\<Livro>\3_16.jpg         versículo 3:16
'  Biblia\<Livro>\3_1-8.jpg        versículos 3:1 a 3:8
'  Biblia\<Livro>\11_32-12_1.jpg   de 11:32 até 12:1
'  Várias imagens para a mesma passagem: numere no fim ("01_01_1.jpg", "01_01_2.jpg")
'  ou use títulos diferentes ("3_16 cruz.jpg", "3_16 mundo.jpg"); todas são mostradas em sequência.
'  (depois do número pode vir um título: "3_16 Deus amou o mundo.jpg")
'  Biblia\<Livro>\capa.jpg         qualquer nome que não comece com número = imagem do livro todo
'  Biblia\Assuntos\pastor.jpg      usada quando o assunto do versículo contém a palavra "pastor"
'                                  (várias: "pastor_1.jpg", "pastor_2.jpg")
'  Biblia\padrao.jpg               usada quando nada mais servir (várias: "padrao_1.jpg", "padrao_2.jpg")
Public Module ImagensBiblia

    Public Class ImagemVersiculo
        Public Caminhos As New List(Of String) 'uma ou mais imagens, na ordem de exibição
        Public Descricao As String
        Public ReadOnly Property Caminho As String 'a primeira
            Get
                Return If(Caminhos.Count > 0, Caminhos(0), Nothing)
            End Get
        End Property
    End Class

    Private Class EntradaImagem
        Public Caminho As String
        Public Titulo As String
        Public Numero As Integer 'ordem dentro do grupo ("_2" no fim do nome)
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
        Public ReadOnly Property Passagem As String 'imagens com a mesma passagem formam um grupo
            Get
                Return CapIni & ":" & VerIni & "-" & CapFim & ":" & VerFim
            End Get
        End Property
    End Class

    Public ImagemBibliaAtual As ImagemVersiculo 'imagens do versículo exibido (Nothing = nenhuma)

    Private ReadOnly ExtensoesImagem As New HashSet(Of String)({".jpg", ".jpeg", ".png", ".bmp", ".gif", ".webp"}, StringComparer.OrdinalIgnoreCase)
    Private ReadOnly RegexNome As New Regex("^(?<c1>\d+)(?:_(?<v1>\d+))?(?:-(?:(?<c2>\d+)_)?(?<e>\d+))?(?:_(?<n>\d+))?(?:\s+(?<t>.*))?$")
    Private ReadOnly RegexNumeroFinal As New Regex("[_\s]+\d+$") '"pastor_2" -> "pastor"
    Private Const DistanciaMaxima As Integer = 10 'versículos: imagem "vizinha" no mesmo capítulo

    Private PorLivro As New Dictionary(Of String, List(Of EntradaImagem))(StringComparer.OrdinalIgnoreCase)
    Private ImagensDoLivro As New Dictionary(Of String, List(Of String))(StringComparer.OrdinalIgnoreCase)
    Private Assuntos As New List(Of KeyValuePair(Of String, List(Of String))) 'palavra -> imagens
    Private ImagensPadrao As New List(Of String)
    Private Carregada As Boolean

    Public Function PastaImagensBiblia() As String
        Return Path.Combine(LocalSystem & "\ProjectionManager\IMAGENS", "Biblia")
    End Function

    Private Function EhImagem(Arquivo As String) As Boolean
        Return ExtensoesImagem.Contains(Path.GetExtension(Arquivo))
    End Function

    'Ordem natural: "2" antes de "10"
    Private Function ChaveOrdem(Arquivo As String) As String
        Return Regex.Replace(Path.GetFileNameWithoutExtension(Arquivo).ToLowerInvariant(), "\d+", Function(m) m.Value.PadLeft(6, "0"c))
    End Function

    'Lê (de novo) a pasta da biblioteca
    Public Sub RecarregarBiblioteca()
        PorLivro = New Dictionary(Of String, List(Of EntradaImagem))(StringComparer.OrdinalIgnoreCase)
        ImagensDoLivro = New Dictionary(Of String, List(Of String))(StringComparer.OrdinalIgnoreCase)
        Assuntos = New List(Of KeyValuePair(Of String, List(Of String)))
        ImagensPadrao = New List(Of String)
        Carregada = True
        Dim Raiz As String = PastaImagensBiblia()
        If Not Directory.Exists(Raiz) Then Exit Sub
        ImagensPadrao = Directory.GetFiles(Raiz).Where(AddressOf EhImagem).
            Where(Function(a) Path.GetFileNameWithoutExtension(a).StartsWith("padrao", StringComparison.OrdinalIgnoreCase)).OrderBy(AddressOf ChaveOrdem).ToList()
        For Each Pasta As String In Directory.GetDirectories(Raiz)
            Dim Nome As String = Path.GetFileName(Pasta)
            Dim Arquivos = Directory.GetFiles(Pasta).Where(AddressOf EhImagem).OrderBy(AddressOf ChaveOrdem).ToList()
            If Nome.Equals("Assuntos", StringComparison.OrdinalIgnoreCase) Then
                Assuntos = Arquivos.GroupBy(Function(a) SemAcentos(RegexNumeroFinal.Replace(Path.GetFileNameWithoutExtension(a), "")).Trim()).
                    Where(Function(g) g.Key <> "").
                    Select(Function(g) New KeyValuePair(Of String, List(Of String))(g.Key, g.ToList())).
                    OrderByDescending(Function(p) p.Key.Length).ToList() 'palavra mais específica primeiro
                Continue For
            End If
            Dim Livro As String = LivrosBiblia.FirstOrDefault(Function(l) l.Equals(Nome, StringComparison.OrdinalIgnoreCase))
            If Livro Is Nothing Then Continue For
            Dim Lista As New List(Of EntradaImagem)
            Dim DoLivro As New List(Of String)
            For Each Arq As String In Arquivos
                Dim E As EntradaImagem = InterpretarNome(Arq)
                If E IsNot Nothing Then Lista.Add(E) Else DoLivro.Add(Arq) 'nome sem número: imagem do livro
            Next
            PorLivro(Livro) = Lista
            If DoLivro.Count > 0 Then ImagensDoLivro(Livro) = DoLivro
        Next
    End Sub

    Private Function InterpretarNome(Arq As String) As EntradaImagem
        Dim M As Match = RegexNome.Match(Path.GetFileNameWithoutExtension(Arq))
        If Not M.Success Then Return Nothing
        Dim E As New EntradaImagem With {.Caminho = Arq, .Titulo = M.Groups("t").Value.Trim(), .CapIni = CInt(M.Groups("c1").Value),
                                         .Numero = If(M.Groups("n").Success, CInt(M.Groups("n").Value), 0)}
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

    'Escolhe as imagens mais específicas para o versículo
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
            If E IsNot Nothing Then
                'todas as imagens da mesma passagem, pela numeração e depois pelo nome
                Dim Grupo = Lista.Where(Function(x) x.Passagem = E.Passagem).OrderBy(Function(x) x.Numero).ThenBy(Function(x) ChaveOrdem(x.Caminho)).ToList()
                Return Descrever(Grupo, Livro, E)
            End If
        End If
        '4) assunto do versículo
        If Not String.IsNullOrWhiteSpace(Assunto) Then
            Dim A As String = SemAcentos(Assunto)
            For Each P In Assuntos
                If A.Contains(P.Key) Then Return Novo(P.Value, "Assunto: " & P.Key)
            Next
        End If
        '5) livro  6) padrão
        Dim DoLivro As List(Of String) = Nothing
        If ImagensDoLivro.TryGetValue(Livro, DoLivro) Then Return Novo(DoLivro, "Imagem do livro de " & NomeLivro(Livro))
        If ImagensPadrao.Count > 0 Then Return Novo(ImagensPadrao, "Imagem padrão")
        Return Nothing
    End Function

    Private Function Novo(Caminhos As List(Of String), Descricao As String) As ImagemVersiculo
        Return New ImagemVersiculo With {.Caminhos = Caminhos.ToList(), .Descricao = Descricao & If(Caminhos.Count > 1, " - " & Caminhos.Count & " imagens", "")}
    End Function

    Private Function Distancia(E As EntradaImagem, Ver As Integer) As Integer
        If Ver < E.VerIni Then Return E.VerIni - Ver
        If Ver > E.VerFim Then Return Ver - E.VerFim
        Return 0
    End Function

    Private Function Descrever(Grupo As List(Of EntradaImagem), Livro As String, E As EntradaImagem) As ImagemVersiculo
        Dim Trecho As String = NomeLivro(Livro) & " " & E.CapIni &
            If(E.PorVersiculo, ":" & E.VerIni & If(E.CapFim <> E.CapIni, "-" & E.CapFim & ":" & E.VerFim, If(E.VerFim <> E.VerIni, "-" & E.VerFim, "")),
               If(E.CapFim <> E.CapIni, "-" & E.CapFim, ""))
        Dim Titulo As String = Grupo(0).Titulo
        Return Novo(Grupo.Select(Function(x) x.Caminho).ToList(), If(Titulo = "", Trecho, Titulo & " (" & Trecho & ")"))
    End Function

    Public Function SemAcentos(Texto As String) As String
        Dim D As String = Texto.ToLowerInvariant().Normalize(Text.NormalizationForm.FormD)
        Return New String(D.Where(Function(c) Globalization.CharUnicodeInfo.GetUnicodeCategory(c) <> Globalization.UnicodeCategory.NonSpacingMark).ToArray())
    End Function

End Module
