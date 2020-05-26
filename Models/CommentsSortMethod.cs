using System;

namespace Decos.Fixi.Models
{
  /// <summary>
  /// Indicates the method by which a collection of comments are sorted.
  /// </summary>
  public enum CommentsSortMethod
  {
    /// <summary>
    /// Comments are sorted in the default order.
    /// </summary>
    Default = 0,

    /// <summary>
    /// Comments are sorted by creation date in ascending order.
    /// </summary>
    OldestFirst,

    /// <summary>
    /// Comments are sorted by creation date in descending order.
    /// </summary>
    NewestFirst
  }
}