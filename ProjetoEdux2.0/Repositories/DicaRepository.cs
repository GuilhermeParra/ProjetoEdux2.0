using ProjetoEdux2._0.Contexts;
using ProjetoEdux2._0.Domains;
using ProjetoEdux2._0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux2._0.Repositories
{
    public class DicaRepository : IDica
    {
        private readonly ProjetoSenaiiContext _ctx;

        public DicaRepository()
        {
            _ctx = new ProjetoSenaiiContext();
        }

        /// <summary>
        /// Busca a dica pelo Id dela
        /// </summary>
        /// <param name="id">Id da dica</param>
        /// <returns>O Id solicitado</returns>
        #region Leitura
        public Dica BuscarPorId(Guid id)
        {
            try
            {

                return _ctx.Dica.Find(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista todas as dicas cadastradas
        /// </summary>
        /// <returns>A lista de dicas</returns>
        public List<Dica> Listar()
        {
            try
            {
                return _ctx.Dica.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Gravação

        /// <summary>
        /// Cadastra novas dicas 
        /// </summary>
        /// <param name="dica">Objeto de adicionar</param>
        public void Adicionar(Dica dica)
        {
            try
            {
                //adiciona um objeto , pode se acionar mais de uma vez
                _ctx.Set<Dica>().Add(dica);


                //salvar no db
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edita uma dica cadastrada
        /// </summary>
        /// <param name="dica">Objeto de editar</param>
        public void Editar(Dica dica)
        {
            try
            {
                Dica dicaTemp = BuscarPorId(dica.IdDica);
                if (dicaTemp == null)
                    throw new Exception("Dica não encontrada ");

                dicaTemp.Texto = dica.Texto;


                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Deleta um id cadastrado
        /// </summary>
        /// <param name="id">Id de dica</param>
        public void Remover(Guid id)
        {
            try
            {
                Dica dicaTemp = BuscarPorId(id);
                if (dicaTemp == null)
                    throw new Exception("Dica não encontrada ");



                _ctx.Dica.Remove(dicaTemp);

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