using System;

namespace StockManagement.Models;

/*
    CREATE TABLE PreOrderItems (
    PreOrderItemID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    PreOrderID UNIQUEIDENTIFIER NOT NULL,
    BatchItemID UNIQUEIDENTIFIER NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (PreOrderID) REFERENCES PreOrders(PreOrderID),
    FOREIGN KEY (BatchItemID) REFERENCES BatchItems(BatchItemID)
);

*/

public class PreOrderItem
{
    public required Guid PreOrderItemID { get; set; }
    public required PreOrder PreOrder { get; set; }
    public required BatchItem BatchItem { get; set; }
    public required int Quantity { get; set; }
    public required DateTime CreatedAt { get; set; }
    public bool Active { get; set; }
}
