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

        private void btnCongTruMon_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            if (btn.Text == "+")
            {
                lblSoLuongMon.Text = (Convert.ToInt32(lblSoLuongMon.Text) + 1).ToString();
            }
            else if (lblSoLuongMon.Text == "1")
            {
                Form1.myUC_QuanLyMenu.flowLayoutPanelChiTietMonAn.Controls.Remove(this);
            }
            else
            {
                lblSoLuongMon.Text = (Convert.ToInt32(lblSoLuongMon.Text) - 1).ToString();
            }
        }
    }
}
