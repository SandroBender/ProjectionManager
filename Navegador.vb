Imports System.IO
Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Web.WebView2.WinForms

'Navegador embutido (Microsoft Edge WebView2) usado na prévia e na tela de projeção
Public Module Navegador

    '---- Estado da Internet na projeção (definido pela tela FormInternet) ----
    Public InternetOn As Boolean          'link ligado na projeção
    Public InternetLink As InfoLink       'link atual (Nothing = nenhum)

    'Pastas do navegador em AppData (a pasta do programa pode não permitir gravação)
    Private ReadOnly PastaDados As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ProjectionManager")
    Private AmbienteTask As Task(Of CoreWebView2Environment)
    Private ReadOnly Preparando As New Dictionary(Of WebView2, Task(Of Boolean))

    'Um único ambiente para todos os navegadores (precisam ter as mesmas opções)
    Private Function Ambiente() As Task(Of CoreWebView2Environment)
        If AmbienteTask Is Nothing Then
            'Permite que vídeos comecem a tocar sozinhos, com som, na projeção
            Dim Opcoes As New CoreWebView2EnvironmentOptions("--autoplay-policy=no-user-gesture-required")
            AmbienteTask = CoreWebView2Environment.CreateAsync(Nothing, Path.Combine(PastaDados, "WebView2"), Opcoes)
        End If
        Return AmbienteTask
    End Function

    'Inicializa o navegador uma única vez. Retorna False se o WebView2 não estiver disponível.
    Public Function PrepararNavegador(Nav As WebView2) As Task(Of Boolean)
        Dim Tarefa As Task(Of Boolean) = Nothing
        If Not Preparando.TryGetValue(Nav, Tarefa) Then
            Tarefa = IniciarNavegador(Nav)
            Preparando(Nav) = Tarefa
            AddHandler Nav.Disposed, Sub() Preparando.Remove(Nav)
        End If
        Return Tarefa
    End Function

    Private Async Function IniciarNavegador(Nav As WebView2) As Task(Of Boolean)
        Try
            Await Nav.EnsureCoreWebView2Async(Await Ambiente())
            'Página local que incorpora o player do YouTube
            Dim PastaWeb As String = Path.Combine(PastaDados, "web")
            Directory.CreateDirectory(PastaWeb)
            File.WriteAllText(Path.Combine(PastaWeb, "youtube.html"), HtmlYouTube, Text.Encoding.UTF8)
            Nav.CoreWebView2.SetVirtualHostNameToFolderMapping(HostLocal, PastaWeb, CoreWebView2HostResourceAccessKind.Allow)
            'Biblioteca de imagens dos versículos (IMAGENS\Biblia)
            Directory.CreateDirectory(PastaImagensBiblia())
            Nav.CoreWebView2.SetVirtualHostNameToFolderMapping(HostImagens, PastaImagensBiblia(), CoreWebView2HostResourceAccessKind.Allow)
            'Editor de composições (pasta Web do programa) e as composições salvas
            Nav.CoreWebView2.SetVirtualHostNameToFolderMapping(HostApp, PastaWebApp(), CoreWebView2HostResourceAccessKind.Allow)
            Directory.CreateDirectory(PastaComposicoes())
            Nav.CoreWebView2.SetVirtualHostNameToFolderMapping(HostComposicoes, PastaComposicoes(), CoreWebView2HostResourceAccessKind.Allow)
            MapearDiscos(Nav.CoreWebView2) 'discos já usados por vídeos/imagens da projeção
            Nav.CoreWebView2.Settings.AreDefaultContextMenusEnabled = False
            Nav.CoreWebView2.Settings.IsStatusBarEnabled = False
            AddHandler Nav.CoreWebView2.NewWindowRequested, Sub(s, e) e.Handled = True 'não abre janelas/pop-ups
            Return True
        Catch ex As Exception
            MsgBox("Não foi possível iniciar o navegador embutido (Microsoft Edge WebView2)." & vbCrLf &
                   "Verifique se o ""Microsoft Edge WebView2 Runtime"" está instalado neste computador." & vbCrLf & vbCrLf & ex.Message,
                   vbCritical, "Internet")
            Return False
        End Try
    End Function

    'Navegadores já iniciados (para liberar um disco novo em todos)
    Public Function NavegadoresProntos() As List(Of CoreWebView2)
        Return Preparando.Where(Function(p) p.Value.IsCompleted AndAlso p.Value.Result AndAlso Not p.Key.IsDisposed AndAlso p.Key.CoreWebView2 IsNot Nothing).
            Select(Function(p) p.Key.CoreWebView2).ToList()
    End Function

    'Abre uma página fixa no navegador uma única vez; todas as chamadas esperam a mesma carga
    Private ReadOnly Paginas As New Dictionary(Of WebView2, Task(Of Boolean))
    Public Function AbrirPagina(Nav As WebView2, Endereco As String) As Task(Of Boolean)
        Dim T As Task(Of Boolean) = Nothing
        If Not Paginas.TryGetValue(Nav, T) OrElse (T.IsCompleted AndAlso Not T.Result) Then
            If T Is Nothing Then AddHandler Nav.Disposed, Sub() Paginas.Remove(Nav)
            T = CarregarPagina(Nav, Endereco)
            Paginas(Nav) = T
        End If
        Return T
    End Function

    Private Async Function CarregarPagina(Nav As WebView2, Endereco As String) As Task(Of Boolean)
        If Not Await PrepararNavegador(Nav) OrElse Nav.IsDisposed Then Return False
        Dim Carregou As New TaskCompletionSource(Of Boolean)
        Dim Ao As EventHandler(Of CoreWebView2NavigationCompletedEventArgs) = Sub(s, e) Carregou.TrySetResult(e.IsSuccess)
        AddHandler Nav.CoreWebView2.NavigationCompleted, Ao
        Nav.Tag = Endereco
        Nav.CoreWebView2.Navigate(Endereco)
        Dim Ok As Boolean = Await Carregou.Task
        RemoveHandler Nav.CoreWebView2.NavigationCompleted, Ao
        Return Ok
    End Function

    'Abre o endereço no navegador (se já não estiver aberto). SemSom = prévia.
    Public Async Function Navegar(Nav As WebView2, Endereco As String, SemSom As Boolean) As Task
        If Not Await PrepararNavegador(Nav) OrElse Nav.IsDisposed Then Exit Function
        Nav.CoreWebView2.IsMuted = SemSom
        If String.Equals(TryCast(Nav.Tag, String), Endereco) Then Exit Function
        Nav.Tag = Endereco
        Nav.CoreWebView2.Navigate(Endereco)
    End Function

    'Limpa a página (para som e vídeo)
    Public Async Function Limpar(Nav As WebView2) As Task
        If Nav.Tag Is Nothing OrElse Nav.IsDisposed Then Exit Function
        Nav.Tag = Nothing
        If Await PrepararNavegador(Nav) AndAlso Not Nav.IsDisposed Then Nav.CoreWebView2.Navigate("about:blank")
    End Function

    Public Async Function ExecutarScript(Nav As WebView2, Script As String) As Task
        If Nav.Tag Is Nothing OrElse Nav.IsDisposed Then Exit Function
        If Not Await PrepararNavegador(Nav) OrElse Nav.IsDisposed Then Exit Function
        Try
            Await Nav.CoreWebView2.ExecuteScriptAsync(Script)
        Catch
            'a página pode estar sendo trocada; ignora
        End Try
    End Function

    '---- Projeção ----

    'Mostra a página atual na tela de projeção, por cima de tudo, e retoma vídeos pausados
    Public Async Sub MostrarPaginaProjecao()
        If InternetLink Is Nothing Then Exit Sub
        Dim Nav As WebView2 = FormApresentar.Navegador
        Dim Retomar As Boolean = String.Equals(TryCast(Nav.Tag, String), InternetLink.Projetar)
        Nav.Visible = True
        Nav.BringToFront()
        Await Navegar(Nav, InternetLink.Projetar, False)
        If Retomar Then Await ExecutarScript(Nav, ScriptRetomar)
    End Sub

    Public Async Sub PausarPaginaProjecao()
        If Not FormApresentar.TemNavegador Then Exit Sub
        Await ExecutarScript(FormApresentar.Navegador, ScriptPausar)
    End Sub

    Public Async Sub EsconderPaginaProjecao()
        If Not FormApresentar.TemNavegador Then Exit Sub
        Dim Nav As WebView2 = FormApresentar.Navegador
        Nav.Visible = False
        Await Limpar(Nav)
    End Sub

    'Endereço de vídeo/áudio a tocar no Windows Media Player da projeção ("" = nenhum).
    'Um link direto da Internet tem prioridade sobre o arquivo da tela Áudio/Vídeo.
    Public Function MidiaAtual() As String
        If InternetOn AndAlso InternetLink IsNot Nothing AndAlso InternetLink.EhMidia Then Return InternetLink.Projetar
        If VideoOn AndAlso File.Exists(Video) Then Return Video
        Return ""
    End Function

    Public Function PaginaInternetAtiva() As Boolean
        Return InternetOn AndAlso InternetLink IsNot Nothing AndAlso Not InternetLink.EhMidia
    End Function

End Module
