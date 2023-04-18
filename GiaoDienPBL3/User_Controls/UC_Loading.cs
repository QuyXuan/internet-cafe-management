using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaoDienPBL3.User_Controls
{
    public partial class UC_Loading : UserControl
    {
        public UC_Loading()
        {
            InitializeComponent();
        }

        private void timerLoad_Tick(object sender, EventArgs e)
        {
            if (circlerProgressBarLoad.Value < 100)
            {
                circlerProgressBarLoad.Value++;

            }
            else
            {
                this.Visible = false;
            }
        }
    }
}
