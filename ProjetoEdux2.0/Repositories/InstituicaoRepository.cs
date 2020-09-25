using ProjetoEdux2._0.Contexts;
using ProjetoEdux2._0.Domains;
using ProjetoEdux2._0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux2._0.Repositories
{
    public class InstituicaoRepository : IInstituicao
    {
        private readonly ProjetoSenaiiContext _ctx;
        public InstituicaoRepository()
        {
            _ctx = new ProjetoSenaiiContext();
        }

        /// <summary>
        /// Adiciona uma instituição
        /// </summary>
        /// <param name="inst">objeto de Instituicao</param>
        public void Adicionar(Instituicao inst)
        {
            try
            {
                _ctx.Instituicao.Add(inst);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca um Id de instituicao
        /// </summary>
        /// <param name="id">Id de idInstituicao</param>
        /// <returns>retorna um Id</returns>
        public Instituicao BuscarPorId(Guid id)
        {
            try
            {

                return _ctx.Instituicao.Find(id);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Busca o nome das instituições cadastradas 
        /// </summary>
        /// <param name="nome">objeto</param>
        /// <returns>retona uma lista com as instituições cadastradas</returns>
        public List<Instituicao> BuscarPorNome(string nome)
        {
            
                try
                {
                return _ctx.Instituicao.Where(a => a.Nome.Contains(nome)).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            
        }

        /// <summary>
        /// Edita as propriedades de Instituicao
        /// </summary>
        /// <param name="inst">objeto</param>
        public void Editar(Instituicao inst)
        {
            {
                try
                {
                    Instituicao InstituicaoBusc = BuscarPorId(inst.IdInstituicao);

                    if (InstituicaoBusc == null)
                        throw new Exception("Instituição não encontrada");

                    InstituicaoBusc.Nome = inst.Nome;
                    InstituicaoBusc.Logradouro = inst.Logradouro;
                    InstituicaoBusc.Numero = inst.Numero;
                    InstituicaoBusc.Complemento = inst.Complemento;
                    InstituicaoBusc.Bairro = inst.Bairro;
                    InstituicaoBusc.Cidade = inst.Cidade;
                    InstituicaoBusc.Uf = inst.Uf;
                    InstituicaoBusc.Cep = inst.Cep;

                    _ctx.Instituicao.Update(InstituicaoBusc);
                    _ctx.SaveChanges();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// Lista várias instituicoes
        /// </summary>
        /// <returns>retorna uma lista</returns>
        public List<Instituicao> Listar()
        {
            try
            {
                return _ctx.Instituicao.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove uma instituicao
        /// </summary>
        /// <param name="id">id de IdInstituicao</param>
        public void Remover(Guid id)
        {
            try
            {
                Instituicao Inst = BuscarPorId(id);
                if (Inst == null)
                    throw new Exception("Instituicao não encontrada ");
                _ctx.Instituicao.Remove(Inst);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}