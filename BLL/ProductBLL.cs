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
    }
}
