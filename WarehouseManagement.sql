-- ==========================
-- FILE: Database Script - Full Schema + Stored Procedures
-- DESCRIPTION: CSDL cho hệ thống quản lý kho
-- ==========================

-- === PHẦN TẠO BẢNG ===
CREATE TABLE Locations (
    LocationID INT IDENTITY(1,1) PRIMARY KEY,
    LocationName VARCHAR(255) NOT NULL,
    Area VARCHAR(255)
);
GO

CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeName VARCHAR(255) NOT NULL,
    Role VARCHAR(50) NOT NULL,
    Email VARCHAR(255) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL
);
GO

CREATE TABLE Customers (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName VARCHAR(255) NOT NULL,
    Address VARCHAR(255),
    Phone VARCHAR(50)
);
GO

CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(255) NOT NULL,
    Category VARCHAR(255),
    Unit VARCHAR(100),
    Quantity INT DEFAULT 0,
    MinQuantity INT DEFAULT 0,
    LocationID INT NULL,
    CONSTRAINT FK_Products_Locations FOREIGN KEY (LocationID)
        REFERENCES Locations(LocationID)
        ON DELETE SET NULL
);
GO

CREATE TABLE Imports (
    ImportID INT IDENTITY(1,1) PRIMARY KEY,
    ImportDate DATE NOT NULL,
    EmployeeID INT NULL,
    Supplier VARCHAR(255),
    CONSTRAINT FK_Imports_Employees FOREIGN KEY (EmployeeID)
        REFERENCES Employees(EmployeeID)
        ON DELETE SET NULL
);
GO

CREATE TABLE ImportDetails (
    ImportDetailID INT IDENTITY(1,1) PRIMARY KEY,
    ImportID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_ImportDetails_Imports FOREIGN KEY (ImportID)
        REFERENCES Imports(ImportID) ON DELETE CASCADE,
    CONSTRAINT FK_ImportDetails_Products FOREIGN KEY (ProductID)
        REFERENCES Products(ProductID) ON DELETE CASCADE
);
GO

CREATE TABLE Exports (
    ExportID INT IDENTITY(1,1) PRIMARY KEY,
    ExportDate DATE NOT NULL,
    CustomerID INT NULL,
    EmployeeID INT NULL,
    TotalAmount DECIMAL(10,2) DEFAULT 0,
    CONSTRAINT FK_Exports_Customers FOREIGN KEY (CustomerID)
        REFERENCES Customers(CustomerID) ON DELETE SET NULL,
    CONSTRAINT FK_Exports_Employees FOREIGN KEY (EmployeeID)
        REFERENCES Employees(EmployeeID) ON DELETE SET NULL
);
GO

CREATE TABLE ExportDetails (
    ExportDetailID INT IDENTITY(1,1) PRIMARY KEY,
    ExportID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_ExportDetails_Exports FOREIGN KEY (ExportID)
        REFERENCES Exports(ExportID) ON DELETE CASCADE,
    CONSTRAINT FK_ExportDetails_Products FOREIGN KEY (ProductID)
        REFERENCES Products(ProductID) ON DELETE CASCADE
);
GO

CREATE TABLE Invoices (
    InvoiceID INT IDENTITY(1,1) PRIMARY KEY,
    InvoiceDate DATE NOT NULL,
    CustomerID INT NULL,
    ExportID INT NULL,
    TotalAmount DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_Invoices_Customers FOREIGN KEY (CustomerID)
        REFERENCES Customers(CustomerID) ON DELETE SET NULL,
    CONSTRAINT FK_Invoices_Exports FOREIGN KEY (ExportID)
        REFERENCES Exports(ExportID) ON DELETE SET NULL
);
GO

CREATE TABLE MaterialsToImport (
    MaterialID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    Status VARCHAR(50) NOT NULL,
    CONSTRAINT FK_MaterialsToImport_Products FOREIGN KEY (ProductID)
        REFERENCES Products(ProductID) ON DELETE CASCADE
);
GO

