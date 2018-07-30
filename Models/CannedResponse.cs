using System;

namespace Decos.Fixi
{
  /// <summary>
  /// Represents a preset comment text for an organization.
  /// </summary>
  public class CannedResponse
  {
    /// <summary>
    /// Gets or sets the name of the canned response.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets a short, URL-friendly name that uniquely identifies the
    /// canned response within an organization.
    /// </summary>
    public string ShortName { get; set; }

    /// <summary>
    /// Gets or sets the point in time when the entity has been created, or a
    /// null reference if the entity has not been committed to the database yet.
    /// </summary>
    public DateTimeOffset? Created { get; set; }

    /// <summary>
    /// Gets or sets the point in time when the entity has been changed, or a
    /// null reference if the entity has not been modified since it was created.
    /// </summary>
    public DateTimeOffset? Modified { get; set; }

    /// <summary>
    /// Gets or sets the canned response text.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Returns a string representation of the canned response.
    /// </summary>
    /// <returns>A <see cref="string"/> that represents this instance.</returns>
    public override string ToString()
    {
      return Name;
    }
  }
}