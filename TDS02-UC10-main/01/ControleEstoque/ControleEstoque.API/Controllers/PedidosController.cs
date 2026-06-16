using ControleEstoque.API.DTOs;
using ControleEstoque.API.Models;
using ControleEstoque.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidosController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPedido(int id)
        {
            var pedido = await _pedidoService.ObterPedidoComDetalhesAsync(id);

            if (pedido == null) return NotFound();

            var pedidoDto = new DetalhesPedidoDto
            {
                Id = pedido.Id,
                DataPedido = pedido.DataPedido,
                Status = pedido.Status,
                ClienteId = pedido.ClienteId,
                Itens = pedido.Itens.Select(i => new DetalhesItemPedidoDto
                {
                    Id = i.Id,
                    Quantidade = i.Quantidade,
                    PrecoUnitario = i.PrecoUnitario,
                    ProdutoId = i.ProdutoId,
                    ProdutoNome = i.Produto.Nome
                }).ToList()
            };

            return Ok(pedidoDto);
        }

        [HttpPost]
        public async Task<IActionResult> CriarPedido([FromBody] CriarPedidoDto pedido)
        {
            /*
            //List<ItemPedido> listaItens = new List<ItemPedido>();
            //foreach(var item in pedido.Itens)
            //{
            //    var novoItem = new ItemPedido
            //    {
            //        Id = item.ProdutoId,
            //        Quantidade = item.Quantidade
            //    };
            //    listaItens.Add(novoItem);
            //}
            */

            var itensPedido = pedido.Itens.Select(i => new ItemPedido
            {
                ProdutoId = i.ProdutoId,
                Quantidade = i.Quantidade
            }).ToList();

            var novoPedido = await _pedidoService.CriarPedidoAsync(pedido.ClienteId, itensPedido);
            return Ok(novoPedido);
        }
    }
}
