namespace QLKTX
{
    partial class Form4
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridDSSV = new System.Windows.Forms.DataGridView();
            this.btnluu = new System.Windows.Forms.Button();
            this.btnxuat = new System.Windows.Forms.Button();
            this.dateTimeNgayDong = new System.Windows.Forms.DateTimePicker();
            this.cobThangdong = new System.Windows.Forms.ComboBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radiNhanTien = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtmssv = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtphong = new System.Windows.Forms.TextBox();
            this.txtsotien = new System.Windows.Forms.TextBox();
            this.txttensv = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnluuvaosql = new System.Windows.Forms.Button();
            this.btnhuy = new System.Windows.Forms.Button();
            this.btnlsdt = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.combtimphong = new System.Windows.Forms.ComboBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDSSV)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(429, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thanh Toán Tiền Phòng";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridDSSV);
            this.groupBox1.Location = new System.Drawing.Point(37, 358);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(1091, 258);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sinh viên";
            // 
            // dataGridDSSV
            // 
            this.dataGridDSSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDSSV.Location = new System.Drawing.Point(10, 25);
            this.dataGridDSSV.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dataGridDSSV.Name = "dataGridDSSV";
            this.dataGridDSSV.ReadOnly = true;
            this.dataGridDSSV.RowHeadersWidth = 62;
            this.dataGridDSSV.RowTemplate.Height = 28;
            this.dataGridDSSV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridDSSV.Size = new System.Drawing.Size(1071, 222);
            this.dataGridDSSV.TabIndex = 0;
            this.dataGridDSSV.SelectionChanged += new System.EventHandler(this.dataGridDSSV_SelectionChanged);
            // 
            // btnluu
            // 
            this.btnluu.Location = new System.Drawing.Point(9, 25);
            this.btnluu.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(137, 40);
            this.btnluu.TabIndex = 2;
            this.btnluu.Text = "Lưu thanh toán";
            this.btnluu.UseVisualStyleBackColor = true;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // btnxuat
            // 
            this.btnxuat.Location = new System.Drawing.Point(176, 25);
            this.btnxuat.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnxuat.Name = "btnxuat";
            this.btnxuat.Size = new System.Drawing.Size(163, 40);
            this.btnxuat.TabIndex = 2;
            this.btnxuat.Text = "Xuất phiếu thanh toán";
            this.btnxuat.UseVisualStyleBackColor = true;
            this.btnxuat.Click += new System.EventHandler(this.btnxuat_Click);
            // 
            // dateTimeNgayDong
            // 
            this.dateTimeNgayDong.Location = new System.Drawing.Point(497, 23);
            this.dateTimeNgayDong.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dateTimeNgayDong.Name = "dateTimeNgayDong";
            this.dateTimeNgayDong.Size = new System.Drawing.Size(182, 26);
            this.dateTimeNgayDong.TabIndex = 3;
            // 
            // cobThangdong
            // 
            this.cobThangdong.FormattingEnabled = true;
            this.cobThangdong.Items.AddRange(new object[] {
            "Tháng 1",
            "Tháng 2",
            "Tháng 3",
            "Tháng 4",
            "Tháng 5",
            "Tháng 6",
            "Tháng 7",
            "Tháng 8",
            "Tháng 9",
            "Tháng 10",
            "Tháng 11",
            "Tháng 12"});
            this.cobThangdong.Location = new System.Drawing.Point(497, 67);
            this.cobThangdong.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cobThangdong.Name = "cobThangdong";
            this.cobThangdong.Size = new System.Drawing.Size(182, 27);
            this.cobThangdong.TabIndex = 4;
            this.cobThangdong.Text = "Chọn Tháng Đóng";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(941, 25);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(140, 40);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(375, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Đóng cho tháng :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(375, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ngày đóng :";
            // 
            // radiNhanTien
            // 
            this.radiNhanTien.AutoSize = true;
            this.radiNhanTien.Location = new System.Drawing.Point(941, 23);
            this.radiNhanTien.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radiNhanTien.Name = "radiNhanTien";
            this.radiNhanTien.Size = new System.Drawing.Size(109, 23);
            this.radiNhanTien.TabIndex = 6;
            this.radiNhanTien.TabStop = true;
            this.radiNhanTien.Text = "Đã nhận tiền";
            this.radiNhanTien.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radiNhanTien);
            this.groupBox3.Controls.Add(this.txtmssv);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cobThangdong);
            this.groupBox3.Controls.Add(this.txtphong);
            this.groupBox3.Controls.Add(this.txtsotien);
            this.groupBox3.Controls.Add(this.txttensv);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.dateTimeNgayDong);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(37, 61);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox3.Size = new System.Drawing.Size(1091, 124);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin sinh viên";
            // 
            // txtmssv
            // 
            this.txtmssv.Location = new System.Drawing.Point(152, 65);
            this.txtmssv.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtmssv.Name = "txtmssv";
            this.txtmssv.ReadOnly = true;
            this.txtmssv.Size = new System.Drawing.Size(206, 26);
            this.txtmssv.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 72);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Mã số sinh viên :";
            // 
            // txtphong
            // 
            this.txtphong.Location = new System.Drawing.Point(749, 23);
            this.txtphong.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtphong.Name = "txtphong";
            this.txtphong.ReadOnly = true;
            this.txtphong.Size = new System.Drawing.Size(155, 26);
            this.txtphong.TabIndex = 0;
            // 
            // txtsotien
            // 
            this.txtsotien.Location = new System.Drawing.Point(751, 72);
            this.txtsotien.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtsotien.Name = "txtsotien";
            this.txtsotien.ReadOnly = true;
            this.txtsotien.Size = new System.Drawing.Size(154, 26);
            this.txtsotien.TabIndex = 0;
            // 
            // txttensv
            // 
            this.txttensv.Location = new System.Drawing.Point(152, 23);
            this.txttensv.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txttensv.Name = "txttensv";
            this.txttensv.ReadOnly = true;
            this.txttensv.Size = new System.Drawing.Size(206, 26);
            this.txttensv.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(682, 28);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 19);
            this.label7.TabIndex = 5;
            this.label7.Text = "Phòng :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(684, 81);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Số tiền :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 30);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tên sinh viên :";
            // 
            // btnluuvaosql
            // 
            this.btnluuvaosql.Location = new System.Drawing.Point(356, 25);
            this.btnluuvaosql.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnluuvaosql.Name = "btnluuvaosql";
            this.btnluuvaosql.Size = new System.Drawing.Size(191, 40);
            this.btnluuvaosql.TabIndex = 2;
            this.btnluuvaosql.Text = "Lưu vào Cơ Sở Dữ Liệu";
            this.btnluuvaosql.UseVisualStyleBackColor = true;
            this.btnluuvaosql.Click += new System.EventHandler(this.btnluuvaosql_Click);
            // 
            // btnhuy
            // 
            this.btnhuy.Location = new System.Drawing.Point(562, 25);
            this.btnhuy.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(163, 40);
            this.btnhuy.TabIndex = 2;
            this.btnhuy.Text = "Hủy Thay Đổi";
            this.btnhuy.UseVisualStyleBackColor = true;
            this.btnhuy.Click += new System.EventHandler(this.btnhuy_Click);
            // 
            // btnlsdt
            // 
            this.btnlsdt.Location = new System.Drawing.Point(762, 25);
            this.btnlsdt.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnlsdt.Name = "btnlsdt";
            this.btnlsdt.Size = new System.Drawing.Size(152, 40);
            this.btnlsdt.TabIndex = 2;
            this.btnlsdt.Text = "Lịch Sử Đóng Tiền";
            this.btnlsdt.UseVisualStyleBackColor = true;
            this.btnlsdt.Click += new System.EventHandler(this.btnlsdt_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnluuvaosql);
            this.groupBox2.Controls.Add(this.btnluu);
            this.groupBox2.Controls.Add(this.btnThoat);
            this.groupBox2.Controls.Add(this.btnxuat);
            this.groupBox2.Controls.Add(this.btnhuy);
            this.groupBox2.Controls.Add(this.btnlsdt);
            this.groupBox2.Location = new System.Drawing.Point(37, 191);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1091, 79);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btntimkiem);
            this.groupBox4.Controls.Add(this.combtimphong);
            this.groupBox4.Controls.Add(this.txtTimKiem);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Location = new System.Drawing.Point(46, 276);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1072, 76);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tìm kiếm";
            // 
            // btntimkiem
            // 
            this.btntimkiem.BackColor = System.Drawing.Color.DarkGray;
            this.btntimkiem.ForeColor = System.Drawing.Color.Black;
            this.btntimkiem.Location = new System.Drawing.Point(932, 33);
            this.btntimkiem.Margin = new System.Windows.Forms.Padding(2);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(123, 30);
            this.btntimkiem.TabIndex = 9;
            this.btntimkiem.Text = "Tìm kiếm ";
            this.btntimkiem.UseVisualStyleBackColor = false;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // combtimphong
            // 
            this.combtimphong.FormattingEnabled = true;
            this.combtimphong.Location = new System.Drawing.Point(701, 36);
            this.combtimphong.Margin = new System.Windows.Forms.Padding(2);
            this.combtimphong.Name = "combtimphong";
            this.combtimphong.Size = new System.Drawing.Size(213, 27);
            this.combtimphong.TabIndex = 8;
            this.combtimphong.SelectedIndexChanged += new System.EventHandler(this.combtimphong_SelectedIndexChanged);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(205, 34);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.txtTimKiem.Multiline = true;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(317, 29);
            this.txtTimKiem.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 34);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(154, 19);
            this.label13.TabIndex = 5;
            this.label13.Text = "Nhập MSSV và tên SV";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.SteelBlue;
            this.label12.Location = new System.Drawing.Point(549, 34);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 19);
            this.label12.TabIndex = 6;
            this.label12.Text = "Lọc theo phòng ";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 663);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDSSV)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridDSSV;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Button btnxuat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cobThangdong;
        private System.Windows.Forms.DateTimePicker dateTimeNgayDong;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.RadioButton radiNhanTien;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtmssv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txttensv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtsotien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtphong;
        private System.Windows.Forms.Button btnluuvaosql;
        private System.Windows.Forms.Button btnhuy;
        private System.Windows.Forms.Button btnlsdt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox combtimphong;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btntimkiem;
    }
}