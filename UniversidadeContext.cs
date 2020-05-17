using Microsoft.EntityFrameworkCore;
using Employer_Project.Models;

namespace Universidade
{
    public class UniversidadeContext : DbContext
    {
        public DbSet<AlunoModel> Alunos { get; set; }
        public DbSet<MateriaModel> Materias { get; set; }
        public DbSet<NotasAlunoModel> NotasAlunos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Altere aqui as configurações do BD
            optionsBuilder.UseSqlServer(@"Server={Nome do Servidor};Database={Nome do Banco};Trusted_Connection=true;MultipleActiveResultSets=true;User Id={Nome do usuário};Password={Senha};");
        }
    }
}