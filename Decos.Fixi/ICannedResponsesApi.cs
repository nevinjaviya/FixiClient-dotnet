using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Decos.Fixi.Models;
using Refit;

namespace Decos.Fixi
{
  /// <summary>
  /// Defines the methods available in the canned responses API.
  /// </summary>
  public interface ICannedResponsesApi
  {
    /// <summary>
    /// Returns a list of canned responses.
    /// </summary>
    /// <param name="id">The short name of an organization.</param>
    /// <param name="selectedCategory">
    /// The short name of the selected category. Leave out to show all canned responses.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>
    /// A task that returns the list of canned responses.
    /// </returns>
    [Get("/organization/{id}/cannedresponses?api-version=1.0")]
    Task<IEnumerable<CannedResponse>> FindAsync(string id, string selectedCategory = null, CancellationToken cancellationToken = default(CancellationToken));

    /// <summary>
    /// Returns a canned response.
    /// </summary>
    /// <param name="id">The short name of an organization.</param>
    /// <param name="name">The short name of the canned response.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that returns a specified canned response.</returns>
    [Get("/organization/{id}/cannedresponses/{name}?api-version=1.0")]
    Task<CannedResponse> GetAsync(string id, string name, CancellationToken cancellationToken = default(CancellationToken));

    /// <summary>
    /// Adds a new canned response.
    /// </summary>
    /// <param name="id">The short name of the organization.</param>
    /// <param name="data">The canned response data.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that returns a created canned response.</returns>
    [Post("/organization/{id}/cannedresponses?api-version=1.0")]
    Task<CannedResponse> AddAsync(string id, CannedResponseData data, CancellationToken cancellationToken = default(CancellationToken));

    /// <summary>
    /// Updates an existing canned response.
    /// </summary>
    /// <param name="id">The short name of the organization.</param>
    /// <param name="name">The short name of the canned response.</param>
    /// <param name="data">The modified data.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that returns the updated canned response.</returns>
    [Patch("/organization/{id}/cannedresponses/{name}?api-version=1.0")]
    Task<CannedResponse> UpdateAsync(string id, string name, CannedResponseData data, CancellationToken cancellationToken = default(CancellationToken));
  }
}