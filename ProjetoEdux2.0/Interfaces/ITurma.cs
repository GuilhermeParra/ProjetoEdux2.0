using ProjetoEdux2._0.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux2._0.Interfaces
{
    interface ITurma
    {
		// mostra uma lista das turmas 
		List<Turma> Listar();

		// faz uma busca precisa pela turma 
		List<Turma> BuscarPorNome(string descricao);

		//Busca um usuario expecífico pelo id
		Turma BuscarPorId(Guid id);

		//Cadastra a turma
		void Adicionar(Turma turma);

		// Edita a turma
		void Editar(Turma turma);

		//Remove a turma por um id específico
		void Remover(Guid id);
	}
}
