using System;

namespace Decos.Fixi
{
  /// <summary>
  /// Represents an application using the Fixi API.
  /// </summary>
  public class Application
  {
    /// <summary>
    /// Gets or sets the API key associated with the application.
    /// </summary>
    public string ApiKey { get; set; }

    /// <summary>
    /// Gets or sets the point in time when the application has been created, or
    /// a null reference if the application has not been committed to the
    /// database yet.
    /// </summary>
    public DateTimeOffset? Created { get; set; }

    /// <summary>
    /// Gets or sets the application that was used to create the entity, or a
    /// null reference if the entity was created by an unauthenticated application.
    /// </summary>
    public Application CreatedBy { get; set; }

    /// <summary>
    /// Gets or sets a string that identifies the type of device the application
    /// runs on.
    /// </summary>
    public string DeviceType { get; set; }

    /// <summary>
    /// Gets or sets the point in time when the application has been changed, or
    /// a null reference if the application has not been modified since it was created.
    /// </summary>
    public DateTimeOffset? Modified { get; set; }

    /// <summary>
    /// Gets or sets the application that was used to change the entity, or a
    /// null reference if the entity has not been modified or has been modified
    /// by an unauthenticated application.
    /// </summary>
    public Application ModifiedBy { get; set; }

    /// <summary>
    /// Gets or sets the name of the application.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the organization that owns the application.
    /// </summary>
    public Organization Organization { get; set; }

    /// <summary>
    /// Gets or sets a comma-separated list of the roles that identify the type
    /// of application and the access it requires.
    /// </summary>
    public string Roles { get; set; }

    /// <summary>
    /// Gets or sets a short, URL-friendly name that uniquely identifies the
    /// application within organization, e.g. "decos".
    /// </summary>
    public string ShortName { get; set; }

    /// <summary>
    /// Returns a <see cref="string"/> that represents this instance.
    /// </summary>
    /// <returns>A <see cref="string"/> that represents this instance.</returns>
    public override string ToString()
    {
      return Name;
    }
  }
}