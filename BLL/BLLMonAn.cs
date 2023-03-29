using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class BLLMonAn
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
                new MonAn("ma001", "Pizza", 50, "Món Ăn", ConvertFromNameToPath("chad-montano-MqT0asuoIcU-unsplash.jpg")),
                new MonAn("ma002", "Miến Gà", 60, "Món Ăn", ConvertFromNameToPath("jennifer-schmidt-zOlQ7lF-3vs-unsplash.jpg")),
                new MonAn("ma003", "Phở Bò", 55, "Món Ăn", ConvertFromNameToPath("markus-winkler-08aic3qPcag-unsplash.jpg")),
                new MonAn("ma004", "Trà Đào", 40, "Nước Uống", ConvertFromNameToPath("food-photographer-jennifer-pallian-sSnCZlEWN5E-unsplash.jpg")),
                new MonAn("ma005", "Bánh Mỳ", 25, "Món Ăn", ConvertFromNameToPath("kadir-celep-paBXUXUwJmo-unsplash.jpg")),
                new MonAn("ma006", "BlueSoda", 65, "Nước Uống", ConvertFromNameToPath("clovis-wood-photography-iUtcVxqxkPk-unsplash.jpg")),
                new MonAn("ma007", "Bún Chả Cá", 45, "Món Ăn", ConvertFromNameToPath("mae-mu-H5Hj8QV2Tx4-unsplash.jpg")),
                new MonAn("ma008", "Cafe Sữa", 20, "Nước Uống", ConvertFromNameToPath("demi-deherrera-L-sm1B4L1Ns-unsplash.jpg")),
                new MonAn("ma009", "Chanh Muối", 30, "Nước Uống", ConvertFromNameToPath("melissa-walker-horn-gtDYwUIr9Vg-unsplash.jpg")),
                new MonAn("ma010", "Cocktail", 70, "Nước Uống", ConvertFromNameToPath("Cocktail.jpg"))
            });
            return listMonAn;
        }
        private string ConvertFromNameToPath(string nameImage)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", ""), "Resources", nameImage);
        }
    }
}
