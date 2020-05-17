using Employer_Project.Models;
using Employer_Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Universidade;

namespace Employer_Project.Repository
{
    public class NotaRepository
    {
        public bool SalvaNotaMateriaAluno(NotasAlunoModel notasAluno)
        {
            var optionMenu = new OptionMenuService();

            try
            {
                using (var context = new UniversidadeContext())
                {
                    var alunoNotaDB = context.NotasAlunos
                                        .Where(w => w.AlunoID == notasAluno.AlunoID &&
                                                w.MateriaID == notasAluno.MateriaID)
                                        .SingleOrDefault();


                    if (alunoNotaDB != null)
                    {
                        return false;
                    }
                    else
                    {
                        context.Add(notasAluno);
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

        public bool DeletaNotaMateriaAluno(NotasAlunoModel notasAluno)
        {
            var optionMenu = new OptionMenuService();

            try
            {
                using (var context = new UniversidadeContext())
                {
                    var alunoNotaDB = context.NotasAlunos
                                        .Where(w => w.AlunoID == notasAluno.AlunoID &&
                                                w.MateriaID == notasAluno.MateriaID)
                                        .SingleOrDefault();


                    if (alunoNotaDB != null)
                    {
                        context.Remove(alunoNotaDB);
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

        public bool VizualizaNotaAluno(int AlunoID)
        {
            var optionMenu = new OptionMenuService();

            try
            {
                using (var context = new UniversidadeContext())
                {
                    var alunoNotasDB = context.NotasAlunos
                                        .Where(w => w.AlunoID == AlunoID)
                                        .ToList();

                    if (alunoNotasDB != null)
                    {
                        foreach (var item in alunoNotasDB)
                        {
                            string materiaNome = context.Materias
                                    .Where(w => w.MateriaID == item.MateriaID)
                                    .Select(s => s.MateriaDesc)
                                    .SingleOrDefault();

                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine(materiaNome.ToUpper() + ": " + item.notaMateria);
                            Console.WriteLine("------------------------------------------");

                        }
                        optionMenu.MenuEscolha();
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
    }
}
