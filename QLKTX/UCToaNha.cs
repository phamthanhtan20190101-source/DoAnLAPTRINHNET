using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKTX
{
    public partial class UCToaNha : UserControl
    {
        public UCToaNha()
        {
            InitializeComponent();
            InitializeComponent();
            // Gán sự kiện click cho tất cả thành phần con
            this.Click += (s, e) => OnSelect?.Invoke(this, e);
            foreach (Control c in this.Controls) c.Click += (s, e) => OnSelect?.Invoke(this, e);
        }
        public event EventHandler OnSelect = null;
        public string MaToaNha { get; private set; }

        public void SetData(string ma, string ten, int daDung, int tong)
        {
            MaToaNha = ma;
            lblToaNha.Text = ten;
            lblSoPhong.Text = $"Đã dùng {daDung} / {tong} phòng";
            if (daDung >= tong) lblSoPhong.ForeColor = Color.Red; // Đổi màu đỏ nếu đầy
        }

   
    }
}
