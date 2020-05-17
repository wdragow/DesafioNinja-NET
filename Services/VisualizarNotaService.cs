using System;
using System.Linq;
using Employer_Project.Models;
using Universidade;
using Validation;
using System.Collections.Generic;
using Employer_Project.Repository;

namespace Employer_Project.Services
{
    public class VisualizarNotaService
    {
        public void VisualizarNotas()
        {
            var menu = new MenuService();
            var optionMenu = new OptionMenuService();

            var alunoRepository = new AlunoRepository();
            var notaRepository = new NotaRepository();

            int AlunoID = 0;

            string cpfAluno;

            bool valid = false;

            Console.Clear();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(" Universidade Ecológica do Sítio do Caqui ");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("|       Vizualizar Notas Do Aluno        |");
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
                        AlunoID = Convert.ToInt32(idAluno);
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                    }
                }
            }

            optionMenu.SairViualizar();
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
                        notaRepository.VizualizaNotaAluno(AlunoID);
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