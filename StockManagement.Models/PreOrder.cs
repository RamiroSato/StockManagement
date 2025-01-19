using System;

namespace StockManagement.Models;

// CREATE TABLE PreOrders (
//     PreOrderID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
//     ClientID UNIQUEIDENTIFIER NOT NULL,
//     OrderID UNIQUEIDENTIFIER NOT NULL,
//     PreOrderDate DATETIME DEFAULT GETDATE(),
//     Status NVARCHAR(50) NOT NULL,
//     CreatedAt DATETIME DEFAULT GETDATE(),
//     FOREIGN KEY (ClientID) REFERENCES Client(ClientID)
//     FOREIGN KEY (OrderID) REFERENCES Order(OrderID)
// );

public class PreOrder
{
    public Guid PreOrderID { get; set; }
    public required Client Client { get; set; }
    public Order? Order { get; set; }  
    public DateTime PreOrderDate { get; set; }
    public required string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool Active { get; set; }

}
