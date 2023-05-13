using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("Computer")]
    public class Computer
    {
        [Key]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string ComputerId { get; set; }

        [Required]
        [StringLength(50)]
        public string ComputerName { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        public string TypeId { get; set; }
        [ForeignKey("TypeId")]
        public virtual TypeComputer TypeComputer { get; set; }


        //[StringLength(50)]
        //public string NameType { get; set; }
        [Required]
        [StringLength(255)]
        [RegularExpression(@"^(Bảo Trì|Đang Hoạt Động|Đã Tắt|Còn 5 Phút)$")]
        public string Status { get; set; }

        [StringLength(100)]
        [Column(TypeName = "varchar")]
        public string IPComputer { get; set; }

        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string AccountId { get; set; }
    }
}
