using System;
using System.Collections.Generic;

namespace PAW.Models.Products;

/// <summary>
/// Represents a supplier providing products, including contact and location details.
/// </summary>
public partial class Supplier
{
    /// <summary>
    /// Gets or sets the unique identifier for the supplier.
    /// </summary>
    public int SupplierId { get; set; }

    /// <summary>
    /// Gets or sets the name of the supplier.
    /// </summary>
    /// <remarks>
    /// This value can be null if no supplier name is provided.
    /// </remarks>
    public string? SupplierName { get; set; }

    /// <summary>
    /// Gets or sets the name of the contact person for the supplier.
    /// </summary>
    /// <remarks>
    /// This value can be null if no contact name is provided.
    /// </remarks>
    public string? ContactName { get; set; }

    /// <summary>
    /// Gets or sets the title of the contact person for the supplier.
    /// </summary>
    /// <remarks>
    /// This value can be null if no contact title is provided.
    /// </remarks>
    public string? ContactTitle { get; set; }

    /// <summary>
    /// Gets or sets the phone number for contacting the supplier.
    /// </summary>
    /// <remarks>
    /// This value can be null if no phone number is provided.
    /// </remarks>
    public string? Phone { get; set; }

    /// <summary>
    /// Gets or sets the address of the supplier.
    /// </summary>
    /// <remarks>
    /// This value can be null if no address is provided.
    /// </remarks>
    public string? Address { get; set; }

    /// <summary>
    /// Gets or sets the city where the supplier is located.
    /// </summary>
    /// <remarks>
    /// This value can be null if no city is provided.
    /// </remarks>
    public string? City { get; set; }

    /// <summary>
    /// Gets or sets the country where the supplier is located.
    /// </summary>
    /// <remarks>
    /// This value can be null if no country is provided.
    /// </remarks>
    public string? Country { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the supplier information was last modified.
    /// </summary>
    /// <remarks>
    /// This value can be null if the supplier has never been modified.
    /// </remarks>
    public DateTime? LastModified { get; set; }

    /// <summary>
    /// Gets or sets the name of the user who last modified the supplier information.
    /// </summary>
    /// <remarks>
    /// This value can be null if the modifier is not recorded.
    /// </remarks>
    public string? ModifiedBy { get; set; }

    /// <summary>
    /// Gets or sets the collection of products associated with the supplier.
    /// </summary>
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}