using System;

namespace Decos.Fixi
{
  /// <summary>
  /// Represents the modifiable properties of a canned response.
  /// </summary>
  public class CannedResponseData
  {
    /// <summary>
    /// Gets or sets the name of the canned response.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the canned response text.
    /// </summary>
    public string Text { get; set; }
  }
}