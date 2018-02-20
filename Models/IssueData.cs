using System;
using System.ComponentModel.DataAnnotations;

namespace Decos.Fixi
{
  /// <summary>
  /// Represents the modifiable properties of a reported issue.
  /// </summary>
  public class IssueData
  {
    /// <summary>
    /// Gets or sets the address that is closest to the location of the issue.
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Gets or sets a additional address details, such as a manual correction.
    /// </summary>
    public string AddressDetails { get; set; }

    /// <summary>
    /// Gets or sets the name of the category for which the issue was reported,
    /// or null if the issue was reported in an area without any registered
    /// regions or in a region without any registered categories.
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// Gets or sets a description of the issue.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets a message to be sent when the issue is forwarded.
    /// </summary>
    public string ForwardedMessage { get; set; }

    /// <summary>
    /// Gets or sets a comma-separated list of the email addresses to which a
    /// mail is sent when the issue is forwarded.
    /// </summary>
    public string ForwardedTo { get; set; }

    /// <summary>
    /// Gets or sets the data of the person that handles the issue.
    /// </summary>
    public UserData Handler { get; set; }

    /// <summary>
    /// Gets or sets the new location of the issue.
    /// </summary>
    public Point Location { get; set; }

    /// <summary>
    /// Gets or sets the new publicly visible identifier for the issue, or a null
    /// reference if the public identifier has not changed.
    /// </summary>
    [MaxLength(50)]
    public string ID { get; set; }

    /// <summary>
    /// Gets or sets the name of the region in which the issue was reported, or
    /// null if the issue was reported in an area without any registered regions.
    /// </summary>
    public string Region { get; set; }

    /// <summary>
    /// Gets or sets the details of the person that reported the issue.
    /// </summary>
    public Person ReportedBy { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the person who reported the issue
    /// should receive updates about this issue.
    /// </summary>
    public bool SendStatusUpdates { get; set; }

    /// <summary>
    /// Gets or sets a string that describes the source of the issue.
    /// </summary>
    public string Source { get; set; }

    /// <summary>
    /// Gets or sets a value that indicates the current status of the issue.
    /// </summary>
    [EnumDataType(typeof(Status))]
    public Status Status { get; set; }

    /// <summary>
    /// Gets or sets the short name of the team to which the issue is assigned.
    /// </summary>
    public string TeamName { get; set; }

    /// <summary>
    /// Gets or sets a value that determines who can see the issue.
    /// </summary>
    [EnumDataType(typeof(Visibility))]
    public Visibility Visibility { get; set; }

    /// <summary>
    /// Returns a string representing the issue data.
    /// </summary>
    /// <returns>A string that represents the issue data.</returns>
    public override string ToString()
    {
      return ID;
    }
  }
}