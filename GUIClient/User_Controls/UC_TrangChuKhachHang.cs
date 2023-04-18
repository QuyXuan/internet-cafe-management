using GiaoDienPBL3.UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIClient.User_Controls
{
    public partial class UC_TrangChuKhachHang : UserControl
    {
        public UC_ChiTietMonAn my_UCChiTietMonAn;
        private bool checkBtnXacNhan = false;
        public UC_TrangChuKhachHang()
        {
            InitializeComponent();
        }
    }
}
