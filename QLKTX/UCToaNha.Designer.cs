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
            this.ibtnToaNha = new FontAwesome.Sharp.IconButton();
            this.lblTenToaNha = new System.Windows.Forms.Label();
            this.lblThongSo = new System.Windows.Forms.Label();
            this.lblToaNha = new System.Windows.Forms.Label();
            this.lblSoPhong = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // ibtnToaNha
            // 
            this.ibtnToaNha.AutoSize = true;
            this.ibtnToaNha.BackColor = System.Drawing.Color.SeaShell;
            this.ibtnToaNha.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ibtnToaNha.IconChar = FontAwesome.Sharp.IconChar.House;
            this.ibtnToaNha.IconColor = System.Drawing.Color.SteelBlue;
            this.ibtnToaNha.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnToaNha.IconSize = 50;
            this.ibtnToaNha.Location = new System.Drawing.Point(63, 21);
            this.ibtnToaNha.Name = "ibtnToaNha";
            this.ibtnToaNha.Size = new System.Drawing.Size(119, 85);
            this.ibtnToaNha.TabIndex = 0;
            this.ibtnToaNha.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ibtnToaNha.UseVisualStyleBackColor = false;
            // 
            // lblTenToaNha
            // 
            this.lblTenToaNha.Location = new System.Drawing.Point(0, 0);
            this.lblTenToaNha.Name = "lblTenToaNha";
            this.lblTenToaNha.Size = new System.Drawing.Size(100, 23);
            this.lblTenToaNha.TabIndex = 1;
            // 
            // lblThongSo
            // 
            this.lblThongSo.Location = new System.Drawing.Point(0, 0);
            this.lblThongSo.Name = "lblThongSo";
            this.lblThongSo.Size = new System.Drawing.Size(100, 23);
            this.lblThongSo.TabIndex = 0;
            // 
            // lblToaNha
            // 
            this.lblToaNha.Location = new System.Drawing.Point(19, 139);
            this.lblToaNha.Name = "lblToaNha";
            this.lblToaNha.Size = new System.Drawing.Size(44, 26);
            this.lblToaNha.TabIndex = 2;
            this.lblToaNha.Text = "label1";
            // 
            // lblSoPhong
            // 
            this.lblSoPhong.Location = new System.Drawing.Point(19, 176);
            this.lblSoPhong.Name = "lblSoPhong";
            this.lblSoPhong.Size = new System.Drawing.Size(44, 16);
            this.lblSoPhong.TabIndex = 2;
            this.lblSoPhong.Text = "label1";
            // 
            // UCToaNha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.Controls.Add(this.lblSoPhong);
            this.Controls.Add(this.lblToaNha);
            this.Controls.Add(this.lblThongSo);
            this.Controls.Add(this.lblTenToaNha);
            this.Controls.Add(this.ibtnToaNha);
            this.Name = "UCToaNha";
            this.Size = new System.Drawing.Size(250, 223);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton ibtnToaNha;
        private System.Windows.Forms.Label lblTenToaNha;
        private System.Windows.Forms.Label lblThongSo;
        private System.Windows.Forms.Label lblToaNha;
        private System.Windows.Forms.Label lblSoPhong;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
