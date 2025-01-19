using System;

namespace StockManagement.Models;

/*
    CREATE TABLE Client (
    ClientID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    FirstName NVARCHAR(255) NOT NULL,
    LastName NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NULL,
    Phone NVARCHAR(20) NULL,
    Address NVARCHAR(255) NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (CompanyID) REFERENCES Companies(CompanyID),
    FOREIGN KEY (PersonID) REFERENCES People(PersonID)
);
*/

public class Client
{
    public Guid ClientID { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required string Address { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool Active { get; set; }
}
