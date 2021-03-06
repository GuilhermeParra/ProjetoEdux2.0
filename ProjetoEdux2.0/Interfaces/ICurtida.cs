﻿using ProjetoEdux2._0.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux2._0.Interfaces
{
    interface ICurtida
    {
        List<Curtida> Listar();
        void Editar(Curtida curtida);
        Curtida BuscarPorId(Guid Id);
        void Adicionar(Curtida curtida);
        void Remover(Guid id);
    }
}
