using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DiscountBLL
    {
        private static DiscountBLL instance;
        public static DiscountBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DiscountBLL();
                }
                return instance;
            }
            private set { instance = value; }
        }
        private DiscountBLL() { }
        public List<Discount> GetListDiscountWithType(bool TypeCustomer)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                var discounts = context.Discounts.Where(p => p.TypeCustomer == TypeCustomer).ToList();
                return discounts;
            }
        }
        public List<Discount> GetListDiscount()
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return null;
                var discounts = context.Discounts.ToList();
                return discounts;
            }
        }
    }
}
