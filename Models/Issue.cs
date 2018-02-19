using System;

namespace Decos.Fixi
{
  /// <summary>
  /// Represents a reported issue.
  /// </summary>
  public class Issue
  {
    /// <summary>
    /// Gets or sets the category in which the issue is reported.
    /// </summary>
    public Category Category { get; set; }

    /// <summary>
    /// Gets or sets the public issue identifier.
    /// </summary>
    public string ID { get; set; }

    /// <summary>
    /// Gets or sets the location at which the issue is made.
    /// </summary>
    public Point Location { get; set; }

    /// <summary>
    /// Gets or sets the name of the region in which the issue is made.
    /// </summary>
    public string RegionName { get; set; }
  }
}