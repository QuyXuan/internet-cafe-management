using Guna.UI2.WinForms;
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
    public partial class UC_HoaDonNhapKho : UserControl
    {
        public UC_HoaDonNhapKho()
        {
            InitializeComponent();
        }

        private void btnThemChiTietHangNhap_Click(object sender, EventArgs e)
        {
            panelChiTietHangNhap.Visible = true;
        }

        private void btnHuyXacNhan_Click(object sender, EventArgs e)
        {
            Guna2Button button = sender as Guna2Button;
            if (button.Name == "btnXacNhan")
            {
                if (CheckValid() == false) return;
                UC_ChiTietHoaDonNhapKho my_UCChiTietHoaDonNhapKho = new UC_ChiTietHoaDonNhapKho();
                int ThanhTien = Convert.ToInt32(txtSoLuong.Text) * Convert.ToInt32((txtGiaGoc.Text.Substring(0, txtGiaGoc.Text.Length - 4).Replace(",", "")));
                my_UCChiTietHoaDonNhapKho.TextThanhTien = string.Format("{0:N3}VNĐ", ThanhTien);
                my_UCChiTietHoaDonNhapKho.TextMaDon = txtMaHoaDon.Text;
                panelHoaDon.Controls.Add(my_UCChiTietHoaDonNhapKho);
                panelHoaDon.Controls.SetChildIndex(my_UCChiTietHoaDonNhapKho, 1);
            }
            txtMaMon.Text = "";
            txtTenMon.Text = "";
            txtSoLuong.Text = "";
            txtGiaGoc.Text = "";
            cboLoai.SelectedIndex = -1;
            panelChiTietHangNhap.Visible = false;
        }
        private bool CheckValid()
        {
            if (txtMaHoaDon.Text == "")
            {
                MessageBox.Show("Mã Hóa Đơn Không Được Để Trống", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            else if (int.TryParse(txtSoLuong.Text, out _) == false)
            {
                MessageBox.Show("Số Lượng Phải Là Một Số Nguyên", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            else if((txtGiaGoc.Text.Length < 4) || txtGiaGoc.Text.Substring(txtGiaGoc.Text.Length - 4) != ".000")
            {
                MessageBox.Show("Bạn Phải Nhập Theo Định Dạng #,###.000" + Environment.NewLine + "Ví Dụ: 20.000 / 1,000.000", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
