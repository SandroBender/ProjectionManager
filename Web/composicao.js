// Editor de composições da tela Fundo - ProjectionManager
// A composição é desenhada num "palco" de 1920x1080 (o telão), em escala.
// O mesmo código desenha o editor (modo=editor), o telão e a prévia (modo=projecao).
'use strict';

const W = 1920, H = 1080;
const MODO = new URLSearchParams(location.search).get('modo') || 'editor';
// camada: 'fundo' (tela Fundo) ou 'sobreposicao' (tela Imagens, por cima do fundo, com fundo transparente)
const CAMADA = new URLSearchParams(location.search).get('camada') || 'fundo';
const SOBREPOSICAO = CAMADA === 'sobreposicao';
const BASE_IMAGENS = window.BASE_IMAGENS || 'https://composicoes.projectionmanager.example/';
const $ = s => document.querySelector(s);

// ---------- comunicação com o programa (WebView2) ----------
const host = window.chrome && window.chrome.webview;
function enviarHost(msg) { if (host) host.postMessage(msg); }
if (host) host.addEventListener('message', e => receberHost(e.data));

// ---------- documento ----------
function novoDoc() { return { versao: 1, fundo: SOBREPOSICAO ? 'transparent' : '#000000', elementos: [] }; }
let doc = novoDoc();
let seq = 1;
const novoId = () => 'e' + Date.now().toString(36) + (seq++);

function elTexto(x, y, texto) {
  return { id: novoId(), tipo: 'texto', x: x, y: y, w: 1000, h: 120, rot: 0, opacidade: 1, texto: texto || '',
    fonte: 'Calibri', tamanho: 80, negrito: true, italico: false, sublinhado: false, cor: '#ffffff',
    alinhamento: 'center', linha: 1.15, fundoCor: '#000000', fundoOpacidade: 0, raio: 14, margem: 18,
    sombra: true, contornoCor: '#000000', contornoLargura: 0 };
}
function elImagem(src, larg, alt) {
  let w = 1280, h = 720;
  if (larg > 0 && alt > 0) { const k = Math.min(1600 / larg, 900 / alt); w = Math.round(larg * k); h = Math.round(alt * k); }
  return { id: novoId(), tipo: 'imagem', x: Math.round((W - w) / 2), y: Math.round((H - h) / 2), w: w, h: h, rot: 0, opacidade: 1,
    src: src || '', ajuste: 'cobrir', bordaLargura: 0, bordaCor: '#ffffff', raio: 0, sombra: false };
}
function elForma() {
  return { id: novoId(), tipo: 'forma', x: 0, y: 760, w: W, h: 240, rot: 0, opacidade: 0.6,
    cor: '#000000', raio: 0, bordaLargura: 0, bordaCor: '#ffffff' };
}

function rgba(hex, a) {
  const m = /^#?([0-9a-f]{2})([0-9a-f]{2})([0-9a-f]{2})$/i.exec(hex || '#000000') || [0, '00', '00', '00'];
  return `rgba(${parseInt(m[1], 16)},${parseInt(m[2], 16)},${parseInt(m[3], 16)},${a})`;
}
function urlImagem(src) {
  if (!src) return '';
  if (/^(https?:|data:|blob:)/i.test(src)) return src;
  return BASE_IMAGENS + src.split('/').map(encodeURIComponent).join('/');
}

// ---------- desenho ----------
function criarPalco(d) {
  const p = document.createElement('div');
  p.className = 'palco';
  p.style.background = d.fundo || '#000';
  for (const e of d.elementos) p.appendChild(criarEl(e));
  return p;
}
function criarEl(e) {
  const n = document.createElement('div');
  n.className = 'el';
  n.dataset.id = e.id;
  aplicarEl(n, e);
  return n;
}
function filho(n, classe) {
  let f = n.querySelector(':scope > .' + classe);
  if (!f) { f = document.createElement('div'); f.className = classe; n.appendChild(f); }
  return f;
}
function aplicarEl(n, e) {
  n.style.left = e.x + 'px';
  n.style.top = e.y + 'px';
  n.style.width = e.w + 'px';
  n.style.height = e.tipo === 'texto' ? 'auto' : e.h + 'px';
  n.style.transform = e.rot ? `rotate(${e.rot}deg)` : '';
  n.style.opacity = e.opacidade == null ? 1 : e.opacidade;
  if (e.tipo === 'imagem') {
    const i = filho(n, 'img');
    i.style.backgroundImage = e.src ? `url("${urlImagem(e.src)}")` : 'none';
    i.style.backgroundColor = e.src ? 'transparent' : '#333';
    i.style.backgroundSize = e.ajuste === 'conter' ? 'contain' : e.ajuste === 'esticar' ? '100% 100%' : 'cover';
    i.style.border = e.bordaLargura > 0 ? `${e.bordaLargura}px solid ${e.bordaCor}` : (e.src ? 'none' : '4px dashed #888');
    i.style.borderRadius = (e.raio || 0) + 'px';
    i.style.boxShadow = e.sombra ? '0 14px 44px rgba(0,0,0,.8)' : 'none';
  } else if (e.tipo === 'forma') {
    const f = filho(n, 'forma');
    f.style.background = e.cor;
    f.style.border = e.bordaLargura > 0 ? `${e.bordaLargura}px solid ${e.bordaCor}` : 'none';
    f.style.borderRadius = (e.raio || 0) + 'px';
  } else if (e.tipo === 'texto') {
    const t = filho(n, 'txt');
    if (t.contentEditable !== 'true' && t.contentEditable !== 'plaintext-only' && t.textContent !== e.texto) t.textContent = e.texto;
    t.style.fontFamily = `"${String(e.fonte).replace(/"/g, '')}", Calibri, Arial, sans-serif`;
    t.style.fontSize = e.tamanho + 'px';
    t.style.fontWeight = e.negrito ? 'bold' : 'normal';
    t.style.fontStyle = e.italico ? 'italic' : 'normal';
    t.style.textDecoration = e.sublinhado ? 'underline' : 'none';
    t.style.color = e.cor;
    t.style.textAlign = e.alinhamento;
    t.style.lineHeight = e.linha;
    t.style.background = e.fundoOpacidade > 0 ? rgba(e.fundoCor, e.fundoOpacidade) : 'transparent';
    t.style.borderRadius = (e.raio || 0) + 'px';
    t.style.padding = (e.margem || 0) + 'px';
    t.style.textShadow = e.sombra ? '0 4px 16px rgba(0,0,0,.85), 0 2px 3px rgba(0,0,0,.9)' : 'none';
    t.style.webkitTextStroke = e.contornoLargura > 0 ? `${e.contornoLargura}px ${e.contornoCor}` : '';
    t.style.paintOrder = 'stroke fill';
  }
}

