using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Decos.Fixi.Http
{
  /// <summary>
  /// Represents a RESTful API client to manage canned responses for an organization.
  /// </summary>
  public class CannedResponsesApi : RestApi, ICannedResponsesApi
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="CannedResponsesApi"/> class
    /// that uses the specified <see cref="System.Net.Http.HttpClient"/>.
    /// </summary>
    /// <param name="httpClient">
    /// An <see cref="System.Net.Http.HttpClient"/> for sending requests.
    /// </param>
    public CannedResponsesApi(System.Net.Http.HttpClient httpClient) : base(httpClient)
    {
    }

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
    public Task<CannedResponse> CreateAsync(string organizationId, CannedResponseData data, CancellationToken cancellationToken)
    {
      return PostAsync<CannedResponseData, CannedResponse>($"organization/{Uri.EscapeDataString(organizationId)}/cannedresponses", data, cancellationToken);
    }

    public Task<CannedResponse> DeleteAsync(string organizationId, string cannedResponseId, CancellationToken cancellationToken)
    {
      return DeleteAsync<CannedResponse>($"organization/{Uri.EscapeDataString(organizationId)}/cannedresponses/{Uri.EscapeDataString(cannedResponseId)}", cancellationToken);
    }

    public Task<IEnumerable<CannedResponse>> FindAsync(string organizationId, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public new Task<CannedResponse> GetAsync(string organizationId, string cannedResponseId, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task<CannedResponse> UpdateAsync(string organizationId, string cannedResponseId, CannedResponseData data, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }
}