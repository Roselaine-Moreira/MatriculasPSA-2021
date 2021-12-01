using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interface
{
   public interface ITurmaDAO
    {
        //Todas as turmas do banco:
        Task<List<Turma>> todasTurmas();
        //Todas as turmas disponíveis
        Task<List<Turma>> turmasDisponiveis();
        //Pega o Id da turma
        Task<Turma> getById(int id);
        //Pega o Id da turma matriculada
        Task<List<Turma>> getByIdTurmasMatriculadas();
        //Muda o status para matriculado
        void updateStatus(Turma turma, int idTurma);
        //Muda o status para cancelado 
        void updateStatusCancelado(Turma turma, int idTurma);
        //Todas as turmas matriculadas:
        Task<List<Turma>> turmasMatriculadas();
        //Filtro
        Task<List<Turma>> filtro(string valorPesquisa);

    }
}
