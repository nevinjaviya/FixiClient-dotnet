using Decos.Fixi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Decos.Fixi
{
  /// <summary>
  /// Defines the methods available in the issues API.
  /// </summary>
  public interface IIssuesApi
  {
    /// <summary>
    /// Creates a new issue.
    /// </summary>
    /// <param name="issueData">The issue data.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that returns the created issue.</returns>
    Task<Issue> CreateAsync(
        IssueData issueData,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes the issue with the specified ID.
    /// </summary>
    /// <param name="id">The issue ID of the issue the delete.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="id"/> is <c>null</c>.</exception>
    Task DeleteIssueAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Generates an Excel overview of a list of issues assigned to the logged-in user's teams and writes the result to the specified stream.
    /// </summary>
    /// <param name="destination">The stream to which the Excel worksheet will be written.</param>
    /// <param name="q">An optional search string.</param>
    /// <param name="reportedBy">Optionally filters the results on reporter email address.</param>
    /// <param name="assignedTo">Optionally filters the results on handler email address or team short name.</param>
    /// <param name="category">Optionally filters the results on category short name. This parameter can be specified multiple times.</param>
    /// <param name="status">Optionally filters the results on status. This parameter can be specified multiple times.</param>
    /// <param name="from">If specified, only issues created on or after this date will be included.</param>
    /// <param name="to">If specified, only issues created on or before this date will be included.</param>
    /// <param name="isManaged">If specified, filters issues based on whether the associated region is managed by an organization.</param>
    /// <param name="hasRegion">If specified, filters issues based on whether a region is associated.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task ExportTeamIssuesToStreamAsync(
        Stream destination,
        string q = null,
        string reportedBy = null,
        string assignedTo = null,
        string[] category = null,
        Status[] status = null,
        DateTimeOffset? from = null,
        DateTimeOffset? to = null,
        bool? isManaged = null,
        bool? hasRegion = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Generates an Excel overview of a list of issues and writes the result to the specified stream.
    /// </summary>
    /// <param name="destination">The stream to which the Excel worksheet will be written.</param>
    /// <param name="q">An optional search string.</param>
    /// <param name="id">An optional Fixi ID. </param>
    /// <param name="description">Issue description (optional)</param>
    /// <param name="organization">Organization short name (optional)</param>
    /// <param name="address">Address (optional)</param>
    /// <param name="reporterName">Issue reporter name (optional)</param>
    /// <param name="reporterEmail">Issue reporter email address (optional)</param>
    /// <param name="createdDate">Issue created date (optional)</param>
    /// <param name="searchPrivateInfo"><c>true</c> to search fields that may contain private information in addition to public information, or <c>false</c> to search only public information.</param>
    /// <param name="reportedBy">Optionally filters the results on reporter email address.</param>
    /// <param name="assignedTo">Optionally filters the results on handler email address or team short name.</param>
    /// <param name="category">Optionally filters the results on category short name. This parameter can be specified multiple times.</param>
    /// <param name="status">Optionally filters the results on status. This parameter can be specified multiple times.</param>
    /// <param name="from">If specified, only issues created on or after this date will be included.</param>
    /// <param name="to">If specified, only issues created on or before this date will be included.</param>
    /// <param name="isManaged">If specified, filters issues based on whether the associated region is managed by an organization.</param>
    /// <param name="hasRegion">If specified, filters issues based on whether a region is associated.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task ExportToStreamAsync(
        Stream destination,
        string q = null,
        string id = null,
        string description = null,
        string organization = null,
        string address = null,
        string reporterName = null,
        string reporterEmail = null,
        DateTimeOffset? createdDate = null,
        bool searchPrivateInfo = false,
        string reportedBy = null,
        string assignedTo = null,
        string[] category = null,
        Status[] status = null,
        DateTimeOffset? from = null,
        DateTimeOffset? to = null,
        bool? isManaged = null,
        bool? hasRegion = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a list of issues in descending order according to creation date.
    /// </summary>
    /// <param name="q">An optional search string.</param>
    /// <param name="searchPrivateInfo"><c>true</c> to search fields that may contain private information in addition to public information, or <c>false</c> to search only public information.</param>
    /// <param name="reportedBy">Optionally filters the results on reporter email address.</param>
    /// <param name="assignedTo">Optionally filters the results on handler email address or team short name.</param>
    /// <param name="region">Optionally filters the results on region short name. This parameter can be specified multiple times.</param>
    /// <param name="category">Optionally filters the results on category short name. This parameter can be specified multiple times.</param>
    /// <param name="status">Optionally filters the results on status. This parameter can be specified multiple times.</param>
    /// <param name="from">If specified, only issues created on or after this date will be returned.</param>
    /// <param name="to">If specified, only issues created on or before this date will be returned.</param>
    /// <param name="isManaged">If specified, filters issues based on whether the associated region is managed by an organization.</param>
    /// <param name="hasRegion">If specified, filters issues based on whether a region is associated.</param>
    /// <param name="page">An optional non-zero positive integer indicating the number of the page to retrieve.</param>
    /// <param name="count">An optional non-zero positive integer indicating the number of results to return per page.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that returns a single page of issues.</returns>
    Task<ListPage<IssueListItem>> FindAsync(
        string q = null,
        bool searchPrivateInfo = false,
        string reportedBy = null,
        string assignedTo = null,
        string[] region = null,
        string[] category = null,
        Status[] status = null,
        DateTimeOffset? from = null,
        DateTimeOffset? to = null,
        bool? isManaged = null,
        bool? hasRegion = null,
        int page = 1, int count = 20,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a lite list of issues in descending order according to creation date.
    /// </summary>
    /// <param name="q">An optional search string.</param>
    /// <param name="id">An optional Fixi ID. </param>
    /// <param name="description">Issue description (optional)</param>
    /// <param name="organization">Organization short name (optional)</param>
    /// <param name="address">Address (optional)</param>
    /// <param name="reporterName">Issue reporter name (optional)</param>
    /// <param name="reporterEmail">Issue reporter email address (optional)</param>
    /// <param name="createdDate">Issue created date (optional)</param>
    /// <param name="searchPrivateInfo"><c>true</c> to search fields that may contain private information in addition to public information, or <c>false</c> to search only public information.</param>
    /// <param name="reportedBy">Optionally filters the results on reporter email address.</param>
    /// <param name="assignedTo">Optionally filters the results on handler email address or team short name.</param>
    /// <param name="region">Optionally filters the results on region short name. This parameter can be specified multiple times.</param>
    /// <param name="category">Optionally filters the results on category short name. This parameter can be specified multiple times.</param>
    /// <param name="status">Optionally filters the results on status. This parameter can be specified multiple times.</param>
    /// <param name="from">If specified, only issues created on or after this date will be returned.</param>
    /// <param name="to">If specified, only issues created on or before this date will be returned.</param>
    /// <param name="isManaged">If specified, filters issues based on whether the associated region is managed by an organization.</param>
    /// <param name="hasRegion">If specified, filters issues based on whether a region is associated.</param>
    /// <param name="page">An optional non-zero positive integer indicating the number of the page to retrieve.</param>
    /// <param name="count">An optional non-zero positive integer indicating the number of results to return per page.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that returns a single page of issues.</returns>
    Task<ListPage<IssueListItem>> FindLiteListAsync(
        string q = null,
        string id = null,
        string description = null,
        string organization = null,
        string address = null,
        string reporterName = null,
        string reporterEmail = null,
        DateTimeOffset? createdDate = null,
        bool searchPrivateInfo = false,
        string reportedBy = null,
        string assignedTo = null,
        string[] region = null,
        string[] category = null,
        Status[] status = null,
        DateTimeOffset? from = null,
        DateTimeOffset? to = null,
        bool? isManaged = null,
        bool? hasRegion = null,
        int page = 1, int count = 20,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the issue with the specified ID.
    /// </summary>
    /// <param name="id">The public issue ID.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that returns the issue with the specified ID.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="id"/> is <c>null</c>.</exception>
    Task<Issue> GetAsync(
        string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a list of the IDs of deleted issues.
    /// </summary>
    /// <param name="since">If specified, only issues deleted since this date/time will be included in the search.</param>
    /// <param name="page">An optional non-zero positive integer indicating the number of the page to retrieve.</param>
    /// <param name="count">An optional non-zero positive integer indicating the number of results to return per page.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that returns a list of the IDs of deleted issues.</returns>
    Task<IEnumerable<string>> GetDeletedIssueIdsAsync(
        DateTimeOffset? since = null,
        int page = 1,
        int count = 1000,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a list of issues within the specified bounds in descending order
    /// according to creation date.
    /// </summary>
    /// <param name="north">The latitude coordinate of the north border.</param>
    /// <param name="east">The longitude coordinate of the east border.</param>
    /// <param name="south">The latitude coordinate of the south border.</param>
    /// <param name="west">The longitude coordinate of the west border.</param>
    /// <param name="category">Optionally filters the results on category short name. This parameter can be specified multiple times.</param>
    /// <param name="status">Optionally filters the results on status. This parameter can be specified multiple times.</param>
    /// <param name="from">If specified, only issues created on or after this date will be returned.</param>
    /// <param name="to">If specified, only issues created on or before this date will be returned.</param>
    /// <param name="isManaged">If specified, filters issues based on whether the associated region is managed by an organization.</param>
    /// <param name="hasRegion">If specified, filters issues based on whether a region is associated.</param>
    /// <param name="page">An optional non-zero positive integer indicating the number of the page to retrieve.</param>
    /// <param name="count">An optional non-zero positive integer indicating the number of results to return per page.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that returns a single page of issues.</returns>
    Task<ListPage<IssueMapListItem>> GetMapIssuesAsync(
        double north,
        double east,
        double south,
        double west,
        string[] category = null,
        Status[] status = null,
        DateTimeOffset? from = null,
        DateTimeOffset? to = null,
        bool? isManaged = null,
        bool? hasRegion = null,
        int page = 1,
        int count = 200,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a list of issues near the specified location.
    /// </summary>
    /// <param name="latitude">The latitude coordinate.</param>
    /// <param name="longitude">The longitude coordinate.</param>
    /// <param name="radius">The radius in meters.</param>
    /// <param name="q">An optional search string.</param>
    /// <param name="searchPrivateInfo"><c>true</c> to search fields that may contain private information in addition to public information, or <c>false</c> to search only public information.</param>
    /// <param name="reportedBy">Optionally filters the results on reporter email address.</param>
    /// <param name="assignedTo">Optionally filters the results on handler email address or team short name.</param>
    /// <param name="category">Optionally filters the results on category short name. This parameter can be specified multiple times.</param>
    /// <param name="status">Optionally filters the results on status. This parameter can be specified multiple times.</param>
    /// <param name="from">If specified, only issues created on or after this date will be returned.</param>
    /// <param name="to">If specified, only issues created on or before this date will be returned.</param>
    /// <param name="isManaged">If specified, filters issues based on whether the associated region is managed by an organization.</param>
    /// <param name="hasRegion">If specified, filters issues based on whether a region is associated.</param>
    /// <param name="sort">The sorting order.</param>
    /// <param name="page">An optional non-zero positive integer indicating the number of the page to retrieve.</param>
    /// <param name="count">An optional non-zero positive integer indicating the number of results to return per page.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that returns a list of issues near the specified location.</returns>
    Task<ListPage<IssueListItem>> GetNearbyIssuesAsync(
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
        bool? isManaged = null,
        bool? hasRegion = null,
        SortOrder sort = SortOrder.Default,
        int page = 1,
        int count = 20,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a list of issues assigned to the logged-in user's teams.
    /// </summary>
    /// <param name="q">An optional search string.</param>
    /// <param name="reportedBy">Optionally filters the results on reporter email address.</param>
    /// <param name="assignedTo">Optionally filters the results on handler email address or team short name.</param>
    /// <param name="category">Optionally filters the results on category short name. This parameter can be specified multiple times.</param>
    /// <param name="status">Optionally filters the results on status. This parameter can be specified multiple times.</param>
    /// <param name="from">If specified, only issues created on or after this date will be returned.</param>
    /// <param name="to">If specified, only issues created on or before this date will be returned.</param>
    /// <param name="isManaged">If specified, filters issues based on whether the associated region is managed by an organization.</param>
    /// <param name="hasRegion">If specified, filters issues based on whether a region is associated.</param>
    /// <param name="page">An optional non-zero positive integer indicating the number of the page to retrieve.</param>
    /// <param name="count">An optional non-zero positive integer indicating the number of results to return per page.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that returns a list of issues assigned to any of the logged-in user's teams.</returns>
    Task<ListPage<IssueListItem>> GetTeamIssuesAsync(
        string q = null,
        string reportedBy = null,
        string assignedTo = null,
        string[] category = null,
        Status[] status = null,
        DateTimeOffset? from = null,
        DateTimeOffset? to = null,
        bool? isManaged = null,
        bool? hasRegion = null,
        int page = 1,
        int count = 20,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing issue.
    /// </summary>
    /// <param name="id">The public issue ID.</param>
    /// <param name="issueData">The modified issue data.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that returns the updated issue.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="id"/> is <c>null</c>.</exception>
    Task<Issue> UpdateAsync(string id, IssueData issueData, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes the issue with the specified ID.
    /// </summary>
    /// <param name="ids">The issue ID of the issue the delete.</param>
    /// <param name="isSoftDelete">To delete softly or permanently</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="ids"/> is <c>null</c>.</exception>
    Task DeleteIssuesAsync(string[] ids, bool isSoftDelete = true, CancellationToken cancellationToken = default);
  }
}