using ControleEstoque.API.DTOs;
using ControleEstoque.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var produto = await _produtoService.ObterTodosAsync();
            return Ok(produto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
            => Ok(await _produtoService.ObterPorIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CriarProdutoDto dto)
        {
            var novoProduto = await _produtoService.CriarProdutoAsync(dto);
            return Ok(novoProduto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AtualizarProdutoDto dto)
        {
            if (id != dto.Id) return BadRequest("O ID da rota difere do id do Produto");

            await _produtoService.AtualizarProdutoDtoAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _produtoService.RemoverAsync(id);
            return NoContent();
        }
    }
}
