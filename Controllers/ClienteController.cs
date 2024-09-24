using LojaLivrosAPI.Data;
using LojaLivrosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LojaLivrosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> GetClientes() => _context.Clientes.ToList();

        [HttpGet("{id}")]
        public ActionResult<Cliente> GetCliente(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.ClienteId == id);
            if (cliente == null) return NotFound();
            return cliente;
        }

      
    }
}
