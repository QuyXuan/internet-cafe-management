using BLL;
using DTO;
using GiaoDienPBL3.UC;
using Guna.UI2.WinForms;
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

namespace GiaoDienPBL3.User_Controls
{
    public partial class UC_ThongTinVaCaiDatMonAn : UserControl
    {
        private Guna2Button lastButton = null;
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
            lastButton = btn;
        }
        private void HuyOKClick(object sender, EventArgs e)
        {
            //Guna2Button btn = sender as Guna2Button;
            //if (btn.Name == "btnOK")
            //{
            //    if (lastButton.Name == "btnThem")
            //    {
            //        AddMonAn(SetMonAn());
            //    }
            //}
            //SetAllButtonEnableAndInvisible();
            //SetEnableComboboxAndTextBox(false);
        }
        //private void AddMonAn(MonAn monAn)
        //{
        //    UC_MonAn my_UCMonAn = new UC_MonAn();
        //    my_UCMonAn.TextGiaMonAn = string.Format("{0:N3}VNĐ", monAn.Gia);
        //    my_UCMonAn.TextTenMonAn = monAn.TenMonAn;
        //    my_UCMonAn.ImagePanel = GetAnhByPathAnhMon(monAn.PathAnhMon);
        //    my_UCMonAn.Tag = monAn;
        //    frmMain.myUC_QuanLyMenu.panelMonAn.Controls.Add(my_UCMonAn);
        //}
        private Image GetAnhByPathAnhMon(string path)
        {
            try
            {
                Image image = Image.FromFile(path);
                return image;
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }
        private string GetPath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn Ảnh";
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                return filePath;
            }
            return null;
        }
        //private MonAn SetMonAn()
        //{
        //    MonAn monAn = new MonAn();
        //    monAn.MaMonAn = txtMaMon.Text.Trim();
        //    monAn.TenMonAn = txtTenMon.Text.Trim();
        //    monAn.Gia = Convert.ToInt32(txtGia.Text);
        //    monAn.Loai = cboLoai.SelectedItem.ToString();
        //    monAn.PathAnhMon = txtPath.Text.Trim();
        //    return monAn;
        //}

        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            txtPath.Text = GetPath();
            if (txtPath.Text == String.Empty)
            {
                txtPath.Text = "Đường Dẫn Không Hợp Lệ";
            }
        }
    }
}