using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    //tạo singleton QLNETDBContext để khởi tạo 1 lần trong suốt vòng đời chương trình
    //tránh dùng using để khởi tạo một đối tượng QLNETDBContext mới thì nó sẽ bị duplicate dữ liệu
    //gây ra lỗi
    public class QLNETDBContextSingleton : QLNETDBContext
    {
        private static QLNETDBContextSingleton instance;
        private QLNETDBContextSingleton() { }
        public static QLNETDBContextSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new QLNETDBContextSingleton();
                }
                return instance;
            }
        }
    }
}
