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
    public class LivroController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LivroController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Livro>> GetLivros() => _context.Livros.Include(l => l.Autor).Include(l => l.Editora).ToList();

        [HttpGet("{id}")]
        public ActionResult<Livro> GetLivro(int id)
        {
            var livro = _context.Livros.Include(l => l.Autor).Include(l => l.Editora).FirstOrDefault(l => l.LivroId == id);
            if (livro == null) return NotFound();
            return livro;
        }

        [HttpPost]
        public ActionResult<Livro> CreateLivro(Livro livro)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetLivro), new { id = livro.LivroId }, livro);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLivro(int id, Livro livro)
        {
            if (id != livro.LivroId) return BadRequest();
            _context.Entry(livro).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLivro(int id)
        {
            var livro = _context.Livros.Find(id);
            if (livro == null) return NotFound();
            _context.Livros.Remove(livro);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
