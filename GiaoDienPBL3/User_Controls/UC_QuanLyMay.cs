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

namespace GiaoDienPBL3.UC
{
    public partial class UC_QuanLyMay : UserControl
    {
        public UC_QuanLyMay()
        {
            InitializeComponent();
        }
        private void SetAllButtonDisableAndVisible()
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnHuy.Visible = true;
            btnOK.Visible = true;
        }
        private void SetAllButtonEnableAndInvisible()
        {
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Checked = false;
            btnXoa.Checked = false;
            btnSua.Checked = false;
            btnHuy.Visible = false;
            btnOK.Visible = false;
        }
        private void SetEnableComboboxAndTextBox(bool status)
        {
            txtMaMay.Enabled = status;
            txtSoMay.Enabled = status;
            txtGia.Enabled = status;
            cboLoaiMay.Enabled = status;
            cboTrangThai.Enabled = status;
        }
        private void ClearComboboxAndTextBox()
        {
            txtMaMay.Text = "";
            txtSoMay.Text = "";
            txtGia.Text = "";
            cboLoaiMay.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1;
        }
        private void ThemXoaSuaClick(object sender, EventArgs e)
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
        }
        private void HuyOKClick(object sender, EventArgs e)
        {
            //Guna2Button btn = sender as Guna2Button;
            SetAllButtonEnableAndInvisible();
            SetEnableComboboxAndTextBox(false);
        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            Guna2Button button = sender as Guna2Button;
            if (button.Checked == false)
            {
                panelCaiDat.Visible = true;
            }
            else
            {
                panelCaiDat.Visible = false;
            }
        }
    }
}
