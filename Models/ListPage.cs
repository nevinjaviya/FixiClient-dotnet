using System;
using System.Collections.Generic;

namespace Decos.Fixi
{
  /// <summary>
  /// Represents a single page of results.
  /// </summary>
  /// <typeparam name="T">The type of element in the list.</typeparam>
  public class ListPage<T>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ListPage{T}"/> class.
    /// </summary>
    public ListPage()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ListPage{T}"/> class with
    /// the specified values.
    /// </summary>
    /// <param name="count">The total number of elements across all pages.</param>
    /// <param name="results">A collection of the elements on this page.</param>
    public ListPage(int count, IEnumerable<T> results)
    {
      if (results == null)
        throw new ArgumentNullException(nameof(results));

      Count = count;
      Results = new List<T>(results);
    }

    /// <summary>
    /// Gets or sets the total number of results across all pages.
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Gets or sets a collection of the results on the page.
    /// </summary>
    public IReadOnlyCollection<T> Results { get; set; }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
      var resultCount = Results?.Count ?? 0;
      return $"{resultCount} result(s), {Count} total";
    }
  }
}