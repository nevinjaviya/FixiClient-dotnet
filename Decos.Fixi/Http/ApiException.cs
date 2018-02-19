using System;
using System.Net;

namespace Decos.Fixi.Http
{
  /// <summary>
  /// Represents error that occur during a Fixi API request.
  /// </summary>
  public class ApiException : Exception
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiException"/> class.
    /// </summary>
    public ApiException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiException"/> class with a
    /// specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public ApiException(string message)
      : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiException"/> class with
    /// the specified message, request URI and status code.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="requestUri">The URI of the request.</param>
    /// <param name="statusCode">The status code of the response.</param>
    public ApiException(string message, Uri requestUri, HttpStatusCode statusCode)
      : base(message)
    {
      RequestUri = requestUri;
      StatusCode = statusCode;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiException"/> class with
    /// the specified message, request URI, status code and content.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="requestUri">The URI of the request.</param>
    /// <param name="statusCode">The status code of the response.</param>
    /// <param name="error">The response to the failed request.</param>
    public ApiException(string message, Uri requestUri, HttpStatusCode statusCode, HttpError error)
      : base(message)
    {
      RequestUri = requestUri;
      StatusCode = statusCode;
      Error = error;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiException"/> class with
    /// the specified message, request information and a reference to the inner
    /// exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="requestUri">The URI of the request.</param>
    /// <param name="statusCode">The status code of the response.</param>
    /// <param name="innerException">
    /// The exception that is the cause of the current exception, or a null
    /// reference (Nothing in Visual Basic) if no inner exception is specified.
    /// </param>
    public ApiException(string message, Uri requestUri, HttpStatusCode statusCode, Exception innerException)
      : base(message, innerException)
    {
      RequestUri = requestUri;
      StatusCode = statusCode;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiException"/> class with
    /// the specified message, request information and a reference to the inner
    /// exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="requestUri">The URI of the request.</param>
    /// <param name="statusCode">The status code of the response.</param>
    /// <param name="error">The response to the failed request.</param>
    /// <param name="innerException">
    /// The exception that is the cause of the current exception, or a null
    /// reference (Nothing in Visual Basic) if no inner exception is specified.
    /// </param>
    public ApiException(string message, Uri requestUri, HttpStatusCode statusCode, HttpError error, Exception innerException)
      : base(message, innerException)
    {
      RequestUri = requestUri;
      StatusCode = statusCode;
      Error = error;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiException"/> class with a
    /// specified error message and a reference to the inner exception that is
    /// the cause of this exception.
    /// </summary>
    /// <param name="message">
    /// The error message that explains the reason for the exception.
    /// </param>
    /// <param name="innerException">
    /// The exception that is the cause of the current exception, or a null
    /// reference (Nothing in Visual Basic) if no inner exception is specified.
    /// </param>
    public ApiException(string message, Exception innerException)
      : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiException"/> class with
    /// the specified request URI and response status.
    /// </summary>
    /// <param name="requestUri">The URI of the request.</param>
    /// <param name="statusCode">The status code of the response.</param>
    public ApiException(Uri requestUri, HttpStatusCode statusCode)
      : base(string.Format(Strings.ApiRequestFailedWithStatus, requestUri, statusCode))
    {
      RequestUri = requestUri;
      StatusCode = statusCode;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiException"/> class with
    /// the specified request URI, response status and content.
    /// </summary>
    /// <param name="requestUri">The URI of the request.</param>
    /// <param name="statusCode">The status code of the response.</param>
    /// <param name="error">The response to the failed request.</param>
    public ApiException(Uri requestUri, HttpStatusCode statusCode, HttpError error)
      : base(string.Format(Strings.ApiRequestFailedWithStatusAndMessage, requestUri, statusCode, error))
    {
      RequestUri = requestUri;
      StatusCode = statusCode;
      Error = error;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiException"/> class with
    /// serialized data.
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
    protected ApiException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
      : base(info, context)
    {
    }

    /// <summary>
    /// Gets the response to the request that failed.
    /// </summary>
    public HttpError Error { get; }

    /// <summary>
    /// Gets the URI of the request that failed.
    /// </summary>
    public Uri RequestUri { get; }

    /// <summary>
    /// Gets the HTTP status code of the response.
    /// </summary>
    public HttpStatusCode StatusCode { get; }
  }
}