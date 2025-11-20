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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            
        }

        string connectionString = @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=QL_KyTucXa;Integrated Security=True;TrustServerCertificate=True";
        DataSet ds = new DataSet();
        SqlDataAdapter daSinhvien;
        DataTable dt;
        private void Form4_Load(object sender, EventArgs e)
        {
            
            TaiDuLieuLenDataGird();
            TaiPhongVaoTimKiem();

        }
        private void TaiDuLieuLenDataGird()
        {
            string query = "SELECT * FROM SinhVien";

            try
            {

                daSinhvien = new SqlDataAdapter(query, connectionString);


                SqlCommandBuilder builder = new SqlCommandBuilder(daSinhvien);


                dt = new DataTable();


                daSinhvien.Fill(dt);


                dt.DefaultView.RowStateFilter = DataViewRowState.CurrentRows | DataViewRowState.Added;


                dataGridDSSV.DataSource = dt;


                dataGridDSSV.Columns["MSSV"].HeaderText = "Mã Số Sinh Viên";
                dataGridDSSV.Columns["MSSV"].Width = 125;
                dataGridDSSV.Columns["HoTen"].HeaderText = "Họ Tên";
                dataGridDSSV.Columns["HoTen"].Width = 150;
                dataGridDSSV.Columns["Lop"].HeaderText = "Lớp";
                dataGridDSSV.Columns["Lop"].Width = 100;
                dataGridDSSV.Columns["SDT"].HeaderText = "Số Điện Thoại";
                dataGridDSSV.Columns["SDT"].Width = 120;
                dataGridDSSV.Columns["GioiTinh"].HeaderText = "Giới Tính";
                dataGridDSSV.Columns["GioiTinh"].Width = 90;
                dataGridDSSV.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                dataGridDSSV.Columns["NgaySinh"].Width = 100;
                dataGridDSSV.Columns["NgayVao"].HeaderText = "Ngày Vào";
                dataGridDSSV.Columns["NgayVao"].Width = 100;
                dataGridDSSV.Columns["MaPhong"].HeaderText = "Mã Phòng";
                dataGridDSSV.Columns["MaPhong"].Width = 100;
                dataGridDSSV.Columns["TrangThaiTienPhong"].HeaderText = "Trạng Thái Tiền Phòng";
                dataGridDSSV.Columns["TrangThaiTienPhong"].Width = 180;
                dataGridDSSV.Columns["QueQuan"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridDSSV_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridDSSV.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridDSSV.SelectedRows[0];

                txtmssv.Text = selectedRow.Cells["MSSV"].Value.ToString();
                txttensv.Text = selectedRow.Cells["HoTen"].Value.ToString();

                string maPhong = selectedRow.Cells["MaPhong"].Value.ToString();
                txtphong.Text = maPhong;

                HienThiTongTien(maPhong);
            }
        }
        private void HienThiTongTien(string maPhong)
        {
            string query = "SELECT Gia, TienDienNuoc FROM Phong WHERE MaPhong = @MaPhong";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaPhong", maPhong);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                decimal giaPhong = Convert.ToDecimal(reader["Gia"]);
                                decimal tienDienNuoc = 0;
                                if (reader["TienDienNuoc"] != DBNull.Value)
                                {
                                    tienDienNuoc = Convert.ToDecimal(reader["TienDienNuoc"]);
                                }
                                decimal tongTien = giaPhong + tienDienNuoc;
                                txtsotien.Text = tongTien.ToString("N0") + " VND";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính tiền phòng: " + ex.Message);
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (dataGridDSSV.SelectedRows.Count == 0 || string.IsNullOrEmpty(txtmssv.Text))
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra đã chọn tháng chưa
            if (cobThangdong.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn tháng cần đóng tiền.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra đã tick vào "Đã nhận tiền" chưa
            if (!radiNhanTien.Checked)
            {
                MessageBox.Show("Vui lòng xác nhận đã nhận tiền (tick vào ô 'Đã nhận tiền').", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. CẬP NHẬT TRỰC TIẾP LÊN DATAGRIDVIEW (KHÔNG GỌI SQL)
            try
            {
                // Lấy dòng đang được chọn
                DataGridViewRow selectedRow = dataGridDSSV.SelectedRows[0];

                // Thay đổi giá trị ô "Trạng Thái Tiền Phòng" thành "Đã đóng"
                // (Lưu ý: Tên cột phải khớp với tên trong CSDL/DataTable, ở đây là "TrangThaiTienPhong")
                selectedRow.Cells["TrangThaiTienPhong"].Value = "Đã đóng";

                // (Tùy chọn) Đổi màu nền dòng đó để dễ nhận biết
                selectedRow.DefaultCellStyle.BackColor = Color.LightGreen;

                // 3. THÔNG BÁO THÀNH CÔNG
                MessageBox.Show($"Đã cập nhật trạng thái đóng tiền cho sinh viên {txttensv.Text}!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4. RESET CÁC Ô NHẬP LIỆU
                radiNhanTien.Checked = false;
                cobThangdong.SelectedIndex = -1;
                txtsotien.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi cập nhật danh sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Bạn có chắc chắn muốn hủy tất cả các thay đổi chưa lưu trên bảng không?",
        "Xác nhận hủy",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );

            if (result == DialogResult.Yes)
            {
                try
                {
                    // 2. Hoàn tác toàn bộ thay đổi trong DataTable
                    // (Những dòng bạn đã sửa thành "Đã đóng" sẽ quay lại trạng thái cũ)
                    dt.RejectChanges();

                    // 3. Xóa trắng các ô nhập liệu để làm sạch giao diện
                    txtmssv.Text = "";
                    txttensv.Text = "";
                    txtphong.Text = "";
                    txtsotien.Text = "";
                    cobThangdong.SelectedIndex = -1;
                    radiNhanTien.Checked = false;

                    MessageBox.Show("Đã hủy bỏ các thay đổi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi hủy thay đổi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TaiPhongVaoTimKiem()
        {
            combtimphong.Items.Clear();
            combtimphong.Items.Add("--- Tất cả ---");

            string query = "SELECT MaPhong FROM Phong ORDER BY MaPhong";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            combtimphong.Items.Add(reader["MaPhong"].ToString());
                        }
                    }
                }
                combtimphong.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách phòng tìm kiếm: " + ex.Message);
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập Mã số sinh viên hoặc Tên sinh viên để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filterExpression = string.Format("MSSV LIKE '%{0}%' OR HoTen LIKE '%{0}%'", keyword);
            if (dt != null)
            {
                dt.DefaultView.RowFilter = filterExpression;
                if (dataGridDSSV.Rows.Count == 0 || (dataGridDSSV.Rows.Count == 1 && dataGridDSSV.Rows[0].IsNewRow))
                {
                    MessageBox.Show("Không tìm thấy sinh viên nào với thông tin này.", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt.DefaultView.RowFilter = string.Empty;
                }
            }
        }

        private void combtimphong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dt == null) return;
            if (combtimphong.SelectedIndex == -1) return;
            if (combtimphong.SelectedIndex == 0) 
            {
                dt.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                string maPhongCanLoc = combtimphong.Text;
                dt.DefaultView.RowFilter = $"MaPhong = '{maPhongCanLoc}'";

                if (dt.DefaultView.Count == 0)
                {
                    MessageBox.Show($"Không có sinh viên nào trong phòng {maPhongCanLoc}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnluuvaosql_Click(object sender, EventArgs e)
        {
            if (dt == null || daSinhvien == null)
            {
                MessageBox.Show("Chưa có dữ liệu để lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn lưu tất cả thay đổi vào Cơ sở dữ liệu không?",
                "Xác nhận lưu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    SqlCommandBuilder builder = new SqlCommandBuilder(daSinhvien);

                    daSinhvien.Update(dt);

                    dt.AcceptChanges();

                    MessageBox.Show("Đã lưu dữ liệu vào SQL Server thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu vào CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
