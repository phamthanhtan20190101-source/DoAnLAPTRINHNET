namespace QLKTX
{
    partial class TTToaNha
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ibtnThoat = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1057, 366);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // ibtnThoat
            // 
            this.ibtnThoat.BackColor = System.Drawing.Color.SeaShell;
            this.ibtnThoat.IconChar = FontAwesome.Sharp.IconChar.CircleXmark;
            this.ibtnThoat.IconColor = System.Drawing.Color.SteelBlue;
            this.ibtnThoat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnThoat.Location = new System.Drawing.Point(463, 418);
            this.ibtnThoat.Name = "ibtnThoat";
            this.ibtnThoat.Size = new System.Drawing.Size(119, 61);
            this.ibtnThoat.TabIndex = 25;
            this.ibtnThoat.Text = "Thoát";
            this.ibtnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ibtnThoat.UseVisualStyleBackColor = false;
            this.ibtnThoat.Click += new System.EventHandler(this.ibtnThoat_Click);
            // 
            // TTToaNha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 539);
            this.Controls.Add(this.ibtnThoat);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "TTToaNha";
            this.Text = "TTToaNha";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private FontAwesome.Sharp.IconButton ibtnThoat;
    }
}