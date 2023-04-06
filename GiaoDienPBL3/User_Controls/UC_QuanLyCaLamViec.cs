using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaoDienPBL3.User_Controls
{
    public partial class UC_QuanLyCaLamViec : UserControl
    {
        private int lastRowIndex = -1;
        public UC_QuanLyCaLamViec()
        {
            InitializeComponent();
            SetData();
            AddColumnButton();
        }
        private void AddColumnButton()
        {
            DataGridViewButtonColumn buttonXoa = new DataGridViewButtonColumn();
            buttonXoa.HeaderText = "";
            buttonXoa.Text = "Xóa";
            buttonXoa.Name = "btnXoa";
            buttonXoa.FillWeight = 40;
            buttonXoa.UseColumnTextForButtonValue = true;
            dgvQuanLyCaLamViec.Columns.Add(buttonXoa);
            DataGridViewButtonColumn buttonSua = new DataGridViewButtonColumn();
            buttonSua.HeaderText = "";
            buttonSua.Text = "Sửa";
            buttonSua.Name = "btnSua";
            buttonSua.FillWeight = 40;
            buttonSua.UseColumnTextForButtonValue = true;
            dgvQuanLyCaLamViec.Columns.Add(buttonSua);
        }
        private void SetData()
        {
            string[] CaLamViec = { "Sáng Trưa", "Trưa Chiều", "Chiều Tối", "Tối Sáng" };
            string[] NhanViens = { "Quý", "Trường", "Sơn" };
            Random random = new Random();
            int count = 1;
            for (int i = 0; i < 50; i++)
            {
                dgvQuanLyCaLamViec.Rows.Add(new object[]
                {
                    (count++).ToString(), DateTime.Now.AddDays(-count).ToString("dd/MM/yyyy"), CaLamViec[random.Next(CaLamViec.Length)],
                    NhanViens[random.Next(NhanViens.Length)], string.Format("{0:N3}VNĐ", random.Next(100)),
                    string.Format("{0:N3}VNĐ", random.Next(100)), string.Format("{0:N3}VNĐ", random.Next(100)),
                    string.Format("{0:N3}VNĐ", random.Next(100)), string.Format("{0:N3}VNĐ", random.Next(100)),
                    string.Format("{0:N3}VNĐ", random.Next(100)), string.Format("{0:N3}VNĐ", random.Next(100))
                });
            }
            cboNhanVien.Items.AddRange(new object[]
            {
                "Tất Cả Nhân Viên","Quý", "Sơn", "Trường"
            });
            cboNhanVien.SelectedIndex = 0;
            cboCaLamViec1.SelectedIndex = 0;
        }

        private void dgvQuanLyCaLamViec_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvQuanLyCaLamViec.Columns["btnXoa"].Index && e.RowIndex >= 0)
                {
                    dgvQuanLyCaLamViec.Rows.RemoveAt(e.RowIndex);
                }
                else if (e.ColumnIndex == dgvQuanLyCaLamViec.Columns["btnSua"].Index && e.RowIndex >= 0)
                {
                    dgvQuanLyCaLamViec.ReadOnly = false;
                    dgvQuanLyCaLamViec.BeginEdit(true);
                    dgvQuanLyCaLamViec.Rows[e.RowIndex].ReadOnly = false;
                    dgvQuanLyCaLamViec.Rows[e.RowIndex].Cells["CaLamViec"].ReadOnly = false;
                    lastRowIndex = e.RowIndex;
                }
                else if (e.RowIndex != lastRowIndex)
                {
                    dgvQuanLyCaLamViec.ReadOnly = true;
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvQuanLyCaLamViec.Rows)
            {
                row.Visible = true;
            }
            if (dtpNgayLamViec1.Value <= DateTime.Now
                    && cboCaLamViec1.SelectedIndex == 0 && cboNhanVien.SelectedIndex == 0)
            {
                foreach (DataGridViewRow row in dgvQuanLyCaLamViec.Rows)
                {
                    if (DateTime.ParseExact(row.Cells["NgayLamViec"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) != dtpNgayLamViec1.Value.Date)
                    {
                        row.Visible = false;
                    }
                }
            }
            else if (dtpNgayLamViec1.Value <= DateTime.Now
                    && cboCaLamViec1.SelectedIndex > 0 && cboNhanVien.SelectedIndex == 0)
            {
                foreach (DataGridViewRow row in dgvQuanLyCaLamViec.Rows)
                {
                    if (DateTime.ParseExact(row.Cells["NgayLamViec"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) != dtpNgayLamViec1.Value.Date
                        || row.Cells["CaLamViec"].Value.ToString() != cboCaLamViec1.SelectedItem.ToString())
                    {
                        row.Visible = false;
                    }
                }
            }
            else if (dtpNgayLamViec1.Value <= DateTime.Now
                    && cboCaLamViec1.SelectedIndex == 0 && cboNhanVien.SelectedIndex > 0)
            {
                foreach (DataGridViewRow row in dgvQuanLyCaLamViec.Rows)
                {
                    if (DateTime.ParseExact(row.Cells["NgayLamViec"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) != dtpNgayLamViec1.Value.Date
                        || row.Cells["NhanVien"].Value.ToString() != cboNhanVien.SelectedItem.ToString())
                    {
                        row.Visible = false;
                    }
                }
            }
            else if (dtpNgayLamViec1.Value <= DateTime.Now
                    && cboCaLamViec1.SelectedIndex > 0 && cboNhanVien.SelectedIndex > 0)
            {
                foreach (DataGridViewRow row in dgvQuanLyCaLamViec.Rows)
                {
                    if (DateTime.ParseExact(row.Cells["NgayLamViec"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) != dtpNgayLamViec1.Value.Date
                        || row.Cells["CaLamViec"].Value.ToString() != cboCaLamViec1.SelectedItem.ToString()
                        || row.Cells["NhanVien"].Value.ToString() != cboNhanVien.SelectedItem.ToString())
                    {
                        row.Visible = false;
                    }
                }
            }
            else if (dtpNgayLamViec1.Value > DateTime.Now
                    && cboCaLamViec1.SelectedIndex > 0 && cboNhanVien.SelectedIndex > 0)
            {
                foreach (DataGridViewRow row in dgvQuanLyCaLamViec.Rows)
                {
                    if (row.Cells["CaLamViec"].Value.ToString() != cboCaLamViec1.SelectedItem.ToString()
                        || row.Cells["NhanVien"].Value.ToString() != cboNhanVien.SelectedItem.ToString())
                    {
                        row.Visible = false;
                    }
                }
            }
            else if (dtpNgayLamViec1.Value > DateTime.Now
                    && cboCaLamViec1.SelectedIndex == 0 && cboNhanVien.SelectedIndex > 0)
            {
                foreach (DataGridViewRow row in dgvQuanLyCaLamViec.Rows)
                {
                    if (row.Cells["NhanVien"].Value.ToString() != cboNhanVien.SelectedItem.ToString())
                    {
                        row.Visible = false;
                    }
                }
            }
            else if (dtpNgayLamViec1.Value > DateTime.Now
                    && cboCaLamViec1.SelectedIndex > 0 && cboNhanVien.SelectedIndex == 0)
            {
                foreach (DataGridViewRow row in dgvQuanLyCaLamViec.Rows)
                {
                    if (row.Cells["CaLamViec"].Value.ToString() != cboCaLamViec1.SelectedItem.ToString())
                    {
                        row.Visible = false;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvQuanLyCaLamViec.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            dtpNgayLamViec2.Value = DateTime.Now;
            cboCaLamViec2.SelectedIndex = -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvQuanLyCaLamViec);
            row.Cells[0].Value = (dgvQuanLyCaLamViec.Rows.Count + 1).ToString();
            row.Cells[1].Value = dtpNgayLamViec2.Value.ToString("dd/MM/yyyy");
            row.Cells[2].Value = cboCaLamViec2.SelectedItem.ToString().Substring(0, cboCaLamViec2.SelectedItem.ToString().Length - 14);
            row.Cells[3].Value = txtTenNhanVien.Text;
            row.Cells[4].Value = row.Cells[5].Value = row.Cells[6].Value
                = row.Cells[7].Value = row.Cells[8].Value = row.Cells[9].Value
                = row.Cells[10].Value = "";
            row.Height = 40;
            dgvQuanLyCaLamViec.Rows.Add(row);
            MessageBox.Show("Thêm Ca Làm Việc Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnHuy.PerformClick();
        }
    }
}
