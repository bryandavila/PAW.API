
namespace PAW.Models.Approvals;

/// <summary>
/// Represents an approval decision for a ticket.
/// </summary>
public partial class Approval
{
    /// <summary>
    /// Gets or sets the unique identifier for the approval.
    /// </summary>
    public int ApprovalId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the associated ticket.
    /// </summary>
    public int TicketId { get; set; }

    /// <summary>
    /// Gets or sets the role of the person approving the ticket.
    /// </summary>
    /// <remarks>
    /// The value cannot be null.
    /// </remarks>
    public string ApproverRole { get; set; } = null!;

    /// <summary>
    /// Gets or sets the decision made by the approver.
    /// </summary>
    /// <remarks>
    /// This value can be null if no decision has been made yet.
    /// </remarks>
    public string? Decision { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the decision was made.
    /// </summary>
    /// <remarks>
    /// This value can be null if no decision has been made yet.
    /// </remarks>
    public DateTime? DecisionDate { get; set; }

    /// <summary>
    /// Gets or sets the associated ticket for this approval.
    /// </summary>
    public virtual Ticket Ticket { get; set; } = null!;
}
