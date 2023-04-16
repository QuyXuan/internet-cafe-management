﻿using System;
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

        [Required]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string DiscountId { get; set; }
        [ForeignKey("DiscountId")]
        public virtual Discount Discount { get; set; }

        public Nullable<float> DiscountPercent { get; set; }

        public Nullable<float> Total { get; set; }

        public Nullable<DateTime> Date { get; set; }

        [Required]
        [StringLength(255)]
        [RegularExpression("^(Chờ Chấp Nhận|Chấp Nhận|Từ Chối)$")]
        public string Status { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }


        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        public Nullable<float> Quantity { get; set; }

        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string ComputerId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Computer Computer { get; set; }

        [Column(TypeName = "varchar")]
        public string IPClient { get; set; }

        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string CustomerId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Customer Customer { get; set; }
    }
}
