using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaoDienPBL3.UC
{
    public partial class UC_MonAn : UserControl
    {
        public Image ImagePanel
        {
            get { return picMonAn.Image; }
            set { picMonAn.Image = value; }
        }
        
        public string TextGiaMonAn
        {
            get { return lblGiaMonAn.Text.Trim(); }
            set { lblGiaMonAn.Text = value; }
        }

        public string TextTenMonAn
        {
            get { return lblTenMonAn.Text.Trim(); }
            set { lblTenMonAn.Text = value; }
        }

        public UC_MonAn()
        {
            InitializeComponent();
        }

        private void ChinhMauVienMonAn()
        {
            if (panelBackGroundMonAn.BackColor == Color.Transparent)
                panelBackGroundMonAn.BackColor = Color.FromArgb(4, 121, 171);
            else
                panelBackGroundMonAn.BackColor = Color.Transparent;
        }

        private void ThemChiTietMonAnVaoFlowLayoutPanel()
        {
            UC_ChiTietMonAn myUCChiTietMonAn = new UC_ChiTietMonAn();
            myUCChiTietMonAn.TextTenMonAn = lblTenMonAn.Text;
            myUCChiTietMonAn.TextGiaMonAn = lblGiaMonAn.Text;
            myUCChiTietMonAn.TextSoLuongMonAn = 1 + "";
            lblTenMonAn.Tag = (Convert.ToInt32(lblTenMonAn.Tag) + 1).ToString();
            myUCChiTietMonAn.Width = 270;
            myUCChiTietMonAn.Tag = this;
            Form1.myUC_QuanLyMenu.flowLayoutPanelChiTietMonAn.Controls.Add(myUCChiTietMonAn);
        }

        private void HienThiVaTinhTongTien()
        {
            int TongTien = Convert.ToInt32(Form1.myUC_QuanLyMenu.lblTongTien.Tag);
            TongTien += Convert.ToInt32(lblGiaMonAn.Text.Substring(0, lblGiaMonAn.Text.Length - 7));
            Form1.myUC_QuanLyMenu.lblTongTien.Text = string.Format("{0:N3}VNĐ", TongTien);
            Form1.myUC_QuanLyMenu.lblTongTien.Tag = TongTien;
        }

        private void picMonAn_Click(object sender, EventArgs e)
        {
            if (panelBackGroundMonAn.BackColor == Color.FromArgb(4, 121, 171)) return;
            ChinhMauVienMonAn();
            ThemChiTietMonAnVaoFlowLayoutPanel();
            HienThiVaTinhTongTien();
        }
        
    }
}
