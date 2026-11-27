Imports System.IO
Imports System.Web.Script.Serialization
Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Web.WebView2.WinForms

'Projeção feita inteiramente no navegador embutido (Web\projecao.html).
'O programa monta um "retrato" do que deve aparecer (EstadoProjecao) e a página desenha:
'fundo + sobreposição, imagem da tela Áudio/Vídeo, vídeo/áudio, Harpa e Bíblia.
'A mesma página, em miniatura (?previa=1), é a prévia da tela principal.
Public Module Projecao

    Public ReadOnly EnderecoProjecao As String = "https://" & HostApp & "/projecao.html"
    Public ReadOnly EnderecoPrevia As String = "https://" & HostApp & "/previa.html"
    Public ReadOnly EnderecoPlayer As String = "https://" & HostApp & "/player.html"

    Public ZoomHarpa As Single = 54  'tamanho da letra da Harpa (zoom da tela Harpa)
    Public ZoomBiblia As Single = 54 'tamanho da letra da Bíblia (zoom da tela Bíblia)

    Private ReadOnly Json As New JavaScriptSerializer With {.MaxJsonLength = Integer.MaxValue}

    Public Function JsonTexto(Valor As Object) As String
        Return Json.Serialize(Valor)
    End Function

    '---- arquivos do computador -> endereço no navegador ----
    'Cada disco (C:, D:, pen drive...) é liberado só para leitura em disco-c.projectionmanager.example
    Private ReadOnly DiscosMapeados As New HashSet(Of Char)

    Private Function HostDisco(Letra As Char) As String
        Return "disco-" & Char.ToLowerInvariant(Letra) & "." & HostLocal
    End Function

    'Chamado por Navegador.IniciarNavegador para cada navegador novo
    Public Sub MapearDiscos(Nav As CoreWebView2)
        For Each Letra As Char In DiscosMapeados
            Nav.SetVirtualHostNameToFolderMapping(HostDisco(Letra), Letra & ":\", CoreWebView2HostResourceAccessKind.Allow)
        Next
    End Sub

    Public Function EhEndereco(Texto As String) As Boolean
        Return Texto.StartsWith("http://", StringComparison.OrdinalIgnoreCase) OrElse Texto.StartsWith("https://", StringComparison.OrdinalIgnoreCase)
    End Function

    'Endereço de um arquivo local (ou o próprio endereço, se já for da internet). "" se não der.
    Public Function UrlArquivo(Caminho As String) As String
        If String.IsNullOrWhiteSpace(Caminho) Then Return ""
        If EhEndereco(Caminho) Then Return Caminho
        Dim Completo As String
        Try
            Completo = Path.GetFullPath(Caminho)
        Catch
            Return ""
        End Try
        If Completo.Length < 3 OrElse Completo(1) <> ":"c Then Return "" 'pasta de rede (\\servidor): copie o arquivo para o computador
        Dim Letra As Char = Char.ToUpperInvariant(Completo(0))
        If DiscosMapeados.Add(Letra) Then 'disco novo: libera em todos os navegadores já abertos
            For Each Nav As CoreWebView2 In NavegadoresProntos()
                Nav.SetVirtualHostNameToFolderMapping(HostDisco(Letra), Letra & ":\", CoreWebView2HostResourceAccessKind.Allow)
            Next
        End If
        Return "https://" & HostDisco(Letra) & "/" & String.Join("/", Completo.Substring(3).Split("\"c).Select(Function(p) Uri.EscapeDataString(p)))
    End Function

    '---- formatos que o navegador toca ----
    Private ReadOnly ExtensoesSuportadas As New HashSet(Of String)(
        {".mp4", ".m4v", ".webm", ".ogv", ".mov", ".mp3", ".m4a", ".aac", ".wav", ".ogg", ".oga", ".opus", ".flac"}, StringComparer.OrdinalIgnoreCase)
    Private ReadOnly ExtensoesAudio As New HashSet(Of String)(
        {".mp3", ".m4a", ".aac", ".wav", ".ogg", ".oga", ".opus", ".flac", ".wma"}, StringComparer.OrdinalIgnoreCase)

    Private Function Extensao(CaminhoOuEndereco As String) As String
        Dim Caminho As String = CaminhoOuEndereco
        Dim U As Uri = Nothing
        If EhEndereco(Caminho) AndAlso Uri.TryCreate(Caminho, UriKind.Absolute, U) Then Caminho = U.AbsolutePath
        Return Path.GetExtension(Caminho)
    End Function

    Public Function FormatoSuportado(CaminhoOuEndereco As String) As Boolean
        Return ExtensoesSuportadas.Contains(Extensao(CaminhoOuEndereco))
    End Function

    Public Function EhAudio(CaminhoOuEndereco As String) As Boolean
        Return ExtensoesAudio.Contains(Extensao(CaminhoOuEndereco))
    End Function

    Public Function NomeMidia(CaminhoOuEndereco As String) As String
        If EhEndereco(CaminhoOuEndereco) Then
            Dim U As Uri = Nothing
            If Uri.TryCreate(CaminhoOuEndereco, UriKind.Absolute, U) Then Return Uri.UnescapeDataString(Path.GetFileName(U.AbsolutePath))
        End If
        Return Path.GetFileName(CaminhoOuEndereco)
    End Function

    Private ReadOnly JaAvisados As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

    'Avisa uma vez por arquivo. Retorna False quando o formato não toca.
    Public Function ConferirFormato(CaminhoOuEndereco As String) As Boolean
        If String.IsNullOrWhiteSpace(CaminhoOuEndereco) OrElse FormatoSuportado(CaminhoOuEndereco) Then Return True
        AvisarFormato(CaminhoOuEndereco)
        Return False
    End Function

    Public Sub AvisarFormato(CaminhoOuEndereco As String)
        If Not JaAvisados.Add(CaminhoOuEndereco) Then Exit Sub
        MsgBox("O arquivo """ & NomeMidia(CaminhoOuEndereco) & """ está num formato que o programa não toca (como WMV, AVI ou WMA)." & vbCrLf & vbCrLf &
               "Converta para MP4 (vídeo) ou MP3 (áudio) e use o arquivo convertido." & vbCrLf &
               "Dica: o Clipchamp (do Windows) ou o VLC fazem a conversão.", vbExclamation, "Formato não suportado")
    End Sub

    '---- o retrato do que deve aparecer ----
    Public Function EstadoProjecao() As String
        Dim E As New Dictionary(Of String, Object) From {{"ativo", True}}
        E("fundo") = If(ComposicaoOn AndAlso ComposicaoJson <> "", ComposicaoJson, Nothing)
        E("sobreposicao") = If(SobreposicaoOn AndAlso SobreposicaoJson <> "", SobreposicaoJson, Nothing)
        E("imagem") = If(ImageA AndAlso File.Exists(ImageAudio), UrlArquivo(ImageAudio), Nothing)
        Dim Midia As String = MidiaAtual()
        Dim Aviso As String = Nothing
        If Midia <> "" AndAlso FormatoSuportado(Midia) Then
            E("midia") = New Dictionary(Of String, Object) From {{"url", UrlArquivo(Midia)}, {"nome", NomeMidia(Midia)}, {"video", Not EhAudio(Midia)}}
            Aviso = If(EhAudio(Midia), "♪ ÁUDIO: ", "▶ VÍDEO: ") & NomeMidia(Midia)
        End If
        If PaginaInternetAtiva() Then Aviso = "INTERNET EM EXIBIÇÃO"
        E("harpa") = If(Harpa AndAlso Not String.IsNullOrEmpty(TextoHarpa), New Dictionary(Of String, Object) From {{"texto", TextoHarpa}, {"fonte", ZoomHarpa}}, Nothing)
        E("biblia") = If(Biblia, DadosBiblia(), Nothing)
        E("aviso") = Aviso
        Return Json.Serialize(E)
    End Function

    '---- envio para o telão e para a prévia ----
    Private ReadOnly ComAviso As New HashSet(Of WebView2)

    Private Async Sub Executar(Nav As WebView2, Endereco As String, Script As String)
        If Nav Is Nothing OrElse Nav.IsDisposed Then Exit Sub
        If Not Await AbrirPagina(Nav, Endereco) OrElse Nav.IsDisposed Then Exit Sub
        If Endereco = EnderecoProjecao AndAlso ComAviso.Add(Nav) Then 'erros de formato vindos do telão
            AddHandler Nav.CoreWebView2.WebMessageReceived, AddressOf MensagemDaProjecao
            AddHandler Nav.Disposed, Sub() ComAviso.Remove(Nav)
        End If
        Try
            Await Nav.CoreWebView2.ExecuteScriptAsync(Script)
        Catch
            'a página pode estar sendo recarregada; o próximo envio corrige
        End Try
    End Sub

    Private Sub MensagemDaProjecao(sender As Object, e As CoreWebView2WebMessageReceivedEventArgs)
        Try
            Dim M = Json.Deserialize(Of Dictionary(Of String, Object))(e.WebMessageAsJson)
            If M IsNot Nothing AndAlso M.ContainsKey("acao") AndAlso M("acao").ToString() = "midiaErro" Then
                Dim Url As String = If(M.ContainsKey("url") AndAlso M("url") IsNot Nothing, M("url").ToString(), "")
                AvisarFormato(Url)
            End If
        Catch
        End Try
    End Sub

    Private Sub ExecutarNasTelas(Script As String)
        If FormApresentar.Visible Then Executar(FormApresentar.webProjecao, EnderecoProjecao, Script)
        'a prévia desenha no tamanho do telão e reduz (fica proporcional ao que aparece na projeção)
        Executar(FormPrincipal.webPrevia, EnderecoPrevia, "definirTela(" & TamanhoTela.Width & "," & TamanhoTela.Height & ");" & Script)
    End Sub

    'Tamanho do monitor de projeção escolhido (ou 1920x1080 se ainda não houver)
    Private Function TamanhoTela() As Size
        Try
            Dim IM As Integer = CInt(Mid(FormPrincipal.ComboMonitor.Text, 1, 1))
            If IM >= 0 AndAlso IM < Screen.AllScreens.Length Then Return Screen.AllScreens(IM).Bounds.Size
        Catch
        End Try
        Return New Size(1920, 1080)
    End Function

    Public Sub MostrarNasTelas()
        ExecutarNasTelas("aplicar(" & EstadoProjecao() & ");")
    End Sub

    Public Sub LimparTelas()
        ExecutarNasTelas("aplicar({""ativo"":false});")
    End Sub

    Public Sub PausarTelas()
        ExecutarNasTelas("pausar();")
    End Sub

    '---- players das telas Harpa e Áudio/Vídeo (Web\player.html) ----
    Public Class PlayerTela
        Private ReadOnly Nav As WebView2
        Public Property Arquivo As String = ""

        Public Sub New(Nav As WebView2)
            Me.Nav = Nav
        End Sub

        Private Async Sub Executar(Script As String)
            If Nav.IsDisposed OrElse Not Await AbrirPagina(Nav, EnderecoPlayer) OrElse Nav.IsDisposed Then Exit Sub
            Try
                Await Nav.CoreWebView2.ExecuteScriptAsync(Script)
            Catch
            End Try
        End Sub

        'Carrega sem tocar (o operador usa os controles do player)
        Public Sub Carregar(Caminho As String)
            Arquivo = If(Caminho, "")
            If Arquivo = "" OrElse Not ConferirFormato(Arquivo) Then
                Executar("parar();")
                Exit Sub
            End If
            Executar("carregar(" & JsonTexto(UrlArquivo(Arquivo)) & "," & If(EhAudio(Arquivo), "false", "true") & "," & JsonTexto(NomeMidia(Arquivo)) & ");")
        End Sub

        Public Sub Pausar()
            Executar("pausar();")
        End Sub

        Public Sub Parar()
            Arquivo = ""
            Executar("parar();")
        End Sub
    End Class

End Module
