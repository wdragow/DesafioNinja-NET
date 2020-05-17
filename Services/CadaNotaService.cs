using System;
using System.Linq;
using Employer_Project.Models;
using Employer_Project.Repository;
using Universidade;
using Validation;

namespace Employer_Project.Services
{
    public class CadaNotaService
    {
        public void CreateAlunoNota()
        {
            var menu = new MenuService();
            var optionMenu = new OptionMenuService();

            string cpfAluno;
            string descMateria;
            string notaAluno;

            bool valid = false;

            var notasAluno = new NotasAlunoModel();
            var alunoRepository = new AlunoRepository();
            var notaRepository = new NotaRepository();
            var materiaRepository = new MateriaRepository();

            Console.Clear();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(" Universidade Ecológica do Sítio do Caqui ");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("|            Cadastrar Nota              |");
            Console.WriteLine("------------------------------------------");

            Console.Write("Aluno CPF: ");
            while (!valid)
            {
                cpfAluno = Console.ReadLine();

                if (ValidaCPF.IsCpf(cpfAluno))
                    valid = true;
                else
                {
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("|             CPF inválido!              |");
                    Console.WriteLine("------------------------------------------");
                    valid = false;
                }

                if (!valid)
                {
                    optionMenu.OperationError();
                    Console.Write("Aluno CPF: ");
                }
                else
                {
                    if (alunoRepository.VerificaCPFAluno(cpfAluno, out int? idAluno))
                    {
                        notasAluno.AlunoID = Convert.ToInt32(idAluno);
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                    }
                }
            }

            valid = false;
            Console.Write("Matéria: ");
            while (!valid)
            {
                descMateria = Console.ReadLine();

                if (string.IsNullOrEmpty(descMateria))
                    valid = false;
                else
                    valid = true;

                if (!valid)
                {
                    optionMenu.OperationError();
                    Console.Write("Matéria: ");
                }
                else
                {
                    if (materiaRepository.VerificaMateriaCadastrada(descMateria, out int? idMateria))
                    {
                        notasAluno.MateriaID = Convert.ToInt32(idMateria);
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                    }
                }
            }

            valid = false;
            Console.Write("Nota (0 a 100): ");
            while (!valid)
            {
                notaAluno = Console.ReadLine();

                int notaint = 0;

                valid = !string.IsNullOrWhiteSpace(notaAluno);

                if (notaAluno.All(char.IsNumber))
                {
                    try
                    {
                        notaint = Convert.ToInt32(notaAluno);

                        if (notaint >= 0 && notaint <= 100)
                        {
                            Console.WriteLine(notaint);
                            notasAluno.notaMateria = notaint;
                            valid = true;
                            continue;
                        }
                        else
                        {
                            valid = false;
                        }
                    }
                    catch
                    {
                        valid = false;
                    }
                }
                else
                {
                    valid = false;
                }

                if (!valid)
                {
                    optionMenu.OperationError();
                    Console.Write("Nota (0 a 100): ");
                }
                else
                {
                    Console.WriteLine(notaint);
                    notasAluno.notaMateria = notaint;
                    continue;
                }
            }

            optionMenu.SalvaExcluiSair();
            Console.Write("-> ");
            var opcao = Console.ReadLine();

            try
            {
                switch (opcao)
                {
                    case "1":
                        menu.Menu();
                        break;

                    case "2":
                        var cadastrado = notaRepository.SalvaNotaMateriaAluno(notasAluno);

                        if (!cadastrado)
                        {
                            Console.Clear();
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("| Já possui nota cadastrada nessa matéria|");
                        }
                        else
                        {
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("|            Nota cadastrada!            |");
                        }
                        optionMenu.MenuEscolha();
                        break;

                    case "3":
                        var deletado = notaRepository.DeletaNotaMateriaAluno(notasAluno);

                        if (!deletado)
                        {
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("|     Essa nota não está cadastrada!     |");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("|             Nota deletada!             |");
                        }
                        optionMenu.MenuEscolha();
                        break;

                    default:
                        break;

                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}