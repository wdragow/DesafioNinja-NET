using System;
using System.Linq;

namespace Employer_Project.Services
{
    public class MenuService
    {
        public void Menu()
        {
            string opcao;

            Console.Clear();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(" Universidade Ecológica do Sítio do Caqui ");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("|            Sistema Acadêmico           |");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(" Selecione a operação que deseja realizar:");
            Console.WriteLine("");
            Console.WriteLine("1 - Cadastrar aluno.");
            Console.WriteLine("");
            Console.WriteLine("2 - Cadastrar matéria.");
            Console.WriteLine("");
            Console.WriteLine("3 - Cadastrar nota.");
            Console.WriteLine("");
            Console.WriteLine("4 - Visualizar notas do aluno.");
            Console.WriteLine("");
            Console.WriteLine("5 - Sair");
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------");
            Console.Write("->  ");

            var valid = false;

            while (!valid)
            {
                opcao = Console.ReadLine();
                valid = !string.IsNullOrWhiteSpace(opcao) &&
                    opcao.All(c => c >= '1' && c <= '5');

                if (!valid)
                {
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("|   Erro na operação! Tente Novamente!   |");
                    Console.WriteLine("------------------------------------------");
                    Console.Write("->  ");
                }
                else
                {
                    switch (opcao)
                    {
                        case "1":
                            var aluno = new AlunoService();
                            aluno.CreateAluno();
                            break;

                        case "2":
                            var materia = new MateriaService();
                            materia.CreateMateria();
                            break;

                        case "3":
                            var cadNotaAluno = new CadaNotaService();
                            cadNotaAluno.CreateAlunoNota();
                            break;

                        case "4":
                            var visuNotas = new VisualizarNotaService();
                            visuNotas.VisualizarNotas();
                            break;

                        case "5":
                            break;

                        default:
                            break;
                    }
                }
            }
        }
    }
}