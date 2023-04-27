using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("BillDay")]
    public class BillDay
    {
        [Key]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string BillDayId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public float TotalBill { get; set; }

        [Required]
        public bool Type { get; set; }
    }
}
