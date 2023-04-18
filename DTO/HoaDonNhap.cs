using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonNhap
    {
        public string MaHoaDon { get; set; }
        public string MaNhanVien { get; set; }
        public string NhaCungCap { get; set; }
        public DateTime NgayNhan { get; set; }
        public string ChietKhau { get; set; }
        public int TongTien { get; set; }
        public HoaDonNhap() { }
        public HoaDonNhap(string maHoaDon, string maNhanVien, string nhaCungCap, DateTime ngayNhan, string chietKhau, int tongTien)
        {
            MaHoaDon = maHoaDon;
            MaNhanVien = maNhanVien;
            NhaCungCap = nhaCungCap;
            NgayNhan = ngayNhan;
            ChietKhau = chietKhau;
            TongTien = tongTien;
        }
    }
}
