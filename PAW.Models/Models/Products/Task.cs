using System;
using System.Collections.Generic;

namespace PAW.Models.Products;

/// <summary>
/// Represents a task with details such as name, description, status, and due date.
/// </summary>
public partial class Task
{
    /// <summary>
    /// Gets or sets the unique identifier for the task.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the task.
    /// </summary>
    /// <remarks>
    /// This value can be null if no name is provided for the task.
    /// </remarks>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the description of the task.
    /// </summary>
    /// <remarks>
    /// This value can be null if no description is provided.
    /// </remarks>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the status of the task (e.g., "In Progress", "Completed").
    /// </summary>
    /// <remarks>
    /// This value can be null if no status is provided for the task.
    /// </remarks>
    public string? Status { get; set; }

    /// <summary>
    /// Gets or sets the due date for the task.
    /// </summary>
    /// <remarks>
    /// This value can be null if no due date is provided for the task.
    /// </remarks>
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the task was created.
    /// </summary>
    /// <remarks>
    /// This value can be null if the creation time is not available.
    /// </remarks>
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the task was last modified.
    /// </summary>
    /// <remarks>
    /// This value can be null if the task has never been modified.
    /// </remarks>
    public DateTime? LastModified { get; set; }

    /// <summary>
    /// Gets or sets the name of the user who last modified the task.
    /// </summary>
    /// <remarks>
    /// This value can be null if the modifier is not recorded.
    /// </remarks>
    public string? ModifiedBy { get; set; }
}
