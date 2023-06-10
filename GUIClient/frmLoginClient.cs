using BLL;
using DTO;
using GiaoDienPBL3;
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
    public partial class frmLoginClient : Form
    {
        public frmLoginClient()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }
        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (txtMatKhau.Text.Length > 0)
            {
                if (chkHienThiMatKhau.Checked == true)
                {
                    txtMatKhau.PasswordChar = '\0';
                }
                else
                {
                    txtMatKhau.PasswordChar = '*';
                }
            }
            else
            {
                txtMatKhau.PasswordChar = '\0';
            }
        }
        private void chkHienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == string.Empty) return;
            if (chkHienThiMatKhau.Checked == true)
            {
                txtMatKhau.PasswordChar = '\0';
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
            }
            txtMatKhau.Focus();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (ConnectionBLL.Instance.hasInternetAccess())
            {
                string AccountId = null;
                bool Role = false, checkTK = false;
                if (AccountBLL.Instance.CheckDangNhap(txtTaiKhoan.Text, txtMatKhau.Text))
                {
                    checkTK = true;

                    AccountId = AccountBLL.Instance.GetAccountIdByUserName(txtTaiKhoan.Text);
                    KeyValuePair<string, string>? TenVaVaiTro = AccountBLL.Instance.GetTenVaVaiTro(AccountId);

                    if (TenVaVaiTro == null) Role = true;
                }

                Computer computer = ComputerBLL.Instance.GetComputerByIP();
                bool CheckComputer = false;
                if (computer == null) CheckComputer = true;

                if (checkTK && Role == false)
                {
                    this.Hide();
                    frmClient Client = new frmClient(AccountId, computer, Role, CheckComputer);
                    Client.ShowDialog();
                }

                else if (computer != null)
                {
                    if (computer.Status != "Bảo Trì")
                    {
                        if (checkTK && Role == true)
                        {
                            if (ComputerBLL.Instance.CheckLogin(AccountId))
                            {
                                this.Hide();
                                frmClient Client = new frmClient(AccountId, computer, Role, CheckComputer);
                                Client.ShowDialog();
                            }
                            else ShowThongBao("Tài khoản của bạn đang được đăng nhập vào máy khác" + Environment.NewLine + "VUI LÒNG KIỂM TRA LẠI!!!");
                        }
                        else ShowThongBao("Tên Tài Khoản Hoặc Mật Khẩu Sai" + Environment.NewLine + "VUI LÒNG NHẬP LẠI!!!");
                    }
                    else ShowThongBao("Máy đang bảo trì" + Environment.NewLine + "VUI LÒNG TRỞ LẠI SAU!!!");
                }
                else ShowThongBao("Máy không nằm trong hệ thống" + Environment.NewLine + "VUI LÒNG KIỂM TRA LẠI!!!");
            }
            else ShowThongBao("Mất kết nối" + Environment.NewLine + "VUI LÒNG KẾT NỐI MẠNG!!!");
        }
        private async void ShowThongBao(string message)
        {
            lblThongBao.Visible = true;
            lblThongBao.Text = message;
            while (lblThongBao.Visible)
            {
                await Task.Delay(3000);
                lblThongBao.Visible = false;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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
