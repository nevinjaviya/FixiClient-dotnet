using System;

namespace Decos.Fixi
{
  /// <summary>
  /// Represents a user that solves issues.
  /// </summary>
  public class Handler
  {
    /// <summary>
    /// Gets or sets the point in time when the handler has been created, or a
    /// null reference if the handler has not been committed to the database yet.
    /// </summary>
    public DateTimeOffset? Created { get; set; }

    /// <summary>
    /// Gets or sets the point in time when the handler has been changed, or a
    /// null reference if the handler has not been modified since it was created.
    /// </summary>
    public DateTimeOffset? Modified { get; set; }

    /// <summary>
    /// Gets or sets an object that contains the handler's personal information.
    /// </summary>
    public User Person { get; set; }

    /// <summary>
    /// Returns a <see cref="string"/> that represents this instance.
    /// </summary>
    /// <returns>A <see cref="string"/> that represents this instance.</returns>
    public override string ToString()
    {
      return Person?.ToString();
    }
  }
}