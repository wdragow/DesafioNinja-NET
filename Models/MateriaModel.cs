using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employer_Project.Models
{
    [Table("materias")]
    public class MateriaModel
    {
        [Key]
        public int MateriaID { get; set; }
        public string MateriaDesc { get; set; }
        public string materiaSitacao { get; set; }
        public System.DateTime MateriaDataCad { get; set; }
    }
}