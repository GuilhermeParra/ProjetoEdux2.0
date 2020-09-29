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
using ProjetoEdux2._0.Utils.Crypt;

namespace ProjetoEdux2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        /*private ProjetoSenaiiContext _context = new ProjetoSenaiiContext();


        // GET: api/Usuarios
        /// <summary>
        /// Mostra os usuarios
        /// </summary>
        /// <returns>retorna todos os usuarios</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _context.Usuario.ToListAsync();
        }

        // GET: api/Usuarios/5
        /// <summary>
        /// mostra um usuario
        /// </summary>
        /// <param name="id">id do usuario</param>
        /// <returns>retorna um usuario</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(Guid id)
        {
            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// altera determinado usuario
        /// </summary>
        /// <param name="id">id do usuario</param>
        /// <param name="usuario">objeto com alterações</param>
        /// <returns>retorna usuario alterado</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(Guid id, Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Cadastra um usuario
        /// </summary>
        /// <param name="usuario">nome do usuario</param>
        /// <returns>retorna objeto cadastrado</returns>
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {

            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.IdUsuario }, usuario);
        }

        // DELETE: api/Usuarios/5
        /// <summary>
        /// exclui um usuario
        /// </summary>
        /// <param name="id">id do usuario</param>
        /// <returns>retorna um usuario</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(Guid id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }
        
        private bool UsuarioExists(Guid id)
        {
            return _context.Usuario.Any(e => e.IdUsuario == id);
        }*/

        private readonly IUsuario _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        // GET: api/Usuario
        /// <summary>
        /// Mostra as custidas
        /// </summary>
        /// <returns>retorna todas os usuarios cadastrados</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuario()
        {
            return _usuarioRepository.Listar();
        }

        // GET: api/Usuario/5
        /// <summary>
        /// mostra um unico usuario
        /// </summary>
        /// <param name="id">id do usuario</param>
        /// <returns>retorna uma usuario</returns>
        [HttpGet("{id}")]
        public ActionResult<Usuario> GetUsuario(Guid id)
        {
            var usuario = _usuarioRepository.BuscarPorId(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuario/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// altera determinado usuario
        /// </summary>
        /// <param name="id">id do usuario</param>
        /// <param name="usuario">objeto com alterações</param>
        /// <returns>retorna o uuario alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Usuario usuario)
        {
            try
            {
                
                _usuarioRepository.Editar(usuario);

                usuario.Senha = Crypto.Criptografar(usuario.Senha, usuario.Email.Substring(0, 4));

                //Retorna Ok com os dados do usuario
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Usuario
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Cadastra um usuario
        /// </summary>
        /// <param name="usuario">objeto adicionado</param>
        /// <returns>retorna o objeto cadastrado</returns>
        [HttpPost]
        public IActionResult Post([FromForm] Usuario usuario)
        {
            usuario.Senha = Crypto.Criptografar(usuario.Senha, usuario.Email.Substring(0, 4));
            try
            {


                _usuarioRepository.Adicionar(usuario);


                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Usuario/5
        /// <summary>
        /// Exclui um usuario
        /// </summary>
        /// <param name="id">id do usuario</param>
        /// <returns>retorna um usuario</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {

                var usuario = _usuarioRepository.BuscarPorId(id);


                if (usuario == null)
                    return NotFound();


                _usuarioRepository.Remover(id);
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
