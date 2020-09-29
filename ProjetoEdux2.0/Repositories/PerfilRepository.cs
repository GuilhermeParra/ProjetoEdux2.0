using ProjetoEdux2._0.Contexts;
using ProjetoEdux2._0.Domains;
using ProjetoEdux2._0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux2._0.Repositories
{
    public class PerfilRepository : IPerfil
    {
        private readonly ProjetoSenaiiContext _ctx;

        public PerfilRepository()
        {
            _ctx = new ProjetoSenaiiContext();
        }
        #region Leitura

        /// <summary>
        /// Busca um perfil pelo Id
        /// </summary>
        /// <param name="id">Objeto de BuscarPorId</param>
        /// <returns>O perfil buscado</returns>
        public Perfil BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Perfil.FirstOrDefault(c => c.IdPerfil == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista todos os perfis
        /// </summary>
        /// <returns>Uma lista de perfis</returns>
        public List<Perfil> Listar()
        {
            try
            {
                return _ctx.Perfil.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Gravação

        /// <summary>
        /// Edita os perfis
        /// </summary>
        /// <param name="perfil">Objeto de editar</param>
        public void Editar(Perfil perfil)
        {
            try
            {
                Perfil PerfilPerm = BuscarPorId(perfil.IdPerfil);



                if (PerfilPerm == null)
                    throw new Exception("Perfil não encontrado");


                PerfilPerm.Permissao = perfil.Permissao;

                _ctx.Perfil.Update(PerfilPerm);
                _ctx.SaveChanges();
            
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove um perfil 
        /// </summary>
        /// <param name="id">Objeto de Remover</param>
        public void Remover(Guid id)
        {
            try
            {
                Perfil perfilPerm = BuscarPorId(id);

                _ctx.Perfil.Remove(perfilPerm);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Adiconar(Perfil perfil)
        {
            try
            {
                _ctx.Set<Perfil>().Update(perfil);

                //Salva as alterações
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
