using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
        public string GetRandomProductId()
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
        public void UpdateProductWithPriceAndPath(string productId, string imageFilePath, float sellingPrice = 0)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                var product = context.Products.FirstOrDefault(p => productId == p.ProductId);
                if (product == null) return;
                if (imageFilePath == "")
                {
                    product.SellingPrice = sellingPrice;
                }
                else
                {
                    product.SellingPrice = sellingPrice;
                    product.ImageFilePath = imageFilePath;
                }
                context.SaveChanges();
            }
        }
        public void AddNewProduct(Product product)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                context.Products.AddOrUpdate(product);
                context.SaveChanges();
            }
        }
        public void AddNewListProduct(List<KeyValuePair<Product, float?>> listProduct)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                foreach (KeyValuePair<Product, float?> product in listProduct)
                {
                    context.Products.AddOrUpdate(new Product
                    {
                        ProductId = product.Key.ProductId,
                        ProductName = product.Key.ProductName,
                        CostPrice = product.Key.CostPrice,
                        Type = product.Key.Type,
                        Stock = product.Value ?? 0,
                        SellingPrice = 0,
                        ImageFilePath = "defaultFoodAndDrink.png",
                        Status = true
                    });
                }
                context.SaveChanges();
            }
        }
    }
}
