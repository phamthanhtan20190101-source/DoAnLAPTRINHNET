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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(212, 179);
            this.txtMatKhau.Multiline = true;
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(323, 35);
            this.txtMatKhau.TabIndex = 35;
            // 
            // txtTenDN
            // 
            this.txtTenDN.Location = new System.Drawing.Point(212, 122);
            this.txtTenDN.Multiline = true;
            this.txtTenDN.Name = "txtTenDN";
            this.txtTenDN.Size = new System.Drawing.Size(323, 35);
            this.txtTenDN.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(158, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 20);
            this.label5.TabIndex = 30;
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.BackColor = System.Drawing.Color.SteelBlue;
            this.lblMatKhau.ForeColor = System.Drawing.Color.White;
            this.lblMatKhau.Location = new System.Drawing.Point(85, 182);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(79, 20);
            this.lblMatKhau.TabIndex = 31;
            this.lblMatKhau.Text = "Mật khẩu:";
            // 
            // lblTenDN
            // 
            this.lblTenDN.AutoSize = true;
            this.lblTenDN.BackColor = System.Drawing.Color.SteelBlue;
            this.lblTenDN.ForeColor = System.Drawing.Color.White;
            this.lblTenDN.Location = new System.Drawing.Point(70, 125);
            this.lblTenDN.Name = "lblTenDN";
            this.lblTenDN.Size = new System.Drawing.Size(124, 20);
            this.lblTenDN.TabIndex = 32;
            this.lblTenDN.Text = "Tên đăng nhập: ";
            // 
            // lblDNHT
            // 
            this.lblDNHT.AutoSize = true;
            this.lblDNHT.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDNHT.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblDNHT.Location = new System.Drawing.Point(222, 12);
            this.lblDNHT.Name = "lblDNHT";
            this.lblDNHT.Size = new System.Drawing.Size(244, 23);
            this.lblDNHT.TabIndex = 29;
            this.lblDNHT.Text = "ĐĂNG NHẬP HỆ THỐNG ";
            // 
            // btnDang_Nhap
            // 
            this.btnDang_Nhap.BackColor = System.Drawing.Color.DarkGray;
            this.btnDang_Nhap.Location = new System.Drawing.Point(262, 319);
            this.btnDang_Nhap.Name = "btnDang_Nhap";
            this.btnDang_Nhap.Size = new System.Drawing.Size(135, 57);
            this.btnDang_Nhap.TabIndex = 28;
            this.btnDang_Nhap.Text = "Đăng nhập ";
            this.btnDang_Nhap.UseVisualStyleBackColor = false;
            this.btnDang_Nhap.Click += new System.EventHandler(this.btnDang_Nhap_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 27;
            // 
            // checkHienMK
            // 
            this.checkHienMK.AutoSize = true;
            this.checkHienMK.Location = new System.Drawing.Point(477, 284);
            this.checkHienMK.Name = "checkHienMK";
            this.checkHienMK.Size = new System.Drawing.Size(142, 24);
            this.checkHienMK.TabIndex = 26;
            this.checkHienMK.Text = "Hiện mật khẩu ";
            this.checkHienMK.UseVisualStyleBackColor = true;
            this.checkHienMK.CheckedChanged += new System.EventHandler(this.checkHienMK_CheckedChanged);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.SteelBlue;
            this.textBox3.Location = new System.Drawing.Point(46, 86);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(559, 166);
            this.textBox3.TabIndex = 23;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(245, 148);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 26);
            this.textBox2.TabIndex = 24;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.textBox1.Location = new System.Drawing.Point(35, 75);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(584, 189);
            this.textBox1.TabIndex = 25;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 387);
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
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
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
        private System.Windows.Forms.TextBox textBox1;
    }
}