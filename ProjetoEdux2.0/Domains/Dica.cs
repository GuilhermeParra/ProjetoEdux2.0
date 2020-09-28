using Microsoft.AspNetCore.Http;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        [NotMapped]
        public IFormFile Imagem { get; set; }


        public string UrlImagem { get; set; }
        public Guid? IdUsuario { get; set; }

        [JsonProperty]
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Curtida> Curtida { get; set; }
    }
}
