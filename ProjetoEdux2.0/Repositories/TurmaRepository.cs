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
