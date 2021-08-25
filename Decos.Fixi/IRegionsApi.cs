using Decos.Fixi.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Decos.Fixi
{
  /// <summary>
  /// Defines the methods available in the regions API.
  /// </summary>
  public interface IRegionsApi
  {
    /// <summary>
    /// Adds a new region.
    /// </summary>
    /// <param name="data">The region data.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns the created region.</returns>
    Task<RegionResponse> AddAsync(RegionData data, CancellationToken cancellationToken);

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
    Task<ListPage<RegionResponse>> AtLocationAsync(double latitude, double longitude, int page = 1, int count = 20, CancellationToken cancellationToken = default(CancellationToken));

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
    Task<ListPage<RegionResponse>> FindAsync(bool? all = null, int page = 1, int count = 20, CancellationToken cancellationToken = default(CancellationToken));

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
    Task<ListPage<RegionResponse>> FindAsync(string organization, int page = 1, int count = 20, CancellationToken cancellationToken = default(CancellationToken));

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
    Task<ListPage<RegionResponse>> SearchAsync(string name = null, string organization = null, string emailAddress = null, bool? all = null, int page = 1, int count = 20, CancellationToken cancellationToken = default(CancellationToken));

    /// <summary>
    /// Returns the region with the specified short name.
    /// </summary>
    /// <param name="region">The short name of the region.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns the specified region.</returns>
    Task<RegionResponse> GetAsync(string region, CancellationToken cancellationToken);

    /// <summary>
    /// Returns the geometry data for a region as polyline-encoded strings.
    /// </summary>
    /// <param name="region">The short name of the region.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns a collection of <see cref="EncodedPolygon"/> objects.</returns>
    Task<IEnumerable<EncodedPolygon>> GetEncodedGeometryAsync(string region, CancellationToken cancellationToken);

    /// <summary>
    /// Returns the geometry data for a region as collections of points.
    /// </summary>
    /// <param name="region">The short name of the region.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns a collection of <see cref="RawPolygon"/> objects.</returns>
    Task<IEnumerable<RawPolygon>> GetRawGeometryAsync(string region, CancellationToken cancellationToken);

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
    Task<byte[]> GetWellKnownBinaryAsync(string region, CancellationToken cancellationToken);

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
    Task<string> GetWellKnownTextAsync(string region, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing region.
    /// </summary>
    /// <param name="region">The short name of the region.</param>
    /// <param name="data">The modified region data.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns the updated region.</returns>
    Task<RegionResponse> UpdateAsync(string region, RegionData data, CancellationToken cancellationToken);
  }
}