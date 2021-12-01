
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Entidades.Models
{
    public class Aluno : IdentityUser
    {
        public int AlunoId { get; set; }
        [MaxLength(30)]
        [Display(Name = "Nome")]
        public string NomeAluno { get; set; }
        public string Curso { get; set; }

        [MaxLength(6)]
        [Display(Name = "Matrícula")]
        public string MaticulaFaculdade { get; set; }


        public ICollection<Historico> ItemHistoricos { get; set; }

        public ICollection<Turma> TurmaMatriculadas { get; set; }

    }
}
