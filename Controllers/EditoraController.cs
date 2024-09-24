using LojaLivrosAPI.Data;
using LojaLivrosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LojaLivrosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EditoraController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EditoraController(AppDbContext context)
        {
            _context = context;
        }
        // Método HTTP GET para listar todas as editoras no banco de dados
        [HttpGet]
        public ActionResult<IEnumerable<Editora>> GetEditoras() => _context.Editoras.ToList();
        // Método HTTP GET para obter uma editora específica pelo seu ID
        [HttpGet("{id}")]
        public ActionResult<Editora> GetEditora(int id)
        {
            var editora = _context.Editoras.FirstOrDefault(e => e.EditoraId == id);
            if (editora == null) return NotFound();
            return editora;
        }
        // Método HTTP POST para criar uma nova editora
        [HttpPost]
        public ActionResult<Editora> CreateEditora([FromBody] Editora editora)
        {
            _context.Editoras.Add(editora);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEditora), new { id = editora.EditoraId }, editora);
        }
        // Método HTTP PUT para atualizar uma editora existente
        [HttpPut("{id}")]
        public IActionResult UpdateEditora(int id, Editora editora)
        {
            if (id != editora.EditoraId) return BadRequest();
            _context.Entry(editora).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        // Método HTTP DELETE para remover uma editora pelo seu ID
        [HttpDelete("{id}")]
        public IActionResult DeleteEditora(int id)
        {
            var editora = _context.Editoras.Find(id);
            if (editora == null) return NotFound();
            _context.Editoras.Remove(editora);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
