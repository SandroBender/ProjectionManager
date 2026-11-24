Imports System.Text.RegularExpressions

'Interpretação dos links da internet: página comum, vídeo do YouTube ou arquivo de mídia direto.
'Não depende de telas: pode ser testado isoladamente.
Public Module LinksInternet

    'Endereço local (fictício) usado pelo navegador embutido para servir a página do YouTube
    Public Const HostLocal As String = "projectionmanager.example"

    Public Enum TipoLink
        Pagina      'qualquer site: abre no navegador embutido (WebView2)
        YouTube     'vídeo do YouTube: abre o player incorporado em tela cheia
        Midia       'arquivo de vídeo/áudio (.mp4, .mp3...): toca no Windows Media Player
    End Enum

    Public Class InfoLink
        Public Tipo As TipoLink
        Public Original As String   'link como foi digitado (normalizado)
        Public Projetar As String   'endereço exibido na projeção
        Public Previa As String     'endereço exibido na prévia (sem som)
        Public Descricao As String  'texto para o usuário

        Public ReadOnly Property EhMidia As Boolean
            Get
                Return Tipo = TipoLink.Midia
            End Get
        End Property
    End Class

    Private ReadOnly ExtensoesMidia As New HashSet(Of String)(
        {".mp4", ".m4v", ".mov", ".wmv", ".avi", ".mpg", ".mpeg", ".mp3", ".wav", ".wma", ".m4a", ".aac"},
        StringComparer.OrdinalIgnoreCase)

    Private ReadOnly RegexIdYouTube As New Regex("^[A-Za-z0-9_-]{11}$")

    'Converte o texto digitado em um link utilizável. Retorna Nothing se não for um link válido.
    Public Function InterpretarLink(Texto As String) As InfoLink
        If String.IsNullOrWhiteSpace(Texto) Then Return Nothing
        Dim T As String = Texto.Trim()
        If Not T.Contains("://") Then T = "https://" & T 'aceita "www.site.com" sem https://
        Dim Url As Uri = Nothing
        If Not Uri.TryCreate(T, UriKind.Absolute, Url) Then Return Nothing
        If Url.Scheme <> Uri.UriSchemeHttp AndAlso Url.Scheme <> Uri.UriSchemeHttps Then Return Nothing
        If Not Url.Host.Contains(".") AndAlso Url.Host <> "localhost" Then Return Nothing

        Dim Info As New InfoLink With {.Original = Url.AbsoluteUri}
        Dim Inicio As Integer = 0
        Dim Id As String = IdYouTube(Url, Inicio)
        If Id IsNot Nothing Then
            Info.Tipo = TipoLink.YouTube
            Info.Projetar = EnderecoYouTube(Id, Inicio, False)
            Info.Previa = EnderecoYouTube(Id, Inicio, True)
            Info.Descricao = "Vídeo do YouTube (" & Id & ")" & If(Inicio > 0, " a partir de " & FormatarTempo(Inicio), "")
        ElseIf ExtensoesMidia.Contains(IO.Path.GetExtension(Url.AbsolutePath)) Then
            Info.Tipo = TipoLink.Midia
            Info.Projetar = Url.AbsoluteUri
            Info.Previa = Url.AbsoluteUri
            Info.Descricao = "Arquivo de vídeo/áudio (" & IO.Path.GetFileName(Uri.UnescapeDataString(Url.AbsolutePath)) & ")"
        Else
            Info.Tipo = TipoLink.Pagina
            Info.Projetar = Url.AbsoluteUri
            Info.Previa = Url.AbsoluteUri
            Info.Descricao = "Página da internet (" & Url.Host & ")"
        End If
        Return Info
    End Function

    'Reconhece youtube.com/watch?v=, youtu.be/, /shorts/, /live/ e /embed/. Retorna Nothing se não for YouTube.
    Public Function IdYouTube(Url As Uri, ByRef Inicio As Integer) As String
        Inicio = 0
        Dim Host As String = Url.Host.ToLowerInvariant()
        If Host.StartsWith("www.") Then Host = Host.Substring(4)
        If Host.StartsWith("m.") Then Host = Host.Substring(2)
        Dim Partes() As String = Url.AbsolutePath.Trim("/"c).Split("/"c)
        Dim Parametros As Dictionary(Of String, String) = ParametrosConsulta(Url.Query)
        Dim Id As String = Nothing
        If Host = "youtu.be" Then
            Id = Partes(0)
        ElseIf Host = "youtube.com" OrElse Host = "music.youtube.com" OrElse Host = "youtube-nocookie.com" Then
            If Partes(0).Equals("watch", StringComparison.OrdinalIgnoreCase) Then
                Parametros.TryGetValue("v", Id)
            ElseIf Partes.Length >= 2 AndAlso {"shorts", "live", "embed", "v"}.Contains(Partes(0).ToLowerInvariant()) Then
                Id = Partes(1)
            End If
        End If
        If Id Is Nothing OrElse Not RegexIdYouTube.IsMatch(Id) Then Return Nothing
        Dim Tempo As String = Nothing
        If Parametros.TryGetValue("t", Tempo) OrElse Parametros.TryGetValue("start", Tempo) Then Inicio = SegundosDeTempo(Tempo)
        Return Id
    End Function

    'Página local que incorpora o player do YouTube (o YouTube exige que o player esteja dentro de uma página)
    Public Function EnderecoYouTube(Id As String, Inicio As Integer, SemSom As Boolean) As String
        Return "https://" & HostLocal & "/youtube.html?v=" & Id & If(Inicio > 0, "&start=" & Inicio, "") & If(SemSom, "&mute=1", "")
    End Function

    Private Function ParametrosConsulta(Query As String) As Dictionary(Of String, String)
        Dim D As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
        For Each Par As String In Query.TrimStart("?"c).Split("&"c)
            If Par = "" Then Continue For
            Dim I As Integer = Par.IndexOf("="c)
            Dim Chave As String = Uri.UnescapeDataString(If(I < 0, Par, Par.Substring(0, I)))
            Dim Valor As String = If(I < 0, "", Uri.UnescapeDataString(Par.Substring(I + 1).Replace("+", " ")))
            If Not D.ContainsKey(Chave) Then D(Chave) = Valor
        Next
        Return D
    End Function

    'Aceita "90", "90s", "1m30s", "1h2m3s"
    Public Function SegundosDeTempo(Tempo As String) As Integer
        If String.IsNullOrWhiteSpace(Tempo) Then Return 0
        Dim Somente As Integer
        If Integer.TryParse(Tempo, Somente) Then Return Math.Max(0, Somente)
        Dim M As Match = Regex.Match(Tempo.ToLowerInvariant(), "^(?:(\d+)h)?(?:(\d+)m)?(?:(\d+)s)?$")
        If Not M.Success Then Return 0
        Dim Total As Integer = 0
        If M.Groups(1).Success Then Total += CInt(M.Groups(1).Value) * 3600
        If M.Groups(2).Success Then Total += CInt(M.Groups(2).Value) * 60
        If M.Groups(3).Success Then Total += CInt(M.Groups(3).Value)
        Return Total
    End Function

    Public Function FormatarTempo(Segundos As Integer) As String
        Dim T As TimeSpan = TimeSpan.FromSeconds(Segundos)
        Return If(T.Hours > 0, T.ToString("h\:mm\:ss"), T.ToString("m\:ss"))
    End Function

    'Página servida em https://projectionmanager.example/youtube.html (pasta local mapeada no WebView2)
    Public Const HtmlYouTube As String =
