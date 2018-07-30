using System;
using System.Collections.Generic;

namespace Decos.Fixi
{
  /// <summary>
  /// Represents a polygon where the rings are encoded according to
  /// Google's polyline encoding algorithm.
  /// </summary>
  public class EncodedPolygon : IPolygon<string>
  {
    /// <summary>
    /// Gets or sets a polyline-encoded string that represents the exterior ring.
    /// </summary>
    public string ExteriorRing { get; set; }

    /// <summary>
    /// Gets or sets a collection of polyline-encoded strings that form the interior rings.
    /// </summary>
    public IEnumerable<string> InteriorRings { get; set; }
  }
}