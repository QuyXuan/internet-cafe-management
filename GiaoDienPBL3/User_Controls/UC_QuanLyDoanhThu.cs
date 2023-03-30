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
        }
        private void SetLineChart()
        {
            if (dtpNgaySau.Value.Month != dtpNgayTruoc.Value.Month || dtpNgaySau.Value.Day <= dtpNgayTruoc.Value.Day)
            {
                MessageBox.Show("Chỉ Xem Được Ngày Trong Cùng 1 Tháng" + Environment.NewLine + "Ngày Sau Phải Lớn Hơn Ngày Trước",
                    "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            LineChart.ChartAreas[0].AxisX.Title = "Ngày";
            LineChart.ChartAreas[0].AxisY.Title = "Nghìn đồng";
            Random rd = new Random();
            double dayDiff = (dtpNgaySau.Value.Day - dtpNgayTruoc.Value.Day);
            foreach (var series in LineChart.Series)
            {
                series.Points.Clear();
            }
            if ((int)dayDiff > 0) 
            {
                for (int i = 0; i <= (int)dayDiff; i++)
                {
                    LineChart.Series["Doanh Thu"].Points.AddXY(dtpNgayTruoc.Value.AddDays(i).ToString("dMMM"), rd.Next(100, 1000));
                    LineChart.Series["Chi Trả"].Points.AddXY(dtpNgayTruoc.Value.AddDays(i).ToString("dMMM"), rd.Next(100, 1000));
                    LineChart.Series["Lợi Nhuận"].Points.AddXY(dtpNgayTruoc.Value.AddDays(i).ToString("dMMM"), rd.Next(100, 1000));
                }
                LineChart.ChartAreas[0].AxisY.Minimum = 99;
                LineChart.ChartAreas[0].AxisY.Maximum = 1001;
            }
        }
        private void SetColumnChart()
        {
            if (dtpNgaySau.Value.Year != dtpNgayTruoc.Value.Year || dtpThangSau.Value.Month <= dtpThangSau.Value.Month)
            {
                MessageBox.Show("Chỉ Xem Được Tháng Trong Cùng 1 Năm" + Environment.NewLine + "Tháng Sau Phải Lớn Hơn Tháng Trước",
                    "Cảnh Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            ColumnChart.ChartAreas[0].AxisX.Title = "Tháng";
            ColumnChart.ChartAreas[0].AxisY.Title = "Nghìn đồng";
            Random rd = new Random();
            double monthDiff = (dtpThangSau.Value.Month - dtpThangTruoc.Value.Month);

            foreach (var series in ColumnChart.Series)
            {
                series.Points.Clear();
            }

            if ((int)monthDiff > 0)
            {
                for (int i = 0; i <= (int)monthDiff; i++)
                {
                    ColumnChart.Series["Doanh Thu"].Points.AddXY(dtpThangTruoc.Value.AddMonths(i).ToString("MMM"), rd.Next(100, 1000));
                    ColumnChart.Series["Chi Trả"].Points.AddXY(dtpThangTruoc.Value.AddMonths(i).ToString("MMM"), rd.Next(100, 1000));
                    ColumnChart.Series["Lợi Nhuận"].Points.AddXY(dtpThangTruoc.Value.AddMonths(i).ToString("MMM"), rd.Next(100, 1000));
                }

                ColumnChart.ChartAreas[0].AxisY.Minimum = 100;
                ColumnChart.ChartAreas[0].AxisY.Maximum = 3000;
            }
        }
        private void btnXemDoanhThuNgay_Click(object sender, EventArgs e)
        {
            SetLineChart();
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

        private void btnXemDoanhThuThang_Click(object sender, EventArgs e)
        {
            SetColumnChart();
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
    }
}
