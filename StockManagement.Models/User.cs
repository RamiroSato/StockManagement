using System;

namespace StockManagement.Models;

public class User
{
    public Guid UserID { get; set; }
    public required UserRole Role { get; set; }
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public required string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool Active { get; set; }
}
