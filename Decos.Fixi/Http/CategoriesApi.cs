using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Decos.Fixi.Http
{
  /// <summary>
  /// Represents a RESTful API client to manage categories in Fixi.
  /// </summary>
  public class CategoriesApi : RestApi, ICategoriesApi
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="CategoriesApi"/> class that uses the specified <see cref="HttpClient"/>.
    /// </summary>
    /// <param name="httpClient">An <see cref="HttpClient"/> for sending requests.</param>
    public CategoriesApi(HttpClient httpClient) : base(httpClient)
    {
    }

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
    public Task<ListPage<Category>> FindAsync(string region, bool? includeInactive = null, int page = 1, int count = 20, CancellationToken cancellationToken = default(CancellationToken))
    {
      var args = new { includeInactive, page, count };
      return GetAsync<ListPage<Category>>($"/regions/{Uri.EscapeDataString(region)}/categories", args, cancellationToken);
    }
  }
}
