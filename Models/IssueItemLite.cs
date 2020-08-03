using System;
using System.Collections.Generic;
using System.Text;

namespace Decos.Fixi
{
  /// <summary>
  /// Represents a reported issue as an item in a list.
  /// </summary>
  public class IssueItemLite
  {
    /// <summary>
    /// Gets the number of files attached to the issue.
    /// </summary>
    public int AttachmentCount { get; set; }

    /// <summary>
    /// Gets or sets the public identifier of the issue.
    /// </summary>
    public string ID { get; set; }

    /// <summary>
    /// Gets the point in time when the issue has been created, or a null reference if the entity has not been committed to the database yet.
    /// </summary>
    public DateTimeOffset? Created { get; set; }

    /// <summary>
    /// Gets a description of the issue.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets the short name of the organization that manages the region in which the issue was reported, or null if the issue was reported in an area
    /// without any registered regions or if the region is not managed by an organization.
    /// </summary>
    public string Organization { get; set; }

    /// <summary>
    /// Gets the short name of the region in which the issue was reported, or a null reference if the issue was reported in an area without any registered regions.
    /// </summary>
    public string Region { get; set; }
  }
}
