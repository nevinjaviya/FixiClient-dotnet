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
  /// Defines the methods available in the teams API.
  /// </summary>
  public interface ITeamsApi
  {
    /// <summary>
    /// Adds a handler to a team.
    /// </summary>
    /// <param name="organization">The short name of the organization.</param>
    /// <param name="team">The short name of the team.</param>
    /// <param name="emailAddress">Email address of a handler to add.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task returns a team to which a new member is added.</returns>
    [Post("/organizations/{organization}/teams/{team}/members/{emailAddress}")]
    Task<Team> AddMember(string organization, string team, string emailAddress, CancellationToken cancellationToken);

    /// <summary>
    /// Returns a list of teams, ordered by name.
    /// </summary>
    /// <param name="organization">The short name of an organization.</param>
    /// <param name="page">
    /// An optional non-zero positive integer indicating the number of the page
    /// to retrieve.
    /// </param>
    /// <param name="count">
    /// An optional non-zero positive integer indicating the number of results to
    /// return per page.
    /// </param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that returns a single page of teams.</returns>
    [Get("/organizations/{organization}/teams")]
    Task<ListPage<Team>> FindAsync(string organization, int page = 1, int count = 20, CancellationToken cancellationToken = default(CancellationToken));

    /// <summary>
    /// Returns the specified team.
    /// </summary>
    /// <param name="organization">The short name of an organization.</param>
    /// <param name="id">The short name of the team.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that returns a specified team.</returns>
    [Get("/organizations/{organization}/teams/{id}")]
    Task<Team> GetAsync(string organization, string id, CancellationToken cancellationToken = default(CancellationToken));

    /// <summary>
    /// Creates a new team and adds it to the organization.
    /// </summary>
    /// <param name="organization">The short name of the organization.</param>
    /// <param name="data">The team data.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that returns a created team.</returns>
    [Post("/organizations/{organization}/teams")]
    Task<Team> AddAsync(string organization, TeamData data, CancellationToken cancellationToken = default(CancellationToken));

    /// <summary>
    /// Updates an existing team.
    /// </summary>
    /// <param name="organization">The short name of the organization.</param>
    /// <param name="id">The short name of the team.</param>
    /// <param name="data">The modified team data.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that returns the updated team.</returns>
    [Patch("/organizations/{organization}/teams/{id}")]
    Task<Team> UpdateAsync(string organization, string id, TeamData data, CancellationToken cancellationToken = default(CancellationToken));
  }
}