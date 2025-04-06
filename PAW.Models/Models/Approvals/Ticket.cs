using System;
using System.Collections.Generic;

namespace PAW.Models.Approvals;

/// <summary>
/// Represents a ticket that may require approval.
/// </summary>
public partial class Ticket
{
    /// <summary>
    /// Gets or sets the unique identifier for the ticket.
    /// </summary>
    public int TicketId { get; set; }

    /// <summary>
    /// Gets or sets the title of the ticket.
    /// </summary>
    /// <remarks>
    /// The value cannot be null.
    /// </remarks>
    public string Title { get; set; } = null!;

    /// <summary>
    /// Gets or sets the description of the ticket.
    /// </summary>
    /// <remarks>
    /// This value can be null if no description has been provided.
    /// </remarks>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the current status of the ticket.
    /// </summary>
    /// <remarks>
    /// This value can be null if no status has been set.
    /// </remarks>
    public string? Status { get; set; }

    /// <summary>
    /// Gets or sets the creation date and time of the ticket.
    /// </summary>
    /// <remarks>
    /// This value can be null if the creation time is not available.
    /// </remarks>
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the collection of approvals associated with the ticket.
    /// </summary>
    public virtual ICollection<Approval> Approvals { get; set; } = new List<Approval>();
}