CREATE TABLE RejectedMaterials (
    RejectedMaterialID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    Reason VARCHAR(255),
    CONSTRAINT FK_RejectedMaterials_Products FOREIGN KEY (ProductID)
        REFERENCES Products(ProductID) ON DELETE CASCADE
);
GO

CREATE TABLE ActivityLogs (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeID INT NULL,
    Activity VARCHAR(255) NOT NULL,
    Timestamp DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_ActivityLogs_Employees FOREIGN KEY (EmployeeID)
        REFERENCES Employees(EmployeeID) ON DELETE SET NULL
);
GO

CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Role NVARCHAR(50) NOT NULL CHECK(Role IN ('Admin', 'Staff', 'Viewer'))
);
GO

CREATE TABLE Permissions (
    PermissionID INT PRIMARY KEY IDENTITY(1,1),
    Role NVARCHAR(50) NOT NULL,
    CanView BIT DEFAULT 1,
    CanEdit BIT DEFAULT 0,
    CanDelete BIT DEFAULT 0
);
GO

-- === PHẦN PROCEDURE ===

CREATE OR ALTER PROCEDURE usp_GetAllImports
AS
BEGIN
  SELECT ImportID, ImportDate, EmployeeID, Supplier FROM Imports;
END
GO

CREATE OR ALTER PROCEDURE usp_GetImportDetails @ImportID INT
AS
BEGIN
  SELECT d.ImportDetailID, d.ProductID, p.ProductName, d.Quantity, d.Price
  FROM ImportDetails d
  JOIN Products p ON p.ProductID = d.ProductID
  WHERE d.ImportID = @ImportID;
END
GO

CREATE OR ALTER PROCEDURE usp_InsertImport
  @ImportDate DATE,
  @EmployeeID INT = NULL,
  @Supplier VARCHAR(255)
AS
BEGIN
  INSERT INTO Imports (ImportDate, EmployeeID, Supplier)
  VALUES (@ImportDate, @EmployeeID, @Supplier);
  SELECT SCOPE_IDENTITY() AS NewImportID;
END
GO

CREATE OR ALTER PROCEDURE usp_UpdateImport
  @ImportID INT,
  @ImportDate DATE,
  @EmployeeID INT = NULL,
  @Supplier VARCHAR(255)
AS
BEGIN
  UPDATE Imports
  SET ImportDate = @ImportDate,
      EmployeeID = @EmployeeID,
      Supplier   = @Supplier
  WHERE ImportID = @ImportID;
END
GO

CREATE OR ALTER PROCEDURE usp_DeleteImport @ImportID INT
AS
BEGIN
  DELETE FROM Imports WHERE ImportID = @ImportID;
END
GO

CREATE OR ALTER PROCEDURE usp_AddImportDetail
  @ImportID INT,
  @ProductID INT,
  @Quantity INT,
  @Price DECIMAL(10,2)
AS
BEGIN
  INSERT INTO ImportDetails (ImportID, ProductID, Quantity, Price)
  VALUES (@ImportID, @ProductID, @Quantity, @Price);
END
GO

ALTER PROCEDURE usp_CheckLogin
@Username NVARCHAR(50),
@Password NVARCHAR(255)
AS
BEGIN
    SELECT UserID, FullName, Role
    FROM Users
    WHERE Username = @Username AND PasswordHash = CONVERT(VARCHAR(255), HASHBYTES('SHA2_256', @Password), 2);
END
GO

CREATE OR ALTER PROCEDURE usp_AddUser
  @Username NVARCHAR(50),
  @Password NVARCHAR(255),
  @FullName NVARCHAR(100),
  @Role NVARCHAR(50)
AS
BEGIN
  INSERT INTO Users (Username, PasswordHash, FullName, Role)
  VALUES (@Username, HASHBYTES('SHA2_256', @Password), @FullName, @Role);
END
GO

