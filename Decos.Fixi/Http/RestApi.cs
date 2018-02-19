using System;
using System.IO;
using System.Linq;
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
    private const int BufferSize = 81920;
    private static readonly HttpMethod Patch = new HttpMethod("PATCH");

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
    /// Sends a DELETE request to the specified URI.
    /// </summary>
    /// <param name="requestUri">The URI to send a request to.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="ApiException">An error occurred the request.</exception>
    /// <exception cref="InvalidResponseFormatException">
    /// An error occurred during deserialization of the response.
    /// </exception>
    protected Task DeleteAsync(string requestUri, CancellationToken cancellationToken)
    {
      return SendAsync(HttpMethod.Delete, requestUri, null, cancellationToken);
    }

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
    /// <exception cref="ApiException">An error occurred the request.</exception>
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
    protected Task<TResult> GetAsync<TResult>(string requestUri, object parameters, CancellationToken cancellationToken)
    {
      return SendAsync<TResult>(HttpMethod.Get, requestUri, parameters, cancellationToken);
    }

    /// <summary>
    /// Sends a POST request to the specified URI with the specified content.
    /// </summary>
    /// <typeparam name="T">The type of object to send.</typeparam>
    /// <typeparam name="TResult">The type of object to read.</typeparam>
    /// <param name="requestUri">The URI to send a request to.</param>
    /// <param name="value">The value to send in the request.</param>
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
    protected Task<TResult> PostAsync<T, TResult>(string requestUri, T value, CancellationToken cancellationToken)
    {
      return SendAsync<T, TResult>(HttpMethod.Post, requestUri, null, value, cancellationToken);
    }

    /// <summary>
    /// Sends a PATCH request to the specified URI with the specified content.
    /// </summary>
    /// <typeparam name="T">The type of object to send.</typeparam>
    /// <typeparam name="TResult">The type of object to read.</typeparam>
    /// <param name="requestUri">The URI to send a request to.</param>
    /// <param name="value">The value to send in the request.</param>
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
    protected Task<TResult> PatchAsync<T, TResult>(string requestUri, T value, CancellationToken cancellationToken)
    {
      return SendAsync<T, TResult>(Patch, requestUri, null, value, cancellationToken);
    }

    /// <summary>
    /// Sends a POST request to the specified URI using an object to provide
    /// request parameters and writes the response body to the specified stream.
    /// </summary>
    /// <param name="requestUri">The URI to send a request to.</param>
    /// <param name="parameters">
    /// An object whose public properties are sent as query string parameters.
    /// </param>
    /// <param name="destination">
    /// The stream that the content of the response will be written to.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    protected async Task PostToStreamAsync(string requestUri, object parameters, Stream destination, CancellationToken cancellationToken)
    {
      using (var response = await SendAsync(HttpMethod.Post, requestUri, parameters, cancellationToken).ConfigureAwait(false))
      using (var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
      {
        await stream.CopyToAsync(destination, BufferSize, cancellationToken).ConfigureAwait(false);
      }
    }

    /// <summary>
    /// Sends an HTTP request to the specified URI using an object to provide
    /// request parameters.
    /// </summary>
    /// <param name="httpMethod">The HTTP method.</param>
    /// <param name="requestUri">The URI to send a request to.</param>
    /// <param name="parameters">
    /// An object whose public properties are sent as query string parameters.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns the HTTP response message.</returns>
    /// <exception cref="ApiException">An error occurred the request.</exception>
    protected async Task<HttpResponseMessage> SendAsync(HttpMethod httpMethod, string requestUri, object parameters, CancellationToken cancellationToken)
    {
      var uri = BuildRequestUri(requestUri, parameters);
      var request = new HttpRequestMessage(httpMethod, uri);

      var response = await HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
      if (!response.IsSuccessStatusCode)
        throw await ApiRequestFailedAsync(response, cancellationToken).ConfigureAwait(false);

      return response;
    }

    /// <summary>
    /// Sends an HTTP request with the specified content to the specified URI
    /// using an object to provide request parameters.
    /// </summary>
    /// <typeparam name="T">The type of object to send.</typeparam>
    /// <param name="httpMethod">The HTTP method.</param>
    /// <param name="requestUri">The URI to send a request to.</param>
    /// <param name="parameters">
    /// An object whose public properties are sent as query string parameters.
    /// </param>
    /// <param name="value">The value to send in the request.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns the HTTP response message.</returns>
    /// <exception cref="ApiException">An error occurred the request.</exception>
    protected async Task<HttpResponseMessage> SendAsync<T>(HttpMethod httpMethod, string requestUri, object parameters, T value, CancellationToken cancellationToken)
    {
      var uri = BuildRequestUri(requestUri, parameters);
      var request = new HttpRequestMessage(httpMethod, uri)
      {
        Content = new ObjectContent<T>(value, Formatters.First())
      };

      var response = await HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
      if (!response.IsSuccessStatusCode)
        throw await ApiRequestFailedAsync(response, cancellationToken).ConfigureAwait(false);

      return response;
    }

    /// <summary>
    /// Sends an HTTP request to the specified URI using an object to provide
    /// request parameters and deserializes the response.
    /// </summary>
    /// <typeparam name="TResult">The type of object to read.</typeparam>
    /// <param name="httpMethod">The HTTP method.</param>
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
    protected async Task<TResult> SendAsync<TResult>(HttpMethod httpMethod, string requestUri, object parameters, CancellationToken cancellationToken)
    {
      try
      {
        using (var response = await SendAsync(httpMethod, requestUri, parameters, cancellationToken).ConfigureAwait(false))
        {
          return await response.Content.ReadAsAsync<TResult>(Formatters, cancellationToken).ConfigureAwait(false);
        }
      }
      catch (JsonReaderException ex)
      {
        throw InvalidResponseFormat<TResult>(ex);
      }
    }

    /// <summary>
    /// Sends an HTTP request with the specified content to the specified URI
    /// using an object to provide request parameters, and deserializes the response.
    /// </summary>
    /// <typeparam name="T">The type of object to send.</typeparam>
    /// <typeparam name="TResult">The type of object to read.</typeparam>
    /// <param name="httpMethod">The HTTP method.</param>
    /// <param name="requestUri">The URI to send a request to.</param>
    /// <param name="parameters">
    /// An object whose public properties are sent as query string parameters.
    /// </param>
    /// <param name="value">The value to send in the request.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>
    /// A task that returns an object instance of the specified type.
    /// </returns>
    /// <exception cref="ApiException">An error occurred the request.</exception>
    protected async Task<TResult> SendAsync<T, TResult>(HttpMethod httpMethod, string requestUri, object parameters, T value, CancellationToken cancellationToken)
    {
      try
      {
        using (var response = await SendAsync(httpMethod, requestUri, parameters, value, cancellationToken).ConfigureAwait(false))
        {
          return await response.Content.ReadAsAsync<TResult>(Formatters, cancellationToken).ConfigureAwait(false);
        }
      }
      catch (JsonReaderException ex)
      {
        throw InvalidResponseFormat<TResult>(ex);
      }
    }

    private static Uri BuildRequestUri(string requestUri, object parameters)
    {
      if (parameters != null)
      {
        var query = QueryStringParameterCollection.FromObject(parameters);
        requestUri = UriUtility.AddQuery(requestUri, query);
      }

      return new Uri(requestUri, UriKind.RelativeOrAbsolute);
    }

    private async Task<ApiException> ApiRequestFailedAsync(HttpResponseMessage response, CancellationToken cancellationToken)
    {
      try
      {
        var error = await response.Content.ReadAsAsync<HttpError>(Formatters, cancellationToken).ConfigureAwait(false);
        return new ApiException(response.RequestMessage, response.StatusCode, error);
      }
      catch (JsonReaderException ex)
      {
        var message = string.Format(Strings.InvalidErrorResponse_Json, response.RequestMessage.Method, response.RequestMessage.RequestUri, response.StatusCode);
        return new InvalidResponseFormatException(message, response.RequestMessage, response.StatusCode, ex);
      }
    }

    private InvalidResponseFormatException InvalidResponseFormat<TExpected>(JsonReaderException ex)
    {
      var message = string.Format(Strings.InvalidResponse_Json, typeof(TExpected));
      return new InvalidResponseFormatException(message, ex);
    }
  }
}