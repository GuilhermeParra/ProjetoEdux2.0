using ProjetoEdux2._0.Contexts;
using ProjetoEdux2._0.Domains;
using ProjetoEdux2._0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux2._0.Repositories
{

    public class CursoRepository : ICurso
    {

        private readonly ProjetoSenaiiContext _ctx;

        public CursoRepository()
        {
            _ctx = new ProjetoSenaiiContext();
        }

        /// <summary>
        /// Adiciona um curso e salva
        /// </summary>
        /// <param name="curso">objeto</param>
        public void Adicionar(Curso curso)
        {
            try
            {
                _ctx.Curso.Add(curso);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca um Id de curso
        /// </summary>
        /// <param name="id">id de idCurso</param>
        /// <returns>retornaa um id</returns>
        public Curso BuscarPorId(Guid id)
        {
            try
            {

                return _ctx.Curso.Find(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Burca por um titulo de curso
        /// </summary>
        /// <param name="titulo">objeto</param>
        /// <returns>retorna um titulo</returns>
        public Curso BuscarPorTitulo(string titulo)
        {
            try
            {
                return _ctx.Curso.Find(titulo);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edita o titulo de um curso
        /// </summary>
        /// <param name="curso"> objeto</param>
        public void Editar(Curso curso)
        {
            try
            {
                Curso cursoTitulo = BuscarPorId(curso.IdCurso);
                if (cursoTitulo == null)
                    throw new Exception("Curso não encontrado ");
                cursoTitulo.Titulo = curso.Titulo;


                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista alguns cursos
        /// </summary>
        /// <returns>retorna uma lista</returns>
        public List<Curso> Listar()
        {
            try
            {
                return _ctx.Curso.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Remove algum curso desejável pelo Id
        /// </summary>
        /// <param name="id">id de idCurso</param>
        public void Remover(Guid id)
        {
            try
            {
                Curso cursoTitulo = BuscarPorId(id);
                if (cursoTitulo == null)
                    throw new Exception("Curso não encontrado ");
                _ctx.Curso.Remove(cursoTitulo);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        List<Curso> ICurso.BuscarPorTitulo(string titulo)
        {
            throw new NotImplementedException();
        }
    }
}