// Desenha a composição ocupando o contêiner (barras pretas se a proporção for diferente)
function encaixar(palco, cont, margem) {
  const cw = cont.clientWidth, ch = cont.clientHeight, m = margem || 0;
  const k = Math.max(0.01, Math.min((cw - 2 * m) / W, (ch - 2 * m) / H));
  palco.style.transform = `translate(${(cw - W * k) / 2}px, ${(ch - H * k) / 2}px) scale(${k})`;
  return k;
}
function miniatura(d, cont) {
  const p = criarPalco(d);
  cont.appendChild(p);
  requestAnimationFrame(() => encaixar(p, cont, 0));
}

// ---------- modo projeção (telão e prévia) ----------
// desenha uma ou mais camadas empilhadas (fundo embaixo, sobreposição por cima); null = camada desligada
function renderizarCamadas(...camadas) {
  const c = $('#projecao');
  c.innerHTML = '';
  for (let d of camadas) {
    if (!d) continue;
    if (typeof d === 'string') d = JSON.parse(d);
    const p = criarPalco(d);
    c.appendChild(p);
    encaixar(p, c, 0);
  }
}
function renderizar(d) { renderizarCamadas(d); }
function limpar() { $('#projecao').innerHTML = ''; }
window.renderizarCamadas = renderizarCamadas;
window.renderizar = renderizar;
window.limpar = limpar;

// ======================================================================
//                               EDITOR
// ======================================================================
let palco = null, camadaSel = null, escala = 1, selId = null, editandoId = null;
let nomeAtual = '', alterado = false;
let historico = [], posHist = -1;
let fontes = ['Calibri', 'Arial', 'Segoe UI', 'Times New Roman', 'Georgia', 'Verdana', 'Tahoma', 'Impact'];
let composicoes = [], textosSalvos = [];
let referencia = null, mostrarReferencia = true, palcoRef = null; // fundo atual, só para visualizar (sobreposição)
const porId = id => doc.elementos.find(e => e.id === id);
const noDe = id => palco && palco.querySelector(`.el[data-id="${id}"]`);
const selecionado = () => porId(selId);

function montarPalco() {
  const area = $('#palcoEditor');
  area.innerHTML = '';
  palco = criarPalco(doc);
  // seleção e guias ficam numa camada por cima, sem o corte das bordas do palco
  camadaSel = document.createElement('div');
  camadaSel.className = 'palco camada-sel';
  // sobreposição: o fundo atual aparece por baixo, só como referência (não é salvo junto)
  palcoRef = null;
  if (SOBREPOSICAO) {
    palcoRef = (referencia && mostrarReferencia) ? criarPalco(referencia) : criarPalco({ fundo: '#000000', elementos: [] });
    palcoRef.classList.add('camada-ref');
    area.appendChild(palcoRef);
    palco.classList.add('transparente');
  }
  area.append(palco, camadaSel);
  reencaixar();
  medirTextos();
  desenharSelecao();
}
function reencaixar() {
  escala = encaixar(palco, $('#palcoEditor'), 18);
  camadaSel.style.transform = palco.style.transform;
  if (palcoRef) palcoRef.style.transform = palco.style.transform;
}
function medirTextos() {
  for (const e of doc.elementos) if (e.tipo === 'texto') { const n = noDe(e.id); if (n) e.h = Math.round(n.offsetHeight); }
}
function atualizarEl(e) {
  const n = noDe(e.id);
  if (!n) return;
  aplicarEl(n, e);
  if (e.tipo === 'texto') e.h = Math.round(n.offsetHeight);
  if (e.id === selId) desenharSelecao();
}

// ---------- seleção e alças ----------
const ALCAS = { nw: [-1, -1], n: [0, -1], ne: [1, -1], e: [1, 0], se: [1, 1], s: [0, 1], sw: [-1, 1], w: [-1, 0] };
function desenharSelecao() {
  if (!palco) return;
  camadaSel.querySelectorAll('.selecao').forEach(x => x.remove()); // as guias são limpas pelo arraste
  const e = selecionado();
  if (!e) return;
  const s = document.createElement('div');
  s.className = 'selecao';
  s.style.left = e.x + 'px'; s.style.top = e.y + 'px';
  s.style.width = e.w + 'px'; s.style.height = e.h + 'px';
  s.style.transform = e.rot ? `rotate(${e.rot}deg)` : '';
  s.style.borderWidth = (2 / escala) + 'px';
  const tam = 14 / escala;
  const nomes = e.tipo === 'texto' ? ['e', 'w'] : Object.keys(ALCAS);
  for (const a of nomes.concat(['rot'])) {
    const h = document.createElement('div');
    h.className = 'alca' + (a === 'rot' ? ' rot' : '');
    h.dataset.alca = a;
    h.style.width = h.style.height = tam + 'px';
    h.style.borderWidth = (2 / escala) + 'px';
    const [sx, sy] = a === 'rot' ? [0, -1] : ALCAS[a];
    h.style.left = `calc(${(sx + 1) * 50}% - ${tam / 2}px)`;
    h.style.top = a === 'rot' ? `${-tam - 40 / escala}px` : `calc(${(sy + 1) * 50}% - ${tam / 2}px)`;
    h.style.cursor = a === 'rot' ? 'grab' : ({ nw: 'nwse', se: 'nwse', ne: 'nesw', sw: 'nesw', n: 'ns', s: 'ns', e: 'ew', w: 'ew' })[a] + '-resize';
    if (a === 'rot') h.style.setProperty('--haste', (40 / escala) + 'px');
    s.appendChild(h);
  }
  camadaSel.appendChild(s);
}
function selecionar(id) {
  if (editandoId && editandoId !== id) sairEdicao();
  selId = id;
  desenharSelecao();
  montarPainel();
}

