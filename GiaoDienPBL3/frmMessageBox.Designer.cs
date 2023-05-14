namespace GiaoDienPBL3
{
    partial class frmMessageBox
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
            this.lblTitleAlertBox = new System.Windows.Forms.Label();
            this.lblContentAlertBox = new System.Windows.Forms.Label();
            this.panelLine = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.picAlertBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picAlertBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitleAlertBox
            // 
            this.lblTitleAlertBox.AutoSize = true;
            this.lblTitleAlertBox.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleAlertBox.Location = new System.Drawing.Point(79, 25);
            this.lblTitleAlertBox.Name = "lblTitleAlertBox";
            this.lblTitleAlertBox.Size = new System.Drawing.Size(72, 25);
            this.lblTitleAlertBox.TabIndex = 1;
            this.lblTitleAlertBox.Text = "TieuDe";
            // 
            // lblContentAlertBox
            // 
            this.lblContentAlertBox.AutoSize = true;
            this.lblContentAlertBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContentAlertBox.Location = new System.Drawing.Point(79, 50);
            this.lblContentAlertBox.Name = "lblContentAlertBox";
            this.lblContentAlertBox.Size = new System.Drawing.Size(74, 20);
            this.lblContentAlertBox.TabIndex = 1;
            this.lblContentAlertBox.Text = "ThongTin";
            // 
            // panelLine
            // 
            this.panelLine.BackColor = System.Drawing.Color.Black;
            this.panelLine.Location = new System.Drawing.Point(0, 90);
            this.panelLine.Name = "panelLine";
            this.panelLine.Size = new System.Drawing.Size(1, 10);
            this.panelLine.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this;
            // 
            // picAlertBox
            // 
            this.picAlertBox.Location = new System.Drawing.Point(12, 25);
            this.picAlertBox.Name = "picAlertBox";
            this.picAlertBox.Size = new System.Drawing.Size(48, 48);
            this.picAlertBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picAlertBox.TabIndex = 0;
            this.picAlertBox.TabStop = false;
            // 
            // frmMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 100);
            this.Controls.Add(this.panelLine);
            this.Controls.Add(this.lblContentAlertBox);
            this.Controls.Add(this.lblTitleAlertBox);
            this.Controls.Add(this.picAlertBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMessageBox";
            this.Text = "frmMessageBox";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmMessageBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAlertBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        public System.Windows.Forms.PictureBox picAlertBox;
        public System.Windows.Forms.Label lblTitleAlertBox;
        public System.Windows.Forms.Label lblContentAlertBox;
        public System.Windows.Forms.Panel panelLine;
    }
}