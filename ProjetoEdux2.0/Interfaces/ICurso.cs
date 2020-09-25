using ProjetoEdux2._0.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux2._0.Interfaces
{
    interface ICurso
    {
        //Cria uma lista de diferentes cursos
        List<Curso> Listar();
        //Busca na lista por titulo do curso
        List<Curso> BuscarPorTitulo(string titulo);
        //Busca um curso pelo ID
        Curso BuscarPorId(Guid id);
        //Adiciona um curso
        void Adicionar(Curso curso);
        //Edita um curso
        void Editar(Curso curso);
        //Remove um curso
        void Remover(Guid id);
    }
}
