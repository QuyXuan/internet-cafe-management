using DTO;
using GUIClient.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIClient
{
    public partial class frmDongHo : Form
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int SW_RESTORE = 9;
        IntPtr hWnd;
        public frmDongHo(IntPtr hWnd)
        {
            InitializeComponent();
            frmClient.myUC_DongHo.closedongho += new UC_DongHo.CloseDongHo(CloseDongHo);
            frmClient.myUC_DongHo.SetDiChuyen(true);
            panelDongHo.Controls.Add(frmClient.myUC_DongHo);
            this.hWnd = hWnd;
        }

        private void btnMinisize_Click(object sender, EventArgs e)
        {
            frmClient.myUC_DongHo.SetDiChuyen(false);
            CloseDongHo();
        }

        //Hàm chống tắt chương trình
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {

                case Keys.Control:
                    {
                        return true;
                    }

                case Keys.Alt | Keys.F4:
                    {
                        return true;
                    }

                case Keys.Alt | Keys.Control | Keys.Delete:
                    {
                        return true;
                    }

                case Keys.Control | Keys.Q:
                    {
                        return true;
                    }
            }
            return base.ProcessDialogKey(keyData);
        }

        public void CloseDongHo()
        {
            Form frmclient = Application.OpenForms.OfType<frmClient>().FirstOrDefault();
            if (frmclient != null)
            {
                Panel panel = frmclient.Controls.Find("panelDongHo", true).FirstOrDefault() as Panel;
                if (panel != null)
                {
                    panel.Controls.Add(frmClient.myUC_DongHo);
                }
            }
            ShowWindow(hWnd, SW_RESTORE);
            Dispose();
        }
    }
}
