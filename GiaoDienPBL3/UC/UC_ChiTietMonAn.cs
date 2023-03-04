using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GiaoDienPBL3.UC
{

    public partial class UC_ChiTietMonAn : UserControl
    {
        public string TextSoLuongMonAn
        {
            get { return lblSoLuongMon.Text.Trim(); }
            set { lblSoLuongMon.Text = value; }
        }
        
        public string TextTenMonAn
        {
            get { return lblTenMon.Text.Trim(); }
            set { lblTenMon.Text = value; }
        }

        public string TextGiaMonAn
        {
            get { return lblGiaMon.Text.Trim(); }
            set { lblGiaMon.Text = value; }
        }


        public UC_ChiTietMonAn()
        {
            InitializeComponent();
        }

        private string ChuyenDoiGiaMon(string GiaMon)
        {
            GiaMon = GiaMon.Substring(0, GiaMon.Length - 7);
            return GiaMon;
        }

        private void btnCongTruMon_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            int TongTien = Convert.ToInt32(Form1.myUC_QuanLyMenu.lblTongTien.Text);
            int GiaMon = Convert.ToInt32(ChuyenDoiGiaMon(lblGiaMon.Text));
            //int SoLuongMon = Convert.ToInt32(lblSoLuongMon.Text);
            if (btn.Text == "+")
            {
                lblSoLuongMon.Text = (Convert.ToInt32(lblSoLuongMon.Text) + 1).ToString();
                TongTien += GiaMon;
            }
            else if (lblSoLuongMon.Text == "1")
            {
                Form1.myUC_QuanLyMenu.flowLayoutPanelChiTietMonAn.Controls.Remove(this);
                TongTien -= GiaMon;
            }
            else
            {
                lblSoLuongMon.Text = (Convert.ToInt32(lblSoLuongMon.Text) - 1).ToString();
                TongTien -= GiaMon;
            }
            Form1.myUC_QuanLyMenu.lblTongTien.Text = TongTien.ToString();
        }
    }
}
