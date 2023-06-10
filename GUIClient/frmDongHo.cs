using DTO;
using GiaoDienPBL3;
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
        public frmDongHo()
        {
            InitializeComponent();
            frmClient.myUC_DongHo.closedongho += new UC_DongHo.CloseDongHo(CloseDongHo);
            frmClient.myUC_DongHo.SetDiChuyen(true);
            panelDongHo.Controls.Add(frmClient.myUC_DongHo);
        }

        private void btnMinisize_Click(object sender, EventArgs e)
        {
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
                    frmClient.myUC_DongHo.SetDiChuyen(false);
                    panel.Controls.Add(frmClient.myUC_DongHo);
                }
                Panel panelBackground = frmclient.Controls.Find("panelBackGround", true).FirstOrDefault() as Panel;
                if (panelBackground != null)
                {
                    if(panelBackground.Controls.OfType<UserControl>().Any() == false)
                    {
                        frmMain.myUC_MenuClient = new GiaoDienPBL3.User_Controls.UC_MenuClient(frmClient.Role,frmClient.accountId, frmClient.computerId);
                        panelBackground.Controls.Add(frmMain.myUC_MenuClient);
                    }
                }
            }
            frmclient.WindowState = FormWindowState.Maximized;
            frmclient.Show();
            frmclient.BringToFront();
            frmClient.DongHo = null;
            Dispose();
        }
    }
}
