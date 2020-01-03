using System;

namespace Decos.Fixi.Models
{
  /// <summary>
  /// Represents a registered Fixi user.
  /// </summary>
  public class User
  {
    /// <summary>
    /// Gets or sets the person's address.
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Gets or sets the object ID of the associated Azure AD user account.
    /// </summary>
    public Guid? AzureADObjectId { get; set; }

    /// <summary>
    /// Gets or sets the point in time when the person has been created, or a
    /// null reference if the person has not been committed to the database yet.
    /// </summary>
    public DateTimeOffset? Created { get; set; }

    /// <summary>
    /// Gets or sets the Decos IDP User ID of the person, or a null reference if
    /// the person does not use a Decos IDP account.
    /// </summary>
    public Guid? DecosUserID { get; set; }

    /// <summary>
    /// Gets or sets an email address for contacting the person.
    /// </summary>
    public string EmailAddress { get; set; }

    /// <summary>
    /// Gets or sets the Facebook user ID of the person, or a null reference if
    /// the person does not use a Facebook account.
    /// </summary>
    public string FacebookUserID { get; set; }

    /// <summary>
    /// Gets or sets the Google user ID of the person, or a null reference if the
    /// person does not use a Google account.
    /// </summary>
    public string GoogleUserID { get; set; }

    /// <summary>
    /// Gets or sets a unique identifier for the person.
    /// </summary>
    public Guid ID { get; set; }

    /// <summary>
    /// Gets or sets the point in time when the person has been changed, or a
    /// null reference if the person has not been modified since it was created.
    /// </summary>
    public DateTimeOffset? Modified { get; set; }

    /// <summary>
    /// Gets or sets the person's full name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets a phone number for contacting the person.
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Gets a uniquely identifying tag which can be used in push notifications.
    /// </summary>
    public string UniqueTag => $"id:{ID:N}";

    /// <summary>
    /// Returns a string representing the person.
    /// </summary>
    /// <returns>A <see cref="string"/> that represents this instance.</returns>
    public override string ToString()
    {
      return Name ?? EmailAddress ?? PhoneNumber;
    }
  }
}