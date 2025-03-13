# LapTrinhUngDung
Đồ án môn học Lớp K68CNTTD
Thành viên nhóm: 
  + Đặng Dương Huy
  + Ngô Trường Giang
  + Nguyễn Quang Hào
  + Phan Minh Đức
  + Dương Doãn Hiển

====================
# QuanLyVatTuKhoHang

## 1. Giới thiệu
Đây là hệ thống quản lý vật tư kho hàng, giúp theo dõi thông tin nhập - xuất hàng hóa, nhân viên, khách hàng và hóa đơn. Hệ thống được xây dựng trên nền tảng C# và SQL Server.

## 2. Cấu trúc thư mục
```
QuanLyVatTuKhoHang/
│── QuanLyVatTuKhoHang.sln           # Solution file
│
├── QuanLyVatTuKhoHang/              # Main project folder
│   │── Program.cs                    # Entry point của ứng dụng
│   │── App.config                     # Cấu hình kết nối database (nếu dùng)
│   │
│   ├── Database/                      # Quản lý truy vấn cơ sở dữ liệu
│   │   ├── Connection.cs              # Quản lý kết nối SQL Server
│   │   ├── Modify.cs                  # Truy vấn dữ liệu từ database
│   │
│   ├── Models/                        # Mô hình dữ liệu (Entities)
│   │   ├── Employee.cs                # Lớp Employee
│   │   ├── Product.cs                 # Lớp Product
│   │   ├── Customer.cs                # Lớp Customer
│   │
│   ├── Auth/                          # Xử lý xác thực
│   │   ├── AuthManager.cs             # Xác thực tài khoản người dùng
│   │
│   ├── UI/                            # Giao diện người dùng
│   │   ├── Forms/                     # Form Windows Forms/WPF
│   │   │   ├── LoginForm.cs           # Form đăng nhập
│   │   │   ├── MainForm.cs            # Form chính
│   │   │   ├── EmployeeForm.cs        # Quản lý nhân viên
│   │   │   ├── ProductForm.cs         # Quản lý sản phẩm
│   │
│   ├── Controllers/                   # Xử lý logic giữa UI và Database
│   │   ├── EmployeeController.cs      # Quản lý nhân viên
│   │   ├── ProductController.cs       # Quản lý sản phẩm
│   │   ├── InventoryController.cs     # Quản lý kho hàng
│   │
│   ├── Utils/                         # Tiện ích chung
│   │   ├── Logger.cs                  # Ghi log hệ thống
│   │   ├── Validator.cs               # Kiểm tra dữ liệu đầu vào
│   │
│   ├── Resources/                     # Chứa hình ảnh, icon
│   │   ├── logo.png                   
│   │   ├── background.jpg             
│   │
│   ├── Properties/                    # Chứa các file resource tự động của C#
│   ├── bin/                           # Output sau khi build
│   ├── obj/                           # File trung gian khi build
│
└── README.md                          # Hướng dẫn sử dụng
```

## 3. Hướng dẫn sử dụng
### 3.1. Cài đặt môi trường
- Yêu cầu hệ thống:
  - Windows 10/11
  - .NET Framework 4.7+ hoặc .NET Core 6+
  - SQL Server 2019 hoặc mới hơn
  - Visual Studio 2022 hoặc cao hơn

### 3.2. Cấu hình cơ sở dữ liệu
1. Mở SQL Server Management Studio (SSMS).
2. Tạo database mới (ví dụ: `WarehouseDB`).
3. Thực thi file SQL tạo bảng và dữ liệu mẫu.
4. Cập nhật chuỗi kết nối trong `App.config`:
   ```xml
   <connectionStrings>
       <add name="DBConnection" connectionString="Server=YOUR_SERVER;Database=WarehouseDB;Integrated Security=True;" providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```

### 3.3. Chạy ứng dụng
1. Mở `QuanLyVatTuKhoHang.sln` bằng Visual Studio.
2. Build và chạy chương trình (`Ctrl + F5`).
3. Đăng nhập bằng tài khoản admin hoặc tạo mới tài khoản nhân viên.

### 3.4. Chức năng chính
- **Quản lý nhân viên**: Thêm, sửa, xóa nhân viên.
- **Quản lý hàng hóa**: Theo dõi số lượng tồn kho, nhập và xuất hàng.
- **Quản lý khách hàng**: Cập nhật thông tin khách hàng.
- **Lập hóa đơn**: Tạo hóa đơn xuất hàng.
- **Xác thực tài khoản**: Đăng nhập với quyền admin hoặc nhân viên.

## 4. Liên hệ & Hỗ trợ
Nếu có bất kỳ vấn đề nào, vui lòng liên hệ nhóm phát triển qua email: `dhuy110399@gmail.com`.

---
📌 **Lưu ý:** Hãy đảm bảo bạn có quyền truy cập SQL Server trước khi chạy ứng dụng.

