using BLL;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIClient.User_Controls
{
    public partial class UC_NapGioChoi : UserControl
    {
        private Computer computer;
        private TypeComputer typeComputer;
        public delegate void SendBalance(double Balance);
        public SendBalance sendBalance;
        public UC_NapGioChoi()
        {
            InitializeComponent();
            this.computer = frmClient.computer;
            this.typeComputer = frmClient.typeComputer;
            SetForm();
            if(frmClient.Role == false) btnXacNhan.Enabled = false;
        }
        
        public void SetForm()
        {
            lblSoMay.Text = computer.ComputerName;
            lblLoaiMay.Text = typeComputer.NameType;
            lblGiaMay.Text = typeComputer.Price.ToString();
            SetGiaMay();
        }

        public void SetGiaMay()
        {
            dgvGiaMay.DataSource = TypeComputerBLL.Instance.GetListTypeComputer();
            dgvGiaMay.DefaultCellStyle.SelectionBackColor = dgvGiaMay.DefaultCellStyle.BackColor;
            dgvGiaMay.DefaultCellStyle.SelectionForeColor = dgvGiaMay.DefaultCellStyle.ForeColor;
            dgvGiaMay.Columns[0].Visible = false;
            dgvGiaMay.Columns[1].HeaderText = "Loại Máy";
            dgvGiaMay.Columns[2].HeaderText = "Giá Máy";
            dgvGiaMay.Columns[3].Visible = false;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Guna2Button btn = (Guna2Button)sender;
            lblSoTienMuonNap.Text = btn.Text;
            double money = Convert.ToDouble(btn.Text.Split('V')[0]);
            lblQuyDoiThanhGioChoi.Text = TimerBLL.Instance.ChangeMoneyToTime(money,typeComputer.NameType).ToString();
            lblTongTien.Text = btn.Text;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(frmClient.customer.Balance) >= Convert.ToDouble(lblSoTienMuonNap.Text.Split('V')[0])/1000)
            {
                frmClient.myUC_DongHo.UpdateTime(float.Parse(lblQuyDoiThanhGioChoi.Text));
                double CurrentBalance = Convert.ToDouble(frmClient.customer.Balance) - Convert.ToDouble(lblSoTienMuonNap.Text.Split('V')[0])/1000;
                CustomerBLL.Instance.SetBalance(CurrentBalance, frmClient.customer.CustomerId);
                sendBalance(CurrentBalance);
            }
            else ShowThongBao("Số Dư Không Đủ");
        }
        //Hàm hiển thị thông báo hết tiền
        public async void ShowThongBao(string thongbao)
        {
            lblThongBao.Visible = true;
            lblThongBao.Text = thongbao;
            while (lblThongBao.Visible)
            {
                await Task.Delay(3000);
                lblThongBao.Visible = false;
            }
        }
    }
}
