using System;

namespace Decos.Fixi.Models
{
  /// <summary>
  /// Represents a comment on an issue as an item in a list.
  /// </summary>
  public class CommentListItem
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="CommentListItem"/> class.
    /// </summary>
    public CommentListItem()
    {
    }

    /// <summary>
    /// The ID of the comment.
    /// </summary>
    public string ID { get; set; }

    /// <summary>
    /// The ID of the issue on which the comment was made.
    /// </summary>
    public string Issue { get; set; }

    /// <summary>
    /// Indicates whether the comment was removed.
    /// </summary>
    public bool? IsArchived { get; set; }

    /// <summary>
    /// The user that created the comment.
    /// </summary>
    public CommentAuthor Author { get; set; }

    /// <summary>
    /// The point in time when the comment was created.
    /// </summary>
    public DateTimeOffset? Created { get; set; }

    /// <summary>
    /// The point in time when the comment was last changed.
    /// </summary>
    public DateTimeOffset? Modified { get; set; }

    /// <summary>
    /// The comment text. Not available if the comment is removed.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Indicates who is allowed to see the comment.
    /// </summary>
    public Visibility Visibility { get; set; }

    /// <summary>
    /// Gets a value indicating whether the comment was made by reporter of an issue.
    /// </summary>
    public bool IsReporterComment { get; set; }

    /// <summary>
    /// Represents the author of a comment.
    /// </summary>
    public class CommentAuthor
    {
      /// <summary>
      /// Initializes a new instance of the <see cref="CommentAuthor"/> class.
      /// </summary>
      public CommentAuthor()
      {
      }

      /// <summary>
      /// A unique identifier for the user that created the comment.
      /// </summary>
      public string ID { get; set; }

      /// <summary>
      /// The name of the user that created the comment.
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// The email address of the user that created the comment.
      /// </summary>
      public string EmailAddress { get; set; }

      /// <summary>
      /// The role of the user that created the comment.
      /// </summary>
      public UserRole Role { get; set; }
    }
  }
}