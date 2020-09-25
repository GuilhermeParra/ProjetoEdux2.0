using ProjetoEdux2._0.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux2._0.Interfaces
{
    interface IUsuario
    {
		// mostra uma lista de usuarios 
		List<Usuario> Listar();

		// faz uma busca precisa por nome 
		List<Usuario> BuscarPorNome(string nome);

		//Busca um usuario expecífico por id
		Usuario BuscarPorId(Guid id);

		//Cadastra um usuario
		void Adicionar(Usuario usuario);

		// Edita um Usuario
		void Editar(Usuario usuario);

		//Remove um usuario específico por id 
		void Remover(Guid id);
	}
}
