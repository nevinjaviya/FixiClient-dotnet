using Decos.Fixi.Models;
using System;
using System.Collections.Generic;
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
      return PostAsync<RegionData, RegionResponse>("/regions", data, cancellationToken);
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
      return GetAsync<ListPage<RegionResponse>>("/regions/atlocation", args, cancellationToken);
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
      return GetAsync<ListPage<RegionResponse>>("/regions", args, cancellationToken);
    }

    /// <summary>
    /// Returns a list of regions for the specified organization.
    /// </summary>
    /// <param name="organization">The short name of the organization.</param>
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
    public Task<ListPage<RegionResponse>> FindAsync(string organization, int page = 1, int count = 20, CancellationToken cancellationToken = default(CancellationToken))
    {
      var args = new { page, count };
      return GetAsync<ListPage<RegionResponse>>($"/organizations/{Uri.EscapeDataString(organization)}/regions", args, cancellationToken);
    }

    /// <summary>
    /// Returns a list of regions, ordered by name.
    /// </summary>
    /// <param name="name">Optional filter Region Name</param>
    /// <param name="organization">Optional filter Organization Name</param>
    /// <param name="emailAddress">Optional filter email address</param>
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
    public Task<ListPage<RegionResponse>> SearchAsync(string name = null, string organization = null, string emailAddress = null, bool? all = null, int page = 1, int count = 20, CancellationToken cancellationToken = default(CancellationToken))
    {
      var args = new { name, organization, emailAddress, all, page, count };
      return GetAsync<ListPage<RegionResponse>>("/regions/search", args, cancellationToken);
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
      return GetAsync<RegionResponse>($"/regions/{Uri.EscapeDataString(region)}", cancellationToken);
    }

    /// <summary>
    /// Returns the geometry data for a region as polyline-encoded strings.
    /// </summary>
    /// <param name="region">The short name of the region.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns an <see cref="EncodedPolygon"/> object.</returns>
    public Task<IEnumerable<EncodedPolygon>> GetEncodedGeometryAsync(string region, CancellationToken cancellationToken)
    {
      return GetAsync<IEnumerable<EncodedPolygon>>($"/regions/{Uri.EscapeDataString(region)}/geometry?format=encoded", cancellationToken);
    }

    /// <summary>
    /// Returns the geometry data for a region as collections of points.
    /// </summary>
    /// <param name="region">The short name of the region.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns a <see cref="RawPolygon"/> object.</returns>
    public Task<IEnumerable<RawPolygon>> GetRawGeometryAsync(string region, CancellationToken cancellationToken)
    {
      return GetAsync<IEnumerable<RawPolygon>>($"/regions/{Uri.EscapeDataString(region)}/geometry?format=raw", cancellationToken);
    }

    /// <summary>
    /// Returns the geometry data for a region as well-known binary (WKB).
    /// </summary>
    /// <param name="region">The short name of the region.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>
    /// A task that returns an array of bytes that contains the well-known text
    /// binary of <paramref name="region"/>.
    /// </returns>
    public async Task<byte[]> GetWellKnownBinaryAsync(string region, CancellationToken cancellationToken)
    {
      var base64 = await GetAsync<string>($"/regions/{Uri.EscapeDataString(region)}/geometry?format=wellKnownBinary", cancellationToken).ConfigureAwait(false);
      return Convert.FromBase64String(base64);
    }

    /// <summary>
    /// Returns the geometry data for a region as well-known text (WKT).
    /// </summary>
    /// <param name="region">The short name of the region.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>
    /// A task that returns a string that contains the well-known text
    /// representation of <paramref name="region"/>.
    /// </returns>
    public Task<string> GetWellKnownTextAsync(string region, CancellationToken cancellationToken)
    {
      return GetAsync<string>($"/regions/{Uri.EscapeDataString(region)}/geometry?format=wellKnownText", cancellationToken);
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
      return PatchAsync<RegionData, RegionResponse>($"/regions/{Uri.EscapeDataString(region)}", data, cancellationToken);
    }
  }
}