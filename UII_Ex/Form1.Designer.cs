namespace UII_Ex
{
    partial class Form1
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
            this.PB_r = new System.Windows.Forms.PictureBox();
            this.T_start = new System.Windows.Forms.Timer(this.components);
            this.PB_l = new System.Windows.Forms.PictureBox();
            this.PB_sel = new System.Windows.Forms.PictureBox();
            this.PB_dif = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PB_r)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_l)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_sel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_dif)).BeginInit();
            this.SuspendLayout();
            // 
            // PB_r
            // 
            this.PB_r.Image = global::UII_Ex.Properties.Resources.A_r;
            this.PB_r.Location = new System.Drawing.Point(250, 170);
            this.PB_r.Name = "PB_r";
            this.PB_r.Size = new System.Drawing.Size(29, 30);
            this.PB_r.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_r.TabIndex = 0;
            this.PB_r.TabStop = false;
            this.PB_r.Visible = false;
            // 
            // T_start
            // 
            this.T_start.Enabled = true;
            this.T_start.Interval = 180;
            this.T_start.Tick += new System.EventHandler(this.T_start_Tick);
            // 
            // PB_l
            // 
            this.PB_l.Image = global::UII_Ex.Properties.Resources.A_l;
            this.PB_l.Location = new System.Drawing.Point(60, 170);
            this.PB_l.Name = "PB_l";
            this.PB_l.Size = new System.Drawing.Size(30, 30);
            this.PB_l.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_l.TabIndex = 1;
            this.PB_l.TabStop = false;
            this.PB_l.Visible = false;
            // 
            // PB_sel
            // 
            this.PB_sel.BackColor = System.Drawing.Color.Transparent;
            this.PB_sel.Image = global::UII_Ex.Properties.Resources.Select1;
            this.PB_sel.Location = new System.Drawing.Point(23, 53);
            this.PB_sel.Name = "PB_sel";
            this.PB_sel.Size = new System.Drawing.Size(300, 25);
            this.PB_sel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_sel.TabIndex = 2;
            this.PB_sel.TabStop = false;
            this.PB_sel.Visible = false;
            // 
            // PB_dif
            // 
            this.PB_dif.BackColor = System.Drawing.Color.Transparent;
            this.PB_dif.Image = global::UII_Ex.Properties.Resources.Easy;
            this.PB_dif.Location = new System.Drawing.Point(103, 170);
            this.PB_dif.Name = "PB_dif";
            this.PB_dif.Size = new System.Drawing.Size(119, 30);
            this.PB_dif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_dif.TabIndex = 3;
            this.PB_dif.TabStop = false;
            this.PB_dif.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UII_Ex.Properties.Resources.Start_screen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(344, 361);
            this.Controls.Add(this.PB_dif);
            this.Controls.Add(this.PB_sel);
            this.Controls.Add(this.PB_l);
            this.Controls.Add(this.PB_r);
            this.Name = "Form1";
            this.Text = "Space Invaders";
            ((System.ComponentModel.ISupportInitialize)(this.PB_r)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_l)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_sel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_dif)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_r;
        private System.Windows.Forms.Timer T_start;
        private System.Windows.Forms.PictureBox PB_l;
        private System.Windows.Forms.PictureBox PB_sel;
        public System.Windows.Forms.PictureBox PB_dif;
    }
}

