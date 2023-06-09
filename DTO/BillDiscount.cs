using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("BillDiscount")]
    public class BillDiscount
    {
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string DiscountId { get; set; }
        public virtual Discount Discount { get; set; }

        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string BillId { get; set; }
        public virtual Bill Bill { get; set; }

        public Nullable<float> DiscountPercent { get; set; }
    }
}
