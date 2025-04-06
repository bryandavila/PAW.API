using System;
using System.Collections.Generic;

namespace PAW.Models.Products;

/// <summary>
/// Represents a notification sent to a user, including message details and read status.
/// </summary>
public partial class Notification
{
    /// <summary>
    /// Gets or sets the unique identifier for the notification.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the user who received the notification.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Gets or sets the message content of the notification.
    /// </summary>
    /// <remarks>
    /// The value cannot be null.
    /// </remarks>
    public string Message { get; set; } = null!;

    /// <summary>
    /// Gets or sets the read status of the notification.
    /// </summary>
    /// <remarks>
    /// This value can be null if the read status is not set.
    /// </remarks>
    public bool? IsRead { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the notification was created.
    /// </summary>
    /// <remarks>
    /// This value can be null if the creation time is not available.
    /// </remarks>
    public DateTime? CreatedAt { get; set; }
}

