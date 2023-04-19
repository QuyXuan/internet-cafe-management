using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }

        public Nullable<float> Balance { get; set; }
        public Nullable<float> TotalTime { get; set; }

        [Required]
        public bool TypeCustomer { get; set; }

        [Required]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        //[Required]
        //[StringLength(10)]
        //[Column(TypeName = "varchar")]
        //public string DiscountId { get; set; }
        //[ForeignKey("DiscountId")]
        //public virtual Discount Discount { get; set; }
    }
}
