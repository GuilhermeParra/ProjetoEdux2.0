using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEdux2._0.Contexts;
using ProjetoEdux2._0.Domains;

namespace ProjetoEdux2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private ProjetoSenaiiContext _context = new ProjetoSenaiiContext();

        // GET: api/Curso
        /// <summary>
        /// Mostra os cursos
        /// </summary>
        /// <returns>retorna os cursos cadastrados</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCurso()
        {
            return await _context.Curso.ToListAsync();
        }

        // GET: api/Curso/5
        /// <summary>
        /// mostra uma unica categoria
        /// </summary>
        /// <param name="id">id do curso</param>
        /// <returns>retorna um curso</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(Guid id)
        {
            var curso = await _context.Curso.FindAsync(id);

            if (curso == null)
            {
                return NotFound();
            }

            return curso;
        }

        // PUT: api/Curso/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// edita os cursos cadastrados
        /// </summary>
        /// <param name="id">id do curso</param>
        /// <param name="curso">Objeto com alterações</param>
        /// <returns>O curso editado</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(Guid id, Curso curso)
        {
            if (id != curso.IdCurso)
            {
                return BadRequest();
            }

            _context.Entry(curso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Curso
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// cadastra um novo cursp
        /// </summary>
        /// <param name="curso">Objeto com alterações</param>
        /// <returns>retorna o objeto cadastrado</returns>
        [HttpPost]
        public async Task<ActionResult<Curso>> PostCurso(Curso curso)
        {
            _context.Curso.Add(curso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurso", new { id = curso.IdCurso }, curso);
        }

        // DELETE: api/Curso/5
        /// <summary>
        /// Deleta o curso
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna o objeto deletado</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Curso>> DeleteCurso(Guid id)
        {
            var curso = await _context.Curso.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            _context.Curso.Remove(curso);
            await _context.SaveChangesAsync();

            return curso;
        }
        
        private bool CursoExists(Guid id)
        {
            return _context.Curso.Any(e => e.IdCurso == id);
        }
    }
}
