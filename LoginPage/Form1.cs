using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginPage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (txtMatKhau.Text.Length > 0)
            {
                txtMatKhau.PasswordChar = '*';
            }
            else
            {
                //txtMatKhau.PasswordChar = '';
            }
        }

        private void cboTuCach_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboTuCach.ForeColor = SystemColors.ControlText;
        }
    }
}
