using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CustomerBLL
    {
        private static CustomerBLL instance;
        public static CustomerBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomerBLL();
                }
                return instance;
            }
            private set { instance = value; }
        }
        private CustomerBLL() { }

        public List<Customer> GetListCustomer()
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                var customers = context.Customers.ToList();
                return customers;
            }
        }
    }
}
