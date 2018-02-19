using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Decos.Fixi.Http
{
  public class IssuesApi : RestApi, IIssuesApi
  {
    public IssuesApi(HttpClient httpClient) : base(httpClient)
    {
    }

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
    public Task<ListPage<IssueListItem>> FindAsync(
        string q = null,
        bool searchPrivateInfo = false,
        string reportedBy = null,
        string assignedTo = null,
        string[] category = null,
        Status[] status = null,
        DateTimeOffset? from = null,
        DateTimeOffset? to = null,
        int page = 1,
        int count = 20,
        CancellationToken cancellationToken = default(CancellationToken))
    {
      var args = new { q, searchPrivateInfo, reportedBy, assignedTo, category, status, from, to, page, count };
      return GetAsync<ListPage<IssueListItem>>("/issues?api-version=2.0", args, cancellationToken);
    }

    public Task<Issue> GetAsync(string id, CancellationToken cancellationToken)
    {
      return GetAsync<Issue>($"/issues/{id}", cancellationToken);
    }

    /// <summary>
    /// Returns a list of issues within the specified bounds in descending order
    /// according to creation date.
    /// </summary>
    /// <param name="north">The latitude coordinate of the north border.</param>
    /// <param name="east">The longitude coordinate of the east border.</param>
    /// <param name="south">The latitude coordinate of the south border.</param>
    /// <param name="west">The longitude coordinate of the west border.</param>
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
    /// A token to observe for cancellation requests.
    /// </param>
    /// <returns>A task that returns a single page of issues.</returns>
    public Task<ListPage<IssueMapListItem>> GetMapIssuesAsync(
        double north,
        double east,
        double south,
        double west,
        string[] category = null,
        Status[] status = null,
        DateTimeOffset? from = null,
        DateTimeOffset? to = null,
        int page = 1,
        int count = 200,
        CancellationToken cancellationToken = default(CancellationToken))
    {
      var args = new { north, east, south, west, category, status, from, to, page, count };
      return GetAsync<ListPage<IssueMapListItem>>("/issues/map?api-version=2.0", args, cancellationToken);
    }

    /// <summary>
    /// Returns a list of issues near the specified location.
    /// </summary>
    /// <param name="latitude">The latitude coordinate.</param>
    /// <param name="longitude">The longitude coordinate.</param>
    /// <param name="radius">The radius in meters.</param>
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
    /// <param name="sort">The sorting order.</param>
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
    /// <returns>
    /// A task that returns a list of issues near the specified location.
    /// </returns>
    public Task<ListPage<IssueListItem>> GetNearbyIssuesAsync(
        double latitude,
        double longitude,
        double radius,
        string q = null,
        bool searchPrivateInfo = false,
        string reportedBy = null,
        string assignedTo = null,
        string[] category = null,
        Status[] status = null,
        DateTimeOffset? from = null,
        DateTimeOffset? to = null,
        SortOrder sort = SortOrder.Default,
        int page = 1,
        int count = 20,
        CancellationToken cancellationToken = default(CancellationToken))
    {
      var args = new { latitude, longitude, radius, q, searchPrivateInfo, reportedBy, assignedTo, category, status, from, to, sort, page, count };
      return GetAsync<ListPage<IssueListItem>>("/issues/nearby?api-version=2.0", args, cancellationToken);
    }

    /// <summary>
    /// Returns a list of issues assigned to the logged-in user's teams.
    /// </summary>
    /// <param name="q">An optional search string.</param>
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
    /// A token to observe for cancellation requests.
    /// </param>
    /// <returns>
    /// A task that returns a list of issues assigned to any of the logged-in
    /// user's teams.
    /// </returns>
    public Task<ListPage<IssueListItem>> GetTeamIssuesAsync(
        string q = null,
        string reportedBy = null,
        string assignedTo = null,
        string[] category = null,
        Status[] status = null,
        DateTimeOffset? from = null,
        DateTimeOffset? to = null,
        int page = 1,
        int count = 20,
        CancellationToken cancellationToken = default(CancellationToken))
    {
      var args = new { q, reportedBy, assignedTo, category, status, from, to, page, count };
      return GetAsync<ListPage<IssueListItem>>("/issues/team?api-version=2.0", args, cancellationToken);
    }

    public Task<Issue> UpdateAsync(string id, IssueChanges issueData, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }
}