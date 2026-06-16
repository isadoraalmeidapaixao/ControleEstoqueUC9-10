const urlParams = new URLSearchParams(window.location.search);
const id = urlParams.get('id');

async function buscarDetalhes() {
    try {
        const response = await fetch(`${API_BASE_URL}/FormaPagamento/${id}`);
        const produto = await response.json();

        document.getElementById('dados-formapagamento').innerHTML = `
            <p><strong>Nome:</strong> ${formapagamento.nome}</p
        `;
    } catch (error) {
        document.getElementById('dados-formapagamento').innerHTML = `<p style="color: red;">Erro ao carregar detalhes.</p>`;
    }
}

buscarDetalhes();