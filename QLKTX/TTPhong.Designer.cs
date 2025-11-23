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
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 63);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(888, 381);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // lblThongTinChung
            // 
            this.lblThongTinChung.AutoSize = true;
            this.lblThongTinChung.Location = new System.Drawing.Point(16, 28);
            this.lblThongTinChung.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblThongTinChung.Name = "lblThongTinChung";
            this.lblThongTinChung.Size = new System.Drawing.Size(60, 22);
            this.lblThongTinChung.TabIndex = 1;
            this.lblThongTinChung.Text = "label1";
            // 
            // ibtnThoat
            // 
            this.ibtnThoat.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ibtnThoat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ibtnThoat.IconChar = FontAwesome.Sharp.IconChar.CircleXmark;
            this.ibtnThoat.IconColor = System.Drawing.Color.Red;
            this.ibtnThoat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnThoat.Location = new System.Drawing.Point(737, 451);
            this.ibtnThoat.Name = "ibtnThoat";
            this.ibtnThoat.Size = new System.Drawing.Size(118, 72);
            this.ibtnThoat.TabIndex = 25;
            this.ibtnThoat.Text = "Thoát";
            this.ibtnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ibtnThoat.UseVisualStyleBackColor = false;
            this.ibtnThoat.Click += new System.EventHandler(this.ibtnThoat_Click);
            // 
            // TTPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 531);
            this.Controls.Add(this.ibtnThoat);
            this.Controls.Add(this.lblThongTinChung);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
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