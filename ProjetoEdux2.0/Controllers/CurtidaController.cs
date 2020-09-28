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
    public class CurtidaController : ControllerBase
    {
        private readonly ICurtida _curtidaRepository;

        public CurtidaController()
        {
           _curtidaRepository = new CurtidaRepository();
        }

        // GET: api/Curtida
        /// <summary>
        /// Mostra as custidas
        /// </summary>
        /// <returns>retorna todas as curtidas cadastradas</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Curtida>> GetCurtida()
        {
            return _curtidaRepository.Listar();
        }

        // GET: api/Curtida/5
        /// <summary>
        /// mostra uma unica curtida
        /// </summary>
        /// <param name="id">id da curtida</param>
        /// <returns>retorna uma curtida</returns>
        [HttpGet("{id}")]
        public ActionResult<Curtida> GetCurtida(Guid id)
        {
            var curtida = _curtidaRepository.BuscarPorId(id);

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
        public IActionResult Put(Guid id, Curtida curtida)
        {
            try
            {
                //Edita o produto
                _curtidaRepository.Editar(curtida);

                //Retorna Ok com os dados do produto
                return Ok(curtida);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
        public IActionResult Post([FromForm] Curtida curtida)
        {
            try
            {
               
                
                _curtidaRepository.Adicionar(curtida);

                
                return Ok(curtida);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Curtida/5
        /// <summary>
        /// Exclui uma curtida
        /// </summary>
        /// <param name="id">id da curtida</param>
        /// <returns>retorna uma curtida</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                
                var produto = _curtidaRepository.BuscarPorId(id);

                
                if (produto == null)
                    return NotFound();

                
                _curtidaRepository.Remover(id);
                //Retorna Ok
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
