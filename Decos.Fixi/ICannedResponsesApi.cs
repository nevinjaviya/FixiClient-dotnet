using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Decos.Fixi
{
  /// <summary>
  /// Defines the methods available in the canned responses API.
  /// </summary>
  public interface ICannedResponsesApi
  {
    /// <summary>
    /// Adds a new canned response for an organization.
    /// </summary>
    /// <param name="organizationId">
    /// The short name of the organization to add the canned response for.
    /// </param>
    /// <param name="data">
    /// An object that represents the canned response to add.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns the created canned response.</returns>
    Task<CannedResponse> CreateAsync(string organizationId, CannedResponseData data, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes a canned response for an organization.
    /// </summary>
    /// <param name="organizationId">
    /// The short name of the organization that has the canned response.
    /// </param>
    /// <param name="cannedResponseId">
    /// The short name of the canned response to delete.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns the deleted canned response.</returns>
    Task<CannedResponse> DeleteAsync(string organizationId, string cannedResponseId, CancellationToken cancellationToken);

    /// <summary>
    /// Returns a list of canned responses for an organization.
    /// </summary>
    /// <param name="organizationId">The short name of the organization.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns a collection of canned responses.</returns>
    Task<IEnumerable<CannedResponse>> FindAsync(string organizationId, CancellationToken cancellationToken);

    /// <summary>
    /// Returns a canned response for an organization.
    /// </summary>
    /// <param name="organizationId">
    /// The short name of the organization that has the canned response.
    /// </param>
    /// <param name="cannedResponseId">
    /// The short name of the canned response to retrieve.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns the canned response.</returns>
    Task<CannedResponse> GetAsync(string organizationId, string cannedResponseId, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing canned response for an organization.
    /// </summary>
    /// <param name="organizationId">
    /// The short name of the organization that has the canned response.
    /// </param>
    /// <param name="cannedResponseId">
    /// The short name of the canned response to update.
    /// </param>
    /// <param name="data">An object that contains the updated property values.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns the updated canned response.</returns>
    Task<CannedResponse> UpdateAsync(string organizationId, string cannedResponseId, CannedResponseData data, CancellationToken cancellationToken);
  }
}