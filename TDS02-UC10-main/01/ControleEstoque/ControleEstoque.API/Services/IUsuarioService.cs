using ControleEstoque.API.DTOs;

namespace ControleEstoque.API.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDto>> ListarTodosUsuariosAsync();
        Task<UsuarioDto?> BuscarUsuarioPorId(int id);
        Task<UsuarioDto?> BuscarUsuarioPorEmail(string email);

        Task<UsuarioDto> RegistrarCliente(CriarClienteDto dto);
        Task<UsuarioDto> RegistrarCaixa(CriarCaixaDto dto);
        Task<UsuarioDto> RegistrarGerente(CriarGerenteDto dto);
    }
}
