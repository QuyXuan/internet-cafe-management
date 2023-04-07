using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GiaoDienPBL3.User_Controls
{
    public partial class UC_QuanLyDoanhThu : UserControl
    {
        public UC_QuanLyDoanhThu()
        {
            InitializeComponent();
            SetHoaDonKhachHangVaNhapKho();
            TinhTongTienKhachHangVaNhapKho();
        }
        private void SetColumnChart1()
        {
            if (dtpNgaySau.Value.Month != dtpNgayTruoc.Value.Month || dtpNgaySau.Value.Day <= dtpNgayTruoc.Value.Day)
            {
                MessageBox.Show("Chỉ Xem Được Ngày Trong Cùng 1 Tháng" + Environment.NewLine + "Ngày Sau Phải Lớn Hơn Ngày Trước",
                    "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            ColumnChart1.ChartAreas[0].AxisX.Title = "Ngày";
            ColumnChart1.ChartAreas[0].AxisY.Title = "Nghìn đồng";
            Random rd = new Random();
            double dayDiff = (dtpNgaySau.Value.Day - dtpNgayTruoc.Value.Day);
            foreach (var series in ColumnChart1.Series)
            {
                series.Points.Clear();
            }
            if ((int)dayDiff > 0) 
            {
                for (int i = 0; i <= (int)dayDiff; i++)
                {
                    ColumnChart1.Series["Doanh Thu"].Points.AddXY(dtpNgayTruoc.Value.AddDays(i).ToString("dMMM"), rd.Next(100, 1000));
                    ColumnChart1.Series["Chi Trả"].Points.AddXY(dtpNgayTruoc.Value.AddDays(i).ToString("dMMM"), rd.Next(100, 1000));
                    ColumnChart1.Series["Lợi Nhuận"].Points.AddXY(dtpNgayTruoc.Value.AddDays(i).ToString("dMMM"), rd.Next(100, 1000));
                }
                ColumnChart1.ChartAreas[0].AxisY.Minimum = 99;
                ColumnChart1.ChartAreas[0].AxisY.Maximum = 1001;
            }
        }
        private void SetColumnChart2()
        {
            if (dtpNgaySau.Value.Year != dtpNgayTruoc.Value.Year || dtpThangSau.Value.Month <= dtpThangSau.Value.Month)
            {
                MessageBox.Show("Chỉ Xem Được Tháng Trong Cùng 1 Năm" + Environment.NewLine + "Tháng Sau Phải Lớn Hơn Tháng Trước",
                    "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            ColumnChart2.ChartAreas[0].AxisX.Title = "Tháng";
            ColumnChart2.ChartAreas[0].AxisY.Title = "Nghìn đồng";
            Random rd = new Random();
            double monthDiff = (dtpThangSau.Value.Month - dtpThangTruoc.Value.Month);

            foreach (var series in ColumnChart2.Series)
            {
                series.Points.Clear();
            }

            if ((int)monthDiff > 0)
            {
                for (int i = 0; i <= (int)monthDiff; i++)
                {
                    ColumnChart2.Series["Doanh Thu"].Points.AddXY(dtpThangTruoc.Value.AddMonths(i).ToString("MMM"), rd.Next(100, 1000));
                    ColumnChart2.Series["Chi Trả"].Points.AddXY(dtpThangTruoc.Value.AddMonths(i).ToString("MMM"), rd.Next(100, 1000));
                    ColumnChart2.Series["Lợi Nhuận"].Points.AddXY(dtpThangTruoc.Value.AddMonths(i).ToString("MMM"), rd.Next(100, 1000));
                }

                ColumnChart2.ChartAreas[0].AxisY.Minimum = 100;
                ColumnChart2.ChartAreas[0].AxisY.Maximum = 3000;
            }
        }

        private void tabControlThongKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlThongKe.SelectedIndex == 1)
            {
                dtpThangTruoc.Format = DateTimePickerFormat.Custom;
                dtpThangTruoc.CustomFormat = "MM/yyyy";
                dtpThangSau.Format = DateTimePickerFormat.Custom;
                dtpThangSau.CustomFormat = "MM/yyyy";
            }
        }

        private void LineChart_MouseMove(object sender, MouseEventArgs e)
        {
            var chart = (Chart)sender;
            var result = chart.HitTest(e.X, e.Y);
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                var dataPoint = result.Series.Points[result.PointIndex];
                var tooltip = string.Format("Value Y: {0}", dataPoint.YValues[0]);
                toolTip1.SetToolTip(chart, tooltip);
                dataPoint.MarkerStyle = MarkerStyle.Circle;
            }
            else
            {
                toolTip1.Hide(chart);
            }
        }
        //private void SetSplitContainer()
        //{
        //    splitContainer1.Panel1.s
        //}

        private void btnXemDoanhThuNgay_Click(object sender, EventArgs e)
        {
            SetColumnChart1();
        }

        private void btnXemDoanhThuThang_Click(object sender, EventArgs e)
        {
            SetColumnChart2();
        }
        private void SetHoaDonKhachHangVaNhapKho()
        {
            Random random = new Random();
            for (int i = 0; i < 7; i++)
            {
                UC_ChiTietHoaDonNhapKho myUC = new UC_ChiTietHoaDonNhapKho();
                myUC.TextMaDon = "mhdhk" + random.Next(0, 100);
                myUC.TextLoaiDon = "Đơn Khách Hàng";
                myUC.TextNgayTaoDon = DateTime.Now.ToString("dd/MM/yyyy");
                myUC.TextThanhTien = string.Format("{0:N3}VNĐ", random.Next(0, 1000));
                myUC.Size = new Size(panelHoaDonKhachHang.Size.Width - 22, 50);
                //myUC.Tag = myUC.TextThanhTien;
                panelHoaDonKhachHang.Controls.Add(myUC);
            }
            for (int i = 0; i < 5; i++)
            {
                UC_ChiTietHoaDonNhapKho myUC = new UC_ChiTietHoaDonNhapKho();
                myUC.TextMaDon = "mhdnk" + random.Next(0, 100);
                myUC.TextLoaiDon = "Đơn Nhập Kho";
                myUC.TextNgayTaoDon = DateTime.Now.ToString("dd/MM/yyyy");
                myUC.TextThanhTien = string.Format("{0:N3}VNĐ", random.Next(0, 100));
                myUC.BackColor = Color.FromArgb(255, 192, 192);
                myUC.Size = new Size(panelHoaDonNhapKho.Size.Width - 22, 50);
                panelHoaDonNhapKho.Controls.Add(myUC);
            }
        }
        private void TinhTongTienKhachHangVaNhapKho()
        {
            int TongTienKhachHang = 0;
            int TongTienNhapKho = 0;
            foreach (Control control in panelHoaDonKhachHang.Controls) 
            {
                string Tien = (control as UC_ChiTietHoaDonNhapKho).TextThanhTien;
                TongTienKhachHang += Convert.ToInt32(Tien.Substring(0, Tien.Length - 7).Replace(",", ""));
            }
            lblTongTienKhachHang.Text = string.Format("{0:N3}VNĐ", TongTienKhachHang);
            //
            foreach (Control control in panelHoaDonNhapKho.Controls)
            {
                string Tien = (control as UC_ChiTietHoaDonNhapKho).TextThanhTien;
                TongTienNhapKho += Convert.ToInt32(Tien.Substring(0, Tien.Length - 7).Replace(",", ""));
            }
            lblTongTienNhapKho.Text = string.Format("{0:N3}VNĐ", TongTienNhapKho);
            lblTongDoanhThu.Text = lblTongTienKhachHang.Text;
            lblTongChiTra.Text = lblTongTienNhapKho.Text;
            lblTongLoiNhuan.Text = string.Format("{0:N3}VNĐ", TongTienKhachHang - TongTienNhapKho);
        }
    }
}
