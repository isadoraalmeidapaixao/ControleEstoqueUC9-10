namespace ControleEstoque.API.DTOs
{
    public class FornecedorDto
    {
        public int Id { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
    }

    public class CriarFornecedorDto
    {
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
    }

    public class AtualizarFornecedorDto
    {
        public int Id { get; set; }
        public string NomeFantasia { get; set; }
    }
}
