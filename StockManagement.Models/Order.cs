using System;

namespace StockManagement.Models;

// CREATE TABLE Orders (
//     OrderID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
//     PreOrderID UNIQUEIDENTIFIER NOT NULL,
//     OrderDate DATETIME DEFAULT GETDATE(),
//     Status NVARCHAR(50) NOT NULL,
//     CreatedAt DATETIME DEFAULT GETDATE(),
//     FOREIGN KEY (PreOrderID) REFERENCES PreOrders(PreOrderID)
// );


public class Order
{
    public Guid OrderID { get; set; }
    public int OrderNumber { get; set; }
    public required PreOrder PreOrder { get; set; }
    public Guid PreOrderID { get; set; }
    public DateTime? OrderDate { get; set; }
    public required string Status { get; set; }
    public DateTime? CreatedAt { get; set; }
    public bool Active { get; set; }

}
