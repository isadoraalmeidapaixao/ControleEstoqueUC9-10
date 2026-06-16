using ControleEstoque.API.Data;
using ControleEstoque.API.DTOs;
using ControleEstoque.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.API.Services
{
    public class ContaReceberService : IContaReceberService
    {
        private readonly AppDbContext _context;

        public ContaReceberService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AtualizarAsync(AtualizarContaReceberDto dto)
        {
            var conta = await _context.ContasReceber
                .FirstOrDefaultAsync(cr => cr.Id == dto.Id);

            if (conta != null)
            {
                conta.Descricao = dto.Descricao;
                conta.Valor = dto.Valor;
                conta.DataVencimento = dto.DataVencimento;
                conta.DataPagamento = dto.DataPagamento;
                conta.Status = dto.Status;
                conta.ClienteId = dto.ClienteId;

                _context.ContasReceber.Update(conta);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ContaReceberDto> CriarAsync(CriarContaReceberDto dto)
        {
            var conta = new ContaReceber
            {
                DataPagamento = dto.DataPagamento,
                DataVencimento = dto.DataVencimento,
                Descricao = dto.Descricao,
                Status = dto.Status,
                Valor = dto.Valor,
                ClienteId = dto.ClienteId                
            };

            await _context.ContasReceber.AddAsync(conta);
            await _context.SaveChangesAsync();

            return await ObterPorIdAsync(conta.Id);
        }

        public async Task<ContaReceberDto?> ObterPorIdAsync(int id)
        {
            var conta = await _context.ContasReceber
                .FirstOrDefaultAsync(cr => cr.Id == id);

            if (conta == null) return null;

            return new ContaReceberDto
            {
                Id = conta.Id,
                DataPagamento = conta?.DataPagamento,
                DataVencimento = conta.DataVencimento,
                Descricao = conta.Descricao,
                Status = conta.Status,
                Valor = conta.Valor,
                ClienteId = conta.ClienteId
            };
        }

        public async Task<IEnumerable<ContaReceberDto>> ObterTodosAsync()
        {
            return await _context.ContasReceber
                .Select(cr => new ContaReceberDto 
                {
                    Id = cr.Id,
                    DataPagamento = cr.DataPagamento,
                    DataVencimento = cr.DataVencimento,
                    Descricao = cr.Descricao,
                    Status = cr.Status,
                    Valor = cr.Valor,
                    ClienteId = cr.ClienteId
                })
                .ToListAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var conta = await _context.ContasReceber.FindAsync(id);
            if(conta != null)
            {
                _context.ContasReceber.Remove(conta);
                await _context.SaveChangesAsync();
            }
        }
    }
}
