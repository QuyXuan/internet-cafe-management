using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ConnectionBLL
    {
        private static ConnectionBLL instance;
        public static ConnectionBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConnectionBLL();
                }
                return instance;
            }
            private set { instance = value; }
        }
        private ConnectionBLL() { }

        //Hàm kiểm tra kết nối internet
        public bool hasInternetAccess()
        {
            try
            {
                System.Net.IPHostEntry i = System.Net.Dns.GetHostEntry("www.google.com");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Hàm kiểm tra truy cập server
        public bool hasServerAccess()
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
