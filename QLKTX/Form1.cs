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
        //string connectionString = @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=QL_KyTucXa;Integrated Security=True;TrustServerCertificate=True";
        string connectionString = @"Data Source=LAPTOP-40KODIPL\SQLEXPRESS;Initial Catalog=QL_KyTucXa01;Integrated Security=True;TrustServerCertificate=True";
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
                return; 
            }

            
            if (!KiemTraSucChuaPhong(cobmaphong.Text))
            {
                return; 
            }

            
            if (dt.Select($"MSSV = '{txtMSSV.Text}'").Length > 0)
            {
                MessageBox.Show("MSSV này đã tồn tại trong danh sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                
                DataRow newRow = dt.NewRow();

                
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

                
                dt.Rows.Add(newRow);

               
                dt.DefaultView.RowFilter = string.Empty;

                combtimphong.SelectedIndex = 0;
                txtTimKiem.Text = "";

                XoaTrangTextBoxes();


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

            return true;
        }

        private void TaiPhongTheoGioiTinh(string gioiTinh)
        {
            cobmaphong.Items.Clear(); 
            cobmaphong.Text = "";     

            string dieuKienToaNha = "";
            if (gioiTinh == "Nam")
            {
                
                dieuKienToaNha = "T.MaToaNha IN ('A', 'C')";
            }
            else if (gioiTinh == "Nữ")
            {
                
                dieuKienToaNha = "T.MaToaNha IN ('B', 'D')";
            }
            else
            {
                return; 
            }

            
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
                
                TaiPhongTheoGioiTinh(gioiTinhDaChon);
            }
        }


        private bool KiemTraSucChuaPhong(string maPhong)
        {
            int soLuongToiDa = 0;
            int soLuongHienTai = 0; 

            try
            {
                
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

                foreach (DataRow row in dt.Rows)
                {
                    
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

            
            if (soLuongHienTai >= soLuongToiDa)
            {
                MessageBox.Show($"Phòng {maPhong} đã đầy (Tối đa {soLuongToiDa} sinh viên).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; 
            }

            return true;
        }


        private void XoaTrangTextBoxes()
        {
            txtMSSV.Text = "";
            txtHo_Ten.Text = "";
            txtLop.Text = "";
            txtSDT.Text = "";
            cobphai.SelectedIndex = -1;
            txtque.Text = "";
            cobmaphong.Items.Clear(); 
            cobmaphong.Text = "";     

            dateTimeNgaySinh.Value = DateTime.Now;
            dateTimengayvao.Value = DateTime.Now;
        }


        private void btnluu_Click(object sender, EventArgs e)
        {
            try
            {
                daSinhvien.Update(dt);
                dt.AcceptChanges();

                MessageBox.Show("Lưu vào cơ sở dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu vào CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



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
                       
                       
                        DataRow[] rowsToDelete = dt.Select($"MSSV = '{mssvCanXoa}'");

                        if (rowsToDelete.Length > 0)
                        {
                            
                            rowsToDelete[0].Delete();

                            
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

            
            if (dataGridDSSV.SelectedRows.Count > 0)
            {
                if (!KiemTraNhapLieu(false)) 
                {
                    return;
                }

                DataGridViewRow selectedRow = dataGridDSSV.SelectedRows[0];
                string mssvCanSua = selectedRow.Cells["MSSV"].Value.ToString();

                if (txtMSSV.Text != mssvCanSua)
                {
                    MessageBox.Show("Bạn không thể sửa MSSV. Dữ liệu trong các ô không khớp với sinh viên đang chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataRow[] rowsToUpdate = dt.Select($"MSSV = '{mssvCanSua}'");
                if (rowsToUpdate.Length > 0)
                {
                    DataRow row = rowsToUpdate[0];

                    row["HoTen"] = txtHo_Ten.Text;
                    row["Lop"] = txtLop.Text;
                    row["SDT"] = txtSDT.Text;
                    row["GioiTinh"] = cobphai.Text;
                    row["NgaySinh"] = dateTimeNgaySinh.Value;
                    row["NgayVao"] = dateTimengayvao.Value;
                    row["QueQuan"] = txtque.Text;
                    row["MaPhong"] = cobmaphong.Text;

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
                return;
            }


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
                    dt.DefaultView.RowFilter = string.Empty;
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

        private void btnghinhan_Click(object sender, EventArgs e)
        {
            // mở form 4 
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();


        }

        private void btndangxuat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                this.Hide();
                Form2 frm2 = new Form2();
                frm2.Show();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 f5= new Form5();
            f5.Show();
            this.Hide();
        }

       
    }
}
    
    
    

