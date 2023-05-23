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
    public partial class UC_ThongTinCaNhan : UserControl
    {
        private string AccountId;
        public UC_ThongTinCaNhan(string accountId = null)
        {
            InitializeComponent();
            AccountId = accountId;
            FillForm();
        }
        private void FillForm()
        {
            string EmployeeId = EmployeeBLL.Instance.GetEmployeeIdByAccountId(AccountId);
            Employee employee = EmployeeBLL.Instance.GetEmployeeByEmployeeId(EmployeeId);
            lblMaNhanVien.Text = EmployeeId;
            lblTenNhanVien.Text = employee.EmployeeName;
            lblMaTaiKhoan.Text = AccountId;
            lblTenTaiKhoan.Text = AccountBLL.Instance.GetUserNameByAccountId(AccountId);
            lblLuong.Text = string.Format("{0:N3}VNĐ", employee.Salary);
        }

        private void btnCapNhatMatKhau_Click(object sender, EventArgs e)
        {
            if (CheckValid())
            {
                AccountBLL.Instance.EditPassword(AccountId, txtMatKhauMoi.Text);
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Success, "Thay Đổi Mật Khẩu Thành Công");
                txtMatKhauCu.Text = "";
                txtMatKhauMoi.Text = "";
                txtXacNhanMatKhau.Text = "";
            }
        }
        private bool CheckValid()
        {
            if (txtMatKhauCu.Text == "" || txtMatKhauMoi.Text == "" || txtXacNhanMatKhau.Text == "")
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Thông Tin Mật Khẩu Không Được Để Trống");
                return false;
            }
            if (!AccountBLL.Instance.CheckDangNhap(lblTenTaiKhoan.Text, txtMatKhauCu.Text))
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Mật Khẩu Cũ Không Chính Xác");
                return false;
            }
            if (txtMatKhauMoi.Text != txtXacNhanMatKhau.Text)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Mật Khẩu Xác Nhận Không Chính Xác");
                return false;
            }
            if (txtMatKhauMoi.Text.Length < 8 || txtMatKhauMoi.Text.Length > 15 || txtMatKhauMoi.Text.Contains(" "))
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Mật Khẩu Từ 8-15 Ký Tự, Không Chứa Khoảng Trắng");
                return false;
            }
            return true;
        }
    }
}
