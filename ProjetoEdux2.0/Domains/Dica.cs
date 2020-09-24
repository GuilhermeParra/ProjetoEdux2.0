using System;
using System.Collections.Generic;

namespace ProjetoEdux2._0.Domains
{
    public partial class Dica
    {
        public Dica()
        {
            Curtida = new HashSet<Curtida>();
        }

        public Guid IdDica { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }
        public Guid? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Curtida> Curtida { get; set; }
    }
}
