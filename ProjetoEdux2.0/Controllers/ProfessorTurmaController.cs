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
    public class ProfessorTurmaController : ControllerBase
    {
        private readonly IProfessorTurma _profeTurmaRepository;

        public ProfessorTurmaController()
        {
            _profeTurmaRepository = new ProfessorTurmaRepository();
        }

        // GET: api/ProfessorTurma
        /// <summary>
        /// exclui um professor
        /// </summary>
        /// <returns>retorna todos os professores</returns>
        [HttpGet]
        public ActionResult<IEnumerable<ProfessorTurma>> GetProfessorTurma()
        {
            return _profeTurmaRepository.Listar();
        }

        // GET: api/ProfessorTurma/5
        /// <summary>
        /// mostra um unico professor
        /// </summary>
        /// <param name="id">id do professorTurma</param>
        /// <returns>retorna um professorTurma</returns>
        [HttpGet("{id}")]
        public ActionResult<ProfessorTurma> GetProfessorTurma(Guid id)
        {
            var professorTurma = _profeTurmaRepository.BuscarPorId(id);

            if (professorTurma == null)
            {
                return NotFound();
            }

            return professorTurma;
        }

        // PUT: api/ProfessorTurma/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// altera determinado professor
        /// </summary>
        /// <param name="id">id do professorTurma</param>
        /// <param name="professorTurma">objeto com alterações</param>
        /// <returns>retorna produto alterado</returns>
        [HttpPut("{id}")]
        public IActionResult PutProfessorTurma(Guid id, ProfessorTurma professorTurma)
        {
            if (id != professorTurma.IdProfessorTurma)
            {
                return BadRequest();
            }

            

            try
            {
                _profeTurmaRepository.Editar(professorTurma);
                return Ok(professorTurma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // POST: api/ProfessorTurma
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// cadastra um professor
        /// </summary>
        /// <param name="professorTurma">nome do professor</param>
        /// <returns>retorna um objeto cadastrado</returns>
        [HttpPost]
        public IActionResult PostProfessorTurma([FromForm]ProfessorTurma professorTurma)
        {
            
            _profeTurmaRepository.Adicionar(professorTurma);


            return CreatedAtAction("GetProfessorTurma", new { id = professorTurma.IdProfessorTurma }, professorTurma);
        }

        // DELETE: api/ProfessorTurma/5
        /// <summary>
        /// exclui um professor
        /// </summary>
        /// <param name="id">id do professorTurma</param>
        /// <returns>retorna uma categoria</returns>
        [HttpDelete("{id}")]
        public ActionResult<ProfessorTurma> DeleteProfessorTurma(Guid id)
        {
            try
            {
                var professorTurma = _profeTurmaRepository.BuscarPorId(id);
                if (professorTurma == null)
                {
                    return NotFound();
                }

                _profeTurmaRepository.Remover(id);

                return Ok(professorTurma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*private bool ProfessorTurmaExists(Guid id)
        {
            return _context.ProfessorTurma.Any(e => e.IdProfessorTurma == id);
        }*/
    }
}
