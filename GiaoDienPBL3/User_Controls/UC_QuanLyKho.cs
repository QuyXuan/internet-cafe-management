using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public partial class UC_QuanLyKho : UserControl
    {
        public UC_QuanLyKho()
        {
            InitializeComponent();
            SetData();
        }
        private void SetData()
        {
            foreach (Product product in ProductBLL.Instance.GetListProduct())
            {
                if (product.ProductId == "sp0012") continue;
                string typeProduct = product.Type;
                if (typeProduct == "Đồ Ăn")
                {
                    dgvKho.Rows.Add(new object[]
                    {
                        imageList1.Images[0], product.ProductId, product.ProductName, product.Type, string.Format("{0:N3}VNĐ", product.CostPrice), product.Stock
                    });
                }
                else
                {
                    dgvKho.Rows.Add(new object[]
                    {
                        imageList1.Images[1], product.ProductId, product.ProductName, product.Type, string.Format("{0:N3}VNĐ", product.CostPrice), product.Stock
                    });
                }
            }
            dgvKho.ClearSelection();
        }
        
        private void TatCaMonAnNuocUongClick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvKho.Rows)
            {
                row.Visible = true;
            }
            Guna2Button button = sender as Guna2Button;
            if (button.Name == "btnDoAn")
            {
                foreach (DataGridViewRow row in dgvKho.Rows)
                {
                    if (row.Cells["Loai"].Value.ToString() != "Đồ Ăn")
                    {
                        row.Visible = false;
                    }
                }
            }
            else if (button.Name == "btnNuocUong")
            {
                foreach (DataGridViewRow row in dgvKho.Rows)
                {
                    if (row.Cells["Loai"].Value.ToString() != "Nước Uống")
                    {
                        row.Visible = false;
                    }
                }
            }
            else
            {
                return;
            }
        }
        private void dgvKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            if (idx < 0) return;
            DataGridViewRow row = dgvKho.Rows[idx];
            txtMaMon.Text = row.Cells["MaMon"].Value.ToString();
            txtTenMon.Text = row.Cells["TenMon"].Value.ToString();
            txtGiaGoc.Text = row.Cells["GiaGoc"].Value.ToString();
            txtSoLuongTru.Text = row.Cells["SoLuongTru"].Value.ToString();
            string Loai = row.Cells["Loai"].Value.ToString();
            if (Loai == "Món Ăn")
                cboLoai.SelectedIndex = 0;
            else
                cboLoai.SelectedIndex = 1;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            btnTatCa.PerformClick();
            foreach (DataGridViewRow row in dgvKho.Rows)
            {
                if (!row.Cells["TenMon"].Value.ToString().ToLower().Contains(txtTimKiem.Text.ToLower()))
                {
                    row.Visible = false;
                }
            }
        }
    }
}
