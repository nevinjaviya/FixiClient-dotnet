namespace Decos.Fixi
{
  /// <summary>
  /// Represents a reference to a category by name.
  /// </summary>
  public class CategoryName
  {
    /// <summary>
    /// The short name of the region that contains the category.
    /// </summary>
    public string RegionShortName { get; set; }

    /// <summary>
    /// The short name of the category.
    /// </summary>
    public string ShortName { get; set; }
  }
}