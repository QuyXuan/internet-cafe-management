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
    public partial class UC_QuanLyKhachHang : UserControl
    {
        private Random random = new Random();
        public UC_QuanLyKhachHang()
        {
            InitializeComponent();
            AddColumnButton();
            SetData();
        }
        private void AddColumnButton()
        {
            DataGridViewButtonColumn buttonXoa = new DataGridViewButtonColumn();
            buttonXoa.HeaderText = "";
            buttonXoa.Text = "Xóa";
            buttonXoa.Name = "btnXoa";
            buttonXoa.FillWeight = 40;
            buttonXoa.UseColumnTextForButtonValue = true;
            dgvQuanLyThongTinKhachHang.Columns.Add(buttonXoa);
            //dgvQuanLyThongTinKhachHang.Columns.Add(buttonXoa.Clone() as DataGridViewButtonColumn);
        }
        private void SetData()
        {
            string[] KhachHangs = { "Quý", "Trường", "Sơn" };
            string[] LoaiTaiKhoan = { "Tài Khoảng Thường", "Tài Khoản VIP" };
            for (int i = 0; i < 50; i++)
            {
                dgvQuanLyThongTinKhachHang.Rows.Add(new object[]
                {
                    "mkh" + random.Next(100), KhachHangs[random.Next(KhachHangs.Length)], LoaiTaiKhoan[random.Next(LoaiTaiKhoan.Length)], DateTime.Now.ToString("dd/MM/yyyy")
                });
            }
        }

        private void dgvQuanLyThongTinKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvQuanLyThongTinKhachHang.Columns["btnXoa"].Index && e.RowIndex >= 0)
                {
                    dgvQuanLyThongTinKhachHang.Rows.RemoveAt(e.RowIndex);
                }
                else
                {
                    txtMaKhachHang.Text = dgvQuanLyThongTinKhachHang.Rows[e.RowIndex].Cells["MaKhachHang"].Value.ToString();
                    txtTenKhachHang.Text = dgvQuanLyThongTinKhachHang.Rows[e.RowIndex].Cells["TenKhachHang"].Value.ToString();
                    txtNgayDangKy.Text = dgvQuanLyThongTinKhachHang.Rows[e.RowIndex].Cells["NgayDangKy"].Value.ToString();
                    txtLoaiTaiKhoan.Text = dgvQuanLyThongTinKhachHang.Rows[e.RowIndex].Cells["LoaiTaiKhoan"].Value.ToString();
                }
            }
            catch(Exception) 
            {
                return;    
            }
        }

        private void btnKhoiPhucTaiKhoan_Click(object sender, EventArgs e)
        {
            SetVisibleControl(true);
            txtTenTaiKhoan.Text = "tkkh" + random.Next(1000);
            txtMatKhau.Text = "mkkh" + random.Next(1000);
        }

        private void btnXacNhanThayDoi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thay Đổi Thành Công");
            txtMatKhau.Text = "";
            txtTenTaiKhoan.Text = "";
            SetVisibleControl(false);
        }
        private void SetVisibleControl(bool status)
        {
            lblMatKhau.Visible = status;
            lblTenTaiKhoan.Visible = status;
            txtMatKhau.Visible = status;
            txtTenTaiKhoan.Visible = status;
            btnXacNhanThayDoi.Visible = status;
        }
        private void SetVisibleControlDangKy(bool status)
        {
            lblMatKhauDangKy.Visible = status;
            lblTenTaiKhoanDangKy.Visible = status;
            txtMatKhauDangKy.Visible = status;
            txtTenTaiKhoanDangKy.Visible = status;
            btnXacNhanDangKy.Visible = status;
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            SetVisibleControlDangKy(true);
            txtTenTaiKhoanDangKy.Text = "tkkh" + random.Next(1000);
            txtMatKhauDangKy.Text = "mkkh" + random.Next(1000);
        }

        private void btnXacNhanDangKy_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvQuanLyThongTinKhachHang);
            row.Cells[0].Value = "mkh" + random.Next(1000);
            row.Cells[1].Value = txtTenKhachHangDangKy.Text;
            row.Cells[2].Value = cboLoaiTaiKhoan.SelectedItem.ToString();
            row.Cells[3].Value = DateTime.Now.ToString("dd/MM/yyyy");
            row.Height = 40;
            dgvQuanLyThongTinKhachHang.Rows.Add(row);
            MessageBox.Show("Đăng Ký Tài Khoản Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnHuy.PerformClick();
            SetVisibleControlDangKy(false);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTenKhachHangDangKy.Text = "";
            cboLoaiTaiKhoan.SelectedIndex = -1;
        }
    }
}
