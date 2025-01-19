using System;

namespace StockManagement.Models;

/*
    CREATE TABLE Wishlist (
    WishlistID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(), 
    Name NVARCHAR(100) NULL,                              
    UserID UNIQUEIDENTIFIER NOT NULL,                      
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(),    
    CONSTRAINT FK_Wishlist_User FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
*/

public class Wishlist
{
    public Guid WishlistID { get; set; }
    public required string Name { get; set; }
    public required Client Client { get; set; }
    public required Guid ClientID { get; set; }
    public required IEnumerable<Product> Products { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool Active { get; set; }

}
