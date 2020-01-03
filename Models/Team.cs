using System;

namespace Decos.Fixi.Models
{
  /// <summary>
  /// Represents a team of handlers.
  /// </summary>
  public class Team
  {
    /// <summary>
    /// Gets or sets the point in time the team has been created.
    /// </summary>
    public DateTimeOffset? Created { get; set; }

    /// <summary>
    /// Gets or sets an email address for the team.
    /// </summary>
    public string EmailAddress { get; set; }

    /// <summary>
    /// Gets or sets the point in time the team was last modified.
    /// </summary>
    public DateTimeOffset? Modified { get; set; }

    /// <summary>
    /// Gets or sets the name of the team.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets a short name that uniquely identifies the team within an organization.
    /// </summary>
    public string ShortName { get; set; }
  }
}