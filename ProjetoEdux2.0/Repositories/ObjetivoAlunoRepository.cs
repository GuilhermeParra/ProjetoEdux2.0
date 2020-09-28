using ProjetoEdux2._0.Contexts;
using ProjetoEdux2._0.Domains;
using ProjetoEdux2._0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux2._0.Repositories
{

    public class ObjetivoAlunoRepository : IObjetivoAluno
    {
        private readonly ProjetoSenaiiContext _ctx;

        public ObjetivoAlunoRepository()
        {
            _ctx = new ProjetoSenaiiContext();
        }

        /// <summary>
        /// adiciona um objetivo pro aluno
        /// </summary>
        /// <param name="objetivoaluno"></param>
        public void Adicionar(ObjetivoAluno objetivoaluno)
        {
            try
            {
                //adiciona objeto do tipo objetivo ao dbset do contexto objetivoaluno
                _ctx.ObjetivoAluno.Add(objetivoaluno);

                //salva as alterações no contexto objetivoaluno
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// faz uma busca de objetivo por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>retorna o objetivo do aluno pelo id</returns>
        public ObjetivoAluno BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.ObjetivoAluno.FirstOrDefault(c => c.IdObjetivoAluno == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// edita um objetivo do aluno
        /// </summary>
        /// <param name="objetivoaluno"></param>
        public void Editar(ObjetivoAluno objetivoaluno)
        {
            try
            {
                ObjetivoAluno objetivoalunotemp = BuscarPorId(objetivoaluno.IdObjetivoAluno);

                if (objetivoalunotemp == null)
                    throw new Exception("objetivo não encontrado");

                objetivoalunotemp.Nota = objetivoaluno.Nota;
                objetivoalunotemp.IdAlunoTurma = objetivoaluno.IdAlunoTurma;
                objetivoalunotemp.DataAlcancado = objetivoaluno.DataAlcancado;
                objetivoalunotemp.IdObjetivo = objetivoaluno.IdObjetivo;

                _ctx.ObjetivoAluno.Update(objetivoalunotemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// cria uma lista de objetivos do aluno
        /// </summary>
        /// <returns>retorna uma lista de objetivos</returns>
        public List<ObjetivoAluno> Listar()
        {
            try
            {
                return _ctx.ObjetivoAluno.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// remove um objetivo do aluno
        /// </summary>
        /// <param name="id"></param>
        public void Remover(Guid id)
        {
            try
            {
                ObjetivoAluno objetivoalunotemp = BuscarPorId(id);

                if (objetivoalunotemp == null)
                    throw new Exception("Objetivo nao encontrado");

                _ctx.ObjetivoAluno.Remove(objetivoalunotemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
