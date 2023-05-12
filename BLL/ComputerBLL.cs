﻿using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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

        //Hàm lấy ra Computer bằng IP
        public Computer GetComputerByIP()
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                string IPComputer = GetLocalIPv4(NetworkInterfaceType.Wireless80211);
                if (string.IsNullOrEmpty(IPComputer))
                {
                    IPComputer = GetLocalIPv4(NetworkInterfaceType.Ethernet);
                }
                var computer = context.Computers.FirstOrDefault(p => p.IPComputer.Equals(IPComputer));

                if (computer == null)
                {
                    return null;
                }
                return computer;
            }
        }

        //Hàm lấy ra Computer bằng ID
        public Computer GetComputerByID(string ID)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                var computer = context.Computers.FirstOrDefault(p => p.ComputerId == ID);

                if (computer == null)
                {
                    return null;
                }
                return computer;
            }
        }
        //public Computer GetComputerByComputerName(string computerName)
        //{
        //    using (var context = new QLNETDBContext())
        //    {
        //        if (context == null) return null;
        //        var computer = context.Computers.FirstOrDefault(p => p.ComputerName == computerName);
        //        if (computer == null) return null;
        //        return computer;
        //    }
        //}
        //Hàm lấy IP của máy
        public string GetMyIP()
        {
            string IPComputer = GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(IPComputer))
            {
                IPComputer = GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
            return IPComputer;
        }
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

        public string GetRandomComputerId()
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null)
                {
                    return null;
                }
                Random random = new Random();
                string computerId = "mt" + random.Next(0, 1000).ToString().PadLeft(4, '0');
                while (context.Computers.Any(p => p.ComputerId == computerId))
                {
                    computerId = "mt" + random.Next(0, 1000).ToString().PadLeft(4, '0');
                }
                return computerId;
            }
        }

        public void AddNewComputer(Computer computer)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                context.Computers.AddOrUpdate(computer);
                context.SaveChanges();
            }
        }

        public void DeleteComputer(string computerId)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                var computer = context.Computers.FirstOrDefault(p => p.ComputerId == computerId);
                if (context != null)
                {
                    context.Computers.Remove(computer);
                    context.SaveChanges();
                }
            }
        }
        
        public void EditComputer(Computer computer)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return;
                var Computer = context.Computers.FirstOrDefault(p => p.ComputerId == computer.ComputerId);
                if (context != null)
                {
                    Computer.ComputerName = computer.ComputerName;
                    Computer.TypeId = computer.TypeId;
                    Computer.Status = computer.Status;
                    Computer.IPComputer = computer.IPComputer;
                    context.SaveChanges();
                }
            }
        }

        public bool CheckComputerName(string computerName)
        {
            using (var context = new QLNETDBContext())
            {
                if (context == null) return false;
                return context.Computers.Any(p => p.ComputerName == computerName);
            }
        }
    }
}
