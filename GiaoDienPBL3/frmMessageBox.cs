using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaoDienPBL3
{
    public partial class frmMessageBox : Form
    {
        private static frmMessageBox instance;
        public static frmMessageBox Instance
        {
            get
            {
                if (instance == null)
                    instance = new frmMessageBox();
                return instance;
            }
            private set { }
        }
        private frmMessageBox()
        {
            InitializeComponent();
        }
        public void ShowFrmMessageBox(StatusResult status, string contentAlertBox)
        {
            this.panelLine.Width = 1;
            Color backColorAlertBox = Color.White;
            Color colorLineAlertBox = Color.White;
            Image imageAlertBox = Properties.Resources.information;
            string titleAlertBox = "";
            if (status == StatusResult.Warning)
            {
                backColorAlertBox = Color.LightGoldenrodYellow;
                colorLineAlertBox = Color.Goldenrod;
                imageAlertBox = Properties.Resources.warning;
                titleAlertBox = "Cảnh Báo";
            }
            else if (status == StatusResult.Information)
            {
                backColorAlertBox = Color.LightSteelBlue;
                colorLineAlertBox = Color.DodgerBlue;
                imageAlertBox = Properties.Resources.information;
                titleAlertBox = "Thông Tin";
            }
            else if (status == StatusResult.Error)
            {
                backColorAlertBox = Color.LightPink;
                colorLineAlertBox = Color.DarkRed;
                imageAlertBox = Properties.Resources.error;
                titleAlertBox = "Lỗi";
            }
            else if (status == StatusResult.Success)
            {
                backColorAlertBox = Color.LightGreen;
                colorLineAlertBox = Color.SeaGreen;
                imageAlertBox = Properties.Resources.success;
                titleAlertBox = "Thành Công";
            }
            this.BackColor = backColorAlertBox;
            this.panelLine.BackColor = this.lblContentAlertBox.ForeColor = this.lblTitleAlertBox.ForeColor = colorLineAlertBox;
            this.picAlertBox.Image = imageAlertBox;
            this.lblTitleAlertBox.Text = titleAlertBox;
            this.lblContentAlertBox.Text = contentAlertBox;
            this.ShowDialog();
        }
        public enum StatusResult
        {
            Success,
            Error,
            Warning,
            Information
        }
        public Color BackColorAlertBox
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }
        public Color ColorLineAlertBox
        {
            get { return this.panelLine.BackColor; }
            set { this.panelLine.BackColor = this.lblContentAlertBox.ForeColor = this.lblTitleAlertBox.ForeColor = value; }
        }
        public Image ImageAlertBox
        {
            get { return this.picAlertBox.Image; }
            set { this.picAlertBox.Image = value; }
        }
        public string TitleAlertBox
        {
            get { return this.lblTitleAlertBox.Text; }
            set { this.lblTitleAlertBox.Text = value; }
        }
        public string ContentAlertBox
        {
            get { return this.lblContentAlertBox.Text; }
            set { this.lblContentAlertBox.Text = value; }
        }
        
        private void PositionAlertBox()
        {
            int xPos = 0; int yPos = 0;
            xPos = Screen.GetWorkingArea(this).Width;
            yPos = Screen.GetWorkingArea(this).Height;
            this.Location = new Point(xPos - this.Width, yPos - this.Height);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.panelLine.Width = this.panelLine.Width + 2;
            if (this.panelLine.Width >= 500)
            {
                this.Hide();
            }
        }
        private void frmMessageBox_Load(object sender, EventArgs e)
        {
            PositionAlertBox();
            for (int i = 0; i < 500; i++)
            {
                timer1.Start();
            }
        }
    }
}
