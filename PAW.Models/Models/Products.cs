using System;
using System.Collections.Generic;

namespace PAW.Models.Models;

public partial class Products
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int? SupplierId { get; set; }

    public int? CategoryId { get; set; }

    public decimal UnitPrice { get; set; }

    public string? QuantityPerUnit { get; set; }

    public int? UnitsInStock { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
