using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GiaoDienPBL3.UC
{
    public partial class UC_QuanLyMenu : UserControl
    {
        public UC_QuanLyMenu()
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
            txtMaMon.Enabled = status;
            txtTenMon.Enabled = status;
            txtGia.Enabled = status;
            cboLoai.Enabled = status;
            btnThemAnh.Enabled = status;
        }
        private void ClearComboboxAndTextBox()
        {
            txtMaMon.Text = "";
            txtTenMon.Text = "";
            txtGia.Text = "";
            cboLoai.SelectedIndex = -1;
        }
        private void ThemXoaSuaClick(object sender, EventArgs e)
        {

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
