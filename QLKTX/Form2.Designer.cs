namespace QLKTX
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtTenDN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.lblTenDN = new System.Windows.Forms.Label();
            this.lblDNHT = new System.Windows.Forms.Label();
            this.btnDang_Nhap = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkHienMK = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(240, 162);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMatKhau.Multiline = true;
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(288, 29);
            this.txtMatKhau.TabIndex = 2;
            this.txtMatKhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtTenDN
            // 
            this.txtTenDN.Location = new System.Drawing.Point(240, 120);
            this.txtTenDN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenDN.Multiline = true;
            this.txtTenDN.Name = "txtTenDN";
            this.txtTenDN.Size = new System.Drawing.Size(288, 29);
            this.txtTenDN.TabIndex = 1;
            this.txtTenDN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(164, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 16);
            this.label5.TabIndex = 30;
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.BackColor = System.Drawing.Color.SteelBlue;
            this.lblMatKhau.ForeColor = System.Drawing.Color.White;
            this.lblMatKhau.Location = new System.Drawing.Point(130, 162);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(64, 16);
            this.lblMatKhau.TabIndex = 31;
            this.lblMatKhau.Text = "Mật khẩu:";
            // 
            // lblTenDN
            // 
            this.lblTenDN.AutoSize = true;
            this.lblTenDN.BackColor = System.Drawing.Color.SteelBlue;
            this.lblTenDN.ForeColor = System.Drawing.Color.White;
            this.lblTenDN.Location = new System.Drawing.Point(100, 120);
            this.lblTenDN.Name = "lblTenDN";
            this.lblTenDN.Size = new System.Drawing.Size(104, 16);
            this.lblTenDN.TabIndex = 32;
            this.lblTenDN.Text = "Tên đăng nhập: ";
            // 
            // lblDNHT
            // 
            this.lblDNHT.AutoSize = true;
            this.lblDNHT.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDNHT.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDNHT.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblDNHT.Location = new System.Drawing.Point(165, 21);
            this.lblDNHT.Name = "lblDNHT";
            this.lblDNHT.Size = new System.Drawing.Size(346, 32);
            this.lblDNHT.TabIndex = 29;
            this.lblDNHT.Text = "ĐĂNG NHẬP HỆ THỐNG ";
            this.lblDNHT.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnDang_Nhap
            // 
            this.btnDang_Nhap.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDang_Nhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDang_Nhap.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnDang_Nhap.Location = new System.Drawing.Point(267, 277);
            this.btnDang_Nhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDang_Nhap.Name = "btnDang_Nhap";
            this.btnDang_Nhap.Size = new System.Drawing.Size(120, 46);
            this.btnDang_Nhap.TabIndex = 4;
            this.btnDang_Nhap.Text = "Đăng nhập ";
            this.btnDang_Nhap.UseVisualStyleBackColor = false;
            this.btnDang_Nhap.Click += new System.EventHandler(this.btnDang_Nhap_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(219, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 27;
            // 
            // checkHienMK
            // 
            this.checkHienMK.AutoSize = true;
            this.checkHienMK.BackColor = System.Drawing.SystemColors.MenuBar;
            this.checkHienMK.ForeColor = System.Drawing.SystemColors.Desktop;
            this.checkHienMK.Location = new System.Drawing.Point(458, 250);
            this.checkHienMK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkHienMK.Name = "checkHienMK";
            this.checkHienMK.Size = new System.Drawing.Size(117, 20);
            this.checkHienMK.TabIndex = 3;
            this.checkHienMK.Text = "Hiện mật khẩu ";
            this.checkHienMK.UseVisualStyleBackColor = false;
            this.checkHienMK.CheckedChanged += new System.EventHandler(this.checkHienMK_CheckedChanged);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.SteelBlue;
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(75, 91);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(497, 134);
            this.textBox3.TabIndex = 23;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(253, 140);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(89, 22);
            this.textBox2.TabIndex = 24;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(649, 373);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightBlue;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(65, 82);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(520, 152);
            this.textBox1.TabIndex = 25;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 373);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtTenDN);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.lblTenDN);
            this.Controls.Add(this.lblDNHT);
            this.Controls.Add(this.btnDang_Nhap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkHienMK);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtTenDN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.Label lblTenDN;
        private System.Windows.Forms.Label lblDNHT;
        private System.Windows.Forms.Button btnDang_Nhap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkHienMK;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
    }
}