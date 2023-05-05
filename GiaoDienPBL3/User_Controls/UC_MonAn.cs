using BLL;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GiaoDienPBL3.UC
{
    public partial class UC_MonAn : UserControl
    {
        private Panel panelHetMon;
        private Label lblHetMon;
        public Image ImagePanel
        {
            get { return picMonAn.Image; }
            set { picMonAn.Image = value; }
        }
        
        public string TextGiaMonAn
        {
            get { return lblGiaMonAn.Text.Trim(); }
            set { lblGiaMonAn.Text = value; }
        }

        public string TextTenMonAn
        {
            get { return lblTenMonAn.Text.Trim(); }
            set { lblTenMonAn.Text = value; }
        }

        public UC_MonAn()
        {
            InitializeComponent();
            SetPanelHetMon();
        }

        private void ChinhMauVienMonAn()
        {
            if (panelBackGroundMonAn.BackColor == Color.Transparent)
                panelBackGroundMonAn.BackColor = Color.FromArgb(4, 121, 171);
            else
                panelBackGroundMonAn.BackColor = Color.Transparent;
        }

        private void ThemChiTietMonAnVaoFlowLayoutPanel(string Role)
        {
            UC_ChiTietMonAn myUCChiTietMonAn = new UC_ChiTietMonAn();
            myUCChiTietMonAn.TextTenMonAn = lblTenMonAn.Text;
            myUCChiTietMonAn.TextGiaMonAn = lblGiaMonAn.Text;
            myUCChiTietMonAn.TextSoLuongMonAn = 1 + "";
            lblTenMonAn.Tag = (Convert.ToInt32(lblTenMonAn.Tag) + 1).ToString();
            myUCChiTietMonAn.Width = 265;
            myUCChiTietMonAn.Tag = this;
            if (Role == "Manager")
            {
                frmMain.myUC_QuanLyMenu.panelChiTietMonAn.Controls.Add(myUCChiTietMonAn);
            }
            else
            {
                frmMain.myUC_MenuClient.panelChiTietMonAn.Controls.Add(myUCChiTietMonAn);
            }
        }

        private void HienThiVaTinhTongTien(string Role)
        {
            if (Role == "Manager")
            {
                int TongTien = Convert.ToInt32(frmMain.myUC_QuanLyMenu.lblTongTien.Tag);
                TongTien += Convert.ToInt32(lblGiaMonAn.Text.Substring(0, lblGiaMonAn.Text.Length - 7));
                frmMain.myUC_QuanLyMenu.lblTongTien.Text = string.Format("{0:N3}VNĐ", TongTien);
                frmMain.myUC_QuanLyMenu.lblTongTien.Tag = TongTien;
            }
            else
            {
                int TongTien = Convert.ToInt32(frmMain.myUC_MenuClient.lblTongTien.Tag);
                TongTien += Convert.ToInt32(lblGiaMonAn.Text.Substring(0, lblGiaMonAn.Text.Length - 7));
                frmMain.myUC_MenuClient.lblTongTien.Text = string.Format("{0:N3}VNĐ", TongTien);
                frmMain.myUC_MenuClient.lblTongTien.Tag = TongTien;
            }
        }

        private void picMonAn_Click(object sender, EventArgs e)
        {
            string Role = ((sender as PictureBox).Parent.Parent as UserControl).Tag.ToString().Split(',')[0];
            if (Role == "Manager" && CheckUCMenuFromUcHoaDon())
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Bạn Không Thể Thay Đổi Món Ăn Trong Hóa Đơn Này");
                return;
            }
            //kiểm tra xem có chọn món ăn trong lúc chỉnh sửa không
            if (Role == "Manager" && UC_QuanLyMenu.my_UCThongTinVaCaiDatMonAn.txtMaMonAn.Text != "")
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Bạn Không Thể Chọn Món Ăn Trong Lúc Chỉnh Sửa");
                return;
            }
            if (lblGiaMonAn.Text == lblTenMonAn.Text)
            {
                if (panelBackGroundMonAn.BackColor == Color.Transparent)
                {
                    if (Role == "Manager")
                    {
                        frmMain.myUC_QuanLyMenu.panelXacNhanLuaChon.Visible = true;
                    }
                    else
                    {
                        frmMain.myUC_MenuClient.panelXacNhanLuaChon.Visible = true;
                    }
                    panelBackGroundMonAn.BackColor = Color.FromArgb(4, 121, 171);
                }
                else
                {
                    if (Role == "Manager")
                    {
                        frmMain.myUC_QuanLyMenu.panelXacNhanLuaChon.Visible = false;
                    }
                    else
                    {
                        frmMain.myUC_MenuClient.panelXacNhanLuaChon.Visible = false;
                    }
                    panelBackGroundMonAn.BackColor = Color.Transparent;
                }
                return;
            }
            if (panelBackGroundMonAn.BackColor == Color.FromArgb(4, 121, 171)) return;
            ChinhMauVienMonAn();
            ThemChiTietMonAnVaoFlowLayoutPanel(Role);
            HienThiVaTinhTongTien(Role);
        }
        //Kiểm tra xem có thêm món ăn vào cái hóa đơn món ăn của khách hàng không
        private bool CheckUCMenuFromUcHoaDon()
        {
            foreach (Control control in frmMain.myUC_QuanLyMenu.panelChiTietMonAn.Controls)
            {
                UC_ChiTietMonAn myUC_ChiTietMonAn = control as UC_ChiTietMonAn;
                if (myUC_ChiTietMonAn != null && myUC_ChiTietMonAn.btnXoaMon.Visible == false)
                {
                    return true;
                }
            }
            return false;
        }
        private void msDaHetMon_Click(object sender, EventArgs e)
        {
            if (panelBackGroundMonAn.BackColor != Color.Transparent)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Món Ăn Này Đang Được Chọn" + Environment.NewLine + "Không Thể Đặt Hết Món");
                return;
            }
            picMonAn.Controls.Add(panelHetMon);
            picMonAn.BringToFront();
            panelHetMon.BringToFront();
            string ProductId = (this.Tag as string).Split(',')[1];
            //false co nghia la mon an da bi khoa
            ProductBLL.Instance.SetStatusProduct(ProductId, false);
        }
        private void SetPanelHetMon()
        {
            panelHetMon = new Panel();
            panelHetMon.BackColor = Color.FromArgb(150, 0, 0, 0);
            panelHetMon.Dock = DockStyle.Fill;
            lblHetMon = new Label();
            lblHetMon.Text = "Đã Hết Món";
            lblHetMon.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblHetMon.BackColor = Color.FromArgb(150, 255, 153, 153);
            lblHetMon.ForeColor = Color.Black;
            lblHetMon.TextAlign = ContentAlignment.MiddleCenter;
            panelHetMon.Controls.Add(lblHetMon);
            lblHetMon.Location = new Point((this.Size.Width - lblHetMon.Size.Width) / 2, (this.Size.Height - lblHetMon.Size.Height) / 2);
        }

        private void msDaCoMon_Click(object sender, EventArgs e)
        {
            picMonAn.Controls.Remove(panelHetMon);
            panelTenMonAn.BringToFront();
            panelGiaMonAn.BringToFront();
            string ProductId = (this.Tag as string).Split(',')[1];
            //true co nghia la mon an da dc mo lai
            ProductBLL.Instance.SetStatusProduct(ProductId, true);
        }

        private void msChinhSua_Click(object sender, EventArgs e)
        {
            if (panelBackGroundMonAn.BackColor != Color.Transparent)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Món Ăn Đang Được Chọn" + Environment.NewLine + "Không Thể Chỉnh Sửa");
                return;
            }
            string productName = lblTenMonAn.Text;
            if (UC_QuanLyMenu.my_UCThongTinVaCaiDatMonAn.txtMaMonAn.Text == "")
            {
                Product product = ProductBLL.Instance.GetProductByProductName(productName);
                if (product != null)
                {
                    UC_QuanLyMenu.my_UCThongTinVaCaiDatMonAn.txtMaMonAn.Text = product.ProductId;
                }
            }
            else
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Không Thể Chỉnh Sửa Cùng Lúc Nhiều Món Ăn");
                return;
            }
            frmMain.myUC_QuanLyMenu.panelCaiDatVaThongTin.SendToBack();
        }
    }
}
