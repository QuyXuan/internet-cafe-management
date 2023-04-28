using BLL;
using DTO;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GUIClient.User_Controls
{
    public partial class UC_DongHo : UserControl
    {
        public delegate void CloseDongHo();
        public CloseDongHo closedongho;
        public delegate void CheckAccess(Time time);
        public CheckAccess checkaccess;

        private Time time;

        // Lấy handle của cửa sổ muốn hiển thị lại
        private IntPtr hWnd;

        public UC_DongHo(IntPtr hWnd)
        {
            InitializeComponent();
            if(frmClient.Role)
            {
                float changtime = TimerBLL.Instance.ChangeTime((float)frmClient.customer.TotalTime, frmClient.typeComputer.NameType);
                time = TimerBLL.Instance.TranferTime(changtime);
                this.hWnd = hWnd;
                if (CustomerBLL.Instance.SetTotalTime(time, frmClient.customer.CustomerId, frmClient.typeComputer.NameType) == 0)
                {
                    timer2.Enabled = false;
                }
            }
        }

        private void DongHo_Load(object sender, EventArgs e)
        {
            if(frmClient.Role)
            {
                lblHr.Text = time.hour.ToString();
                lblMin.Text = time.minute.ToString();
                lblSec.Text = time.second.ToString();
                timer1.Enabled = true;
                timer2.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time time = new Time(Convert.ToInt32(lblHr.Text), Convert.ToInt32(lblMin.Text), Convert.ToInt32(lblSec.Text));
            checkaccess(time);
            SetColor(TimerBLL.Instance.TranferTotalTime(time));
            if ((time.hour == 0) && (time.minute == 0) && (time.second == 0))
            {
                timer1.Enabled = false;
                Console.Beep();
                if(frmClient.DongHo != null)
                {
                    //MessageBox.Show("Vô rồi");
                    closedongho();
                }
            }
            else
            {
                time = TimerBLL.Instance.timertick(time.hour, time.minute, time.second);
                lblHr.Text = time.hour.ToString();
                lblMin.Text = time.minute.ToString();
                lblSec.Text = time.second.ToString();
            }
        }

        public Time getCurrentTime()
        {
            Time time = new Time(Convert.ToInt32(lblHr.Text), Convert.ToInt32(lblMin.Text), Convert.ToInt32(lblSec.Text));
            return time;
        }

        public void UpdateTime(float TotalTime)
        {
            float currentTime = TimerBLL.Instance.TranferTotalTime(getCurrentTime());
            Time time = TimerBLL.Instance.SumTime(currentTime, TotalTime);
            lblHr.Text = time.hour.ToString();
            lblMin.Text = time.minute.ToString();
            lblSec.Text = time.second.ToString();
            timer1.Enabled = true;
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Time time = new Time(Convert.ToInt32(lblHr.Text), Convert.ToInt32(lblMin.Text), Convert.ToInt32(lblSec.Text));
            if(CustomerBLL.Instance.SetTotalTime(time,frmClient.customer.CustomerId,frmClient.typeComputer.NameType) == 0)
            {
                timer2.Enabled = false;
            }
        }

        public void SetDiChuyen(bool diChuyen)
        {
            if(diChuyen)
            {
                guna2DragControl1.TargetControl = groupBoxTimer;
                guna2DragControl2.TargetControl = lblHr;
                guna2DragControl3.TargetControl = label8;
                guna2DragControl4.TargetControl = lblMin;
                guna2DragControl5.TargetControl = label10;
                guna2DragControl6.TargetControl = lblSec;
            }
            else
            {
                guna2DragControl1.TargetControl = null;
                guna2DragControl2.TargetControl = null;
                guna2DragControl3.TargetControl = null;
                guna2DragControl4.TargetControl = null;
                guna2DragControl5.TargetControl = null;
                guna2DragControl6.TargetControl = null;
            }
        }

        public void SetColor(float totaltime)
        {
            if(totaltime >= 5) 
            {
                lblHr.ForeColor = Color.FromArgb(0, 192, 0);
                lblMin.ForeColor = Color.FromArgb(0, 192, 0);
                lblSec.ForeColor = Color.FromArgb(0, 192, 0);
                label8.ForeColor = Color.Lime;
                label10.ForeColor = Color.Lime;
            }
            else if(totaltime < 5 && totaltime >= 1)
            {
                lblHr.ForeColor = Color.FromArgb(255, 128, 0);
                lblMin.ForeColor = Color.FromArgb(255, 128, 0);
                lblSec.ForeColor = Color.FromArgb(255, 128, 0);
                label8.ForeColor = Color.FromArgb(255, 192, 128);
                label10.ForeColor = Color.FromArgb(255, 192, 128);
            } else if(totaltime < 1)
            {
                lblHr.ForeColor = Color.Red;
                lblMin.ForeColor = Color.Red;
                lblSec.ForeColor = Color.Red;
                label8.ForeColor = Color.FromArgb(255, 128, 128);
                label10.ForeColor = Color.FromArgb(255, 128, 128);
            }
        }
    }
}
