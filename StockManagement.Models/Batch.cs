using System;

namespace StockManagement.Models;

/*
CREATE TABLE Batch (
    BatchID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    BatchNumber NVARCHAR(50) NOT NULL UNIQUE,
    WarehouseID UNIQUEIDENTIFIER NOT NULL,
    ProductionDate DATE NULL,
    ExpiryDate DATE NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (WarehouseID) REFERENCES Warehouse(WarehouseID)
);
*/
public class Batch
{
    public required Guid BatchID { get; set; }
    public required string BatchNumber { get; set; }
    public required Warehouse warehouse { get; set; }
    public required DateTime ProductionDate { get; set; }
    public required DateTime CreatedAt { get; set; }
    public bool Active { get; set; }

}
