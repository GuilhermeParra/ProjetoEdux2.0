using System;
using System.Collections.Generic;

namespace ProjetoEdux2._0.Domains
{
    public partial class Perfil
    {
        public Perfil()
        {
            Usuario = new HashSet<Usuario>();
        }

        public Guid IdPerfil { get; set; }
        public string Permissao { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
