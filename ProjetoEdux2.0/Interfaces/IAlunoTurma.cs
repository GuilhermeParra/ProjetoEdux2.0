using ProjetoEdux2._0.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux2._0.Interfaces
{
    interface IAlunoTurma
    {
        List<AlunoTurma> Listar();

        List<AlunoTurma> BuscarPorMatricula(string matricula);

        AlunoTurma BuscarPorId(Guid id);

        void Adicionar(AlunoTurma alunoturma);

        void Editar(AlunoTurma alunoturma);

        void Remover(Guid id);
    }
}