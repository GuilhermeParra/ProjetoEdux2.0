using ProjetoEdux2._0.Contexts;
using ProjetoEdux2._0.Domains;
using ProjetoEdux2._0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux2._0.Repositories
{
    public class UsuarioRepository : IUsuario
    {

        private readonly ProjetoSenaiiContext _ctx;

        public UsuarioRepository()
        {
            _ctx = new ProjetoSenaiiContext();
        }
        #region Leitura

        /// <summary>
        /// Busca o usuario pelo nome
        /// </summary>
        /// <param name="nome">Objeto de BuscarPorNome</param>
        /// <returns>O usuario buscado</returns>
        public List<Usuario> BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.Usuario.Where(c => c.Nome.Contains(nome)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        /// <summary>
        /// Lista todos os usuarios cadastrados
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        public List<Usuario> Listar()
        {
            try
            {
                return _ctx.Usuario.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca o usuario pelo Id
        /// </summary>
        /// <param name="id">Objeto de BuscarPorId</param>
        /// <returns>O usuario buscado pelo id</returns>
        public Usuario BuscarPorId(Guid id)
        {
            try
            {

                return _ctx.Usuario.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion


        #region Gravação

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">Objeto de Adicionar</param>
        public void Adicionar(Usuario usuario)
        {
            try
            {


                _ctx.Set<Usuario>().Update(usuario);

                //Salva as alterações
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edita o usuario cadastrado
        /// </summary>
        /// <param name="usuario">Objeto de Editar</param>
        public void Editar(Usuario usuario)
        {
            try { 
            
            Usuario usuarioTemp = BuscarPorId(usuario.IdUsuario);

            
            if (usuarioTemp == null)
            {
                throw new Exception("Usuario não encontrado");

            }
                
                usuarioTemp.Nome = usuario.Nome;
                usuarioTemp.Email = usuario.Email;
                usuarioTemp.Senha = usuario.Senha;
                usuarioTemp.DataCadastro = usuario.DataCadastro;
                usuarioTemp.DataUltimoAcesso = usuario.DataUltimoAcesso;
                



            //Altera usuario no contexto
            _ctx.Usuario.Update(usuarioTemp);
            _ctx.SaveChanges();}


            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    
        /// <summary>
        /// Remove um usuario pelo id
        /// </summary>
        /// <param name="id">Objeto de Remover</param>
        public void Remover(Guid id)
        {
            try
            {

                Usuario usuarioTemp = BuscarPorId(id);


                if (usuarioTemp == null)
                {
                    throw new Exception("Usuario não encontrado");

                }

                _ctx.Usuario.Remove(usuarioTemp);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            };
        }
        #endregion
    }
}
