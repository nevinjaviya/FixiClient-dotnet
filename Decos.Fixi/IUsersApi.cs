using System;
using System.Threading;
using System.Threading.Tasks;

namespace Decos.Fixi
{
  /// <summary>
  /// Defines the methods available in the users API.
  /// </summary>
  public interface IUsersApi
  {
    /// <summary>
    /// Retrieves the currently logged-in user.
    /// </summary>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns the currently-logged in user.</returns>
    Task<User> GetCurrentUserAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Creates or updates information for the currently logged-in user.
    /// </summary>
    /// <param name="data">A <see cref="UserData"/> object containing the changes.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns the updated user.</returns>
    Task<User> UpdateCurrentUserAsync(UserData data, CancellationToken cancellationToken);
  }
}