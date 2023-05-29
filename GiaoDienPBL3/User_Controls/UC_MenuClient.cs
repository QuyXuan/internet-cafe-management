using BLL;
using DTO;
using GiaoDienPBL3.UC;
using Guna.UI2.WinForms;
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

namespace GiaoDienPBL3.User_Controls
{
    public partial class UC_MenuClient : UserControl
    {
        public UC_ChiTietMonAn my_UCChiTietMonAn;
        private bool checkBtnCaiDat = false;
        public bool checkBtnXacNhan = false;
        private string AccountId;
        private string ComputerId;
        private bool Role;
        private List<BillDiscount> listBillDiscount;
        List<UC_ChiTietMonAn> listUCThongTinHangHoa;
        private List<UC_MonAn> listProductOnPanel = new List<UC_MonAn>();
        public static double TotalMoney = 0;
        public delegate void UpdateBalance(double Balance);
        public UpdateBalance updateBalance { get; set; }
        //kiểm tra đây là form admin hay là client, false là admin
        //private bool checkFormAdminOrClient = false;
        public UC_MenuClient(bool role,string accountId = null, string computerId = null)
        {
            InitializeComponent();
            listUCThongTinHangHoa = new List<UC_ChiTietMonAn>();
            AccountId = accountId;
            ComputerId = computerId;
            Role = role;
        }
        private void UC_QuanLyMenu_Load(object sender, EventArgs e)
        {
            SetFullMonAn();
            if(Role) SetFullInfo();
            else btnYeuCau.Enabled = false;
        }
        private void SetFullInfo()
        {
            txtMaHoaDon.Text = BillBLL.Instance.GetRandomBillId();
            Customer customer = CustomerBLL.Instance.GetCustomerByAccountId(AccountId);
            txtMaKhachHang.Text = customer.CustomerId;
            txtTenKhachHang.Text = customer.CustomerName;
            Computer computer = ComputerBLL.Instance.GetComputerByID(ComputerId);
            txtSoMay.Text = computer.ComputerName;
            dtpNgayNhan.Value = DateTime.Now;
            float TotalDiscount = 0;
            listBillDiscount = new List<BillDiscount>();
            foreach (Discount discount in DiscountBLL.Instance.GetListDiscountWithType(customer.TypeCustomer))
            {
                listBillDiscount.Add(new BillDiscount { 
                    BillId = txtMaHoaDon.Text,
                    DiscountId = discount.DiscountId,
                });
                TotalDiscount += discount.DiscountPercent ?? 0;
            }
            txtTongGiamGia.Text = TotalDiscount + " %";
        }
        private void SetFullMonAn()
        {
            List<Product> listProduct = ProductBLL.Instance.GetListProduct();
            foreach (Product item in listProduct)
            {
                if (item.ProductId == "sp0012") continue;
                AddMonAn(item);
            }
        }
        private void AddMonAn(Product product)
        {
            UC_MonAn my_UCMonAn = new UC_MonAn();
            my_UCMonAn.TextGiaMonAn = string.Format("{0:N3}VNĐ", product.SellingPrice);
            my_UCMonAn.TextTenMonAn = product.ProductName;
            my_UCMonAn.ImagePanel = ByteArrayToImage(product.ProductImage);
            my_UCMonAn.Tag = "Client," + product.ProductId;
            if (product.Status == false)
            {
                my_UCMonAn.picMonAn.ContextMenuStrip.Items["msDaHetMon"].PerformClick();
            }
            my_UCMonAn.picMonAn.ContextMenuStrip = null;
            //my_UCMonAn.Tag = product;
            /*frmMain.myUC_QuanLyMenu.*/
            panelMonAn.Controls.Add(my_UCMonAn);
            listProductOnPanel.Add(my_UCMonAn);
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
        //private void btnXacNhan_Click(object sender, EventArgs e)
        //{
        //    if (checkBtnXacNhan == false)
        //    {
        //        my_UCChiTietMonAn = new UC_ChiTietMonAn();
        //    }
        //    if ((cboMenhGia.Text.Length < 4) || cboMenhGia.Text.Substring(cboMenhGia.Text.Length - 4) != ".000")
        //    {
        //        frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Bạn Phải Nhập Theo Định Dạng #,###.000" + Environment.NewLine + "Ví Dụ: 20.000 / 1,000.000");
        //        return;
        //    }
        //    ThemChiTietMonAnVaoFlowLayoutPanel();
        //    HienThiVaTinhTongTien();
        //    checkBtnXacNhan = true;
        //}
        //private void ThemChiTietMonAnVaoFlowLayoutPanel()
        //{
        //    if (checkBtnXacNhan == true)
        //    {
        //        int TongMenhGia = Convert.ToInt32(ConvertIfGraterThan1000(cboMenhGia.Text.Substring(0, cboMenhGia.Text.Length - 4)))
        //            + Convert.ToInt32(ConvertIfGraterThan1000(my_UCChiTietMonAn.TextGiaMonAn.Substring(0, my_UCChiTietMonAn.TextGiaMonAn.Length - 7)));
        //        my_UCChiTietMonAn.TextGiaMonAn = string.Format("{0:N3}VNĐ", TongMenhGia);
        //    }
        //    else
        //    {
        //        my_UCChiTietMonAn.TextTenMonAn = "Nạp Tiền";
        //        my_UCChiTietMonAn.TextGiaMonAn = string.Format("{0:N3}VNĐ", cboMenhGia.Text);
        //        my_UCChiTietMonAn.TextSoLuongMonAn = 1 + "";
        //        btnXacNhan.Tag = (Convert.ToInt32(btnXacNhan.Tag) + 1).ToString();
        //        my_UCChiTietMonAn.Width = 255;
        //        my_UCChiTietMonAn.Tag = "Client";
        //        /*frmMain.myUC_QuanLyMenu.*/
        //        panelChiTietMonAn.Controls.Add(my_UCChiTietMonAn);
        //    }
        //}
        private string ConvertIfGraterThan1000(string cash)
        {
            return cash.Replace(",", "");
        }
        //private void HienThiVaTinhTongTien()
        //{
        //    string textMenhGia = string.Format("{0:N3}VNĐ", cboMenhGia.Text);
        //    int TongTien = Convert.ToInt32(/*frmMain.myUC_QuanLyMenu.*/lblTongTien.Tag);
        //    TongTien += Convert.ToInt32(textMenhGia.Substring(0, textMenhGia.Length - 7));
        //    /*frmMain.myUC_QuanLyMenu.*/
        //    lblTongTien.Text = string.Format("{0:N3}VNĐ", TongTien);
        //    /*frmMain.myUC_QuanLyMenu.*/
        //    lblTongTien.Tag = TongTien;
        //}
        private void btnYeuCau_Click(object sender, EventArgs e)
        {
            if (panelChiTietMonAn.Controls.Count == 0)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Không Có Món Ăn Nào Được Thêm");
                return;
            }
            
            Guna2Button button = sender as Guna2Button;
            try
            {
                float total = (float)Convert.ToDouble(lblTongTien.Text.Substring(0, lblTongTien.Text.Length - 7).Replace(",", ""));
                float customerBalance = CustomerBLL.Instance.GetCustomerByCustomerId(txtMaKhachHang.Text).Balance ?? 0;
                if (customerBalance < total)
                {
                    frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Số Dư Tài Khoản Không Đủ Để Yêu Cầu");
                    return;
                }
                Bill newBill = new Bill();
                newBill.BillId = txtMaHoaDon.Text;
                newBill.Date = DateTime.Now;
                newBill.ComputerId = ComputerId;
                newBill.CustomerId = txtMaKhachHang.Text;
                newBill.Total = total;
                newBill.TotalDiscountPercent = (float)Convert.ToDouble(txtTongGiamGia.Text.Substring(0, txtTongGiamGia.Text.Length - 2));
                newBill.Status = "Chờ Chấp Nhận";
                List<BillProduct> listBillProduct = GetListBillProductOnPanel();
                BillBLL.Instance.AddBilllWithStatusChoXacNhan(newBill);
                BillBLL.Instance.AddListProductToBill(listBillProduct);
                BillBLL.Instance.AddListDiscountToBill(listBillDiscount);
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Success, "Yêu Cầu Thành Công");
                UpdateNewBalance(txtMaKhachHang.Text, total, customerBalance);
                ResetUCQuanLyMenu();
            }
            catch (Exception)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Error, "Yêu Cầu Thất Bại");
                return;
            }
        }
        private void UpdateNewBalance(string customerId ,float total, float customerBalance)
        {
            CustomerBLL.Instance.EditCustomerBalance(customerId, total, false);
            updateBalance(customerBalance - total);
        }
        private List<BillProduct> GetListBillProductOnPanel()
        {
            List<BillProduct> listBillProduct = new List<BillProduct>();
            foreach (Control control in panelChiTietMonAn.Controls)
            {
                UC_ChiTietMonAn myUC_ChiTietMonAn = control as UC_ChiTietMonAn;
                BillProduct billProduct = new BillProduct
                {
                    BillId = txtMaHoaDon.Text,
                    ProductId = ProductBLL.Instance.GetProductByProductName(myUC_ChiTietMonAn.TextTenMonAn).ProductId,
                    Quantity = (float)Convert.ToDouble(myUC_ChiTietMonAn.TextSoLuongMonAn),
                    Price = (float)Convert.ToDouble(myUC_ChiTietMonAn.TextGiaMonAn.Split('.')[0])
                };
                listBillProduct.Add(billProduct);
            }
            return listBillProduct;
        }
        private void ResetUCQuanLyMenu()
        {
            txtMaHoaDon.Text = BillBLL.Instance.GetRandomBillId();
            foreach (Control control in panelChiTietMonAn.Controls)
            {
                UC_ChiTietMonAn myUC_ChiTietMonAn = control as UC_ChiTietMonAn;
                listUCThongTinHangHoa.Add(myUC_ChiTietMonAn);
            }
            foreach (UC_ChiTietMonAn control in listUCThongTinHangHoa)
            {
                control.btnXoaMon.PerformClick();
            }
            TotalMoney = 0;
            lblTongTien.Text = "0.000VNĐ";
            listUCThongTinHangHoa.Clear();
        }

        private void msLamMoiMenu_Click(object sender, EventArgs e)
        {
            foreach (UC_MonAn item in listProductOnPanel)
            {
                panelMonAn.Controls.Remove(item);
                item.Dispose();
            }
            listProductOnPanel.Clear();
            SetFullMonAn();
        }
    }
}
