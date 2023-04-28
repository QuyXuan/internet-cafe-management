using BLL;
using DTO;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace GiaoDienPBL3.User_Controls
{
    public partial class UC_QuanLyDoanhThu : UserControl
    {
        public UC_QuanLyDoanhThu()
        {
            InitializeComponent();
        }
        private void SetColumnChart1()
        {
            if (dtpNgaySau.Value.Month != dtpNgayTruoc.Value.Month || dtpNgaySau.Value.Day < dtpNgayTruoc.Value.Day)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Chỉ Xem Được Ngày Trong Cùng 1 Tháng" + Environment.NewLine + "Ngày Sau Phải Lớn Hơn Ngày Trước");
                return;
            }
            ColumnChart1.ChartAreas[0].AxisX.Title = "Ngày";
            ColumnChart1.ChartAreas[0].AxisY.Title = "Nghìn đồng";
            foreach (var series in ColumnChart1.Series)
            {
                series.Points.Clear();
            }
            List<RecieptBillDayTotalPrice> listRecieptBillDayPrice = new List<RecieptBillDayTotalPrice>();
            foreach (BillDay billDay in BillBLL.Instance.GetListBillDayByType(true))
            {
                if (billDay.Date >= dtpNgayTruoc.Value.Date && billDay.Date <= dtpNgaySau.Value.Date)
                {
                    ColumnChart1.Series["Doanh Thu"].Points.AddXY(billDay.Date.ToString("dMMM"), billDay.TotalBill);
                    listRecieptBillDayPrice.Add(new RecieptBillDayTotalPrice
                    {
                        BillPrice = billDay.TotalBill,
                        Date = billDay.Date
                    });
                }
            }
            foreach (BillDay billDay in BillBLL.Instance.GetListBillDayByType(false))
            {
                if (billDay.Date >= dtpNgayTruoc.Value && billDay.Date <= dtpNgaySau.Value)
                {
                    ColumnChart1.Series["Chi Trả"].Points.AddXY(billDay.Date.ToString("dMMM"), billDay.TotalBill);
                    foreach (RecieptBillDayTotalPrice item in listRecieptBillDayPrice)
                    {
                        if (item.Date == billDay.Date)
                        {
                            item.RecieptPrice = billDay.TotalBill;
                        }
                        else
                        {
                            item.RecieptPrice = 0;
                        }
                    }
                }
            }
            foreach (var item in listRecieptBillDayPrice)
            {
                ColumnChart1.Series["Lợi Nhuận"].Points.AddXY(item.Date.ToString("dMMM"), (item.BillPrice - item.RecieptPrice) >= 0 ? item.BillPrice - item.RecieptPrice : 0);
            }
            //ColumnChart1.ChartAreas[0].AxisY.Minimum = MinTotalBill;
            //ColumnChart1.ChartAreas[0].AxisY.Maximum = MaxTotalBill;
        }
        private void SetColumnChart2()
        {
            if (dtpNgaySau2.Value.Year != dtpNgayTruoc2.Value.Year || dtpNgaySau2.Value.Month < dtpNgaySau2.Value.Month)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Chỉ Xem Được Tháng Trong Cùng 1 Năm" + Environment.NewLine + "Tháng Sau Phải Lớn Hơn Hoặc Bằng Tháng Trước");
                return;
            }
            ColumnChart2.ChartAreas[0].AxisX.Title = "Tháng";
            ColumnChart2.ChartAreas[0].AxisY.Title = "Nghìn đồng";
            foreach (var series in ColumnChart2.Series)
            {
                series.Points.Clear();
            }
            for (int i = dtpNgayTruoc2.Value.Month; i <= dtpNgaySau2.Value.Month; i++)
            {
                float TotalBillMonth = 0;
                foreach (BillDay billDay in BillBLL.Instance.GetListBillDayByType(true))
                {
                    if (billDay.Date.Month == i)
                    {
                        TotalBillMonth += billDay.TotalBill;
                    }
                }
                ColumnChart2.Series["Doanh Thu"].Points.AddXY(DateTimeFormatInfo.CurrentInfo.GetMonthName(i) + dtpNgayTruoc2.Value.Year, TotalBillMonth);

                float TotalRecieptMonth = 0;
                foreach (BillDay billDay in BillBLL.Instance.GetListBillDayByType(false))
                {
                    if (billDay.Date.Month == i)
                    {
                        TotalRecieptMonth += billDay.TotalBill;
                    }
                }
                ColumnChart2.Series["Chi Trả"].Points.AddXY(DateTimeFormatInfo.CurrentInfo.GetMonthName(i) + dtpNgayTruoc2.Value.Year, TotalRecieptMonth);
            }
        }

        private void tabControlThongKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlThongKe.SelectedIndex == 1)
            {
                dtpNgayTruoc2.Format = DateTimePickerFormat.Custom;
                dtpNgayTruoc2.CustomFormat = "MM/yyyy";
                dtpNgaySau2.Format = DateTimePickerFormat.Custom;
                dtpNgaySau2.CustomFormat = "MM/yyyy";
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

        private void btnXemDoanhThuNgay_Click(object sender, EventArgs e)
        {
            SetColumnChart1();
        }

        private void btnXemDoanhThuThang_Click(object sender, EventArgs e)
        {
            SetColumnChart2();
        }

        private void btnXemThongKeHoaDonTheoNgay_Click(object sender, EventArgs e)
        {
            if (dtpNgaySau3.Value.Day < dtpNgayTruoc3.Value.Day)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Chỉ Xem Được Ngày Trong Cùng 1 Tháng" + Environment.NewLine + "Ngày Sau Phải Lớn Hơn Hoặc Bằng Ngày Trước");
                return;
            }
            panelHoaDonKhachHang.Controls.Clear();
            panelHoaDonNhapKho.Controls.Clear();
            float TongTienKhachHang = 0;
            float TongTienNhapKho = 0;
            foreach (Bill bill in BillBLL.Instance.GetListBillWithStatus("Chấp Nhận"))
            {
                if (bill.Date >= dtpNgayTruoc3.Value.Date && bill.Date <= dtpNgaySau3.Value.Date)
                {
                    UC_ChiTietHoaDonNhapKho myUC = new UC_ChiTietHoaDonNhapKho();
                    myUC.TextMaDon = bill.BillId;
                    myUC.TextLoaiDon = "Đơn Khách Hàng";
                    myUC.TextNgayTaoDon = bill.Date.Value.ToString("dd/MM/yyyy");
                    myUC.TextThanhTien = string.Format("{0:N3}VNĐ", bill.Total);
                    myUC.Size = new Size(panelHoaDonKhachHang.Size.Width - 22, 60);
                    panelHoaDonKhachHang.Controls.Add(myUC);
                    TongTienKhachHang = TongTienKhachHang + bill.Total ?? 0;
                }
            }
            foreach (Reciept reciept in RecieptBLL.Instance.GetListReciept())
            {
                if (reciept.Date >= dtpNgayTruoc3.Value && reciept.Date <= dtpNgaySau3.Value)
                {
                    UC_ChiTietHoaDonNhapKho myUC = new UC_ChiTietHoaDonNhapKho();
                    myUC.TextMaDon = reciept.RecieptId;
                    myUC.TextLoaiDon = "Đơn Nhập Kho";
                    myUC.TextNgayTaoDon = reciept.Date.Value.ToString("dd/MM/yyyy");
                    myUC.TextThanhTien = string.Format("{0:N3}VNĐ", reciept.TotalBill);
                    myUC.BackColor = Color.FromArgb(255, 192, 192);
                    myUC.Size = new Size(panelHoaDonNhapKho.Size.Width - 22, 60);
                    panelHoaDonNhapKho.Controls.Add(myUC);
                    TongTienNhapKho = TongTienNhapKho + reciept.TotalBill ?? 0;
                }
            }
            lblTongTienKhachHang.Text = lblTongDoanhThu.Text = string.Format("{0:N3}VNĐ", TongTienKhachHang);
            lblTongTienNhapKho.Text = lblTongChiTra.Text = string.Format("{0:N3}VNĐ", TongTienNhapKho);
            lblTongLoiNhuan.Text = string.Format("{0:N3}VNĐ", TongTienKhachHang - TongTienNhapKho);
        }

        private void btnXemThongKeHoaDonTheoThang_Click(object sender, EventArgs e)
        {
            if (dtpNgaySau2.Value.Month < dtpNgaySau2.Value.Month)
            {
                frmMessageBox.Instance.ShowFrmMessageBox(frmMessageBox.StatusResult.Warning, "Chỉ Xem Được Tháng Trong Cùng 1 Năm" + Environment.NewLine + "Tháng Sau Phải Lớn Hơn Hoặc Bằng Tháng Trước");
                return;
            }
            panelHoaDonKhachHang2.Controls.Clear();
            panelHoaDonNhapKho2.Controls.Clear();
            for (int i = dtpNgayTruoc4.Value.Month; i <= dtpNgaySau4.Value.Month; i++)
            {
                float TotalBillMonth = 0;
                foreach (BillDay billDay in BillBLL.Instance.GetListBillDayByType(true))
                {
                    if (billDay.Date.Month == i)
                    {
                        UC_ChiTietHoaDonNhapKho myUC = new UC_ChiTietHoaDonNhapKho();
                        myUC.TextMaDon = billDay.BillDayId;
                        myUC.TextLoaiDon = "Đơn Khách Hàng";
                        myUC.TextNgayTaoDon = billDay.Date.ToString("dd/MM/yyyy");
                        myUC.TextThanhTien = string.Format("{0:N3}VNĐ", billDay.TotalBill);
                        myUC.Size = new Size(panelHoaDonKhachHang.Size.Width - 22, 60);
                        panelHoaDonKhachHang2.Controls.Add(myUC);
                        TotalBillMonth = TotalBillMonth + billDay.TotalBill;
                    }
                }
                lblTongTienKhachHang2.Text = lblTongDoanhThu2.Text = string.Format("{0:N3}VNĐ", TotalBillMonth);

                float TotalRecieptMonth = 0;
                foreach (BillDay billDay in BillBLL.Instance.GetListBillDayByType(false))
                {
                    if (billDay.Date.Month == i)
                    {
                        UC_ChiTietHoaDonNhapKho myUC = new UC_ChiTietHoaDonNhapKho();
                        myUC.TextMaDon = billDay.BillDayId;
                        myUC.TextLoaiDon = "Đơn Nhập Kho";
                        myUC.TextNgayTaoDon = billDay.Date.ToString("dd/MM/yyyy");
                        myUC.TextThanhTien = string.Format("{0:N3}VNĐ", billDay.TotalBill);
                        myUC.Size = new Size(panelHoaDonKhachHang.Size.Width - 22, 60);
                        myUC.BackColor = Color.FromArgb(255, 192, 192);
                        panelHoaDonNhapKho2.Controls.Add(myUC);
                        TotalRecieptMonth = TotalRecieptMonth + billDay.TotalBill;
                    }
                }
                lblTongTienNhapKho2.Text = lblTongChiTra2.Text = string.Format("{0:N3}VNĐ", TotalRecieptMonth);
                
                lblTongLoiNhuan2.Text = string.Format("{0:N3}VNĐ", TotalBillMonth - TotalRecieptMonth);
            }
        }
    }
}
