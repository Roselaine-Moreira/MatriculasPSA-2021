using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entidades.Models
{
    public class Historico
    {
        public int HistoricoId { get; set; }
        public double Nota { get; set; }
        public string AnoSemetre { get; set; }

        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }

    }
}
