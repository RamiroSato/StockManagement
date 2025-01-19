using System;

namespace StockManagement.Models;

/*
CREATE TABLE Product (
    ProductID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ProductName NVARCHAR(255) NOT NULL,
    ProductTypeID UNIQUEIDENTIFIER NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    Description NVARCHAR(MAX) NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,
    Active BIT DEFAULT 1,
    FOREIGN KEY (ProductTypeID) REFERENCES ProductType(ProductTypeID)
    
);
*/

public class Product
{
    public Guid ProductID { get; set; }
    public required string ProductName { get; set; }
    public required ProductType productType { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool Active { get; set; }
}
