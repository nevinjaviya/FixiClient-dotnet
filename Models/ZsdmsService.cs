namespace Decos.Fixi.Models
{
  /// <summary>
  /// Contains the data for an <see cref="ZsdmsService"/> object.
  /// </summary>
  /// <remarks>
  /// This class is used both as a data transfer object and as base class for the
  /// complete <see cref="ZsdmsService"/> entity.
  /// </remarks>
  public class ZsdmsService
  {
    /// <summary>
    /// Gets or sets the endpoint url of the service used for syncing using ZSDMS.
    /// </summary>
    public string Endpoint { get; set; }

    /// <summary>
    /// Gets or sets the certificate name of the service used for syncing using ZSDMS.
    /// </summary>
    public string CertificateName { get; set; }

    /// <summary>
    /// Gets or sets the certificate base64 of the service used for syncing using ZSDMS.
    /// </summary>
    public string CertificateBase64 { get; set; }

    /// <summary>
    /// Gets or sets the certificate password of the service used for syncing using ZSDMS.
    /// </summary>
    public string CertificatePassword { get; set; }
  }
}