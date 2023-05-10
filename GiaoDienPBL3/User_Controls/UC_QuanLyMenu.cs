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
        public bool checkBtnXacNhan = false;
        //kiểm tra đây là form admin hay là client, false là admin
        private bool checkFormAdminOrClient = false;
        private string EmployeeId;
        public UC_QuanLyMenu(string employeeId = null)
        {
            InitializeComponent();
            my_UCThongTinVaCaiDatMonAn = new UC_ThongTinVaCaiDatMonAn();
            AddUC();
            EmployeeId = employeeId;
            SetInfo();
        }
        private void SetInfo()
        {
            cboTenTaiKhoan.SelectedIndex = -1;
            txtMaHoaDon.Text = BillBLL.Instance.GetRandomBillId();
            dtpNgayNhan.Value = DateTime.Now.Date;
            txtMaNhanVien.Text = EmployeeId;
            txtTenNhanVien.Text = EmployeeBLL.Instance.GetEmployeeNameByEmployeeId(EmployeeId);
            txtSoMay.Text = "0";
            cboTenTaiKhoan.DataSource = AccountBLL.Instance.GetListAccount("Khách Hàng");
            cboTenTaiKhoan.DisplayMember = "UserName";
            //cboTenTaiKhoan.ValueMember = "AccountId";
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
            my_UCMonAn.ImagePanel = ByteArrayToImage(product.ProductImage);
            my_UCMonAn.Tag = "Manager" + "," + product.ProductId;
            if (product.Status == false)
            {
                my_UCMonAn.picMonAn.ContextMenuStrip.Items["msDaHetMon"].PerformClick();
            }
            //my_UCMonAn.Tag = product;
            /*frmMain.myUC_QuanLyMenu.*/panelMonAn.Controls.Add(my_UCMonAn);
        }
        //private Image GetAnhByPathAnhMon(string nameImg)
        //{
        //    string imgFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace(@"GiaoDienPBL3\bin\Debug", ""), "img", nameImg);
        //    try
        //    {
        //        Image image = Image.FromFile(imgFilePath);
        //        checkFormAdminOrClient = false;
        //        return image;
        //    }
        //    catch (FileNotFoundException)
        //    {
        //        imgFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace(@"\GUIClient\bin\Debug", ""), "img", nameImg);
        //        Image image = Image.FromFile(imgFilePath);
        //        image = Image.FromFile(imgFilePath);
        //        checkFormAdminOrClient = true;
        //        return image;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}
        private Image ByteArrayToImage(byte[] byteArray)
        {
            Image image = null;
            try
            {
                MemoryStream ms = new MemoryStream(byteArray);
                image = Image.FromStream(ms);
            }
            catch (Exception)
            {
                return null;
            }
            return image;
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (checkBtnXacNhan == false)
            {
                my_UCChiTietMonAn = new UC_ChiTietMonAn();
            }
            if ((cboMenhGia.Text.Length < 4) || cboMenhGia.Text.Substring(cboMenhGia.Text.Length - 4) != ".000")
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Bạn Phải Nhập Theo Định Dạng #,###.000" + Environment.NewLine + "Ví Dụ: 20.000 / 1,000.000");
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
                my_UCChiTietMonAn.Tag = "Manager";
                /*frmMain.myUC_QuanLyMenu.*/panelChiTietMonAn.Controls.Add(my_UCChiTietMonAn);
            }
        }
        private string ConvertIfGraterThan1000(string cash)
        {
            return cash.Replace(",", "");
        }
        private void HienThiVaTinhTongTien()
        {
            string textMenhGia = string.Format("{0:N3}VNĐ", cboMenhGia.Text);
            int TongTien = Convert.ToInt32(/*frmMain.myUC_QuanLyMenu.*/lblTongTien.Tag);
            TongTien += Convert.ToInt32(textMenhGia.Substring(0, textMenhGia.Length - 7));
            /*frmMain.myUC_QuanLyMenu.*/lblTongTien.Text = string.Format("{0:N3}VNĐ", TongTien);
            /*frmMain.myUC_QuanLyMenu.*/lblTongTien.Tag = TongTien;
        }

        private void ResetUCQuanLyMenu()
        {
            txtMaHoaDon.Text = BillBLL.Instance.GetRandomBillId();
            txtMaKhachHang.Text = "";
            txtMaKhachHang.ReadOnly = false;
            txtMaNhanVien.Text = EmployeeId;
            cboTenTaiKhoan.Enabled = true;
            txtSoMay.Text = "";
            txtSoMay.ReadOnly = false;
            txtTenKhachHang.Text = "";
            txtTenKhachHang.ReadOnly = false;
            txtTenNhanVien.Text = EmployeeBLL.Instance.GetEmployeeNameByEmployeeId(EmployeeId);
            txtTongGiamGia.Text = "";
            lblTongTien.Text = "0.000VNĐ";
            panelChiTietMonAn.Controls.Clear();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (frmMain.myUC_QuanLyMenu.panelChiTietMonAn.Controls.Count < 1)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Không Có Món Ăn Nào Được Chọn");
                return;
            }
            Guna2Button button = sender as Guna2Button;
            try
            {
                string MaHoaDon = txtMaHoaDon.Text;
                BillBLL.Instance.SetStatusChoXacNhanToXacNhan(MaHoaDon, EmployeeId);
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Success, "Thanh Toán Thành Công");
                ResetUCQuanLyMenu();
            }
            catch (Exception)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Error, "Thanh Toán Thất Bại");
                return;
            }
        }

        private void cboTenTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTenTaiKhoan.SelectedIndex == -1) return;
            try
            {
                Account account = cboTenTaiKhoan.SelectedValue as Account;
                Customer customer = CustomerBLL.Instance.GetCustomerByAccountId(account.AccountId);
                txtMaKhachHang.Text = customer.CustomerId;
                txtTenKhachHang.Text = customer.CustomerName;
                float TotalDiscount = 0;
                foreach (Discount discount in DiscountBLL.Instance.GetListDiscountWithType(customer.TypeCustomer))
                {
                    TotalDiscount += discount.DiscountPercent ?? 0;
                }
                txtTongGiamGia.Text = TotalDiscount + " %";
            }
            catch (Exception)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Error, "Lỗi");
                return;
            }
        }
    }
}