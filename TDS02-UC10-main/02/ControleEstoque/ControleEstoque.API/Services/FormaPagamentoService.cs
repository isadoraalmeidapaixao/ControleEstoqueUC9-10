using ControleEstoque.API.Data;
using ControleEstoque.API.DTOs;
using ControleEstoque.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.API.Services
{
    public class FormaPagamentoService : IFormaPagamentoService
    {
        private readonly AppDbContext _context;

        public FormaPagamentoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FormaPagamentoDto>> ObterTodosAsync()
        {
            return await _context.FormasPagamento
                .AsNoTracking()
                .Select(fp => new FormaPagamentoDto
                {
                    Id = fp.Id,
                    Nome = fp.Nome
                })
                .ToListAsync();
        }

        public async Task<FormaPagamentoDto?> ObterPorIdAsync(int id)
        {
            var formaPagamento = await _context.FormasPagamento
                .AsNoTracking()
                .FirstOrDefaultAsync(fp => fp.Id == id);

            if (formaPagamento == null)
                return null;

            return new FormaPagamentoDto
            {
                Id = formaPagamento.Id,
                Nome = formaPagamento.Nome
            };
        }

        public async Task<FormaPagamentoDto> CriarAsync(CriarFormaPagamentoDto dto)
        {
            var formaPagamento = new FormaPagamento
            {
                Nome = dto.Nome
            };

            _context.FormasPagamento.Add(formaPagamento);
            await _context.SaveChangesAsync();

            return new FormaPagamentoDto
            {
                Id = formaPagamento.Id,
                Nome = formaPagamento.Nome
            };
        }

        public async Task<FormaPagamentoDto> AtualizarAsync(AtualizarFormaPagamentoDto dto)
        {
            var formaPagamento = await _context.FormasPagamento.FindAsync(id);

            if (formaPagamento != null)
            {
                formaPagamento.Nome = dto.Nome;

                _context.FormasPagamento.Update(formaPagamento);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoverAsync(int id)
        {
            var formaPagamento = await _context.FormasPagamento.FindAsync(id);

            if (formaPagamento != null)
            {
                _context.FormasPagamento.Remove(formaPagamento);
                await _context.SaveChangesAsync();
            }
        }
    }
}
