using System;
using System.Collections.Generic;

namespace PAW.Models.Products;

/// <summary>
/// Represents an action that a user can perform, including its name and description.
/// </summary>
public partial class UserAction
{
    /// <summary>
    /// Gets or sets the unique identifier for the user action.
    /// </summary>
    /// <remarks>
    /// This value can be null if the identifier is not provided.
    /// </remarks>
    public decimal? Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the user action.
    /// </summary>
    /// <remarks>
    /// This value can be null if no name is provided.
    /// </remarks>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the description of the user action.
    /// </summary>
    /// <remarks>
    /// This value can be null if no description is provided.
    /// </remarks>
    public string? Description { get; set; }
}
