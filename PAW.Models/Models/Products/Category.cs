using PAW.Models.Products;

namespace PAW.Models.Products;

/// <summary>
/// Represents a product category, which can contain multiple products.
/// </summary>
public partial class Category
{
    /// <summary>
    /// Gets or sets the unique identifier for the category.
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the name of the category.
    /// </summary>
    /// <remarks>
    /// This value can be null if no category name is provided.
    /// </remarks>
    public string? CategoryName { get; set; }

    /// <summary>
    /// Gets or sets the description of the category.
    /// </summary>
    /// <remarks>
    /// This value can be null if no description is provided.
    /// </remarks>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the category was last modified.
    /// </summary>
    /// <remarks>
    /// This value can be null if the category has not been modified.
    /// </remarks>
    public DateTime? LastModified { get; set; }

    /// <summary>
    /// Gets or sets the name of the user who last modified the category.
    /// </summary>
    /// <remarks>
    /// This value can be null if the modifier is not recorded.
    /// </remarks>
    public string? ModifiedBy { get; set; }

    /// <summary>
    /// Gets or sets the collection of products associated with the category.
    /// </summary>
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
