using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
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
        //Hàm lấy ra TypeComputer bằng TypeId
        public TypeComputer GetTypeComputerByTypeId(string typeId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                var typeComputer = context.TypeComputers.FirstOrDefault(p => p.TypeId == typeId);
                if (typeComputer == null)
                {
                    return null;
                }
                return typeComputer;
            }
        }
<<<<<<< HEAD
<<<<<<< HEAD
        //Hàm lấy ra Computer bằng IP
        public Computer GetComputerByIP(string IP)
=======
        public string GetNumberComputerByComputerId(string computerId)
>>>>>>> a5d95e68c4157f25b0b0177beb333a88787bf1f0
=======
        //Hàm lấy ra Computer bằng IP
        public Computer GetComputerByIP(string IP)
>>>>>>> db4cf27b471460c2d841536b31bffcb5acc0f1ff
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
<<<<<<< HEAD
<<<<<<< HEAD
                var computer = context.Computers.FirstOrDefault(p => p.IPComputer == IP);
=======
                var computer = context.Computers.FirstOrDefault(p => p.ComputerId == computerId);
>>>>>>> a5d95e68c4157f25b0b0177beb333a88787bf1f0
=======
                var computer = context.Computers.FirstOrDefault(p => p.IPComputer == IP);
<<<<<<< HEAD
=======

>>>>>>> aeae4fca473fc8667969f5ea7e4328d8bb08e518
>>>>>>> db4cf27b471460c2d841536b31bffcb5acc0f1ff
                if (computer == null)
                {
                    return null;
                }
<<<<<<< HEAD
<<<<<<< HEAD
                return computer;
            }
        }
        //Hàm lấy IP của máy
        public string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }
=======
                return computer.ComputerName;
            }
        }
>>>>>>> a5d95e68c4157f25b0b0177beb333a88787bf1f0
=======
                return computer;
            }
        }
        //Hàm lấy IP của máy
        public string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }
>>>>>>> db4cf27b471460c2d841536b31bffcb5acc0f1ff
    }
}
