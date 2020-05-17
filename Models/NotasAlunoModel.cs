using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employer_Project.Models
{
    [Table("notasAluno")]
    public class NotasAlunoModel
    {
        [Key]
        public int NotaID { get; set; }
        public int AlunoID { get; set; }
        public int MateriaID { get; set; }

        [MaxLength(3)]
        public int notaMateria { get; set; }
    }
}