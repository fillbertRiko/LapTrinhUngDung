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
