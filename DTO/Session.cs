using DTO;
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
    [Table("Session")]
    public class Session
    {
        [Key]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string SessionId { get; set; }
        public Nullable<DateTime> StartTime { get; set; }

        public Nullable<DateTime> EndTime { get; set; }

        public Nullable<float> TotalTime { get; set; }

        [StringLength(10)]
        [Column(TypeName = "varchar")]
        [Required]
        public string AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        [StringLength(10)]
        [Column(TypeName = "varchar")]
        [Required]
        public string ComputerId { get; set; }
        [ForeignKey("ComputerId")]
        public virtual Computer Computer { get; set; }
    }
}
