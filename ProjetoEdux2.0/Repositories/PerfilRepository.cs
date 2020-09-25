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
        #endregion
    }
}
