// Tela de projeção - ProjectionManager
// O programa chama aplicar(estado) com tudo o que deve aparecer; a página só desenha.
'use strict';

const PREVIA = new URLSearchParams(location.search).get('previa') === '1';
const $ = s => document.querySelector(s);
const host = window.chrome && window.chrome.webview;
const avisarHost = m => { if (host) host.postMessage(m); };

// os quadros internos (fundo/sobreposição e Bíblia) podem ainda estar carregando: espera por eles
function quandoCarregar(iframe) {
  return new Promise(ok => {
    const pronto = () => { try { return iframe.contentWindow.document.readyState === 'complete'; } catch (x) { return false; } };
    if (pronto()) ok(); else iframe.addEventListener('load', () => ok(), { once: true });
  });
}
const camadasProntas = quandoCarregar($('#camadas'));
const bibliaPronta = quandoCarregar($('#biblia'));

function mostrar(el, sim) { el.classList.toggle('visivel', !!sim); }

// ---------- fundo e sobreposição ----------
let ultimasCamadas = '';
async function aplicarCamadas(fundo, sobre) {
  const chave = (fundo || '') + '\u0000' + (sobre || '');
  mostrar($('#camadas'), fundo || sobre);
  if (chave === ultimasCamadas) return;
  ultimasCamadas = chave;
  await camadasProntas;
  const w = $('#camadas').contentWindow;
  if (fundo || sobre) w.renderizarCamadas(fundo || null, sobre || null); else w.limpar();
}

// ---------- imagem da tela Áudio/Vídeo ----------
function aplicarImagem(url) {
  const el = $('#imagem');
  if (url) el.style.backgroundImage = `url("${url}")`;
  mostrar(el, url);
}

// ---------- vídeo / áudio ----------
const video = $('#midia');
let midiaAtual = '';
function aplicarMidia(m, pausado) {
  if (PREVIA) { mostrar(video, false); return; } // a prévia não toca (só mostra o aviso)
  if (!m || !m.url) {
    if (midiaAtual) { video.pause(); video.removeAttribute('src'); video.load(); midiaAtual = ''; }
    mostrar(video, false);
    return;
  }
  video.classList.toggle('somente-audio', !m.video);
  mostrar(video, true);
  if (m.url !== midiaAtual) {
    midiaAtual = m.url;
    video.src = m.url;
    video.currentTime = 0;
  }
  if (pausado) video.pause();
  else video.play().catch(() => {}); // um erro de formato é avisado pelo evento "error"
}
video.addEventListener('error', () => {
  if (!midiaAtual) return;
  const c = video.error ? video.error.code : 0;
  avisarHost({ acao: 'midiaErro', url: midiaAtual, codigo: c });
});

// ---------- Harpa ----------
function tamanhoQueCabe(texto, base, fracao) {
  const m = $('#medidaHarpa'), lim = window.innerHeight * fracao;
  m.textContent = texto;
  let t = base;
  for (let n = 0; n < 80; n++) { m.style.fontSize = t + 'pt'; if (m.scrollHeight <= lim || t < 10) break; t *= 0.95; }
  return t;
}
function aplicarHarpa(h) {
  const el = $('#harpa');
  if (h && h.texto) {
    const t = $('#harpaTexto');
    t.textContent = h.texto;
    t.style.fontSize = tamanhoQueCabe(h.texto, h.fonte || 54, 0.92) + 'pt';
  }
  mostrar(el, h && h.texto);
}

// ---------- Bíblia (slide com imagem, em biblia.html) ----------
let bibliaVisivel = false;
async function aplicarBiblia(b) {
  await bibliaPronta;
  const w = $('#biblia').contentWindow;
  if (b) { w.mostrar(b); bibliaVisivel = true; }
  else if (bibliaVisivel) { w.esconder(); bibliaVisivel = false; }
  mostrar($('#biblia'), b);
}

// ---------- aviso (só na prévia) ----------
function aplicarAviso(texto) {
  const a = $('#aviso');
  a.textContent = texto || '';
  a.classList.toggle('visivel', PREVIA && !!texto);
}

// ---------- entrada principal ----------
let ultimoEstado = null;
window.aplicar = function (estado) {
  const e = (typeof estado === 'string') ? JSON.parse(estado) : estado;
  ultimoEstado = e;
  if (!e.ativo) { // Neutra/Fechada: tela preta
    aplicarCamadas(null, null); aplicarImagem(null); aplicarMidia(null); aplicarHarpa(null); aplicarBiblia(null); aplicarAviso(null);
    return;
  }
  aplicarCamadas(e.fundo, e.sobreposicao);
  aplicarImagem(e.imagem);
  aplicarMidia(e.midia, false);
  aplicarHarpa(e.harpa);
  aplicarBiblia(e.biblia);
  aplicarAviso(e.aviso);
};
// Pausada: congela o que está na tela e pausa o vídeo/áudio
window.pausar = function () {
  if (!PREVIA && midiaAtual) video.pause();
  if (ultimoEstado && ultimoEstado.ativo && ultimoEstado.aviso) aplicarAviso(ultimoEstado.aviso + '  (PAUSADO)');
};

window.addEventListener('resize', () => { if (ultimoEstado && ultimoEstado.harpa) aplicarHarpa(ultimoEstado.harpa); });
if (PREVIA) document.body.style.cursor = 'default';
