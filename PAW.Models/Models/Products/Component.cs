namespace PAW.Models.Products;

/// <summary>
/// Represents a generic component with an identifier, name, and content.
/// </summary>
public partial class Component
{
    /// <summary>
    /// Gets or sets the unique identifier for the component.
    /// </summary>
    public decimal Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the component.
    /// </summary>
    /// <remarks>
    /// The value cannot be null.
    /// </remarks>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the content associated with the component.
    /// </summary>
    /// <remarks>
    /// The value cannot be null.
    /// </remarks>
    public string Content { get; set; } = null!;
}
