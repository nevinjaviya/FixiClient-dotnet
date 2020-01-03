using System;

namespace Decos.Fixi.Models
{
  /// <summary>
  /// Represents the modifiable properties of a team.
  /// </summary>
  public class TeamData
  {
    /// <summary>
    /// Gets or sets an email address for the team.
    /// </summary>
    public string EmailAddress { get; set; }

    /// <summary>
    /// Gets or sets the name of the team.
    /// </summary>
    public string Name { get; set; }
  }
}