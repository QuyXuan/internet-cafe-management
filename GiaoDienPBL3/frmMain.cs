﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL;
using GiaoDienPBL3.UC;
using GiaoDienPBL3.User_Controls;
using Guna.UI2.WinForms;

namespace GiaoDienPBL3
{
    public partial class frmMain : Form
    {
        public static string AccountId;
        public static UC_TrangChu myUC_TrangChu = new UC_TrangChu();
        public static UC_QuanLyMenu myUC_QuanLyMenu = new UC_QuanLyMenu();
        public static UC_QuanLyMay myUC_QuanLyMay = new UC_QuanLyMay();
        public static UC_QuanLyKho myUC_QuanLyKho = new UC_QuanLyKho();
        public static UC_QuanLyHoaDon myUC_QuanLyHoaDon = new UC_QuanLyHoaDon();
        public static UC_QuanLyDoanhThu myUC_QuanLyDoanhThu = new UC_QuanLyDoanhThu();
        public static UC_QuanLyHoaDonNhapKho myUC_QuanLyHoaDonNhapKho = new UC_QuanLyHoaDonNhapKho();
        public static UC_QuanLyCaLamViec myUC_QuanLyCaLamViec = new UC_QuanLyCaLamViec();
        public static UC_QuanLyKhachHang myUC_QuanLyKhachHang = new UC_QuanLyKhachHang();
        public static UC_Loading myUC_Loading = new UC_Loading();

        public frmMain(string accountId = null)
        {
            InitializeComponent();
            AccountId = accountId;
        }

        private void imgbtnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KeyValuePair<string, string>? TenVaVaiTro = AccountBLL.Instance.GetTenVaVaiTro(AccountId);
            lblTen.Text = TenVaVaiTro.Value.Key;
            lblVaiTro.Text = TenVaVaiTro.Value.Value;
            TurnOffAllPanelQuanLy();
            SetOffAllCheckStateButton();
            AddUserControlOnBackGround(myUC_TrangChu);
            btnTrangChu.Checked = true;
            imgbtnThoat.Location = new Point(12, 750);
            myUC_TrangChu.Visible = true;
        }
        private void SetOffAllCheckStateButton()
        {
            btnQuanLyMenu.Checked = false;
            btnQuanLyMay.Checked = false;
            btnQuanLyDoanhThu.Checked = false;
            btnQuanLyKhachHang.Checked = false;
            btnQuanLyKho.Checked = false;
            btnQuanLyNhanVien.Checked = false;
            btnCaiDat.Checked = false;
            btnTrangChu.Checked = false;
        }

        private void SetOnCheckStateButton(Guna2Button btn)
        {
            SetOffAllCheckStateButton();
            btn.Checked = true;
        }

        private void HideSubMenu()
        {
            if (panelQuanLyMenu.Visible == true)
                panelQuanLyMenu.Visible = false;
            if (panelQuanLyKho.Visible == true)
                panelQuanLyKho.Visible = false;
            if (panelQuanLy3.Visible == true)
                panelQuanLy3.Visible = false;
            if (panelCaiDat.Visible == true)
                panelCaiDat.Visible = false;
        }

        private void TurnOffAllPanelQuanLy()
        {
            panelQuanLyMenu.Visible = false;
            panelQuanLyKho.Visible = false;
            panelQuanLy3.Visible = false;
            panelCaiDat.Visible = false;
        }


        private void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void btnQuanLyMenu_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            SetOnCheckStateButton(btn);
            ShowSubMenu(panelQuanLyMenu);
        }

        private void btnQuanLyKho_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            SetOnCheckStateButton(btn);
            ShowSubMenu(panelQuanLyKho);
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            SetOnCheckStateButton(btn);
            ShowSubMenu(panelQuanLy3);
        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            SetOnCheckStateButton(btn);
            ShowSubMenu(panelCaiDat);
        }

        private void AddUserControlOnBackGround(UserControl userControl)
        {
            myUC_Loading.Visible = true;
            myUC_Loading.circlerProgressBarLoad.Value = 0;
            panelBackGround.Controls.Clear();
            panelBackGround.Controls.Add(myUC_Loading);
            panelBackGround.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            SetOnCheckStateButton(btn);
            HideSubMenu();
            AddUserControlOnBackGround(myUC_TrangChu);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            AddUserControlOnBackGround(myUC_QuanLyMenu);
        }

        private void btnQuanLyMay_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            SetOnCheckStateButton(btn);
            HideSubMenu();
            AddUserControlOnBackGround(myUC_QuanLyMay);
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            AddUserControlOnBackGround(myUC_QuanLyKho);
        }

        private void btnQuanLyHoaDon_Click(object sender, EventArgs e)
        {
            myUC_QuanLyHoaDon.ResetData();
            myUC_QuanLyHoaDon.SetData();
            AddUserControlOnBackGround(myUC_QuanLyHoaDon);
        }

        private void btnQuanLyDoanhThu_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            SetOnCheckStateButton(btn);
            HideSubMenu();
            AddUserControlOnBackGround(myUC_QuanLyDoanhThu);
        }

        private void btnQuanLyHoaDonNhap_Click(object sender, EventArgs e)
        {
            AddUserControlOnBackGround(myUC_QuanLyHoaDonNhapKho);
        }

        private void btnQuanLyCaLamViec_Click(object sender, EventArgs e)
        {
            AddUserControlOnBackGround(myUC_QuanLyCaLamViec);
        }

        private void btnQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            SetOnCheckStateButton(btn);
            HideSubMenu();
            AddUserControlOnBackGround(myUC_QuanLyKhachHang);
        }
    }
}
