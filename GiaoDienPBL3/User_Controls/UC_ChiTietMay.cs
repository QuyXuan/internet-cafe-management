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
    public partial class UC_ChiTietMay : UserControl
    {
        public string TextMaMay
        {
            get { return lblMaMay.Text.Trim(); }
            set { lblMaMay.Text = value; }
        }
        public string TextSoMay
        {
            get { return lblSoMay.Text.Trim(); }
            set { lblSoMay.Text = value; }
        }
        public string TextGiaMay
        {
            get { return lblGiaMay.Text.Trim(); }
            set { lblGiaMay.Text = value; }
        }
        public string TextLoaiMay
        {
            get { return lblLoaiMay.Text.Trim(); }
            set { lblLoaiMay.Text = value; }
        }
        public string TextTrangThai
        {
            get { return lblTrangThai.Text.Trim(); }
            set { lblTrangThai.Text = value; }
        }
        public string TextNguoiDung
        {
            get { return lblNguoiDung.Text.Trim(); }
            set { lblNguoiDung.Text = value; }
        }

        public UC_ChiTietMay()
        {
            InitializeComponent();
        }
    }
}
