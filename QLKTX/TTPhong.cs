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
            HienThiThongTin();
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

        private void HienThiThongTin()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // SQL: Đếm tổng số phòng VÀ tổng số sinh viên của tòa nhà này
                    string sql = @"
                    SELECT 
                        (SELECT COUNT(*) FROM Phong WHERE MaToaNha = @ma) AS TongPhong,
                        (SELECT COUNT(*) FROM SinhVien SV JOIN Phong P ON SV.MaPhong = P.MaPhong WHERE P.MaToaNha = @ma) AS TongSV";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ma", maToaNha);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int tongPhong = reader["TongPhong"] != DBNull.Value ? Convert.ToInt32(reader["TongPhong"]) : 0;
                            int tongSV = reader["TongSV"] != DBNull.Value ? Convert.ToInt32(reader["TongSV"]) : 0;

                            // Hiển thị lên Label (đã tạo ở bước thiết kế)
                            // Nếu chưa có label thì dùng MessageBox hoặc đặt tiêu đề Form
                            this.Text += $" | Tổng: {tongPhong} phòng - {tongSV} sinh viên";

                            // Nếu có Label thì dùng dòng này:
                            lblThongTinChung.Text = $"Tòa nhà {maToaNha}: Tổng {tongPhong} phòng, hiện có {tongSV} sinh viên.";
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi thống kê: " + ex.Message); }
            }
        }

        private void ibtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn có muốn quay về màn hình chính?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (traloi == DialogResult.Yes)
            {
                Application.Restart();
                Environment.Exit(0);
            }
        }
    }
}
