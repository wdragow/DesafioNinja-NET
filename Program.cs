using Employer_Project.Services;

namespace ProgramEmployer
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new MenuService();
            menu.Menu();
        }
    }
}