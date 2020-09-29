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
    public class ObjetivoAlunoController : ControllerBase
    {
        private readonly IObjetivoAluno _objetivoAluRepository;

        public ObjetivoAlunoController()
        {
            _objetivoAluRepository = new ObjetivoAlunoRepository();
        }

        // GET: api/ObjetivoAluno
        /// <summary>
        /// Mostra todos os objetivos de alunos
        /// </summary>
        /// <returns>uma lista de objetivo de cada aluno</returns>
        [HttpGet]
        public ActionResult<IEnumerable<ObjetivoAluno>> GetObjetivoAluno()
        {
            return _objetivoAluRepository.Listar();
        }

        // GET: api/ObjetivoAluno/5
        /// <summary>
        /// Procura por um objetivo específico
        /// </summary>
        /// <param name="id">Id de objetivoAluno</param>
        /// <returns>O objetivo procurado</returns>
        [HttpGet("{id}")]
        public ActionResult<ObjetivoAluno> GetObjetivoAluno(Guid id)
        {
            var objetivoAluno = _objetivoAluRepository.BuscarPorId(id);

            if (objetivoAluno == null)
            {
                return NotFound();
            }

            return objetivoAluno;
        }

        // PUT: api/ObjetivoAluno/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Altera um determinado objetivo
        /// </summary>
        /// <param name="id">id de ObjetivoAluno</param>
        /// <param name="objetivoAluno">Objeto a ser alterado</param>
        /// <returns>O objetivo alterado</returns>
        [HttpPut("{id}")]
        public IActionResult PutObjetivoAluno(Guid id, ObjetivoAluno objetivoAluno)
        {
            if (id != objetivoAluno.IdObjetivoAluno)
            {
                return BadRequest();
            }

            

            try
            {
                _objetivoAluRepository.Editar(objetivoAluno);
                return Ok(objetivoAluno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
        }

        // POST: api/ObjetivoAluno
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Cadastra um novo objetivo
        /// </summary>
        /// <param name="objetivoAluno">Objeto a ser cadastrado</param>
        /// <returns>o objeto cadastrado</returns>
        [HttpPost]
        public IActionResult PostObjetivoAluno([FromForm] ObjetivoAluno objetivoAluno)
        {
            _objetivoAluRepository.Adicionar(objetivoAluno);

            return CreatedAtAction("GetObjetivoAluno", new { id = objetivoAluno.IdObjetivoAluno }, objetivoAluno);
        }

        // DELETE: api/ObjetivoAluno/5
        /// <summary>
        /// Remove um objetivo
        /// </summary>
        /// <param name="id">Id de ObjetivoAluno</param>
        /// <returns>O objetivo deletado</returns>
        [HttpDelete("{id}")]
        public ActionResult<ObjetivoAluno> DeleteObjetivoAluno(Guid id)
        {
            try
            {
                var objetivoAluno = _objetivoAluRepository.BuscarPorId(id);
                if (objetivoAluno == null)
                {
                    return NotFound();
                }

                _objetivoAluRepository.Remover(id);

                return Ok(objetivoAluno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*private bool ObjetivoAlunoExists(Guid id)
        {
            return _context.ObjetivoAluno.Any(e => e.IdObjetivoAluno == id);
        }*/
    }
}
