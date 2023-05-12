using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("TypeComputer")]
    public class TypeComputer
    {
        [Key]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string TypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string NameType { get; set; }

        public Nullable<float> Price { get; set; }


        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string ColorId { get; set; }

        public virtual ICollection<Computer> Computers { get; set; }
    }
}
