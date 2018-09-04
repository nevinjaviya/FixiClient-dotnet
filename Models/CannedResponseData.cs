using System.Collections.Generic;

namespace Decos.Fixi
{
  /// <summary>
  /// Represents modifiable properties of a canned response.
  /// </summary>
  public class CannedResponseData
  {
    /// <summary>
    /// The name of the canned response.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The canned response text.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Relative priority of the canned response.
    /// </summary>
    public int Priority { get; set; }

    /// <summary>
    /// A collection of categories that the canned response applies to, or an
    /// empty collection if the canned response applies to all categories.
    /// </summary>
    public ICollection<CategoryName> Categories { get; set; }
  }
}