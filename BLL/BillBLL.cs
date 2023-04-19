using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BillBLL
    {
        private static BillBLL instance;
        public static BillBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillBLL();
                }
                return instance;
            }
            private set { instance = value; }
        }
        private BillBLL() { }
        public List<Bill> GetListBillWithStatus(string status)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                var bills = context.Bills.Where(p => p.Status == status).ToList();
                return bills;
            }
        }
    }
}
