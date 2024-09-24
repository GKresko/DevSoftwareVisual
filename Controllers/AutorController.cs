using LojaLivrosAPI.Data;
using LojaLivrosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LojaLivrosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AutorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Autor>> GetAutores() => _context.Autores.ToList();

        [HttpGet("{id}")]
        public ActionResult<Autor> GetAutor(int id)
        {
            var autor = _context.Autores.Find(id);
            if (autor == null) return NotFound();
            return autor;
        }

        [HttpPost]
        public ActionResult<Autor> CreateAutor([FromBody] Autor autor)
        {
            _context.Autores.Add(autor);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAutor), new { id = autor.AutorId }, autor);
        }

        
    }
}