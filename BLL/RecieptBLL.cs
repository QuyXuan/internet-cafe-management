using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RecieptBLL
    {
        private static RecieptBLL instance;
        public static RecieptBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RecieptBLL();
                }
                return instance;
            }
            private set { instance = value; }
        }
        private RecieptBLL() { }
        public List<Reciept> GetListReciept()
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                var reciepts = context.Reciepts.ToList();
                if (reciepts == null)
                {
                    return null;
                }
                return reciepts;
            }
        }
    }
}
