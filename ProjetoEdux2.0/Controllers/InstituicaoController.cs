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
    public class InstituicaoController : ControllerBase
    {
        private ProjetoSenaiiContext _context = new ProjetoSenaiiContext();

        // GET: api/Instituicao
        /// <summary>
        /// mostra a insituição
        /// </summary>
        /// <returns>retorna todas as instituições</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instituicao>>> GetInstituicao()
        {
            return await _context.Instituicao.ToListAsync();
        }

        // GET: api/Instituicao/5
        /// <summary>
        /// mostra uma unica instituição
        /// </summary>
        /// <param name="id">id da instituição</param>
        /// <returns>retorna uma instuituição</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Instituicao>> GetInstituicao(Guid id)
        {
            var instituicao = await _context.Instituicao.FindAsync(id);

            if (instituicao == null)
            {
                return NotFound();
            }

            return instituicao;
        }

        // PUT: api/Instituicao/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// altera determinada instituição
        /// </summary>
        /// <param name="id">id da insituição</param>
        /// <param name="instituicao">Objeto com alterações</param>
        /// <returns>retorna produto alterado</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstituicao(Guid id, Instituicao instituicao)
        {
            if (id != instituicao.IdInstituicao)
            {
                return BadRequest();
            }

            _context.Entry(instituicao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstituicaoExists(id))
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

        // POST: api/Instituicao
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Cadastra uma instituição
        /// </summary>
        /// <param name="instituicao">Nome da insituição</param>
        /// <returns>retorna o objeto cadastrado</returns>
        [HttpPost]
        public async Task<ActionResult<Instituicao>> PostInstituicao(Instituicao instituicao)
        {
            _context.Instituicao.Add(instituicao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstituicao", new { id = instituicao.IdInstituicao }, instituicao);
        }

        // DELETE: api/Instituicao/5
        /// <summary>
        /// exclui uma instituição
        /// </summary>
        /// <param name="id">id da instituição</param>
        /// <returns>retorna uma insituição</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Instituicao>> DeleteInstituicao(Guid id)
        {
            var instituicao = await _context.Instituicao.FindAsync(id);
            if (instituicao == null)
            {
                return NotFound();
            }

            _context.Instituicao.Remove(instituicao);
            await _context.SaveChangesAsync();

            return instituicao;
        }

        private bool InstituicaoExists(Guid id)
        {
            return _context.Instituicao.Any(e => e.IdInstituicao == id);
        }
    }
}
