using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("Account")]
    public class Account
    {
        [Key]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string AccountId { get; set; }

        [Required]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [RegularExpression("^(Administrator|Khách Hàng|Quản Lý|Nhân Viên)$")]
        public string Role { get; set; }

        [StringLength(10)]
        public string TypeDiscount { get; set; }
    }
}
