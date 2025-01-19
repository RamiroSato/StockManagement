using System;

namespace StockManagement.Models;

public class UserRole
{
    public int UserRoleID { get; set; }
    public required string RoleName { get; set; }

    public  IEnumerable<User>? Users { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool Active { get; set; }
}
