namespace Decos.Fixi.Models
{
  /// <summary>
  /// Represents a category in the response.
  /// </summary>
  public class CategoryResponse : CategoryData
  {
    /// <summary>
    /// Gets or sets a short name that uniquely identifies the category within a region.
    /// </summary>
    public string ShortName { get; set; }
  }
}