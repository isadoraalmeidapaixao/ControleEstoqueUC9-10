using ControleEstoque.API.Models;

namespace ControleEstoque.API.DTOs
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public PerfilUsuario Perfil { get; set; }

        public string? Turno { get; set; }
        public string? CPF { get; set; }
        public string? Setor { get; set; }
    }

    public class CriarClienteDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
    }

    public class CriarCaixaDto
    {
        public string Nome { get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Turno { get; set; } = string.Empty;
    }

    public class CriarGerenteDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Setor { get; set; } = string.Empty;
    }
}
