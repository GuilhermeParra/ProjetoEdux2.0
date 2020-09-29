
using System;
using System.Collections.Generic;
using System.IO;
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
    public class DicasController : ControllerBase
    {
        private readonly IDica _dicaRepository;

        public DicasController()
        {
            _dicaRepository = new DicaRepository();
        }



        // GET: api/Dicas
        /// <summary>
        /// Mostra todas as dicas cadastradas
        /// </summary>
        /// <returns>Uma lista de dicas</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Dica>> GetDica()
        {
            return _dicaRepository.Listar();
        }

        // GET: api/Dicas/5
        /// <summary>
        /// Mostra uma dica específica
        /// </summary>
        /// <param name="id">Objeto de dica</param>
        /// <returns>A dica especificada</returns>
        [HttpGet("{id}")]
        public ActionResult<Dica> GetDica(Guid id)
        {
            var dica = _dicaRepository.BuscarPorId(id);

            if (dica == null)
            {
                return NotFound();
            }

            return dica;
        }

        // PUT: api/Dicas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Altera uma dica
        /// </summary>
        /// <param name="id">objeto com dica</param>
        /// <param name="dica">objeto a ser alterado</param>
        /// <returns>Objeto alterado</returns>
        [HttpPut("{id}")]
        public IActionResult PutDica(Guid id, Dica dica)
        {
            if (id != dica.IdDica)
            {
                return BadRequest();
            }

            

            try
            {
                _dicaRepository.Editar(dica);
                return Ok(dica);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            
        }

        // POST: api/Dicas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Cadastra uma nova dica
        /// </summary>
        /// <param name="dica">Objeto a ser cadastrado</param>
        /// <returns>A dica cadastrada</returns>
        [HttpPost]
        public IActionResult Post([FromForm] Dica dica)
        {
            try
            {
                
                if (dica.ImagemNova != null)
                {
                    var nomeArquivo = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(dica.ImagemNova.FileName);
                    var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwRoot/Upload/Imagens", nomeArquivo);

                    using var streamImagem = new FileStream(caminhoArquivo, FileMode.Create);

                    dica.ImagemNova.CopyTo(streamImagem);

                    dica.UrlImagem = "seulocalhost/Upload/Imagens" + nomeArquivo;

                }

                _dicaRepository.Adicionar(dica);

                return Ok(dica);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Dicas/5
        /// <summary>
        /// Deleta uma dica
        /// </summary>
        /// <param name="id">Id de dica</param>
        /// <returns>A dica removida</returns>
        [HttpDelete("{id}")]
        public ActionResult<Dica> DeleteDica(Guid id)
        {
            try
            {
                var dica = _dicaRepository.BuscarPorId(id);
                if (dica == null)
                {
                    return NotFound();
                }

                _dicaRepository.Remover(id);
                return Ok(dica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