CREATE OR ALTER PROCEDURE usp_GetPermissions @Role NVARCHAR(50)
AS
BEGIN
  SELECT CanView, CanEdit, CanDelete FROM Permissions WHERE Role = @Role;
END
GO

CREATE OR ALTER PROCEDURE usp_GetUsers
AS
BEGIN
  SELECT UserID, Username, FullName, Role FROM Users;
END
GO

CREATE OR ALTER PROCEDURE usp_GetExports
AS
BEGIN
  SELECT e.ExportID, e.ExportDate, c.CustomerName, e.TotalAmount
  FROM Exports e
  JOIN Customers c ON e.CustomerID = c.CustomerID;
END
GO

CREATE OR ALTER PROCEDURE usp_GetExportDetails @ExportID INT
AS
BEGIN
  SELECT d.ExportDetailID, p.ProductName, d.Quantity, d.Price
  FROM ExportDetails d
  JOIN Products p ON d.ProductID = p.ProductID
  WHERE d.ExportID = @ExportID;
END
GO

CREATE OR ALTER PROCEDURE usp_AddExport
  @ExportDate DATE,
  @CustomerID INT
AS
BEGIN
  INSERT INTO Exports (ExportDate, CustomerID, TotalAmount)
  VALUES (@ExportDate, @CustomerID, 0);
  SELECT SCOPE_IDENTITY() AS NewExportID;
END
GO

CREATE OR ALTER PROCEDURE usp_UpdateTotalAmount @ExportID INT
AS
BEGIN
  UPDATE Exports
  SET TotalAmount = (
    SELECT SUM(Quantity * Price)
    FROM ExportDetails
    WHERE ExportID = @ExportID
  )
  WHERE ExportID = @ExportID;
END
GO

--datamau
-- Tạo 1 người dùng Admin
INSERT INTO Users (Username, PasswordHash, FullName, Role)
VALUES (
    'admin', 
    HASHBYTES('SHA2_256', '123456'),  -- Mật khẩu: 123456
    N'Nguyễn Văn Admin', 
    'Admin'
);

-- Tạo 1 người dùng Nhân viên
INSERT INTO Users (Username, PasswordHash, FullName, Role)
VALUES (
    'staff1', 
    HASHBYTES('SHA2_256', 'staff123'),  -- Mật khẩu: staff123
    N'Nguyễn Thị Nhân Viên', 
    'Staff'
);
go
UPDATE Users
SET PasswordHash = HASHBYTES('SHA2_256', 'new_password'),
    FullName = N'Nguyễn Văn Admin',
    Role = 'Admin'
WHERE Username = 'admin';

go
--cap nhat procedủe de chuyen ve mat khau cung 1 dang
CREATE OR ALTER PROCEDURE usp_AddUser
  @Username NVARCHAR(50),
  @Password NVARCHAR(255),
  @FullName NVARCHAR(100),
  @Role NVARCHAR(50)
AS
BEGIN
  -- Sử dụng HASHBYTES để băm mật khẩu với SHA2_256 và chuyển sang dạng hex (mã hóa đơn giản)
  INSERT INTO Users (Username, PasswordHash, FullName, Role)
  VALUES (@Username, CONVERT(VARCHAR(255), HASHBYTES('SHA2_256', @Password), 2), @FullName, @Role);
END
GO

CREATE OR ALTER PROCEDURE usp_CheckLogin
  @Username NVARCHAR(50),
  @Password NVARCHAR(255)
AS
BEGIN
  SELECT UserID, FullName, Role
  FROM Users
  WHERE Username = @Username 
    AND PasswordHash = CONVERT(VARCHAR(255), HASHBYTES('SHA2_256', @Password), 2);
END
GO

--xoa tai khoan admin
DELETE FROM Users WHERE Username = 'admin';
GO