// ---------- histórico (desfazer/refazer) e "ao vivo" ----------
function registrar() {
  const s = JSON.stringify(doc);
  if (historico[posHist] === s) return;
  historico = historico.slice(0, posHist + 1);
  historico.push(s);
  if (historico.length > 150) historico.shift();
  posHist = historico.length - 1;
  marcarAlterado(true);
  aoVivoAgora();
}
function reiniciarHistorico() { historico = [JSON.stringify(doc)]; posHist = 0; atualizarBotoesHist(); }
function irHistorico(passo) {
  const novo = posHist + passo;
  if (novo < 0 || novo >= historico.length) return;
  posHist = novo;
  doc = JSON.parse(historico[posHist]);
  if (!porId(selId)) selId = null;
  editandoId = null;
  montarPalco(); montarPainel(); marcarAlterado(true); aoVivoAgora();
}
function atualizarBotoesHist() {
  $('#bDesfazer').disabled = posHist <= 0;
  $('#bRefazer').disabled = posHist >= historico.length - 1;
}
function marcarAlterado(sim) {
  alterado = sim;
  $('#nome').textContent = nomeAtual || 'Sem nome';
  $('#nome').classList.toggle('alterado', sim);
  atualizarBotoesHist();
}
let timerVivo = null;
function aoVivo() { // durante o arraste: no máximo ~8 envios por segundo
  if (!$('#aoVivo').checked || timerVivo) return;
  timerVivo = setTimeout(() => { timerVivo = null; aoVivoAgora(); }, 120);
}
function aoVivoAgora() {
  if ($('#aoVivo').checked) enviarHost({ acao: 'aoVivo', docJson: JSON.stringify(doc) });
}

// ---------- mouse: mover, redimensionar, girar ----------
function pontoPalco(ev) {
  const r = palco.getBoundingClientRect();
  return { x: (ev.clientX - r.left) / escala, y: (ev.clientY - r.top) / escala };
}
let arraste = null;

function iniciarArraste(ev) {
  if (ev.button !== 0) return;
  // tira o foco de campos do painel, para as setas e o Delete agirem na tela
  const ae = document.activeElement;
  if (ae && ae !== document.body && !ae.closest('.txt')) ae.blur();
  const alca = ev.target.closest('.alca');
  const no = ev.target.closest('.el');
  if (alca) {
    const e = selecionado();
    arraste = { tipo: alca.dataset.alca === 'rot' ? 'girar' : 'redimensionar', alca: alca.dataset.alca, e: e, ini: { ...e }, p0: pontoPalco(ev) };
  } else if (no) {
    const id = no.dataset.id;
    if (id === editandoId) return; // clique dentro do texto em edição: posiciona o cursor
    if (id !== selId) selecionar(id);
    const e = porId(id);
    arraste = { tipo: 'mover', e: e, ini: { ...e }, p0: pontoPalco(ev) };
  } else {
    if (editandoId) sairEdicao();
    selecionar(null);
    return;
  }
  palco.setPointerCapture(ev.pointerId);
  ev.preventDefault();
}

function moverArraste(ev) {
  if (!arraste) return;
  const p = pontoPalco(ev), a = arraste, e = a.e, i = a.ini;
  const dx = p.x - a.p0.x, dy = p.y - a.p0.y;
  camadaSel.querySelectorAll('.guia').forEach(g => g.remove());
  if (a.tipo === 'mover') {
    let x = i.x + dx, y = i.y + dy;
    if (!ev.altKey) [x, y] = encaixarGuias(e, x, y);
    e.x = Math.round(x); e.y = Math.round(y);
  } else if (a.tipo === 'redimensionar') {
    const [sx, sy] = ALCAS[a.alca];
    const ang = (i.rot || 0) * Math.PI / 180, cos = Math.cos(ang), sin = Math.sin(ang);
    const lx = dx * cos + dy * sin, ly = -dx * sin + dy * cos; // deslocamento no eixo do elemento
    let w = i.w + sx * lx, h = i.h + sy * ly;
    const travar = (e.tipo === 'imagem') !== ev.shiftKey; // imagem mantém a proporção (Shift solta)
    if (travar && sx !== 0 && sy !== 0) {
      const k = Math.max(w / i.w, h / i.h);
      w = i.w * k; h = i.h * k;
    }
    w = Math.max(30, w); h = e.tipo === 'texto' ? i.h : Math.max(30, h);
    // a borda oposta fica parada
    const mx = sx * (w - i.w) / 2, my = sy * (h - i.h) / 2;
    const cx = i.x + i.w / 2 + mx * cos - my * sin, cy = i.y + i.h / 2 + mx * sin + my * cos;
    e.w = Math.round(w); if (e.tipo !== 'texto') e.h = Math.round(h);
    e.x = Math.round(cx - w / 2); e.y = Math.round(cy - h / 2);
  } else if (a.tipo === 'girar') {
    const cx = i.x + i.w / 2, cy = i.y + i.h / 2;
    let ang = Math.atan2(p.y - cy, p.x - cx) * 180 / Math.PI + 90;
    if (ev.shiftKey) ang = Math.round(ang / 15) * 15;
    else for (const alvo of [0, 90, 180, 270, 360, -90]) if (Math.abs(ang - alvo) < 4) ang = alvo;
    ang = ((Math.round(ang) % 360) + 360) % 360;
    e.rot = ang > 180 ? ang - 360 : ang;
  }
  atualizarEl(e);
  atualizarCamposPosicao();
  aoVivo();
}

