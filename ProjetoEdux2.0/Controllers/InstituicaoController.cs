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
    public class InstituicaoController : ControllerBase
    {
        private readonly IInstituicao _instituicaoRepository;

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        // GET: api/Instituicao
        /// <summary>
        /// mostra a insituição
        /// </summary>
        /// <returns>retorna todas as instituições</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Instituicao>> GetInstituicao()
        {
            return _instituicaoRepository.Listar();
        }

        // GET: api/Instituicao/5
        /// <summary>
        /// mostra uma unica instituição
        /// </summary>
        /// <param name="id">id da instituição</param>
        /// <returns>retorna uma instuituição</returns>
        [HttpGet("{id}")]
        public ActionResult<Instituicao> GetInstituicao(Guid id)
        {
            var instituicao = _instituicaoRepository.BuscarPorId(id);

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
        public IActionResult PutInstituicao(Guid id, Instituicao instituicao)
        {
            if (id != instituicao.IdInstituicao)
            {
                return BadRequest();
            }

            

            try
            {
                _instituicaoRepository.Editar(instituicao);
                return Ok(instituicao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
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
        public IActionResult PostInstituicao([FromForm] Instituicao instituicao)
        {
            _instituicaoRepository.Adicionar(instituicao);

            return CreatedAtAction("GetInstituicao", new { id = instituicao.IdInstituicao }, instituicao);
        }

        // DELETE: api/Instituicao/5
        /// <summary>
        /// exclui uma instituição
        /// </summary>
        /// <param name="id">id da instituição</param>
        /// <returns>retorna uma insituição</returns>
        [HttpDelete("{id}")]
        public ActionResult<Instituicao> DeleteInstituicao(Guid id)
        {
            try
            {
                var instituicao = _instituicaoRepository.BuscarPorId(id);
                if (instituicao == null)
                {
                    return NotFound();
                }

                _instituicaoRepository.Remover(id);

                return Ok(instituicao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
