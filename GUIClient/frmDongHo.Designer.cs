namespace GUIClient
{
    partial class frmDongHo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDongHo));
            this.btnMinisize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.panelDongHo = new System.Windows.Forms.Panel();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.SuspendLayout();
            // 
            // btnMinisize
            // 
            resources.ApplyResources(this.btnMinisize, "btnMinisize");
            this.btnMinisize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnMinisize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.btnMinisize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinisize.FillColor = System.Drawing.Color.Silver;
            this.btnMinisize.IconColor = System.Drawing.Color.White;
            this.btnMinisize.Name = "btnMinisize";
            this.btnMinisize.Click += new System.EventHandler(this.btnMinisize_Click);
            // 
            // panelDongHo
            // 
            this.panelDongHo.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.panelDongHo, "panelDongHo");
            this.panelDongHo.Name = "panelDongHo";
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // frmDongHo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.btnMinisize);
            this.Controls.Add(this.panelDongHo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmDongHo";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ControlBox btnMinisize;
        private System.Windows.Forms.Panel panelDongHo;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}