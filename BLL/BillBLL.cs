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
        public List<Bill> GetListBillWithStatusAndCustomerId(string customerId, string status = null)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                if (status == null)
                {
                    var lstBill = context.Bills.Where(p => p.CustomerId == customerId).ToList();
                    return lstBill;
                }
                var bills = context.Bills.Where(p => p.CustomerId == customerId && p.Status == status).ToList();
                return bills;
            }
        }
        public Bill GetBillByBillId(string BillId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return null;
                var bill = context.Bills.FirstOrDefault(p => p.BillId == BillId);
                if (bill == null) return null;
                return bill;
            }
        }
        public List<Bill> GetListBillWithStatusAndStartEnd(int start, int end, string status = null)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return null;
                if (status == null)
                {
                    var lstBill = context.Bills.OrderByDescending(p => p.Date).Skip(start).Take(end).ToList();
                    return lstBill;
                }
                var bills = context.Bills.Where(p => p.Status == status).OrderByDescending(p => p.Date).Skip(start).Take(end).ToList();
                return bills;
            }
        }
        public List<Bill> GetListBillWithStatusCustomerIdAndStartEnd(string customerId, int start, int end, string status = null)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return null;
                if (status == null)
                {
                    var lstBill = context.Bills.Where(p => p.CustomerId == customerId).OrderByDescending(p => p.Date).Skip(start).Take(end).ToList();
                    return lstBill;
                }
                var bills = context.Bills.Where(p => p.CustomerId == customerId && p.Status == status).OrderByDescending(p => p.BillId).Skip(start).Take(end).ToList();
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
                    p.Quantity,
                    p.Price
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
                    productIdNameQuantity.SellingPrice = product.Price ?? 0;
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
                var listDiscount = context.BillDiscounts.Where(p => p.BillId == billId).ToList();
                if (listDiscount == null) return null;
                var discountList = new List<KeyValuePair<string, float?>>();
                foreach (var discount in listDiscount)
                {
                    KeyValuePair<string, float?> discountKVP;
                    var discountTemp = context.Discounts.FirstOrDefault(p => p.DiscountId == discount.DiscountId);
                    discountKVP = new KeyValuePair<string, float?>(discountTemp.DiscountName, discount.DiscountPercent);
                    discountList.Add(discountKVP);
                }
                return discountList;
            }
        }
        public void SetStatusChoXacNhanToXacNhan(string billId, string employeeId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                var bill = context.Bills.FirstOrDefault(p => p.BillId == billId);
                if (bill == null) return;
                bill.Status = "Chấp Nhận";
                bill.EmployeeId = employeeId;
                context.SaveChanges();
            }
        }
        public void SetStatusChoXacNhanToTuChoi(string billId, string employeeId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                var bill = context.Bills.FirstOrDefault(p => p.BillId == billId);
                if (bill == null) return;
                bill.Status = "Từ Chối";
                bill.EmployeeId = employeeId;
                context.SaveChanges();
            }
        }
        public void UpdateQuantityProduct(string billId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                var listBillProduct = context.BillProducts.Where(p => p.BillId == billId).ToList();
                foreach (var billProduct in listBillProduct)
                {
                    var product = context.Products.FirstOrDefault(c => c.ProductId == billProduct.ProductId);
                    if (product == null) continue;
                    product.Stock -= billProduct.Quantity;
                }
                context.SaveChanges();
            }
        }
        public void AddBilllWithStatusChoXacNhan(Bill bill)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                context.Bills.AddOrUpdate(bill);
                context.SaveChanges();
            }
        }
        
        
        public string GetRandomBillId()
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                Random random = new Random();
                string billId = "hd" + random.Next(0, 1000).ToString().PadLeft(4, '0');
                while (context.Bills.Any(p => p.BillId == billId))
                {
                    billId = "hd" + random.Next(0, 1000).ToString().PadLeft(4, '0');
                }
                return billId;
            }
        }
        
        public bool CheckExistBillId(string BillId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return false;
                return context.Bills.Any(p => p.BillId == BillId);
            }
        }
        public void AddListProductToBill(List<BillProduct> listBillProduct)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                if (listBillProduct == null) return;
                foreach (BillProduct product in listBillProduct)
                {
                    context.BillProducts.AddOrUpdate(product);
                }
                context.SaveChanges();
            }
        }
        public void AddListDiscountToBill(List<BillDiscount> listBillDiscount)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                if (listBillDiscount == null) return;
                foreach(BillDiscount discount in listBillDiscount)
                {
                    context.BillDiscounts.AddOrUpdate(discount);
                }
                context.SaveChanges();
            }
        }
        public void AddNewBill(Bill bill)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                context.Bills.AddOrUpdate(bill);
                context.SaveChanges();
            }
        }
        
        //Kiểm tra xem khách hàng có tồn tại trong listbill không
        public bool CheckCustomerId(string customerId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return false;
                return context.Bills.Any(p => p.CustomerId == customerId);
            }
        }

        public bool CheckEmployeeId(string employeeId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return false;
                return context.Bills.Any(p => p.EmployeeId == employeeId);
            }
        }

        public bool CheckBillWithStatus(string billId, string status)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return false;
                var bill = context.Bills.Any(p =>  p.BillId == billId && p.Status == status);
                return bill;
            }
        }
    }
}
