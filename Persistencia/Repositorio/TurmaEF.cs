using Entidades.Interface;
using Entidades.Models;
using Entidades.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistencia.Repositorio
{
    public class TurmaEF : ITurmaDAO
    {
        private readonly MatriculasPSA2021Context _context;

        //construtor entity framework        
        public TurmaEF(MatriculasPSA2021Context context)
        {
            _context = context;
        }

        //Exibe todas as turmas
        public async Task<List<Turma>> todasTurmas()
        {
            return await _context.Turmas.Include(t => t.Disciplina).ToListAsync();

        }

        //Filtro
        public async Task<List<Turma>> filtro(string valorPesquisa)
        {
            return await _context.Turmas
                .Where(t => t.NomeTurma.Contains(valorPesquisa)
                || t.Horario.Contains(valorPesquisa)
                 || t.Disciplina.CodCred.Contains(valorPesquisa))
                .ToListAsync();
        }

        //Exibe todas as turmas disponiveis 
        public async Task<List<Turma>> turmasDisponiveis()
        {

            return await _context.Turmas
                   .Include(t => t.Disciplina)
                   .Where(p => p.Status == StatusMatricula.Disponivel)
                   .ToListAsync();
        }

        //Pega o id da turma
        public async Task<Turma> getById(int id)
        {
            return await _context.Turmas.FindAsync(id);
        }

        //Pega as turmas matriculadas para gerar o comprovante
        public async Task<List<Turma>> getByIdTurmasMatriculadas()
        {
            return await _context.Turmas
                 .Where(p => p.Status == StatusMatricula.Matriculado)
                 .ToListAsync();
        }


        //Muda o status da turma para Matriculado
        public void updateStatus(Turma turma , int idTurma)
        {

            var consulta1 = _context.Turmas
                            .Where(p => p.TurmaId == idTurma)
                            .Where(p => p.Status == StatusMatricula.Disponivel)
                            .Where(p => p.NumeroDeVaga >= 1)
                            .Select(p => p);

            foreach (Turma p in consulta1)
            {
                p.Status = StatusMatricula.Matriculado;
                p.NumeroDeVaga = p.NumeroDeVaga - 1;
                _context.Update(p);
            }
            _context.SaveChanges();

        }


        //Muda o status para cancelado
        public void updateStatusCancelado(Turma turma, int idTurma)
        {

            var consulta1 = _context.Turmas
                            .Where(p => p.TurmaId == idTurma)
                            .Where(p => p.Status == StatusMatricula.Matriculado)
                            .Select(p => p);

            foreach (Turma p in consulta1)
            {
                p.Status = StatusMatricula.Disponivel;
                p.NumeroDeVaga = p.NumeroDeVaga + 1;
                _context.Update(p);
            }
            _context.SaveChanges();

        }


        //Exibe todas as turmas matriculadas
        public async Task<List<Turma>> turmasMatriculadas()
        {

            return await _context.Turmas
                  .Include(t => t.Disciplina)
                  .Where(p => p.Status == StatusMatricula.Matriculado)
                  .ToListAsync();
        }

    }
}
