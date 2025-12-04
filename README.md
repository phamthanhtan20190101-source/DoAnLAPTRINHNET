# 🏠 HỆ THỐNG QUẢN LÝ KÝ TÚC XÁ (Dormitory Management System)

![.NET](https://img.shields.io/badge/.NET-Framework%204.8-purple?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=c-sharp)
![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server)
![WinForms](https://img.shields.io/badge/UI-Windows%20Forms-blue?style=for-the-badge)

> **Đồ án môn học Lập trình .NET**
> Ứng dụng Desktop giúp số hóa quy trình quản lý sinh viên, phòng ở và tài chính tại ký túc xá trường Đại học.

---

## 🚀 Tính Năng Nổi Bật

Hệ thống được phân quyền chi tiết cho **Ban Quản Lý** và **Sinh Viên**.

### 👮‍♂️ Dành cho Quản Lý (Admin)
- **Quản lý Sinh viên:**
  - Thêm, Xóa, Sửa hồ sơ sinh viên.
  - **Tự động gợi ý** phòng còn trống và phù hợp giới tính.
  - Tìm kiếm thông minh (theo MSSV, Tên) và Lọc theo Tòa/Phòng.
- **Quản lý Phòng & Tòa nhà:**
  - **Sơ đồ trực quan (Card View):** Xem trạng thái lấp đầy của từng tòa nhà.
  - **Kiểm soát sức chứa:** Chặn thêm người nếu phòng đã đầy (Logic chặt chẽ).
  - Cập nhật giá phòng, điện nước.
- **Quản lý Tài chính (Quan trọng):**
  - 💰 **Ghi nhận đóng tiền:** Tính tổng tiền tự động (Giá phòng + Điện nước).
  - 🧾 **Xuất phiếu thu:** Xuất hóa đơn ra file `.txt` để in ấn.
  - 🔒 **Giao dịch an toàn:** Sử dụng `SQL Transaction` để đảm bảo dữ liệu tiền bạc không bị sai lệch.

### 👨‍🎓 Dành cho Sinh Viên (User)
- **Tra cứu thông tin:** Xem hồ sơ cá nhân, thông tin phòng đang ở.
- **Lịch sử giao dịch:** Xem lại chi tiết các lần đóng tiền (Ngày đóng, Số tiền) để đối soát.
- **Tiện ích:** Tự đổi Mật khẩu và Cập nhật Số điện thoại liên lạc.

---

## 📸 Hình Ảnh Demo

| **Màn hình Đăng nhập** | **Dashboard Quản lý** |
|:---:|:---:|
| <img width="625" height="436" alt="Ảnh chụp màn hình 2025-11-26 022515" src="https://github.com/user-attachments/assets/8441b400-5306-4d4b-ace8-2b5bf9e1a439" />
 ![Uploading Ảnh chụp màn hình 2025-11-26 022515.png…]()
 | ![Admin](https://via.placeholder.com/400x250?text=Giao+Dien+Quan+Ly) |

| **Sơ đồ Tòa nhà (Card View)** | **Ghi nhận Đóng tiền** |
|:---:|:---:|
| ![ToaNha](https://via.placeholder.com/400x250?text=So+Do+Toa+Nha) | ![Payment](https://via.placeholder.com/400x250?text=Chuc+Nang+Thu+Tien) |

---

## 🛠 Công Nghệ Sử Dụng

| Thành phần | Công nghệ / Kỹ thuật |
| :--- | :--- |
| **Ngôn ngữ** | C# (Visual Studio 2022) |
| **Framework** | .NET Framework (Windows Forms) |
| **Cơ sở dữ liệu** | Microsoft SQL Server |
| **Kết nối dữ liệu** | **ADO.NET** (Mô hình Disconnected & Connected) |
| **Giao diện** | `DataGridView`, `FlowLayoutPanel`, **UserControl** (Tự thiết kế) |
| **Thư viện Icon** | **FontAwesome.Sharp** (NuGet) |
| **Kỹ thuật nâng cao**| `SqlTransaction`, `UserControl`, `Disconnected Architecture` |

---

## ⚙️ Hướng Dẫn Cài Đặt

Để chạy dự án trên máy của bạn, hãy làm theo các bước sau:

### Bước 1: Chuẩn bị Database
1. Mở **SQL Server Management Studio (SSMS)**.
2. Mở file script `Database.sql` (nằm trong thư mục `Database` của dự án).
3. Chạy (**Execute**) để tạo CSDL `QL_KyTucXa01` và các bảng dữ liệu.

### Bước 2: Cấu hình Code
1. Mở dự án bằng **Visual Studio**.
2. Tìm đến file `DatabaseHelper.cs` (hoặc phần khai báo biến ở đầu các Form).
3. Sửa dòng `connectionString` cho đúng với tên máy của bạn:

```csharp
// Thay .\SQLEXPRESS bằng tên máy SQL của bạn
string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QL_KyTucXa01;Integrated Security=True;TrustServerCertificate=True";

### Bước 3: Cài đặt Thư viện
Nếu báo lỗi thiếu thư viện, hãy:
1. Chuột phải vào **Solution** -> chọn **Manage NuGet Packages**.
2. Tìm và cài đặt gói: **`FontAwesome.Sharp`**.
3. Nhấn **Restore** các gói nếu cần.

### Bước 4: Chạy ứng dụng
Nhấn **F5** hoặc nút **Start** 

---

## 📂 Cấu Trúc Dự Án

```text
QLKTX/
├── Database/            # Script tạo CSDL SQL
├── UserControls/        # Các thẻ giao diện tự tạo (UCToaNha, UCPhong)
├── Forms/               
│   ├── Form1.cs         # Quản lý Sinh viên
│   ├── Form2.cs         # Đăng nhập
│   ├── Form4.cs         # Thu phí & Xuất hóa đơn
│   ├── Form5.cs         # Quản lý Phòng
│   └── ...
├── Program.cs           # Điểm khởi chạy ứng dụng
└── README.md            # Tài liệu hướng dẫn