function terminarArraste() {
  if (!arraste) return;
  arraste = null;
  camadaSel.querySelectorAll('.guia').forEach(g => g.remove());
  registrar();
}

// Guias de alinhamento: bordas e centro da tela e dos outros elementos
function encaixarGuias(e, x, y) {
  const lim = 10 / escala;
  const vx = [0, W / 2, W], vy = [0, H / 2, H];
  for (const o of doc.elementos) {
    if (o === e || o.rot) continue;
    vx.push(o.x, o.x + o.w / 2, o.x + o.w);
    vy.push(o.y, o.y + o.h / 2, o.y + o.h);
  }
  const melhor = (pos, tam, linhas) => {
    let m = null;
    for (const [k, off] of [[0, 0], [1, tam / 2], [2, tam]]) for (const l of linhas) {
      const d = l - (pos + off);
      if (Math.abs(d) <= lim && (!m || Math.abs(d) < Math.abs(m.d))) m = { d: d, l: l };
    }
    return m;
  };
  const mx = melhor(x, e.w, vx), my = melhor(y, e.h, vy);
  if (mx) { x += mx.d; guia(mx.l, null); }
  if (my) { y += my.d; guia(null, my.l); }
  return [x, y];
}
function guia(x, y) {
  const g = document.createElement('div');
  g.className = 'guia';
  const t = 2 / escala;
  if (x != null) Object.assign(g.style, { left: (x - t / 2) + 'px', top: 0, width: t + 'px', height: H + 'px' });
  else Object.assign(g.style, { top: (y - t / 2) + 'px', left: 0, height: t + 'px', width: W + 'px' });
  camadaSel.appendChild(g);
}

// ---------- edição do texto no lugar ----------
function entrarEdicao(id) {
  const e = porId(id);
  if (!e || e.tipo !== 'texto') return;
  selecionar(id);
  editandoId = id;
  const t = noDe(id).querySelector('.txt');
  try { t.contentEditable = 'plaintext-only'; } catch (x) { t.contentEditable = 'true'; }
  if (t.contentEditable !== 'plaintext-only') t.contentEditable = 'true';
  t.focus();
  const r = document.createRange(); r.selectNodeContents(t);
  const s = getSelection(); s.removeAllRanges(); s.addRange(r);
  $('#status').textContent = 'Editando o texto: Enter quebra a linha, Esc ou clique fora termina.';
}
function sairEdicao() {
  const id = editandoId;
  editandoId = null;
  const n = noDe(id), e = porId(id);
  if (!n || !e) return;
  const t = n.querySelector('.txt');
  e.texto = t.innerText.replace(/\n$/, '');
  t.contentEditable = 'false';
  t.blur();
  atualizarEl(e);
  $('#status').textContent = 'Pronto.';
  registrar();
  montarPainel();
}
function textoDigitado(ev) {
  const t = ev.target.closest('.txt');
  if (!t || !editandoId) return;
  const e = porId(editandoId);
  e.texto = t.innerText.replace(/\n$/, '');
  e.h = Math.round(noDe(editandoId).offsetHeight);
  desenharSelecao();
  aoVivo();
}

// ---------- operações ----------
function adicionar(e) {
  doc.elementos.push(e);
  montarPalco();
  selecionar(e.id);
  registrar();
}
function remover() {
  if (!selId) return;
  doc.elementos = doc.elementos.filter(e => e.id !== selId);
  selId = null; editandoId = null;
  montarPalco(); montarPainel(); registrar();
}
function duplicar() {
  const e = selecionado();
  if (!e) return;
  const c = JSON.parse(JSON.stringify(e));
  c.id = novoId(); c.x += 40; c.y += 40;
  adicionar(c);
}
function camada(onde) {
  const e = selecionado();
  if (!e) return;
  const l = doc.elementos, i = l.indexOf(e);
  l.splice(i, 1);
  const pos = onde === 'frente' ? l.length : onde === 'tras' ? 0 : onde === 'subir' ? Math.min(l.length, i + 1) : Math.max(0, i - 1);
  l.splice(pos, 0, e);
  montarPalco(); registrar();
}
function centralizar(eixo) {
  const e = selecionado();
  if (!e) return;
  if (eixo !== 'v') e.x = Math.round((W - e.w) / 2);
  if (eixo !== 'h') e.y = Math.round((H - e.h) / 2);
  atualizarEl(e); atualizarCamposPosicao(); registrar();
}
function abrirDoc(d, nome) {
  doc = (typeof d === 'string') ? JSON.parse(d) : JSON.parse(JSON.stringify(d));
  if (!doc.elementos) doc.elementos = [];
  for (const e of doc.elementos) if (!e.id) e.id = novoId();
  nomeAtual = nome || '';
  selId = null; editandoId = null;
  montarPalco(); montarPainel(); reiniciarHistorico(); marcarAlterado(false);
  aoVivoAgora();
}
function confirmarDescarte() {
  return !alterado || confirm('A composição atual tem alterações não salvas. Deseja descartá-las?');
}

