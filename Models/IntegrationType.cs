namespace Decos.Fixi.Models
{
  /// <summary>
  /// Indicates the type of third party integration.
  /// </summary>
  public enum IntegrationType
  {
    /// <summary> No integration is specified.</summary>
    None = 0,

    /// <summary> The JOIN integration type </summary>
    JOIN = 1,

    /// <summary> The ZSDMS integration type. </summary>
    ZSDMS = 2
  }
}