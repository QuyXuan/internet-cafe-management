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
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIClient
{
    public partial class frmClient : Form
    {
        private string accountId;
        public static Computer computer;
        public static TypeComputer typeComputer;
        public static Customer customer;
        public static UC_TrangChuKhachHang myUC_TrangChuKhachHang;
        public static UC_NapGioChoi myUC_NapGioChoi;
        public static UC_DongHo myUC_DongHo;
        public static frmDongHo DongHo;
        public frmClient(string accountId, Computer computer)
        {
            InitializeComponent();
            this.accountId = accountId;
            frmClient.computer = computer;
            customer = CustomerBLL.Instance.GetCustomerByAccountId(accountId);
            myUC_TrangChuKhachHang = new UC_TrangChuKhachHang();
            typeComputer = ComputerBLL.Instance.GetTypeComputerByTypeId(computer.TypeId);
            myUC_NapGioChoi = new UC_NapGioChoi();
            myUC_NapGioChoi.sendBalance += new UC_NapGioChoi.SendBalance(SetBalance);
            myUC_DongHo = new UC_DongHo(this.Handle);
            myUC_DongHo.checkaccess += new UC_DongHo.CheckAccess(CheckAccess);
        }
        private void frmClient_Load(object sender, EventArgs e)
        {
            AddUserControlOnBackGround(myUC_TrangChuKhachHang);
            SetDongHo();
            lblTenKhachHang.Text = customer.CustomerName;
            if (customer.TypeCustomer) lblLoaiKhachHang.Text = "Khách Hàng VIP";
            else lblLoaiKhachHang.Text = "Khách Hàng Thường";
            SetBalance((float)customer.Balance);
            CheckAccess(myUC_DongHo.getCurrentTime());
        }
        private void imgbtnThoat_Click(object sender, EventArgs e)
        {
            frmLoginClient frmLoginClient = new frmLoginClient();
            CustomerBLL.Instance.SetTotalTime(myUC_DongHo.getCurrentTime(), customer.CustomerId, typeComputer.NameType);
            frmLoginClient.Show();
            Dispose();
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

        public void SetDongHo()
        {
            panelDongHo.Controls.Clear();
            panelDongHo.Controls.Add(myUC_DongHo);
        }

        private void btnMinisize_Click(object sender, EventArgs e)
        {
            DongHo = new frmDongHo(this.Handle);
            DongHo.Show();
        }

        //Hàm Set Số dư
        public void SetBalance(double balance)
        {
            lblSoDu.Text = string.Format("{0:N3}VNĐ", balance);
            customer = CustomerBLL.Instance.GetCustomerByAccountId(accountId);
            myUC_TrangChuKhachHang.setThongTinCaNhan(customer);
        }

        //Hàm kiểm tra khả năng truy cập vào máy
        public void CheckAccess(Time time)
        {
            if(time.hour == 0 && time.minute == 0 && time.second == 0)
            {
               btnMinisize.Visible = false;
            }
            else
            {
                btnMinisize.Visible = true;
            }
        }
        //Hàm tránh tắt chương trình
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {

                case Keys.Control:
                    {
                        return true;
                    }

                case Keys.Alt | Keys.F4:
                    {
                        return true;
                    }

                case Keys.Alt | Keys.Control | Keys.Delete:
                    {
                        return true;
                    }

                case Keys.Control | Keys.Q:
                    {
                        return true;
                    }
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
