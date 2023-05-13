using BLL;
using DTO;
using GiaoDienPBL3.UC;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaoDienPBL3.User_Controls
{
    public partial class UC_QuanLyHoaDonNhapKho : UserControl
    {
        private Random random = new Random();
        private List<Control> listUCThongTinHangHoa;
        //private bool checkThemHangMoi = false;
        private List<KeyValuePair<Product, float?>> newProducts = new List<KeyValuePair<Product, float?>>();
        private List<KeyValuePair<string, float?>> productsKVP = new List<KeyValuePair<string, float?>>();
        private bool checkFirstAdd = false;
        public static double TotalMoney = 0;
        public UC_QuanLyHoaDonNhapKho()
        {
            InitializeComponent();
            listUCThongTinHangHoa = new List<Control>();
            SetData();
        }

        private void btnHuyXacNhan_Click(object sender, EventArgs e)
        {
            Guna2Button button = sender as Guna2Button;
            if (button.Name == "btnXacNhan")
            {
                if (CheckValid() == false) return;
                UC_ChiTietMonAn my_UCChiTietMonAn = new UC_ChiTietMonAn();
                my_UCChiTietMonAn.btnCongMon.Visible = false;
                my_UCChiTietMonAn.btnTruMon.Visible = false;
                int ThanhTien = Convert.ToInt32(txtSoLuong.Text) * Convert.ToInt32((txtGiaGoc.Text.Substring(0, txtGiaGoc.Text.Length - 4).Replace(",", "")));
                my_UCChiTietMonAn.TextGiaMonAn = string.Format("{0:N3}VNĐ", ThanhTien); ;
                my_UCChiTietMonAn.TextTenMonAn = cboTenHangHoa.Text;
                my_UCChiTietMonAn.TextSoLuongMonAn = txtSoLuong.Text;
                my_UCChiTietMonAn.Size = new Size(300, 56);
                my_UCChiTietMonAn.Tag = "Kho";
                TotalMoney += ThanhTien;
                AddOrUpdateThongTinHangHoa(my_UCChiTietMonAn);
                //panelHoaDon.Controls.Add(my_UCChiTietMonAn);
                //panelHoaDon.Controls.SetChildIndex(my_UCChiTietMonAn, 1);
                //int TotalMoney = Convert.ToInt32(lblTongTien.Text.Substring(0, lblTongTien.Text.Length - 7).Replace(",", "")) + ThanhTien;
                if (txtGiamGia.Text != "")
                {
                    int GiamGia = Convert.ToInt32(txtGiamGia.Text/*.Substring(0, txtGiamGia.Text.Length - 1)*/);
                    lblTongTien.Text = string.Format("{0:N3}VNĐ", Math.Ceiling(TotalMoney / 100 * (100 - GiamGia)));
                }
                else
                {
                    lblTongTien.Text = string.Format("{0:N3}VNĐ", Math.Ceiling(TotalMoney));
                }
                //HangHoa hangHoa = new HangHoa(txtMaHangHoa.Text, cboTenHangHoa.Text, Convert.ToInt32(txtSoLuong.Text), cboLoai.Text, my_UCChiTietMonAn.TextGiaMonAn);
                if (btnThemHangMoi.Checked == true)
                {
                    Product product = new Product()
                    {
                        ProductId = txtMaHangHoa.Text,
                        ProductName = cboTenHangHoa.Text,
                        Type = cboLoai.Text,
                        CostPrice = (float)Convert.ToDouble(txtGiaGoc.Text.Substring(0, txtGiaGoc.Text.Length - 4).Replace(",", ""))
                    };
                    newProducts.Add(new KeyValuePair<Product, float?>(product, (float)Convert.ToDouble(txtSoLuong.Text)));
                    productsKVP.Add(new KeyValuePair<string, float?>(txtMaHangHoa.Text, (float)Convert.ToDouble(txtSoLuong.Text)));
                }
                else if (btnThemHangCu.Checked == true)
                {
                    productsKVP.Add(new KeyValuePair<string, float?>(txtMaHangHoa.Text, (float)Convert.ToDouble(txtSoLuong.Text)));
                }
            }
            txtMaHangHoa.Text = "";
            cboTenHangHoa.SelectedIndex = -1;
            txtSoLuong.Text = "";
            txtGiaGoc.Text = "";
            //if (txtGiamGia.Text != "")
            //    txtTongTien.Text = string.Format("{0:N3}VNĐ", (Math.Ceiling(((float)Convert.ToDouble(lblTongTien.Text.Substring(0, lblTongTien.Text.Length - 7).Replace(",", ""))) * (100 - (Convert.ToDouble(txtGiamGia.Text)) / 100))));
            //else txtTongTien.Text = lblTongTien.Text;
            txtTongTien.Text = lblTongTien.Text;
            cboLoai.SelectedIndex = -1;
            panelChiTietHangNhap.Visible = false;
            btnThemHangCu.Checked = false;
            btnThemHangMoi.Checked = false;
            SetEnableTextBoxAndCombobox2(false);
        }
        private void AddOrUpdateThongTinHangHoa(UC_ChiTietMonAn myUC_NewChiTietMonAn)
        {
            foreach (Control control in listUCThongTinHangHoa)
            {
                UC_ChiTietMonAn myUC_ChiTietMonAn = control as UC_ChiTietMonAn;
                if (myUC_ChiTietMonAn != null && myUC_ChiTietMonAn.TextTenMonAn == myUC_NewChiTietMonAn.TextTenMonAn)
                {
                    myUC_ChiTietMonAn.TextSoLuongMonAn = (Convert.ToInt32(myUC_ChiTietMonAn.TextSoLuongMonAn) + Convert.ToInt32(myUC_NewChiTietMonAn.TextSoLuongMonAn)).ToString();
                    myUC_ChiTietMonAn.TextGiaMonAn = string.Format("{0:N3}VNĐ", (Convert.ToDouble(myUC_ChiTietMonAn.TextGiaMonAn.Substring(0, myUC_ChiTietMonAn.TextGiaMonAn.Length - 7).Replace(",", ""))) + 
                        Convert.ToDouble(myUC_NewChiTietMonAn.TextGiaMonAn.Substring(0, myUC_NewChiTietMonAn.TextGiaMonAn.Length - 7).Replace(",", "")));
                    return;
                }
            }
            listUCThongTinHangHoa.Add(myUC_NewChiTietMonAn);
            panelHoaDon.Controls.Add(myUC_NewChiTietMonAn);
        }
        private bool CheckValid()
        {
            if (txtMaHoaDon.Text == "")
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Mã Hóa Đơn Không Được Để Trống");
                return false;
            }
            else if (cboTenHangHoa.Text == "")
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Tên Món Không Được Để Trống");
                return false;
            }
            else if (int.TryParse(txtSoLuong.Text, out _) == false)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Số Lượng Phải Là Một Số Nguyên");
                return false;
            }
            else if ((txtGiaGoc.Text.Length < 4) || txtGiaGoc.Text.Substring(txtGiaGoc.Text.Length - 4) != ".000")
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Bạn Phải Nhập Theo Định Dạng #,###.000" + Environment.NewLine + "Ví Dụ: 20.000 / 1,000.000");
                return false;
            }
            else if (txtNhaCungCap.Text == "")
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Tên Nhà Cung Cấp Không Được Để Trống");
                return false;
            }
            else if (txtGiamGia.Text.Length > 2 || (int.TryParse(txtGiamGia.Text, out _) == false && txtGiamGia.Text != ""))
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Giảm Giá Phải Là Một Số Nguyên Không Âm" + Environment.NewLine + "Có Ít Nhất 2 Chữ Số");
                return false;
            }
            return true;
        }
        public void SetData()
        {
            foreach (Reciept reciept in RecieptBLL.Instance.GetListReciept())
            {
                dgvHoaDonNhap.Rows.Add(new object[]
                {
                    reciept.RecieptId, reciept.EmployeeId, reciept.Manufacturer, reciept.Date.Value.ToString("dd/MM/yyyy"), reciept.Discount + "%", string.Format("{0:N3}VNĐ", reciept.TotalBill)
                });
            }
            dgvHoaDonNhap.ClearSelection();
        }
        public void ResetData()
        {
            dgvHoaDonNhap.SuspendLayout();
            dgvHoaDonNhap.Rows.Clear();
            dgvHoaDonNhap.ResumeLayout();
            TotalMoney = 0;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            checkFirstAdd = true;
            if ((txtNhaCungCap.Text == "" && txtMaHoaDon.Text == "") || txtNhaCungCap.ReadOnly == true)
            {
                txtMaHoaDon.Text = RecieptBLL.Instance.GetRandomRecieptId();
                dtpNgayNhan.Value = DateTime.Now;
                txtMaNhanVien.Text = EmployeeBLL.Instance.GetEmployeeIdByAccountId(frmMain.AccountId);
                txtTenNhanVien.Text = EmployeeBLL.Instance.GetEmployeeNameByEmployeeId(txtMaNhanVien.Text);
                txtNhaCungCap.Text = "";
                txtNhaCungCap.ReadOnly = false;
                txtGiamGia.Text = "";
                txtGiamGia.ReadOnly = false;
                lvThongTinHangHoa.Items.Clear();
            }
            panelChiTietHangNhap.Visible = true;
            panelHoaDon.Controls.SetChildIndex(panelChiTietHangNhap, panelHoaDon.Controls.Count - 1);
            txtNhaCungCap.Enabled = true;
            txtGiamGia.Enabled = true;
            dtpNgayNhan.Enabled = true;
            txtMaHangHoa.Focus();
        }
        private void SetAllButtonDisableAndVisible()
        {
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnHuy.Visible = true;
            btnOK.Visible = true;
        }
        private void SetAllButtonEnableAndInvisible()
        {
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Checked = false;
            btnSua.Checked = false;
            btnHuy.Visible = false;
            btnOK.Visible = false;
        }
        private void SetEnableComboboxAndTextBox(bool status)
        {
            txtMaHoaDon.Enabled = status;
            txtTongTien.Enabled = status;
            dtpNgayNhan.Enabled = status;
            txtMaNhanVien.Enabled = status;
            txtTenNhanVien.Enabled = status;
            txtNhaCungCap.Enabled = status;
            txtGiamGia.Enabled = status;
        }
        private void ClearComboboxAndTextBox()
        {
            txtTongTien.Text = "";
            txtTenNhanVien.Text = "";
            txtNhaCungCap.Text = "";
            txtGiamGia.Text = "";
            dtpNgayNhan.Value = DateTime.Now;
        }
        private void btnXoaSuaClick(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            SetAllButtonDisableAndVisible();
            if (btn.Name == "btnThem")
            {
                btnThem.Enabled = true;
                ClearComboboxAndTextBox();
                SetEnableComboboxAndTextBox(true);
            }
            else if (btn.Name == "btnSua")
            {
                btnSua.Enabled = true;
                SetEnableComboboxAndTextBox(true);
            }
            else
            {
                btnXoa.Enabled = true;
                ClearComboboxAndTextBox();
            }
            //lastButton = btn;
        }
        private void btnHuyOKClick(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            //if (btn.Name == "btnOK")
            //{
            //    if (lastButton.Name == "btnThem")
            //    {
            //        AddMonAn(SetMonAn());
            //    }
            //}
            SetAllButtonEnableAndInvisible();
            SetEnableComboboxAndTextBox(false);
        }

        private void btnThemHangCuMoi_Click(object sender, EventArgs e)
        {
            SetEnableTextBoxAndCombobox2(true);
            Guna2Button button = sender as Guna2Button;
            if (button.Name == "btnThemHangCu")
            {
                txtMaHangHoa.ReadOnly = true;
                txtGiaGoc.ReadOnly = true;
                cboLoai.Enabled = true;
                cboTenHangHoa.Enabled = true;
                txtSoLuong.Enabled = true;
                cboTenHangHoa.DataSource = ProductBLL.Instance.GetListNameProduct();
            }
            else
            {
                txtMaHangHoa.ReadOnly = true;
                txtGiaGoc.ReadOnly = false;
                txtMaHangHoa.Text = ProductBLL.Instance.GetRandomProductId();
                cboTenHangHoa.DataSource = null;
            }
        }
        private void SetEnableTextBoxAndCombobox2(bool status)
        {
            txtMaHangHoa.Enabled = status;
            cboTenHangHoa.Enabled = status;
            cboLoai.Enabled = status;
            txtSoLuong.Enabled = status;
            txtGiaGoc.Enabled = status;
        }
        private void btnThemChiTietHangNhap_Click(object sender, EventArgs e)
        {
            if (listUCThongTinHangHoa.Count == 0)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Không Có Hàng Hóa Để Thêm");
                return;
            }
            //List<KeyValuePair<Product, float?>> listProduct = new List<KeyValuePair<Product, float?>>();
            foreach (Control control in listUCThongTinHangHoa)
            {
                UC_ChiTietMonAn ChiTietMonAn = control as UC_ChiTietMonAn;
                if (control != null)
                {
                    panelHoaDon.Controls.Remove(control);
                    control.Dispose();
                }
            }
            ProductBLL.Instance.AddNewListProduct(newProducts);
            float total = (float)Convert.ToDouble(txtTongTien.Text.Substring(0, txtTongTien.Text.Length - 7).Replace(",", ""));
            RecieptBLL.Instance.AddNewReciept(new Reciept
            {
                RecieptId = txtMaHoaDon.Text,
                Date = DateTime.Now.Date,
                Discount = txtGiamGia.Text == string.Empty ? 0 : (float)Convert.ToDouble(txtGiamGia),
                EmployeeId = txtMaNhanVien.Text,
                Manufacturer = txtNhaCungCap.Text,
                TotalBill = total,
            });
            if (BillDayBLL.Instance.CheckBillDay(DateTime.Now.Date, false))
            {
                BillDayBLL.Instance.EditBillDay(DateTime.Now.Date, false, total);
            }
            else
            {
                BillDayBLL.Instance.AddNewBillDay(new BillDay
                {
                    BillDayId = BillDayBLL.Instance.GetRandomBillDayId(),
                    Date = DateTime.Now.Date,
                    TotalBill = total,
                    Type = false
                });
            }
            foreach (var recieptProduct in productsKVP)
            {
                RecieptBLL.Instance.AddRecieptProduct(new RecieptProduct
                {
                    RecieptId = txtMaHoaDon.Text,
                    ProductId = recieptProduct.Key,
                    Quantity = recieptProduct.Value
                });
            }
            listUCThongTinHangHoa.Clear();
            lblTongTien.Text = "0.000VNĐ";
            
            productsKVP.Clear();
            newProducts.Clear();
            checkFirstAdd = false;
            ResetData();
            SetData();
        }

        private void btnHuyTatCa_Click(object sender, EventArgs e)
        {
            foreach (Control control in listUCThongTinHangHoa)
            {
                panelHoaDon.Controls.Remove(control);
                control.Dispose();
            }
            listUCThongTinHangHoa.Clear();
            lblTongTien.Text = "0.000VNĐ";
        }
        private void dgvHoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (checkFirstAdd == true) return;
            if (e.RowIndex == -1) return;
            DataGridViewRow Row = dgvHoaDonNhap.SelectedRows[0];
            txtMaHoaDon.Text = Row.Cells["MaHoaDon"].Value.ToString();
            txtMaNhanVien.Text = Row.Cells["MaNhanVien"].Value.ToString();
            txtTenNhanVien.Text = EmployeeBLL.Instance.GetEmployeeNameByEmployeeId(txtMaNhanVien.Text);
            txtNhaCungCap.Text = Row.Cells["NhaCungCap"].Value.ToString();
            dtpNgayNhan.Value = DateTime.ParseExact(Row.Cells["NgayNhan"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            txtGiamGia.Text = Row.Cells["GiamGia"].Value.ToString();
            txtTongTien.Text = Row.Cells["TongTien"].Value.ToString();
            txtGiamGia.ReadOnly = true;
            txtNhaCungCap.ReadOnly = true;
            lvThongTinHangHoa.Items.Clear();
            List<KeyValuePair<Product, float?>> productList = RecieptBLL.Instance.GetListProductByRecieptId(txtMaHoaDon.Text);
            foreach (var product in productList)
            {
                ListViewItem item = new ListViewItem(product.Key.ProductId);
                item.SubItems.Add(product.Key.ProductName);
                item.SubItems.Add(product.Value.ToString());
                item.SubItems.Add(string.Format("{0:N3}VNĐ", product.Key.CostPrice));
                item.SubItems.Add(product.Key.Type);
                lvThongTinHangHoa.Items.Add(item);
            }
        }

        private void cboTenHangHoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTenHangHoa.SelectedIndex == -1) return;
            Product product = ProductBLL.Instance.GetProductByProductName(cboTenHangHoa.SelectedItem.ToString());
            txtGiaGoc.Text = string.Format("{0:N3}", product.CostPrice);
            if (product.Type == "Đồ Ăn")
            {
                cboLoai.SelectedIndex = 0;
            }
            else
            {
                cboLoai.SelectedIndex = 1;
            }
            txtMaHangHoa.Text = product.ProductId;
        }
    }
}
