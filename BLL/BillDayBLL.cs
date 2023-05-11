using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BillDayBLL
    {
        private static BillDayBLL instance;
        public static BillDayBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillDayBLL();
                }
                return instance;
            }
            private set { instance = value; }
        }
        private BillDayBLL() { }
        public List<BillDay> GetListBillDayByType(bool type)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return null;
                var billDays = context.BillDays.Where(p => p.Type == type).ToList();
                if (billDays == null) return null;
                return billDays;
            }
        }
        public string GetRandomBillDayId()
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                Random random = new Random();
                string billDayId = "hdd" + random.Next(0, 1000).ToString().PadLeft(4, '0');
                while (context.BillDays.Any(p => p.BillDayId == billDayId))
                {
                    billDayId = "hdd" + random.Next(0, 1000).ToString().PadLeft(4, '0');
                }
                return billDayId;
            }
        }
        public void AddNewBillDay(BillDay billDay)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                context.BillDays.AddOrUpdate(billDay);
                context.SaveChanges();
            }
        }
        public void EditBillDay(DateTime date, bool type, float total)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                BillDay billDay = context.BillDays.FirstOrDefault(p => p.Date == date.Date && p.Type == type);
                if (billDay == null) return;
                billDay.TotalBill += total;
                context.SaveChanges();
            }
        }
        //kiểm tra xem trong ngày hôm nay đã có bill được tạo chưa
        public bool CheckBillDay(DateTime date, bool type)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return false;
                return context.BillDays.Any(p => p.Date == date.Date && p.Type == type);
            }
        }
    }
}
