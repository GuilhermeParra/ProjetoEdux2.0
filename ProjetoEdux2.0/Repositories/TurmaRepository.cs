using ProjetoEdux2._0.Contexts;
using ProjetoEdux2._0.Domains;
using ProjetoEdux2._0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux2._0.Repositories
{
    public class TurmaRepository : ITurma
    {
        private readonly ProjetoSenaiiContext _ctx;

        public TurmaRepository()
        {
            _ctx = new ProjetoSenaiiContext();
        }

        /// <summary>
        /// Adiciona uma turma
        /// </summary>
        /// <param name="turma">Objeto de Adicionar</param>
        public void Adicionar(Turma turma)
        {
            try
            {
                _ctx.Set<Turma>().Update(turma);

                //Salva as alterações
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca a turma pelo Id
        /// </summary>
        /// <param name="id">Objeto de BuscarPorId</param>
        /// <returns>A turma buscada</returns>
        public Turma BuscarPorId(Guid id)
        {
            try
            {

                return _ctx.Turma.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca a turma pelo nome
        /// </summary>
        /// <param name="descricao">Objeto de BuscarPorNome</param>
        /// <returns>A turma buscada</returns>
        public List<Turma> BuscarPorNome(string descricao)
        {
            try
            {
                return _ctx.Turma.Where(c => c.Descricao.Contains(descricao)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        /// <summary>
        /// Edita a turma cadastrada
        /// </summary>
        /// <param name="turma">Objeto de Editar</param>
        public void Editar(Turma turma)
        {
            try
            {

                Turma turmaTemp = BuscarPorId(turma.IdTurma);


                if (turmaTemp == null)
                {
                    throw new Exception("Turma não encontrada");

                }

                turmaTemp.Descricao = turma.Descricao;


                //Altera a turma no contexto
                _ctx.Turma.Update(turmaTemp);
                _ctx.SaveChanges();
            }


            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista as turmas cadastradas
        /// </summary>
        /// <returns>A lista de turmas</returns>
        public List<Turma> Listar()
        {
            try
            {
                return _ctx.Turma.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove a turma pelo id
        /// </summary>
        /// <param name="id">Objeto de Remover</param>
        public void Remover(Guid id)
        {
            try
            {

                Turma turmaTemp = BuscarPorId(id);


                if (turmaTemp == null)
                {
                    throw new Exception("Turma não encontrada");

                }

                _ctx.Turma.Remove(turmaTemp);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            };
        }
    }
}
