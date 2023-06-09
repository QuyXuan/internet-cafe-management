using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
        public bool CheckColorId(string colorId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return false;
                return context.TypeComputers.Any(p => p.ColorId == colorId);
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
        public string GetRandomTypeComputerId()
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                Random random = new Random();
                string typeComputerId = "type" + random.Next(0, 1000).ToString().PadLeft(4, '0');
                while (context.TypeComputers.Any(p => p.TypeId == typeComputerId))
                {
                    typeComputerId = "type" + random.Next(0, 1000).ToString().PadLeft(4, '0');
                }
                return typeComputerId;
            }
        }
        public bool CheckTypeComputerName(string typeComputerName)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return false;
                return context.TypeComputers.Any(p => p.NameType == typeComputerName);
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
        public bool CheckColorIdToEdit(string typeId, string colorId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return false;
                var typeComputer = context.TypeComputers.FirstOrDefault(p => p.TypeId == typeId);
                if (typeComputer == null) return false;
                if (typeComputer.ColorId == colorId) return true;
                else if (context.TypeComputers.Any(p => p.ColorId == colorId)) return false;
                return true;
            }
        }
        public void AddNewTypeComputer(TypeComputer typeComputer)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                context.TypeComputers.AddOrUpdate(typeComputer);
                context.SaveChanges();
            }
        }
        public void EditTypeComputer(TypeComputer typeComputer)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                context.TypeComputers.AddOrUpdate(typeComputer);
                context.SaveChanges();
            }
        }
        public void DeleteTypeComputer(string typeId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                var typeComputer = context.TypeComputers.FirstOrDefault(p => p.TypeId == typeId);
                context.TypeComputers.Remove(typeComputer);
                context.SaveChanges();
            }
        }
        public bool CheckTypeIsUsing(string typeId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return false;
                return context.Computers.Any(p => p.TypeId == typeId);
            }
        }
    }
}
