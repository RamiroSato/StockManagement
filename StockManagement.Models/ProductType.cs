using System;

namespace StockManagement.Models;

public class ProductType
{
    public Guid ProductTypeID { get; set; }
    public IEnumerable<Product>? Products { get; set; }
    public required string TypeName { get; set; }
    public required string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool Active { get; set; }
}
