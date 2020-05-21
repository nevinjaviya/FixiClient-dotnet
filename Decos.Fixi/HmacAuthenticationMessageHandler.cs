using System;
using System.Security.Cryptography;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;

namespace Decos.Fixi
{
  /// <summary>
  /// Represents an HTTP message handler that adds a Fixi-compatible
  /// Authorization header to HTTP requests.
  /// </summary>
  public class HmacAuthenticationMessageHandler : DelegatingHandler
  {
    private const string HmacAuthenticationScheme = "Hmac";
    private readonly HashAlgorithm hashAlgorithm;

    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="HmacAuthenticationMessageHandler"/> class with the specified key
    /// and secret.
    /// </summary>
    /// <param name="key">The API client application key.</param>
    /// <param name="secret">The API client application secret key.</param>
    public HmacAuthenticationMessageHandler(string key, string secret)
    {
      ApiKey = key;

      var secretKey = Encoding.UTF8.GetBytes(secret);
      hashAlgorithm = new HMACSHA512(secretKey);
    }

    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="HmacAuthenticationMessageHandler"/> class with the specified key,
    /// secret and inner handler.
    /// </summary>
    /// <param name="key">The API client application key.</param>
    /// <param name="secret">The API client application secret key.</param>
    /// <param name="innerHandler">
    /// The inner handler which is responsible for processing the HTTP response messages.
    /// </param>
    public HmacAuthenticationMessageHandler(string key, string secret, HttpMessageHandler innerHandler) : base(innerHandler)
    {
      ApiKey = key;

      var secretKey = Encoding.UTF8.GetBytes(secret);
      hashAlgorithm = new HMACSHA512(secretKey);
    }

    /// <summary>
    /// Gets the API key that identifies the client application.
    /// </summary>
    public string ApiKey { get; }

    /// <summary>
    /// Releases the unmanaged resources used by the <see
    /// cref="DelegatingHandler"/>, and optionally disposes of the managed resources.
    /// </summary>
    /// <param name="disposing">
    /// true to release both managed and unmanaged resources; false to releases
    /// only unmanaged resources.
    /// </param>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        hashAlgorithm?.Dispose();
      }

      base.Dispose(disposing);
    }

    /// <summary>
    /// Sends an HTTP request to the inner handler to send to the server as an
    /// asynchronous operation.
    /// </summary>
    /// <returns>
    /// Returns <see cref="Task{TResult}"/>. The task object representing the
    /// asynchronous operation.
    /// </returns>
    /// <param name="request">The HTTP request message to send to the server.</param>
    /// <param name="cancellationToken">A cancellation token to cancel operation.</param>
    /// <exception cref="ArgumentNullException">
    /// The <paramref name="request"/> was null.
    /// </exception>
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
      request.Headers.Authorization = await GetAuthorizationAsync(request).ConfigureAwait(false);
      return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    }

    private static async Task<string> GetContentHashAsync(HttpContent content)
    {
      using (var md5 = MD5.Create())
      {
        // Note: ReadAsStreamAsync can only be used once and will cause actions
        // with [FromBody] parameters to be null! The string and byte[] methods
        // do not share this problem and can be safely used here.
        var rawContent = content != null ? await content.ReadAsByteArrayAsync().ConfigureAwait(false) : new byte[0];
        var hash = md5.ComputeHash(rawContent);
        return Convert.ToBase64String(hash);
      }
    }

    private static string GetNonce() => Guid.NewGuid().ToString();

    private static string GetTimestamp() => DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString(CultureInfo.InvariantCulture);

    private async Task<System.Net.Http.Headers.AuthenticationHeaderValue> GetAuthorizationAsync(HttpRequestMessage request)
    {
      var nonce = GetNonce();
      var timestamp = GetTimestamp();
      var signature = await GetSignatureAsync(request, nonce, timestamp).ConfigureAwait(false);

      var authorizationValue = string.Join(":", ApiKey, signature, nonce, timestamp);
      var authorizationData = Encoding.UTF8.GetBytes(authorizationValue);
      var authorizationHash = Convert.ToBase64String(authorizationData);
      return new System.Net.Http.Headers.AuthenticationHeaderValue(HmacAuthenticationScheme, authorizationHash);
    }

    private async Task<string> GetSignatureAsync(HttpRequestMessage request, string nonce, string timestamp)
    {
      var contentHash = await GetContentHashAsync(request.Content).ConfigureAwait(false);
      var token = string.Concat(ApiKey, request.Method.Method, request.RequestUri.AbsoluteUri, nonce, timestamp, contentHash);
      var tokenData = Encoding.UTF8.GetBytes(token);
      var tokenHash = hashAlgorithm.ComputeHash(tokenData);
      return Convert.ToBase64String(tokenHash);
    }
  }
}