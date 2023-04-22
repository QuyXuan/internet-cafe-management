using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TypeComputerBLL
    {
        private static TypeComputerBLL instance;
        public static TypeComputerBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TypeComputerBLL();
                }
                return instance;
            }
            private set { instance = value; }
        }
        private TypeComputerBLL() { }

        public List<TypeComputer> GetListTypeComputer()
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                var typecomputer = context.TypeComputers.ToList();
                return typecomputer;
            }
        }
    }
}
