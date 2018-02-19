using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Decos.Fixi.Http
{
  /// <summary>
  /// Represents a RESTful API.
  /// </summary>
  public abstract class RestApi
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="RestApi"/> class that uses
    /// the specified <see cref="System.Net.Http.HttpClient"/>.
    /// </summary>
    /// <param name="httpClient">
    /// An <see cref="System.Net.Http.HttpClient"/> for sending requests.
    /// </param>
    protected RestApi(HttpClient httpClient)
    {
      if (httpClient == null)
        throw new ArgumentNullException(nameof(httpClient));

      HttpClient = httpClient;
      Formatters = new MediaTypeFormatterCollection();
    }

    /// <summary>
    /// Gets a collection of formatters used to deserialize HTTP response messages.
    /// </summary>
    public MediaTypeFormatterCollection Formatters { get; }

    /// <summary>
    /// Gets an HTTP client for sending API requests.
    /// </summary>
    public HttpClient HttpClient { get; }

    /// <summary>
    /// Sends a GET request to the specified URI.
    /// </summary>
    /// <typeparam name="TResult">The type of object to read.</typeparam>
    /// <param name="requestUri">The URI to send a request to.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>
    /// A task that returns an object instance of the specified type.
    /// </returns>
    /// <exception cref="InvalidResponseFormatException">
    /// An error occurred during deserialization of the response.
    /// </exception>
    protected Task<TResult> GetAsync<TResult>(string requestUri, CancellationToken cancellationToken)
    {
      return GetAsync<TResult>(requestUri, null, cancellationToken);
    }

    /// <summary>
    /// Sends a GET request to the specified URI using an object to provide
    /// request parameters.
    /// </summary>
    /// <typeparam name="TResult">The type of object to read.</typeparam>
    /// <param name="requestUri">The URI to send a request to.</param>
    /// <param name="parameters">
    /// An object whose public properties are sent as query string parameters.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>
    /// A task that returns an object instance of the specified type.
    /// </returns>
    /// <exception cref="ApiException">An error occurred the request.</exception>
    /// <exception cref="InvalidResponseFormatException">
    /// An error occurred during deserialization of the response.
    /// </exception>
    protected async Task<TResult> GetAsync<TResult>(string requestUri, object parameters, CancellationToken cancellationToken)
    {
      try
      {
        if (parameters != null)
        {
          var query = QueryStringParameterCollection.FromObject(parameters);
          requestUri = UriUtility.AddQuery(requestUri, query);
        }

        var response = await HttpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
          throw await ApiRequestFailedAsync(response, cancellationToken).ConfigureAwait(false);

        return await response.Content.ReadAsAsync<TResult>(Formatters, cancellationToken).ConfigureAwait(false);
      }
      catch (JsonReaderException ex)
      {
        throw InvalidResponseFormat<TResult>(ex);
      }
    }

    private async Task<ApiException> ApiRequestFailedAsync(HttpResponseMessage response, CancellationToken cancellationToken)
    {
      try
      {
        var error = await response.Content.ReadAsAsync<HttpError>(Formatters, cancellationToken).ConfigureAwait(false);
        return new ApiException(response.RequestMessage.RequestUri, response.StatusCode, error);
      }
      catch (JsonReaderException ex)
      {
        var message = string.Format(Strings.InvalidErrorResponse_Json, response.RequestMessage.RequestUri, response.StatusCode);
        return new InvalidResponseFormatException(message, response.RequestMessage.RequestUri, response.StatusCode, ex);
      }
    }

    private InvalidResponseFormatException InvalidResponseFormat<TExpected>(JsonReaderException ex)
    {
      var message = string.Format(Strings.InvalidResponse_Json, typeof(TExpected));
      return new InvalidResponseFormatException(message, ex);
    }
  }
}