namespace QLKTX
{
    partial class UCPhong
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
            this.lblTenPhong = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ibtnPhong
            // 
            this.ibtnPhong.AutoSize = true;
            this.ibtnPhong.BackColor = System.Drawing.Color.SeaShell;
            this.ibtnPhong.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ibtnPhong.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.ibtnPhong.IconColor = System.Drawing.Color.SteelBlue;
            this.ibtnPhong.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnPhong.IconSize = 60;
            this.ibtnPhong.Location = new System.Drawing.Point(28, 17);
            this.ibtnPhong.Name = "ibtnPhong";
            this.ibtnPhong.Size = new System.Drawing.Size(180, 100);
            this.ibtnPhong.TabIndex = 1;
            this.ibtnPhong.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ibtnPhong.UseVisualStyleBackColor = false;
            // 
            // lblTenPhong
            // 
            this.lblTenPhong.AutoSize = true;
            this.lblTenPhong.Location = new System.Drawing.Point(25, 149);
            this.lblTenPhong.Name = "lblTenPhong";
            this.lblTenPhong.Size = new System.Drawing.Size(44, 16);
            this.lblTenPhong.TabIndex = 2;
            this.lblTenPhong.Text = "label1";
            this.lblTenPhong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.Controls.Add(this.lblTenPhong);
            this.Controls.Add(this.ibtnPhong);
            this.Name = "UCPhong";
            this.Size = new System.Drawing.Size(250, 200);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton ibtnPhong;
        private System.Windows.Forms.Label lblTenPhong;
    }
}
