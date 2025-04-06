using PAW.Models.Products;

namespace PAW.Models.Components;

/// <summary>
/// Represents the base class for a component, containing data and a URL.
/// </summary>
public abstract class ComponentBase
{
    /// <summary>
    /// Gets or sets the collection of components associated with this base component.
    /// </summary>
    public IEnumerable<Component> Data { get; set; }

    /// <summary>
    /// Gets or sets the URL associated with this component.
    /// </summary>
    /// <remarks>
    /// The value should be a valid URL string.
    /// </remarks>
    public string Url { get; set; }
}

