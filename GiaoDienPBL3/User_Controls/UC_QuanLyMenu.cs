using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
using GiaoDienPBL3.User_Controls;
using Guna.UI2.WinForms;

namespace GiaoDienPBL3.UC
{
    public partial class UC_QuanLyMenu : UserControl
    {
        public static UC_ThongTinVaCaiDatMonAn my_UCThongTinVaCaiDatMonAn;
        public UC_ChiTietMonAn my_UCChiTietMonAn;
        private bool checkBtnCaiDat = false;
        public static bool checkBtnXacNhan = false;
        //kiểm tra đây là form admin hay là client, false là admin
        private bool checkFormAdminOrClient = false;
        public UC_QuanLyMenu()
        {
            InitializeComponent();
            my_UCThongTinVaCaiDatMonAn = new UC_ThongTinVaCaiDatMonAn();
            AddUC();
        }
        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            if (checkBtnCaiDat == false)
            {
                panelCaiDatVaThongTin.SendToBack();
                checkBtnCaiDat = true;
            }
            else
            {
                panelCaiDatVaThongTin.BringToFront();
                checkBtnCaiDat = false;
            }
        }
        private void AddUC()
        {
            panelThongTinChiTietMonAn.Controls.Add(my_UCThongTinVaCaiDatMonAn);
            my_UCThongTinVaCaiDatMonAn.Dock = DockStyle.Fill;
            panelCaiDatVaThongTin.BringToFront();
        }
        private void UC_QuanLyMenu_Load(object sender, EventArgs e)
        {
            SetFullMonAn();
        }
        private void SetFullMonAn()
        {
            List<Product> listProduct = ProductBLL.Instance.GetListProduct();
            foreach (Product item in listProduct)
            {
                AddMonAn(item);
            }
        }
        private void AddMonAn(Product product)
        {
            UC_MonAn my_UCMonAn = new UC_MonAn();
            my_UCMonAn.TextGiaMonAn = string.Format("{0:N3}VNĐ", product.SellingPrice);
            my_UCMonAn.TextTenMonAn = product.ProductName;
            my_UCMonAn.ImagePanel = GetAnhByPathAnhMon(product.ImageFilePath);
            my_UCMonAn.Tag = product;
            //if (checkFormAdminOrClient == true)
            //{

            //}
            frmMain.myUC_QuanLyMenu.panelMonAn.Controls.Add(my_UCMonAn);
        }
        private Image GetAnhByPathAnhMon(string nameImg)
        {
            string imgFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace(@"GiaoDienPBL3\bin\Debug", ""), "img", nameImg);
            try
            {
                Image image = Image.FromFile(imgFilePath);
                checkFormAdminOrClient = false;
                return image;
            }
            catch (FileNotFoundException)
            {
                imgFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace(@"\GUIClient\bin\Debug", ""), "img", nameImg);
                Image image = Image.FromFile(imgFilePath);
                image = Image.FromFile(imgFilePath);
                checkFormAdminOrClient = true;
                return image;
            }
            catch (Exception)
            {
                return null;
            }
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (checkBtnXacNhan == false)
            {
                my_UCChiTietMonAn = new UC_ChiTietMonAn();
            }
            if ((cboMenhGia.Text.Length < 4) || cboMenhGia.Text.Substring(cboMenhGia.Text.Length - 4) != ".000")
            {
                MessageBox.Show("Bạn Phải Nhập Theo Định Dạng #,###.000" + Environment.NewLine + "Ví Dụ: 20.000 / 1,000.000", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            ThemChiTietMonAnVaoFlowLayoutPanel();
            HienThiVaTinhTongTien();
            checkBtnXacNhan = true;
        }
        private void ThemChiTietMonAnVaoFlowLayoutPanel()
        {
            if (checkBtnXacNhan == true)
            {
                int TongMenhGia = Convert.ToInt32(ConvertIfGraterThan1000(cboMenhGia.Text.Substring(0, cboMenhGia.Text.Length - 4)))
                    + Convert.ToInt32(ConvertIfGraterThan1000(my_UCChiTietMonAn.TextGiaMonAn.Substring(0, my_UCChiTietMonAn.TextGiaMonAn.Length - 7)));
                my_UCChiTietMonAn.TextGiaMonAn = string.Format("{0:N3}VNĐ", TongMenhGia);
            }
            else
            {
                my_UCChiTietMonAn.TextTenMonAn = "Nạp Tiền";
                my_UCChiTietMonAn.TextGiaMonAn = string.Format("{0:N3}VNĐ", cboMenhGia.Text);
                my_UCChiTietMonAn.TextSoLuongMonAn = 1 + "";
                btnXacNhan.Tag = (Convert.ToInt32(btnXacNhan.Tag) + 1).ToString();
                my_UCChiTietMonAn.Width = 255;
                my_UCChiTietMonAn.Tag = this;
                frmMain.myUC_QuanLyMenu.panelChiTietMonAn.Controls.Add(my_UCChiTietMonAn);
            }
        }
        private string ConvertIfGraterThan1000(string cash)
        {
            return cash.Replace(",", "");
        }
        private void HienThiVaTinhTongTien()
        {
            string textMenhGia = string.Format("{0:N3}VNĐ", cboMenhGia.Text);
            int TongTien = Convert.ToInt32(frmMain.myUC_QuanLyMenu.lblTongTien.Tag);
            TongTien += Convert.ToInt32(textMenhGia.Substring(0, textMenhGia.Length - 7));
            frmMain.myUC_QuanLyMenu.lblTongTien.Text = string.Format("{0:N3}VNĐ", TongTien);
            frmMain.myUC_QuanLyMenu.lblTongTien.Tag = TongTien;
        }
    }
}
