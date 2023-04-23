using DTO;
using GiaoDienPBL3.UC;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Utilities.BunifuTextBox.Transitions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskBand;

namespace GiaoDienPBL3.User_Controls
{
    public partial class UC_QuanLyHoaDonNhapKho : UserControl
    {
        private Random random = new Random();
        private List<Control> listUCThongTinHangHoa;
        public UC_QuanLyHoaDonNhapKho()
        {
            InitializeComponent();
            listUCThongTinHangHoa = new List<Control>();
            SetData();
        }

        private void btnHuyXacNhan_Click(object sender, EventArgs e)
        {
            Guna2Button button = sender as Guna2Button;
            if (button.Name == "btnXacNhan")
            {
                if (CheckValid() == false) return;
                UC_ChiTietMonAn my_UCChiTietMonAn = new UC_ChiTietMonAn();
                my_UCChiTietMonAn.btnCongMon.Visible = false;
                my_UCChiTietMonAn.btnTruMon.Visible = false;
                int ThanhTien = Convert.ToInt32(txtSoLuong.Text) * Convert.ToInt32((txtGiaGoc.Text.Substring(0, txtGiaGoc.Text.Length - 4).Replace(",", "")));
                my_UCChiTietMonAn.TextGiaMonAn = string.Format("{0:N3}VNĐ", ThanhTien);
                my_UCChiTietMonAn.TextTenMonAn = txtTenHangHoa.Text;
                my_UCChiTietMonAn.TextSoLuongMonAn = txtSoLuong.Text;
                my_UCChiTietMonAn.Size = new Size(300, 56);
                listUCThongTinHangHoa.Add(my_UCChiTietMonAn);
                panelHoaDon.Controls.Add(my_UCChiTietMonAn);
                //panelHoaDon.Controls.SetChildIndex(my_UCChiTietMonAn, 1);
                int TongTien = Convert.ToInt32(lblTongTien.Text.Substring(0, lblTongTien.Text.Length - 7).Replace(",", "")) + ThanhTien;
                lblTongTien.Text = string.Format("{0:N3}VNĐ", TongTien);
                HangHoa hangHoa = new HangHoa(txtMaHangHoa.Text, txtTenHangHoa.Text, Convert.ToInt32(txtSoLuong.Text), cboLoai.Text, my_UCChiTietMonAn.TextGiaMonAn);
                my_UCChiTietMonAn.Tag = hangHoa;
            }
            txtMaHangHoa.Text = "";
            txtTenHangHoa.Text = "";
            txtSoLuong.Text = "";
            txtGiaGoc.Text = "";
            txtTongTien.Text = "";
            cboLoai.SelectedIndex = -1;
            panelChiTietHangNhap.Visible = false;
        }
        private bool CheckValid()
        {
            if (txtMaHoaDon.Text == "")
            {
                MessageBox.Show("Mã Hóa Đơn Không Được Để Trống", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtTenHangHoa.Text == "")
            {
                MessageBox.Show("Tên Món Không Được Để Trống", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            else if (int.TryParse(txtSoLuong.Text, out _) == false)
            {
                MessageBox.Show("Số Lượng Phải Là Một Số Nguyên", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            else if((txtGiaGoc.Text.Length < 4) || txtGiaGoc.Text.Substring(txtGiaGoc.Text.Length - 4) != ".000")
            {
                MessageBox.Show("Bạn Phải Nhập Theo Định Dạng #,###.000" + Environment.NewLine + "Ví Dụ: 20.000 / 1,000.000", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtNhaCungCap.Text == "")
            {
                MessageBox.Show("Tên Nhà Cung Cấp Không Được Để Trống", "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void SetData()
        {
            txtMaHoaDon.Text = "mdh" + random.Next(0, 100);
            txtMaNhanVien.Text = "nv" + random.Next(0, 100);
            txtTenNhanVien.Text = "Quy";
            txtGiamGia.Text = "0%";
            for (int i = 0; i < 50; i++)
            {
                dgvHoaDonNhap.Rows.Add(new object[]
                {
                    "mdh" + random.Next(0, 100), "nv" + random.Next(0, 100), "QuyXuan", DateTime.Now.ToString("dd/MM/yyyy"), random.Next(0, 100) + "%", random.Next(1, 999) + ".000VNĐ"
                });
            }
            dgvHoaDonNhap.ClearSelection();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            panelChiTietHangNhap.Visible = true;
            panelHoaDon.Controls.SetChildIndex(panelChiTietHangNhap, panelHoaDon.Controls.Count - 1);
            //panelChiTietHangNhap.Size.Width = panelHoaDon.Size.Width - 2;
            txtNhaCungCap.Enabled = true;
            txtGiamGia.Enabled = true;
            dtpNgayNhan.Enabled = true;
            txtMaHangHoa.Focus();
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
            txtMaHoaDon.Enabled = status;
            txtTongTien.Enabled = status;
            dtpNgayNhan.Enabled = status;
            txtMaNhanVien.Enabled = status;
            txtTenNhanVien.Enabled = status;
            txtNhaCungCap.Enabled = status;
            txtGiamGia.Enabled = status;
        }
        private void ClearComboboxAndTextBox()
        {
            txtTongTien.Text = "";
            txtTenNhanVien.Text = "";
            txtNhaCungCap.Text = "";
            txtGiamGia.Text = "";
            dtpNgayNhan.Value = DateTime.Now;
        }
        private void btnXoaSuaClick(object sender, EventArgs e)
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
            //lastButton = btn;
        }
        private void btnHuyOKClick(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            //if (btn.Name == "btnOK")
            //{
            //    if (lastButton.Name == "btnThem")
            //    {
            //        AddMonAn(SetMonAn());
            //    }
            //}
            SetAllButtonEnableAndInvisible();
            SetEnableComboboxAndTextBox(false);
        }

        private void btnThemChiTietHangNhap_Click(object sender, EventArgs e)
        {
            if (listUCThongTinHangHoa.Count == 0) return;
            List<HangHoa> listHangHoa = new List<HangHoa>();
            foreach (Control control in listUCThongTinHangHoa)
            {
                HangHoa hangHoa = (control as UC_ChiTietMonAn).Tag as HangHoa;
                listHangHoa.Add(hangHoa);
                panelHoaDon.Controls.Remove(control);
                control.Dispose();
            }
            listUCThongTinHangHoa.Clear();
            lblTongTien.Text = "0.000VNĐ";
            DataGridViewRow row = new DataGridViewRow();
            row.Height = 40;
            row.CreateCells(dgvHoaDonNhap, txtMaHoaDon.Text, txtMaNhanVien.Text, txtNhaCungCap.Text, dtpNgayNhan.Value.ToString("dd/MM/yyyy"), txtGiamGia.Text, lblTongTien.Text);
            row.Tag = listHangHoa;
            dgvHoaDonNhap.Rows.Add(row);
        }

        private void btnHuyTatCa_Click(object sender, EventArgs e)
        {
            foreach (Control control in listUCThongTinHangHoa)
            {
                panelHoaDon.Controls.Remove(control);
                control.Dispose();
            }
            listUCThongTinHangHoa.Clear();
            lblTongTien.Text = "0.000VNĐ";
        }

        private void dgvHoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            DataGridViewRow Row = dgvHoaDonNhap.SelectedRows[0];
            txtMaHoaDon.Text = Row.Cells["MaHoaDon"].Value.ToString();
            txtMaNhanVien.Text = Row.Cells["MaNhanVien"].Value.ToString();
            txtNhaCungCap.Text = Row.Cells["NhaCungCap"].Value.ToString();
            dtpNgayNhan.Value = DateTime.ParseExact(Row.Cells["NgayNhan"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            txtGiamGia.Text = Row.Cells["GiamGia"].Value.ToString();
            txtTongTien.Text = Row.Cells["TongTien"].Value.ToString();
            if (Row.Tag == null)
            {
                lvThongTinHangHoa.Items.Clear();
                return;
            }
            List<HangHoa> listHangHoa = Row.Tag as List<HangHoa>;
            lvThongTinHangHoa.Items.Clear();
            foreach (HangHoa hangHoa in listHangHoa)
            {
                ListViewItem item = new ListViewItem(hangHoa.MaHangHoa);
                item.SubItems.Add(hangHoa.TenHangHoa);
                item.SubItems.Add(hangHoa.SoLuong.ToString());
                item.SubItems.Add(hangHoa.Gia);
                item.SubItems.Add(hangHoa.Loai);
                lvThongTinHangHoa.Items.Add(item);
            }
        }
    }
}
