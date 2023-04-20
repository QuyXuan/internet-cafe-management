using BLL;
using DTO;
using GiaoDienPBL3.UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaoDienPBL3.User_Controls
{
    public partial class UC_QuanLyHoaDon : UserControl
    {
        public UC_QuanLyHoaDon()
        {
            InitializeComponent();
            AddColumnButton();
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
            dgvDaXacNhan.Columns.Add(buttonXem.Clone() as DataGridViewButtonColumn);
            dgvChoXacNhan.Columns.Add(buttonXem.Clone() as DataGridViewButtonColumn);
            dgvDaHuy.Columns.Add(buttonXem.Clone() as DataGridViewButtonColumn);
        }
        private void SetData()
        {
            foreach (Bill bill in BillBLL.Instance.GetListBillWithStatus())
            {
                dgvTatCaHoaDon.Rows.Add(new object[]
                {
                    bill.BillId, bill.EmployeeId, bill.CustomerId, BillBLL.Instance.GetNumberComputerByComputerId(bill.ComputerId), bill.Date, bill.Status, string.Format("{0:N3}VNĐ", bill.Total)
                });
            }
            foreach (Bill bill in BillBLL.Instance.GetListBillWithStatus("Chấp Nhận"))
            {
                dgvDaXacNhan.Rows.Add(new object[]
                {
                    bill.BillId, bill.EmployeeId, bill.CustomerId, BillBLL.Instance.GetNumberComputerByComputerId(bill.ComputerId), bill.Date, bill.Status, string.Format("{0:N3}VNĐ", bill.Total)
                });
            }
            foreach (Bill bill in BillBLL.Instance.GetListBillWithStatus("Chờ Chấp Nhận"))
            {
                dgvChoXacNhan.Rows.Add(new object[]
                {
                    bill.BillId, bill.EmployeeId, bill.CustomerId, BillBLL.Instance.GetNumberComputerByComputerId(bill.ComputerId), bill.Date, bill.Status, string.Format("{0:N3}VNĐ", bill.Total)
                });
            }
        }
        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = sender as DataGridView;
                int RowIndex = e.RowIndex;
                if (e.ColumnIndex == dgv.Columns["btnXem"].Index && e.RowIndex >= 0)
                {
                    txtMaHoaDon.Text = dgv.Rows[RowIndex].Cells[0].Value.ToString();
                    txtMaKhachHang.Text = dgv.Rows[RowIndex].Cells[2].Value.ToString();
                    txtMaNhanVien.Text = dgv.Rows[RowIndex].Cells[1].Value.ToString();
                    txtNgayNhan.Text = dgv.Rows[RowIndex].Cells[4].Value.ToString();
                    txtSoMay.Text = dgv.Rows[RowIndex].Cells[3].Value.ToString();
                    txtTrangThai.Text = dgv.Rows[RowIndex].Cells[5].Value.ToString();
                    txtTongTien.Text = dgv.Rows[RowIndex].Cells[6].Value.ToString();
                    SetListProduct(txtMaHoaDon.Text);
                    SetListDiscount(txtMaHoaDon.Text);
                    tabHoaDon.SelectedTab = tabHoaDon.TabPages[4];
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        //private void tabHoaDon_Selecting(object sender, TabControlCancelEventArgs e)
        //{
        //    if (e.TabPage == tabThongTinHoaDon)
        //    {
        //        e.Cancel = true;
        //    }
        //}
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
    }
}
