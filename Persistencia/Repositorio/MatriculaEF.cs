using Entidades.Interface;
using Entidades.Models;
using Entidades.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Repositorio
{
    public class MatriculaEF : IMatriculaDAO
    {
        private readonly MatriculasPSA2021Context _context;
        //construtor entity framework        
        public MatriculaEF(MatriculasPSA2021Context context)
        {
            _context = context;
        }


        //Efetua a matrícula
        public Boolean addMatricula(Matricula matricula, Turma turma)
        {
            
            if (turma.Status == 0 && turma.NumeroDeVaga >=1)
            {
                _context.Add(matricula);
                _context.SaveChanges();

                return true;
            }

            return false;
        }


    }
}
