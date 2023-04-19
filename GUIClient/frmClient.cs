using BLL;
using DTO;
using GiaoDienPBL3;
using GiaoDienPBL3.UC;
using GUIClient.User_Controls;
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

namespace GUIClient
{
    public partial class frmClient : Form
    {
        private Customer customer;
        public static UC_TrangChuKhachHang myUC_TrangChuKhachHang;
        //public static UC_QuanLyMenu myUC_QuanLyMenu = new UC_QuanLyMenu();
        public static UC_NapGioChoi myUC_NapGioChoi = new UC_NapGioChoi();
        public frmClient(string accountId)
        {
            InitializeComponent();
            customer = CustomerBLL.Instance.GetCustomerByID(accountId);
            myUC_TrangChuKhachHang = new UC_TrangChuKhachHang(customer);
        }
        private void frmClient_Load(object sender, EventArgs e)
        {
            AddUserControlOnBackGround(myUC_TrangChuKhachHang);
            lblTenKhachHang.Text = customer.CustomerName;
            if (customer.TypeCustomer) lblLoaiKhachHang.Text = "Khách Hàng VIP";
            else lblLoaiKhachHang.Text = "Khách Hàng Thường";
        }
        private void imgbtnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void SetOffAllCheckStateButton()
        {
            btnMenu.Checked = false;
            btnNapGioChoi.Checked = false;
            btnTrangChu.Checked = false;
        }
        private void SetOnCheckStateButton(Guna2Button btn)
        {
            SetOffAllCheckStateButton();
            btn.Checked = true;
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            SetOnCheckStateButton(btn);
            AddUserControlOnBackGround(myUC_TrangChuKhachHang);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            SetOnCheckStateButton(btn);
            AddUserControlOnBackGround(frmMain.myUC_QuanLyMenu);
        }

        private void btnNapGioChoi_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            SetOnCheckStateButton(btn);
            AddUserControlOnBackGround(myUC_NapGioChoi);
        }
        private void AddUserControlOnBackGround(UserControl userControl)
        {
            panelBackGround.Controls.Clear();
            panelBackGround.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
        }

        //Hàm đếm ngược thời gian còn lại
        public void CountDownTimer(float totaltime)
        {
            txtTime.Text = totaltime.ToString();
        }
    }
}
