﻿using GiaoDienPBL3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginPage
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
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
            if (txtTaiKhoan.Text == "1" && txtMatKhau.Text == "1")
            {
                this.Hide();
                frmMain Main = new frmMain();
                Main.ShowDialog();
            }
            ShowThongBao("Tên Tài Khoản Hoặc Mật Khẩu Sai" + Environment.NewLine + "VUI LÒNG NHẬP LẠI!!!");
            //showNotification("Tên Tài Khoản Hoặc Mật Khẩu Sai");
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
    }
}
