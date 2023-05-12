using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DTO
{
    [Table("Bill")]
    public class Bill
    {
        [Key]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string BillId { get; set; }

        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        public Nullable<float> TotalDiscountPercent { get; set; }

        public Nullable<float> Total { get; set; }

        public Nullable<DateTime> Date { get; set; }

        [Required]
        [StringLength(255)]
        [RegularExpression("^(Chờ Chấp Nhận|Chấp Nhận|Từ Chối)$")]
        public string Status { get; set; }

        public virtual ICollection<BillProduct> Products { get; set; }

        public virtual ICollection<BillDiscount> Discounts { get; set; }

        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string ComputerId { get; set; }
        [ForeignKey("ComputerId")]
        public virtual Computer Computer { get; set; }

        [Column(TypeName = "varchar")]
        public string IPClient { get; set; }

        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}