// ---------- painel de propriedades ----------
function campo(rotulo, el) {
  const d = document.createElement('div');
  d.className = 'linha';
  const s = document.createElement('span');
  s.textContent = rotulo;
  d.append(s, el);
  return d;
}
// cria um controle ligado a uma propriedade do elemento (ou do documento)
function controle(obj, prop, tipo, op) {
  op = op || {};
  let el;
  if (tipo === 'select') {
    el = document.createElement('select');
    for (const [v, t] of op.opcoes) { const o = document.createElement('option'); o.value = v; o.textContent = t; el.appendChild(o); }
    if (![...el.options].some(o => o.value === String(obj[prop]))) { const o = document.createElement('option'); o.value = obj[prop]; o.textContent = obj[prop]; el.appendChild(o); }
    el.value = obj[prop];
  } else if (tipo === 'check') {
    el = document.createElement('input'); el.type = 'checkbox'; el.checked = !!obj[prop];
  } else {
    el = document.createElement('input'); el.type = tipo;
    if (op.min != null) el.min = op.min;
    if (op.max != null) el.max = op.max;
    if (op.passo != null) el.step = op.passo;
    el.value = obj[prop];
  }
  el.dataset.prop = prop;
  const ler = () => tipo === 'check' ? el.checked : (tipo === 'number' || tipo === 'range') ? Number(el.value) : el.value;
  el.addEventListener('input', () => {
    if (tipo === 'number' && el.value === '') return;
    obj[prop] = ler();
    if (obj === doc) { palco.style.background = doc.fundo; aoVivo(); return; }
    atualizarEl(obj);
    aoVivo();
  });
  el.addEventListener('change', registrar);
  return el;
}
function botao(texto, titulo, acao) {
  const b = document.createElement('button');
  b.textContent = texto; b.title = titulo || ''; b.onclick = acao;
  return b;
}
function grupo(titulo, ...itens) {
  const f = document.createElement('fieldset');
  const l = document.createElement('legend'); l.textContent = titulo;
  f.append(l, ...itens);
  return f;
}
function montarPainel() {
  const p = $('#painel');
  p.innerHTML = '';
  const e = selecionado();
  if (!e) {
    const h = document.createElement('h3'); h.textContent = SOBREPOSICAO ? 'Sobreposição' : 'Composição';
    p.appendChild(h);
    if (SOBREPOSICAO) {
      // fundo transparente deixa ver a imagem de fundo; desmarcado, a sobreposição cobre tudo com uma cor
      const transp = document.createElement('input'); transp.type = 'checkbox'; transp.checked = doc.fundo === 'transparent';
      transp.onchange = () => { doc.fundo = transp.checked ? 'transparent' : '#000000'; montarPalco(); montarPainel(); registrar(); };
      const ver = document.createElement('input'); ver.type = 'checkbox'; ver.checked = mostrarReferencia;
      ver.onchange = () => { mostrarReferencia = ver.checked; montarPalco(); };
      const itens = [campo('Transparente', transp)];
      if (doc.fundo !== 'transparent') itens.push(campo('Cor de fundo', controle(doc, 'fundo', 'color')));
      itens.push(campo('Ver o fundo', ver));
      p.appendChild(grupo('Fundo', ...itens));
      if (!referencia) { const r = document.createElement('p'); r.className = 'dica'; r.textContent = 'Nenhum fundo enviado para a projeção ainda (aparece preto aqui).'; p.appendChild(r); }
    } else {
      p.appendChild(grupo('Tela', campo('Cor de fundo', controle(doc, 'fundo', 'color'))));
    }
    const d = document.createElement('p'); d.className = 'dica';
    d.textContent = 'Use os botões + Imagem, + Texto e + Forma, ou arraste imagens do computador para a tela. Duplo clique numa área vazia cria um texto.';
    p.appendChild(d);
    return;
  }
  const h = document.createElement('h3');
  h.textContent = { texto: 'Texto', imagem: 'Imagem', forma: 'Forma' }[e.tipo];
  p.appendChild(h);
  p.appendChild(grupo('Organizar', Object.assign(document.createElement('div'), { className: 'botoes' })));
  p.lastChild.lastChild.append(
    botao('Frente', 'Trazer para a frente', () => camada('frente')),
    botao('Trás', 'Enviar para trás', () => camada('tras')),
    botao('▲', 'Subir uma camada', () => camada('subir')),
    botao('▼', 'Descer uma camada', () => camada('descer')),
    botao('⇔', 'Centralizar na horizontal', () => centralizar('h')),
    botao('⇕', 'Centralizar na vertical', () => centralizar('v')),
    botao('Duplicar', 'Ctrl+D', duplicar),
    botao('Excluir', 'Delete', remover));
  if (e.tipo === 'texto') {
    const opFontes = fontes.map(f => [f, f]);
    const estilos = Object.assign(document.createElement('div'), { className: 'botoes' });
    for (const [prop, rot, tit] of [['negrito', 'N', 'Negrito'], ['italico', 'I', 'Itálico'], ['sublinhado', 'S', 'Sublinhado']]) {
      const b = botao(rot, tit, () => { e[prop] = !e[prop]; b.classList.toggle('ativo', e[prop]); atualizarEl(e); registrar(); });
      b.classList.toggle('ativo', !!e[prop]);
      estilos.appendChild(b);
    }
    for (const [v, rot] of [['left', '⯇'], ['center', '≡'], ['right', '⯈']]) {
      const b = botao(rot, { left: 'Alinhar à esquerda', center: 'Centralizar', right: 'Alinhar à direita' }[v], () => {
        e.alinhamento = v; estilos.querySelectorAll('.al').forEach(x => x.classList.toggle('ativo', x === b)); atualizarEl(e); registrar(); });
      b.classList.add('al'); b.classList.toggle('ativo', e.alinhamento === v);
      estilos.appendChild(b);
    }
    const editar = botao('Editar texto', 'Ou duplo clique no texto', () => entrarEdicao(e.id));
    p.append(
      grupo('Texto', editar),
      grupo('Fonte',
        campo('Fonte', controle(e, 'fonte', 'select', { opcoes: opFontes })),
        campo('Tamanho', controle(e, 'tamanho', 'number', { min: 8, max: 600 })),
        campo('Cor', controle(e, 'cor', 'color')),
        estilos,
        campo('Entrelinha', controle(e, 'linha', 'number', { min: 0.6, max: 3, passo: 0.05 }))),
      grupo('Fundo do texto',
        campo('Cor', controle(e, 'fundoCor', 'color')),
        campo('Opacidade', controle(e, 'fundoOpacidade', 'range', { min: 0, max: 1, passo: 0.05 })),
        campo('Cantos', controle(e, 'raio', 'number', { min: 0, max: 300 })),
        campo('Margem', controle(e, 'margem', 'number', { min: 0, max: 200 }))),
      grupo('Efeitos',
        campo('Sombra', controle(e, 'sombra', 'check')),
        campo('Contorno', controle(e, 'contornoLargura', 'number', { min: 0, max: 30 })),
        campo('Cor contorno', controle(e, 'contornoCor', 'color'))));
  } else if (e.tipo === 'imagem') {
    p.append(
      grupo('Imagem',
        botao('Trocar imagem…', '', () => enviarHost({ acao: 'escolherImagem', trocar: e.id })),
        campo('Ajuste', controle(e, 'ajuste', 'select', { opcoes: [['cobrir', 'Preencher (corta)'], ['conter', 'Mostrar inteira'], ['esticar', 'Esticar']] })),
        botao('Tamanho original', 'Volta à proporção da imagem', () => proporcaoOriginal(e))),
      grupo('Borda',
        campo('Largura', controle(e, 'bordaLargura', 'number', { min: 0, max: 120 })),
        campo('Cor', controle(e, 'bordaCor', 'color')),
        campo('Cantos', controle(e, 'raio', 'number', { min: 0, max: 600 })),
        campo('Sombra', controle(e, 'sombra', 'check'))));
  } else {
    p.append(grupo('Forma',
      campo('Cor', controle(e, 'cor', 'color')),
      campo('Cantos', controle(e, 'raio', 'number', { min: 0, max: 600 })),
      campo('Borda', controle(e, 'bordaLargura', 'number', { min: 0, max: 120 })),
      campo('Cor borda', controle(e, 'bordaCor', 'color'))));
  }
  p.append(grupo('Posição e tamanho',
    campo('X', controle(e, 'x', 'number')),
    campo('Y', controle(e, 'y', 'number')),
    campo('Largura', controle(e, 'w', 'number', { min: 30 })),
    e.tipo === 'texto' ? document.createTextNode('') : campo('Altura', controle(e, 'h', 'number', { min: 30 })),
    campo('Rotação', controle(e, 'rot', 'number', { min: -180, max: 180 })),
    campo('Opacidade', controle(e, 'opacidade', 'range', { min: 0, max: 1, passo: 0.05 }))));
}
function atualizarCamposPosicao() {
  const e = selecionado();
  if (!e) return;
  for (const prop of ['x', 'y', 'w', 'h', 'rot']) {
    const c = $(`#painel [data-prop="${prop}"]`);
    if (c && document.activeElement !== c) c.value = e[prop];
  }
}
function proporcaoOriginal(e) {
  const img = new Image();
  img.onload = () => {
    const k = Math.min(e.w / img.naturalWidth, 2000);
    const cx = e.x + e.w / 2, cy = e.y + e.h / 2;
    e.h = Math.round(img.naturalHeight * k);
    e.x = Math.round(cx - e.w / 2); e.y = Math.round(cy - e.h / 2);
    atualizarEl(e); montarPainel(); registrar();
  };
  img.src = urlImagem(e.src);
}

