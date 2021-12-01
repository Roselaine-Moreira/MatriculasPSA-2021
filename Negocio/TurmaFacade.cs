using Entidades.Interface;
using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Negocio
{
   public class TurmaFacade
    {
        private readonly ITurmaDAO _turmaDao;
        private readonly IHistoricoDAO _historicoDao;
        private readonly IMatriculaDAO _matriculaDao;



        public TurmaFacade(ITurmaDAO turmaDAO, IHistoricoDAO historicoDao, IMatriculaDAO matriculaDao)
        {
            _turmaDao = turmaDAO;
            _historicoDao = historicoDao;
            _matriculaDao = matriculaDao;
        }
        //TURMAS
        //Exibe todas as turmas 
        public Task<List<Turma>> todasTurmas()
        {
            return  _turmaDao.todasTurmas();
        }
         

        //Filtro
        public async Task<List<Turma>> filtro(string valorPesquisa)
        {
            return await _turmaDao.filtro(valorPesquisa);
        }


        //Exibe as turmas disponiveis 
        public Task<List<Turma>> turmasDisponiveis()
        {
            return _turmaDao.turmasDisponiveis();
        }


        //Efetua a Matricula
        public Boolean addMatricula(Matricula matricula, Turma turma)
        {
            return _matriculaDao.addMatricula(matricula, turma);
        }


        //Muda o status da turma para Matriculado
        public void updateStatus(Turma turma, int idTurma)
        {
            _turmaDao.updateStatus(turma, idTurma);
        }


        //Muda o status da turma para Cancelado
        public void updateStatusCancelado(Turma turma, int idTurma)
        {
            _turmaDao.updateStatusCancelado(turma, idTurma);
        }


        //Pega o id da turma
        public async Task<Turma> getById(int id)
        {
            return await _turmaDao.getById(id);
        }
        
        //MATRÍCULA--TURMA
        //Pega turmas matriculadas pra gerar o comprovante de matricula
        public async Task<List<Turma>> getByIdTurmasMatriculadas()
        {
            return await _turmaDao.getByIdTurmasMatriculadas();
        }

      
        //Exibe todas as turmas matriculadas
        public Task<List<Turma>> turmasMatriculadas()
        {
            return _turmaDao.turmasMatriculadas();
        }

        //HISTORICO
        //Exibe todas as turmas disponiveis
        public Task<List<Historico>> todosHistoricos()
        {
            return _historicoDao.todosHistoricos();
        }
    }
}
