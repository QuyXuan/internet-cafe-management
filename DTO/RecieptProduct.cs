using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("RecieptProduct")]
    public class RecieptProduct
    {
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string ProductId { get; set; }
        public virtual Product Product { get; set; }

        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string RecieptId { get; set; }
        public virtual Reciept Reciept { get; set; }

        public Nullable<float> Quantity { get; set; }
    }
}
