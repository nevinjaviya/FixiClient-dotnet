using System;

namespace Decos.Fixi.Http
{
  /// <summary>
  /// Represents the response to a failed request.
  /// </summary>
  public class HttpError
  {
    /// <summary>
    /// Gets or sets a message explaining the cause of the error.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
      return Message;
    }
  }
}