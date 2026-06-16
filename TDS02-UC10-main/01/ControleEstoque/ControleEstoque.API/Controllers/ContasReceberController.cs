using ControleEstoque.API.DTOs;
using ControleEstoque.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasReceberController : ControllerBase
    {
        private readonly IContaReceberService _contaReceberService;

        public ContasReceberController(IContaReceberService contaReceberService)
        {
            _contaReceberService = contaReceberService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contas = await _contaReceberService.ObterTodosAsync();
            return Ok(contas);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CriarContaReceberDto dto)
        {
            var novaConta = await _contaReceberService.CriarAsync(dto);
            return Ok(novaConta);
            // return Created(nameof(Create), novaConta);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AtualizarContaReceberDto dto)
        {
            if(id != dto.Id)
                return BadRequest("ID inforado diferente da conta atualizada!");

            await _contaReceberService.AtualizarAsync(dto);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById (int id)
        {
            var conta = await _contaReceberService.ObterPorIdAsync(id);
            if (conta == null)
                return NotFound("Não foi encontrada Conta a Receber para esse ID!");

            return Ok(conta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _contaReceberService.RemoverAsync(id);
            return NoContent();
        }
    }
}
