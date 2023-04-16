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
    }
}
