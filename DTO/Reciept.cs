using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("Reciept")]
    public class Reciept
    {
        [Key]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string RecieptId { get; set; }

        public Nullable<float> TotalBill { get; set; }

        public Nullable<DateTime> Date { get; set; }

        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [StringLength(50)]
        public string Manufacturer { get; set; }

        public Nullable<float> Discount { get; set; }

        //public Nullable<float> Quantity { get; set; }

        //public Nullable<float> CostPrice { get; set; }

        public virtual ICollection<RecieptProduct> Products { get; set; }

        //[StringLength(50)]
        //public string ProductName { get; set; }
    }
}
