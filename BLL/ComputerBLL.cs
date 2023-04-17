using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ComputerBLL
    {
        private static ComputerBLL instance;
        public static ComputerBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ComputerBLL();
                }
                return instance;
            }
            private set { instance = value; }
        }
        private ComputerBLL() { }
        public List<Computer> GetListComputer()
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                var computers = context.Computers.ToList();
                return computers;
            }
        }
    }
}
