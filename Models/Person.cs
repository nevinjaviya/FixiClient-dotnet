using System;
using System.ComponentModel.DataAnnotations;

namespace Decos.Fixi
{
  /// <summary>
  /// Represents personal information.
  /// </summary>
  public class Person : IEquatable<Person>
  {
    /// <summary>
    /// Represents the empty <see cref="Person"/>. This field is read-only.
    /// </summary>
    public static readonly Person Empty = new Person();

    /// <summary>
    /// Gets or sets the person's address.
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Gets or sets an email address for contacting the person.
    /// </summary>
    [MaxLength(254)]
    public string EmailAddress { get; set; }

    /// <summary>
    /// Gets or sets the person's full name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets a phone number for contacting the person.
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Indicates whether the specified <see cref="Person"/> is null or has no value.
    /// </summary>
    /// <param name="person">The <see cref="Person"/> to test.</param>
    /// <returns>
    /// <c>true</c> if <paramref name="person"/> is a null reference or has no
    /// value; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsNullOrEmpty(Person person)
    {
      return person == null || (string.IsNullOrEmpty(person.Name)
          && string.IsNullOrEmpty(person.EmailAddress)
          && string.IsNullOrEmpty(person.PhoneNumber)
          && string.IsNullOrEmpty(person.Address));
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <returns>
    /// true if the specified object is equal to the current object; otherwise, false.
    /// </returns>
    /// <param name="obj">The object to compare with the current object.</param>
    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;

      var other = obj as Person;
      return Equals(other);
    }

    /// <summary>
    /// Indicates whether the current object is equal to another object of the
    /// same type.
    /// </summary>
    /// <returns>
    /// true if the current object is equal to the <paramref name="other"/>
    /// parameter; otherwise, false.
    /// </returns>
    /// <param name="other">An object to compare with this object.</param>
    public bool Equals(Person other)
    {
      if (other == null)
        return false;

      return Name == other.Name
          && EmailAddress == other.EmailAddress
          && PhoneNumber == other.PhoneNumber
          && Address == other.Address;
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode()
    {
      unchecked
      {
        var result = 37;
        result *= 397 + Name?.GetHashCode() ?? 0;
        result *= 397 + EmailAddress?.GetHashCode() ?? 0;
        result *= 397 + PhoneNumber?.GetHashCode() ?? 0;
        result *= 397 + Address?.GetHashCode() ?? 0;
        return result;
      }
    }

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