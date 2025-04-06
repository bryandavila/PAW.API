using System;
using System.Collections.Generic;

namespace PAW.Models.Products;

/// <summary>
/// Represents a user role association, linking a user with a specific role.
/// </summary>
public partial class UserRole
{
    /// <summary>
    /// Gets or sets the unique identifier for the user role association.
    /// </summary>
    /// <remarks>
    /// This value can be null if the identifier is not provided.
    /// </remarks>
    public decimal? Id { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the role associated with the user.
    /// </summary>
    /// <remarks>
    /// This value can be null if the role ID is not provided.
    /// </remarks>
    public decimal? RoldId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the user associated with the role.
    /// </summary>
    /// <remarks>
    /// This value can be null if the user ID is not provided.
    /// </remarks>
    public decimal? UserId { get; set; }
}
