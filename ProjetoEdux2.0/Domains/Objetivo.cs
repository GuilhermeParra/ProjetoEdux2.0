using System;
using System.Collections.Generic;

namespace ProjetoEdux2._0.Domains
{
    public partial class Objetivo
    {
        public Objetivo()
        {
            ObjetivoAluno = new HashSet<ObjetivoAluno>();
        }

        public Guid IdObjetivo { get; set; }
        public string Descricao { get; set; }
        public Guid? IdCategoria { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual ICollection<ObjetivoAluno> ObjetivoAluno { get; set; }
    }
}
