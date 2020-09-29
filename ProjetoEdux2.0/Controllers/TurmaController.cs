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
    public class TurmaController : ControllerBase
    {
        private readonly ITurma _turmaRepository;

        public TurmaController()
        {
           _turmaRepository = new TurmaRepository();
        }

        // GET: api/Turma
        /// <summary>
        /// mostra todas as turmas
        /// </summary>
        /// <returns>retorna todas as turmas cadastradas</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Turma>> GetTurma()
        {
            return _turmaRepository.Listar();
        }

        // GET: api/Turma/5
        /// <summary>
        /// mostra as turmas
        /// </summary>
        /// <param name="id">id da turma</param>
        /// <returns>retorna uma turma</returns>
        [HttpGet("{id}")]
        public ActionResult<Turma> GetTurma(Guid id)
        {
            var turma = _turmaRepository.BuscarPorId(id);

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
        public IActionResult PutTurma(Guid id, Turma turma)
        {
            if (id != turma.IdTurma)
            {
                return BadRequest();
            }

            

            try
            {
                _turmaRepository.Editar(turma);
                return Ok(turma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
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
        public IActionResult PostTurma([FromForm]Turma turma)
        {
            _turmaRepository.Adicionar(turma);

            return CreatedAtAction("GetTurma", new { id = turma.IdTurma }, turma);
        }

        // DELETE: api/Turma/5
        /// <summary>
        /// exclui uma turma
        /// </summary>
        /// <param name="id">id da turma</param>
        /// <returns>retorna uma turma</returns>
        [HttpDelete("{id}")]
        public ActionResult<Turma> DeleteTurma(Guid id)
        {
            try
            {


                var turma = _turmaRepository.BuscarPorId(id);
                if (turma == null)
                {
                    return NotFound();
                }

                _turmaRepository.Remover(id);

                return Ok(turma);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        /*private bool TurmaExists(Guid id)
        {
            return _context.Turma.Any(e => e.IdTurma == id);
        }*/
    }
}
