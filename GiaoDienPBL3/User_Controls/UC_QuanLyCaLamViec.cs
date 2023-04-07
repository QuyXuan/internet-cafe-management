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
            SetDataQuanLyLichSuCaLamViec();
            SetDataQuanLyCaLamViecTrongNgay();
            AddColumnButton();
            timerThoiGianHienTai.Start();
        }
        private void AddColumnButton()
        {
            DataGridViewButtonColumn buttonXoa = new DataGridViewButtonColumn();
            buttonXoa.HeaderText = "";
            buttonXoa.Text = "Xóa";
            buttonXoa.Name = "btnXoa";
            buttonXoa.FillWeight = 40;
            buttonXoa.UseColumnTextForButtonValue = true;
            dgvQuanLyLichSuCaLamViec.Columns.Add(buttonXoa);
            dgvQuanLyCaLamViecTrongNgay.Columns.Add(buttonXoa.Clone() as DataGridViewButtonColumn);
            DataGridViewButtonColumn buttonSua = new DataGridViewButtonColumn();
            buttonSua.HeaderText = "";
            buttonSua.Text = "Sửa";
            buttonSua.Name = "btnSua";
            buttonSua.FillWeight = 40;
            buttonSua.UseColumnTextForButtonValue = true;
            dgvQuanLyLichSuCaLamViec.Columns.Add(buttonSua);
            dgvQuanLyCaLamViecTrongNgay.Columns.Add(buttonSua.Clone() as DataGridViewButtonColumn);
        }
        private void SetDataQuanLyLichSuCaLamViec()
        {
            string[] CaLamViec = { "Sáng Trưa", "Trưa Chiều", "Chiều Tối", "Tối Sáng" };
            string[] NhanViens = { "Quý", "Trường", "Sơn" };
            Random random = new Random();
            int count = 1;
            for (int i = 0; i < 50; i++)
            {
                dgvQuanLyLichSuCaLamViec.Rows.Add(new object[]
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

        private void dgvQuanLyVaLichSuCaLamViec_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = sender as DataGridView;
                if (e.ColumnIndex == dgv.Columns["btnXoa"].Index && e.RowIndex >= 0)
                {
                    dgv.Rows.RemoveAt(e.RowIndex);
                }
                else if (e.ColumnIndex == dgv.Columns["btnSua"].Index && e.RowIndex >= 0)
                {
                    dgv.ReadOnly = false;
                    dgv.BeginEdit(true);
                    dgv.Rows[e.RowIndex].ReadOnly = false;
                    dgv.Rows[e.RowIndex].Cells["CaLamViec"].ReadOnly = false;
                    lastRowIndex = e.RowIndex;
                }
                else if (e.RowIndex != lastRowIndex)
                {
                    dgv.ReadOnly = true;
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvQuanLyLichSuCaLamViec.Rows)
            {
                row.Visible = true;
            }
            if (dtpNgayLamViec1.Value <= DateTime.Now
                    && cboCaLamViec1.SelectedIndex == 0 && cboNhanVien.SelectedIndex == 0)
            {
                foreach (DataGridViewRow row in dgvQuanLyLichSuCaLamViec.Rows)
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
                foreach (DataGridViewRow row in dgvQuanLyLichSuCaLamViec.Rows)
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
                foreach (DataGridViewRow row in dgvQuanLyLichSuCaLamViec.Rows)
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
                foreach (DataGridViewRow row in dgvQuanLyLichSuCaLamViec.Rows)
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
                foreach (DataGridViewRow row in dgvQuanLyLichSuCaLamViec.Rows)
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
                foreach (DataGridViewRow row in dgvQuanLyLichSuCaLamViec.Rows)
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
                foreach (DataGridViewRow row in dgvQuanLyLichSuCaLamViec.Rows)
                {
                    if (row.Cells["CaLamViec"].Value.ToString() != cboCaLamViec1.SelectedItem.ToString())
                    {
                        row.Visible = false;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvQuanLyLichSuCaLamViec.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            //dtpNgayLamViec2.Value = DateTime.Now;
            cboCaLamViec2.SelectedIndex = -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvQuanLyCaLamViecTrongNgay);
            row.Cells[0].Value = (dgvQuanLyCaLamViecTrongNgay.Rows.Count + 1).ToString();
            //row.Cells[1].Value = dtpNgayLamViec2.Value.ToString("dd/MM/yyyy");
            row.Cells[1].Value = cboCaLamViec2.SelectedItem.ToString().Substring(0, cboCaLamViec2.SelectedItem.ToString().Length - 14);
            row.Cells[2].Value = txtTenNhanVien.Text;
            row.Height = 40;
            dgvQuanLyCaLamViecTrongNgay.Rows.Add(row);
            MessageBox.Show("Thêm Ca Làm Việc Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnHuy.PerformClick();
        }
        private void SetDataQuanLyCaLamViecTrongNgay()
        {
            lblNgayHienTai.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void timerThoiGianHienTai_Tick(object sender, EventArgs e)
        {
            lblNgayHienTai.Text = DateTime.Now.ToString();
        }
    }
}
