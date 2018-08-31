namespace Decos.Fixi
{
  /// <summary>
  /// Represents a category in the response.
  /// </summary>
  public class Category : CategoryData
  {
    /// <summary>
    /// Gets or sets a short name that uniquely identifies the category within a region.
    /// </summary>
    public string ShortName { get; set; }
  }
}