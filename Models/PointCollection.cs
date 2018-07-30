using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Decos.Fixi
{
  /// <summary>
  /// Represents a collection of points.
  /// </summary>
  public class PointCollection : Collection<Point>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="PointCollection"/> class.
    /// </summary>
    public PointCollection()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PointCollection"/> class as
    /// a wrapper for the specified list.
    /// </summary>
    /// <param name="list">The list that is wrapped by the new collection.</param>
    public PointCollection(IList<Point> list) : base(list)
    {
    }
  }
}