using System;
using System.Collections.Generic;

namespace PAW.Models.Products;

/// <summary>
/// Represents a role within the system, such as an administrative or user role.
/// </summary>
public partial class Role
{
    /// <summary>
    /// Gets or sets the unique identifier for the role.
    /// </summary>
    public int RoleId { get; set; }

    /// <summary>
    /// Gets or sets the name of the role.
    /// </summary>
    /// <remarks>
    /// This value can be null if no name is provided for the role.
    /// </remarks>
    public string? RoleName { get; set; }
}
