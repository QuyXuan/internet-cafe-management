using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RecieptBillDayTotalPrice
    {
        public float ProfitPrice { get; set; }
        public float BillPrice { get; set; }
        public float RecieptPrice { get; set; }
        public DateTime Date { get; set; }
    }
}
