using Entidades.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entidades.Models
{
    public class Turma
    {
        public int TurmaId { get; set; }
        public string NomeTurma { get; set; }
        public string Horario { get; set; }
        public int NumeroDeVaga { get; set; }
        public StatusMatricula Status { get; set; }

        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }

        public ICollection<Aluno> Alunos { get; set; }

    }
}
