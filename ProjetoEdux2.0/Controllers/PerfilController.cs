﻿using System;
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
    public class PerfilController : ControllerBase
    {
        private ProjetoSenaiiContext _context = new ProjetoSenaiiContext();

        // GET: api/Perfil
        /// <summary>
        /// mostra os perfis
        /// </summary>
        /// <returns>retorna todas os perfis cadastrados</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Perfil>>> GetPerfil()
        {
            return await _context.Perfil.ToListAsync();
        }

        // GET: api/Perfil/5
        /// <summary>
        /// mostra um unico perfil
        /// </summary>
        /// <param name="id">id do perfil</param>
        /// <returns>retorna um perfil</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Perfil>> GetPerfil(Guid id)
        {
            var perfil = await _context.Perfil.FindAsync(id);

            if (perfil == null)
            {
                return NotFound();
            }

            return perfil;
        }

        // PUT: api/Perfil/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// altera determinado perfil
        /// </summary>
        /// <param name="id">id do perfil</param>
        /// <param name="perfil">objeto com alterações</param>
        /// <returns>retorna produto alterado</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerfil(Guid id, Perfil perfil)
        {
            if (id != perfil.IdPerfil)
            {
                return BadRequest();
            }

            _context.Entry(perfil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilExists(id))
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

        // POST: api/Perfil
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// cadastra um perfil
        /// </summary>
        /// <param name="perfil">nome do perfil</param>
        /// <returns>retorna o objeto alterado</returns>
        [HttpPost]
        public async Task<ActionResult<Perfil>> PostPerfil(Perfil perfil)
        {
            _context.Perfil.Add(perfil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerfil", new { id = perfil.IdPerfil }, perfil);
        }

        // DELETE: api/Perfil/5
        /// <summary>
        /// exclui um perfil
        /// </summary>
        /// <param name="id">id do perfil</param>
        /// <returns>retorna um perfil</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Perfil>> DeletePerfil(Guid id)
        {
            var perfil = await _context.Perfil.FindAsync(id);
            if (perfil == null)
            {
                return NotFound();
            }

            _context.Perfil.Remove(perfil);
            await _context.SaveChangesAsync();

            return perfil;
        }

        private bool PerfilExists(Guid id)
        {
            return _context.Perfil.Any(e => e.IdPerfil == id);
        }
    }
}
