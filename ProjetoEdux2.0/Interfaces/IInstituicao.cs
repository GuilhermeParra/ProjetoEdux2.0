using ProjetoEdux2._0.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux2._0.Interfaces
{
    interface IInstituicao
    {
        List<Instituicao> Listar();
        //Busca na lista por nome 
        List<Instituicao> BuscarPorNome(string nome);
        //Busca uma instituição pelo ID
        Instituicao BuscarPorId(Guid id);
        //Adiciona uma instituição 
        void Adicionar(Instituicao inst);
        //Edita uma instituição 
        void Editar(Instituicao inst);
        //Remove uma instituição 
        void Remover(Guid id);
    }
}
