using Newtonsoft.Json;

namespace Decos.Fixi
{
  /// <summary>
  /// Contains data for <see cref="ConnectConfiguration"/> object
  /// </summary>
  public class IntegrationConfiguration
  {
    /// <summary>
    /// Gets or sets the Connect system ID to use when syncing with JOIN.
    /// </summary>
    public string SystemID { get; set; }

    /// <summary>
    /// Gets or sets the Connect system password to use when syncing with JOIN.
    /// </summary>
    public string SystemPassword { get; set; }

    /// <summary>
    /// Indicates whether the <see cref="SystemPassword"/> property should
    /// be serialized.
    /// </summary>
    /// <returns><c>false</c>.</returns>
    public bool ShouldSerializeSystemPassword() => true;

    /// <summary>
    /// Get json string of the current instance
    /// </summary>
    /// <returns>A json string of this object</returns>
    public string GetJsonString()
    {
      return JsonConvert.SerializeObject(this);
    }
  }
}