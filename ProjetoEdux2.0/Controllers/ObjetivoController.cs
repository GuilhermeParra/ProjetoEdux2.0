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
    public class ObjetivoController : ControllerBase
    {
        private readonly IObjetivo _objetivoRepository;

        public ObjetivoController()
        {
            _objetivoRepository = new ObjetivoRepository();
        }


        // GET: api/Objetivo
        /// <summary>
        /// Mostra os objetivos
        /// </summary>
        /// <returns>retorna todos os objetivos</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Objetivo>> GetObjetivo()
        {
            return _objetivoRepository.Listar();
        }

        // GET: api/Objetivo/5
        /// <summary>
        /// Mostra um unico objetivo
        /// </summary>
        /// <param name="id">ido do objetivo</param>
        /// <returns>retorna um unico objetivo</returns>
        [HttpGet("{id}")]
        public ActionResult<Objetivo> GetObjetivo(Guid id)
        {
            var objetivo = _objetivoRepository.BuscarPorId(id);

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
        public IActionResult PutObjetivo(Guid id, Objetivo objetivo)
        {
            if (id != objetivo.IdObjetivo)
            {
                return BadRequest();
            }

            

            try
            {
                _objetivoRepository.Editar(objetivo);
                return Ok(objetivo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };

            
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
        public IActionResult PostObjetivo([FromForm]Objetivo objetivo)
        {
            _objetivoRepository.Adicionar(objetivo);

            return CreatedAtAction("GetObjetivo", new { id = objetivo.IdObjetivo }, objetivo);
        }

        // DELETE: api/Objetivo/5
        /// <summary>
        /// Exclui um objetivo 
        /// </summary>
        /// <param name="id">iddo objetivo</param>
        /// <returns>retorna objetivo</returns>
        [HttpDelete("{id}")]
        public ActionResult<Objetivo> DeleteObjetivo(Guid id)
        {
            try
            {
                var objetivo = _objetivoRepository.BuscarPorId(id);
                if (objetivo == null)
                {
                    return NotFound();
                }

                _objetivoRepository.Remover(id);

                return Ok(objetivo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*private bool ObjetivoExists(Guid id)
        {
            return _context.Objetivo.Any(e => e.IdObjetivo == id);
        }*/
    }
}
