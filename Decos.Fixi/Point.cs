using System;
using System.Globalization;
using static System.FormattableString;

namespace Decos.Fixi
{
  public class Point
  {
    public double? Elevation { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

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

    public override string ToString()
    {
      return Invariant($"{Latitude},{Longitude},{Elevation ?? 0}z");
    }
  }
}