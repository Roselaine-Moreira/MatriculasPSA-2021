using Entidades.Models;
using Persistencia.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistencia.Data
{
    public class DbInicializador
    {
        private MatriculasPSA2021Context _context;

        public DbInicializador(MatriculasPSA2021Context context)
        {
            _context = context;
        }

        public void PopulaDb()
        {
            //verifica se já existe algum dado na tabela
            if ((_context.Aluno.Any())
                || (_context.Disciplinas.Any())
                || (_context.Turmas.Any()))
            {
                return; //DB já populado
            }
            else
            {

                //Aluno
                var alunos = new Aluno[]
         {
                new Aluno {
                   NomeAluno = "Roselaine", Curso= "SI", MaticulaFaculdade="123456"}
         };

                foreach (Aluno a in alunos)
                {
                    _context.Aluno.Add(a);
                }
                _context.SaveChanges();




                // Disciplina
                var disciplinas = new Disciplina[]
              {
                new Disciplina { NomeDisciplina="Programação de Software Aplicada", CodCred="4644E"},
                new Disciplina { NomeDisciplina="Fundamentos de Programação", CodCred="4646F" },
                new Disciplina { NomeDisciplina="Legislação", CodCred="4545F"},
                new Disciplina { NomeDisciplina="Infra de TI", CodCred="3346B"},
                new Disciplina { NomeDisciplina="Qualidade de Processo", CodCred="2425H" },
                new Disciplina { NomeDisciplina="Qualidade de Produto", CodCred="4636M" },
                new Disciplina { NomeDisciplina="Ética", CodCred="2278L"},
                new Disciplina { NomeDisciplina="Matemática Discreta", CodCred="2379F" },
                new Disciplina { NomeDisciplina="Lógica de Programação", CodCred="4848E"},
                new Disciplina { NomeDisciplina="Métodos Estatísticos", CodCred="3536F" },
                new Disciplina { NomeDisciplina="Fundamentos de Engenharia de Software", CodCred="4245L"},
                new Disciplina { NomeDisciplina="Comportamento Organizacional", CodCred="2040H" },
                new Disciplina { NomeDisciplina="Sistemas Distribuídos", CodCred="4243E"}
              };

                foreach (Disciplina d in disciplinas)
                {
                    _context.Disciplinas.Add(d);
                }
                _context.SaveChanges();


                var historicos = new Historico[]
              {
                      new Historico {Nota=8.9, AnoSemetre="2021/1", AlunoId = 1, DisciplinaId = 2  },
                      new Historico {Nota=9.0, AnoSemetre="2021/1", AlunoId = 1, DisciplinaId = 13  },
                      new Historico {Nota=7.5, AnoSemetre="2020/2", AlunoId = 1, DisciplinaId = 10  },
                      new Historico {Nota=10, AnoSemetre="2020/2", AlunoId = 1, DisciplinaId = 4  },
                      new Historico {Nota=8, AnoSemetre="2020/1", AlunoId = 1, DisciplinaId = 3  },
                      new Historico {Nota=9.7, AnoSemetre="2020/1", AlunoId = 1, DisciplinaId = 1  },
                      new Historico {Nota=9.4, AnoSemetre="2019/2", AlunoId = 1, DisciplinaId = 9  },
                      new Historico {Nota=7, AnoSemetre="2019/2", AlunoId = 1, DisciplinaId = 6  },
                      new Historico {Nota=7.9, AnoSemetre="2019/1", AlunoId = 1, DisciplinaId = 12  },
                      new Historico {Nota=10, AnoSemetre="2019/1", AlunoId = 1, DisciplinaId = 5  },
                      new Historico {Nota=9.8, AnoSemetre="2018/2", AlunoId = 1, DisciplinaId = 11  },
                      new Historico {Nota=7.8, AnoSemetre="2018/2", AlunoId = 1, DisciplinaId = 7  },
                      new Historico {Nota=9.9, AnoSemetre="2018/1", AlunoId = 1, DisciplinaId = 8  }

              };

                foreach (Historico h in historicos)
                {
                    _context.Historico.Add(h);
                }
                _context.SaveChanges();



                // Turma
                var turmas = new Turma[]
              {
                new Turma { NomeTurma="Turma-164", Horario="JK",NumeroDeVaga=1, DisciplinaId= 1 },
                new Turma { NomeTurma="Turma-164", Horario="JK",NumeroDeVaga=2, DisciplinaId= 13 },
                new Turma { NomeTurma="Turma-164", Horario="JK",NumeroDeVaga=3, DisciplinaId= 5 },
                new Turma { NomeTurma="Turma-164", Horario="JK",NumeroDeVaga=0, DisciplinaId= 8 },
                new Turma { NomeTurma="Turma-164", Horario="JK",NumeroDeVaga=0, DisciplinaId= 10 },
                new Turma { NomeTurma="Turma-127", Horario="LM",NumeroDeVaga=4, DisciplinaId= 2 },
                new Turma { NomeTurma="Turma-127", Horario="LM",NumeroDeVaga=1, DisciplinaId= 9 },
                new Turma { NomeTurma="Turma-127", Horario="LM",NumeroDeVaga=10, DisciplinaId= 4 },
                new Turma { NomeTurma="Turma-127", Horario="LM",NumeroDeVaga=1, DisciplinaId= 7 },
                new Turma { NomeTurma="Turma-155", Horario="NP",NumeroDeVaga=2, DisciplinaId= 12 },
                new Turma { NomeTurma="Turma-155", Horario="NP",NumeroDeVaga=8, DisciplinaId= 3 },
                new Turma { NomeTurma="Turma-155", Horario="NP",NumeroDeVaga=3, DisciplinaId= 11 },
                new Turma { NomeTurma="Turma-155", Horario="NP",NumeroDeVaga=1, DisciplinaId= 6 },
              };

                foreach (Turma t in turmas)
                {
                    _context.Turmas.Add(t);
                }
                _context.SaveChanges();



                // Matrícula
                var matriculas = new Matricula[]
              {
                  new Matricula {AlunoId=1, TurmaId= 1 },
                  new Matricula {AlunoId=1, TurmaId= 2 },
                  new Matricula {AlunoId=1, TurmaId= 3 },

              };

                foreach (Matricula h in matriculas)
                {
                    _context.Add(h);
                }
                _context.SaveChanges();

            }


        }
    }
}
