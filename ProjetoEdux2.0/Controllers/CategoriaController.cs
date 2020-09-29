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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoria _categoriaRepository;

        public CategoriaController()
        {
            _categoriaRepository = new CategoriaRepository();
        }

        // GET: api/Categoria
        /// <summary>
        /// Mostra as categorias 
        /// </summary>
        /// <returns>retorna todas as categorias cadastradas</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> GetCategoria()
        {
            return _categoriaRepository.Listar();
        }

        // GET: api/Categoria/5
        /// <summary>
        /// mostra uma unica categoria
        /// </summary>
        /// <param name="id">id da categoria</param>
        /// <returns>retorna uma categoria</returns>
        [HttpGet("{id}")]
        public ActionResult<Categoria> GetCategoria(Guid id)
        {
            var categoria = _categoriaRepository.BuscarPorId(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        // PUT: api/Categoria/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// altera determinada categoria
        /// </summary>
        /// <param name="id">id da categoria </param>
        /// <param name="categoria">objeto com alteraçoes</param>
        /// <returns>retorna produto alterado</returns>
        [HttpPut("{id}")]
        public IActionResult PutCategoria(Guid id, Categoria categoria)
        {
            if (id != categoria.IdCategoria)
            {
                return BadRequest();
            }

            

            try
            {
                _categoriaRepository.Editar(categoria);

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
        }

        // POST: api/Categoria
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Cadastra uma categoria
        /// </summary>
        /// <param name="categoria">nome da categoria</param>
        /// <returns>retorna objeto cadastrado</returns>
        [HttpPost]
        public IActionResult PostCategoria([FromForm] Categoria categoria)
        {
            _categoriaRepository.Adicionar(categoria);

            return CreatedAtAction("GetCategoria", new { id = categoria.IdCategoria }, categoria);
        }

        /*[HttpPost]
        public IActionResult Post([FromBody]Categoria novaCategoria)
        {
            Categoria categoria = new Categoria()
            {
                Tipo = novaCategoria.Tipo,
                Objetivo = novaCategoria.Objetivo
            };
            _context.Add(categoria);

            _context.SaveChangesAsync();

            return StatusCode(201);
            
        }*/

        // DELETE: api/Categoria/5
        /// <summary>
        /// exclui uma categoria
        /// </summary>
        /// <param name="id">id da categoria</param>
        /// <returns>retorna uma categoria</returns>
        [HttpDelete("{id}")]
        public ActionResult<Categoria> DeleteCategoria(Guid id)
        {
            try
            {
                var categoria = _categoriaRepository.BuscarPorId(id);
                if (categoria == null)
                {
                    return NotFound();
                }

                _categoriaRepository.Remover(id);

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
