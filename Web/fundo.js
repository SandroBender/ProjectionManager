// Tela Fundo simplificada - ProjectionManager
// Gera uma composição de uma imagem só (mesmo formato do editor) a partir das opções da tela.
'use strict';

// opções do fundo (guardadas junto com a composição, para reabrir a tela como estava)
function padrao() {
  return { src: '', largura: 0, altura: 0, margem: 0, ajuste: 'conter', dx: 0, dy: 0,
    borda: 0, bordaCor: '#ffffff', raio: 0, sombra: false, corFundo: '#000000' };
}
let cfg = padrao();
let palcoPrevia = null, escalaPrevia = 1;

// monta a composição: a imagem ocupa a área livre dentro da margem
function gerarDoc() {
  const d = { versao: 1, fundo: cfg.corFundo, elementos: [], fundoSimples: cfg };
  if (!cfg.src) return d;
  const m = cfg.margem / 100, aw = W * (1 - 2 * m), ah = H * (1 - 2 * m);
  let w = aw, h = ah;
  if (cfg.ajuste === 'conter' && cfg.largura > 0 && cfg.altura > 0) { // tamanho da imagem inteira dentro da área
    const k = Math.min(aw / cfg.largura, ah / cfg.altura);
    w = cfg.largura * k; h = cfg.altura * k;
  }
  d.elementos.push({ id: 'fundo', tipo: 'imagem', x: Math.round((W - w) / 2 + cfg.dx), y: Math.round((H - h) / 2 + cfg.dy),
    w: Math.round(w), h: Math.round(h), rot: 0, opacidade: 1, src: cfg.src,
    ajuste: cfg.ajuste === 'cobrir' ? 'cobrir' : 'esticar', bordaLargura: cfg.borda, bordaCor: cfg.bordaCor, raio: cfg.raio, sombra: cfg.sombra });
  return d;
}

function desenhar() {
  const c = $('#previa');
  c.innerHTML = '';
  palcoPrevia = criarPalco(gerarDoc());
  c.appendChild(palcoPrevia);
  escalaPrevia = encaixar(palcoPrevia, c, 18);
}

// envia para o programa (que grava e atualiza a projeção) - no máximo ~6 vezes por segundo
let timerEnvio = null;
function aplicar() {
  desenhar();
  clearTimeout(timerEnvio);
  timerEnvio = setTimeout(() => enviarHost({ acao: 'atualizar', ligado: $('#opLigado').checked, docJson: JSON.stringify(gerarDoc()) }), 160);
}

