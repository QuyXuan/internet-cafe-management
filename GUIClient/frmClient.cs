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
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int SW_RESTORE = 9;

        private string IPComputer;
        private Computer computer;
        private TypeComputer typeComputer;
        private Customer customer;
        private Time time;
        public static UC_TrangChuKhachHang myUC_TrangChuKhachHang;
        //public static UC_QuanLyMenu myUC_QuanLyMenu = new UC_QuanLyMenu();
        public static UC_NapGioChoi myUC_NapGioChoi;
        public frmClient(string accountId)
        {
            
            InitializeComponent();
            customer = CustomerBLL.Instance.GetCustomerByAccountId(accountId);
            myUC_TrangChuKhachHang = new UC_TrangChuKhachHang(customer);
            IPComputer = ComputerBLL.Instance.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(IPComputer))
            {
                IPComputer = ComputerBLL.Instance.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
            computer = ComputerBLL.Instance.GetComputerByIP(IPComputer);
            typeComputer = ComputerBLL.Instance.GetTypeComputerByTypeId(computer.TypeId);
            myUC_NapGioChoi = new UC_NapGioChoi(computer, typeComputer);
            float changtime = TimerBLL.Instance.ChangeTime((float)customer.TotalTime, typeComputer.NameType);
            time = TimerBLL.Instance.TranferTime(changtime);
        }
        private void frmClient_Load(object sender, EventArgs e)
        {
            AddUserControlOnBackGround(myUC_TrangChuKhachHang);
            lblTenKhachHang.Text = customer.CustomerName;
            if (customer.TypeCustomer) lblLoaiKhachHang.Text = "Khách Hàng VIP";
            else lblLoaiKhachHang.Text = "Khách Hàng Thường";
            lblHr.Text = time.hour.ToString();
            lblMin.Text = time.minute.ToString();
            lblSec.Text = time.second.ToString();
            timer1.Enabled = true;
        }
        private void imgbtnThoat_Click(object sender, EventArgs e)
        {
            frmLoginClient frmLoginClient = new frmLoginClient();
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

        //Hàm đếm ngược thời gian còn lại
        private void timer1_Tick(object sender, EventArgs e)
        {
            Time time = new Time(Convert.ToInt32(lblHr.Text), Convert.ToInt32(lblMin.Text), Convert.ToInt32(lblSec.Text)); 
            if ((time.hour == 0) && (time.minute == 0) && (time.second == 0))
            {
                timer1.Enabled = false;
                Console.Beep();
                // Lấy handle của cửa sổ muốn hiển thị lại
                IntPtr hWnd = this.Handle;
                // Hiển thị lại cửa sổ
                ShowWindow(hWnd, SW_RESTORE);
                //btnMinisize.Visible = false;
            }
            else
            {
                time = TimerBLL.Instance.timertick(time.hour,time.minute,time.second);
                lblHr.Text = time.hour.ToString();
                lblMin.Text = time.minute.ToString();
                lblSec.Text = time.second.ToString();
            }
        }
    }
}
