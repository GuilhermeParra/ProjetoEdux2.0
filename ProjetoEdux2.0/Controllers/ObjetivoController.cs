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
    public class ObjetivoController : ControllerBase
    {
        private ProjetoSenaiiContext _context = new ProjetoSenaiiContext();


        // GET: api/Objetivo
        /// <summary>
        /// Mostra os objetivos
        /// </summary>
        /// <returns>retorna todos os objetivos</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Objetivo>>> GetObjetivo()
        {
            return await _context.Objetivo.ToListAsync();
        }

        // GET: api/Objetivo/5
        /// <summary>
        /// Mostra um unico objetivo
        /// </summary>
        /// <param name="id">ido do objetivo</param>
        /// <returns>retorna um unico objetivo</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Objetivo>> GetObjetivo(Guid id)
        {
            var objetivo = await _context.Objetivo.FindAsync(id);

            if (objetivo == null)
            {
                return NotFound();
            }

            return objetivo;
        }

        // PUT: api/Objetivo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Altera determinado objetivo
        /// </summary>
        /// <param name="id">id do objetivo</param>
        /// <param name="objetivo">objetivo</param>
        /// <returns>retorna objetivo alternado</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjetivo(Guid id, Objetivo objetivo)
        {
            if (id != objetivo.IdObjetivo)
            {
                return BadRequest();
            }

            _context.Entry(objetivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjetivoExists(id))
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

        // POST: api/Objetivo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Cadastra um Objetivo
        /// </summary>
        /// <param name="objetivo">objetivo</param>
        /// <returns>retorna o novo objetivo</returns>
        [HttpPost]
        public async Task<ActionResult<Objetivo>> PostObjetivo(Objetivo objetivo)
        {
            _context.Objetivo.Add(objetivo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObjetivo", new { id = objetivo.IdObjetivo }, objetivo);
        }

        // DELETE: api/Objetivo/5
        /// <summary>
        /// Exclui um objetivo 
        /// </summary>
        /// <param name="id">iddo objetivo</param>
        /// <returns>retorna objetivo</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Objetivo>> DeleteObjetivo(Guid id)
        {
            var objetivo = await _context.Objetivo.FindAsync(id);
            if (objetivo == null)
            {
                return NotFound();
            }

            _context.Objetivo.Remove(objetivo);
            await _context.SaveChangesAsync();

            return objetivo;
        }

        private bool ObjetivoExists(Guid id)
        {
            return _context.Objetivo.Any(e => e.IdObjetivo == id);
        }
    }
}
