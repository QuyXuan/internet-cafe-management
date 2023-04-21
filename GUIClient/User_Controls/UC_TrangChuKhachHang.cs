using BLL;
using DTO;
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
        private string AccountID;
        public UC_ChiTietMonAn my_UCChiTietMonAn;
        private bool checkBtnXacNhan = false;
        public UC_TrangChuKhachHang(string accountID)
        {
            InitializeComponent();
            AccountID = accountID;
            setThongTinCaNhan(accountID);
        }

        public void setThongTinCaNhan(string AccountID)
        {
            Customer customer = CustomerBLL.Instance.GetCustomerByAccountId(AccountID);
            lblMaKhachHang.Text = customer.CustomerId;
            lblTenKhachHang.Text = customer.CustomerName;
            if (customer.TypeCustomer) lblLoaiTaiKhoan.Text = "Khách Hàng VIP";
            else lblLoaiTaiKhoan.Text = "Khách Hàng Thường";
            lblSoDuTaiKhoan.Text = string.Format("{0:N3}VNĐ", customer.Balance);
            txtSoGioChoiConLai.Text = customer.TotalTime.ToString();
            txtSoGioChoiConLai.Enabled = false;
        }
    }
}
