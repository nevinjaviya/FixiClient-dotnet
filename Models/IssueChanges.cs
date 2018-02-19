using System;

namespace Decos.Fixi
{
  /// <summary>
  /// Represents changes to a reported issue.
  /// </summary>
  public class IssueChanges
  {
    /// <summary>
    /// Gets or sets the short name of the category to assign to the issue.
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// Gets or sets the new location of the issue.
    /// </summary>
    public Point Location { get; set; }

    /// <summary>
    /// Gets or sets the short name of the region to associate with the issue,
    /// </summary>
    public string Region { get; set; }
  }
}