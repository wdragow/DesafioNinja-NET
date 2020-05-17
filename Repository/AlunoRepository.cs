using Employer_Project.Models;
using Employer_Project.Services;
using System;
using System.Linq;
using Universidade;

namespace Employer_Project.Repository
{
    public class AlunoRepository
    {
        public bool CreateAluno(AlunoModel aluno)
        {

            var menu = new MenuService();
            var optionMenu = new OptionMenuService();

            try
            {
                using (var context = new UniversidadeContext())
                {
                    var alunoDB = context.Alunos.Where(w => w.AlunoCPF == aluno.AlunoCPF).SingleOrDefault();

                    if (alunoDB != null)
                    {
                        return false;
                    }
                    else
                    {
                        context.Add(aluno);
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteAluno(AlunoModel aluno)
        {
            var menu = new MenuService();
            var optionMenu = new OptionMenuService();

            try
            {
                using (var context = new UniversidadeContext())
                {
                    var alunoDB = context.Alunos.Where(w => w.AlunoCPF == aluno.AlunoCPF).SingleOrDefault();

                    if (alunoDB != null)
                    {
                        context.Remove(alunoDB);
                        context.SaveChanges();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool VerificaCPFAluno(string cpfAluno, out int? idAluno)
        {
            try
            {
                using (var context = new UniversidadeContext())
                {
                    var alunoDB = context.Alunos
                        .Where(w => w.AlunoCPF ==
                        Convert.ToInt64(cpfAluno)).SingleOrDefault();

                    if (alunoDB != null)
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Aluno: " + alunoDB.AlunoNome + " " + alunoDB.AlunoSobrenome);
                        Console.WriteLine("------------------------------------------");

                        idAluno = alunoDB.AlunoID;

                        return true;
                    }
                    else
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("|          Aluno não cadastrado!         |");
                        Console.WriteLine("------------------------------------------");
                        Console.Write("Aluno CPF: ");

                        idAluno = null;

                        return false;
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
