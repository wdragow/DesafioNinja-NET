using Employer_Project.Models;
using Employer_Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Universidade;

namespace Employer_Project.Repository
{
    public class MateriaRepository
    {
        public bool VerificaMateriaCadastrada(string descMateria, out int? idMateria)
        {
            try
            {
                using (var context = new UniversidadeContext())
                {
                    var materiaDB = context.Materias
                        .Where(w => w.MateriaDesc.ToUpper() ==
                        descMateria.ToUpper()).SingleOrDefault();

                    if (materiaDB != null)
                    {
                        idMateria = materiaDB.MateriaID;

                        return true;
                    }
                    else
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("|         Matéria não cadastrada!        |");
                        Console.WriteLine("------------------------------------------");
                        Console.Write("Matéria: ");

                        idMateria = null;

                        return false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CreateMateria(MateriaModel materia)
        {
            var menu = new MenuService();
            var optionMenu = new OptionMenuService();

            try
            {
                using (var context = new UniversidadeContext())
                {
                    var materiaDB = context.Materias.Where(w => w.MateriaDesc == materia.MateriaDesc).SingleOrDefault();

                    if (materiaDB != null)
                    {
                        return false;
                    }
                    else
                    {
                        context.Add(materia);
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

        public bool DeleteMateria(MateriaModel materia)
        {
            var menu = new MenuService();
            var optionMenu = new OptionMenuService();

            try
            {
                using (var context = new UniversidadeContext())
                {
                    var materiaDB = context.Materias.Where(w => w.MateriaDesc == materia.MateriaDesc).SingleOrDefault();

                    if (materiaDB != null)
                    {
                        context.Remove(materiaDB);
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
    }
}
