using System;

namespace StockManagement.Models;

/*
    CREATE TABLE BatchItems (
    BatchItemID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    BatchID UNIQUEIDENTIFIER NOT NULL,
    ProductID UNIQUEIDENTIFIER NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (BatchID) REFERENCES Batch(BatchID),
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);
*/

public class BatchItem
{
    public Guid BatchItemID { get; set; }
    public IEnumerable<PreOrderItem>? PreOrderItems { get; set; }
    public required Batch Batch { get; set; }
    public Guid BatchId { get; set; }
    public required Product Product { get; set; }
    public Guid ProductID { get; set; }
    public int Quantity { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool Active { get; set; }
}
