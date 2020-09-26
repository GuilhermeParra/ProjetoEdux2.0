using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProjetoEdux2._0.Domains
{
    public partial class ProfessorTurma
    {
        public Guid IdProfessorTurma { get; set; }
        public string Descricao { get; set; }
        public Guid? IdUsuario { get; set; }
        public Guid? IdTurma { get; set; }
        [JsonIgnore]
        public virtual Turma IdTurmaNavigation { get; set; }
        [JsonIgnore]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    } 
}
