using ProjetoEdux2._0.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux2._0.Interfaces
{
    interface IProfessorTurma
    {
		// mostra uma lista dos professores 
		List<ProfessorTurma> Listar();

		// faz uma busca precisa pelo professor 
		List<ProfessorTurma> BuscarPorNome(string descricao);

		//Busca um professor expecífico pelo id
		ProfessorTurma BuscarPorId(Guid id);

		//Cadastra o professor daturma
		void Adicionar(ProfessorTurma professorTurma);

		// Edita o professor da turma
		void Editar(ProfessorTurma professorTurma);

		//Remove o professor da turma por um id específico
		void Remover(Guid id);
	}
}
