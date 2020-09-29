using ProjetoEdux2._0.Contexts;
using ProjetoEdux2._0.Domains;
using ProjetoEdux2._0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux2._0.Repositories
{
    public class ObjetivoRepository : IObjetivo
    {
        private readonly ProjetoSenaiiContext _ctx;
        public ObjetivoRepository()
        {
            _ctx = new ProjetoSenaiiContext();
        }

        /// <summary>
        /// Adiciona um novo objetivo
        /// </summary>
        /// <param name="objetivo">nome objetivo</param>
        public void Adicionar(Objetivo objetivo)
        {
            try
            {
                //adiciona um objeto , pode se acionar mais de uma vez
                _ctx.Objetivo.Add(objetivo);


                //salvar no db
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Buscar determinado objetivo por id
        /// </summary>
        /// <param name="id">id do objetivo </param>
        /// <returns>retorna seu id </returns>
        public Objetivo BuscarPorId(Guid id)
        {
            try
            {

                return _ctx.Objetivo.Find(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca um objetivo por seu nome 
        /// </summary>
        /// <param name="nome">nome do objetivo</param>
        /// <returns>retorna nome do objetivo</returns>

        public Objetivo BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.Objetivo.Find(nome);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// altera um objetivo
        /// </summary>
        /// <param name="objetivo">nome do objetivo</param>
        public void Editar(Objetivo objetivo)
        {
            try
            {
                Objetivo objetivoTemp = BuscarPorId(objetivo.IdObjetivo);
                if (objetivoTemp == null)
                    throw new Exception("Objetivo não encontrado ");

                //objetivoTemp.Tipo = Objetivo.Tipo;
                objetivoTemp.Descricao = objetivo.Descricao;



                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// lista todos os objetivos
        /// </summary>
        /// <returns>retorna uma lista de objetivos</returns>
        public List<Objetivo> Listar()
        {
            try
            {
                return _ctx.Objetivo.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// remove um objetivo
        /// </summary>
        /// <param name="id">id do objetivo</param>
        public void Remover(Guid id)
        {
            try
            {
                Objetivo objetivoTemp = BuscarPorId(id);
                if (objetivoTemp == null)
                    throw new Exception("Objetivo não encontrado ");



                _ctx.Objetivo.Remove(objetivoTemp);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}