using System.Collections.Generic;

namespace Decos.Fixi
{
  /// <summary>
  /// Represents a polygon as an exterior ring with zero or more interior rings.
  /// </summary>
  /// <typeparam name="TLineString"></typeparam>
  public interface IPolygon<TLineString>
  {
    /// <summary>
    /// Gets or sets the line string that forms the exterior ring.
    /// </summary>
    TLineString ExteriorRing { get; set; }

    /// <summary>
    /// Gets or sets a collection of line strings that form the interior rings.
    /// </summary>
    IEnumerable<TLineString> InteriorRings { get; set; }
  }
}