﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProjetoEdux2._0.Domains
{
    public partial class ObjetivoAluno
    {
        public Guid IdObjetivoAluno { get; set; }
        public decimal? Nota { get; set; }
        public DateTime? DataAlcancado { get; set; }
        public Guid? IdAlunoTurma { get; set; }
        public Guid? IdObjetivo { get; set; }

        [JsonIgnore]
        public virtual AlunoTurma IdAlunoTurmaNavigation { get; set; }
        public virtual Objetivo IdObjetivoNavigation { get; set; }
    }
}
