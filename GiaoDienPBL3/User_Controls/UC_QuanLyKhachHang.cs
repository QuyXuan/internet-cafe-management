using BLL;
using DTO;
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
            //string[] KhachHangs = { "Quý", "Trường", "Sơn" };
            //string[] LoaiTaiKhoan = { "Tài Khoảng Thường", "Tài Khoản VIP" };
            //for (int i = 0; i < 50; i++)
            //{
            //    dgvQuanLyThongTinKhachHang.Rows.Add(new object[]
            //    {
            //        "mkh" + random.Next(100), KhachHangs[random.Next(KhachHangs.Length)], LoaiTaiKhoan[random.Next(LoaiTaiKhoan.Length)], DateTime.Now.ToString("dd/MM/yyyy")
            //    });
            //}
            foreach (Customer customer in CustomerBLL.Instance.GetListCustomer())
            {
                string typeCustomer = "Khách Thường";
                if (customer.TypeCustomer == true) typeCustomer = "Khách VIP";
                dgvQuanLyThongTinKhachHang.Rows.Add(new object[]
                {
                    customer.CustomerId, customer.CustomerName, typeCustomer, string.Format("{0:N3}VNĐ", customer.Balance), customer.TotalTime + " Phút"
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
                    frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Success, "Xóa Khách Hàng Thành Công");
                }
                else
                {
                    txtMaKhachHang.Text = dgvQuanLyThongTinKhachHang.Rows[e.RowIndex].Cells["MaKhachHang"].Value.ToString();
                    txtTenKhachHang.Text = dgvQuanLyThongTinKhachHang.Rows[e.RowIndex].Cells["TenKhachHang"].Value.ToString();
                    txtSoDuTaiKhoan.Text = dgvQuanLyThongTinKhachHang.Rows[e.RowIndex].Cells["SoDuTaiKhoan"].Value.ToString();
                    txtLoaiTaiKhoan.Text = dgvQuanLyThongTinKhachHang.Rows[e.RowIndex].Cells["LoaiTaiKhoan"].Value.ToString();
                    txtThoiGianConLai.Text = dgvQuanLyThongTinKhachHang.Rows[e.RowIndex].Cells["ThoiGianConLai"].Value.ToString();
                }
            }
            catch(Exception) 
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Error, "Xóa Khách Hàng Thất Bại");
                return;    
            }
        }

        private void btnKhoiPhucTaiKhoan_Click(object sender, EventArgs e)
        {
            SetVisibleControl(true);
            txtTenTaiKhoan.Text = "khachhang" + random.Next(1000);
            txtMatKhau.Text = "mkkh" + random.Next(1000);
        }

        private void btnXacNhanThayDoi_Click(object sender, EventArgs e)
        {
            frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Success, "Thay Đổi Thành Công");
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
            frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Success, "Thay Đổi Tài Khoản Thành Công");
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
