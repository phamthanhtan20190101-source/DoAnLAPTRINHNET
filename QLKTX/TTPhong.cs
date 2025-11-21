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
    public partial class TTPhong : Form
    {
        public TTPhong()
        {
            InitializeComponent();
            LoadData();
        }
        string maToaNha;
        string connectionString = @"Data Source=LAPTOP-40KODIPL\SQLEXPRESS;Initial Catalog=QL_KyTucXa01;Integrated Security=True;TrustServerCertificate=True";


        public TTPhong(string ma) // Constructor nhận mã
        {
            InitializeComponent();
            this.maToaNha = ma;
            this.Text = "Danh sách phòng tòa " + ma;
            LoadData();
        }


        private void TTPhong_Load(object sender, EventArgs e) { LoadData(); }

        private void LoadData()
        {
            /*flowLayoutPanel2.Controls.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // SQL: Lấy phòng VÀ đếm số sinh viên trong đó
                string sql = @"SELECT P.MaPhong, P.LoaiPhong,
                           (SELECT COUNT(*) FROM SinhVien SV WHERE SV.MaPhong = P.MaPhong) AS DaO
                           FROM Phong P WHERE P.MaToaNha = @ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", maToaNha);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UCPhong item = new UCPhong();
                    item.SetData(reader["MaPhong"].ToString(), reader["LoaiPhong"].ToString(), Convert.ToInt32(reader["DaO"]));
                    flowLayoutPanel2.Controls.Add(item);
                }*/
            flowLayoutPanel2.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // SQL: Lấy phòng VÀ đếm số sinh viên trong đó
                    string sql = @"SELECT P.MaPhong, P.LoaiPhong,
                               (SELECT COUNT(*) FROM SinhVien SV WHERE SV.MaPhong = P.MaPhong) AS DaO
                               FROM Phong P WHERE P.MaToaNha = @ma";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ma", maToaNha); // Biến này đã có dữ liệu nhờ Constructor ở trên

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        UCPhong item = new UCPhong();

                        // Đổ dữ liệu vào thẻ
                        item.SetData(reader["MaPhong"].ToString(),
                                     reader["LoaiPhong"].ToString(),
                                     Convert.ToInt32(reader["DaO"]));

                        flowLayoutPanel2.Controls.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải phòng: " + ex.Message);
                }
            }
        }
    }
}
