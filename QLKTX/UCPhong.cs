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
    public partial class UCPhong : UserControl
    {
        public UCPhong()
        {
            InitializeComponent();
            this.Click += (s, e) => OnSelect?.Invoke(this, e);
            foreach (Control c in this.Controls) c.Click += (s, e) => OnSelect?.Invoke(this, e);
        }
        public event EventHandler OnSelect = null;
        private int LaySo(string text)
        {
            var match = System.Text.RegularExpressions.Regex.Match(text ?? "", @"\d+");
            return match.Success ? int.Parse(match.Value) : 0;
        }
        public void SetData(string maPhong, string loaiPhong, int soLuongDaO)
        {
            int sucChua = LaySo(loaiPhong);
            lblTenPhong.Text = $"Phòng {maPhong} ({soLuongDaO} / {sucChua})";
            if (soLuongDaO >= sucChua) lblTenPhong.ForeColor = Color.Red;
        }

    }
}
