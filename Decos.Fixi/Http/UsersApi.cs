using Decos.Fixi.Models;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Decos.Fixi.Http
{
  /// <summary>
  /// Represents a RESTful API client to manage users in Fixi.
  /// </summary>
  public class UsersApi : RestApi, IUsersApi
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="UsersApi"/> class that uses
    /// the specified <see cref="HttpClient"/>.
    /// </summary>
    /// <param name="httpClient">An <see cref="HttpClient"/> for sending requests.</param>
    public UsersApi(HttpClient httpClient) : base(httpClient)
    {
    }

    /// <summary>
    /// Retrieves the currently logged-in user.
    /// </summary>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns the currently-logged in user.</returns>
    public Task<User> GetCurrentUserAsync(CancellationToken cancellationToken)
    {
      return GetAsync<User>("/users/me?api-version=1.0", null, cancellationToken);
    }

    /// <summary>
    /// Creates or updates information for the currently logged-in user.
    /// </summary>
    /// <param name="data">A <see cref="UserData"/> object containing the changes.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns the updated user.</returns>
    public Task<User> UpdateCurrentUserAsync(UserData data, CancellationToken cancellationToken)
    {
      return PostAsync<UserData, User>("/users/me?api-version=1.0", data, cancellationToken);
    }
  }
}