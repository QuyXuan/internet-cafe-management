using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GiaoDienPBL3.User_Controls;
using Guna.UI2.WinForms;

namespace GiaoDienPBL3.UC
{
    public partial class UC_QuanLyKho : UserControl
    {
        public UC_QuanLyKho()
        {
            InitializeComponent();
            TestData();
        }
        private void TestData()
        {
            int id = 1;
            for (int i = 0; i < 50; i++)
            {
                dgvKho.Rows.Add(new object[]
                {
                    imageList1.Images[0], id++, "Thùng Mỳ Gói", "Món Ăn", "100.000VNĐ", "15"
                });
                dgvKho.Rows.Add(new object[]
                {
                    imageList1.Images[1], id++, "Két Sting", "Nước Uống", "125.000VNĐ", "25"
                });
            }
            dgvKho.ClearSelection();
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
            txtGiaGoc.Enabled = status;
            txtMaMon.Enabled = status;
            txtSoLuongTru.Enabled = status;
            txtTenMon.Enabled = status;
            cboLoai.Enabled = status;
        }
        private void ClearComboboxAndTextBox()
        {
            txtMaMon.Text = "";
            txtTenMon.Text = "";
            txtGiaGoc.Text = "";
            txtSoLuongTru.Text = "";
            cboLoai.SelectedIndex = -1;
        }
        private void ThemXoaSuaClick(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            SetAllButtonDisableAndVisible();
            if (btn.Name == "btnSua")
            {
                btnSua.Enabled = true;
                SetEnableComboboxAndTextBox(true);
            }
            else
            {
                btnXoa.Enabled = true;
                ClearComboboxAndTextBox();
            }
        }
        private void HuyOKClick(object sender, EventArgs e)
        {
            //Guna2Button btn = sender as Guna2Button;
            SetAllButtonEnableAndInvisible();
            SetEnableComboboxAndTextBox(false);
        }
        private void TatCaMonAnNuocUongClick(object sender, EventArgs e)
        {

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
    }
}
