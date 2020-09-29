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
    public class CursoController : ControllerBase
    {
        private readonly ICurso _cursoRepository;

        public CursoController()
        {
            _cursoRepository = new CursoRepository();
        }

        // GET: api/Curso
        /// <summary>
        /// Mostra os cursos
        /// </summary>
        /// <returns>retorna os cursos cadastrados</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Curso>> GetCurso()
        {
            return _cursoRepository.Listar();
        }

        // GET: api/Curso/5
        /// <summary>
        /// mostra uma unica categoria
        /// </summary>
        /// <param name="id">id do curso</param>
        /// <returns>retorna um curso</returns>
        [HttpGet("{id}")]
        public ActionResult<Curso> GetCurso(Guid id)
        {
            var curso = _cursoRepository.BuscarPorId(id);

            if (curso == null)
            {
                return NotFound();
            }

            return curso;
        }

        // PUT: api/Curso/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// edita os cursos cadastrados
        /// </summary>
        /// <param name="id">id do curso</param>
        /// <param name="curso">Objeto com alterações</param>
        /// <returns>O curso editado</returns>
        [HttpPut("{id}")]
        public IActionResult PutCurso(Guid id, Curso curso)
        {
            if (id != curso.IdCurso)
            {
                return BadRequest();
            }

            

            try
            {
                _cursoRepository.Editar(curso);
                return Ok(curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
        }

        // POST: api/Curso
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// cadastra um novo curso
        /// </summary>
        /// <param name="curso">Objeto com alterações</param>
        /// <returns>retorna o objeto cadastrado</returns>
        [HttpPost]
        public IActionResult PostCurso([FromForm] Curso curso)
        {
            _cursoRepository.Adicionar(curso);

            return CreatedAtAction("GetCurso", new { id = curso.IdCurso }, curso);
        }

        // DELETE: api/Curso/5
        /// <summary>
        /// Deleta o curso
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna o objeto deletado</returns>
        [HttpDelete("{id}")]
        public ActionResult<Curso> DeleteCurso(Guid id)
        {
            try
            {
                var curso = _cursoRepository.BuscarPorId(id);
                if (curso == null)
                {
                    return NotFound();
                }

                _cursoRepository.Remover(id);

                return Ok(curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
       
    }
}
