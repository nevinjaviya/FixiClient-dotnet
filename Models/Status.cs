using System;

namespace Decos.Fixi.Models
{
  /// <summary>
  /// Indicates the status of an issue.
  /// </summary>
  public enum Status
  {
    /// <summary>
    /// The issue has been reported but has not yet been assigned.
    /// </summary>
    Reported = 0,

    /// <summary>
    /// The issue has been accepted and is being worked on.
    /// </summary>
    InProgress = 1,

    /// <summary>
    /// The issue has been closed.
    /// </summary>
    Denied = 3,

    /// <summary>
    /// The issue has been handled.
    /// </summary>
    Handled = 4,

    /// <summary>
    /// The issue is put on hold or will be handled at a later date.
    /// </summary>
    Waiting = 5,

    /// <summary>
    /// The issue has been forwarded to an external party that will handle the issue.
    /// </summary>
    Forwarded = 6,
  }
}