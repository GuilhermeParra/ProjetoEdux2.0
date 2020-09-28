using ProjetoEdux2._0.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux2._0.Interfaces
{
    interface IObjetivoAluno
    {
        List<ObjetivoAluno> Listar();


        ObjetivoAluno BuscarPorId(Guid id);

        void Adicionar(ObjetivoAluno objetivoaluno);

        void Editar(ObjetivoAluno objetivoaluno);

        void Remover(Guid id);
    }
}