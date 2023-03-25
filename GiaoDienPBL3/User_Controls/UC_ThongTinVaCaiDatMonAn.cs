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

namespace GiaoDienPBL3.User_Controls
{
    public partial class UC_ThongTinVaCaiDatMonAn : UserControl
    {
        public string TextMaMon
        {
            get { return txtMaMon.Text.Trim(); }
            set { txtMaMon.Text = value; }
        }
        public string TextTenMon
        {
            get { return txtTenMon.Text.Trim(); }
            set { txtTenMon.Text = value; }
        }
        public string TextGia
        {
            get { return txtGia.Text.Trim(); }
            set { txtGia.Text = value; }
        }
        public string TextLoai
        {
            get { return cboLoai.SelectedItem?.ToString(); }
            set
            {
                if (cboLoai.Items.Contains(value))
                {
                    cboLoai.SelectedItem = value;
                }
            }
        }
        //public Image AnhMon
        //{
        //    get; set;
        //}
        public UC_ThongTinVaCaiDatMonAn()
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
    }
}
