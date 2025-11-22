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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblTenToaNha = new System.Windows.Forms.Label();
            this.lblThongSo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ibtnToaNha
            // 
            this.ibtnToaNha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ibtnToaNha.AutoSize = true;
            this.ibtnToaNha.BackColor = System.Drawing.Color.SeaShell;
            this.ibtnToaNha.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ibtnToaNha.IconChar = FontAwesome.Sharp.IconChar.House;
            this.ibtnToaNha.IconColor = System.Drawing.Color.SteelBlue;
            this.ibtnToaNha.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnToaNha.IconSize = 50;
            this.ibtnToaNha.Location = new System.Drawing.Point(63, 12);
            this.ibtnToaNha.Name = "ibtnToaNha";
            this.ibtnToaNha.Size = new System.Drawing.Size(119, 85);
            this.ibtnToaNha.TabIndex = 0;
            this.ibtnToaNha.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ibtnToaNha.UseVisualStyleBackColor = false;
            // 
            // lblTenToaNha
            // 
            this.lblTenToaNha.AutoSize = true;
            this.lblTenToaNha.Location = new System.Drawing.Point(25, 126);
            this.lblTenToaNha.Name = "lblTenToaNha";
            this.lblTenToaNha.Size = new System.Drawing.Size(0, 16);
            this.lblTenToaNha.TabIndex = 1;
            // 
            // lblThongSo
            // 
            this.lblThongSo.AutoSize = true;
            this.lblThongSo.Location = new System.Drawing.Point(25, 174);
            this.lblThongSo.Name = "lblThongSo";
            this.lblThongSo.Size = new System.Drawing.Size(0, 16);
            this.lblThongSo.TabIndex = 1;
            // 
            // UCToaNha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.Controls.Add(this.lblThongSo);
            this.Controls.Add(this.lblTenToaNha);
            this.Controls.Add(this.ibtnToaNha);
            this.Name = "UCToaNha";
            this.Size = new System.Drawing.Size(250, 205);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton ibtnToaNha;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblTenToaNha;
        private System.Windows.Forms.Label lblThongSo;
    }
}
