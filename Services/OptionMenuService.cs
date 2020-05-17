using System;
using System.Linq;

namespace Employer_Project.Services
{
    public class OptionMenuService
    {

        public void MenuEscolha()
        {
            var menu = new MenuService();
            bool valid = false;
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("|     1 - Voltar      |     2 - Sair     |");
            Console.WriteLine("------------------------------------------");
            Console.Write("->  ");

            while (!valid)
            {
                var opcao = Console.ReadLine();
                valid = !string.IsNullOrWhiteSpace(opcao) &&
                    opcao.All(c => c >= '1' && c <= '2');

                if (!valid)
                    OperationError();
                Console.Write("->  ");

                switch (opcao)
                {
                    case "1":
                        menu.Menu();
                        break;
                    case "2":
                        break;

                    default:
                        break;
                }
            }
        }

        public void OperationError()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("|   Erro na operação! Tente Novamente!   |");
            Console.WriteLine("------------------------------------------");
        }

        public void SalvaExcluiSair()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("|  1-Voltar  |  2-Salvar  |  3-Excluir   |");
            Console.WriteLine("------------------------------------------");
        }

        public void SairViualizar()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("|     1-Voltar     |    2-Vizualizar     |");
            Console.WriteLine("------------------------------------------");
        }
    }
}