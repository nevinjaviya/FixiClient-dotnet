using System.Net.Http;

namespace Decos.Fixi
{
  /// <summary>
  /// Defines a client that connects to the Fixi APIs.
  /// </summary>
  public interface IFixiClient
  {
    /// <summary>
    /// Gets a reference to the attachments API.
    /// </summary>
    IAttachmentsApi Attachments { get; }

    /// <summary>
    /// Gets an <see cref="HttpClient"/> used to send HTTP requests.
    /// </summary>
    HttpClient HttpClient { get; }

    /// <summary>
    /// Gets a reference to the issues API.
    /// </summary>
    IIssuesApi Issues { get; }

    /// <summary>
    /// Gets a reference to the organizations API.
    /// </summary>
    IOrganizationsApi Organizations { get; }

    /// <summary>
    /// Gets a reference to the regions API.
    /// </summary>
    IRegionsApi Regions { get; }

    /// <summary>
    /// Gets a reference to the teams API.
    /// </summary>
    ITeamsApi Teams { get; }

    /// <summary>
    /// Gets a reference to the users API.
    /// </summary>
    IUsersApi Users { get; }
  }
}