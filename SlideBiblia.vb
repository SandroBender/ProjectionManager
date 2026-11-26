Imports Microsoft.Web.WebView2.WinForms

'Projeção do versículo como "slide" no navegador embutido: imagem ilustrativa + texto,
'com os modos "Sem imagem", "Foco alternado" e "Fundo esmaecido" e posição topo/centro/embaixo.
Public Module SlideBiblia

    Public Const EnderecoSlide As String = "https://" & HostLocal & "/biblia.html"
    Public Const HostImagens As String = "imagens." & HostLocal

    'Página servida em https://projectionmanager.example/biblia.html
    Public Const HtmlBiblia As String =
"<!DOCTYPE html>
<html><head><meta charset=""utf-8""><title>Bíblia</title>
<style>
html,body{margin:0;height:100%;overflow:hidden;background:#111;color:#fff;font-family:Calibri,'Segoe UI',Arial,sans-serif;font-weight:bold}
.camada{position:absolute;inset:-3%;background:center/cover no-repeat;opacity:0;transition:opacity 1.2s ease,filter 2s ease}
.camada.visivel{opacity:1}
.camada.mover{animation:zoom 40s ease-in-out infinite alternate}
@keyframes zoom{from{transform:scale(1)}to{transform:scale(1.12) translate(-1.5%,-1%)}}
.camada.esmaecida{filter:brightness(.32) blur(3px)}
#caixa{position:absolute;left:5%;right:5%;text-align:center;opacity:0;
  transition:top 1.5s ease,transform 1.5s ease,font-size 1.5s ease,background-color 1.5s ease,padding 1.5s ease,opacity .6s ease;
  text-shadow:0 0 14px rgba(0,0,0,.95),0 2px 4px #000;border-radius:14px;padding:0}
#caixa.visivel{opacity:1}
#caixa.topo{top:5%;transform:translateY(0)}
#caixa.centro{top:50%;transform:translateY(-50%)}
#caixa.baixo{top:95%;transform:translateY(-100%)}
#caixa.faixa{background-color:rgba(0,0,0,.6);padding:.35em .8em}
#ref{font-size:.55em;opacity:.85;margin-bottom:.35em}
#ref:empty{display:none}
#texto{white-space:pre-line}
#medida{position:absolute;left:5%;right:5%;visibility:hidden;text-align:center;padding:.35em .8em}
</style></head><body>
<div id=""a"" class=""camada mover""></div><div id=""b"" class=""camada mover""></div>
<div id=""caixa""><div id=""ref""></div><div id=""texto""></div></div>
<div id=""medida""><div id=""mref""></div><div id=""mtexto"" style=""white-space:pre-line""></div></div>
<script>
var timer=null, ativa=null, urlAtual='';
function q(id){return document.getElementById(id)}
// maior tamanho (em pt) em que o texto cabe na altura indicada (fração da tela)
function tamanho(base,fracao){
  var m=q('medida'), lim=window.innerHeight*fracao, t=base;
  q('mref').style.fontSize='.55em'; q('mref').style.display=q('ref').textContent?'block':'none';
  q('mref').textContent=q('ref').textContent; q('mtexto').textContent=q('texto').textContent;
  for(var n=0;n<80;n++){ m.style.fontSize=t+'pt'; if(m.scrollHeight<=lim||t<10) break; t*=0.95; }
  return t;
}
function trocarImagem(url,esmaecida){
  var a=q('a'), b=q('b');
  if(!url){ a.classList.remove('visivel'); b.classList.remove('visivel'); urlAtual=''; return; }
  if(url!==urlAtual){
    urlAtual=url;
    var nova=(ativa===a)?b:a, velha=ativa;
    var img=new Image();
    img.onload=img.onerror=function(){
      if(urlAtual!==url) return;
      nova.style.backgroundImage='url(""'+url+'"")';
      nova.classList.toggle('esmaecida',esmaecida);
      nova.classList.add('visivel'); if(velha) velha.classList.remove('visivel'); ativa=nova;
    };
    img.src=url;
  } else if(ativa){ ativa.classList.toggle('esmaecida',esmaecida); }
}
// d: {referencia, texto, imagem, modo: 'sem'|'foco'|'esmaecido', posicao: 'topo'|'centro'|'baixo', tempo (s), fonte (pt)}
function mostrar(d){
  clearTimeout(timer);
  var c=q('caixa');
  q('ref').textContent=d.referencia||''; q('texto').textContent=d.texto||'';
  var comImagem=d.modo!=='sem' && !!d.imagem;
  trocarImagem(comImagem?d.imagem:'', comImagem);
  c.className=d.posicao+' visivel';
  c.style.fontSize=tamanho(d.fonte,.86)+'pt';
  if(comImagem && d.modo==='foco'){
    timer=setTimeout(function(){
      if(ativa) ativa.classList.remove('esmaecida');
      c.className=(d.posicao==='topo'?'topo':'baixo')+' faixa visivel';
      c.style.fontSize=tamanho(Math.min(d.fonte*0.6,40),.32)+'pt';
    }, Math.max(1,d.tempo)*1000);
  }
}
function esconder(){ clearTimeout(timer); q('caixa').className=''; trocarImagem('',false); }
</script>
</body></html>"

    'Monta o texto JSON de forma segura (aspas, barras, quebras de linha)
    Private Function Json(Texto As String) As String
        Dim S As New Text.StringBuilder("""")
        For Each C As Char In If(Texto, "")
            Select Case C
                Case """"c : S.Append("\""")
                Case "\"c : S.Append("\\")
                Case ControlChars.Lf : S.Append("\n")
                Case ControlChars.Cr
                Case ControlChars.Tab : S.Append(" ")
                Case Else
                    If AscW(C) < 32 OrElse C = ChrW(&H2028) OrElse C = ChrW(&H2029) Then S.Append("\u" & AscW(C).ToString("x4")) Else S.Append(C)
            End Select
        Next
        Return S.Append("""").ToString()
    End Function

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

    'Mostra o versículo atual na projeção, por cima do texto clássico.
    'Se o navegador embutido não estiver disponível, o texto clássico (rtbBiblia) continua aparecendo.
    'Carrega a página do slide uma única vez por navegador (todas as chamadas esperam a mesma carga)
    Private SlideNav As WebView2
    Private SlidePronto As Task(Of Boolean)
    Private Function CarregarSlide(Nav As WebView2) As Task(Of Boolean)
        If SlideNav IsNot Nav OrElse SlidePronto Is Nothing OrElse (SlidePronto.IsCompleted AndAlso Not SlidePronto.Result) Then
            SlideNav = Nav
            SlidePronto = NavegarSlide(Nav)
        End If
        Return SlidePronto
    End Function

    Private Async Function NavegarSlide(Nav As WebView2) As Task(Of Boolean)
        If Not Await PrepararNavegador(Nav) OrElse Nav.IsDisposed Then Return False
        Dim Carregou As New TaskCompletionSource(Of Boolean)
        Dim Ao As EventHandler(Of Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs) = Sub(s, e) Carregou.TrySetResult(e.IsSuccess)
        AddHandler Nav.CoreWebView2.NavigationCompleted, Ao
        Nav.Tag = EnderecoSlide
        Nav.CoreWebView2.Navigate(EnderecoSlide)
        Dim Ok As Boolean = Await Carregou.Task
        RemoveHandler Nav.CoreWebView2.NavigationCompleted, Ao
        If Not Ok Then Nav.Tag = Nothing
        Return Ok
    End Function

    Public Async Sub MostrarSlideBiblia(Referencia As String, Texto As String, TamanhoFonte As Single)
        Dim Nav As WebView2 = FormApresentar.NavegadorBiblia
        If Not Await CarregarSlide(Nav) OrElse Nav.IsDisposed Then Exit Sub
        Nav.Visible = True
        Nav.BringToFront()
        Dim Imagem As String = If(ImagemBibliaAtual Is Nothing, "", EnderecoImagem(ImagemBibliaAtual.Caminho))
        Dim Dados As String = "{""referencia"":" & Json(Referencia) & ",""texto"":" & Json(Texto) & ",""imagem"":" & Json(Imagem) &
                              ",""modo"":""" & ModoJs() & """,""posicao"":""" & PosicaoJs() & """,""tempo"":" & Math.Max(1, My.Settings.BibliaTempoFoco) &
                              ",""fonte"":" & TamanhoFonte.ToString(Globalization.CultureInfo.InvariantCulture) & "}"
        Await ExecutarScript(Nav, "mostrar(" & Dados & ");")
    End Sub

    Public Async Sub EsconderSlideBiblia()
        If Not FormApresentar.TemNavegadorBiblia Then Exit Sub
        Dim Nav As WebView2 = FormApresentar.NavegadorBiblia
        If Not Nav.Visible Then Exit Sub
        Nav.Visible = False
        Await ExecutarScript(Nav, "esconder();")
    End Sub

End Module