// ---------- imagens: escolhidas no computador ou arrastadas ----------
function inserirImagens(srcs, trocar) {
  for (const src of srcs) {
    const img = new Image();
    img.onload = img.onerror = () => {
      const alvo = trocar && porId(trocar);
      if (alvo) {
        alvo.src = src;
        if (img.naturalWidth > 0) { // mantém a largura e ajusta a altura à nova proporção
          const cy = alvo.y + alvo.h / 2;
          alvo.h = Math.round(alvo.w * img.naturalHeight / img.naturalWidth);
          alvo.y = Math.round(cy - alvo.h / 2);
        }
        montarPalco(); selecionar(alvo.id); registrar();
      } else {
        adicionar(elImagem(src, img.naturalWidth, img.naturalHeight));
      }
    };
    img.src = urlImagem(src);
    trocar = null;
  }
}
function soltarArquivos(ev) {
  ev.preventDefault();
  const arquivos = [...(ev.dataTransfer && ev.dataTransfer.files || [])].filter(f => /^image\//.test(f.type));
  for (const f of arquivos) {
    const r = new FileReader();
    r.onload = () => enviarHost({ acao: 'salvarImagem', nome: f.name, dados: String(r.result).split(',')[1] });
    r.readAsDataURL(f);
  }
  if (arquivos.length && !host) inserirImagens(arquivos.map(f => URL.createObjectURL(f)));
}

// ---------- janelas: abrir, textos salvos, nome ----------
function janela(titulo, conteudo) {
  $('#janelaTitulo').textContent = titulo;
  const c = $('#janelaConteudo');
  c.innerHTML = '';
  c.append(...[].concat(conteudo));
  $('#janela').hidden = false;
}
function fecharJanela() { $('#janela').hidden = true; }

function cartao(nome, d, abrir, excluir) {
  const c = document.createElement('div');
  c.className = 'cartao';
  const m = document.createElement('div'); m.className = 'mini';
  const r = document.createElement('div'); r.className = 'rotulo';
  const s = document.createElement('span'); s.textContent = nome; s.title = nome;
  r.appendChild(s);
  if (excluir) r.appendChild(botao('Excluir', 'Excluir esta composição', ev => { ev.stopPropagation(); excluir(); }));
  c.append(m, r);
  c.onclick = abrir;
  setTimeout(() => miniatura(d, m), 0);
  return c;
}
function mostrarAbrir() {
  const t1 = document.createElement('h4'); t1.textContent = 'Composições salvas';
  const g1 = document.createElement('div'); g1.className = 'galeria';
  for (const c of composicoes) {
    let d; try { d = JSON.parse(c.docJson); } catch (x) { continue; }
    g1.appendChild(cartao(c.nome, d,
      () => { if (confirmarDescarte()) { abrirDoc(d, c.nome); fecharJanela(); } },
      () => { if (confirm(`Excluir a composição "${c.nome}"?`)) enviarHost({ acao: 'excluir', nome: c.nome }); }));
  }
  if (!composicoes.length) g1.textContent = 'Nenhuma composição salva ainda.';
  const t2 = document.createElement('h4'); t2.textContent = 'Modelos prontos';
  const g2 = document.createElement('div'); g2.className = 'galeria';
  for (const [nome, criar] of MODELOS) {
    const d = criar();
    g2.appendChild(cartao(nome, d, () => { if (confirmarDescarte()) { abrirDoc(criar(), ''); fecharJanela(); } }));
  }
  janela('Abrir composição', [t1, g1, t2, g2]);
}
function mostrarTextosSalvos() {
  const l = document.createElement('div'); l.className = 'lista-textos';
  for (const t of textosSalvos) {
    l.appendChild(botao(`${t.tipo ? '[' + t.tipo + '] ' : ''}${t.texto}`, 'Inserir este texto', () => {
      const e = elTexto(460, 420, t.texto);
      if (t.fonte) e.fonte = t.fonte;
      if (t.tamanho > 0) e.tamanho = Math.round(t.tamanho * 2.2); // tamanho antigo (prévia) -> telão
      e.negrito = !!(t.estilo & 1); e.italico = !!(t.estilo & 2); e.sublinhado = !!(t.estilo & 4);
      if (t.cor) e.cor = t.cor;
      if (t.fundo) { e.fundoCor = t.fundo; e.fundoOpacidade = t.fundoAlfa; }
      e.alinhamento = /Left/.test(t.alinhamento) ? 'left' : /Right/.test(t.alinhamento) ? 'right' : 'center';
      adicionar(e); fecharJanela();
    }));
  }
  if (!textosSalvos.length) l.textContent = 'Nenhum texto salvo na versão anterior.';
  janela('Textos salvos (versão anterior)', l);
}
function pedirNome(aoConfirmar) {
  const f = document.createElement('form'); f.className = 'form-nome';
  const i = document.createElement('input'); i.value = nomeAtual; i.placeholder = 'Nome da composição'; i.maxLength = 80;
  const b = document.createElement('button'); b.textContent = 'Salvar'; b.className = 'destaque';
  f.append(i, b);
  f.onsubmit = ev => {
    ev.preventDefault();
    const n = i.value.replace(/[\\/:*?"<>|]/g, ' ').trim();
    if (!n) { i.focus(); return; }
    if (n !== nomeAtual && composicoes.some(c => c.nome.toLowerCase() === n.toLowerCase()) && !confirm(`Já existe "${n}". Substituir?`)) return;
    fecharJanela(); aoConfirmar(n);
  };
  janela('Salvar composição', f);
  setTimeout(() => { i.focus(); i.select(); }, 0);
}
function salvar(comoNovo) {
  if (editandoId) sairEdicao();
  const gravar = n => { nomeAtual = n; enviarHost({ acao: 'salvar', nome: n, docJson: JSON.stringify(doc) }); if (!host) marcarAlterado(false); };
  if (nomeAtual && !comoNovo) gravar(nomeAtual); else pedirNome(gravar);
}

// ---------- modelos prontos ----------
function modelo(fundo, ...elementos) { return { versao: 1, fundo: fundo, elementos: elementos }; }
const MODELOS = [
  ['Título centralizado', () => modelo('#000000',
    Object.assign(elTexto(160, 330, 'Título'), { w: 1600, tamanho: 140 }),
    Object.assign(elTexto(260, 560, 'Subtítulo'), { w: 1400, tamanho: 64, negrito: false, cor: '#d9d9d9' }))],
  ['Aviso com faixa', () => modelo('#1b1f3b',
    Object.assign(elForma(), { y: 700, h: 300, cor: '#000000', opacidade: 0.7 }),
    Object.assign(elTexto(120, 730, 'AVISO'), { w: 1680, tamanho: 70, alinhamento: 'left', cor: '#ffd54a' }),
    Object.assign(elTexto(120, 840, 'Escreva aqui o aviso da semana.'), { w: 1680, tamanho: 56, negrito: false, alinhamento: 'left' }))],
  ['Imagem com moldura', () => modelo('#000000',
    Object.assign(elImagem('', 1600, 900), { x: 240, y: 90, w: 1440, h: 810, bordaLargura: 18, bordaCor: '#ffffff', raio: 24, sombra: true }),
    Object.assign(elTexto(240, 930, 'Legenda da imagem'), { w: 1440, tamanho: 54, negrito: false }))],
  ['Versículo em destaque', () => modelo('#0d0d0d',
    Object.assign(elForma(), { x: 120, y: 160, w: 1680, h: 760, cor: '#ffffff', opacidade: 0.08, raio: 40, bordaLargura: 4, bordaCor: '#c9a227' }),
    Object.assign(elTexto(200, 260, '“Lâmpada para os meus pés é tua palavra, e luz para o meu caminho.”'), { w: 1520, tamanho: 84, italico: true }),
    Object.assign(elTexto(200, 760, 'Salmos 119:105'), { w: 1520, tamanho: 54, cor: '#c9a227' }))],
];

// ---------- mensagens do programa ----------
function receberHost(m) {
  if (typeof m === 'string') { try { m = JSON.parse(m); } catch (x) { return; } }
  if (!m || !m.tipo) return;
  if (m.tipo === 'iniciar') {
    if (m.fontes && m.fontes.length) fontes = m.fontes;
    composicoes = m.composicoes || [];
    textosSalvos = m.textos || [];
    $('#opLigado').checked = !!m.ligado; $('#opDesligado').checked = !m.ligado;
    try { referencia = m.referencia ? JSON.parse(m.referencia) : null; } catch (x) { referencia = null; }
    if (m.atual && m.atual.docJson) abrirDoc(m.atual.docJson, m.atual.nome || ''); else montarPalco();
    montarPainel();
  } else if (m.tipo === 'referencia') { // o fundo mudou enquanto a tela estava aberta
    try { referencia = m.referencia ? JSON.parse(m.referencia) : null; } catch (x) { referencia = null; }
    montarPalco(); if (!selId) montarPainel();
  } else if (m.tipo === 'lista') {
    composicoes = m.composicoes || [];
    if (!$('#janela').hidden && $('#janelaTitulo').textContent === 'Abrir composição') mostrarAbrir();
  } else if (m.tipo === 'salvo') {
    nomeAtual = m.nome; marcarAlterado(false);
    $('#status').textContent = `Composição "${m.nome}" salva.`;
  } else if (m.tipo === 'imagens') {
    inserirImagens(m.srcs || [], m.trocar);
  } else if (m.tipo === 'ligado') {
    $('#opLigado').checked = !!m.ligado; $('#opDesligado').checked = !m.ligado;
  } else if (m.tipo === 'erro') {
    alert(m.mensagem);
  }
}

// ---------- início ----------
function iniciarEditor() {
  $('#editor').hidden = false;
  montarPalco(); montarPainel(); reiniciarHistorico(); marcarAlterado(false);
  new ResizeObserver(() => { if (palco) { reencaixar(); desenharSelecao(); } }).observe($('#area'));

  const area = $('#palcoEditor');
  area.addEventListener('pointerdown', ev => { if (palco && (palco.contains(ev.target) || camadaSel.contains(ev.target))) iniciarArraste(ev); else if (ev.button === 0) { if (editandoId) sairEdicao(); selecionar(null); } });
  area.addEventListener('pointermove', moverArraste);
  area.addEventListener('pointerup', terminarArraste);
  area.addEventListener('pointercancel', terminarArraste);
  area.addEventListener('dblclick', ev => {
    const no = ev.target.closest('.el');
    if (no) { if (porId(no.dataset.id).tipo === 'texto') entrarEdicao(no.dataset.id); return; }
    if (!palco || !palco.contains(ev.target)) return;
    const p = pontoPalco(ev), e = elTexto(0, 0, '');
    e.x = Math.round(p.x - e.w / 2); e.y = Math.round(p.y - 60);
    adicionar(e); entrarEdicao(e.id);
  });
  area.addEventListener('input', textoDigitado);
  // sai da edição ao clicar fora do texto (mas não ao usar o painel de formatação)
  area.addEventListener('focusout', ev => {
    if (!editandoId || !ev.target.closest('.txt')) return;
    setTimeout(() => {
      const a = document.activeElement, n = editandoId && noDe(editandoId);
      if (n && !n.contains(a) && !$('#painel').contains(a)) sairEdicao();
    }, 0);
  });
  $('#area').addEventListener('dragover', ev => ev.preventDefault());
  $('#area').addEventListener('drop', soltarArquivos);
  // arquivo solto fora da tela: não deixa o navegador abrir o arquivo no lugar do editor
  document.addEventListener('dragover', ev => ev.preventDefault());
  document.addEventListener('drop', ev => ev.preventDefault());

  $('#bNovo').onclick = () => { if (confirmarDescarte()) abrirDoc(novoDoc(), ''); };
  $('#bAbrir').onclick = mostrarAbrir;
  $('#bSalvar').onclick = () => salvar(false);
  $('#bSalvarComo').onclick = () => salvar(true);
  $('#bImagem').onclick = () => enviarHost({ acao: 'escolherImagem' });
  $('#bTexto').onclick = () => { const e = elTexto(460, 440, 'Novo texto'); adicionar(e); entrarEdicao(e.id); };
  $('#bForma').onclick = () => adicionar(elForma());
  $('#bTextosSalvos').onclick = mostrarTextosSalvos;
  $('#bDesfazer').onclick = () => irHistorico(-1);
  $('#bRefazer').onclick = () => irHistorico(1);
  $('#bEnviar').onclick = () => {
    if (editandoId) sairEdicao();
    enviarHost({ acao: 'enviar', docJson: JSON.stringify(doc) });
    $('#status').textContent = 'Composição enviada para a projeção.';
  };
  $('#aoVivo').onchange = aoVivoAgora;
  for (const r of ['#opLigado', '#opDesligado']) $(r).onchange = () => enviarHost({ acao: 'operacao', ligado: $('#opLigado').checked, docJson: JSON.stringify(doc) });
  $('#janelaFechar').onclick = fecharJanela;
  $('#janela').addEventListener('pointerdown', ev => { if (ev.target.id === 'janela') fecharJanela(); });

  document.addEventListener('keydown', ev => {
    if (ev.key === 'Escape') { if (!$('#janela').hidden) fecharJanela(); else if (editandoId) sairEdicao(); else selecionar(null); return; }
    const ae = document.activeElement;
    const emCampo = editandoId || /^(SELECT|TEXTAREA)$/.test(ae.tagName) ||
      (ae.tagName === 'INPUT' && !/^(checkbox|radio|range|color|button)$/.test(ae.type));
    const ctrl = ev.ctrlKey || ev.metaKey, k = ev.key.toLowerCase();
    if (ctrl && k === 's') { ev.preventDefault(); salvar(false); return; }
    if (emCampo) return;
    if (ctrl && k === 'z') { ev.preventDefault(); irHistorico(ev.shiftKey ? 1 : -1); }
    else if (ctrl && k === 'y') { ev.preventDefault(); irHistorico(1); }
    else if (ctrl && k === 'd') { ev.preventDefault(); duplicar(); }
    else if (ev.key === 'Delete' || ev.key === 'Backspace') { ev.preventDefault(); remover(); }
    else if (ev.key === 'Enter' && selecionado() && selecionado().tipo === 'texto') { ev.preventDefault(); entrarEdicao(selId); }
    else if (ev.key.startsWith('Arrow') && selecionado()) {
      ev.preventDefault();
      const e = selecionado(), p = ev.shiftKey ? 10 : 1;
      if (ev.key === 'ArrowLeft') e.x -= p; if (ev.key === 'ArrowRight') e.x += p;
      if (ev.key === 'ArrowUp') e.y -= p; if (ev.key === 'ArrowDown') e.y += p;
      atualizarEl(e); atualizarCamposPosicao(); aoVivo();
      clearTimeout(window.timerSeta); window.timerSeta = setTimeout(registrar, 400);
    }
  });
  enviarHost({ acao: 'iniciar' });
}

if (MODO === 'projecao') {
  $('#projecao').hidden = false;
  window.addEventListener('resize', () => { for (const p of document.querySelectorAll('#projecao .palco')) encaixar(p, $('#projecao'), 0); });
} else {
  iniciarEditor();
}
