using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AccountBLL
    {
        private static AccountBLL instance;
        public static AccountBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountBLL();
                }
                return instance;
            }
            private set { instance = value; }
        }
        private AccountBLL() { }
        public List<Account> GetListAccount()
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                var accounts = context.Accounts.ToList();
                return accounts;
            }
        }
        //hàm kiểm tra đăng nhập có đúng username password không
        public bool CheckDangNhap(string UserName, string Password)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return false;
                }
                var account = context.Accounts.FirstOrDefault(p => p.UserName == UserName && p.Password == Password);
                if (account == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        //hàm trả về cặp giá trị là tên và vai trò
        public KeyValuePair<string, string>? GetTenVaVaiTro(string accountId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }

                var account = context.Accounts.FirstOrDefault(p => p.AccountId == accountId);
                var employee = context.Employees.FirstOrDefault(p => p.AccountId == accountId);
                var customer = context.Customers.FirstOrDefault(p => p.AccountId == accountId);

                KeyValuePair<string, string>? result = null;

                if (account != null && employee != null)
                {
                    result = new KeyValuePair<string, string>(employee.EmployeeName, account.Role);
                }

                if (account != null && customer != null)
                {
                    if(customer.TypeCustomer)
                    {
                        result = new KeyValuePair<string, string>(customer.CustomerName, "Khách hàng VIP");
                    } else
                    {
                        result = new KeyValuePair<string, string>(customer.CustomerName, "Khách hàng thường");
                    }
                }

                return result;
            }
        }
        //hàm lấy AccountId từ username để từ form login truyền cho MainForm
        public string GetAccountIdByUserName(string UserName)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                var account = context.Accounts.FirstOrDefault(p => p.UserName == UserName);
                if (account == null)
                {
                    return null;
                }
                else
                {
                    return account.AccountId;
                }
            }
        }
    }
}
