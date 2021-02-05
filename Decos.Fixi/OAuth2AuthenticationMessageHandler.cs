using System;
using System.Security.Cryptography;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using System.Runtime.Caching;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Decos.Fixi
{
  /// <summary>
  /// Represents an HTTP message handler that adds a Fixi-compatible Authorization header to HTTP requests.
  /// </summary>
  public class OAuth2AuthenticationMessageHandler : DelegatingHandler
  {
    private const string BearerAuthenticationScheme = "Bearer";
    private string BearerToken = "BearerToken";

    /// <summary>
    /// Initializes a new instance of the <see cref="OAuth2AuthenticationMessageHandler"/> class with the specified key and secret.
    /// </summary>
    /// <param name="key">The API client application key.</param>
    /// <param name="secret">The API client application secret key.</param>
    public OAuth2AuthenticationMessageHandler(string key, string secret)
    {
      BearerToken = $"{BearerToken}-{key}";
      ApiKey = key;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OAuth2AuthenticationMessageHandler"/> class with the specified key, secret and inner handler.
    /// </summary>
    /// <param name="key">The API client application key.</param>
    /// <param name="secret">The API client application secret key.</param>
    /// <param name="innerHandler">The inner handler which is responsible for processing the HTTP response messages.</param>
    /// <param name="customerId"></param>
    public OAuth2AuthenticationMessageHandler(string key, string secret, HttpMessageHandler innerHandler, string customerId = null) : base(innerHandler)
    {
      ApiKey = key;
      Secret = secret;
      CustomerId = customerId;
    }

    /// <summary>
    /// Gets the API key that identifies the client application.
    /// </summary>
    public string ApiKey { get; }

    /// <summary>
    /// Gets the API client application secret.
    /// </summary>
    public string Secret { get; }

    /// <summary>
    /// Customer Id
    /// </summary>
    public string CustomerId { get; }

    /// <summary>
    /// Releases the unmanaged resources used by the <see cref="DelegatingHandler"/>, and optionally disposes of the managed resources.
    /// </summary>
    /// <param name="disposing">true to release both managed and unmanaged resources; false to releases only unmanaged resources.</param>
    protected override void Dispose(bool disposing)
    {
      base.Dispose(disposing);
    }

    /// <summary>
    /// Sends an HTTP request to the inner handler to send to the server as an asynchronous operation.
    /// </summary>
    /// <param name="request">The HTTP request message to send to the server.</param>
    /// <param name="cancellationToken">A cancellation token to cancel operation.</param>
    /// <exception cref="ArgumentNullException">The <paramref name="request"/> was null.</exception>
    /// <returns>Returns <see cref="Task{TResult}"/>. The task object representing the asynchronous operation.</returns>
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
      request.Headers.Authorization = await GetAuthorizationAsync(request).ConfigureAwait(false);
      return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    }

    private async Task<System.Net.Http.Headers.AuthenticationHeaderValue> GetAuthorizationAsync(HttpRequestMessage request)
    {
      var cache = MemoryCache.Default;
      var token = (Token)cache[BearerToken];
      if (token == null)
      {
        token = await GetToken(request);
        cache[BearerToken] = token;
      }
      else
      {
        var expiresOn = DateTime.Parse(token.Expires);
        // If Token is about to expire in few minutes get new token by refredh token.
        if (expiresOn < DateTime.Now.AddMinutes(5))
        {
          try
          {
            token = await GetTokenByRefreshToken(request, token.RefreshToken);
          }
          catch (Exception ex)
          {
            if (ex.Message.Contains("invalid_grant"))
            {
              cache.Remove(BearerToken);
              return await GetAuthorizationAsync(request);
            }
          }
          cache[BearerToken] = token;
        }
      }

      return new System.Net.Http.Headers.AuthenticationHeaderValue(BearerAuthenticationScheme, token.AccessToken);
    }

    private async Task<Token> GetToken(HttpRequestMessage req)
    {
      var dict = new Dictionary<string, string>() {
        { "client_id", ApiKey }, { "client_secret", Secret }, { "CustomerId", CustomerId }, { "scope", "geoservice.all" }, {"grant_type", "client_credentials" },
        { "Content-Type", "application/x-www-form-urlencoded" }
      };
      return await GetToken(req, dict);
    }

    private async Task<Token> GetTokenByRefreshToken(HttpRequestMessage req, string refreshToken)
    {
      var dict = new Dictionary<string, string>() {
        { "refresh_token", refreshToken }, {"grant_type", "refresh_token" },
        { "Content-Type", "application/x-www-form-urlencoded" }
      };

      return await GetToken(req, dict);
    }

    private async Task<Token> GetToken(HttpRequestMessage req, Dictionary<string, string> dict)
    {
      var request = new HttpRequestMessage(HttpMethod.Post, GetTokenUrl(req.RequestUri));
      request.Content = new FormUrlEncodedContent(dict);

      var response = await base.SendAsync(request, default(CancellationToken));
      if (response.StatusCode == System.Net.HttpStatusCode.OK)
        return await response.Content.ReadAsAsync<Token>();

      var errorMsg = await response.Content.ReadAsStringAsync();
      throw new Exception(errorMsg);
    }

    private string GetTokenUrl(Uri uri) => uri.GetLeftPart(UriPartial.Authority) + "/Token";
  }
}