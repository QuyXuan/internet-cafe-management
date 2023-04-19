using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("Discount")]
    public class Discount
    {
        [Key]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string DiscountId { get; set; }

        [Required]
        [StringLength(50)]
        public string DiscountName { get; set; }

        public Nullable<float> DiscountPercent { get; set; }

        [Required]
        public bool TypeCustomer { get; set; }

        public virtual ICollection<BillDiscount> Bills { get; set; }
    }
}
