using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKTX
{
    public partial class TTToaNha : Form
    {
        public TTToaNha()
        {
            InitializeComponent();
            LoadData();
        }
        string connectionString = @"Data Source=LAPTOP-40KODIPL\SQLEXPRESS;Initial Catalog=QL_KyTucXa01;Integrated Security=True;TrustServerCertificate=True";

        private void TTToaNha_Load(object sender, EventArgs e) { LoadData(); }

        private void LoadData()
        {
            flowLayoutPanel1.Controls.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Câu lệnh SQL thần thánh để lấy thông tin
                string sql = @"SELECT T.MaToaNha, T.TenToaNha, T.SoLuongPhong,
                           (SELECT COUNT(*) FROM Phong P WHERE P.MaToaNha = T.MaToaNha AND P.TrangThai = N'Đầy') AS DaDung
                           FROM ToaNha T";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UCToaNha item = new UCToaNha();
                    item.SetData(reader["MaToaNha"].ToString(), reader["TenToaNha"].ToString(),
                                 Convert.ToInt32(reader["DaDung"]), Convert.ToInt32(reader["SoLuongPhong"]));

                    // Sự kiện khi Click vào tòa nhà -> Mở Form chi tiết
                    item.OnSelect += (s, e) => {
                        TTPhong frm = new TTPhong(item.MaToaNha);
                        frm.ShowDialog();
                    };
                    flowLayoutPanel1.Controls.Add(item);
                }
            }
        }
    }
}
