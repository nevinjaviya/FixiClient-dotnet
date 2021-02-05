using System.Collections.Generic;

namespace Decos.Fixi.Models
{
  /// <summary>
  /// Contains the data for an <see cref="ZsdmsConfiguration"/> object.
  /// </summary>
  /// <remarks>
  /// This class is used both as a data transfer object and as base class for the
  /// complete <see cref="ZsdmsConfiguration"/> entity.
  /// </remarks>
  public class ZsdmsConfiguration : IntegrationConfiguration
  {
    /// <summary>
    /// Gets or sets the OntvangAsynchroon service details.
    /// </summary>
    public ZsdmsService OntvangAsynchroon { get; set; }

    /// <summary>
    /// Gets or sets the Vrijeberichten service details.
    /// </summary>
    public ZsdmsService Vrijeberichten { get; set; }

    /// <summary>
    ///  Gets or sets the BeantwoordVraag service details.
    /// </summary>
    public ZsdmsService BeantwoordVraag { get; set; }

    /// <summary>
    ///  Gets or sets the BeantwoordVraagZSDMS service details.
    /// </summary>
    public ZsdmsService BeantwoordVraagZsdms { get; set; }

    /// <summary>
    /// Gets or sets the receiver application to use when syncing using ZSDMS.
    /// </summary>
    public string ReceiverApplication { get; set; }

    /// <summary>
    /// Gets or sets the receiver organization to use when syncing using ZSDMS.
    /// </summary>
    public string ReceiverOrganisation { get; set; }

    /// <summary>
    /// Gets or sets the sender application to use when syncing using ZSDMS.
    /// </summary>
    public string SenderApplication { get; set; }

    /// <summary>
    /// Gets or sets the sender organization to use when syncing using ZSDMS.
    /// </summary>
    public string SenderOrganisation { get; set; }

    /// <summary>
    /// Gets or sets the case type code to use when syncing using ZSDMS.
    /// </summary>
    public string CaseTypeCode { get; set; }

    /// <summary>
    /// Gets or sets the case type description to use when syncing using ZSDMS.
    /// </summary>
    public string CaseTypeDescription { get; set; }

    /// <summary>
    /// Gets or sets the status map to use when syncing using ZSDMS.
    /// </summary>
    public Dictionary<Status, string> StatusMapping { get; set; }
  }
}