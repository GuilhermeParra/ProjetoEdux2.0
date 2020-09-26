using ProjetoEdux2._0.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux2._0.Interfaces
{
    interface IDica
    {
        List<Dica> Listar();
        Dica BuscarPorId(Guid id);
        void Adicionar(Dica dica);
        void Editar(Dica dica);
        void Remover(Guid id);
    }
}