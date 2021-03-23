using System;

namespace Decos.Fixi.Models
{
  /// <summary>
  /// Represents a specialized data transfer object of organization's extra settings.
  /// </summary>
  public class OrganizationExtraSettings
  {
    /// <summary>
    /// Gets or sets a flag that tells if citizens are allowed to make public comments on other citizen's issues or not.
    /// </summary>
    public bool AllowCitizenPublicComment { get; set; }
  }
}