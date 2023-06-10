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
        }
        private void SetData()
        {
            foreach (Customer customer in CustomerBLL.Instance.GetListCustomer())
            {
                string typeCustomer = "Khách Thường";
                if (customer.TypeCustomer == true) typeCustomer = "Khách VIP";
                dgvQuanLyThongTinKhachHang.Rows.Add(new object[]
                {
                    customer.CustomerId, customer.CustomerName, typeCustomer, string.Format("{0:N3}VNĐ", customer.Balance), customer.TotalTime + " Phút"
                });
            }
            dgvQuanLyThongTinKhachHang.ClearSelection();
            txtMaKhachHang2.Text = CustomerBLL.Instance.GetRandomCustomerId();
        }

        private void dgvQuanLyThongTinKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvQuanLyThongTinKhachHang.Columns["btnXoa"].Index && e.RowIndex >= 0)
                {
                    string customerId = dgvQuanLyThongTinKhachHang.Rows[e.RowIndex].Cells["MaKhachHang"].Value.ToString();
                    if (BillBLL.Instance.CheckCustomerId(customerId))
                    {
                        frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Hóa Đơn Khách Hàng Này Đang Tồn Tại" + Environment.NewLine + "Không Thể Xóa");
                        return;
                    }
                    else
                    {
                        CustomerBLL.Instance.DeleteCustomer(customerId);
                        AccountBLL.Instance.DeleteAccount(CustomerBLL.Instance.GetAccountIdByCustomerId(customerId));
                        frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Success, "Xóa Khách Hàng Thành Công");
                        dgvQuanLyThongTinKhachHang.Rows.RemoveAt(e.RowIndex);
                    }
                }
                else
                {
                    txtMaKhachHang.Text = dgvQuanLyThongTinKhachHang.Rows[e.RowIndex].Cells["MaKhachHang"].Value.ToString();
                    txtTenKhachHang.Text = dgvQuanLyThongTinKhachHang.Rows[e.RowIndex].Cells["TenKhachHang"].Value.ToString();
                    txtSoDuTaiKhoan.Text = dgvQuanLyThongTinKhachHang.Rows[e.RowIndex].Cells["SoDuTaiKhoan"].Value.ToString();
                    txtLoaiTaiKhoan.Text = dgvQuanLyThongTinKhachHang.Rows[e.RowIndex].Cells["LoaiKhach"].Value.ToString();
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
            if (dgvQuanLyThongTinKhachHang.SelectedRows.Count != 1)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, 
                    "Bạn Phải Chọn, Khách Hàng Cần Sửa" + Environment.NewLine + 
                    "Bạn Chỉ Có Thể Sửa Thông Tin Của Từng Người");
                return;
            }
            SetVisibleControl(true);
            txtTenTaiKhoan.Text = CustomerBLL.Instance.GetRandomUserNameAccount();
            txtMatKhau.Text = random.Next(0, 1000).ToString().PadLeft(3, '0');
        }

        private void btnXacNhanThayDoi_Click(object sender, EventArgs e)
        {
            string accountId = CustomerBLL.Instance.GetAccountIdByCustomerId(dgvQuanLyThongTinKhachHang.SelectedRows[0].Cells["MaKhachHang"].Value.ToString());
            AccountBLL.Instance.UpdateUserNameAndPassword(accountId, txtTenTaiKhoan.Text, txtMatKhau.Text);
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
            lblMaTaiKhoan.Visible = status;
            txtMaTaiKhoan.Visible = status;
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            SetVisibleControlDangKy(true);
            txtMaTaiKhoan.Text = AccountBLL.Instance.GetRandomAccountId();
            txtTenTaiKhoanDangKy.Text = CustomerBLL.Instance.GetRandomUserNameAccount();
            txtMatKhauDangKy.Text = random.Next(0, 1000).ToString().PadLeft(3, '0');
        }

        private void btnXacNhanDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValid() == false) return; 
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvQuanLyThongTinKhachHang);
                row.Cells[0].Value = txtMaKhachHang2.Text;
                row.Cells[1].Value = txtTenKhachHangDangKy.Text;
                row.Cells[2].Value = cboLoaiKhach.SelectedItem.ToString();
                row.Cells[3].Value = string.Format("{0:N3}VNĐ", 0);
                row.Cells[4].Value = "60 Phút";
                row.Height = 40;
                //typecustomer == false la khach binh thuong, true la khach vip
                AccountBLL.Instance.AddNewAccount(new Account
                {
                    AccountId = txtMaTaiKhoan.Text,
                    DateCreate = DateTime.Now.Date,
                    Password = txtMatKhauDangKy.Text,
                    Role = "Khách Hàng",
                    UserName = txtTenTaiKhoanDangKy.Text
                });
                CustomerBLL.Instance.AddNewCustomer(new Customer
                {
                    CustomerId = txtMaKhachHang2.Text,
                    CustomerName = txtTenKhachHangDangKy.Text,
                    AccountId = txtMaTaiKhoan.Text,
                    Balance = 0,
                    TotalTime = 60,
                    TypeCustomer = (cboLoaiKhach.SelectedIndex == 1)
                });
                
                frmMain.myUC_QuanLyMenu.cboTenTaiKhoan.DataSource = AccountBLL.Instance.GetListAccount("Khách Hàng");
                //cboTenTaiKhoan.DisplayMember = "UserName";
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Success, "Đăng Ký Tài Khoản Thành Công");
                dgvQuanLyThongTinKhachHang.Rows.Add(row);
                btnHuy.PerformClick();
                SetVisibleControlDangKy(false);
            }
            catch (Exception)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Error, "Lỗi");
                return;
            }
        }

        private bool CheckValid()
        {
            if (txtTenKhachHangDangKy.Text == "")
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Tên Khách Hàng Không Được Để Trống");
                return false;
            }
            if (cboLoaiKhach.SelectedIndex == -1)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Bạn Phải Chọn Loại Tài Khoản");
                return false;
            }
            return true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTenKhachHangDangKy.Text = "";
            txtMaKhachHang2.Text = CustomerBLL.Instance.GetRandomCustomerId();
            cboLoaiKhach.SelectedIndex = -1;
        }

        private void msLamMoiDanhSach_Click(object sender, EventArgs e)
        {
            dgvQuanLyThongTinKhachHang.SuspendLayout();
            dgvQuanLyThongTinKhachHang.Rows.Clear();
            SetData();
        }
    }
}
