using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HangHoa
    {
        public string MaHangHoa { get; set; }
        public string TenHangHoa { get; set; }
        public int SoLuong { get; set; }
        public string Loai { get; set; }
        public string Gia { get; set; }
        public HangHoa() { }
        public HangHoa(string maHangHoa, string tenHangHoa, int soLuong, string loai, string gia)
        {
            MaHangHoa = maHangHoa;
            TenHangHoa = tenHangHoa;
            SoLuong = soLuong;
            Loai = loai;
            Gia = gia;
        }
    }
}
