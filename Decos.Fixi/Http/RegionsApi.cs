using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Decos.Fixi.Http
{
  /// <summary>
  /// Represents a RESTful API client to manage regions in Fixi.
  /// </summary>
  public class RegionsApi : RestApi, IRegionsApi
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="RegionsApi"/> class that
    /// uses the specified <see cref="HttpClient"/>.
    /// </summary>
    /// <param name="httpClient">An <see cref="HttpClient"/> for sending requests.</param>
    public RegionsApi(HttpClient httpClient) : base(httpClient)
    {
    }

    /// <summary>
    /// Adds a new region.
    /// </summary>
    /// <param name="data">The region data.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns the created region.</returns>
    public Task<RegionResponse> AddAsync(RegionData data, CancellationToken cancellationToken)
    {
      return PostAsync<RegionData, RegionResponse>("/regions?api-version=2.0", data, cancellationToken);
    }

    /// <summary>
    /// Returns a list of regions at the specified location.
    /// </summary>
    /// <param name="latitude">The latitude coordinate.</param>
    /// <param name="longitude">The longitude coordinate.</param>
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
    /// <returns>A task that returns a single page of regions.</returns>
    public Task<ListPage<RegionResponse>> AtLocationAsync(double latitude, double longitude, int page = 1, int count = 20, CancellationToken cancellationToken = default(CancellationToken))
    {
      var args = new { latitude, longitude, page, count };
      return GetAsync<ListPage<RegionResponse>>("/regions/atlocation?api-version=2.0", args, cancellationToken);
    }

    /// <summary>
    /// Returns a list of regions, ordered by name.
    /// </summary>
    /// <param name="all">
    /// If <c>true</c>, only regions for the current organization are retrieved.
    /// The current organization is determined by the <c>X-Customer-ID</c>
    /// header. The default value is <c>true</c>.
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
    /// <returns>A task that returns a single page of regions.</returns>
    public Task<ListPage<RegionResponse>> FindAsync(bool? all = null, int page = 1, int count = 20, CancellationToken cancellationToken = default(CancellationToken))
    {
      var args = new { all, page, count };
      return GetAsync<ListPage<RegionResponse>>("/regions?api-version=2.0", args, cancellationToken);
    }

    /// <summary>
    /// Returns the region with the specified short name.
    /// </summary>
    /// <param name="region">The short name of the region.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns the specified region.</returns>
    public Task<RegionResponse> GetAsync(string region, CancellationToken cancellationToken)
    {
      return GetAsync<RegionResponse>($"/regions/{Uri.EscapeDataString(region)}?api-version=2.0", cancellationToken);
    }

    /// <summary>
    /// Updates an existing region.
    /// </summary>
    /// <param name="region">The short name of the region.</param>
    /// <param name="data">The modified region data.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns the updated region.</returns>
    public Task<RegionResponse> UpdateAsync(string region, RegionData data, CancellationToken cancellationToken)
    {
      return PatchAsync<RegionData, RegionResponse>($"/regions/{Uri.EscapeDataString(region)}?api-version=2.0", data, cancellationToken);
    }
  }
}