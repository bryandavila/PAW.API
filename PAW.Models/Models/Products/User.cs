using System;
using System.Collections.Generic;

namespace PAW.Models.Products;

/// <summary>
/// Represents a user in the system, including authentication details and account status.
/// </summary>
public partial class User
{
    /// <summary>
    /// Gets or sets the unique identifier for the user.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Gets or sets the username associated with the user account.
    /// </summary>
    /// <remarks>
    /// This value can be null if no username is provided.
    /// </remarks>
    public string? Username { get; set; }

    /// <summary>
    /// Gets or sets the email address associated with the user account.
    /// </summary>
    /// <remarks>
    /// This value can be null if no email is provided.
    /// </remarks>
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the hashed password for the user account.
    /// </summary>
    /// <remarks>
    /// This value can be null if the password hash is not provided.
    /// </remarks>
    public string? PasswordHash { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the user account was created.
    /// </summary>
    /// <remarks>
    /// This value can be null if the creation time is not available.
    /// </remarks>
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user account is active.
    /// </summary>
    /// <remarks>
    /// This value can be null if the active status is not set.
    /// </remarks>
    public bool? IsActive { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the user account was last modified.
    /// </summary>
    /// <remarks>
    /// This value can be null if the account has never been modified.
    /// </remarks>
    public DateTime? LastModified { get; set; }

    /// <summary>
    /// Gets or sets the name of the user who last modified the user account.
    /// </summary>
    /// <remarks>
    /// This value can be null if the modifier is not recorded.
    /// </remarks>
    public string? ModifiedBy { get; set; }
}
