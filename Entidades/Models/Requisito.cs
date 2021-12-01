using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entidades.Models
{
    public class Requisito
    {
        public int RequisitoId { get; set; }

        public ICollection<Disciplina> Disciplinas { get; set; }

    }
}
