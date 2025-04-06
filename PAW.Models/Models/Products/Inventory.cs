using PAW.Models.Products;

namespace PAW.Models.Products;

/// <summary>
/// Represents the inventory details for a product, including stock levels and pricing information.
/// </summary>
public partial class Inventory
{
    /// <summary>
    /// Gets or sets the unique identifier for the inventory record.
    /// </summary>
    public int InventoryId { get; set; }

    /// <summary>
    /// Gets or sets the unit price of the product in the inventory.
    /// </summary>
    /// <remarks>
    /// This value can be null if the unit price is not set.
    /// </remarks>
    public decimal? UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the number of units available in stock for the product.
    /// </summary>
    /// <remarks>
    /// This value can be null if the stock level is not set.
    /// </remarks>
    public int? UnitsInStock { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the inventory record was last updated.
    /// </summary>
    /// <remarks>
    /// This value can be null if the inventory has never been updated.
    /// </remarks>
    public DateTime? LastUpdated { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the associated product.
    /// </summary>
    /// <remarks>
    /// This value can be null if no product is associated.
    /// </remarks>
    public int? ProductId { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the inventory record was added.
    /// </summary>
    /// <remarks>
    /// This value can be null if the date added is not available.
    /// </remarks>
    public DateTime? DateAdded { get; set; }

    /// <summary>
    /// Gets or sets the name of the user who last modified the inventory record.
    /// </summary>
    /// <remarks>
    /// This value can be null if the modifier is not recorded.
    /// </remarks>
    public string? ModifiedBy { get; set; }

    /// <summary>
    /// Gets or sets the collection of products associated with this inventory record.
    /// </summary>
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
