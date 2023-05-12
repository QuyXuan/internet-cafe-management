using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
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
        
        public string GetRandomCustomerId()
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                Random random = new Random();
                string customerId = "kh" + random.Next(0, 1000).ToString().PadLeft(4, '0');
                while (context.Customers.Any(p => p.CustomerId == customerId))
                {
                    customerId = "kh" + random.Next(0, 1000).ToString().PadLeft(4, '0');
                }
                return customerId;
            }
        }
        public Customer GetCustomerByAccountId(string AccountID)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                var customer = context.Customers.FirstOrDefault(p => p.AccountId == AccountID);
                return customer;
            }
        }
        public Customer GetCustomerByCustomerId(string customerId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return null;
                var customer = context.Customers.FirstOrDefault(p => p.CustomerId == customerId);
                if (customer == null) return null;
                return customer;
            }
        }
        public string GetNameCustomerByCustomerId(string customerId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                var customer = context.Customers.FirstOrDefault(p => p.CustomerId == customerId);
                return customer.CustomerName;
            }
        }

        //Hàm cập nhật thời gian còn lại của người chơi
        public int SetTotalTime(Time time, string customerId, string NameType)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return 0;
                }
                float totalTime = TimerBLL.Instance.TranferTotalTime(time);
                float totalTimeMayThuong = TimerBLL.Instance.ChangeTimeToMayThuong(totalTime, NameType);
                var customer = context.Customers.FirstOrDefault(p => p.CustomerId == customerId);
                if (totalTimeMayThuong < 1)
                {
                    totalTime = 0;
                }
                customer.TotalTime = totalTimeMayThuong;
                context.SaveChanges();
                return (int)totalTime;
            }
        }

        //Hàm cập nhật số dư khách hàng
        public void SetBalance(double Balance, string customerId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return;
                }
                var customer = context.Customers.FirstOrDefault(p => p.CustomerId == customerId);
                customer.Balance = (float)Balance;
                context.SaveChanges();
            }
        }
        public string GetRandomUserNameAccount()
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                Random random = new Random();
                string userName = "khachhang" + random.Next(0, 1000).ToString().PadLeft(4, '0');
                while (context.Customers.Any(p => p.CustomerName == userName))
                {
                    userName = "khachhang" + random.Next(0, 1000).ToString().PadLeft(4, '0');
                }
                return userName;
            }
        }
        public void AddNewCustomer(Customer customer)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                context.Customers.AddOrUpdate(customer);
                context.SaveChanges();
            }
        }
        public void DeleteCustomer(string customerId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                var customer = context.Customers.FirstOrDefault(p => p.CustomerId == customerId);
                if (customer == null) return;
                context.Customers.Remove(customer);
                context.SaveChanges();
            }
        }
        public string GetAccountIdByCustomerId(string customerId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return null;
                var customer = context.Customers.FirstOrDefault(p => p.CustomerId == customerId);
                if (customer == null) return null;
                return customer.AccountId;
            }
        }
        public void EditCustomerBalance(string customerId, float balance, bool type)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                var customer = context.Customers.FirstOrDefault(p => p.CustomerId == customerId);
                if (customer == null) return;
                //nếu true là cộng lên nếu false là trừ ra
                if (type == true)
                {
                    customer.Balance += balance;

                }
                else
                {
                    customer.Balance -= balance;
                }
                context.SaveChanges();
            }
        }
    }
}
