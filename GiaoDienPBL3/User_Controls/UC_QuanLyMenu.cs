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
        List<UC_ChiTietMonAn> listUCThongTinHangHoa;
        //kiểm tra đây là form admin hay là client, false là admin
        private bool checkFormAdminOrClient = false;
        private List<BillDiscount> listBillDiscout = new List<BillDiscount>();
        private List<UC_MonAn> listProductOnPanel = new List<UC_MonAn>();
        public static double TotalMoney = 0;
        private string EmployeeId;
        public UC_QuanLyMenu(string employeeId = null)
        {
            InitializeComponent();
            listUCThongTinHangHoa = new List<UC_ChiTietMonAn>();
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
                //bỏ qua cái nạp tiền
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
            my_UCMonAn.Tag = "Manager" + "," + product.ProductId;
            if (product.Status == false)
            {
                my_UCMonAn.picMonAn.ContextMenuStrip.Items["msDaHetMon"].PerformClick();
            }
            //my_UCMonAn.Tag = product;
            /*frmMain.myUC_QuanLyMenu.*/
            panelMonAn.Controls.Add(my_UCMonAn);
            listProductOnPanel.Add(my_UCMonAn);
        }
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
                my_UCChiTietMonAn.btnCongMon.Visible = false;
                my_UCChiTietMonAn.btnTruMon.Visible = false;
                my_UCChiTietMonAn.TextTenMonAn = "Nạp Tiền";
                my_UCChiTietMonAn.TextGiaMonAn = string.Format("{0:N3}VNĐ", cboMenhGia.Text);
                my_UCChiTietMonAn.TextSoLuongMonAn = 1 + "";
                btnXacNhan.Tag = (Convert.ToInt32(btnXacNhan.Tag) + 1).ToString();
                my_UCChiTietMonAn.Width = 255;
                my_UCChiTietMonAn.Tag = "Manager";
                /*frmMain.myUC_QuanLyMenu.*/
                panelChiTietMonAn.Controls.Add(my_UCChiTietMonAn);
            }
        }
        private string ConvertIfGraterThan1000(string cash)
        {
            return cash.Replace(",", "");
        }
        private void HienThiVaTinhTongTien()
        {
            //string textMenhGia = string.Format("{0:N3}VNĐ", cboMenhGia.Text);
            //int TongTien = Convert.ToInt32(/*frmMain.myUC_QuanLyMenu.*/lblTongTien.Tag);
            ///TongTien += Convert.ToInt32(textMenhGia.Substring(0, textMenhGia.Length - 7));
            /*frmMain.myUC_QuanLyMenu.*/
            UC_QuanLyMenu.TotalMoney += Convert.ToInt32(cboMenhGia.Text.Substring(0, cboMenhGia.Text.Length - 4).Replace(",", ""));
            int GiamGia = Convert.ToInt32(txtTongGiamGia.Text.Substring(0, txtTongGiamGia.Text.Length - 2));
            lblTongTien.Text = string.Format("{0:N3}VNĐ", Math.Ceiling(UC_QuanLyMenu.TotalMoney / 100 * (100 - GiamGia)));
            /*frmMain.myUC_QuanLyMenu.*/
            lblTongTien.Tag = UC_QuanLyMenu.TotalMoney;
        }

        private void ResetUCQuanLyMenu()
        {
            //panelChiTietMonAn.Controls.Clear();
            foreach (Control control in panelChiTietMonAn.Controls)
            {
                UC_ChiTietMonAn myUC_ChiTietMonAn = control as UC_ChiTietMonAn;
                listUCThongTinHangHoa.Add(myUC_ChiTietMonAn);
            }
            foreach (UC_ChiTietMonAn control in listUCThongTinHangHoa)
            {
                if (control.btnXoaMon.Visible == false)
                {
                    panelChiTietMonAn.Controls.Clear();
                    break;
                }
                control.btnXoaMon.PerformClick();
            }
            listUCThongTinHangHoa.Clear();
            txtMaHoaDon.Text = BillBLL.Instance.GetRandomBillId();
            cboTenTaiKhoan.SelectedIndex = -1;
            txtMaKhachHang.Text = "";
            txtMaKhachHang.ReadOnly = false;
            txtMaNhanVien.Text = EmployeeId;
            cboTenTaiKhoan.Enabled = true;
            txtSoMay.Text = "0";
            txtSoMay.ReadOnly = false;
            txtTenKhachHang.Text = "";
            txtTenKhachHang.ReadOnly = false;
            txtTenNhanVien.Text = EmployeeBLL.Instance.GetEmployeeNameByEmployeeId(EmployeeId);
            txtTongGiamGia.Text = "";
            lblTongTien.Text = "0.000VNĐ";
            TotalMoney = 0;
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
                string BillId = txtMaHoaDon.Text;
                if (BillBLL.Instance.CheckExistBillId(BillId))
                {
                    BillBLL.Instance.SetStatusChoXacNhanToXacNhan(BillId, EmployeeId);
                    BillBLL.Instance.UpdateQuantityProduct(BillId);
                    float Total = BillBLL.Instance.GetBillByBillId(BillId).Total ?? 0;
                    if (BillDayBLL.Instance.CheckBillDay(DateTime.Now.Date, true))
                    {
                        BillDayBLL.Instance.EditBillDay(DateTime.Now.Date, true, Total);
                    }
                    else
                    {
                        BillDayBLL.Instance.AddNewBillDay(new BillDay
                        {
                            BillDayId = BillDayBLL.Instance.GetRandomBillDayId(),
                            Date = DateTime.Now,
                            TotalBill = Total,
                            Type = true
                        });
                    }
                }
                else
                {
                    float total = (float)Convert.ToDouble(lblTongTien.Text.Substring(0, lblTongTien.Text.Length - 7).Replace(",", ""));
                    BillBLL.Instance.AddNewBill(new Bill
                    {
                        BillId = txtMaHoaDon.Text,
                        CustomerId = txtMaKhachHang.Text,
                        Date = DateTime.Now,
                        EmployeeId = txtMaNhanVien.Text,
                        Total = total,
                        TotalDiscountPercent = (float)Convert.ToDouble(txtTongGiamGia.Text.Substring(0, txtTongGiamGia.Text.Length - 2)),
                        Status = "Chấp Nhận",
                        ComputerId = "mt0031"
                    });
                    BillBLL.Instance.AddListProductToBill(GetListBillProductOnPanel());
                    BillBLL.Instance.AddListDiscountToBill(listBillDiscout);
                    if (BillDayBLL.Instance.CheckBillDay(DateTime.Now.Date, true))
                    {
                        BillDayBLL.Instance.EditBillDay(DateTime.Now.Date, true, total);
                    }
                    else
                    {
                        BillDayBLL.Instance.AddNewBillDay(new BillDay
                        {
                            BillDayId = BillDayBLL.Instance.GetRandomBillDayId(),
                            Date = DateTime.Now.Date,
                            TotalBill = total,
                            Type = true
                        });
                    }
                    BillBLL.Instance.UpdateQuantityProduct(BillId);
                }
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Success, "Thanh Toán Thành Công");
                ResetUCQuanLyMenu();
            }
            catch (Exception)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Error, "Thanh Toán Thất Bại");
                return;
            }
        }
        private List<BillProduct> GetListBillProductOnPanel()
        {
            List<BillProduct> listBillProduct = new List<BillProduct>();
            foreach (Control control in panelChiTietMonAn.Controls)
            {
                UC_ChiTietMonAn myUC_ChiTietMonAn = control as UC_ChiTietMonAn;
                if (myUC_ChiTietMonAn.TextTenMonAn == "Nạp Tiền")
                {
                    float balance = (float)Convert.ToDouble(myUC_ChiTietMonAn.TextGiaMonAn.Substring(0, myUC_ChiTietMonAn.TextGiaMonAn.Length - 7).Replace(",", ""));
                    CustomerBLL.Instance.EditCustomerBalance(txtMaKhachHang.Text, balance, true);
                }
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
        private void cboTenTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTenTaiKhoan.SelectedIndex == -1) return;
            listBillDiscout.Clear();
            try
            {
                Account account = cboTenTaiKhoan.SelectedValue as Account;
                Customer customer = CustomerBLL.Instance.GetCustomerByAccountId(account.AccountId);
                txtMaKhachHang.Text = customer.CustomerId;
                txtTenKhachHang.Text = customer.CustomerName;
                float TotalDiscount = 0;
                foreach (Discount discount in DiscountBLL.Instance.GetListDiscountWithType(customer.TypeCustomer))
                {
                    listBillDiscout.Add(new BillDiscount
                    {
                        BillId = txtMaHoaDon.Text,
                        DiscountId = discount.DiscountId,
                        DiscountPercent = discount.DiscountPercent
                    });
                    TotalDiscount += discount.DiscountPercent ?? 0;
                }
                txtTongGiamGia.Text = TotalDiscount + " %";
                lblTongTien.Text = string.Format("{0:N3}VNĐ", Math.Ceiling(UC_QuanLyMenu.TotalMoney / 100 * (100 - TotalDiscount)));
            }
            catch (Exception)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Error, "Lỗi");
                return;
            }
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

        private void btnHuyYeuCau_Click(object sender, EventArgs e)
        {
            try
            {
                if (!BillBLL.Instance.CheckBillWithStatus(txtMaHoaDon.Text, "Chờ Chấp Nhận"))
                {
                    frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Không Thể Hủy");
                    return;
                }
                BillBLL.Instance.SetStatusChoXacNhanToTuChoi(txtMaHoaDon.Text, EmployeeId);
                CustomerBLL.Instance.EditCustomerBalance(txtMaKhachHang.Text, Convert.ToInt32(lblTongTien.Text.Split('.')[0].Replace(",", "")), true);
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Success, "Hủy Thành Công");
                ResetUCQuanLyMenu();
            }
            catch (Exception)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Error, "Lỗi");
                return;
            }
        }
    }
}