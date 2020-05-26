using System;

namespace Decos.Fixi.Models
{
  /// <summary>
  /// Indicates the different levels of visibility.
  /// </summary>
  public enum UserRole
  {
    /// <summary>
    /// No role is specified.
    /// </summary>
    None = 0,

    /// <summary>
    /// The user is a citizen.
    /// </summary>
    Citizen,

    /// <summary>
    /// The user is a Handler.
    /// </summary>
    Handler,

    /// <summary>
    /// The user is a person at telephone information center(TIC).
    /// </summary>
    Tic,

    /// <summary>
    /// The user is an Admin.
    /// </summary>
    Admin
  }
}