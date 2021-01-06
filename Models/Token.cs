using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Decos.Fixi
{
  /// <summary>
  /// Fixi Token object
  /// </summary>
  public class Token
  {
    /// <summary>
    /// Access token
    /// </summary>
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }

    /// <summary>
    /// Token type
    /// </summary>
    [JsonProperty("token_type")]
    public string TokenType { get; set; }

    /// <summary>
    /// Token expires in seconds
    /// </summary>
    [JsonProperty("expires_in")]
    public int ExpiresIn { get; set; }

    /// <summary>
    /// Refresh token
    /// </summary>
    [JsonProperty("refresh_token")]
    public string RefreshToken { get; set; }

    /// <summary>
    /// Token issued on
    /// </summary>
    [JsonProperty(".issued")]
    public string Issued { get; set; }

    /// <summary>
    /// Token expires on
    /// </summary>
    [JsonProperty(".expires")]
    public string Expires { get; set; }
  }
}
