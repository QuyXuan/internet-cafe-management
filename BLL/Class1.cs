using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Class1
    {
        private static BLLMonAn instance;
        public static BLLMonAn Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BLLMonAn();
                }
                return instance;
            }
            private set { instance = value; }   
        }
        private BLLMonAn() { }
        public List<MonAn> GetListMonAn()
        {
            //chưa có dữ liệu trong database nên thêm thủ công
            List<MonAn> listMonAn = new List<MonAn>();
            listMonAn.AddRange(new MonAn[]{
                new MonAn("ma001", "Pizza", 50, "Món Ăn", "E:\\Documents\\icon\\pizza.jpg"),
                new MonAn("ma002", "Miến Gà", 60, "Món Ăn", "E:\\Documents\\icon\\MienGa.jpg"),
                new MonAn("ma003", "Phở Bò", 55, "Món Ăn", "E:\\Documents\\icon\\PhoBo.jpg"),
                new MonAn("ma004", "Trà Đào", 40, "Nước Uống", "E:\\Documents\\icon\\TraDao.jpg"),
                new MonAn("ma005", "Bánh Mỳ", 25, "Món Ăn", "E:\\Documents\\icon\\BanhMy.jpg"),
                new MonAn("ma006", "BlueSoda", 65, "Nước Uống", "E:\\Documents\\icon\\BlueSoda.jpg"),
                new MonAn("ma007", "Bún Chả Cá", 45, "Món Ăn", "E:\\Documents\\icon\\BunChaCa.jpg"),
                new MonAn("ma008", "Cafe Sữa", 20, "Nước Uống", "E:\\Documents\\icon\\CafeSua.jpg"),
                new MonAn("ma009", "Chanh Muối", 30, "Nước Uống", "E:\\Documents\\icon\\ChanhMuoi.jpg"),
                new MonAn("ma010", "Cocktail", 70, "Nước Uống", "E:\\Documents\\icon\\Cocktail.jpg")
            });
            return listMonAn;
        }
    }
}
