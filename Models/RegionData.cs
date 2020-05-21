using System;

namespace Decos.Fixi.Models
{
  /// <summary>
  /// Represents the modifiable properties of a region.
  /// </summary>
  public class RegionData
  {
    /// <summary>
    /// Gets or sets the name of the culture or locale used in the region, e.g. "en-US".
    /// </summary>
    public string Culture { get; set; }

    /// <summary>
    /// Gets or sets an email address of the person or organization that manages
    /// this region, e.g. the public email address of a municipality.
    /// </summary>
    public string EmailAddress { get; set; }

    /// <summary>
    /// Gets or sets an connect configuration id of the organization that is used to connect with join
    /// </summary>
    public ConnectConfiguration ConnectConfiguration { get; set; }

    /// <summary>
    /// Gets or sets a ZSDMS configuration that is used to sync data with other applications.
    /// </summary>
    public ZsdmsConfiguration ZsdmsConfiguration { get; set; }

    /// <summary>
    /// Gets or sets an connect configuration id of the organization that is used to connect with join
    /// </summary>
    public string IntegrationConfiguration { get; set; }

    /// <summary>
    /// Gets or sets an integer that identifies the map layer on which the region
    /// is located. Higher values indicate smaller, more specific regions.
    /// </summary>
    public int? Layer { get; set; }

    /// <summary>
    /// Gets or sets the approximate northernmost latitude of the region.
    /// </summary>
    public double? MaxLatitude { get; set; }

    /// <summary>
    /// Gets or sets the approximate easternmost longitude of the region.
    /// </summary>
    public double? MaxLongitude { get; set; }

    /// <summary>
    /// Gets or sets the approximate southernmost latitude of the region.
    /// </summary>
    public double? MinLatitude { get; set; }

    /// <summary>
    /// Gets or sets the approximate westernmost longitude of the region.
    /// </summary>
    public double? MinLongitude { get; set; }

    /// <summary>
    /// Gets or sets a name for the region.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets an display name for an region(municipality).
    /// </summary>
    public string DisplayName { get; set; }

    /// <summary>
    /// Gets or sets the short name of the organization that owns the region, or
    /// a null reference if the region is not owned by a customer.
    /// </summary>
    public string OrganizationName { get; set; }

    /// <summary>
    /// Gets or sets a polygon that represents the area covered by the region.
    /// </summary>
    public Polygon Polygon { get; set; }

    /// <summary>
    /// Time zone id of the organization
    /// </summary>
    public string TimeZoneId { get; set; }
  }
}