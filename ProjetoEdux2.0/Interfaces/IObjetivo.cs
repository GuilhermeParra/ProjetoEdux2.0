using ProjetoEdux2._0.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux2._0.Interfaces
{
    interface IObjetivo
    {
        List<Objetivo> Listar();
        Objetivo BuscarPorId(Guid id);
        Objetivo BuscarPorNome(string nome);
        void Adicionar(Objetivo objetivo);
        void Editar(Objetivo objetivo);
        void Remover(Guid id);
    }
}
