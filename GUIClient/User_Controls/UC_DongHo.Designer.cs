namespace GUIClient.User_Controls
{
    partial class UC_DongHo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBoxTimer = new System.Windows.Forms.GroupBox();
            this.lblSec = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblHr = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl2 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl3 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl4 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl5 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl6 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.groupBoxTimer.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTimer
            // 
            this.groupBoxTimer.Controls.Add(this.lblSec);
            this.groupBoxTimer.Controls.Add(this.label10);
            this.groupBoxTimer.Controls.Add(this.lblMin);
            this.groupBoxTimer.Controls.Add(this.label8);
            this.groupBoxTimer.Controls.Add(this.lblHr);
            this.groupBoxTimer.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTimer.Name = "groupBoxTimer";
            this.groupBoxTimer.Size = new System.Drawing.Size(279, 73);
            this.groupBoxTimer.TabIndex = 8;
            this.groupBoxTimer.TabStop = false;
            // 
            // lblSec
            // 
            this.lblSec.AutoSize = true;
            this.lblSec.Font = new System.Drawing.Font("Agency FB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSec.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblSec.Location = new System.Drawing.Point(218, 24);
            this.lblSec.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSec.Name = "lblSec";
            this.lblSec.Size = new System.Drawing.Size(51, 44);
            this.lblSec.TabIndex = 16;
            this.lblSec.Text = "00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Lime;
            this.label10.Location = new System.Drawing.Point(184, 22);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 42);
            this.label10.TabIndex = 15;
            this.label10.Text = ":";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Font = new System.Drawing.Font("Agency FB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblMin.Location = new System.Drawing.Point(114, 24);
            this.lblMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(51, 44);
            this.lblMin.TabIndex = 14;
            this.lblMin.Text = "00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Lime;
            this.label8.Location = new System.Drawing.Point(77, 22);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 42);
            this.label8.TabIndex = 13;
            this.label8.Text = ":";
            // 
            // lblHr
            // 
            this.lblHr.AutoSize = true;
            this.lblHr.Font = new System.Drawing.Font("Agency FB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblHr.Location = new System.Drawing.Point(7, 24);
            this.lblHr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHr.Name = "lblHr";
            this.lblHr.Size = new System.Drawing.Size(51, 44);
            this.lblHr.TabIndex = 12;
            this.lblHr.Text = "00";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 60000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // guna2DragControl2
            // 
            this.guna2DragControl2.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl2.UseTransparentDrag = true;
            // 
            // guna2DragControl3
            // 
            this.guna2DragControl3.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl3.UseTransparentDrag = true;
            // 
            // guna2DragControl4
            // 
            this.guna2DragControl4.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl4.UseTransparentDrag = true;
            // 
            // guna2DragControl5
            // 
            this.guna2DragControl5.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl5.UseTransparentDrag = true;
            // 
            // guna2DragControl6
            // 
            this.guna2DragControl6.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl6.UseTransparentDrag = true;
            // 
            // UC_DongHo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxTimer);
            this.Name = "UC_DongHo";
            this.Size = new System.Drawing.Size(279, 73);
            this.Load += new System.EventHandler(this.DongHo_Load);
            this.groupBoxTimer.ResumeLayout(false);
            this.groupBoxTimer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTimer;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblHr;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl2;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl3;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl4;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl5;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl6;
    }
}
