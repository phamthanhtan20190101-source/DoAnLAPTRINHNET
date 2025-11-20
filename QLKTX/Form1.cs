using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLKTX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=QL_KyTucXa;Integrated Security=True;TrustServerCertificate=True";
        DataSet ds = new DataSet();
        SqlDataAdapter daSinhvien;
        DataTable dt;

        private void Form1_Load(object sender, EventArgs e)
        {

            TaiDuLieuLenDataGird();
            TaiPhongVaoTimKiem();
            this.dataGridDSSV.SelectionChanged += new System.EventHandler(this.dataGridDSSV_SelectionChanged_1);
            this.combtimphong.SelectedIndexChanged += new System.EventHandler(this.combtimphong_SelectedIndexChanged);
            this.cobphai.SelectedIndexChanged += new System.EventHandler(this.cobphai_SelectedIndexChanged);
        }
        // THAY THẾ HÀM NÀY
        private void TaiDuLieuLenDataGird()
        {
            string query = "SELECT * FROM SinhVien";

            try
            {
                // 1. Khởi tạo DataAdapter
                daSinhvien = new SqlDataAdapter(query, connectionString);

                // 2. Tự động tạo lệnh INSERT, UPDATE, DELETE
                SqlCommandBuilder builder = new SqlCommandBuilder(daSinhvien);

                // 3. Khởi tạo DataTable toàn cục
                dt = new DataTable();

                // 4. Đổ TOÀN BỘ dữ liệu vào DataTable
                daSinhvien.Fill(dt);

                // 5. === SỬA LỖI HIỂN THỊ TẠI ĐÂY ===
                // Mặc định, DataView chỉ hiển thị các dòng 'Current'
                // Chúng ta phải CÀI ĐẶT cho nó hiển thị cả các dòng 'Added' (Mới thêm).
                dt.DefaultView.RowStateFilter = DataViewRowState.CurrentRows | DataViewRowState.Added;

                // 6. Gán DataTable làm nguồn
                dataGridDSSV.DataSource = dt;

                // 7. Định dạng cột (Giữ nguyên code của bạn)
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
                dataGridDSSV.Columns["QueQuan"].HeaderText = "Quê Quán";
                dataGridDSSV.Columns["QueQuan"].Width = 130;
                dataGridDSSV.Columns["MaPhong"].HeaderText = "Mã Phòng";
                dataGridDSSV.Columns["MaPhong"].Width = 100;
                dataGridDSSV.Columns["TrangThaiTienPhong"].HeaderText = "Trạng Thái Tiền Phòng";
                dataGridDSSV.Columns["TrangThaiTienPhong"].Width = 140;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnhientatca_Click(object sender, EventArgs e)
        {
            // ấn vào chuyển qua form 3
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (!KiemTraNhapLieu(true))
            {
                return; // Dừng lại nếu kiểm tra thất bại
            }

            // 2. Kiểm tra sức chứa phòng
            if (!KiemTraSucChuaPhong(cobmaphong.Text))
            {
                return; // Dừng lại nếu phòng đã đầy
            }

            // 3. Kiểm tra MSSV đã tồn tại trong DataTable chưa
            if (dt.Select($"MSSV = '{txtMSSV.Text}'").Length > 0)
            {
                MessageBox.Show("MSSV này đã tồn tại trong danh sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 4. Tạo một dòng mới
                DataRow newRow = dt.NewRow();

                // 5. Điền dữ liệu
                newRow["MSSV"] = txtMSSV.Text;
                newRow["HoTen"] = txtHo_Ten.Text;
                newRow["Lop"] = txtLop.Text;
                newRow["SDT"] = txtSDT.Text;
                newRow["GioiTinh"] = cobphai.Text;
                newRow["NgaySinh"] = dateTimeNgaySinh.Value;
                newRow["NgayVao"] = dateTimengayvao.Value;
                newRow["QueQuan"] = txtque.Text;
                newRow["MaPhong"] = cobmaphong.Text;
                newRow["TrangThaiTienPhong"] = "Chưa đóng";

                // 6. Thêm dòng mới vào DataTable
                dt.Rows.Add(newRow);

                // 7. === SỬA LỖI HIỂN THỊ TẠI ĐÂY ===
                // Xóa mọi bộ lọc đang có để đảm bảo hàng mới được hiển thị
                dt.DefaultView.RowFilter = string.Empty;

                // Đồng thời reset các ô tìm kiếm
                combtimphong.SelectedIndex = 0; // Đặt về "--- Tất cả ---"
                textBox16.Text = ""; // Xóa text tìm kiếm

                // 8. Xóa trắng các ô nhập liệu
                XoaTrangTextBoxes();

                // 9. Tải lại danh sách phòng (logic này vẫn đúng)
                TaiPhongTheoGioiTinh(cobphai.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sinh viên vào danh sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private bool KiemTraNhapLieu(bool kiemTraMSSV = true)
        {
            if (string.IsNullOrWhiteSpace(txtHo_Ten.Text) ||
         string.IsNullOrWhiteSpace(txtLop.Text) ||
         string.IsNullOrWhiteSpace(txtSDT.Text) ||
         string.IsNullOrWhiteSpace(cobphai.Text) ||
         string.IsNullOrWhiteSpace(txtque.Text) ||
         string.IsNullOrWhiteSpace(cobmaphong.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ tất cả thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Chỉ kiểm tra MSSV khi 'kiemTraMSSV' là true
            if (kiemTraMSSV)
            {
                if (string.IsNullOrWhiteSpace(txtMSSV.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ MSSV.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (!Regex.IsMatch(txtMSSV.Text, @"^SV[0-9]{3}$"))
                {
                    MessageBox.Show("MSSV phải có định dạng 'SV' theo sau là 3 chữ số (ví dụ: SV001).", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMSSV.Focus();
                    return false;
                }
            }

            // (Các kiểm tra còn lại)
            if (!Regex.IsMatch(txtSDT.Text, @"^0[0-9]{9}$"))
            {
                MessageBox.Show("Số điện thoại phải bắt đầu bằng 0 và có đúng 10 chữ số.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            if (dateTimeNgaySinh.Value > dateTimengayvao.Value)
            {
                MessageBox.Show("Ngày sinh không thể muộn hơn ngày vào.", "Lỗi logic", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // === SỬA LỖI Ở ĐÂY ===
            // Nếu tất cả các kiểm tra ở trên đều VƯỢT QUA (không có lỗi)
            // chúng ta phải trả về 'true' để báo là nhập liệu hợp lệ.
            return true;
        }

        private void TaiPhongTheoGioiTinh(string gioiTinh)
        {
            cobmaphong.Items.Clear(); // Xóa danh sách phòng cũ
            cobmaphong.Text = "";     // Reset lựa chọn

            string dieuKienToaNha = "";
            if (gioiTinh == "Nam")
            {
                // Ràng buộc 1: Nam chỉ ở tòa A, C
                dieuKienToaNha = "T.MaToaNha IN ('A', 'C')";
            }
            else if (gioiTinh == "Nữ")
            {
                // Ràng buộc 2: Nữ chỉ ở tòa B, D
                dieuKienToaNha = "T.MaToaNha IN ('B', 'D')";
            }
            else
            {
                return; // Chưa chọn giới tính, không tải gì cả
            }

            // Ràng buộc 3: Chỉ tải phòng "Trống"
            string query = $@"
        SELECT P.MaPhong 
        FROM Phong P
        JOIN ToaNha T ON P.MaToaNha = T.MaToaNha
        WHERE 
            P.TrangThai = N'Trống' 
            AND {dieuKienToaNha}
        ORDER BY P.MaPhong";

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
                            cobmaphong.Items.Add(reader["MaPhong"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách phòng: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cobphai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobphai.SelectedItem != null)
            {
                string gioiTinhDaChon = cobphai.Text;
                // Gọi hàm lọc phòng mới
                TaiPhongTheoGioiTinh(gioiTinhDaChon);
            }
        }


        private bool KiemTraSucChuaPhong(string maPhong)
        {
            int soLuongToiDa = 0;
            int soLuongHienTai = 0; // Sẽ đếm trong DataTable

            try
            {
                // 1. Lấy số lượng tối đa (4 hay 6) từ CSDL (Phần này vẫn đúng)
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string queryLoaiPhong = "SELECT LoaiPhong FROM Phong WHERE MaPhong = @MaPhong";
                    using (SqlCommand cmdA = new SqlCommand(queryLoaiPhong, conn))
                    {
                        cmdA.Parameters.AddWithValue("@MaPhong", maPhong);
                        object result = cmdA.ExecuteScalar();

                        if (result != null)
                        {
                            if (result.ToString() == "4 người") soLuongToiDa = 4;
                            else if (result.ToString() == "6 người") soLuongToiDa = 6;
                        }
                        else
                        {
                            MessageBox.Show("Mã phòng không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }

                // 2. === SỬA LỖI Ở ĐÂY ===
                // Đếm số sinh viên HIỆN TẠI có trong DataTable (dt)
                // (Bao gồm cả sinh viên cũ từ CSDL và sinh viên mới thêm vào)
                foreach (DataRow row in dt.Rows)
                {
                    // Chỉ đếm các dòng chưa bị xóa và có cùng mã phòng
                    if (row.RowState != DataRowState.Deleted && row["MaPhong"].ToString() == maPhong)
                    {
                        soLuongHienTai++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra sức chứa phòng: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // 3. So sánh
            if (soLuongHienTai >= soLuongToiDa)
            {
                MessageBox.Show($"Phòng {maPhong} đã đầy (Tối đa {soLuongToiDa} sinh viên).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; // Hết chỗ
            }

            return true; // Còn chỗ
        }


        private void XoaTrangTextBoxes()
        {
            txtMSSV.Text = "";
            txtHo_Ten.Text = "";
            txtLop.Text = "";
            txtSDT.Text = "";
            cobphai.SelectedIndex = -1; // Xóa lựa chọn ComboBox Giới tính
            txtque.Text = "";

            // SỬA LẠI CHO cobmaphong
            cobmaphong.Items.Clear(); // Xóa danh sách phòng đã lọc
            cobmaphong.Text = "";     // Xóa phòng đã chọn

            dateTimeNgaySinh.Value = DateTime.Now;
            dateTimengayvao.Value = DateTime.Now;
        }


        private void btnluu_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Dùng DataAdapter toàn cục để Cập nhật CSDL
                // (Hàm này sẽ tự động chạy lệnh INSERT cho các dòng mới)
                daSinhvien.Update(dt);

                // 2. Đồng bộ lại DataTable, đánh dấu các dòng là đã lưu
                dt.AcceptChanges();

                MessageBox.Show("Lưu vào cơ sở dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu vào CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // (Tùy chọn) Nếu lưu thất bại, hủy các thay đổi
                // dt.RejectChanges(); 
            }
        }
        // 1. Kiểm tra nhập liệu cơ bản (rỗng, định dạng MSSV, SĐT)



        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (dataGridDSSV.SelectedRows.Count > 0)
            {
                string mssvCanXoa = dataGridDSSV.SelectedRows[0].Cells["MSSV"].Value.ToString();
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sinh viên MSSV: {mssvCanXoa}?\n(Hành động sẽ được lưu khi bạn nhấn 'Lưu')", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                       
                        // 1. Tìm dòng (DataRow) trong DataTable (dt)
                        DataRow[] rowsToDelete = dt.Select($"MSSV = '{mssvCanXoa}'");

                        if (rowsToDelete.Length > 0)
                        {
                            // 2. Đánh dấu dòng này để xóa (KHÔNG xóa trực tiếp)
                            rowsToDelete[0].Delete();

                            // 3. (Tùy chọn) Cập nhật DataTable
                            // dt.AcceptChanges(); // Không AcceptChanges ở đây, hãy để nút Lưu làm
                            MessageBox.Show("Đã xóa sinh viên khỏi danh sách. \nHãy nhấn 'Lưu' để cập nhật CSDL.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa sinh viên khỏi danh sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }




        private void dataGridDSSV_SelectionChanged_1(object sender, EventArgs e)
        {

            if (dataGridDSSV.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridDSSV.SelectedRows[0];
                txtMSSV.Text = selectedRow.Cells["MSSV"].Value.ToString();
                txtHo_Ten.Text = selectedRow.Cells["HoTen"].Value.ToString();
                txtLop.Text = selectedRow.Cells["Lop"].Value.ToString();
                txtSDT.Text = selectedRow.Cells["SDT"].Value.ToString();
                cobphai.Text = selectedRow.Cells["GioiTinh"].Value.ToString();
                dateTimeNgaySinh.Value = Convert.ToDateTime(selectedRow.Cells["NgaySinh"].Value);
                dateTimengayvao.Value = Convert.ToDateTime(selectedRow.Cells["NgayVao"].Value);
                txtque.Text = selectedRow.Cells["QueQuan"].Value.ToString();
                cobmaphong.Text = selectedRow.Cells["MaPhong"].Value.ToString();
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {

            // Sửa thông tin sinh viên đã chọn trong datagridview không thêm mới 
            if (dataGridDSSV.SelectedRows.Count > 0)
            {
                // 1. Kiểm tra nhập liệu (trừ MSSV vì không sửa MSSV)
                if (!KiemTraNhapLieu(false)) // Truyền 'false' để báo là không kiểm tra MSSV
                {
                    return;
                }

                // 2. Lấy dòng đang chọn
                DataGridViewRow selectedRow = dataGridDSSV.SelectedRows[0];
                string mssvCanSua = selectedRow.Cells["MSSV"].Value.ToString();

                // 3. Kiểm tra xem MSSV trong TextBox có khớp với MSSV đang chọn không
                //    (Để tránh sửa nhầm)
                if (txtMSSV.Text != mssvCanSua)
                {
                    MessageBox.Show("Bạn không thể sửa MSSV. Dữ liệu trong các ô không khớp với sinh viên đang chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 4. Tìm dòng (DataRow) trong DataTable (dt)
                DataRow[] rowsToUpdate = dt.Select($"MSSV = '{mssvCanSua}'");
                if (rowsToUpdate.Length > 0)
                {
                    DataRow row = rowsToUpdate[0];

                    // 5. Cập nhật dữ liệu TỪ TextBox VÀO DataRow
                    row["HoTen"] = txtHo_Ten.Text;
                    row["Lop"] = txtLop.Text;
                    row["SDT"] = txtSDT.Text;
                    row["GioiTinh"] = cobphai.Text;
                    row["NgaySinh"] = dateTimeNgaySinh.Value;
                    row["NgayVao"] = dateTimengayvao.Value;
                    row["QueQuan"] = txtque.Text;
                    row["MaPhong"] = cobmaphong.Text;
                    // (Không sửa TrangThaiTienPhong ở đây)

                    MessageBox.Show("Sửa thông tin sinh viên thành công (trên Grid).\nHãy nhấn 'Lưu' để cập nhật CSDL.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            // Hủy các thay đổi chưa lưu trong DataTable hỏi người dùng trước
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy tất cả các thay đổi chưa lưu không?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                dt.RejectChanges();
            MessageBox.Show("Đã hủy các thay đổi chưa lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void combtimphong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combtimphong.SelectedIndex == -1)
            {
                return; // Không làm gì nếu chưa chọn
            }

            // 1. KIỂM TRA NẾU CHỌN "TẤT CẢ"
            if (combtimphong.SelectedIndex == 0) // (Giả sử 0 là "--- Tất cả ---")
            {
                // Xóa bộ lọc, hiển thị lại tất cả sinh viên
                dt.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                // 2. NẾU CHỌN PHÒNG CỤ THỂ
                string maPhongCanLoc = combtimphong.Text;

                // 3. Áp dụng bộ lọc vào DataTable (DataGridView sẽ tự động cập nhật)
                dt.DefaultView.RowFilter = $"MaPhong = '{maPhongCanLoc}'";

                // 4. KIỂM TRA KẾT QUẢ (YÊU CẦU CỦA BẠN)
              
                if (dt.DefaultView.Count == 0)
                {
                    // Nếu không có sinh viên nào, hiển thị thông báo
                    MessageBox.Show($"Không có sinh viên nào trong phòng {maPhongCanLoc}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                    // dt.DefaultView.RowFilter = string.Empty;
                }
            }

        }
        private void TaiPhongVaoTimKiem()
        {
            combtimphong.Items.Clear();

            // === THÊM DÒNG NÀY ĐỂ SỬA LỖI LỌC ===
            combtimphong.Items.Add("--- Tất cả ---"); // Mục để xóa bộ lọc

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
                // Dòng này bây giờ sẽ chọn "--- Tất cả ---" làm mặc định
                combtimphong.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách phòng tìm kiếm: " + ex.Message);
            }
        }
    }
}
    
    
    

