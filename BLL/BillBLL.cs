using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BillBLL
    {
        private static BillBLL instance;
        public static BillBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillBLL();
                }
                return instance;
            }
            private set { instance = value; }
        }
        private BillBLL() { }
        public List<Bill> GetListBillWithStatus(string status = null)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                if (status == null)
                {
                    var lstBill = context.Bills.ToList();
                    return lstBill;
                }
                var bills = context.Bills.Where(p => p.Status == status).ToList();
                return bills;
            }
        }

        //public string GetNumberComputerByComputerId(string computerId)
        //{
        //    using (var context = new QLNETDBContext())
        //    {
        //        if (context == null)
        //        {
        //            return null;
        //        }
        //        var computer = context.Computers.FirstOrDefault(p => p.ComputerId == computerId);
        //        if (computer == null)
        //        {
        //            return null;
        //        }
        //        return computer.ComputerName;
        //    }
        //}

        public List<ProductIdNameQuantityPrice> GetListProductByBillId(string billId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return null;
                var listProduct = context.BillProducts.Where(p => p.BillId == billId).Select(p => new
                {
                    p.ProductId,
                    p.Quantity
                }).ToList();
                if (listProduct == null) return null;
                var productList = new List<ProductIdNameQuantityPrice>();
                foreach (var product in listProduct)
                {
                    var productTemp = context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
                    ProductIdNameQuantityPrice productIdNameQuantity = new ProductIdNameQuantityPrice();
                    productIdNameQuantity.ProductId = product.ProductId;
                    productIdNameQuantity.ProductName = productTemp.ProductName;
                    productIdNameQuantity.Quantity = product.Quantity ?? 0;
                    productIdNameQuantity.SellingPrice = productTemp.SellingPrice ?? 0;
                    productList.Add(productIdNameQuantity);
                }
                return productList;
            }
        }
        public List<KeyValuePair<string, float?>> GetListDiscountByBillId(string billId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return null;
                var listDiscount = context.BillDiscounts.Where(p => p.BillId == billId).Select(p => new { p.DiscountId }).ToList();
                if (listDiscount == null) return null;
                var discountList = new List<KeyValuePair<string, float?>>();
                foreach (var discount in listDiscount)
                {
                    KeyValuePair<string, float?> discountKVP;
                    var discountTemp = context.Discounts.FirstOrDefault(p => p.DiscountId == discount.DiscountId);
                    discountKVP = new KeyValuePair<string, float?>(discountTemp.DiscountName, discountTemp.DiscountPercent);
                    discountList.Add(discountKVP);
                }
                return discountList;
            }
        }
        //public float GetTotalPriceBy
    }
}
