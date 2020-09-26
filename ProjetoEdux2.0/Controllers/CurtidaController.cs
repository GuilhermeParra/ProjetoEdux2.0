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
    public class CurtidaController : ControllerBase
    {
        private readonly ProjetoSenaiiContext _context;

        public CurtidaController(ProjetoSenaiiContext context)
        {
            _context = context;
        }

        // GET: api/Curtida
        /// <summary>
        /// Mostra as custidas
        /// </summary>
        /// <returns>retorna todas as curtidas cadastradas</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curtida>>> GetCurtida()
        {
            return await _context.Curtida.ToListAsync();
        }

        // GET: api/Curtida/5
        /// <summary>
        /// mostra uma unica curtida
        /// </summary>
        /// <param name="id">id da curtida</param>
        /// <returns>retorna uma curtida</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Curtida>> GetCurtida(Guid id)
        {
            var curtida = await _context.Curtida.FindAsync(id);

            if (curtida == null)
            {
                return NotFound();
            }

            return curtida;
        }

        // PUT: api/Curtida/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// altera determinada curtida
        /// </summary>
        /// <param name="id">id da curtida</param>
        /// <param name="curtida">objeto com alterações</param>
        /// <returns>retorna a curtida alterada</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurtida(Guid id, Curtida curtida)
        {
            if (id != curtida.IdCurtida)
            {
                return BadRequest();
            }

            _context.Entry(curtida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurtidaExists(id))
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

        // POST: api/Curtida
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Cadastra uma curtida
        /// </summary>
        /// <param name="curtida">nome da curtida</param>
        /// <returns>retorna o objeto cadastrado</returns>
        [HttpPost]
        public async Task<ActionResult<Curtida>> PostCurtida(Curtida curtida)
        {
            _context.Curtida.Add(curtida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurtida", new { id = curtida.IdCurtida }, curtida);
        }

        // DELETE: api/Curtida/5
        /// <summary>
        /// Exclui uma curtida
        /// </summary>
        /// <param name="id">id da curtida</param>
        /// <returns>retorna uma curtida</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Curtida>> DeleteCurtida(Guid id)
        {
            var curtida = await _context.Curtida.FindAsync(id);
            if (curtida == null)
            {
                return NotFound();
            }

            _context.Curtida.Remove(curtida);
            await _context.SaveChangesAsync();

            return curtida;
        }

        private bool CurtidaExists(Guid id)
        {
            return _context.Curtida.Any(e => e.IdCurtida == id);
        }
    }
}
