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
        private Customer customer;
        public UC_ChiTietMonAn my_UCChiTietMonAn;
        //private bool checkBtnXacNhan = false;
        public UC_TrangChuKhachHang(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            setThongTinCaNhan(customer);
            lblThongBao.Visible = false;
        }

        public void setThongTinCaNhan(Customer customer)
        {
            lblMaKhachHang.Text = customer.CustomerId;
            lblTenKhachHang.Text = customer.CustomerName;
            if (customer.TypeCustomer) lblLoaiTaiKhoan.Text = "Khách Hàng VIP";
            else lblLoaiTaiKhoan.Text = "Khách Hàng Thường";
            lblSoDuTaiKhoan.Text = string.Format("{0:N3}VNĐ", customer.Balance);
            txtSoGioChoiConLai.Text = customer.TotalTime.ToString();
            txtSoGioChoiConLai.Enabled = false;
            lblTenKhachHang.Text = AccountBLL.Instance.GetAccountByID(customer.AccountId).UserName;
        }

        private void btnCapNhatMatKhau_Click(object sender, EventArgs e)
        {
            if (txtMatKhauCu.Text != string.Empty && txtMatKhauMoi.Text != string.Empty && txtXacNhanMatKhau.Text != string.Empty)
            {
                string message = AccountBLL.Instance.CheckDoiMatKhau(customer.AccountId, txtMatKhauCu.Text, txtMatKhauMoi.Text, txtXacNhanMatKhau.Text);
                if (message == null)
                {
                    ShowThongBao("Thành Công");
                    txtMatKhauCu.Clear();
                    txtMatKhauMoi.Clear();
                    txtXacNhanMatKhau.Clear();
                }
                else ShowThongBao(message);
            }
            else ShowThongBao("Vui lòng nhập đủ thông tin");
        }

        public async void ShowThongBao(string thongbao)
        {
            lblThongBao.Visible = true;
            lblThongBao.Text = thongbao;
            while (lblThongBao.Visible)
            {
                await Task.Delay(3000);
                lblThongBao.Visible = false;
            }
        }
    }
}
