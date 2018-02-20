using System;
using System.Collections.Generic;

namespace Decos.Fixi
{
  /// <summary>
  /// Represents a reported issue.
  /// </summary>
  public class Issue
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Issue"/> class.
    /// </summary>
    public Issue()
    {
      Attachments = new HashSet<Attachment>();
    }

    /// <summary>
    /// Gets or sets the address that is closest to the location of the issue.
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Gets or sets a additional address details, such as a manual correction.
    /// </summary>
    public string AddressDetails { get; set; }

    /// <summary>
    /// Gets or sets the application that was used to create the entity, or a
    /// null reference if the entity was created by an unauthenticated application.
    /// </summary>
    public Application Application { get; set; }

    /// <summary>
    /// Gets or sets a collection of files attached to the issue.
    /// </summary>
    public ICollection<Attachment> Attachments { get; set; }

    /// <summary>
    /// Gets or sets the category for which the issue was reported, or a null
    /// reference if the issue was reported in an area without any registered
    /// regions or in a region without any registered categories.
    /// </summary>
    public Category Category { get; set; }

    /// <summary>
    /// Gets or sets the new point in time that the issue has been closed, or a
    /// null reference if the closed date has not changed.
    /// </summary>
    public DateTimeOffset? Closed { get; set; }

    /// <summary>
    /// Gets or sets the point in time when the issue has been created, or a null
    /// reference if the entity has not been committed to the database yet.
    /// </summary>
    public DateTimeOffset? Created { get; set; }

    /// <summary>
    /// Gets or sets the user that created the issue, or a null reference if the
    /// issue was reported anonymously.
    /// </summary>
    public User CreatedBy { get; set; }

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
    /// Gets or sets the handler that has been assigned to the issue, or a null
    /// reference if the issue has not been assigned to anyone.
    /// </summary>
    public Handler Handler { get; set; }

    /// <summary>
    /// Gets a value indicating whether the issue has any comments.
    /// </summary>
    public bool HasComments { get; set; }

    /// <summary>
    /// Gets or sets the location of the issue.
    /// </summary>
    public Point Location { get; set; }

    /// <summary>
    /// Gets or sets the point in time when the entity has been changed, or a
    /// null reference if the entity has not been modified since it was created.
    /// </summary>
    public DateTimeOffset? Modified { get; set; }

    /// <summary>
    /// Gets or sets the application that was used to change the entity, or a
    /// null reference if the entity has not been modified or has been modified
    /// by an unauthenticated application.
    /// </summary>
    public Application ModifiedBy { get; set; }

    /// <summary>
    /// Gets the short name of the organization that manages the region in which
    /// the issue was reported, or null if the issue was reported in an area
    /// without any registered regions or if the region is not managed by an organization.
    /// </summary>
    public string OrganizationName { get; set; }

    /// <summary>
    /// Gets or sets the new publicly visible identifier for the issue, or a null
    /// reference if the public identifier has not changed.
    /// </summary>
    public string ID { get; set; }

    /// <summary>
    /// Gets or sets the short name of the region in which the issue was
    /// reported, or a null reference if the issue was reported in an area
    /// without any registered regions.
    /// </summary>
    public string RegionName { get; set; }

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
    public Status Status { get; set; }

    /// <summary>
    /// Gets or sets the team that has been assigned to the issue, or a null
    /// reference if the issue has not been assigned to a team.
    /// </summary>
    public Team Team { get; set; }

    /// <summary>
    /// Gets or sets a value that determines who can see the issue.
    /// </summary>
    public Visibility Visibility { get; set; }
  }
}