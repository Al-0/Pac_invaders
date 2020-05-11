namespace UII_Ex
{
    partial class Game
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
            this.T_G = new System.Windows.Forms.Timer(this.components);
            this.PB_go_win = new System.Windows.Forms.PictureBox();
            this.PB_fl = new System.Windows.Forms.PictureBox();
            this.PBP = new System.Windows.Forms.PictureBox();
            this.T_D = new System.Windows.Forms.Timer(this.components);
            this.PB_press = new System.Windows.Forms.PictureBox();
            this.PB_win = new System.Windows.Forms.PictureBox();
            this.T_W = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PB_go_win)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_fl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_press)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_win)).BeginInit();
            this.SuspendLayout();
            // 
            // T_G
            // 
            this.T_G.Interval = 10;
            this.T_G.Tick += new System.EventHandler(this.T_G_Tick);
            // 
            // PB_go_win
            // 
            this.PB_go_win.BackColor = System.Drawing.Color.Transparent;
            this.PB_go_win.Image = global::UII_Ex.Properties.Resources.Win;
            this.PB_go_win.Location = new System.Drawing.Point(52, 52);
            this.PB_go_win.Name = "PB_go_win";
            this.PB_go_win.Size = new System.Drawing.Size(374, 153);
            this.PB_go_win.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_go_win.TabIndex = 8;
            this.PB_go_win.TabStop = false;
            this.PB_go_win.Visible = false;
            // 
            // PB_fl
            // 
            this.PB_fl.BackColor = System.Drawing.Color.Transparent;
            this.PB_fl.Image = global::UII_Ex.Properties.Resources.floor;
            this.PB_fl.Location = new System.Drawing.Point(12, 306);
            this.PB_fl.Name = "PB_fl";
            this.PB_fl.Size = new System.Drawing.Size(460, 42);
            this.PB_fl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_fl.TabIndex = 9;
            this.PB_fl.TabStop = false;
            // 
            // PBP
            // 
            this.PBP.BackColor = System.Drawing.SystemColors.Control;
            this.PBP.Image = global::UII_Ex.Properties.Resources.PO_u;
            this.PBP.Location = new System.Drawing.Point(222, 317);
            this.PBP.Name = "PBP";
            this.PBP.Size = new System.Drawing.Size(30, 30);
            this.PBP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PBP.TabIndex = 10;
            this.PBP.TabStop = false;
            // 
            // T_D
            // 
            this.T_D.Tick += new System.EventHandler(this.T_D_Tick);
            // 
            // PB_press
            // 
            this.PB_press.BackColor = System.Drawing.Color.Transparent;
            this.PB_press.Image = global::UII_Ex.Properties.Resources.Press_start_go;
            this.PB_press.Location = new System.Drawing.Point(64, 225);
            this.PB_press.Name = "PB_press";
            this.PB_press.Size = new System.Drawing.Size(351, 50);
            this.PB_press.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_press.TabIndex = 11;
            this.PB_press.TabStop = false;
            this.PB_press.Visible = false;
            // 
            // PB_win
            // 
            this.PB_win.BackColor = System.Drawing.Color.Transparent;
            this.PB_win.Image = global::UII_Ex.Properties.Resources.Ms_pac;
            this.PB_win.Location = new System.Drawing.Point(170, 281);
            this.PB_win.Name = "PB_win";
            this.PB_win.Size = new System.Drawing.Size(100, 50);
            this.PB_win.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_win.TabIndex = 12;
            this.PB_win.TabStop = false;
            this.PB_win.Visible = false;
            // 
            // T_W
            // 
            this.T_W.Interval = 1000;
            this.T_W.Tick += new System.EventHandler(this.T_W_Tick);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UII_Ex.Properties.Resources.Cage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.PB_win);
            this.Controls.Add(this.PB_press);
            this.Controls.Add(this.PBP);
            this.Controls.Add(this.PB_fl);
            this.Controls.Add(this.PB_go_win);
            this.DoubleBuffered = true;
            this.Name = "Game";
            this.Text = "Game";
            this.Shown += new System.EventHandler(this.Game_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.PB_go_win)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_fl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_press)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_win)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer T_G;
        private System.Windows.Forms.PictureBox PB_go_win;
        private System.Windows.Forms.PictureBox PB_fl;
        private System.Windows.Forms.PictureBox PBP;
        private System.Windows.Forms.Timer T_D;
        private System.Windows.Forms.PictureBox PB_press;
        private System.Windows.Forms.PictureBox PB_win;
        private System.Windows.Forms.Timer T_W;
    }
}