using ProjetoEdux2._0.Contexts;
using ProjetoEdux2._0.Domains;
using ProjetoEdux2._0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux2._0.Repositories
{
    public class AlunoTurmaRepository : IAlunoTurma
    {
        private readonly ProjetoSenaiiContext _ctx;

        public AlunoTurmaRepository()
        {
            _ctx = new ProjetoSenaiiContext();
        }

        /// <summary>
        /// adiciona um aluno na turma
        /// </summary>
        /// <param name="alunoturma"></param>
        public void Adicionar(AlunoTurma alunoturma)
        {
            try
            {
                //adiciona objeto do tipo aluno ao dbset do contexto AlunoTurma
                _ctx.AlunoTurma.Add(alunoturma);

                //salva as alterações no contexto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// edita os alunos da turma
        /// </summary>
        /// <param name="alunoturma"></param>
        public void Editar(AlunoTurma alunoturma)
        {
            try
            {
                AlunoTurma alunoturmatemp = BuscarPorId(alunoturma.IdAlunoTurma);

                if (alunoturmatemp == null)
                    throw new Exception("aluno não encontrado");

                alunoturmatemp.Matricula = alunoturma.Matricula;
                alunoturmatemp.IdAlunoTurma = alunoturma.IdAlunoTurma;

                _ctx.AlunoTurma.Update(alunoturmatemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove um aluno da turma por id
        /// </summary>
        /// <param name="id"></param>
        public void Remover(Guid id)
        {
            try
            {
                AlunoTurma alunoturmatemp = BuscarPorId(id);

                if (alunoturmatemp == null)
                    throw new Exception("Aluno nao encontrado");

                _ctx.AlunoTurma.Remove(alunoturmatemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region Leitura

        /// <summary>
        /// Faz uma busca do aluno da turma pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna a busca feita pelo id</returns>
        public AlunoTurma BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.AlunoTurma.FirstOrDefault(c => c.IdAlunoTurma == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// faz uma busca pela matricula do aluno
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns>retorna o aluno pela pesquisa de matricula</returns>
        public List<AlunoTurma> BuscarPorMatricula(string matricula)
        {
            try
            {
                return _ctx.AlunoTurma.Where(c => c.Matricula.Contains(matricula)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// lista dos alunos da turma
        /// </summary>
        /// <returns>retorna em lista os alunos armazenados na turma em _ctx</returns>
        public List<AlunoTurma> Listar()
        {
            try
            {
                return _ctx.AlunoTurma.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

    }
}