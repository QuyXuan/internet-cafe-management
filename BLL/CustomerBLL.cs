using DAL;
using DTO;
using System;
using System.Collections.Generic;
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
    }
}
