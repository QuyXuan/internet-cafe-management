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
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string EmployeeId { get; set; }

        [Required]
        [StringLength(50)]
        public string EmployeeName { get; set; }

        public Nullable<float> Salary { get; set; }

        [Required]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        public string OtherInfomation { get; set; }
    }
}
