using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Models.Enums
{
    public enum StatusMatricula
    {
        [Display(Name = "Disponivel")] Disponivel = 0,
        [Display(Name = "Matriculado")] Matriculado = 1,
        [Display(Name = "Cancelado")] Cancelado = 2,
        [Display(Name = "Requisito")] Requisito = 3,
    }
}
