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
    public class DicaController : ControllerBase
    {
        private ProjetoSenaiiContext _context = new ProjetoSenaiiContext();

        // GET: api/Dica
        /// <summary>
        /// Mostra as dicas
        /// </summary>
        /// <returns>retorna todas as dicas</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dica>>> GetDica()
        {
            return await _context.Dica.ToListAsync();
        }

        // GET: api/Dica/5
        /// <summary>
        /// alterna uma determinada dica
        /// </summary>
        /// <param name="id">id da dica</param>
        /// <returns>tretorna uma dica</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Dica>> GetDica(Guid id)
        {
            var dica = await _context.Dica.FindAsync(id);

            if (dica == null)
            {
                return NotFound();
            }

            return dica;
        }

        // PUT: api/Dica/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// altera uma determinada curtida
        /// </summary>
        /// <param name="id">id da dica</param>
        /// <param name="dica">objeto com aletrações</param>
        /// <returns>retorna o produto alterado</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDica(Guid id, Dica dica)
        {
            if (id != dica.IdDica)
            {
                return BadRequest();
            }

            _context.Entry(dica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DicaExists(id))
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

        // POST: api/Dica
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Cadastra uma dica
        /// </summary>
        /// <param name="dica">nome da dica</param>
        /// <returns>retorna o objeto cadastrado</returns>
        [HttpPost]
        public async Task<ActionResult<Dica>> PostDica(Dica dica)
        {
            _context.Dica.Add(dica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDica", new { id = dica.IdDica }, dica);
        }

        // DELETE: api/Dica/5
        /// <summary>
        /// eclui uma dica
        /// </summary>
        /// <param name="id">id da dica</param>
        /// <returns>retorna uma dica</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dica>> DeleteDica(Guid id)
        {
            var dica = await _context.Dica.FindAsync(id);
            if (dica == null)
            {
                return NotFound();
            }

            _context.Dica.Remove(dica);
            await _context.SaveChangesAsync();

            return dica;
        }

        private bool DicaExists(Guid id)
        {
            return _context.Dica.Any(e => e.IdDica == id);
        }
    }
}
