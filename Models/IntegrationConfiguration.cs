using Newtonsoft.Json;

namespace Decos.Fixi
{
  /// <summary>
  /// Contains data for <see cref="ConnectConfiguration"/> object
  /// </summary>
  public class IntegrationConfiguration
  {
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