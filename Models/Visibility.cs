namespace Decos.Fixi
{
  /// <summary>
  /// Indicates the different levels of visibility.
  /// </summary>
  public enum Visibility
  {
    /// <summary>
    /// No visibility is specified.
    /// </summary>
    None = 0,

    /// <summary>
    /// The entity is publicly visible.
    /// </summary>
    Public,

    /// <summary>
    /// The entity is only visible to the creator and people in the organization
    /// to which the entity belongs.
    /// </summary>
    Private,

    /// <summary>
    /// The entity is only visible to people in the organization to which the
    /// entity belongs.
    /// </summary>
    Internal,
  }
}
