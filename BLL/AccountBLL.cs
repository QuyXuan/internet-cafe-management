using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.Mime;
using System.Runtime.Remoting.Contexts;
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
        public List<Account> GetListAccount(string Role = null)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                List<Account> accounts = new List<Account>();
                if (Role == null)
                {
                    accounts = context.Accounts.ToList();
                }
                else
                {
                    accounts = context.Accounts.Where(p => p.Role == Role).ToList();
                }
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
        public void EditPassword(string accountId, string password)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                var account = context.Accounts.FirstOrDefault(p => p.AccountId == accountId);
                if (account == null) return;
                account.Password = password;
                context.SaveChanges();
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

                KeyValuePair<string, string>? result = null;

                if (account != null && employee != null)
                {
                    result = new KeyValuePair<string, string>(employee.EmployeeName, account.Role);
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

        //Hàm lấy Account từ accountID
        public Account GetAccountByID(string accountId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                var account = context.Accounts.FirstOrDefault(p => p.AccountId == accountId);
                if (account == null)
                {
                    return null;
                }
                else
                {
                    return account;
                }
            }
        }

        //Hàm kiểm tra thay đổi mật khẩu
        public string CheckDoiMatKhau(string accountID, string oldPass, string newPass, string confirmPass)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                var account = context.Accounts.FirstOrDefault(p => p.AccountId == accountID);
                if (account.Password != oldPass)
                {
                    return "Mật Khẩu Sai";
                }
                if(newPass.Length < 8 || newPass.Length > 15 || newPass.Contains(" "))
                {
                    return "Mật Khẩu Từ 8-15 Ký Tự, Không Chứa Khoảng Trắng";
                }
                if (newPass != confirmPass)
                {
                    return "Mật Khẩu Không Khớp";
                }
                account.Password = newPass;
                context.SaveChanges();
                return "Thay Đổi Mật Khẩu Thành Công";
            }
        }
        public string GetUserNameByAccountId(string accountId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return null;
                var account = context.Accounts.FirstOrDefault(p => p.AccountId == accountId);
                if (account != null)
                {
                    return account.UserName;
                }
                return null;
            }
        }
        public string GetRandomAccountId()
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                Random random = new Random();
                string accountId = "acc" + random.Next(0, 1000).ToString().PadLeft(4, '0');
                while (context.Accounts.Any(p => p.AccountId == accountId))
                {
                    accountId = "acc" + random.Next(0, 1000).ToString().PadLeft(4, '0');
                }
                return accountId;
            }
        }
        public void AddNewAccount(Account account)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                context.Accounts.AddOrUpdate(account);
                context.SaveChanges();
            }
        }
        public void DeleteAccount(string AccountId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                var account = context.Accounts.FirstOrDefault(p => p.AccountId == AccountId);
                if (account == null) return;
                context.Accounts.Remove(account);
                context.SaveChanges();
            }
        }

        public void UpdateUserNameAndPassword(string accountId, string userName, string password)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                var account = context.Accounts.FirstOrDefault(p => p.AccountId == accountId);
                if (account == null) return;
                account.UserName = userName;
                account.Password = password;
                context.SaveChanges();
            }
        }
    }
}
