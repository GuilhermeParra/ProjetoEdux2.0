using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProjetoEdux2._0.Domains
{
    public partial class AlunoTurma
    {
        public AlunoTurma()
        {
            ObjetivoAluno = new HashSet<ObjetivoAluno>();
        }

        public Guid IdAlunoTurma { get; set; }
        public string Matricula { get; set; }
        public Guid? IdUsuario { get; set; }
        public Guid? IdTurma { get; set; }

        [JsonIgnore]
        public virtual Turma IdTurmaNavigation { get; set; }
        [JsonIgnore]
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<ObjetivoAluno> ObjetivoAluno { get; set; }
    }
}
