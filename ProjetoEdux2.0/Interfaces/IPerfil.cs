using ProjetoEdux2._0.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux2._0.Interfaces
{
    interface IPerfil
    {
		// mostra uma lista de perfil
		List<Perfil> Listar();

		//Busca um perfil expecífico por id
		Perfil BuscarPorId(Guid id);

		// Edita um perfil
		void Editar(Perfil perfil);

		//Remove um perfil específico por id 
		void Remover(Guid id);
	}
}
