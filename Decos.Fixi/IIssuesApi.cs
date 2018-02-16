using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace Decos.Fixi
{
  public interface IIssuesApi
  {
    /// <summary>
    /// Returns the issue with the specified ID.
    /// </summary>
    /// <param name="id">The public issue ID.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>The issue with the specified ID.</returns>
    [Get("/issues/{id}")]
    Task<Issue> GetAsync(string id, CancellationToken cancellationToken);

    /// <summary>
    /// Returns a list of issues in descending order according to creation date.
    /// </summary>
    /// <param name="q">An optional search string.</param>
    /// <param name="searchPrivateInfo">
    /// <c>true</c> to search fields that may contain private information in
    /// addition to public information, or <c>false</c> to search only public information.
    /// </param>
    /// <param name="reportedBy">
    /// Optionally filters the results on reporter email address.
    /// </param>
    /// <param name="assignedTo">
    /// Optionally filters the results on handler email address or team short name.
    /// </param>
    /// <param name="category">
    /// Optionally filters the results on category short name. This parameter can
    /// be specified multiple times.
    /// </param>
    /// <param name="status">
    /// Optionally filters the results on status. This parameter can be specified
    /// multiple times.
    /// </param>
    /// <param name="from">
    /// If specified, only issues created on or after this date will be returned.
    /// </param>
    /// <param name="to">
    /// If specified, only issues created on or before this date will be returned.
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
    /// <returns>A task that returns a single page of issues.</returns>
    [Get("/issues?api-version=2.0")]
    Task<ListPage<IssueListItem>> FindAsync(
      string q = null,
      bool searchPrivateInfo = false,
      string reportedBy = null,
      string assignedTo = null,
      string[] category = null,
      Status[] status = null,
      DateTimeOffset? from = null,
      DateTimeOffset? to = null,
      int page = 1, int count = 20,
      CancellationToken cancellationToken = default(CancellationToken));

    /// <summary>
    /// Updates an existing issue.
    /// </summary>
    /// <param name="id">The public issue ID.</param>
    /// <param name="issueData">The modified issue data.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>The updated issue.</returns>
    [Patch("/issues/{id}")]
    Task<Issue> UpdateAsync(string id, IssueChanges issueData, CancellationToken cancellationToken);
  }
}