"<!DOCTYPE html>
<html><head><meta charset=""utf-8""><title>YouTube</title>
<style>html,body{margin:0;height:100%;background:#000;overflow:hidden}iframe{border:0;width:100%;height:100%}</style>
</head><body>
<iframe id=""yt"" allow=""autoplay; encrypted-media; fullscreen; picture-in-picture"" allowfullscreen referrerpolicy=""strict-origin-when-cross-origin""></iframe>
<script>
var p=new URLSearchParams(location.search);
var v=p.get('v')||'', s=parseInt(p.get('start')||'0',10)||0, m=p.get('mute')==='1'?1:0;
document.getElementById('yt').src='https://www.youtube.com/embed/'+encodeURIComponent(v)+
  '?autoplay=1&rel=0&playsinline=1&enablejsapi=1&mute='+m+(s?'&start='+s:'')+'&origin='+encodeURIComponent(location.origin);
</script>
</body></html>"

    'Pausa/retoma vídeos e áudios da página, inclusive o player do YouTube (via mensagens do player)
    Public Const ScriptPausar As String =
        "(function(){document.querySelectorAll('video,audio').forEach(function(m){m.pause()});" &
        "document.querySelectorAll('iframe').forEach(function(f){try{f.contentWindow.postMessage(JSON.stringify({event:'command',func:'pauseVideo',args:''}),'*')}catch(e){}});})();"
    Public Const ScriptRetomar As String =
        "(function(){document.querySelectorAll('video,audio').forEach(function(m){var r=m.play();if(r&&r.catch)r.catch(function(){})});" &
        "document.querySelectorAll('iframe').forEach(function(f){try{f.contentWindow.postMessage(JSON.stringify({event:'command',func:'playVideo',args:''}),'*')}catch(e){}});})();"

End Module
