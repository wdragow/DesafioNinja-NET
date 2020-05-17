using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employer_Project.Models
{
    [Table("alunos")]
    public class AlunoModel
    {
        [Key]
        public int AlunoID { get; set; }
        [MaxLength(11)]
        public long AlunoCPF { get; set; }
        [StringLength(50)]
        public string AlunoNome { get; set; }
        [StringLength(100)]
        public string AlunoSobrenome { get; set; }
        [StringLength(100)]
        public string AlunoCurso { get; set; }
        public System.DateTime AlunoNascimento { get; set; }
    }
}