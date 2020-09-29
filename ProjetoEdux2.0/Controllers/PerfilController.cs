using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEdux2._0.Contexts;
using ProjetoEdux2._0.Domains;
using ProjetoEdux2._0.Interfaces;
using ProjetoEdux2._0.Repositories;

namespace ProjetoEdux2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfil _perfiRepository;

        public PerfilController()
        {
            _perfiRepository = new PerfilRepository();
        }

        // GET: api/Perfil
        /// <summary>
        /// mostra os perfis
        /// </summary>
        /// <returns>retorna todas os perfis cadastrados</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Perfil>> GetPerfil()
        {
            return _perfiRepository.Listar();
        }

        // GET: api/Perfil/5
        /// <summary>
        /// mostra um unico perfil
        /// </summary>
        /// <param name="id">id do perfil</param>
        /// <returns>retorna um perfil</returns>
        [HttpGet("{id}")]
        public ActionResult<Perfil> GetPerfil(Guid id)
        {
            var perfil = _perfiRepository.BuscarPorId(id);

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
        public IActionResult PutPerfil(Guid id, Perfil perfil)
        {
            if (id != perfil.IdPerfil)
            {
                return BadRequest();
            }

            

            try
            {
                _perfiRepository.Editar(perfil);
                return Ok(perfil);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
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
        public IActionResult PostPerfil([FromForm] Perfil perfil)
        {
            _perfiRepository.Adiconar(perfil);

            return CreatedAtAction("GetPerfil", new { id = perfil.IdPerfil }, perfil);
        }

        // DELETE: api/Perfil/5
        /// <summary>
        /// exclui um perfil
        /// </summary>
        /// <param name="id">id do perfil</param>
        /// <returns>retorna um perfil</returns>
        [HttpDelete("{id}")]
        public ActionResult<Perfil> DeletePerfil(Guid id)
        {
            try
            {
                var perfil = _perfiRepository.BuscarPorId(id);
                if (perfil == null)
                {
                    return NotFound();
                }

                _perfiRepository.Remover(id);

                return Ok(perfil);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*private bool PerfilExists(Guid id)
        {
            return _context.Perfil.Any(e => e.IdPerfil == id);
        }*/
    }
}
