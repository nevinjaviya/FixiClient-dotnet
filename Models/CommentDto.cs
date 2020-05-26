using System;

namespace Decos.Fixi.Models
{
  /// <summary>
  /// Represents a specialized data transfer object for adding and editing
  /// comments and any associated properties.
  /// </summary>
  public class CommentDto
  {
    /// <summary>
    /// Gets or sets the comment text.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Gets or sets the email address of the person that created the comment.
    /// </summary>
    public string Author { get; set; }

    /// <summary>
    /// Gets or sets a value that indicates who is allowed to see the comment.
    /// </summary>
    public Visibility Visibility { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the comment is archived or not.
    /// </summary>
    public bool? IsArchived { get; set; }
  }
}