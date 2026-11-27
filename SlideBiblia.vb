'Versículo da Bíblia na projeção: os dados do slide (texto, imagens, modo e posição) que a página
'Web\biblia.html desenha dentro da tela de projeção (Web\projecao.html).
Public Module SlideBiblia

    Public Const HostImagens As String = "imagens." & HostLocal

    'Endereço da imagem da biblioteca no navegador (pasta IMAGENS\Biblia mapeada em imagens.projectionmanager.example)
    Public Function EnderecoImagem(Caminho As String) As String
        If String.IsNullOrEmpty(Caminho) Then Return ""
        Dim Raiz As String = IO.Path.GetFullPath(PastaImagensBiblia()).TrimEnd("\"c) & "\"
        Dim Completo As String = IO.Path.GetFullPath(Caminho)
        If Not Completo.StartsWith(Raiz, StringComparison.OrdinalIgnoreCase) Then Return ""
        Dim Partes() As String = Completo.Substring(Raiz.Length).Split("\"c)
        Return "https://" & HostImagens & "/" & String.Join("/", Partes.Select(Function(p) Uri.EscapeDataString(p)))
    End Function
    Private Function ModoJs() As String
        Select Case My.Settings.BibliaModoImagem
            Case "Foco alternado" : Return "foco"
            Case "Fundo esmaecido" : Return "esmaecido"
            Case Else : Return "sem"
        End Select
    End Function
    Private Function PosicaoJs() As String
        Select Case My.Settings.BibliaPosicaoTexto
            Case "Topo" : Return "topo"
            Case "Embaixo" : Return "baixo"
            Case Else : Return "centro"
        End Select
    End Function

    'Dados do versículo atual para a página
    Public Function DadosBiblia() As Dictionary(Of String, Object)
        Dim Imagens As New List(Of String)
        If ImagemBibliaAtual IsNot Nothing Then Imagens = ImagemBibliaAtual.Caminhos.Select(Function(c) EnderecoImagem(c)).Where(Function(u) u <> "").ToList()
        Return New Dictionary(Of String, Object) From {
            {"referencia", If(Aad, "", ResultRef1 & " [" & VersaoBiblia & "]")},
            {"texto", If(Aad, TextoBibliaCondensado, ResultVers)},
            {"imagens", Imagens},
            {"modo", ModoJs()}, {"posicao", PosicaoJs()},
            {"tempo", Math.Max(1, My.Settings.BibliaTempoFoco)}, {"troca", Math.Max(2, My.Settings.BibliaTempoTroca)},
            {"fonte", ZoomBiblia}}
    End Function

End Module
