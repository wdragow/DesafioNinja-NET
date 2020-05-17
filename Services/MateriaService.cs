using System;
using System.Linq;
using Employer_Project.Models;
using Employer_Project.Repository;
using Universidade;

namespace Employer_Project.Services
{
    public class MateriaService
    {
        public void CreateMateria()
        {
            var menu = new MenuService();
            var optionMenu = new OptionMenuService();

            var materia = new MateriaModel();

            var materiaRepository = new MateriaRepository();

            string descMateria;
            string dataCadastro;
            string situacaoMateria;

            bool valid = false;

            Console.Clear();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(" Universidade Ecológica do Sítio do Caqui ");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("|            Cadastrar Matéria           |");
            Console.WriteLine("------------------------------------------");

            Console.Write("Descrição: ");
            while (!valid)
            {
                descMateria = Console.ReadLine();

                var nomeMateria = descMateria.Split(' ');

                if (string.IsNullOrEmpty(descMateria))
                    valid = false;

                for (var i = 0; i < nomeMateria.Length; i++)
                {
                    bool verifica = nomeMateria[i].All(char.IsLetter);

                    if (verifica)
                    {
                        valid = true;
                        continue;
                    }
                    else
                        valid = false;

                }

                if (!valid)
                {
                    optionMenu.OperationError();
                    Console.Write("Descrição: ");
                }
                else
                {
                    materia.MateriaDesc = descMateria;
                    continue;
                }
            }


            valid = false;
            Console.Write("Data cadastro (dd/mm/aaaa): ");
            while (!valid)
            {
                dataCadastro = Console.ReadLine();

                try
                {
                    string data = dataCadastro;

                    int maiorAnoPermitido = DateTime.Now.Year;
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
                    materia.MateriaDataCad = Convert.ToDateTime(dataCadastro);
                    continue;
                }
            }

            valid = false;
            Console.Write("Situação (A - Ativo | I - Inativo): ");
            while (!valid)
            {
                situacaoMateria = Console.ReadLine();
                valid = !string.IsNullOrWhiteSpace(situacaoMateria) &&
                    situacaoMateria.All(char.IsLetter);

                if (situacaoMateria.ToUpper().Equals("A")
                        || situacaoMateria.ToUpper().Equals("I"))
                {
                    valid = true;
                }
                else
                {
                    valid = false;
                }


                if (!valid)
                {
                    optionMenu.OperationError();
                    Console.Write("Situação (A - Ativo | I - Inativo): ");
                }
                else
                {
                    materia.materiaSitacao = situacaoMateria.ToUpper();
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
                        var cadastado = materiaRepository.CreateMateria(materia);

                        if (!cadastado)
                        {
                            Console.Clear();
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("|    Já existe essa matéria cadastrada   |");
                        }
                        else
                        {
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("|           Matéria cadastrada!          |");
                        }
                        optionMenu.MenuEscolha();
                        break;

                    case "3":
                        var deletado = materiaRepository.CreateMateria(materia);

                        if (!deletado)
                        {
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("|   Não existe essa matéria cadastrada!  |");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("|            Matéria deletada!           |");
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