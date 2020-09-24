using System;
using System.Collections.Generic;

namespace ProjetoEdux2._0.Domains
{
    public partial class Categoria
    {
        public Categoria()
        {
            Objetivo = new HashSet<Objetivo>();
        }

        public Guid IdCategoria { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Objetivo> Objetivo { get; set; }
    }
}
