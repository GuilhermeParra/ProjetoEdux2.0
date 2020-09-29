using Microsoft.AspNetCore.Http;
using System;
//using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

        [JsonIgnore]
        [NotMapped]
        public IFormFile ImagemNova { get; set; }

        public string UrlImagem { get; set; }
        public Guid? IdUsuario { get; set; }

        [JsonIgnore]
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Curtida> Curtida { get; set; }
    }
}
