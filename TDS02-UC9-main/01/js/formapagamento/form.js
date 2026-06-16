const urlParams = new URLSearchParams(window.location.search);
const id = urlParams.get('id');

const form = document.getElementById('form-formapagamento');

async function carregarFormaPagamento() {
    if (id) {
        document.getElementById('titulo-pagina').innerText = "Editar Forma de Pagamento";

        try {
            const response = await fetch(
                `${API_BASE_URL}/FormaPagamento/${id}`,
                {
                    headers: getHeaders()
                }
            );

            if (!response.ok)
                throw new Error('Erro ao carregar forma de pagamento');

            const formaPagamento = await response.json();

            document.getElementById('nome').value = formaPagamento.nome;
            document.getElementById('ativo').checked = formaPagamento.ativo;
        }
        catch (error) {
            console.error(error);
            alert('Erro ao carregar os dados');
        }
    }
}

form.addEventListener('submit', async (e) => {
    e.preventDefault();

    const formaPagamentoDados = {
        id: id ? parseInt(id) : 0,
        nome: document.getElementById('nome').value.trim(),
        ativo: document.getElementById('ativo').checked
    };

    const method = id ? 'PUT' : 'POST';

    const url = id
        ? `${API_BASE_URL}/FormaPagamento/${id}`
        : `${API_BASE_URL}/FormaPagamento`;

    try {
        const response = await fetch(url, {
            method: method,
            headers: getHeaders(),
            body: JSON.stringify(formaPagamentoDados)
        });

        if (!response.ok)
            throw new Error('Erro ao salvar');

        window.location.href = 'index.html';
    }
    catch (error) {
        console.error(error);
        alert('Erro ao salvar');
    }
});

carregarFormaPagamento();