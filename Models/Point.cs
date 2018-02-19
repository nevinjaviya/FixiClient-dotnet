using System;
using System.Globalization;
using static System.FormattableString;

namespace Decos.Fixi
{
  /// <summary>
  /// Represents a set of geographical coordinates.
  /// </summary>
  public class Point
  {
    /// <summary>
    /// Gets or sets the elevation.
    /// </summary>
    public double? Elevation { get; set; }

    /// <summary>
    /// Gets or sets the latitude coordinate of the point.
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// Gets or sets the longitude coordinate of the point.
    /// </summary>
    public double Longitude { get; set; }

    /// <summary>
    /// Converts the string representation of a point to an equivalent object.
    /// </summary>
    /// <param name="value">A string that contains a point to convert.</param>
    /// <returns>
    /// A <see cref="Point"/> that is equivalent to the point represented by
    /// <paramref name="value"/>.
    /// </returns>
    public static Point Parse(string value)
    {
      if (value == null)
        throw new ArgumentNullException(nameof(value));

      var parts = value.Split(',');
      if (parts.Length < 2 || parts.Length > 3)
        throw new FormatException();

      var latitude = double.Parse(parts[0], CultureInfo.InvariantCulture);
      var longitude = double.Parse(parts[1], CultureInfo.InvariantCulture);
      var elevation = 0.0;
      if (parts.Length > 2)
        elevation = double.Parse(parts[2].TrimEnd('Z', 'z'), CultureInfo.InvariantCulture);

      return new Point
      {
        Latitude = latitude,
        Longitude = longitude,
        Elevation = elevation
      };
    }

    /// <summary>
    /// Converts the string representation of a point to an equivalent object.
    /// The return value indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="value">A string that contains a point to convert.</param>
    /// <param name="point">
    /// When this method returns, contains a <see cref="Point"/> object that is
    /// represented by <paramref name="value"/>.
    /// </param>
    /// <returns>
    /// <c>true</c> if <paramref name="value"/> is converted successfully;
    /// otherwise, <c>false</c>.
    /// </returns>
    public static bool TryParse(string value, out Point point)
    {
      point = default(Point);
      if (string.IsNullOrEmpty(value))
        return false;

      try
      {
        point = Parse(value);
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// Converts the point to its equivalent string representation.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
      return Invariant($"{Latitude},{Longitude},{Elevation ?? 0}z");
    }
  }
}