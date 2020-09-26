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
    public class TurmaController : ControllerBase
    {
        private ProjetoSenaiiContext _context = new ProjetoSenaiiContext();

        // GET: api/Turma
        /// <summary>
        /// mostra todas as turmas
        /// </summary>
        /// <returns>retorna todas as turmas cadastradas</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turma>>> GetTurma()
        {
            return await _context.Turma.ToListAsync();
        }

        // GET: api/Turma/5
        /// <summary>
        /// mostra as turmas
        /// </summary>
        /// <param name="id">id da turma</param>
        /// <returns>retorna uma turma</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Turma>> GetTurma(Guid id)
        {
            var turma = await _context.Turma.FindAsync(id);

            if (turma == null)
            {
                return NotFound();
            }

            return turma;
        }

        // PUT: api/Turma/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// mostra uma unica turma
        /// </summary>
        /// <param name="id">id da turma</param>
        /// <param name="turma">objeto com alterações</param>
        /// <returns>retorna produto alterado</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTurma(Guid id, Turma turma)
        {
            if (id != turma.IdTurma)
            {
                return BadRequest();
            }

            _context.Entry(turma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurmaExists(id))
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

        // POST: api/Turma
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Cadastra uma turma
        /// </summary>
        /// <param name="turma">nome de turma</param>
        /// <returns>retorna objeto cadastrado</returns>
        [HttpPost]
        public async Task<ActionResult<Turma>> PostTurma(Turma turma)
        {
            _context.Turma.Add(turma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTurma", new { id = turma.IdTurma }, turma);
        }

        // DELETE: api/Turma/5
        /// <summary>
        /// exclui uma turma
        /// </summary>
        /// <param name="id">id da turma</param>
        /// <returns>retorna uma turma</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Turma>> DeleteTurma(Guid id)
        {
            var turma = await _context.Turma.FindAsync(id);
            if (turma == null)
            {
                return NotFound();
            }

            _context.Turma.Remove(turma);
            await _context.SaveChangesAsync();

            return turma;
        }
        
        private bool TurmaExists(Guid id)
        {
            return _context.Turma.Any(e => e.IdTurma == id);
        }
    }
}
