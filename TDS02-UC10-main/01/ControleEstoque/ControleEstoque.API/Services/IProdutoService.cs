using ControleEstoque.API.DTOs;

namespace ControleEstoque.API.Services
{
    public interface IProdutoService
    {
        Task<ProdutoDto> CriarProdutoAsync(CriarProdutoDto dto);
        Task AtualizarProdutoDtoAsync(AtualizarProdutoDto dto);
        Task<IEnumerable<ProdutoDto>> ObterTodosAsync();
        Task<ProdutoDto?> ObterPorIdAsync(int id);
        Task RemoverAsync(int id);
    }
}
