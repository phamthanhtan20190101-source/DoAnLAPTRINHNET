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
                MessageBox.Show("Vui lòng chọn sinh viên và tháng cần lưu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn lưu vào CSDL không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            // 2. BẮT ĐẦU QUÁ TRÌNH LƯU
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction(); // Bắt đầu giao dịch

                try
                {
                    // === BƯỚC 1: CẬP NHẬT TRẠNG THÁI SINH VIÊN (UPDATE) ===
                    // Chúng ta dùng lệnh SQL trực tiếp cho chắc chắn, thay vì dùng daSinhvien.Update() dễ bị lỗi cấu hình
                    string sqlUpdateSV = "UPDATE SinhVien SET TrangThaiTienPhong = N'Đã đóng' WHERE MSSV = @MSSV";

                    using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdateSV, conn, transaction))
                    {
                        cmdUpdate.Parameters.AddWithValue("@MSSV", txtmssv.Text);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    // === BƯỚC 2: TẠO MÃ THANH TOÁN (TT***_xx) ===
                    string mssv = txtmssv.Text.Trim();
                    int thang = cobThangdong.SelectedIndex + 1;
                    int nam = dateTimeNgayDong.Value.Year;

                    // Lấy 3 số cuối của MSSV (Ví dụ: SV001 -> 001)
                    string baSoCuoi = mssv.Length >= 3 ? mssv.Substring(mssv.Length - 3) : mssv;
                    string maThanhToan = $"TT{baSoCuoi}_{thang}";

                    // === BƯỚC 3: THÊM LỊCH SỬ ĐÓNG TIỀN (INSERT) ===
                    string sqlInsertLS = @"
                INSERT INTO LichSuDongTien (MaThanhToan, MSSV, ThangDongTien, NamDongTien, SoTien, NgayDong) 
                VALUES (@Ma, @MSSV, @Thang, @Nam, @Tien, @Ngay)";

                    using (SqlCommand cmdInsert = new SqlCommand(sqlInsertLS, conn, transaction))
                    {
                        cmdInsert.Parameters.AddWithValue("@Ma", maThanhToan);
                        cmdInsert.Parameters.AddWithValue("@MSSV", mssv);
                        cmdInsert.Parameters.AddWithValue("@Thang", thang);
                        cmdInsert.Parameters.AddWithValue("@Nam", nam);

                        // Xử lý tiền (Xóa dấu phẩy, chữ đ...)
                        decimal tien = 0;
                        string tienText = txtsotien.Text.Replace(",", "").Replace(".", "").Replace(" VND", "").Trim();
                        decimal.TryParse(tienText, out tien);
                        cmdInsert.Parameters.AddWithValue("@Tien", tien);

                        cmdInsert.Parameters.AddWithValue("@Ngay", dateTimeNgayDong.Value);

                        cmdInsert.ExecuteNonQuery();
                    }

                    // === HOÀN TẤT ===
                    transaction.Commit(); // Xác nhận lưu
                    MessageBox.Show($"Lưu thành công!\nMã GD: {maThanhToan}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   

                    // Tải lại Grid để thấy trạng thái mới nhất từ CSDL
                    TaiDuLieuLenDataGird();
                }
                catch (SqlException sqlEx)
                {
                    transaction.Rollback(); // Gặp lỗi thì hoàn tác mọi thứ

                    // Bắt lỗi cụ thể để bạn dễ sửa
                    if (sqlEx.Message.Contains("String or binary data would be truncated"))
                    {
                        MessageBox.Show("LỖI: Mã thanh toán quá dài so với cột trong CSDL.\nHãy mở SQL và sửa cột MaThanhToan thành VARCHAR(50).", "Lỗi CSDL");
                    }
                    else if (sqlEx.Message.Contains("Conversion failed when converting the varchar value"))
                    {
                        MessageBox.Show($"LỖI: CSDL vẫn đang để cột MaThanhToan là kiểu SỐ (INT).\nCode đang cố gửi chữ '{txtmssv.Text}' vào.\n\nHãy chạy lệnh SQL tôi gửi ở bước trước để đổi sang VARCHAR.", "Sai kiểu dữ liệu");
                    }
                    else if (sqlEx.Number == 2627) // Trùng khóa chính
                    {
                        MessageBox.Show("Sinh viên này đã có lịch sử đóng tiền cho tháng này rồi (Trùng mã thanh toán).", "Trùng lặp");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi SQL: " + sqlEx.Message);
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi chung: " + ex.Message);
                }
            }
        }

        private void btnxuat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtmssv.Text) || string.IsNullOrEmpty(txtsotien.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xuất phiếu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. TẠO NỘI DUNG PHIẾU (Sử dụng StringBuilder để nối chuỗi cho nhanh)
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("===============================================");
            sb.AppendLine("           PHIẾU THANH TOÁN TIỀN KÝ TÚC XÁ     ");
            sb.AppendLine("===============================================");
            sb.AppendLine("");
            sb.AppendLine($"Mã phiếu: {DateTime.Now.ToString("yyyyMMddHHmmss")}"); // Mã tự sinh theo thời gian
            sb.AppendLine($"Ngày lập: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}");
            sb.AppendLine("");
            sb.AppendLine("---------------- THÔNG TIN SINH VIÊN --------------");
            sb.AppendLine($"Mã số sinh viên : {txtmssv.Text}");
            sb.AppendLine($"Họ và tên       : {txttensv.Text}");
            sb.AppendLine($"Phòng ở         : {txtphong.Text}");
            sb.AppendLine("");
            sb.AppendLine("---------------- CHI TIẾT THANH TOÁN --------------");

            string thangDong = cobThangdong.SelectedIndex != -1 ? cobThangdong.Text : "Chưa chọn";
            sb.AppendLine($"Nội dung thu    : Tiền phòng + Điện nước {thangDong}");
            sb.AppendLine($"Ngày đóng tiền  : {dateTimeNgayDong.Value.ToString("dd/MM/yyyy")}");
            sb.AppendLine($"Số tiền         : {txtsotien.Text}");

            // Kiểm tra trạng thái đóng tiền
            string trangThai = radiNhanTien.Checked ? "Đã thanh toán" : "Chưa thanh toán";
            sb.AppendLine($"Trạng thái      : {trangThai}");

            sb.AppendLine("");
            sb.AppendLine("===============================================");
            sb.AppendLine("       Người lập phiếu          Người nộp tiền");
            sb.AppendLine("          (Ký tên)                 (Ký tên)");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("===============================================");

            // 3. MỞ HỘP THOẠI LƯU FILE (SaveFileDialog)
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File (*.txt)|*.txt"; // Chỉ cho phép lưu file .txt
            sfd.Title = "Lưu Phiếu Thanh Toán";

            // Đặt tên file mặc định: PhieuThu_MSSV_Ngay.txt
            sfd.FileName = $"PhieuThu_{txtmssv.Text}_{DateTime.Now.ToString("ddMMyyyy")}.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 4. GHI FILE
                    // sfd.FileName chứa đường dẫn đầy đủ mà người dùng đã chọn
                    File.WriteAllText(sfd.FileName, sb.ToString());

                    MessageBox.Show($"Xuất phiếu thành công!\nĐường dẫn: {sfd.FileName}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // (Tùy chọn) Mở file lên xem ngay sau khi lưu
                    // System.Diagnostics.Process.Start("notepad.exe", sfd.FileName);
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
