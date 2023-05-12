using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaoDienPBL3.User_Controls
{
    public partial class UC_QuanLyNhanVien : UserControl
    {
        private Random random = new Random();
        public UC_QuanLyNhanVien()
        {
            InitializeComponent();
            AddColumnButton();  
            SetData();
        }
        private void SetData()
        {
            foreach (Employee employee in EmployeeBLL.Instance.GetListEmployee())
            {
                dgvNhanVien.Rows.Add(new object[]
                {
                    employee.EmployeeId, employee.EmployeeName, AccountBLL.Instance.GetUserNameByAccountId(employee.AccountId), string.Format("{0:N3}VNĐ", employee.Salary)
                });
            }
            dgvNhanVien.ClearSelection();
            txtMaNhanVien2.Text = EmployeeBLL.Instance.GetRandomEmployeeId();
        }
        private void AddColumnButton()
        {
            DataGridViewButtonColumn buttonXoa = new DataGridViewButtonColumn();
            buttonXoa.HeaderText = "Xóa Nhân Viên";
            buttonXoa.Text = "Xoá";
            buttonXoa.Name = "btnXoa";
            buttonXoa.FillWeight = 80;
            buttonXoa.UseColumnTextForButtonValue = true;
            dgvNhanVien.Columns.Add(buttonXoa);
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvNhanVien.Columns["btnXoa"].Index && e.RowIndex >= 0)
                {
                    string employeeId = dgvNhanVien.Rows[e.RowIndex].Cells["MaNhanVien"].Value.ToString();
                    if (BillBLL.Instance.CheckEmployeeId(employeeId))
                    {
                        frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Hóa Đơn Khách Hàng Của Nhân Viên Này Còn Tồn Tại" + Environment.NewLine + "Không Thể Xóa Được");
                        return;
                    }
                    else if (RecieptBLL.Instance.CheckEmployeeId(employeeId))
                    {
                        frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Hóa Đơn Nhập Kho Của Nhân Viên Này Còn Tồn Tại" + Environment.NewLine + "Không Thể Xóa Được");
                        return;
                    }
                    else
                    {
                        EmployeeBLL.Instance.DeleteEmployee(employeeId);
                        AccountBLL.Instance.DeleteAccount(EmployeeBLL.Instance.GetAccountIdByEmployeeId(employeeId));
                        frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Success, "Xóa Nhân Viên Thành Công");
                        dgvNhanVien.Rows.RemoveAt(e.RowIndex);
                    }
                }
                else
                {
                    txtMaNhanVien.Text = dgvNhanVien.Rows[e.RowIndex].Cells["MaNhanVien"].Value.ToString();
                    txtTenNhanVien.Text = dgvNhanVien.Rows[e.RowIndex].Cells["TenNhanVien"].Value.ToString();
                    txtTenTaiKhoan1.Text = dgvNhanVien.Rows[e.RowIndex].Cells["TenTaiKhoan"].Value.ToString();
                    txtLuong.Text = dgvNhanVien.Rows[e.RowIndex].Cells["Luong"].Value.ToString();
                }
            }
            catch (Exception)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Error, "Lỗi");
                return;
            }
        }
        private void btnKhoiPhucTaiKhoan_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count != 1)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning,
                    "Bạn Phải Chọn, Nhân Viên Cần Sửa" + Environment.NewLine +
                    "Bạn Chỉ Có Thể Sửa Thông Tin Của Từng Người");
                return;
            }
            SetVisibleControl(true);
            txtTenTaiKhoan2.Text = EmployeeBLL.Instance.GetRandomUserNameAccount();
            txtMatKhau.Text = random.Next(0, 1000).ToString().PadLeft(3, '0');
        }

        private void btnXacNhanThayDoi_Click(object sender, EventArgs e)
        {
            string accountId = EmployeeBLL.Instance.GetAccountIdByEmployeeId(dgvNhanVien.SelectedRows[0].Cells["MaNhanVien"].Value.ToString());
            AccountBLL.Instance.UpdateUserNameAndPassword(accountId, txtTenTaiKhoan2.Text, txtMatKhau.Text);
            frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Success, "Thay Đổi Thành Công");
            txtMatKhau.Text = "";
            txtTenTaiKhoan2.Text = "";
            SetVisibleControl(false);
        }
        private void SetVisibleControl(bool status)
        {
            lblMatKhau.Visible = status;
            lblTenTaiKhoan.Visible = status;
            txtMatKhau.Visible = status;
            txtTenTaiKhoan2.Visible = status;
            btnXacNhanThayDoi.Visible = status;
        }
        private void SetVisibleControlDangKy(bool status)
        {
            lblMatKhauDangKy.Visible = status;
            lblTenTaiKhoanDangKy.Visible = status;
            txtMatKhauDangKy.Visible = status;
            txtTenTaiKhoanDangKy.Visible = status;
            txtMaTaiKhoan.Visible = status;
            lblMaTaiKhoan.Visible = status;
            btnXacNhanDangKy.Visible = status;
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            SetVisibleControlDangKy(true);
            txtTenTaiKhoanDangKy.Text = EmployeeBLL.Instance.GetRandomUserNameAccount();
            txtMatKhauDangKy.Text = "123";
            txtMaTaiKhoan.Text = AccountBLL.Instance.GetRandomAccountId();
        }

        private void btnXacNhanDangKy_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvNhanVien);
            row.Cells[0].Value = txtMaNhanVien2.Text;
            row.Cells[1].Value = txtTenNhanVien2.Text;
            row.Cells[2].Value = txtTenTaiKhoanDangKy.Text;
            row.Cells[3].Value = string.Format("{0:N3}VNĐ", Convert.ToDouble(txtLuong2.Text));
            row.Height = 40;
            dgvNhanVien.Rows.Add(row);
            AccountBLL.Instance.AddNewAccount(new Account
            {
                AccountId = txtMaTaiKhoan.Text,
                DateCreate = DateTime.Now.Date,
                Password = txtMatKhauDangKy.Text,
                UserName = txtTenTaiKhoanDangKy.Text,
                Role = "Nhân Viên"
            });
            EmployeeBLL.Instance.AddNewEmployee(new Employee
            {
                EmployeeId = txtMaNhanVien2.Text,
                EmployeeName = txtTenNhanVien2.Text,
                AccountId = txtMaTaiKhoan.Text,
                Salary = (float)Convert.ToDouble(txtLuong2.Text)
            });
            frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Success, "Thêm Nhân Viên Thành Công");
            btnHuy.PerformClick();
            SetVisibleControlDangKy(false);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTenNhanVien2.Text = "";
            txtLuong2.Text = "";
        }
    }
}
