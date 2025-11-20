namespace QLKTX
{
    partial class Form3
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboLoc = new System.Windows.Forms.ComboBox();
            this.txtNhapMSSV_TenSV = new System.Windows.Forms.TextBox();
            this.lblNhap_TenSV = new System.Windows.Forms.Label();
            this.lblLoc_Phong = new System.Windows.Forms.Label();
            this.btbHienALL = new System.Windows.Forms.Button();
            this.btnT_kiem = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.SteelBlue;
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(22, 117);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(1224, 550);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách sinh viên ";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.SteelBlue;
            this.groupBox2.Controls.Add(this.cboLoc);
            this.groupBox2.Controls.Add(this.txtNhapMSSV_TenSV);
            this.groupBox2.Controls.Add(this.lblNhap_TenSV);
            this.groupBox2.Controls.Add(this.lblLoc_Phong);
            this.groupBox2.Controls.Add(this.btbHienALL);
            this.groupBox2.Controls.Add(this.btnT_kiem);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(22, 22);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(1224, 278);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm sinh viên ";
            // 
            // cboLoc
            // 
            this.cboLoc.FormattingEnabled = true;
            this.cboLoc.Location = new System.Drawing.Point(684, 41);
            this.cboLoc.Margin = new System.Windows.Forms.Padding(2);
            this.cboLoc.Name = "cboLoc";
            this.cboLoc.Size = new System.Drawing.Size(213, 28);
            this.cboLoc.TabIndex = 4;
            // 
            // txtNhapMSSV_TenSV
            // 
            this.txtNhapMSSV_TenSV.Location = new System.Drawing.Point(214, 41);
            this.txtNhapMSSV_TenSV.Margin = new System.Windows.Forms.Padding(2);
            this.txtNhapMSSV_TenSV.Multiline = true;
            this.txtNhapMSSV_TenSV.Name = "txtNhapMSSV_TenSV";
            this.txtNhapMSSV_TenSV.Size = new System.Drawing.Size(272, 29);
            this.txtNhapMSSV_TenSV.TabIndex = 3;
            // 
            // lblNhap_TenSV
            // 
            this.lblNhap_TenSV.AutoSize = true;
            this.lblNhap_TenSV.Location = new System.Drawing.Point(5, 46);
            this.lblNhap_TenSV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNhap_TenSV.Name = "lblNhap_TenSV";
            this.lblNhap_TenSV.Size = new System.Drawing.Size(170, 20);
            this.lblNhap_TenSV.TabIndex = 0;
            this.lblNhap_TenSV.Text = "Nhập MSSV và tên SV";
            // 
            // lblLoc_Phong
            // 
            this.lblLoc_Phong.AutoSize = true;
            this.lblLoc_Phong.BackColor = System.Drawing.Color.SteelBlue;
            this.lblLoc_Phong.Location = new System.Drawing.Point(526, 46);
            this.lblLoc_Phong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLoc_Phong.Name = "lblLoc_Phong";
            this.lblLoc_Phong.Size = new System.Drawing.Size(124, 20);
            this.lblLoc_Phong.TabIndex = 0;
            this.lblLoc_Phong.Text = "Lọc theo phòng ";
            // 
            // btbHienALL
            // 
            this.btbHienALL.BackColor = System.Drawing.Color.DarkGray;
            this.btbHienALL.ForeColor = System.Drawing.Color.Black;
            this.btbHienALL.Location = new System.Drawing.Point(1065, 38);
            this.btbHienALL.Margin = new System.Windows.Forms.Padding(2);
            this.btbHienALL.Name = "btbHienALL";
            this.btbHienALL.Size = new System.Drawing.Size(136, 53);
            this.btbHienALL.TabIndex = 2;
            this.btbHienALL.Text = "Hiện tất cả ";
            this.btbHienALL.UseVisualStyleBackColor = false;
            // 
            // btnT_kiem
            // 
            this.btnT_kiem.BackColor = System.Drawing.Color.DarkGray;
            this.btnT_kiem.ForeColor = System.Drawing.Color.Black;
            this.btnT_kiem.Location = new System.Drawing.Point(931, 38);
            this.btnT_kiem.Margin = new System.Windows.Forms.Padding(2);
            this.btnT_kiem.Name = "btnT_kiem";
            this.btnT_kiem.Size = new System.Drawing.Size(130, 53);
            this.btnT_kiem.TabIndex = 2;
            this.btnT_kiem.Text = "Tìm kiếm ";
            this.btnT_kiem.UseVisualStyleBackColor = false;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.LightSteelBlue;
            this.textBox7.Location = new System.Drawing.Point(11, 11);
            this.textBox7.Margin = new System.Windows.Forms.Padding(2);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(1245, 668);
            this.textBox7.TabIndex = 10;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1192, 325);
            this.dataGridView1.TabIndex = 0;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 690);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBox7);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboLoc;
        private System.Windows.Forms.TextBox txtNhapMSSV_TenSV;
        private System.Windows.Forms.Label lblNhap_TenSV;
        private System.Windows.Forms.Label lblLoc_Phong;
        private System.Windows.Forms.Button btbHienALL;
        private System.Windows.Forms.Button btnT_kiem;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}