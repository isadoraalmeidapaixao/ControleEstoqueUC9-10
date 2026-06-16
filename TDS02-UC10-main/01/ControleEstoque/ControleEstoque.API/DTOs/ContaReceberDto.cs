namespace ControleEstoque.API.DTOs
{
    public class ContaReceberDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateOnly DataVencimento { get; set; }
        public DateOnly? DataPagamento { get; set; }
        public string Status { get; set; }
        public int ClienteId { get; set; }
        // adicionar o retorno da clienteDto no futuro
    }

    public class CriarContaReceberDto
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateOnly DataVencimento { get; set; }
        public DateOnly? DataPagamento { get; set; }
        public string Status { get; set; }
        public int ClienteId { get; set; }
    }

    public class AtualizarContaReceberDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateOnly DataVencimento { get; set; }
        public DateOnly? DataPagamento { get; set; }
        public string Status { get; set; }
        public int ClienteId { get; set; }
    }
}
