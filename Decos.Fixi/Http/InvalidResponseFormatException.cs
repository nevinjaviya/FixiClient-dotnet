using System;
using System.Net.Http;

namespace Decos.Fixi.Http
{
  /// <summary>
  /// Represents errors that occur when an API response was in an unexpected format.
  /// </summary>
  public class InvalidResponseFormatException : ApiException
  {
    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="InvalidResponseFormatException"/> class.
    /// </summary>
    public InvalidResponseFormatException()
      : base(Strings.InvalidResponse)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="InvalidResponseFormatException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public InvalidResponseFormatException(string message)
      : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="InvalidResponseFormatException"/> class with a specified error
    /// message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">
    /// The error message that explains the reason for the exception.
    /// </param>
    /// <param name="innerException">
    /// The exception that is the cause of the current exception, or a null
    /// reference (Nothing in Visual Basic) if no inner exception is specified.
    /// </param>
    public InvalidResponseFormatException(string message, Exception innerException)
      : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="InvalidResponseFormatException"/> class with the specified request
    /// URI and response status.
    /// </summary>
    /// <param name="request">The request that failed.</param>
    /// <param name="statusCode">The status code of the response.</param>
    public InvalidResponseFormatException(HttpRequestMessage request, System.Net.HttpStatusCode statusCode)
      : base(request, statusCode)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="InvalidResponseFormatException"/> class with the specified request
    /// URI, response status and content.
    /// </summary>
    /// <param name="request">The request that failed.</param>
    /// <param name="statusCode">The status code of the response.</param>
    /// <param name="error">The response to the failed request.</param>
    public InvalidResponseFormatException(HttpRequestMessage request, System.Net.HttpStatusCode statusCode, HttpError error)
      : base(request, statusCode, error)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiException"/> class with
    /// the specified message and request information.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="request">The request that failed.</param>
    /// <param name="statusCode">The status code of the response.</param>
    /// <param name="error">The response to the failed request.</param>
    public InvalidResponseFormatException(string message, HttpRequestMessage request, System.Net.HttpStatusCode statusCode, HttpError error)
      : base(message, request, statusCode, error)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiException"/> class with
    /// the specified message and request information.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="request">The request that failed.</param>
    /// <param name="statusCode">The status code of the response.</param>
    public InvalidResponseFormatException(string message, HttpRequestMessage request, System.Net.HttpStatusCode statusCode)
      : base(message, request, statusCode)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiException"/> class with
    /// the specified message, request information and a reference to the inner
    /// exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="request">The request that failed.</param>
    /// <param name="statusCode">The status code of the response.</param>
    /// <param name="innerException">
    /// The exception that is the cause of the current exception, or a null
    /// reference (Nothing in Visual Basic) if no inner exception is specified.
    /// </param>
    public InvalidResponseFormatException(string message, HttpRequestMessage request, System.Net.HttpStatusCode statusCode, Exception innerException)
      : base(message, request, statusCode, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiException"/> class with
    /// the specified message, request information and a reference to the inner
    /// exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="request">The request that failed.</param>
    /// <param name="statusCode">The status code of the response.</param>
    /// <param name="error">The response to the failed request.</param>
    /// <param name="innerException">
    /// The exception that is the cause of the current exception, or a null
    /// reference (Nothing in Visual Basic) if no inner exception is specified.
    /// </param>
    public InvalidResponseFormatException(string message, HttpRequestMessage request, System.Net.HttpStatusCode statusCode, HttpError error, Exception innerException)
      : base(message, request, statusCode, error, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="InvalidResponseFormatException"/> class with serialized data.
    /// </summary>
    /// <param name="info">
    /// The <see cref="System.Runtime.Serialization.SerializationInfo"/> that
    /// holds the serialized object data about the exception being thrown.
    /// </param>
    /// <param name="context">
    /// The <see cref="System.Runtime.Serialization.StreamingContext"/> that
    /// contains contextual information about the source or destination.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// The <paramref name="info"/> parameter is null.
    /// </exception>
    /// <exception cref="System.Runtime.Serialization.SerializationException">
    /// The class name is null or <see cref="P:System.Exception.HResult"/> is
    /// zero (0).
    /// </exception>
    protected InvalidResponseFormatException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
      : base(info, context)
    {
    }
  }
}