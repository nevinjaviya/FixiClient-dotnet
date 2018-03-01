using System;
using System.ComponentModel.DataAnnotations;

namespace Decos.Fixi
{
  /// <summary>
  /// Represents the modifiable properties of a user.
  /// </summary>
  public class UserData
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
    /// Gets or sets the Decos IDP User ID of the person, or a null reference if
    /// the person does not use a Decos IDP account.
    /// </summary>
    public Guid? DecosUserID { get; set; }

    /// <summary>
    /// Gets or sets an email address for contacting the person.
    /// </summary>
    [MaxLength(254)]
    public string EmailAddress { get; set; }

    /// <summary>
    /// Gets or sets the Facebook user ID of the person, or a null reference if
    /// the person does not use a Facebook account.
    /// </summary>
    [MaxLength(128)]
    public string FacebookUserID { get; set; }

    /// <summary>
    /// Gets or sets the Google user ID of the person, or a null reference if the
    /// person does not use a Google account.
    /// </summary>
    [MaxLength(128)]
    public string GoogleUserID { get; set; }

    /// <summary>
    /// Gets or sets the person's full name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets a phone number for contacting the person.
    /// </summary>
    public string PhoneNumber { get; set; }

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