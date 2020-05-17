using System;
using System.Linq;
using Employer_Project.Repository;
using Employer_Project.Models;
using Validation;

namespace Employer_Project.Services
{
    public class AlunoService
    {
        public void CreateAluno()
        {
            var menu = new MenuService();
            var optionMenu = new OptionMenuService();

            var alunoRepository = new AlunoRepository();

            var aluno = new AlunoModel();

            string nomeAluno;
            string sobnomeAluno;
            string cpfAluno;
            string dataNascAluno;
            string cursoAluno;
            bool valid = false;

            DateTime todayDate = DateTime.Today;

            Console.Clear();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(" Universidade Ecológica do Sítio do Caqui ");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("|            Cadastrar Aluno             |");
            Console.WriteLine("------------------------------------------");

            Console.Write("Primeiro nome: ");
            while (!valid)
            {
                nomeAluno = Console.ReadLine();
                valid = !string.IsNullOrWhiteSpace(nomeAluno) &&
                    nomeAluno.All(char.IsLetter);

                if (!valid)
                {
                    optionMenu.OperationError();
                    Console.Write("Primeiro nome: ");
                }
                else
                {
                    aluno.AlunoNome = nomeAluno.ToUpper();
                    continue;
                }
            }

            valid = false;
            Console.Write("Sobrenome: ");
            while (!valid)
            {
                sobnomeAluno = Console.ReadLine();

                if (string.IsNullOrEmpty(sobnomeAluno))
                    valid = false;
                else
                    valid = true;

                if (!valid)
                {
                    optionMenu.OperationError();
                    Console.Write("Sobrenome: ");
                }
                else
                {
                    aluno.AlunoSobrenome = sobnomeAluno.ToUpper();
                    continue;
                }
            }

            valid = false;
            Console.Write("Data nascimento (dd/mm/aaaa): ");
            while (!valid)
            {
                dataNascAluno = Console.ReadLine();

                try
                {
                    string data = dataNascAluno;

                    int maiorAnoPermitido = 2002;
                    int menorAnoPermitido = 1800;

                    string[] val = data.Split('/');

                    int dia, mes, ano;

                    if (int.TryParse(val[0], out dia) && int.TryParse(val[1], out mes) && int.TryParse(val[2], out ano))
                    {
                        if (ano >= menorAnoPermitido && ano <= maiorAnoPermitido)
                        {
                            if (mes >= 1 && mes <= 12)
                            {

                                int maxDia = (mes == 2 ? (ano % 4 == 0 ? 29 : 28) : mes <= 7 ? (mes % 2 == 0 ? 30 : 31) : (mes % 2 == 0 ? 31 : 30));

                                if (dia >= 1 && dia <= maxDia)
                                {
                                    valid = true;
                                }
                                else
                                {
                                    Console.WriteLine("------------------------------------------");
                                    Console.WriteLine("|            Dia inválido!               |");
                                    Console.WriteLine("------------------------------------------");
                                    valid = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("------------------------------------------");
                                Console.WriteLine("|            Mês inválido!               |");
                                Console.WriteLine("------------------------------------------");
                                valid = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("|            Ano inválido!               |");
                            Console.WriteLine("------------------------------------------");
                            valid = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("|            Data inválida!              |");
                        Console.WriteLine("------------------------------------------");
                        valid = false;
                    }
                }
                catch
                {
                    valid = false;
                }

                if (!valid)
                {
                    optionMenu.OperationError();
                    Console.Write("Data nascimento (dd/mm/aaaa): ");
                }
                else
                {
                    aluno.AlunoNascimento = Convert.ToDateTime(dataNascAluno);
                    continue;
                }
            }

            valid = false;
            Console.Write("CPF: ");
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
                    Console.Write("CPF: ");
                }
                else
                {
                    aluno.AlunoCPF = Convert.ToInt64(cpfAluno);
                    continue;
                }
            }

            valid = false;
            Console.Write("Curso: ");
            while (!valid)
            {
                cursoAluno = Console.ReadLine();

                if (string.IsNullOrEmpty(cursoAluno))
                    valid = false;
                else
                    valid = true;

                if (!valid)
                {
                    optionMenu.OperationError();
                    Console.Write("Curso: ");
                }
                else
                {
                    aluno.AlunoCurso = cursoAluno.ToUpper();
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
                        var cadastrado = alunoRepository.CreateAluno(aluno);

                        if (!cadastrado)
                        {
                            Console.Clear();
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("|      Já existe esse CPF cadastrado     |");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("|            Aluno cadastrado!           |");
                        }

                        optionMenu.MenuEscolha();
                        break;

                    case "3":
                        var deletado = alunoRepository.DeleteAluno(aluno);

                        if (!deletado) 
                        {
                            Console.Clear();
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("|     Não existe aluno com esse CPF!     |");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("|             Aluno deletado!            |");
                        }
                        optionMenu.MenuEscolha();
                        break;

                    default:
                        break;

                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}