function mostrarValores() {
  $('#margem').value = cfg.margem; $('#margemValor').textContent = cfg.margem + '%';
  $('#ajuste').value = cfg.ajuste;
  $('#borda').value = cfg.borda; $('#bordaValor').textContent = cfg.borda;
  $('#bordaCor').value = cfg.bordaCor;
  $('#raio').value = cfg.raio; $('#raioValor').textContent = cfg.raio;
  $('#sombra').checked = cfg.sombra;
  $('#corFundo').value = cfg.corFundo;
  $('#bRemover').disabled = !cfg.src;
  $('#arquivo').textContent = cfg.src ? 'Imagem: ' + cfg.src.replace(/^imagens\//, '') : 'Nenhuma imagem escolhida.';
}

// liga um controle a uma opção
function ligar(id, prop, ler) {
  $(id).addEventListener('input', () => { cfg[prop] = ler($(id)); mostrarValores(); aplicar(); });
}

// nova imagem: guarda o tamanho original (para "mostrar inteira") e volta ao centro
function usarImagem(src) {
  const img = new Image();
  img.onload = img.onerror = () => {
    cfg.src = src; cfg.largura = img.naturalWidth || 0; cfg.altura = img.naturalHeight || 0; cfg.dx = 0; cfg.dy = 0;
    mostrarValores(); aplicar();
    $('#status').textContent = 'Imagem aplicada ao fundo.';
  };
  img.src = urlImagem(src);
}

// arrastar a imagem na prévia desloca a posição (com "ímã" no centro)
let arrasto = null;
function pontoPrevia(ev) {
  const r = palcoPrevia.getBoundingClientRect();
  return { x: (ev.clientX - r.left) / escalaPrevia, y: (ev.clientY - r.top) / escalaPrevia };
}

function receberHostFundo(m) {
  if (typeof m === 'string') { try { m = JSON.parse(m); } catch (x) { return; } }
  if (!m || !m.tipo) return;
  if (m.tipo === 'iniciar') {
    $('#opLigado').checked = !!m.ligado; $('#opDesligado').checked = !m.ligado;
    let salvo = null;
    try { salvo = m.atual && m.atual.docJson ? JSON.parse(m.atual.docJson).fundoSimples : null; } catch (x) { salvo = null; }
    cfg = Object.assign(padrao(), salvo || {});
    mostrarValores(); desenhar();
  } else if (m.tipo === 'imagens') {
    if (m.srcs && m.srcs.length) usarImagem(m.srcs[0]);
  } else if (m.tipo === 'erro') {
    alert(m.mensagem);
  }
}
if (host) host.addEventListener('message', e => receberHostFundo(e.data));

function iniciarFundo() {
  mostrarValores(); desenhar();
  new ResizeObserver(() => { if (palcoPrevia) escalaPrevia = encaixar(palcoPrevia, $('#previa'), 18); }).observe($('#area'));
  ligar('#margem', 'margem', c => Number(c.value));
  ligar('#ajuste', 'ajuste', c => c.value);
  ligar('#borda', 'borda', c => Number(c.value));
  ligar('#bordaCor', 'bordaCor', c => c.value);
  ligar('#raio', 'raio', c => Number(c.value));
  ligar('#sombra', 'sombra', c => c.checked);
  ligar('#corFundo', 'corFundo', c => c.value);
  $('#bEscolher').onclick = () => enviarHost({ acao: 'escolherImagem' });
  $('#bRemover').onclick = () => { cfg.src = ''; cfg.largura = cfg.altura = 0; cfg.dx = cfg.dy = 0; mostrarValores(); aplicar(); };
  $('#bCentralizar').onclick = () => { cfg.dx = 0; cfg.dy = 0; aplicar(); };
  for (const r of ['#opLigado', '#opDesligado']) $(r).onchange = aplicar;

  const prev = $('#previa');
  prev.addEventListener('pointerdown', ev => {
    if (ev.button !== 0 || !ev.target.closest('.el')) return;
    arrasto = { p0: pontoPrevia(ev), dx: cfg.dx, dy: cfg.dy };
    prev.setPointerCapture(ev.pointerId);
  });
  prev.addEventListener('pointermove', ev => {
    if (!arrasto) return;
    const p = pontoPrevia(ev);
    cfg.dx = Math.round(arrasto.dx + p.x - arrasto.p0.x);
    cfg.dy = Math.round(arrasto.dy + p.y - arrasto.p0.y);
    if (!ev.altKey) { if (Math.abs(cfg.dx) < 12) cfg.dx = 0; if (Math.abs(cfg.dy) < 12) cfg.dy = 0; }
    aplicar();
  });
  const soltar = () => { arrasto = null; };
  prev.addEventListener('pointerup', soltar);
  prev.addEventListener('pointercancel', soltar);

  // arrastar um arquivo de imagem do computador para a prévia
  document.addEventListener('dragover', ev => { ev.preventDefault(); prev.classList.add('solto'); });
  document.addEventListener('dragleave', ev => { if (!ev.relatedTarget) prev.classList.remove('solto'); });
  document.addEventListener('drop', ev => {
    ev.preventDefault(); prev.classList.remove('solto');
    const f = [...(ev.dataTransfer && ev.dataTransfer.files || [])].find(x => /^image\//.test(x.type));
    if (!f) return;
    const r = new FileReader();
    r.onload = () => enviarHost({ acao: 'salvarImagem', nome: f.name, dados: String(r.result).split(',')[1] });
    r.readAsDataURL(f);
    if (!host) usarImagem(URL.createObjectURL(f));
  });
  enviarHost({ acao: 'iniciar' });
}
iniciarFundo();
