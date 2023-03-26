using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLMay
    {
        private static BLLMay instance;
        public static BLLMay Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BLLMay();
                }
                return instance;
            }
            private set { instance = value; }
        }
        private BLLMay() { }
        public List<May> GetListMay()
        {
            List<May> listMay = new List<May>();
            listMay.AddRange(new May[]
            {
                new May("m001", "1", 15, "Khách", "Bình Thường"),
                new May("m002", "2", 12, "Khách Thường Xuyên", "Bình Thường"),
                new May("m003", "3", 0, "Admistrator", "Bình Thường"),
                new May("m004", "4", 5, "Nhân Viên", "Bình Thường"),
                new May("m005", "5", 10, "Học Sinh", "Bình Thường"),
                new May("m006", "6", 15, "Online", "Bình Thường"),
                new May("m007", "7", 15, "Offline", "Bình Thường"),
                new May("m008", "8", 15, "Trả Sau", "Bình Thường"),
                new May("m009", "9", 15, "Khách", "Còn 5 Phút"),
                new May("m010", "10", 15, "Khách", "Bảo Trì"),
            });
            return listMay;
        }
    }
}
