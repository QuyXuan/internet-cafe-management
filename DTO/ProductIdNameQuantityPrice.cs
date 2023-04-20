using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductIdNameQuantityPrice
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public float Quantity { get; set; }
        public float SellingPrice { get; set; }
    }
}
