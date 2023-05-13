using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using GiaoDienPBL3.User_Controls;
using Guna.UI2.WinForms;

namespace GiaoDienPBL3.UC
{

    public partial class UC_ChiTietMonAn : UserControl
    {
        public string TextSoLuongMonAn
        {
            get { return lblSoLuongMon.Text.Trim(); }
            set { lblSoLuongMon.Text = value; }
        }
        public string TextTenMonAn
        {
            get { return lblTenMon.Text.Trim(); }
            set { lblTenMon.Text = value; }
        }
        public string TextGiaMonAn
        {
            get { return lblGiaMon.Text.Trim(); }
            set { lblGiaMon.Text = value; }
        }
        public UC_ChiTietMonAn()
        {
            InitializeComponent();
        }
        private string ChuyenDoiGiaMon(string GiaMon)
        {
            GiaMon = GiaMon.Substring(0, GiaMon.Length - 7);
            return GiaMon;
        }

        private void btnCongTruXoaMon_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            string Role = " ";
            string ProductId = " ";
            if ((btn.Parent).Parent.Tag is string)
            {
                Role = (btn.Parent).Parent.Tag as string;
            }
            else
            {
                Role = (((btn.Parent).Parent.Tag as UC_MonAn).Tag as string).Split(',')[0];
                ProductId = (((btn.Parent).Parent.Tag as UC_MonAn).Tag as string).Split(',')[1];
            }
            int TongTien = 0;
            if (Role == "Manager")
            {
                TongTien = Convert.ToInt32(frmMain.myUC_QuanLyMenu.lblTongTien.Tag);
            }
            else if (Role == "Client")
            {
                TongTien = Convert.ToInt32(frmMain.myUC_MenuClient.lblTongTien.Tag);
            }
            int GiaMon = Convert.ToInt32(ChuyenDoiGiaMon(lblGiaMon.Text).Replace(",", ""));
            if (btn.Text == "+")
            {
                if (lblTenMon.Text != "Nạp Tiền")
                {
                    int SoLuong = Convert.ToInt32(lblSoLuongMon.Text) + 1;
                    if (!ProductBLL.Instance.CheckStockProduct(ProductId, SoLuong))
                    {
                        frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Số Lượng Món Ăn Không Đủ Để Phục Vụ");
                        return;
                    }
                    lblSoLuongMon.Text = (Convert.ToInt32(lblSoLuongMon.Text) + 1).ToString();
                    //TongTien += GiaMon;
                    if (Role == "Manager")
                    {
                        UC_QuanLyMenu.TotalMoney += GiaMon;
                    }
                    else if (Role == "Client")
                    {
                        UC_MenuClient.TotalMoney += GiaMon;
                    }
                }
            }
            else if (btn.Name == "btnXoaMon")
            {
                if (Role == "Kho")
                {
                    //string tien = frmMain.myUC_QuanLyHoaDonNhapKho.lblTongTien.Text;
                    //int Tien = Convert.ToInt32(tien.Substring(0, tien.Length - 7).Replace(",", ""));
                    //int tienMonAn = Convert.ToInt32(this.TextGiaMonAn.Substring(0, this.TextGiaMonAn.Length - 7).Replace(",", ""));
                    int giamGia = 0;
                    if (frmMain.myUC_QuanLyHoaDonNhapKho.txtGiamGia.Text != "")
                    {
                        giamGia = Convert.ToInt32(frmMain.myUC_QuanLyHoaDonNhapKho.txtGiamGia.Text);
                    }
                    UC_QuanLyHoaDonNhapKho.TotalMoney -= Convert.ToInt32(TextGiaMonAn.Substring(0, TextGiaMonAn.Length - 7).Replace(",", ""));
                    frmMain.myUC_QuanLyHoaDonNhapKho.lblTongTien.Text = string.Format("{0:N3}VNĐ", Math.Ceiling(UC_QuanLyHoaDonNhapKho.TotalMoney / 100 * (100 - giamGia)));
                    frmMain.myUC_QuanLyHoaDonNhapKho.panelHoaDon.Controls.Remove(this);
                    this.Dispose();
                    return;
                }
                if (Role == "Manager")
                {
                    UC_QuanLyMenu.TotalMoney -= GiaMon * Convert.ToInt32(lblSoLuongMon.Text);

                }
                else if (Role == "Client")
                {
                    UC_MenuClient.TotalMoney -= GiaMon * Convert.ToInt32(lblSoLuongMon.Text);
                }
                //TongTien -= GiaMon * Convert.ToInt32(lblSoLuongMon.Text);
                if (lblTenMon.Text == "Nạp Tiền")
                {
                    if (Role == "Manager")
                    {
                        frmMain.myUC_QuanLyMenu.panelChiTietMonAn.Controls.Remove(this);
                        frmMain.myUC_QuanLyMenu.checkBtnXacNhan = false;
                    }
                    else if (Role == "Client")
                    {
                        frmMain.myUC_MenuClient.panelChiTietMonAn.Controls.Remove(this);
                        frmMain.myUC_MenuClient.checkBtnXacNhan = false;
                    }
                    
                }
                else if (btnCongMon.Visible == false)
                {
                    frmMain.myUC_QuanLyHoaDonNhapKho.panelHoaDon.Controls.Remove(this);
                    int Gia = Convert.ToInt32(lblGiaMon.Text.Substring(0,
                        lblGiaMon.Text.Length - 7).Replace(",", ""));
                    string Tien = frmMain.myUC_QuanLyHoaDonNhapKho.lblTongTien.Text;
                    frmMain.myUC_QuanLyHoaDonNhapKho.lblTongTien.Text = string.Format("{0:N3}VNĐ",
                        (Convert.ToInt32(Tien.Substring(0, Tien.Length - 7).Replace(",", "")) - Gia));
                }
                else
                {
                    if (Role == "Manager")
                    {
                        frmMain.myUC_QuanLyMenu.panelChiTietMonAn.Controls.Remove(this);
                    }
                    else
                    {
                        frmMain.myUC_MenuClient.panelChiTietMonAn.Controls.Remove(this);
                    }
                    UC_MonAn myUCMonAn = this.Tag as UC_MonAn;
                    myUCMonAn.panelBackGroundMonAn.BackColor = Color.Transparent;
                }
            }
            else if (lblSoLuongMon.Text == "1")
            {
                if (lblTenMon.Text != "Nạp Tiền")
                {
                    if (Role == "Manager")
                    {
                        frmMain.myUC_QuanLyMenu.panelChiTietMonAn.Controls.Remove(this);
                    }
                    else
                    {
                        frmMain.myUC_MenuClient.panelChiTietMonAn.Controls.Remove(this);
                    }
                    if (Role == "Manager")
                    {
                        UC_QuanLyMenu.TotalMoney -= GiaMon;
                    }
                    else
                    {
                        UC_MenuClient.TotalMoney -= GiaMon;
                    }
                    //TongTien -= GiaMon;
                    UC_MonAn myUCMonAn = this.Tag as UC_MonAn;
                    myUCMonAn.panelBackGroundMonAn.BackColor = Color.Transparent;
                }
            }
            else
            {
                lblSoLuongMon.Text = (Convert.ToInt32(lblSoLuongMon.Text) - 1).ToString();
                if (Role == "Manager")
                {
                    UC_QuanLyMenu.TotalMoney -= GiaMon;
                }
                else if (Role == "Client")
                {
                    UC_MenuClient.TotalMoney -= GiaMon;
                }
                //TongTien -= GiaMon;
            }
            if (Role == "Manager")
            {
                int GiamGia = Convert.ToInt32(frmMain.myUC_QuanLyMenu.txtTongGiamGia.Text.Substring(0, frmMain.myUC_QuanLyMenu.txtTongGiamGia.Text.Length - 2));
                frmMain.myUC_QuanLyMenu.lblTongTien.Text = string.Format("{0:N3}VNĐ", Math.Ceiling(UC_QuanLyMenu.TotalMoney / 100 * (100 - GiamGia)));
                frmMain.myUC_QuanLyMenu.lblTongTien.Tag = UC_QuanLyMenu.TotalMoney;
            }
            else
            {
                int GiamGia = Convert.ToInt32(frmMain.myUC_MenuClient.txtTongGiamGia.Text.Substring(0, frmMain.myUC_MenuClient.txtTongGiamGia.Text.Length - 2));
                frmMain.myUC_MenuClient.lblTongTien.Text = string.Format("{0:N3}VNĐ", Math.Ceiling(UC_MenuClient.TotalMoney / 100 * (100 - GiamGia)));
                frmMain.myUC_MenuClient.lblTongTien.Tag = UC_MenuClient.TotalMoney;
            }
        }
    }
}
