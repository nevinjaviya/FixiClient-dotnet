namespace Decos.Fixi.Models
{
  /// <summary>
  /// Represents the modifiable properties of a category.
  /// </summary>
  public class CategoryData
  {
    /// <summary>
    /// Gets or sets an optional description of the category.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the category is currently in use.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Gets or sets the name of the category.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the relative priority of the category.
    /// </summary>
    public int Priority { get; set; }

    /// <summary>
    /// Gets or sets the number of business days in which issues in this category
    /// should be handled, or <c>null</c> if there is no service target for this category.
    /// </summary>
    public int? ServiceTarget { get; set; }

    /// <summary>
    /// Gets a value that indicates whether issues reported in this category
    /// should be public by default.
    /// </summary>
    public BooleanDefault IssueVisibility { get; set; }

    /// <summary>
    /// Gets or sets the short name of the team that should be assigned to new
    /// issues with this category.
    /// </summary>
    public string DefaultTeam { get; set; }
  }
}