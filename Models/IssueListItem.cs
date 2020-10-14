using System;

namespace Decos.Fixi.Models
{
  /// <summary>
  /// Represents a reported issue as an item in a list.
  /// </summary>
  public class IssueListItem
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="IssueListItem"/> class.
    /// </summary>
    public IssueListItem()
    {
    }

    /// <summary>
    /// Gets or sets the public identifier of the issue.
    /// </summary>
    public string ID { get; set; }

    /// <summary>
    /// Gets or sets the public identifier of the issue.
    /// </summary>
    public string PublicID { get; set; }

    /// <summary>
    /// Gets or sets the number of files attached to the issue.
    /// </summary>
    public int AttachmentCount { get; set; }

    /// <summary>
    /// Gets or sets the display name of the category for which the issue was
    /// reported, or a null reference if the issue was reported in an area
    /// without any registered regions or in a region without any registered categories.
    /// </summary>
    public string CategoryName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the issue has any comments.
    /// </summary>
    public bool HasComments { get; set; }

    /// <summary>
    /// Gets or sets the Decos User ID of the handler that has been assigned to
    /// the issue, or a null reference if the issue has not been assigned to anyone.
    /// </summary>
    public Guid? HandlerID { get; set; }

    /// <summary>
    /// Gets or sets the full name of the handler that has been assigned to the
    /// issue, or a null reference if the issue has not been assigned to anyone.
    /// </summary>
    public string HandlerName { get; set; }

    /// <summary>
    /// Gets or sets the full name of the team that has been assigned to the
    /// issue, or a null reference if the issue has not been assigned to a team.
    /// </summary>
    public string TeamName { get; set; }

    /// <summary>
    /// Gets or sets the name of the person that reported the account.
    /// </summary>
    public string ReporterName { get; set; }

    /// <summary>
    /// Gets or sets the address that is closest to the location of the issue.
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Gets or sets a additional address details, such as a manual correction.
    /// </summary>
    public string AddressDetails { get; set; }

    /// <summary>
    /// Gets or sets the short name of the application that was used to create
    /// the entity, or a null reference if the entity was created by an
    /// unauthenticated application.
    /// </summary>
    public string Application { get; set; }

    /// <summary>
    /// Gets or sets the short name of the category for which the issue was
    /// reported, or a null reference if the issue was reported in an area
    /// without any registered regions or in a region without any registered categories.
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// Gets or sets the point in time that the issue has been closed, or a null
    /// reference if the closed date has not changed.
    /// </summary>
    public DateTimeOffset? Closed { get; set; }

    /// <summary>
    /// Gets or sets the point in time when the issue has been created, or a null
    /// reference if the entity has not been committed to the database yet.
    /// </summary>
    public DateTimeOffset? Created { get; set; }

    /// <summary>
    /// Gets or sets the email address of the user that created the issue, or a
    /// null reference if the issue was reported anonymously.
    /// </summary>
    public string CreatedBy { get; set; }

    /// <summary>
    /// Gets or sets a description of the issue.
    /// </summary>
    public string Description { get; set; }

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
    /// Gets or sets the short name of the application that was used to change
    /// the entity, or a null reference if the entity has not been modified or
    /// has been modified by an unauthenticated application.
    /// </summary>
    public string ModifiedBy { get; set; }

    /// <summary>
    /// Gets or sets the short name of the region in which the issue was
    /// reported, or a null reference if the issue was reported in an area
    /// without any registered regions.
    /// </summary>
    public string Region { get; set; }

    /// <summary>
    /// Gets or sets the short name of the organization that manages the region
    /// in which the issue was reported, or null if the issue was reported in an
    /// area without any registered regions or if the region is not managed by an organization.
    /// </summary>
    public string Organization { get; set; }

    /// <summary>
    /// Gets or sets a value that indicates the current status of the issue.
    /// </summary>
    public Status Status { get; set; }

    /// <summary>
    /// Gets or sets the short name of the team that has been assigned to the
    /// issue, or a null reference if the issue has not been assigned to a team.
    /// </summary>
    public string Team { get; set; }

    /// <summary>
    /// Gets or sets the user that reported the issue, or a
    /// null reference if the issue was reported without a user account. This is
    /// typically the same as <see cref="CreatedBy"/>, except in cases where the
    /// issue was created by someone else and later re-assigned.
    /// </summary>
    public User User { get; set; }

    /// <summary>
    /// Gets or sets the details of the person that reported the issue.
    /// </summary>
    public Person ReportedBy { get; set; }

    /// <summary>
    /// Gets or sets a value that determines who can see the issue.
    /// </summary>
    public Visibility Visibility { get; set; }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
      return $"{ID} {CategoryName} ({Status}): {Description}";
    }
  }
}