using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entidades.Models
{
    public class Matricula
    {
        public int MatriculaId { get; set; }
        public int AlunoId { get; set; }
        public int TurmaId { get; set; }

        public Aluno Aluno { get; set; }
        public ICollection<Turma> Turmas { get; set; }

    }
}
