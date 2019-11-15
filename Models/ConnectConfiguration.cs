using System;
using System.Runtime.Serialization;

namespace Decos.Fixi
{
  /// <summary>
  /// Contains the data for an <see cref="ConnectConfiguration"/> object.
  /// </summary>
  /// <remarks>
  /// This class is used both as a data transfer object and as base class for the
  /// complete <see cref="ConnectConfiguration"/> entity.
  /// </remarks>
  public class ConnectConfiguration : IntegrationConfiguration
  {
    /// <summary>
    /// Gets or sets an identifier of the case type to use when creating new
    /// cases in JOIN.
    /// </summary>
    public string CaseTypeIdentifier { get; set; }

    /// <summary>
    /// Gets or sets a URI to the BasicHttpEntityService to use when syncing with
    /// JOIN. HTTP, HTTPS and Service Bus Relay bindings are supported.
    /// </summary>
    public string ConnectEntityServiceUri { get; set; }
  }
}