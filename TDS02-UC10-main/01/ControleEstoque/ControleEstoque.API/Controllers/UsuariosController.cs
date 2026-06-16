using ControleEstoque.API.DTOs;
using ControleEstoque.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuariosController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuario = await _service.ListarTodosUsuariosAsync();
            return Ok(usuario);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _service.BuscarUsuarioPorId(id);
            if(usuario == null) return NotFound("Usuário não encontrado para o ID informado!");
            return Ok(usuario);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var usuario = await _service.BuscarUsuarioPorEmail(email);
            if (usuario == null) return NotFound("Usuário não encontrado para o EMAIL informado!");
            return Ok(usuario);
        }

        [HttpPost("registrar-cliente")]
        public async Task<IActionResult> RegistrarCliente ([FromBody] CriarClienteDto dto)
        {
            var novoCliente = await _service.RegistrarCliente(dto);
            return Ok(novoCliente);
        }

        [HttpPost("registrar-caixa")]
        public async Task<IActionResult> RegistrarCaixa ([FromBody] CriarCaixaDto dto)
        {
            var novoCaixa = await _service.RegistrarCaixa(dto);
            return Ok();
        }

        [HttpPost("registrar-gerente")]
        public async Task<IActionResult> RegistrarGerente ([FromBody] CriarGerenteDto dto)
        {
            var novoGerente = await _service.RegistrarGerente(dto);
            return Ok();
        }
    }
}
