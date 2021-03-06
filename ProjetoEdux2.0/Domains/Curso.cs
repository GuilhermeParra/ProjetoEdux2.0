﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProjetoEdux2._0.Domains
{
    public partial class Curso
    {
        public Curso()
        {
            Turma = new HashSet<Turma>();
        }

        public Guid IdCurso { get; set; }
        public string Titulo { get; set; }
        public Guid? IdInstituicao { get; set; }

        [JsonIgnore]
        public virtual Instituicao IdInstituicaoNavigation { get; set; }
        public virtual ICollection<Turma> Turma { get; set; }
    }
}
