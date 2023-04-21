﻿using BLL;
using DTO;
using GiaoDienPBL3.UC;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Globalization;
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
                    bill.BillId, bill.EmployeeId, bill.CustomerId, ComputerBLL.Instance.GetNumberComputerByComputerId(bill.ComputerId), bill.Date, bill.Status, string.Format("{0:N3}VNĐ", bill.Total)
                });
            }
            foreach (Bill bill in BillBLL.Instance.GetListBillWithStatus("Chấp Nhận"))
            {
                dgvDaXacNhan.Rows.Add(new object[]
                {
                    bill.BillId, bill.EmployeeId, bill.CustomerId, ComputerBLL.Instance.GetNumberComputerByComputerId(bill.ComputerId), bill.Date, bill.Status, string.Format("{0:N3}VNĐ", bill.Total)
                });
            }
            foreach (Bill bill in BillBLL.Instance.GetListBillWithStatus("Chờ Chấp Nhận"))
            {
                dgvChoXacNhan.Rows.Add(new object[]
                {
                    bill.BillId, bill.EmployeeId, bill.CustomerId, ComputerBLL.Instance.GetNumberComputerByComputerId(bill.ComputerId), bill.Date, bill.Status, string.Format("{0:N3}VNĐ", bill.Total)
                });
            }
        }
        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = sender as DataGridView;
                int RowIndex = e.RowIndex;
                if (e.ColumnIndex == dgv.Columns["btnXem"].Index && e.RowIndex >= 0 && dgv.Name == "dgvChoXacNhan")
                {
                    List<ProductIdNameQuantityPrice> productList = BillBLL.Instance.GetListProductByBillId(dgv.Rows[RowIndex].Cells[0].Value.ToString());
                    foreach (var product in productList)
                    {
                        UC_ChiTietMonAn myUC_ChiTietMonAn = new UC_ChiTietMonAn();
                        myUC_ChiTietMonAn.TextGiaMonAn = string.Format("{0:N3}VNĐ", product.SellingPrice);
                        myUC_ChiTietMonAn.TextTenMonAn = product.ProductName;
                        myUC_ChiTietMonAn.TextSoLuongMonAn = product.Quantity.ToString();
                        myUC_ChiTietMonAn.Width = 190;
                        frmMain.myUC_QuanLyMenu.panelChiTietMonAn.Controls.Add(myUC_ChiTietMonAn);
                        frmMain.myUC_QuanLyMenu.txtMaHoaDon.Text = dgv.Rows[RowIndex].Cells[0].Value.ToString();
                        frmMain.myUC_QuanLyMenu.dtpNgayNhan.Value = Convert.ToDateTime(dgv.Rows[RowIndex].Cells[4].Value.ToString());
                        frmMain.myUC_QuanLyMenu.txtMaNhanVien.Text = dgv.Rows[RowIndex].Cells[1].Value.ToString();
                        frmMain.myUC_QuanLyMenu.txtMaKhachHang.Text = dgv.Rows[RowIndex].Cells[2].Value.ToString();
                        frmMain.myUC_QuanLyMenu.txtSoMay.Text = dgv.Rows[RowIndex].Cells[3].Value.ToString();
                        frmMain.myUC_QuanLyMenu.txtTenKhachHang.Text = CustomerBLL.Instance.GetNameCustomerByCustomerId(dgv.Rows[RowIndex].Cells[2].Value.ToString());
                        frmMain.myUC_QuanLyMenu.txtTenNhanVien.Text = EmployeeBLL.Instance.GetEmployeeNameByEmployeeId(dgv.Rows[RowIndex].Cells[1].Value.ToString());
                        frmMain.myUC_QuanLyMenu.lblTongTien.Text = dgv.Rows[RowIndex].Cells[6].Value.ToString();
                    }
                    
                    //Nếu xem hóa đơn đang trong trạng thái chờ xác nhận thì sẽ mở UCMenu lên,
                    //đầu tiên là tìm cái form frmMain sau đó tìm cái button có name == btnMenu trong form đó
                    //xong cho thao tác click để mở form
                    Form mainForm = Application.OpenForms.OfType<frmMain>().FirstOrDefault();
                    if (mainForm != null)
                    {
                        Guna2Button button = mainForm.Controls.Find("btnMenu", true).FirstOrDefault() as Guna2Button;
                        if (button != null)
                        {
                            button.PerformClick();
                        }
                    }
                }
                else if (e.ColumnIndex == dgv.Columns["btnXem"].Index && e.RowIndex >= 0)
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
