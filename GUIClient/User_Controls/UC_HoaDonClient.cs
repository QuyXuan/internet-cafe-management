using BLL;
using DTO;
using GiaoDienPBL3;
using GiaoDienPBL3.UC;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIClient.User_Controls
{
    public partial class UC_HoaDonClient : UserControl
    {
        private string CustomerId;
        private int CurrentPageTatCaHoaDon = 0;
        private int CurrentPageHoaDonChapNhan = 0;
        private int CurrentPageHoaDonChoChapNhan = 0;
        private const int PAGE_SIZE = 12;
        public delegate void SetBalance(double balance);
        public SetBalance setBalance { get; set; }

        public UC_HoaDonClient(string customerId = null)
        {
            InitializeComponent();
            AddColumnButton();
            CustomerId = customerId;
            SetData();
        }
        private void AddColumnButton()
        {
            DataGridViewButtonColumn buttonXem = new DataGridViewButtonColumn();
            buttonXem.HeaderText = "Xem Hóa Đơn";
            buttonXem.Text = "Xem";
            buttonXem.Name = "btnXem";
            buttonXem.FillWeight = 80;
            buttonXem.UseColumnTextForButtonValue = true;
            dgvTatCaHoaDon.Columns.Add(buttonXem);
        }
        private void SetData()
        {
            foreach (Bill bill in BillBLL.Instance.GetListBillWithStatusCustomerIdAndStartEnd(CustomerId, 0, PAGE_SIZE))
            {
                dgvTatCaHoaDon.Rows.Add(new object[]
                {
                    bill.BillId, bill.EmployeeId, bill.CustomerId, ComputerBLL.Instance.GetComputerByID(bill.ComputerId).ComputerName, bill.Date, bill.Status, bill.TotalDiscountPercent + "%", string.Format("{0:N3}VNĐ", bill.Total)
                });
            }
            lblTrang1.Text = "Trang : " + (CurrentPageTatCaHoaDon + 1) + " / " + (BillBLL.Instance.GetListBillWithStatusAndCustomerId(CustomerId).Count() / PAGE_SIZE + 1);
        }
        private void ResetData()
        {
            dgvTatCaHoaDon.SuspendLayout();
            dgvTatCaHoaDon.Rows.Clear();
            dgvTatCaHoaDon.ResumeLayout();
            CurrentPageTatCaHoaDon = 0;
            CurrentPageHoaDonChapNhan = 0;
            CurrentPageHoaDonChoChapNhan = 0;
        }
        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int RowIndex = e.RowIndex;
                if (e.ColumnIndex == dgvTatCaHoaDon.Columns["btnXem"].Index && e.RowIndex >= 0)
                {
                    txtMaHoaDon.Text = dgvTatCaHoaDon.Rows[RowIndex].Cells[0].Value.ToString();
                    txtMaKhachHang.Text = dgvTatCaHoaDon.Rows[RowIndex].Cells[2].Value.ToString();
                    if (dgvTatCaHoaDon.Rows[RowIndex].Cells[1].Value != null) txtMaNhanVien.Text = dgvTatCaHoaDon.Rows[RowIndex].Cells[1].Value.ToString();
                    txtNgayNhan.Text = dgvTatCaHoaDon.Rows[RowIndex].Cells[4].Value.ToString();
                    txtSoMay.Text = dgvTatCaHoaDon.Rows[RowIndex].Cells[3].Value.ToString();
                    txtTrangThai.Text = dgvTatCaHoaDon.Rows[RowIndex].Cells[5].Value.ToString();
                    txtTongGiamGia.Text = dgvTatCaHoaDon.Rows[RowIndex].Cells[6].Value.ToString();
                    txtTongTien.Text = dgvTatCaHoaDon.Rows[RowIndex].Cells[7].Value.ToString();
                    SetListProduct(txtMaHoaDon.Text);
                    SetListDiscount(txtMaHoaDon.Text);
                    tabHoaDon.SelectedTab = tabHoaDon.TabPages[1];
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        private void SetListProduct(string billId)
        {
            panelDanhSachMonAn.Controls.Clear();
            List<ProductIdNameQuantityPrice> productList = BillBLL.Instance.GetListProductByBillId(billId);
            foreach (var product in productList)
            {
                UC_ChiTietMonAn myUC_ChiTietMonAn = new UC_ChiTietMonAn();
                myUC_ChiTietMonAn.TextGiaMonAn = string.Format("{0:N3}VNĐ", product.SellingPrice);
                myUC_ChiTietMonAn.TextSoLuongMonAn = product.Quantity.ToString();
                myUC_ChiTietMonAn.TextTenMonAn = product.ProductName;
                myUC_ChiTietMonAn.btnCongMon.Visible = false;
                myUC_ChiTietMonAn.btnTruMon.Visible = false;
                myUC_ChiTietMonAn.btnXoaMon.Visible = false;
                myUC_ChiTietMonAn.Size = new Size(465, 60);
                panelDanhSachMonAn.Controls.Add(myUC_ChiTietMonAn);
            }
        }
        private void SetListDiscount(string billId)
        {
            panelDanhSachGiamGia.Controls.Clear();
            List<KeyValuePair<string, float?>> discountList = BillBLL.Instance.GetListDiscountByBillId(billId);
            foreach (KeyValuePair<string, float?> discount in discountList)
            {
                if (discount.Value == 0) continue;
                UC_ChiTietMonAn myUC_ChiTietMonAn = new UC_ChiTietMonAn();
                myUC_ChiTietMonAn.TextGiaMonAn = discount.Key;
                myUC_ChiTietMonAn.TextTenMonAn = discount.Value + "%";
                myUC_ChiTietMonAn.btnCongMon.Visible = false;
                myUC_ChiTietMonAn.btnTruMon.Visible = false;
                myUC_ChiTietMonAn.btnXoaMon.Visible = false;
                myUC_ChiTietMonAn.Size = new Size(465, 60);
                panelDanhSachGiamGia.Controls.Add(myUC_ChiTietMonAn);
            }
        }
        private void btnNextPrevious_Click(object sender, EventArgs e)
        {
            Guna2ImageButton button = sender as Guna2ImageButton;
            if (button.Name == "btnNext1")
            {
                NextPreviousClick(true);
            }
            else if (button.Name == "btnPrevious1")
            {
                NextPreviousClick(false);
            }
        }
        //type == true nghia la next, false nghia la previous
        private void NextPreviousClick(bool type/*, DataGridView dgv, string status = null*/)
        {
            int CurrentPage = 0;
            if (type == true)
            {
                int TotalPage = 0;
                TotalPage = Convert.ToInt32(BillBLL.Instance.GetListBillWithStatusAndCustomerId(CustomerId).Count() / PAGE_SIZE) + 1;
                if (CurrentPageTatCaHoaDon < TotalPage - 1)
                {
                    CurrentPageTatCaHoaDon++;
                }
                else
                {
                    frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Không Trong Phạm Vi Truy Cập Dữ Liệu");
                    return;
                }
                lblTrang1.Text = "Trang : " + (CurrentPageTatCaHoaDon + 1) + " / " + TotalPage;
                CurrentPage = CurrentPageTatCaHoaDon;
            }
            else
            {
                int TotalPage = 0;
                TotalPage = Convert.ToInt32(BillBLL.Instance.GetListBillWithStatusAndCustomerId(CustomerId).Count() / PAGE_SIZE) + 1;
                if (CurrentPageTatCaHoaDon > 0)
                {
                    CurrentPageTatCaHoaDon--;
                }
                else
                {
                    frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Không Trong Phạm Vi Truy Cập Dữ Liệu");
                    return;
                }
                lblTrang1.Text = "Trang : " + (CurrentPageTatCaHoaDon + 1) + " / " + TotalPage;
                CurrentPage = CurrentPageTatCaHoaDon;
            }
            dgvTatCaHoaDon.SuspendLayout();
            dgvTatCaHoaDon.Rows.Clear();
            dgvTatCaHoaDon.ResumeLayout();
            foreach (Bill bill in BillBLL.Instance.GetListBillWithStatusCustomerIdAndStartEnd(CustomerId, CurrentPage * PAGE_SIZE, PAGE_SIZE))
            {
                dgvTatCaHoaDon.Rows.Add(new object[]
                {
                        bill.BillId, bill.EmployeeId, bill.CustomerId, ComputerBLL.Instance.GetComputerByID(bill.ComputerId).ComputerName, bill.Date, bill.Status, bill.TotalDiscountPercent + "%", string.Format("{0:N3}VNĐ", bill.Total)
                });
            }
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            double balance = CustomerBLL.Instance.GetCustomerByCustomerId(CustomerId).Balance ?? 0;
            setBalance(balance);
            ResetData();
            SetData();
        }
    }
}
