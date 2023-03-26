using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaoDienPBL3.User_Controls
{
    public partial class UC_ThongTinVaCaiDatMay : UserControl
    {
        private Guna2Button lastButton = null;
        private Dictionary<string, Color> COLOR;
        public string TextMaMay
        {
            get { return txtMaMay.Text.Trim(); }
            set { txtMaMay.Text = value; }
        }
        public string TextTenMay
        {
            get { return txtSoMay.Text.Trim(); }
            set { txtSoMay.Text = value; }
        }
        public string TextGia
        {
            get { return txtGia.Text.Trim(); }
            set { txtGia.Text = value; }
        }
        public string TextLoaiMay
        {
            get { return cboLoaiMay.SelectedItem?.ToString(); }
            set
            {
                if (cboLoaiMay.Items.Contains(value))
                {
                    cboLoaiMay.SelectedItem = value;
                }
            }
        }
        public string TextTrangThai
        {
            get { return cboTrangThai.SelectedItem?.ToString(); }
            set
            {
                if (cboTrangThai.Items.Contains(value))
                {
                    cboTrangThai.SelectedItem = value;
                }
            }
        }
        public UC_ThongTinVaCaiDatMay()
        {
            InitializeComponent();
            AddMauSac();
        }
        private void AddMauSac()
        {
            COLOR = new Dictionary<string, Color>();
            COLOR.Add("Red", Color.Red);
            COLOR.Add("Purple", Color.FromArgb(107, 13, 179));
            COLOR.Add("BrightBlue", Color.FromArgb(77, 167, 236));
            COLOR.Add("Brown", Color.FromArgb(128, 64, 0));
            COLOR.Add("Yellow", Color.FromArgb(211, 240, 17));
            COLOR.Add("BrightYellow", Color.FromArgb(185, 192, 138));
            COLOR.Add("Green", Color.FromArgb(17, 240, 55));
            COLOR.Add("Black", Color.Black);
            COLOR.Add("Pink", Color.FromArgb(225, 33, 246));
            COLOR.Add("Blue", Color.Blue);
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
            lastButton = btn;
        }
        private void HuyOKClick(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            if (btn.Name == "btnOK")
            {
                if (lastButton.Name == "btnThem")
                {
                    AddMay(GetMay());
                }
            }
            SetAllButtonEnableAndInvisible();
            SetEnableComboboxAndTextBox(false);
        }
        private void AddMay(May may)
        {
            Guna2Button button = new Guna2Button();
            button.Size = new Size(60, 60);
            button.FillColor = Color.Gray;
            button.BorderColor = Color.Transparent;
            button.BorderRadius = 8;
            button.BorderThickness = 3;
            button.Margin = new Padding(10, 10, 10, 10);
            button.Text = may.SoMay;
            if (may.LoaiMay == "Khách")
                button.BorderColor = COLOR["Purple"];
            else if (may.LoaiMay == "Khách Thường Xuyên")
                button.BorderColor = COLOR["BrightBlue"];
            else if (may.LoaiMay == "Administrator")
                button.BorderColor = COLOR["Brown"];
            else if (may.LoaiMay == "Nhân Viên")
                button.BorderColor = COLOR["Yellow"];
            else if (may.LoaiMay == "Học Sinh")
                button.BorderColor = COLOR["BrightYellow"];
            else if (may.LoaiMay == "Online")
                button.BorderColor = COLOR["Green"];
            else if (may.LoaiMay == "Offline")
                button.BorderColor = COLOR["Black"];
            else if (may.LoaiMay == "Trả Sau")
                button.BorderColor = COLOR["Pink"];
            if (may.TrangThai == "Còn 5 Phút")
                button.FillColor = COLOR["Red"];
            else if (may.TrangThai == "Bảo Trì")
                button.FillColor = COLOR["Blue"];
            button.Tag = may;
            frmMain.myUC_QuanLyMay.panelQuanLyMay.Controls.Add(button);
        }
        private May GetMay()
        {
            May may = new May();
            may.MaMay = txtMaMay.Text.Trim();
            may.SoMay = txtSoMay.Text.Trim();
            may.Gia = Convert.ToInt32(txtGia.Text.Trim());
            may.TrangThai = cboTrangThai.SelectedItem.ToString();
            may.LoaiMay = cboLoaiMay.SelectedItem.ToString();
            return may;
        }
    }
}
