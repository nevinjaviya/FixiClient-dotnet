using System;

namespace Decos.Fixi.Models
{
  /// <summary>
  /// Represents the accepted formats for updating a region's polygon.
  /// </summary>
  public class Polygon
  {
    /// <summary>
    /// Gets or sets a string containing the polygon value as a space-separated
    /// list of longitude and latitude coordinates (original Fixi format).
    /// </summary>
    public string FixiString { get; set; }

    /// <summary>
    /// Gets or sets the well-known text representation of the polygon value.
    /// </summary>
    public string WellKnownText { get; set; }
  }
}