using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entidades.Models
{
    public class Disciplina
    {
        public int DisciplinaId { get; set; }
        public string NomeDisciplina { get; set; }
        public string CodCred { get; set; }

        public ICollection<Historico> ItemHistoricos { get; set; }

        public ICollection<Requisito> Requisitos { get; set; }
        public ICollection<Turma> Turmas { get; set; }
        public ICollection<Matricula> Matriculas { get; set; }

    }
}
