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
