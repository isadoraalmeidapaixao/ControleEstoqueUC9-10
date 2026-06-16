using ControleEstoque.API.DTOs;
using ControleEstoque.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedoresController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var fornecedores = await _fornecedorService.ObterTodosAsync();
            return Ok(fornecedores);
        }

        [HttpGet("{id}")] //recebe pela rota
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _fornecedorService.ObterPorIdAsync(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CriarFornecedorDto dto)
        {
            FornecedorDto result = await _fornecedorService.CriarAsync(dto);            
            return Created(nameof(Create), result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AtualizarFornecedorDto dto)
        {
            if(id != dto.Id) return BadRequest();

            var existe = await _fornecedorService.ObterPorIdAsync(id);
            if (existe == null) return NotFound();

            await _fornecedorService.AtualizarAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _fornecedorService.RemoverAsync(id);
            return NoContent();
        }
    }
}
