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
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (checkBtnXacNhan == false)
            {
                my_UCChiTietMonAn = new UC_ChiTietMonAn();
            }
            if ((cboMenhGia.Text.Length < 4) || cboMenhGia.Text.Substring(cboMenhGia.Text.Length - 4) != ".000")
            {
                MessageBox.Show("Bạn Phải Nhập Theo Định Dạng #,###.000" + Environment.NewLine + "Ví Dụ: 20.000 / 1,000.000", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            ThemChiTietMonAnVaoFlowLayoutPanel();
            //HienThiVaTinhTongTien();
            checkBtnXacNhan = true;
        }
        private void ThemChiTietMonAnVaoFlowLayoutPanel()
        {
            if (checkBtnXacNhan == true)
            {
                int TongMenhGia = Convert.ToInt32(cboMenhGia.Text.Substring(0, cboMenhGia.Text.Length - 4).Replace(",", ""))
                    + Convert.ToInt32(my_UCChiTietMonAn.TextGiaMonAn.Substring(0, my_UCChiTietMonAn.TextGiaMonAn.Length - 7).Replace(",", ""));
                my_UCChiTietMonAn.TextGiaMonAn = string.Format("{0:N3}VNĐ", TongMenhGia);
                lblTongTienNap.Text = my_UCChiTietMonAn.TextGiaMonAn;
            }
            else if (btnXacNhan.Tag.ToString() == "0")
            {
                my_UCChiTietMonAn.TextTenMonAn = "Nạp Tài Khoản";
                my_UCChiTietMonAn.TextGiaMonAn = string.Format("{0:N3}VNĐ", cboMenhGia.Text);
                my_UCChiTietMonAn.TextSoLuongMonAn = 1 + "";
                btnXacNhan.Tag = (Convert.ToInt32(btnXacNhan.Tag) + 1).ToString();
                my_UCChiTietMonAn.Width = 450;
                my_UCChiTietMonAn.btnCongMon.Visible = false;
                my_UCChiTietMonAn.btnTruMon.Visible = false;
                my_UCChiTietMonAn.btnXoaMon.Click += BtnXoaMon_Click;
                my_UCChiTietMonAn.Tag = this;
                panelNapTien.Controls.Add(my_UCChiTietMonAn);
                lblTongTienNap.Text = my_UCChiTietMonAn.TextGiaMonAn;
                SetBtnNapTien(true);
            }
        }

        private void BtnXoaMon_Click(object sender, EventArgs e)
        {
            panelNapTien.Controls.Remove(my_UCChiTietMonAn);
            checkBtnXacNhan = false;
            lblTongTienNap.Text = "0.000VNĐ";
            btnXacNhan.Tag = "0";
            SetBtnNapTien(false);
        }
        private void SetBtnNapTien(bool status)
        {
            btnNapTien.Enabled = status;
            if (status == true)
            {
                btnNapTien.FillColor = Color.FromArgb(255, 128, 128);
            }
            else
            {
                btnNapTien.FillColor = Color.Silver;
            }
        }
    }
}
