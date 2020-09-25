using ProjetoEdux2._0.Contexts;
using ProjetoEdux2._0.Domains;
using ProjetoEdux2._0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux2._0.Repositories
{
    public class CategoriaRepository : ICategoria
    {
        private readonly ProjetoSenaiiContext _ctx;
        public CategoriaRepository()
        {
            _ctx = new ProjetoSenaiiContext();
        }

        /// <summary>
        /// Adiciona uma Categoria
        /// </summary>
        /// <param name="categoria">objeto tipo categoria </param>
        public void Adicionar(Categoria categoria)
        {
            try
            {
                //adiciona um objeto , pode se acionar mais de uma vez
                _ctx.Categoria.Add(categoria);


                //salvar no db
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca um determinado id
        /// </summary>
        /// <param name="id">retorna um id</param>
        /// <returns></returns>
        public Categoria BuscarPorId(Guid id)
        {
            try
            {

                return _ctx.Categoria.Find(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca uma determinada categoria
        /// </summary>
        /// <param name="nome">retorna nome da categoria</param>
        /// <returns></returns>
        public Categoria BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.Categoria.Find(nome);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edita uma categoria 
        /// </summary>
        /// <param name="categoria">objeto tipo categoria</param>
        public void Editar(Categoria categoria)
        {
            try
            {
                Categoria categoriaTemp = BuscarPorId(categoria.IdCategoria);
                if (categoriaTemp == null)
                    throw new Exception("Categoria não encontrada ");

                categoriaTemp.Tipo = categoria.Tipo;


                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista uuma tabela de categorias
        /// </summary>
        /// <returns>returna uma lista com categorias </returns>
        public List<Categoria> Listar()
        {

            try
            {
                return _ctx.Categoria.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove uma categoria
        /// </summary>
        /// <param name="id">id da categoria</param>
        public void Remover(Guid id)
        {
            try
            {
                Categoria categoriaTemp = BuscarPorId(id);
                if (categoriaTemp == null)
                    throw new Exception("Categoria não encontrada ");



                _ctx.Categoria.Remove(categoriaTemp);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}