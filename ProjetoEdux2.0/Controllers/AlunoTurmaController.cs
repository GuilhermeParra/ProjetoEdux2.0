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
    public class AlunoTurmaController : ControllerBase
    {
        private readonly IAlunoTurma _alunoRepository;

        public AlunoTurmaController()
        {
            _alunoRepository = new AlunoTurmaRepository();
        }

        // GET: api/AlunoTurma
        /// <summary>
        /// Busca todos os alunos
        /// </summary>
        /// <returns>Uma lista de alunos</returns>
        [HttpGet]
        public ActionResult<IEnumerable<AlunoTurma>> GetAlunoTurma()
        {
            return _alunoRepository.Listar();
        }

        // GET: api/AlunoTurma/5
        /// <summary>
        /// Procura um aluno pelo Id
        /// </summary>
        /// <param name="id">Objeto de AlunoTurma</param>
        /// <returns>O aluno procurado</returns>
        [HttpGet("{id}")]
        public ActionResult<AlunoTurma> GetAlunoTurma(Guid id)
        {
            var alunoTurma = _alunoRepository.BuscarPorId(id);

            if (alunoTurma == null)
            {
                return NotFound();
            }

            return alunoTurma;
        }

        // PUT: api/AlunoTurma/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Edita as informações do aluno
        /// </summary>
        /// <param name="id">Objeto de AlunoTurma</param>
        /// <param name="alunoTurma">Objeto com alterações</param>
        /// <returns>A informação editada</returns>
        [HttpPut("{id}")]
        public IActionResult PutAlunoTurma(Guid id, AlunoTurma alunoTurma)
        {
            if (id != alunoTurma.IdAlunoTurma)
            {
                return BadRequest();
            }

            

            try
            {
                _alunoRepository.Editar(alunoTurma);
                return Ok(alunoTurma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
        }

        // POST: api/AlunoTurma
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Adiciona um novo aluno
        /// </summary>
        /// <param name="alunoTurma">Objeto adicionado</param>
        /// <returns>O aluno novo</returns>
        [HttpPost]
        public IActionResult PostAlunoTurma([FromForm] AlunoTurma alunoTurma)
        {
            _alunoRepository.Adicionar(alunoTurma);


            return CreatedAtAction("GetAlunoTurma", new { id = alunoTurma.IdAlunoTurma }, alunoTurma);
        }

        // DELETE: api/AlunoTurma/5
        /// <summary>
        /// Deleta o aluno cadastrado
        /// </summary>
        /// <param name="id">Objeto de AlunoTurma</param>
        /// <returns>O aluno removido</returns>
        [HttpDelete("{id}")]
        public ActionResult<AlunoTurma> DeleteAlunoTurma(Guid id)
        {
            try
            {
                var alunoTurma = _alunoRepository.BuscarPorId(id);
                if (alunoTurma == null)
                {
                    return NotFound();
                }

                _alunoRepository.Remover(id);

                return Ok(alunoTurma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
