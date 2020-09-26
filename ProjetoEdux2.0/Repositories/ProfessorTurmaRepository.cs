using ProjetoEdux2._0.Contexts;
using ProjetoEdux2._0.Domains;
using ProjetoEdux2._0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux2._0.Repositories
{
    public class ProfessorTurmaRepository : IProfessorTurma
    {
        private readonly ProjetoSenaiiContext _ctx;

        public ProfessorTurmaRepository()
        {
            _ctx = new ProjetoSenaiiContext();
        }

        /// <summary>
        /// Cadastra um professor
        /// </summary>
        /// <param name="professorTurma">Objeto de Adicionar</param>
        public void Adicionar(ProfessorTurma professorTurma)
        {
            try
            {
                _ctx.Set<ProfessorTurma>().Update(professorTurma);

                //Salva as alterações
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca o professor pelo Id
        /// </summary>
        /// <param name="id">Objeto de BuscarPorId</param>
        /// <returns>O professor buscado</returns>
        public ProfessorTurma BuscarPorId(Guid id)
        {
            try
            {

                return _ctx.ProfessorTurma.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca o professor pelo nome
        /// </summary>
        /// <param name="descricao">Objeto de BuscarPorNome</param>
        /// <returns>O professor buscado pelo nome</returns>
        public List<ProfessorTurma> BuscarPorNome(string descricao)
        {
            try
            {
                return _ctx.ProfessorTurma.Where(c => c.Descricao.Contains(descricao)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        /// <summary>
        /// Edita o professor cadastrado
        /// </summary>
        /// <param name="professorTurma">Objeto de Editar</param>
        public void Editar(ProfessorTurma professorTurma)
        {
            try
            {

                ProfessorTurma professor = BuscarPorId(professorTurma.IdProfessorTurma);


                if (professor == null)
                {
                    throw new Exception("Turma não encontrada");

                }

                professor.Descricao = professorTurma.Descricao;


                //Altera a turma no contexto
                _ctx.ProfessorTurma.Update(professor);
                _ctx.SaveChanges();
            }


            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista todos os professores
        /// </summary>
        /// <returns>Todos os professor listados</returns>
        public List<ProfessorTurma> Listar()
        {
            try
            {
                return _ctx.ProfessorTurma.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove os professores
        /// </summary>
        /// <param name="id">Objeto de Remover</param>
        public void Remover(Guid id)
        {
            try
            {

                ProfessorTurma professor = BuscarPorId(id);


                if (professor == null)
                {
                    throw new Exception("Turma não encontrada");

                }

                _ctx.ProfessorTurma.Remove(professor);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            };
        }
    }
}
