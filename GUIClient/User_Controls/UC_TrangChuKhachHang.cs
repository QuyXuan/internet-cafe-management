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
        public UC_ChiTietMonAn my_UCChiTietMonAn;
        //private bool checkBtnXacNhan = false;
        public UC_TrangChuKhachHang()
        {
            InitializeComponent();
            if(frmClient.Role)
            {
                setThongTinCaNhan(frmClient.customer);
                SetThongTinGiamGia(frmClient.customer);
                panelGiamGia.Text = "Giảm Giá Của Tôi";
                txtIPV4.Visible = false;
                dgvGiamGia.Visible = true;
            }
            else
            {
                btnCapNhatMatKhau.Enabled = false;
                panelGiamGia.Text = "Địa Chỉ IPv4";
                dgvGiamGia.Visible = false;
                txtIPV4.Visible = true;
                SetIPv4();
            }
            lblThongBao.Visible = false;
        }

        public void setThongTinCaNhan(Customer customer)
        {
            lblMaKhachHang.Text = customer.CustomerId;
            lblTenKhachHang.Text = customer.CustomerName;
            if (customer.TypeCustomer) lblLoaiTaiKhoan.Text = "Khách Hàng VIP";
            else lblLoaiTaiKhoan.Text = "Khách Hàng Thường";
            lblSoDuTaiKhoan.Text = string.Format("{0:N3}VNĐ", customer.Balance);
            lblTenTaiKhoan.Text = AccountBLL.Instance.GetAccountByID(customer.AccountId).UserName;
        }

        public void SetThongTinGiamGia(Customer customer)
        {
            dgvGiamGia.DataSource = DiscountBLL.Instance.GetListDiscountWithType(customer.TypeCustomer);
            dgvGiamGia.Columns[0].Visible = false;
            dgvGiamGia.Columns[1].HeaderText = "Tên giảm giá";
            dgvGiamGia.Columns[2].HeaderText = "Phần trăm";
            dgvGiamGia.Columns[3].Visible = false;
            dgvGiamGia.Columns[4].Visible = false;
        }

        public void SetIPv4()
        {
            txtIPV4.ReadOnly = true;
            txtIPV4.Text = ComputerBLL.Instance.GetMyIP();
        }

        private void btnCapNhatMatKhau_Click(object sender, EventArgs e)
        {
            if (txtMatKhauCu.Text != string.Empty && txtMatKhauMoi.Text != string.Empty && txtXacNhanMatKhau.Text != string.Empty)
            {
                string message = AccountBLL.Instance.CheckDoiMatKhau(frmClient.customer.AccountId, txtMatKhauCu.Text, txtMatKhauMoi.Text, txtXacNhanMatKhau.Text);
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
