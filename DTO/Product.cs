using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        public Nullable<float> SellingPrice { get; set; }

        public Nullable<float> CostPrice { get; set; }

        [Required]
        [RegularExpression(@"^(Nước Uống|Đồ Ăn|Thẻ)$")]
        public string Type { get; set; }

        public Nullable<float> Stock { get; set; }

        //public Nullable<float> Quantity { get; set; }

        [Required]
        public bool Status { get; set; }

        public string Discription { get; set; }

        [MaxLength]
        public byte[] ProductImage { get; set; }

        //[MaxLength]
        //public string ImageFilePath { get; set; }

        public virtual ICollection<BillProduct> Bills { get; set; }

        public virtual ICollection<RecieptProduct> Reciepts { get; set; }
    }
}
