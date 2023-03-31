using DTO;
using GiaoDienPBL3.UC;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Utilities.BunifuTextBox.Transitions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskBand;

namespace GiaoDienPBL3.User_Controls
{
    public partial class UC_QuanLyHoaDonNhapKho : UserControl
    {
        private Random random = new Random();
        private List<Control> listUCThongTinHangHoa;
        public UC_QuanLyHoaDonNhapKho()
        {
            InitializeComponent();
            listUCThongTinHangHoa = new List<Control>();
            SetData();
        }

        private void btnHuyXacNhan_Click(object sender, EventArgs e)
        {
            Guna2Button button = sender as Guna2Button;
            if (button.Name == "btnXacNhan")
            {
                if (CheckValid() == false) return;
                UC_ChiTietMonAn my_UCChiTietMonAn = new UC_ChiTietMonAn();
                my_UCChiTietMonAn.btnCongMon.Visible = false;
                my_UCChiTietMonAn.btnTruMon.Visible = false;
                int ThanhTien = Convert.ToInt32(txtSoLuong.Text) * Convert.ToInt32((txtGiaGoc.Text.Substring(0, txtGiaGoc.Text.Length - 4).Replace(",", "")));
                my_UCChiTietMonAn.TextGiaMonAn = string.Format("{0:N3}VNĐ", ThanhTien);
                my_UCChiTietMonAn.TextTenMonAn = txtTenMon.Text;
                my_UCChiTietMonAn.TextSoLuongMonAn = txtSoLuong.Text;
                listUCThongTinHangHoa.Add(my_UCChiTietMonAn);
                panelHoaDon.Controls.Add(my_UCChiTietMonAn);
                panelHoaDon.Controls.SetChildIndex(my_UCChiTietMonAn, 1);
                int TongTien = Convert.ToInt32(lblTongTien.Text.Substring(0, lblTongTien.Text.Length - 7).Replace(",", "")) + ThanhTien;
                lblTongTien.Text = string.Format("{0:N3}VNĐ", TongTien);
            }
            txtMaMon.Text = "";
            txtTenMon.Text = "";
            txtSoLuong.Text = "";
            txtGiaGoc.Text = "";
            txtTongTien.Text = "";
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
            else if (txtTenMon.Text == "")
            {
                MessageBox.Show("Tên Món Không Được Để Trống", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
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
            else if (txtNhaCungCap.Text == "")
            {
                MessageBox.Show("Tên Nhà Cung Cấp Không Được Để Trống", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void SetData()
        {
            txtMaHoaDon.Text = "mdh" + random.Next(0, 100);
            txtMaNhanVien.Text = "nv" + random.Next(0, 100);
            txtTenNhanVien.Text = "Quy";
            txtGiamGia.Text = "0%";
            for (int i = 0; i < 50; i++)
            {
                dgvHoaDonNhap.Rows.Add(new object[]
                {
                    "mdh" + random.Next(0, 100), "nv" + random.Next(0, 100), "QuyXuan", DateTime.Now.ToString("dd/MM/yyyy"), random.Next(0, 100) + "%", random.Next(1, 999) + ".000VNĐ"
                });
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            panelChiTietHangNhap.Visible = true;
            //panelChiTietHangNhap.Size.Width = panelHoaDon.Size.Width - 2;
            txtNhaCungCap.Enabled = true;
            txtGiamGia.Enabled = true;
            dtpNgayNhan.Enabled = true;
            txtMaMon.Focus();
        }
        private void SetAllButtonDisableAndVisible()
        {
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnHuy.Visible = true;
            btnOK.Visible = true;
        }
        private void SetAllButtonEnableAndInvisible()
        {
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Checked = false;
            btnSua.Checked = false;
            btnHuy.Visible = false;
            btnOK.Visible = false;
        }
        private void SetEnableComboboxAndTextBox(bool status)
        {
            txtMaHoaDon.Enabled = status;
            txtTongTien.Enabled = status;
            dtpNgayNhan.Enabled = status;
            txtMaNhanVien.Enabled = status;
            txtTenNhanVien.Enabled = status;
            txtNhaCungCap.Enabled = status;
            txtGiamGia.Enabled = status;
        }
        private void ClearComboboxAndTextBox()
        {
            txtTongTien.Text = "";
            txtTenNhanVien.Text = "";
            txtNhaCungCap.Text = "";
            txtGiamGia.Text = "";
            dtpNgayNhan.Value = DateTime.Now;
        }
        private void btnXoaSuaClick(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            SetAllButtonDisableAndVisible();
            if (btn.Name == "btnThem")
            {
                btnThem.Enabled = true;
                ClearComboboxAndTextBox();
                SetEnableComboboxAndTextBox(true);
            }
            else if (btn.Name == "btnSua")
            {
                btnSua.Enabled = true;
                SetEnableComboboxAndTextBox(true);
            }
            else
            {
                btnXoa.Enabled = true;
                ClearComboboxAndTextBox();
            }
            //lastButton = btn;
        }
        private void btnHuyOKClick(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            //if (btn.Name == "btnOK")
            //{
            //    if (lastButton.Name == "btnThem")
            //    {
            //        AddMonAn(SetMonAn());
            //    }
            //}
            SetAllButtonEnableAndInvisible();
            SetEnableComboboxAndTextBox(false);
        }

        private void btnThemChiTietHangNhap_Click(object sender, EventArgs e)
        {
            //HoaDonNhap hoaDonNhap = new HoaDonNhap();
            //hoaDonNhap.MaHoaDon = txtMaHoaDon.Text;
            //hoaDonNhap.MaNhanVien = txtMaNhanVien.Text;
            //hoaDonNhap.NhaCungCap = txtNhaCungCap.Text;
            //hoaDonNhap.ChietKhau = txtGiamGia.Text;
            //hoaDonNhap.NgayNhan = dtpNgayNhan.Value;
            dgvHoaDonNhap.Rows.Add(new object[]
            {
                txtMaHoaDon.Text, txtMaNhanVien.Text, txtNhaCungCap.Text, dtpNgayNhan.Value.ToString("dd/MM/yyyy"), txtGiamGia.Text, lblTongTien.Text
            });
            btnHuyTatCa.PerformClick();
        }

        private void btnHuyTatCa_Click(object sender, EventArgs e)
        {
            foreach (Control control in listUCThongTinHangHoa)
            {
                panelHoaDon.Controls.Remove(control);
                control.Dispose();
            }
            lblTongTien.Text = "0.000VNĐ";
        }

        private void dgvHoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            DataGridViewRow Row = dgvHoaDonNhap.SelectedRows[0];
            txtMaHoaDon.Text = Row.Cells["MaHoaDon"].Value.ToString();
            txtMaNhanVien.Text = Row.Cells["MaNhanVien"].Value.ToString();
            txtNhaCungCap.Text = Row.Cells["NhaCungCap"].Value.ToString();
            dtpNgayNhan.Value = Convert.ToDateTime(Row.Cells["NgayNhan"].Value);
            txtGiamGia.Text = Row.Cells["ChietKhau"].Value.ToString();
            txtTongTien.Text = Row.Cells["TongTien"].Value.ToString();
        }
    }
}
