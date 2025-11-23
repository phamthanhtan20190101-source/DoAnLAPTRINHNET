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
using System.IO;

namespace QLKTX
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            
        }

        //string connectionString = @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=QL_KyTucXa;Integrated Security=True;TrustServerCertificate=True";
        string connectionString = @"Data Source=LAPTOP-40KODIPL\SQLEXPRESS;Initial Catalog=QL_KyTucXa01;Integrated Security=True;TrustServerCertificate=True";
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
                // 1. Khởi tạo DataAdapter
                daSinhvien = new SqlDataAdapter(query, connectionString);

                // 2. Tự động tạo lệnh INSERT, UPDATE, DELETE
                SqlCommandBuilder builder = new SqlCommandBuilder(daSinhvien);

                // === BẮT BUỘC PHẢI CÓ 3 DÒNG NÀY ===
                daSinhvien.InsertCommand = builder.GetInsertCommand();
                daSinhvien.UpdateCommand = builder.GetUpdateCommand();
                daSinhvien.DeleteCommand = builder.GetDeleteCommand();
                // =====================================

                // 3. Khởi tạo DataTable toàn cục
                dt = new DataTable();

                // 4. Đổ TOÀN BỘ dữ liệu vào DataTable
                daSinhvien.Fill(dt);

                // 5. Cài đặt để hiển thị cả dòng mới thêm
                dt.DefaultView.RowStateFilter = DataViewRowState.CurrentRows | DataViewRowState.Added;

                // 6. Gán DataTable làm nguồn
                dataGridDSSV.DataSource = dt;

                // 7. Định dạng cột
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
                dataGridDSSV.Columns["TrangThaiTienPhong"].Width = 200;
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
            if (cobThangdong.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn tháng cần đóng tiền.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!radiNhanTien.Checked)
            {
                MessageBox.Show("Vui lòng xác nhận đã nhận tiền.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. CẬP NHẬT VÀO DATATABLE (QUAN TRỌNG)
            try
            {
                // Lấy DataRow (dòng dữ liệu gốc) từ dòng đang chọn trên lưới
                // Việc này giúp đảm bảo RowState được đánh dấu là Modified
                if (dataGridDSSV.CurrentRow.DataBoundItem is DataRowView rowView)
                {
                    DataRow row = rowView.Row;

                    // Cập nhật giá trị cột "TrangThaiTienPhong"
                    row["TrangThaiTienPhong"] = "Đã đóng";

                    // (Tùy chọn) Đổi màu trên lưới để dễ nhìn
                    dataGridDSSV.CurrentRow.DefaultCellStyle.BackColor = Color.LightGreen;

                    MessageBox.Show($"Đã cập nhật trạng thái cho sinh viên {txttensv.Text}!\nHãy nhấn 'Lưu vào CSDL' để hoàn tất.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            // trở về Form1 (Quản lý)
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();


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
            if (string.IsNullOrEmpty(txtmssv.Text) || cobThangdong.SelectedIndex == -1 || string.IsNullOrEmpty(txtsotien.Text))
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin sinh viên và tháng đóng tiền.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mssv = txtmssv.Text.Trim();
            int thang = cobThangdong.SelectedIndex + 1;
            int nam = dateTimeNgayDong.Value.Year;

            // 2. === KIỂM TRA TRÙNG LẶP  ===
            // Kiểm tra xem sinh viên này đã đóng tiền cho tháng/năm này chưa
            if (KiemTraDaDongTien(mssv, thang, nam))
            {
                MessageBox.Show($"Sinh viên {mssv} ĐÃ ĐÓNG TIỀN cho Tháng {thang}/{nam} rồi!\nKhông thể đóng trùng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại ngay, không lưu
            }

            // 3. Hỏi xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn lưu vào CSDL không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            // 4. BẮT ĐẦU QUÁ TRÌNH LƯU (Phần này giống code cũ nhưng an toàn hơn)
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // A. CẬP NHẬT TRẠNG THÁI SINH VIÊN
                    string sqlUpdateSV = "UPDATE SinhVien SET TrangThaiTienPhong = N'Đã đóng' WHERE MSSV = @MSSV";
                    using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdateSV, conn, transaction))
                    {
                        cmdUpdate.Parameters.AddWithValue("@MSSV", mssv);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    // B. TẠO MÃ THANH TOÁN
                    string baSoCuoi = mssv.Length >= 3 ? mssv.Substring(mssv.Length - 3) : mssv;
                    string maThanhToan = $"TT{baSoCuoi}_{thang}";

                    // C. THÊM LỊCH SỬ ĐÓNG TIỀN
                    string sqlInsertLS = @"
                INSERT INTO LichSuDongTien (MaThanhToan, MSSV, ThangDongTien, NamDongTien, SoTien, NgayDong) 
                VALUES (@Ma, @MSSV, @Thang, @Nam, @Tien, @Ngay)";

                    using (SqlCommand cmdInsert = new SqlCommand(sqlInsertLS, conn, transaction))
                    {
                        cmdInsert.Parameters.AddWithValue("@Ma", maThanhToan);
                        cmdInsert.Parameters.AddWithValue("@MSSV", mssv);
                        cmdInsert.Parameters.AddWithValue("@Thang", thang);
                        cmdInsert.Parameters.AddWithValue("@Nam", nam);

                        decimal tien = 0;
                        string tienText = txtsotien.Text.Replace(",", "").Replace(".", "").Replace(" VND", "").Trim();
                        decimal.TryParse(tienText, out tien);
                        cmdInsert.Parameters.AddWithValue("@Tien", tien);
                        cmdInsert.Parameters.AddWithValue("@Ngay", dateTimeNgayDong.Value);

                        cmdInsert.ExecuteNonQuery();
                    }

                    // D. HOÀN TẤT
                    transaction.Commit();

                    // Reset giao diện
                    MessageBox.Show($"Lưu thành công!\nMã GD: {maThanhToan}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtsotien.Text = "";
                    cobThangdong.SelectedIndex = -1;
                    radiNhanTien.Checked = false;
                    TaiDuLieuLenDataGird();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool KiemTraDaDongTien(string mssv, int thang, int nam)
        {
            string query = "SELECT COUNT(*) FROM LichSuDongTien WHERE MSSV = @MSSV AND ThangDongTien = @Thang AND NamDongTien = @Nam";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MSSV", mssv);
                        cmd.Parameters.AddWithValue("@Thang", thang);
                        cmd.Parameters.AddWithValue("@Nam", nam);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0; // Nếu > 0 tức là đã có dữ liệu -> Đã đóng
                    }
                }
            }
            catch (Exception)
            {
                return false; // Nếu lỗi kết nối thì tạm thời cho qua (hoặc xử lý tùy bạn)
            }
        }
        private void btnxuat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtmssv.Text) || string.IsNullOrEmpty(txtsotien.Text) || cobThangdong.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin để xuất phiếu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. LẤY THÔNG TIN CẦN THIẾT
            string mssv = txtmssv.Text.Trim();
            int thang = cobThangdong.SelectedIndex + 1;
            string baSoCuoi = mssv.Length >= 3 ? mssv.Substring(mssv.Length - 3) : mssv;
            string maThanhToan = $"TT{baSoCuoi}_{thang}"; // Tạo mã TT001_10

            // Lấy tên người quản lý (Dùng UserSession hoặc Program tùy theo cách bạn đã chọn)
            string tenQuanLy = Program.HoTenNguoiDung;

            // 3. TẠO NỘI DUNG PHIẾU
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("===============================================");
            sb.AppendLine("           PHIẾU THANH TOÁN TIỀN KÝ TÚC XÁ     ");
            sb.AppendLine("===============================================");
            sb.AppendLine("");

            // --- THÊM TÊN NGƯỜI LẬP Ở ĐÂY ---
            sb.AppendLine($"Mã thanh toán  : {maThanhToan}");
            sb.AppendLine($"Người lập phiếu: {tenQuanLy}"); // <--- Dòng mới thêm
            sb.AppendLine($"Ngày lập phiếu : {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}");
            // --------------------------------

            sb.AppendLine("");
            sb.AppendLine("---------------- THÔNG TIN SINH VIÊN --------------");
            sb.AppendLine($"Mã số sinh viên : {txtmssv.Text}");
            sb.AppendLine($"Họ và tên       : {txttensv.Text}");
            sb.AppendLine($"Phòng ở         : {txtphong.Text}");
            sb.AppendLine("");
            sb.AppendLine("---------------- CHI TIẾT THANH TOÁN --------------");
            sb.AppendLine($"Nội dung thu    : Tiền phòng + Điện nước ({cobThangdong.Text})");
            sb.AppendLine($"Ngày đóng tiền  : {dateTimeNgayDong.Value.ToString("dd/MM/yyyy")}");
            sb.AppendLine($"Số tiền         : {txtsotien.Text}");

            string trangThai = radiNhanTien.Checked ? "Đã thanh toán" : "Chưa thanh toán (Phiếu tạm)";
            sb.AppendLine($"Trạng thái      : {trangThai}");

            sb.AppendLine("");
            sb.AppendLine("===============================================");
            sb.AppendLine("       Người lập phiếu          Người nộp tiền");
            sb.AppendLine("          (Ký tên)                 (Ký tên)");
            sb.AppendLine("");
            sb.AppendLine("");

            // Phần ký tên bên dưới có thể để tên người nộp, người lập đã có ở trên rồi
            string tenSinhVien = txttensv.Text;
            

            sb.AppendLine("===============================================");

            // 4. LƯU FILE
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File (*.txt)|*.txt";
            sfd.Title = "Lưu Phiếu Thanh Toán";
            sfd.FileName = $"PhieuThu_{maThanhToan}_{mssv}.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(sfd.FileName, sb.ToString());
                    MessageBox.Show($"Xuất phiếu thành công!\nĐường dẫn: {sfd.FileName}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnlsdt_Click(object sender, EventArgs e)
        {
            if (dataGridDSSV.SelectedRows.Count > 0)
            {
                // 2. Lấy dữ liệu từ dòng đang chọn
                DataGridViewRow selectedRow = dataGridDSSV.SelectedRows[0];

                string mssv = selectedRow.Cells["MSSV"].Value.ToString();
                string hoten = selectedRow.Cells["HoTen"].Value.ToString();
                string phong = selectedRow.Cells["MaPhong"].Value.ToString();

                // 3. Khởi tạo Form 6 và truyền dữ liệu sang
                // (Lưu ý: Form6 phải có hàm khởi tạo nhận 3 tham số này)
                Form6 fLichSu = new Form6(mssv, hoten, phong);

                // 4. Hiển thị Form 6
                fLichSu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên trên danh sách để xem lịch sử.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
