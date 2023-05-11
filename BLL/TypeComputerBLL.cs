using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

        public string GetColoIdByTypeId(string typeId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                var typeComputer = context.TypeComputers.FirstOrDefault(p => p.TypeId == typeId);
                if (typeComputer != null)
                {
                    return typeComputer.ColorId;
                }
                return null;
            }
        }

        public TypeComputer GetTypeComputerByTypeComputerId(string typeComputerId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return null;
                var typeComputer = context.TypeComputers.FirstOrDefault(p => p.TypeId == typeComputerId);
                if (typeComputer != null) return typeComputer;
                return null;
            }
        }

        public float GetPriceByTypeId(string typeId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return 0;
                }
                var typeComputer = context.TypeComputers.FirstOrDefault(p => p.TypeId == typeId);
                if (typeComputer != null)
                {
                    return typeComputer.Price ?? 0;
                }
                return 0;
            }
        }
    }
}
