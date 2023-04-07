using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaoDienPBL3.User_Controls
{
    public partial class UC_ChiTietHoaDonNhapKho : UserControl
    {
        public string TextMaDon
        {
            get { return lblMaDon.Text.Trim(); }
            set { lblMaDon.Text = value; }
        }
        public string TextLoaiDon
        {
            get { return lblLoaiDon.Text.Trim(); }
            set { lblLoaiDon.Text = value; }
        }
        public string TextThanhTien
        {
            get { return lblThanhTien.Text.Trim(); }
            set { lblThanhTien.Text = value; }
        }
        public string TextNgayTaoDon
        {
            get { return lblNgayTaoDon.Text.Trim(); }
            set { lblNgayTaoDon.Text = value; }
        }
        public UC_ChiTietHoaDonNhapKho()
        {
            InitializeComponent();
        }
    }
}
