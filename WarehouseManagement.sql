--1. Bang kho
CREATE TABLE Locations(
	LocationID INT IDENTITY(1,1) PRIMARY KEY,
	LocationName VARCHAR(255) NOT NULL,
	Area VARCHAR(255)
);
GO

--2. Bang nhan vien
CREATE TABLE Employees(
	EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
	EmployeeName VARCHAR(255) NOT NULL,
	Role VARCHAR(50) NOT NULL,
	Email VARCHAR(255) NOT NULL UNIQUE,
	Password VARCHAR(255) NOT NULL
);
GO

--3. Bang khach hang
CREATE TABLE Customers(
	CustomerID INT IDENTITY(1,1) PRIMARY KEY,
	CustomerName VARCHAR(255) NOT NULL,
	Address VARCHAR(255),
	Phone VARCHAR(50)
);
GO

--4. Bang hang hoa
CREATE TABLE Products(
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

--5. Bang nhap hang
CREATE TABLE Imports(
	ImportID INT IDENTITY(1,1) PRIMARY KEY,
	ImportDate DATE NOT NULL,
	EmployeeID INT NULL,
	Supplier VARCHAR(255),
	CONSTRAINT FK_Imports_Employees FOREIGN KEY (EmployeeID)
		REFERENCES Employees(EmployeeID)
		ON DELETE SET NULL
);
GO

--6. Bang chi tiet nhap hang
CREATE TABLE ImportDetails (
    ImportDetailID INT IDENTITY(1,1) PRIMARY KEY,
    ImportID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_ImportDetails_Imports FOREIGN KEY (ImportID)
         REFERENCES Imports(ImportID)
         ON DELETE CASCADE,
    CONSTRAINT FK_ImportDetails_Products FOREIGN KEY (ProductID)
         REFERENCES Products(ProductID)
         ON DELETE CASCADE
);
GO

--7. Bang xuat hang
CREATE TABLE Exports (
    ExportID INT IDENTITY(1,1) PRIMARY KEY,
    ExportDate DATE NOT NULL,
    CustomerID INT NULL,
    EmployeeID INT NULL,
    CONSTRAINT FK_Exports_Customers FOREIGN KEY (CustomerID)
         REFERENCES Customers(CustomerID)
         ON DELETE SET NULL,
    CONSTRAINT FK_Exports_Employees FOREIGN KEY (EmployeeID)
         REFERENCES Employees(EmployeeID)
         ON DELETE SET NULL
);
GO

--8. Bang chi tiet xuat hang
CREATE TABLE ExportDetails (
    ExportDetailID INT IDENTITY(1,1) PRIMARY KEY,
    ExportID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_ExportDetails_Exports FOREIGN KEY (ExportID)
         REFERENCES Exports(ExportID)
         ON DELETE CASCADE,
    CONSTRAINT FK_ExportDetails_Products FOREIGN KEY (ProductID)
         REFERENCES Products(ProductID)
         ON DELETE CASCADE
);
GO

--9. Bang hoa don 
CREATE TABLE Invoices (
    InvoiceID INT IDENTITY(1,1) PRIMARY KEY,
    InvoiceDate DATE NOT NULL,
    CustomerID INT NULL,
    ExportID INT NULL,
    TotalAmount DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_Invoices_Customers FOREIGN KEY (CustomerID)
         REFERENCES Customers(CustomerID)
         ON DELETE SET NULL,
    CONSTRAINT FK_Invoices_Exports FOREIGN KEY (ExportID)
         REFERENCES Exports(ExportID)
         ON DELETE SET NULL
);
GO

--10. Bang vat tu can nhap
CREATE TABLE MaterialsToImport (
    MaterialID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    Status VARCHAR(50) NOT NULL,  -- Ví dụ: 'Chờ duyệt', 'Đã duyệt', 'Đã nhập'
    CONSTRAINT FK_MaterialsToImport_Products FOREIGN KEY (ProductID)
         REFERENCES Products(ProductID)
         ON DELETE CASCADE
);
GO

--11. Bang vat tu khong duoc nhap
CREATE TABLE RejectedMaterials (
    RejectedMaterialID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    Reason VARCHAR(255),
    CONSTRAINT FK_RejectedMaterials_Products FOREIGN KEY (ProductID)
         REFERENCES Products(ProductID)
         ON DELETE CASCADE
);
GO

--12. Bang nhat ki hoat dong
CREATE TABLE ActivityLogs (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeID INT NULL,
    Activity VARCHAR(255) NOT NULL,
    Timestamp DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_ActivityLogs_Employees FOREIGN KEY (EmployeeID)
         REFERENCES Employees(EmployeeID)
         ON DELETE SET NULL
);
GO

--Da hoan thien csdl co ban

--code thuc thi trong winform

--tao procedure 
--nhập hàng
IF OBJECT_ID('dbo.usp_GetAllImports','P') IS NOT NULL
  DROP PROC dbo.usp_GetAllImports;
GO
CREATE PROCEDURE dbo.usp_GetAllImports
AS
BEGIN
  SET NOCOUNT ON;
  SELECT 
    ImportID,
    ImportDate,
    EmployeeID,
    Supplier
  FROM Imports;
END
GO


--Chi tiết Nhập hàng
IF OBJECT_ID('dbo.usp_GetImportDetails','P') IS NOT NULL
  DROP PROC dbo.usp_GetImportDetails;
GO
CREATE PROCEDURE dbo.usp_GetImportDetails
  @ImportID INT
AS
BEGIN
  SET NOCOUNT ON;
  SELECT 
    d.ImportDetailID,
    d.ProductID,
    p.ProductName,
    d.Quantity,
    d.Price
  FROM ImportDetails d
  JOIN Products p ON p.ProductID = d.ProductID
  WHERE d.ImportID = @ImportID;
END
GO


--Them moi bản ghi nhập hàng
IF OBJECT_ID('dbo.usp_InsertImport','P') IS NOT NULL
  DROP PROC dbo.usp_InsertImport;
GO
CREATE PROCEDURE dbo.usp_InsertImport
  @ImportDate DATE,
  @EmployeeID INT = NULL,
  @Supplier VARCHAR(255)
AS
BEGIN
  SET NOCOUNT ON;
  INSERT INTO Imports (ImportDate, EmployeeID, Supplier)
  VALUES (@ImportDate, @EmployeeID, @Supplier);

  SELECT SCOPE_IDENTITY() AS NewImportID;
END
GO


--Cập nhật nhập hàng
IF OBJECT_ID('dbo.usp_UpdateImport','P') IS NOT NULL
  DROP PROC dbo.usp_UpdateImport;
GO
CREATE PROCEDURE dbo.usp_UpdateImport
  @ImportID INT,
  @ImportDate DATE,
  @EmployeeID INT = NULL,
  @Supplier VARCHAR(255)
AS
BEGIN
  SET NOCOUNT ON;
  UPDATE Imports
  SET ImportDate = @ImportDate,
      EmployeeID = @EmployeeID,
      Supplier   = @Supplier
  WHERE ImportID = @ImportID;
END
GO


--Xoá nhập hàng
IF OBJECT_ID('dbo.usp_DeleteImport','P') IS NOT NULL
  DROP PROC dbo.usp_DeleteImport;
GO
CREATE PROCEDURE dbo.usp_DeleteImport
  @ImportID INT
AS
BEGIN
  SET NOCOUNT ON;
  DELETE FROM Imports
  WHERE ImportID = @ImportID;
END
GO

--Tao procedure cho truy xuat tai khoan
CREATE PROCEDURE CheckLogin
@Email NVARCHAR(100),
@Password NVARCHAR(100)
AS
BEGIN
    SELECT * FROM Employees WHERE Email = @Email AND Password = @Password;
END


--kiem tra procedure
SELECT name
FROM sys.procedures
ORDER BY name;

--procedure voi thong tin nhan vien
--Cap nhat nhan vien
CREATE PROCEDURE usp_UpdateEmployee
    @EmployeeID INT,
    @EmployeeName NVARCHAR(255),
    @Role NVARCHAR(50),
    @Email NVARCHAR(255)
AS
BEGIN
    UPDATE Employees
    SET EmployeeName = @EmployeeName, 
        Role = @Role, 
        Email = @Email
    WHERE EmployeeID = @EmployeeID;
END

--xoa nhan vien
CREATE PROCEDURE usp_DeleteEmployee
    @EmployeeID INT
AS
BEGIN
    DELETE FROM Employees WHERE EmployeeID = @EmployeeID;
END

--tim kiem nhan vien
CREATE PROCEDURE usp_SearchEmployee
    @Keyword NVARCHAR(255)
AS
BEGIN
    SELECT EmployeeID, EmployeeName, Role, Email 
    FROM Employees
    WHERE EmployeeName LIKE '%' + @Keyword + '%' 
       OR Email LIKE '%' + @Keyword + '%';
END

--phan trang danh sach nhan vien
CREATE PROCEDURE usp_GetEmployeesByPage
    @PageNumber INT,
    @PageSize INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT EmployeeID, EmployeeName, Role, Email 
    FROM Employees
    ORDER BY EmployeeID
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;
END

--procedure khach hang
--lay danh sach
CREATE PROCEDURE usp_GetCustomers
AS
BEGIN
    SELECT CustomerID, CustomerName, Address, Phone FROM Customers;
END

--tim kiem khach hang
CREATE PROCEDURE usp_SearchCustomers
    @Keyword NVARCHAR(255)
AS
BEGIN
    SELECT CustomerID, CustomerName, Address, Phone 
    FROM Customers
    WHERE CustomerName LIKE '%' + @Keyword + '%' 
       OR Phone LIKE '%' + @Keyword + '%';
END

--them khach hang
CREATE PROCEDURE usp_AddCustomer
    @CustomerName NVARCHAR(255),
    @Address NVARCHAR(255),
    @Phone NVARCHAR(50)
AS
BEGIN
    INSERT INTO Customers (CustomerName, Address, Phone)
    VALUES (@CustomerName, @Address, @Phone);
END
go
--chinh sua va xoa khach hang
CREATE PROCEDURE usp_UpdateCustomer
    @CustomerID INT,
    @CustomerName NVARCHAR(255),
    @Address NVARCHAR(255),
    @Phone NVARCHAR(50)
AS
BEGIN
    UPDATE Customers
    SET CustomerName = @CustomerName, Address = @Address, Phone = @Phone
    WHERE CustomerID = @CustomerID;
END
go
CREATE PROCEDURE usp_DeleteCustomer
    @CustomerID INT
AS
BEGIN
    DELETE FROM Customers WHERE CustomerID = @CustomerID;
END

go
--thong ke so luong don hang cua khach hang
CREATE PROCEDURE usp_GetCustomerOrders
AS
BEGIN
    SELECT c.CustomerID, c.CustomerName, c.Phone,
           ISNULL(o.OrderCount, 0) AS TotalOrders
    FROM Customers c
    LEFT JOIN (SELECT CustomerID, COUNT(*) AS OrderCount FROM Exports GROUP BY CustomerID) o
        ON c.CustomerID = o.CustomerID;
END
go

--procedure voi san pham
--tải danh sách hàng hoá
CREATE PROCEDURE usp_GetProducts
AS
BEGIN
    SELECT ProductID, ProductName, Category, Unit, Quantity, MinQuantity, LocationID
    FROM Products;
END
go

--tim kiem san pham
CREATE PROCEDURE usp_SearchProducts
    @Keyword NVARCHAR(255)
AS
BEGIN
    SELECT ProductID, ProductName, Category, Unit, Quantity, MinQuantity, LocationID
    FROM Products
    WHERE ProductName LIKE '%' + @Keyword + '%' 
       OR Category LIKE '%' + @Keyword + '%';
END
go

--them san pham
CREATE PROCEDURE usp_AddProduct
    @ProductName NVARCHAR(255),
    @Category NVARCHAR(255),
    @Unit NVARCHAR(100),
    @Quantity INT,
    @MinQuantity INT,
    @LocationID INT
AS
BEGIN
    INSERT INTO Products (ProductName, Category, Unit, Quantity, MinQuantity, LocationID)
    VALUES (@ProductName, @Category, @Unit, @Quantity, @MinQuantity, @LocationID);
END
go

--them sua xoa san pham
CREATE PROCEDURE usp_UpdateProduct
    @ProductID INT,
    @ProductName NVARCHAR(255),
    @Category NVARCHAR(255),
    @Unit NVARCHAR(100),
    @Quantity INT,
    @MinQuantity INT,
    @LocationID INT
AS
BEGIN
    UPDATE Products
    SET ProductName = @ProductName, Category = @Category, Unit = @Unit,
        Quantity = @Quantity, MinQuantity = @MinQuantity, LocationID = @LocationID
    WHERE ProductID = @ProductID;
END
go
CREATE PROCEDURE usp_DeleteProduct
    @ProductID INT
AS
BEGIN
    DELETE FROM Products WHERE ProductID = @ProductID;
END
go

--lay thong ke 
CREATE PROCEDURE usp_GetLowStockProducts
AS
BEGIN
    SELECT ProductID, ProductName, Category, Quantity, MinQuantity
    FROM Products
    WHERE Quantity < MinQuantity;
END
go

--procedure cho nhap hang
--lay danh sach phieu nhap
CREATE PROCEDURE usp_GetImports
AS
BEGIN
    SELECT i.ImportID, i.ImportDate, e.EmployeeName, i.Supplier
    FROM Imports i
    JOIN Employees e ON i.EmployeeID = e.EmployeeID;
END
go

--them phieu nhap
CREATE PROCEDURE usp_AddImport
    @ImportDate DATE,
    @EmployeeID INT,
    @Supplier NVARCHAR(255)
AS
BEGIN
    INSERT INTO Imports (ImportDate, EmployeeID, Supplier)
    VALUES (@ImportDate, @EmployeeID, @Supplier);

    SELECT SCOPE_IDENTITY() AS NewImportID;
END
go

--them san pham vao phieu nhap
CREATE PROCEDURE usp_AddImportDetail
    @ImportID INT,
    @ProductID INT,
    @Quantity INT,
    @Price DECIMAL(10,2)
AS
BEGIN
    INSERT INTO ImportDetails (ImportID, ProductID, Quantity, Price)
    VALUES (@ImportID, @ProductID, @Quantity, @Price);
END
go