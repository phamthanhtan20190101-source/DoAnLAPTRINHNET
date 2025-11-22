namespace QLKTX
{
    partial class TTPhong
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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblThongTinChung = new System.Windows.Forms.Label();
            this.ibtnThoat = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 61);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(800, 391);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // lblThongTinChung
            // 
            this.lblThongTinChung.AutoSize = true;
            this.lblThongTinChung.Location = new System.Drawing.Point(12, 20);
            this.lblThongTinChung.Name = "lblThongTinChung";
            this.lblThongTinChung.Size = new System.Drawing.Size(44, 16);
            this.lblThongTinChung.TabIndex = 1;
            this.lblThongTinChung.Text = "label1";
            // 
            // ibtnThoat
            // 
            this.ibtnThoat.BackColor = System.Drawing.Color.SeaShell;
            this.ibtnThoat.IconChar = FontAwesome.Sharp.IconChar.CircleXmark;
            this.ibtnThoat.IconColor = System.Drawing.Color.SteelBlue;
            this.ibtnThoat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnThoat.Location = new System.Drawing.Point(677, -2);
            this.ibtnThoat.Name = "ibtnThoat";
            this.ibtnThoat.Size = new System.Drawing.Size(123, 61);
            this.ibtnThoat.TabIndex = 26;
            this.ibtnThoat.Text = "Thoát";
            this.ibtnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ibtnThoat.UseVisualStyleBackColor = false;
            this.ibtnThoat.Click += new System.EventHandler(this.ibtnThoat_Click);
            // 
            // TTPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 452);
            this.Controls.Add(this.ibtnThoat);
            this.Controls.Add(this.lblThongTinChung);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Name = "TTPhong";
            this.Text = "TTPhong";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblThongTinChung;
        private FontAwesome.Sharp.IconButton ibtnThoat;
    }
}