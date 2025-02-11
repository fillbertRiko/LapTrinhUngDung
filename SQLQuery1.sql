-- TẠO CƠ SỞ DỮ LIỆU
DROP DATABASE IF EXISTS SalesManagement;
CREATE DATABASE SalesManagement;
USE SalesManagement;

-- XÓA BẢNG (THEO THỨ TỰ PHỤ THUỘC)
DROP TABLE IF EXISTS SaleInvoiceDetails;
DROP TABLE IF EXISTS SaleInvoice;
DROP TABLE IF EXISTS ImportInvoiceDetails;
DROP TABLE IF EXISTS ImportInvoice;
DROP TABLE IF EXISTS Product;
DROP TABLE IF EXISTS Material;
DROP TABLE IF EXISTS Customer;
DROP TABLE IF EXISTS Supplier;
DROP TABLE IF EXISTS Staff;
DROP TABLE IF EXISTS StaffPosition;
DROP TABLE IF EXISTS Warehouse;
DROP TABLE IF EXISTS UnitOfMeasure;
DROP TABLE IF EXISTS Permission;

-- TẠO BẢNG
CREATE TABLE Permission (
    PermissionID INT PRIMARY KEY,
    PermissionName VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE StaffPosition (
    PositionID INT PRIMARY KEY,
    PositionName VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE UnitOfMeasure (
    UOMID INT PRIMARY KEY,
    UOMName VARCHAR(20) NOT NULL UNIQUE
);

CREATE TABLE Warehouse (
    WarehouseID INT PRIMARY KEY,
    WarehouseName VARCHAR(100) NOT NULL,
    Location VARCHAR(255)
);

CREATE TABLE Staff (
    StaffID INT PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE,
    Phone VARCHAR(15),
    PositionID INT,
    PermissionID INT,
    FOREIGN KEY (PositionID) REFERENCES StaffPosition(PositionID),
    FOREIGN KEY (PermissionID) REFERENCES Permission(PermissionID)
);

CREATE TABLE Customer (
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100) NOT NULL,
    Phone VARCHAR(15),
    Address VARCHAR(255)
);

CREATE TABLE Supplier (
    SupplierID INT PRIMARY KEY,
    SupplierName VARCHAR(100) NOT NULL,
    Phone VARCHAR(15),
    Address VARCHAR(255)
);

CREATE TABLE Product (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL,
    UOMID INT,
    UnitPrice DECIMAL(18,2) NOT NULL,
    WarehouseID INT,
    FOREIGN KEY (UOMID) REFERENCES UnitOfMeasure(UOMID),
    FOREIGN KEY (WarehouseID) REFERENCES Warehouse(WarehouseID)
);

CREATE TABLE Material (
    MaterialID INT PRIMARY KEY,
    MaterialName VARCHAR(100) NOT NULL,
    UOMID INT,
    UnitPrice DECIMAL(18,2) NOT NULL,
    WarehouseID INT,
    FOREIGN KEY (UOMID) REFERENCES UnitOfMeasure(UOMID),
    FOREIGN KEY (WarehouseID) REFERENCES Warehouse(WarehouseID)
);

CREATE TABLE SaleInvoice (
    InvoiceID INT PRIMARY KEY,
    CustomerID INT,
    StaffID INT,
    InvoiceDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    TotalAmount DECIMAL(18,2),
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
    FOREIGN KEY (StaffID) REFERENCES Staff(StaffID),
    INDEX idx_CustomerID (CustomerID),
    INDEX idx_StaffID (StaffID)
);

CREATE TABLE SaleInvoiceDetails (
    InvoiceID INT,
    ProductID INT,
    Quantity INT NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    PRIMARY KEY (InvoiceID, ProductID),
    FOREIGN KEY (InvoiceID) REFERENCES SaleInvoice(InvoiceID),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);

CREATE TABLE ImportInvoice (
    ImportID INT PRIMARY KEY,
    SupplierID INT,
    StaffID INT,
    ImportDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    TotalAmount DECIMAL(18,2),
    FOREIGN KEY (SupplierID) REFERENCES Supplier(SupplierID),
    FOREIGN KEY (StaffID) REFERENCES Staff(StaffID),
    INDEX idx_SupplierID (SupplierID),
    INDEX idx_StaffID (StaffID)
);

CREATE TABLE ImportInvoiceDetails (
    ImportID INT,
    MaterialID INT,
    Quantity INT NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    PRIMARY KEY (ImportID, MaterialID),
    FOREIGN KEY (ImportID) REFERENCES ImportInvoice(ImportID),
    FOREIGN KEY (MaterialID) REFERENCES Material(MaterialID)
);