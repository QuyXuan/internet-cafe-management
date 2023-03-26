using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class May
    {
        public string MaMay { get; set; }
        public string SoMay { get; set; }
        public int Gia { get; set; }
        public string LoaiMay { get; set; }
        public string TrangThai { get; set; }
        public May()
        {

        }
        public May(string maMay, string soMay, int gia, string loaiMay, string trangThai)
        {
            MaMay = maMay;
            SoMay = soMay;
            Gia = gia;
            LoaiMay = loaiMay;
            TrangThai = trangThai;
        }
    }
}
