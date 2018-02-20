using System;

namespace Decos.Fixi.Http
{
  /// <summary>
  /// Provides a set of static methods for building URI's.
  /// </summary>
  public static class UriUtility
  {
    /// <summary>
    /// Appends the specified query string parameters to the specified URI.
    /// </summary>
    /// <param name="uri">
    /// The URI to append to. The URI may be relative or absolute, and may
    /// contain a query string.
    /// </param>
    /// <param name="query">
    /// A collection of query string parameters to append to <paramref name="uri"/>.
    /// </param>
    /// <returns>
    /// A new string that represents <paramref name="uri"/> with additional query
    /// string parameters.
    /// </returns>
    public static string AddQuery(string uri, QueryStringParameterCollection query)
    {
      var queryFromPath = QueryStringParameterCollection.Parse(uri);

      var queryPosition = uri.LastIndexOf('?');
      if (queryPosition >= 0)
      {
        uri = uri.Substring(0, queryPosition);
      }

      var newQuery = queryFromPath.Add(query);
      return uri + '?' + newQuery;
    }
  }
}