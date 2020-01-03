using System;

namespace Decos.Fixi.Models
{
  /// <summary>
  /// Represents an attachment to an issue.
  /// </summary>
  public class Attachment
  {
    /// <summary>
    /// Gets or sets name of the blob.
    /// </summary>
    public string BlobName { get; set; }

    /// <summary>
    /// Gets or sets the point in time the attachment was added.
    /// </summary>
    public DateTimeOffset? Created { get; set; }

    /// <summary>
    /// Gets or sets the original file name of the attachment.
    /// </summary>
    public string FileName { get; set; }

    /// <summary>
    /// Gets or sets the content type of the attachment.
    /// </summary>
    public string MimeType { get; set; }

    /// <summary>
    /// Gets or sets the point in time the attachment was last modified.
    /// </summary>
    public DateTimeOffset? Modified { get; set; }

    /// <summary>
    /// Gets or sets a public URI of the attachment.
    /// </summary>
    public string Uri { get; set; }
  }
}