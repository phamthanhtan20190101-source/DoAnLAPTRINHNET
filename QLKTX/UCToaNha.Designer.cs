namespace QLKTX
{
    partial class UCToaNha
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
            this.ibtnPhong = new FontAwesome.Sharp.IconButton();
            this.lblTenToaNha = new System.Windows.Forms.Label();
            this.lblThongSo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ibtnPhong
            // 
            this.ibtnPhong.AutoSize = true;
            this.ibtnPhong.BackColor = System.Drawing.Color.SeaShell;
            this.ibtnPhong.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ibtnPhong.IconChar = FontAwesome.Sharp.IconChar.House;
            this.ibtnPhong.IconColor = System.Drawing.Color.SteelBlue;
            this.ibtnPhong.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnPhong.IconSize = 50;
            this.ibtnPhong.Location = new System.Drawing.Point(54, 3);
            this.ibtnPhong.Name = "ibtnPhong";
            this.ibtnPhong.Size = new System.Drawing.Size(119, 85);
            this.ibtnPhong.TabIndex = 0;
            this.ibtnPhong.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ibtnPhong.UseVisualStyleBackColor = false;
            // 
            // lblTenToaNha
            // 
            this.lblTenToaNha.AutoSize = true;
            this.lblTenToaNha.Location = new System.Drawing.Point(92, 90);
            this.lblTenToaNha.Name = "lblTenToaNha";
            this.lblTenToaNha.Size = new System.Drawing.Size(44, 16);
            this.lblTenToaNha.TabIndex = 1;
            this.lblTenToaNha.Text = "label1";
            // 
            // lblThongSo
            // 
            this.lblThongSo.AutoSize = true;
            this.lblThongSo.Location = new System.Drawing.Point(92, 117);
            this.lblThongSo.Name = "lblThongSo";
            this.lblThongSo.Size = new System.Drawing.Size(44, 16);
            this.lblThongSo.TabIndex = 2;
            this.lblThongSo.Text = "label1";
            this.lblThongSo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCToaNha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.Controls.Add(this.lblThongSo);
            this.Controls.Add(this.lblTenToaNha);
            this.Controls.Add(this.ibtnPhong);
            this.Name = "UCToaNha";
            this.Size = new System.Drawing.Size(226, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton ibtnPhong;
        private System.Windows.Forms.Label lblTenToaNha;
        private System.Windows.Forms.Label lblThongSo;
    }
}
