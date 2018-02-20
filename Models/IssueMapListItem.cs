using System;

namespace Decos.Fixi
{
  /// <summary>
  /// Represents a reported issue as a location on a map.
  /// </summary>
  public class IssueMapListItem
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="IssueMapListItem"/> class.
    /// </summary>
    public IssueMapListItem()
    {
    }

    /// <summary>
    /// Gets or sets the public identifier of the issue.
    /// </summary>
    public string ID { get; set; }

    /// <summary>
    /// Gets or sets the latitude coordinate of the issue.
    /// </summary>
    public double? Latitude { get; set; }

    /// <summary>
    /// Gets or sets the longitude coordinate of the issue.
    /// </summary>
    public double? Longitude { get; set; }

    /// <summary>
    /// Gets or sets the current status of the issue.
    /// </summary>
    public Status Status { get; set; }

    /// <summary>Returns a string that represents the current object.</summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
      return $"{ID}@{Latitude},{Longitude} ({Status})";
    }
  }
}