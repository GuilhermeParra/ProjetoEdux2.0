using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProjetoEdux2._0.Domains
{
    public partial class Curtida
    {
        public Guid IdCurtida { get; set; }
        public Guid? IdUsuario { get; set; }
        public Guid? IdDica { get; set; }

        [JsonIgnore]
        public virtual Dica IdDicaNavigation { get; set; }
        [JsonIgnore]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
