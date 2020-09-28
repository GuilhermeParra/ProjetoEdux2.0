using Microsoft.EntityFrameworkCore;
using ProjetoEdux2._0.Contexts;
using ProjetoEdux2._0.Domains;
using ProjetoEdux2._0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux2._0.Repositories
{
    public class CurtidaRepository : ICurtida
    {
        private readonly ProjetoSenaiiContext _ctx;

        public CurtidaRepository()
        {
            _ctx = new ProjetoSenaiiContext();
        }
        /// <summary>
        /// Adiciona uma curtida
        /// </summary>
        /// <param name="curtida">objeto curtida</param>
        public void Adicionar(Curtida curtida)
        {
            try
            {
                //adiciona um objeto , pode se acionar mais de uma vez
                _ctx.Curtida.Add(curtida);


                //salvar no db
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca uma curtida por id
        /// </summary>
        /// <param name="id">objeto de curtida</param>
        /// <returns>Uma curtida</returns>
        public Curtida BuscarPorId(Guid id)
        {
            try
            {

                return _ctx.Curtida.Find(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edita a curtida
        /// </summary>
        /// <param name="curtida">Objeto Curtida</param>
        public void Editar(Curtida curtida)
        {
            try
            {
                Curtida curtidaTemp = BuscarPorId(curtida.IdCurtida);
                if (curtidaTemp == null)
                    throw new Exception("Curtida não encontrado ");


                _ctx.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Lista todas as curtidas  
        /// </summary>
        /// <returns>Lista de curtidas</returns>
        public List<Curtida> Listar()
        {
            try
            {
                return _ctx.Curtida.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove uma curtida pelo id
        /// </summary>
        /// <param name="id">Id da curtida</param>
        public void Remover(Guid id)
        {
            try
            {
                Curtida curtidaTemp = BuscarPorId(id);
                if (curtidaTemp == null)
                    throw new Exception("Dica não encontrada ");



                _ctx.Curtida.Remove(curtidaTemp);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}