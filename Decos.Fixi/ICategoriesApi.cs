using System;
using System.Threading;
using System.Threading.Tasks;

namespace Decos.Fixi
{
  /// <summary>
  /// Defines the methods available in the categories API.
  /// </summary>
  public interface ICategoriesApi
  {
    /// <summary>
    /// Returns a list of categories in a region, ordered by priority and name.
    /// </summary>
    /// <param name="region">The short name of the region.</param>
    /// <param name="includeInactive">
    /// If <c>true</c>, deactivated categories are also retrieved. The default
    /// value is <c>false</c>.
    /// </param>
    /// <param name="page">
    /// An optional non-zero positive integer indicating the number of the page
    /// to retrieve.
    /// </param>
    /// <param name="count">
    /// An optional non-zero positive integer indicating the number of results to
    /// return per page.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns a single page of categories.</returns>
    Task<ListPage<Category>> FindAsync(string region, bool? includeInactive = null, int page = 1, int count = 20, CancellationToken cancellationToken = default(CancellationToken));
  }
}