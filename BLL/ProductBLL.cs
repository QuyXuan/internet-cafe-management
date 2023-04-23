using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class ProductBLL
    {
        private static ProductBLL instance;
        public static ProductBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductBLL();
                }
                return instance;
            }
            private set { instance = value; }
        }
        private ProductBLL() { }
        public List<Product> GetListProduct()
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    // Xử lý lỗi, ví dụ throw Exception, trả về giá trị mặc định, ...
                    return null;
                }

                var products = context.Products.ToList();
                return products;
            }
        }
        public List<string> GetListNameProduct()
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                var products = context.Products.Select(p => p.ProductName).ToList();
                if (products == null) return null;
                return products;
            }
        }
        public Product GetProductByProductName(string productName)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                var product = context.Products.FirstOrDefault(p => p.ProductName == productName);
                if (product == null) return null;
                return product;
            }
        }
        public string SetRandomProductId()
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                Random random = new Random();
                string productId = "sp" + random.Next(0, 1000).ToString().PadLeft(4, '0');
                while (context.Products.Any(p => p.ProductId == productId))
                {
                    productId = "sp" + random.Next(0, 1000);
                }
                return productId;
            }
        }
    }
}
