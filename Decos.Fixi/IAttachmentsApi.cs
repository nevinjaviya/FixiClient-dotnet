using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace Decos.Fixi
{
  /// <summary>
  /// Defines the methods available in the Fixi attachments API.
  /// </summary>
  public interface IAttachmentsApi
  {
    /// <summary>
    /// Uploads file attachments to an issue.
    /// </summary>
    /// <param name="issue">The ID of the issue.</param>
    /// <param name="file">
    /// An object that represents an item in a multipart form data request.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>
    /// An asynchronous operation that returns a collection of the uploaded attachments.
    /// </returns>
    [Multipart]
    [Post("/issues/{issue}/attachments")]
    Task<IEnumerable<Attachment>> UploadAsync(string issue, MultipartItem file, CancellationToken cancellationToken);
  }
}