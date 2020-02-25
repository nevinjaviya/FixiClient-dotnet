using System;

namespace Decos.Fixi.Models
{
  /// <summary>
  /// Indicates the order in which results are returned.
  /// </summary>
  public enum SortOrder
  {
    /// <summary>
    /// Results are not sorted in any particular order.
    /// </summary>
    Default,

    /// <summary>
    /// Results are sorted by creation date, with the most recent item first.
    /// </summary>
    NewestFirst,

    /// <summary>
    /// Results are sorted by distance from a location, with the closest item first.
    /// </summary>
    ClosestFirst
  }
}