namespace Decos.Fixi
{
  /// <summary>
  /// Represents a category in the response.
  /// </summary>
  public class Category
  {
    /// <summary>
    /// Gets or sets the name of the category.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets a short name that uniquely identifies the category within a region.
    /// </summary>
    public string ShortName { get; set; }

    /// <summary>
    /// Gets or sets a description of the category.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the category is currently in use.
    /// </summary>
    public bool? IsActive { get; set; }

    /// <summary>
    /// Gets or sets the priority of the category.
    /// </summary>
    public int? Priority { get; set; }
  }
}