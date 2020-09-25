using ProjetoEdux2._0.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux2._0.Interfaces
{
    public interface ICategoria
    {
        List<Categoria> Listar();
        Categoria BuscarPorId(Guid id);
        Categoria BuscarPorNome(string nome);
        void Adicionar(Categoria categoria);
        void Editar(Categoria categoria);
        void Remover(Guid id);
    }
}