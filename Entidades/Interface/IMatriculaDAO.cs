using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interface
{
    public interface IMatriculaDAO
    {
        //Task<List<Matricula>> todasMatriculas();
        public Boolean addMatricula(Matricula matricula, Turma turma);
        //public Boolean cancelaMatricula(Matricula matricula, Turma turma);
        //void addMatricula(Matricula matricula);

    }
}
