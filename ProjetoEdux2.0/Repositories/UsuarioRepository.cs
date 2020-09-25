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

        public void Editar(Usuario usuario)
        {
            try { 
            
            Usuario usuarioTemp = BuscarPorId(usuario.IdUsuario);

            
            if (usuarioTemp == null)
            {
                throw new Exception("Usuario não encontrado");

            }

            usuarioTemp.Nome = usuario.Nome;


            //Altera usuario no contexto
            _ctx.Usuario.Update(usuarioTemp);
            _ctx.SaveChanges();}


            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    


        

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
