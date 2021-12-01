using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Persistencia.Repositorio
{
    //public class MatriculasPSA2021Context : DbContext
    public class MatriculasPSA2021Context : IdentityDbContext<Aluno>

    {
        public MatriculasPSA2021Context() : base()
        {
        }
        public MatriculasPSA2021Context(DbContextOptions<MatriculasPSA2021Context> options)
            : base(options)
        {
        }

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Historico> Historico { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Requisito> Requisitos { get; set; }



        // associar a PK do Identity
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Historico>().ToTable("Historico");
            builder.Entity<Disciplina>().ToTable("Disciplina");
            builder.Entity<Turma>().ToTable("Turma");
            builder.Entity<Requisito>().ToTable("Requisito");
            builder.Entity<Aluno>().ToTable("Aluno").HasKey(t => t.Id);

            base.OnModelCreating(builder);
        }


    }
}