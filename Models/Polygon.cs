using System;

namespace Decos.Fixi
{
  /// <summary>
  /// Represents a polygon.
  /// </summary>
  public class Polygon
  {
    /// <summary>
    /// Gets a value that indicates the total area covered by the polygon in
    /// square meters.
    /// </summary>
    public double? Area { get; set; }

    /// <summary>
    /// Gets a polyline-encoded string representing the polygon value.
    /// </summary>
    public string EncodedPolyline { get; set; }

    /// <summary>
    /// Sets a string containing the polygon value as a space-separated list of
    /// longitude and latitude coordinates (original Fixi format).
    /// </summary>
    public string FixiString { get; set; }

    /// <summary>
    /// Gets or sets the well-known text representation of the polygon value.
    /// </summary>
    public string WellKnownText { get; set; }
  }
}