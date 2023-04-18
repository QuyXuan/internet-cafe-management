using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
<<<<<<< HEAD:DTO/MonAn.cs
    public class MonAn
=======
    public class Class1
>>>>>>> parent of 792afe9 (11:14 pm 3/25/2023 quy changed):DTO/Class1.cs
    {
        public string MaMonAn { get; set; }
        public string TenMonAn { get; set; }
        public int Gia { get; set; }
        public string Loai { get; set; }
        public string PathAnhMon { get; set; }
        public MonAn()
        {

        }
        public MonAn(string maMonAn, string tenMonAn, int gia, string loai, string pathAnhMon)
        {
            MaMonAn = maMonAn;
            TenMonAn = tenMonAn;
            Gia = gia;
            Loai = loai;
            PathAnhMon = pathAnhMon;
        }
    }
}
