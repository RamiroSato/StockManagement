using System;

namespace StockManagement.Models;

/*

CREATE TABLE Transactions (
    TransactionID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    PreOrderID UNIQUEIDENTIFIER NOT NULL,
    TransactionDate DATETIME DEFAULT GETDATE(),
    Amount DECIMAL(18, 2) NOT NULL,
    PaymentMethod NVARCHAR(50) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (PreOrderID) REFERENCES PreOrders(PreOrderID)
);

*/

public class Transaction
{
    public Guid TransactionID { get; set; }
    public PreOrder? PreOrder { get; set; }
    public required Guid PreOrderID { get; set; }
    public DateTime? TransactionDate { get; set; }
    public decimal Amount { get; set; }
    public required string PaymentMethod { get; set; }
    public DateTime? CreatedAt { get; set; }
    public bool Active { get; set; }
}
