async function carregarFormasPagamento() {
    try {
        const response = await fetch(`${API_BASE_URL}/FormaPagamento`, {
            method: 'GET',
            headers: getHeaders()
        });

        if (!response.ok) {
            throw new Error(`Erro HTTP ${response.status}`);
        }

        const formasPagamento = await response.json();

        const tbody = document.getElementById('tabela-formapagamento');
        tbody.innerHTML = '';

        formasPagamento.forEach(fp => {
            const tr = document.createElement('tr');

            tr.innerHTML = `
                <td>${fp.id}</td>
                <td>${fp.nome}</td>
                <td class="actions">
                    <a href="detalhes.html?id=${fp.id}">Detalhes</a>
                    <a href="form.html?id=${fp.id}">Editar</a>
                    <a href="excluir.html?id=${fp.id}" style="color: var(--danger-color);">Excluir</a>
                </td>
            `;

            tbody.appendChild(tr);
        });

    } catch (error) {
        console.error("Erro ao carregar as formas de pagamento:", error);
    }
}

carregarFormasPagamento();