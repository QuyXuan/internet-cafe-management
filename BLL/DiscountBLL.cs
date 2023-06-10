using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
                var discounts = context.Discounts.Where(p => p.TypeCustomer == TypeCustomer && p.DiscountPercent > 0).ToList();
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
        public Discount GetDiscountByDiscountId(string discountId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return null;
                var discount = context.Discounts.FirstOrDefault(p => p.DiscountId == discountId);
                return discount;
            }
        }
        public string GetRandomDiscountId()
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                Random random = new Random();
                string discountId = "gg" + random.Next(0, 1000).ToString().PadLeft(4, '0');
                while (context.Discounts.Any(p => p.DiscountId == discountId))
                {
                    discountId = "gg" + random.Next(0, 1000).ToString().PadLeft(4, '0');
                }
                return discountId;
            }
        }
        public bool CheckDiscountName(string discountName)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return false;
                return context.Discounts.Any(p => p.DiscountName == discountName);
            }
        }
        public void AddNewDiscount(Discount discount)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                context.Discounts.AddOrUpdate(discount);
                context.SaveChanges();
            }
        }
        public void EditDiscount(Discount discount)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                context.Discounts.AddOrUpdate(discount);
                context.SaveChanges();
            }
        }
        public void RemoveDiscount(string discountId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                var discount = context.Discounts.FirstOrDefault(p => p.DiscountId == discountId);
                if (discount == null) return;
                discount.DiscountPercent = 0;
                context.SaveChanges();
            }
        }
    }
}
