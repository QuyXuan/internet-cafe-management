using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Security.Principal;

namespace DTO
{
    [Table("ComputerManvenue")]
    public class ComputerManvenue
    {
        [Key]
        [Column(Order = 1, TypeName = "varchar")]
        public string AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "varchar")]
        public string ComputerId { get; set; }
        [ForeignKey("ComputerId")]
        public virtual Computer Computer { get; set; }

        public Nullable<bool> IsEmployeeUsing { get; set; }

        public Nullable<float> Prepay { get; set; }

        public Nullable<DateTime> StartTime { get; set; }

        public Nullable<DateTime> EndTime { get; set; }

        public Nullable<float> Total { get; set; }
    }
}
