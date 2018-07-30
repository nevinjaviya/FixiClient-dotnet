using System;
using System.Collections.Generic;

namespace Decos.Fixi
{
  /// <summary>
  /// Represents a polygon where the rings are represented as collections of points.
  /// </summary>
  public class RawPolygon : IPolygon<PointCollection>
  {
    /// <summary>
    /// Gets or sets a collection of points that forms the exterior ring.
    /// </summary>
    public PointCollection ExteriorRing { get; set; }

    /// <summary>
    /// Gets or sets a collection of the collections of points that form the
    /// interior rings.
    /// </summary>
    public IEnumerable<PointCollection> InteriorRings { get; set; }
  }
}