using System;
using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace Decos.Fixi
{
  /// <summary>
  /// Defines the methods available in the Fixi organizations API.
  /// </summary>
  public interface IOrganizationsApi
  {
    /// <summary>
    /// Returns a list of organizations, ordered by name.
    /// </summary>
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
    /// <returns>A task representing the asynchronous operation.</returns>
    [Get("/organizations?api-version=2.0")]
    Task<ListPage<Organization>> FindAsync(
        int page = 1,
        int count = 20,
        CancellationToken cancellationToken = default(CancellationToken));

    /// <summary>
    /// Returns the organization with the specified identifier.
    /// </summary>
    /// <param name="id">The short name of the organization to find.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Get("/organizations/{id}?api-version=1.0")]
    Task<Organization> FindByIdAsync(
        string id,
        CancellationToken cancellationToken = default(CancellationToken));

    /// <summary>
    /// Creates a new organization.
    /// </summary>
    /// <param name="data">The organization data.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Post("/organizations?api-version=1.0")]
    Task<Organization> PostAsync(
        Organization data,
        CancellationToken cancellationToken = default(CancellationToken));

    /// <summary>
    /// Updates an existing organization.
    /// </summary>
    /// <param name="id">The short name of the organization to update.</param>
    /// <param name="data">The modified organization data.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task representing the asynchronous operation.</returns>
    [Patch("/organizations/{id}?api-version=1.0")]
    Task<Organization> UpdateAsync(
        string id,
        Organization data,
        CancellationToken cancellationToken = default(CancellationToken));
  }
}