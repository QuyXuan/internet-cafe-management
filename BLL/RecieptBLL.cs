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
    public class RecieptBLL
    {
        private static RecieptBLL instance;
        public static RecieptBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RecieptBLL();
                }
                return instance;
            }
            private set { instance = value; }
        }
        private RecieptBLL() { }
        public List<Reciept> GetListReciept()
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                var reciepts = context.Reciepts.ToList();
                if (reciepts == null)
                {
                    return null;
                }
                return reciepts;
            }
        }
        public List<KeyValuePair<Product, float?>> GetListProductByRecieptId(string recieptId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                var listProduct = context.RecieptProducts.Where(p => p.RecieptId == recieptId).Select(p => new
                {
                    p.ProductId,
                    p.Quantity
                }).ToList();
                if (listProduct == null) return null;
                var productList = new List<KeyValuePair<Product, float?>>();
                foreach (var product in listProduct)
                {
                    KeyValuePair<Product, float?> productKVP;
                    var productTemp = context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
                    productKVP = new KeyValuePair<Product, float?>(productTemp, product.Quantity);
                    productList.Add(productKVP);
                }
                return productList;
            }
        }
        public string GetRandomRecieptId()
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                Random random = new Random();
                string recieptId = "hdn" + random.Next(0, 1000).ToString().PadLeft(4, '0');
                while (context.Reciepts.Any(p => p.RecieptId == recieptId))
                {
                    recieptId = "hdn" + random.Next(0, 1000).ToString().PadLeft(4, '0');
                }
                return recieptId;
            }
        }
        public void AddNewReciept(Reciept reciept)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                context.Reciepts.AddOrUpdate(reciept);
                context.SaveChanges();
            }
        }
        public void AddRecieptProduct(RecieptProduct recieptProduct)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                context.RecieptProducts.AddOrUpdate(recieptProduct);
                context.SaveChanges();
            }
        }
        public bool CheckEmployeeId(string employeeId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return false;
                return context.Reciepts.Any(p => p.EmployeeId == employeeId);
            }
        }
    }
}
