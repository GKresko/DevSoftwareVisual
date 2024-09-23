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

        [HttpGet]
        public ActionResult<IEnumerable<Editora>> GetEditoras() => _context.Editoras.ToList();

        [HttpGet("{id}")]
        public ActionResult<Editora> GetEditora(int id)
        {
            var editora = _context.Editoras.FirstOrDefault(e => e.EditoraId == id);
            if (editora == null) return NotFound();
            return editora;
        }

        [HttpPost]
        public ActionResult<Editora> CreateEditora([FromBody] Editora editora)
        {
            _context.Editoras.Add(editora);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEditora), new { id = editora.EditoraId }, editora);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEditora(int id, Editora editora)
        {
            if (id != editora.EditoraId) return BadRequest();
            _context.Entry(editora).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

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
