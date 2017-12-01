using System;
using System.Globalization;
using System.Net.Http;
using System.Reflection;

namespace Decos.Fixi
{
  /// <summary>
  /// Represents a client that connects to the Fixi APIs using HMAC-based authentication.
  /// </summary>
  public class FixiClient : IFixiClient, IDisposable
  {
    private static readonly Refit.RefitSettings refitSettings = new Refit.RefitSettings { UrlParameterFormatter = new InvariantUrlParameterFormatter() };
    private readonly string apiSecret;
    private readonly Lazy<IAttachmentsApi> attachmentsApi;
    private readonly Lazy<HttpClient> httpClient;
    private readonly Lazy<IRegionsApi> regionsApi;
    private readonly Lazy<ITeamsApi> teamsApi;
    private readonly Lazy<IIssuesApi> issuesApi;

    /// <summary>
    /// Initializes a new instance of the <see cref="FixiClient"/> class with the
    /// specified API key, secret key and base address.
    /// </summary>
    /// <param name="apiKey">The application key.</param>
    /// <param name="apiSecret">The application secret key.</param>
    /// <param name="baseAddress">The base address of the Fixi APIs.</param>
    public FixiClient(string apiKey, string apiSecret, Uri baseAddress)
    {
      ApiKey = apiKey;
      this.apiSecret = apiSecret;
      BaseAddress = baseAddress;

      httpClient = new Lazy<HttpClient>(CreateHttpClient);
      attachmentsApi = new Lazy<IAttachmentsApi>(CreateApiInstance<IAttachmentsApi>);
      teamsApi = new Lazy<ITeamsApi>(CreateApiInstance<ITeamsApi>);
      regionsApi = new Lazy<IRegionsApi>(CreateApiInstance<IRegionsApi>);
      issuesApi = new Lazy<IIssuesApi>(CreateApiInstance<IIssuesApi>);
    }

    /// <summary>
    /// Gets the application key.
    /// </summary>
    public string ApiKey { get; }

    /// <summary>
    /// Gets a reference to the attachments API.
    /// </summary>
    public IAttachmentsApi Attachments => attachmentsApi.Value;

    /// <summary>
    /// Gets the base address of the Fixi APIs.
    /// </summary>
    public Uri BaseAddress { get; }

    /// <summary>
    /// Gets a reference to the regions API.
    /// </summary>
    public IRegionsApi Regions => regionsApi.Value;

    /// <summary>
    /// Gets a reference to the teams API.
    /// </summary>
    public ITeamsApi Teams => teamsApi.Value;

    /// <summary>
    /// Gets a reference to the issues API.
    /// </summary>
    public IIssuesApi Issues => issuesApi.Value;

    /// <summary>
    /// Gets an <see cref="HttpClient"/> used to send HTTP requests.
    /// </summary>
    public HttpClient HttpClient => httpClient.Value;

    public void Dispose()
    {
      Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (httpClient.IsValueCreated)
          httpClient.Value.Dispose();
      }
    }

    /// <summary>
    /// Creates a new instance of an API.
    /// </summary>
    /// <typeparam name="T">The type of interface that defines the API.</typeparam>
    /// <returns>A new instance of the API.</returns>
    protected virtual T CreateApiInstance<T>()
    {
      return Refit.RestService.For<T>(HttpClient, refitSettings);
    }

    /// <summary>
    /// Creates a new <see cref="HttpClient"/> for the current application.
    /// </summary>
    /// <returns>A new <see cref="HttpClient"/> object.</returns>
    protected virtual HttpClient CreateHttpClient()
    {
      var defaultHandler = new HttpClientHandler();
      var authenticationHandler = new HmacAuthenticationMessageHandler(ApiKey, apiSecret, defaultHandler);
      return new HttpClient(authenticationHandler)
      {
        BaseAddress = BaseAddress
      };
    }

    /// <summary>
    /// Represents a URL parameter formatter that uses the invariant culture.
    /// </summary>
    private class InvariantUrlParameterFormatter : Refit.IUrlParameterFormatter
    {
      public string Format(object value, ParameterInfo parameterInfo)
      {
        return value != null ? Convert.ToString(value, CultureInfo.InvariantCulture) : null;
      }
    }
  }
}