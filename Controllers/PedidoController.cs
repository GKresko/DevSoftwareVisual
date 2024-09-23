using LojaLivrosAPI.Data;
using LojaLivrosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LojaLivrosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PedidoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pedido>> GetPedidos() => _context.Pedidos.Include(p => p.Cliente).ToList();

        [HttpGet("{id}")]
        public ActionResult<Pedido> GetPedido(int id)
        {
            var pedido = _context.Pedidos.Include(p => p.Cliente).FirstOrDefault(p => p.PedidoId == id);
            if (pedido == null) return NotFound();
            return pedido;
        }

        [HttpPost]
        public ActionResult<Pedido> CreatePedido([FromBody] Pedido pedido)  //criando pedidos 
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetPedido), new { id = pedido.PedidoId }, pedido);    //retornando com id
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePedido(int id, Pedido pedido)
        {
            if (id != pedido.PedidoId) return BadRequest();
            _context.Entry(pedido).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePedido(int id)
        {
            var pedido = _context.Pedidos.Find(id);
            if (pedido == null) return NotFound();
            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
