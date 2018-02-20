using System;

namespace Decos.Fixi
{
  /// <summary>
  /// Indicates the default value for a boolean option.
  /// </summary>
  public enum BooleanDefault
  {
    /// <summary>
    /// No explicit default value is specified.
    /// </summary>
    None = 0,

    /// <summary>
    /// The option is off by default.
    /// </summary>
    DefaultOff,

    /// <summary>
    /// The option is on by default.
    /// </summary>
    DefaultOn,

    /// <summary>
    /// The option is always off and may not be changed.
    /// </summary>
    AlwaysOff,

    /// <summary>
    /// The option is always on and may not be changed.
    /// </summary>
    AlwaysOn,
  }
}