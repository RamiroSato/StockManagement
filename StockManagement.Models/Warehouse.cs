using System;

namespace StockManagement.Models;
/*
    CREATE TABLE Warehouse (
        WarehouseID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
        WarehouseName NVARCHAR(255) NOT NULL,
        Location NVARCHAR(255) NULL,
        CreatedAt DATETIME DEFAULT GETDATE(),
        UpdatedAt DATETIME NULL,
        Active BIT DEFAULT 1

    );
*/

public class Warehouse
{
    public Guid WarehouseID { get; set; }
    public required string WarehouseName { get; set; }
    public string? Location { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool Active { get; set; }
}
