namespace PAW.Models.Products;

/// <summary>
/// Represents a product with details such as name, description, rating, and related entities.
/// </summary>
public partial class Product
{
    /// <summary>
    /// Gets or sets the unique identifier for the product.
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    /// <remarks>
    /// This value can be null if no name is provided for the product.
    /// </remarks>
    public string? ProductName { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the associated inventory record for the product.
    /// </summary>
    /// <remarks>
    /// This value can be null if no inventory record is linked to the product.
    /// </remarks>
    public int? InventoryId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the supplier of the product.
    /// </summary>
    /// <remarks>
    /// This value can be null if no supplier is linked to the product.
    /// </remarks>
    public int? SupplierId { get; set; }

    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    /// <remarks>
    /// This value can be null if no description is provided.
    /// </remarks>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the rating of the product.
    /// </summary>
    /// <remarks>
    /// This value can be null if no rating is provided.
    /// </remarks>
    public decimal? Rating { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the category to which the product belongs.
    /// </summary>
    /// <remarks>
    /// This value can be null if the product is not assigned to a category.
    /// </remarks>
    public int? CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the product was last modified.
    /// </summary>
    /// <remarks>
    /// This value can be null if the product has never been modified.
    /// </remarks>
    public DateTime? LastModified { get; set; }

    /// <summary>
    /// Gets or sets the name of the user who last modified the product.
    /// </summary>
    /// <remarks>
    /// This value can be null if the modifier is not recorded.
    /// </remarks>
    public string? ModifiedBy { get; set; }
    public decimal UnitPrice { get; set; }


    /// <summary>
    /// Gets or sets the category associated with the product.
    /// </summary>
    public virtual Category? Category { get; set; }

    /// <summary>
    /// Gets or sets the inventory record associated with the product.
    /// </summary>
    public virtual Inventory? Inventory { get; set; }

    /// <summary>
    /// Gets or sets the supplier associated with the product.
    /// </summary>
    public virtual Supplier? Supplier { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsDirty { get; set; }
    public DateTime LastRetreived { get; set; }

}