INSERT INTO Users (Username, PasswordHash, FullName, Role)
VALUES (
    'admin', 
    CONVERT(VARCHAR(255), HASHBYTES('SHA2_256', '123456'), 2), -- Mật khẩu mới: 123456
    N'Nguyễn Văn Admin', 
    'Admin'
);
GO

EXEC usp_AddUser 
     @Username = 'admin', 
     @Password = '123456', 
     @FullName = N'Nguyễn Văn Admin', 
     @Role = 'Admin';
GO

CREATE OR ALTER PROCEDURE usp_AddUser
  @Username NVARCHAR(50),
  @Password NVARCHAR(255),
  @FullName NVARCHAR(100),
  @Role NVARCHAR(50)
AS
BEGIN
  INSERT INTO Users (Username, PasswordHash, FullName, Role)
  VALUES (
    @Username, 
    CONVERT(VARCHAR(255), HASHBYTES('SHA2_256', CONCAT('KhoWarehouse123', @Password)), 2), 
    @FullName, 
    @Role
  );
END
GO

CREATE OR ALTER PROCEDURE usp_CheckLogin
  @Username NVARCHAR(50),
  @Password NVARCHAR(255)
AS
BEGIN
  SELECT UserID, FullName, Role
  FROM Users
  WHERE Username = @Username 
    AND PasswordHash = CONVERT(VARCHAR(255), HASHBYTES('SHA2_256', CONCAT('KhoWarehouse123', @Password)), 2);
END
GO

EXEC usp_AddUser 
    @Username = 'admin',
    @Password = '123456',
    @FullName = N'Nguyễn Văn Admin',
    @Role = 'Admin';
GO

EXEC usp_AddUser 
      @Username = 'admin', 
      @Password = '123456', 
      @FullName = N'Nguyễn Văn Admin', 
      @Role = 'Admin';
GO

--tao procedure cho thống kê
-- Procedure lấy danh sách toàn bộ sản phẩm
CREATE OR ALTER PROCEDURE usp_GetProducts
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        ProductID, 
        ProductName, 
        Category, 
        Unit, 
        Quantity, 
        MinQuantity, 
        LocationID
    FROM dbo.Products;
END
GO

-- Procedure lấy danh sách sản phẩm đang có số lượng thấp (ví dụ: số lượng <= minQuantity)
CREATE OR ALTER PROCEDURE usp_GetLowStockProducts
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        ProductID, 
        ProductName, 
        Category, 
        Unit, 
        Quantity, 
        MinQuantity, 
        LocationID
    FROM dbo.Products
    WHERE Quantity <= MinQuantity;
END
GO

CREATE OR ALTER PROCEDURE usp_SearchProducts
    @Keyword NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        ProductID, 
        ProductName, 
        Category, 
        Unit, 
        Quantity, 
        MinQuantity, 
        LocationID
    FROM dbo.Products
    WHERE ProductName LIKE '%' + @Keyword + '%'
       OR Category LIKE '%' + @Keyword + '%';
END
GO

--tim kiem nguoi dung
CREATE OR ALTER PROCEDURE usp_SearchUsers
    @Keyword NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        UserID,
        Username,
        FullName,
        Role
		PasswordHash
    FROM dbo.Users
    WHERE 
        Username LIKE '%' + @Keyword + '%'
        OR FullName LIKE '%' + @Keyword + '%';
        
END
GO

--tao procedure lay danh sach nguoi dung
CREATE PROCEDURE usp_GetExports
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        ExportID,
        ExportDate,
        CustomerID
    FROM dbo.Exports
    ORDER BY ExportDate DESC;
END
go

--tao procedure nhap hang
CREATE PROCEDURE usp_GetImports
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        ImportID,
        ImportDate,
        Supplier
    FROM dbo.Imports
    ORDER BY ImportDate DESC;
END
go

--procedure xem san pham ton kho thap
CREATE OR ALTER PROCEDURE usp_GetLowStockProducts
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ProductName, Quantity, Category, Unit, MinQuantity
    FROM Products
    WHERE MinQuantity < 5;
END;