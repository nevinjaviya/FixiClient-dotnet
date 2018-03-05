using System;
using System.Globalization;
using System.Net.Http;
using System.Reflection;
using Decos.Fixi.Http;

namespace Decos.Fixi
{
  /// <summary>
  /// Represents a client that connects to the Fixi APIs using HMAC-based authentication.
  /// </summary>
  public class FixiClient : IFixiClient, IDisposable
  {
    private readonly string apiSecret;
    private readonly Lazy<IAttachmentsApi> attachmentsApi;
    private readonly Lazy<ICategoriesApi> categoriesApi;
    private readonly Lazy<HttpClient> httpClient;
    private readonly Lazy<IIssuesApi> issuesApi;
    private readonly Lazy<IOrganizationsApi> organizationsApi;
    private readonly Lazy<IRegionsApi> regionsApi;
    private readonly Lazy<ITeamsApi> teamsApi;
    private readonly Lazy<IUsersApi> usersApi;

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
      regionsApi = new Lazy<IRegionsApi>(() => new RegionsApi(HttpClient));
      issuesApi = new Lazy<IIssuesApi>(() => new IssuesApi(HttpClient));
      organizationsApi = new Lazy<IOrganizationsApi>(CreateApiInstance<IOrganizationsApi>);
      usersApi = new Lazy<IUsersApi>(() => new UsersApi(HttpClient));
      categoriesApi = new Lazy<ICategoriesApi>(() => new CategoriesApi(HttpClient));
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
    /// Gets a reference to the categories API.
    /// </summary>
    public ICategoriesApi Categories => categoriesApi.Value;

    /// <summary>
    /// Gets an <see cref="HttpClient"/> used to send HTTP requests.
    /// </summary>
    public HttpClient HttpClient => httpClient.Value;

    /// <summary>
    /// Gets a reference to the issues API.
    /// </summary>
    public IIssuesApi Issues => issuesApi.Value;

    /// <summary>
    /// Gets a reference to the organizations API.
    /// </summary>
    public IOrganizationsApi Organizations => organizationsApi.Value;

    /// <summary>
    /// Gets a reference to the regions API.
    /// </summary>
    public IRegionsApi Regions => regionsApi.Value;

    /// <summary>
    /// Gets a reference to the teams API.
    /// </summary>
    public ITeamsApi Teams => teamsApi.Value;

    /// <summary>
    /// Gets a reference to the users API.
    /// </summary>
    public IUsersApi Users => usersApi.Value;

    private Refit.RefitSettings RefitSettings
    {
      get
      {
        var settings = new Refit.RefitSettings
        {
          JsonSerializerSettings = new Newtonsoft.Json.JsonSerializerSettings
          {
            DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
          },
          UrlParameterFormatter = new FixiApiUrlParameterFormatter()
        };
        settings.JsonSerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter() { CamelCaseText = true });
        return settings;
      }
    }

    /// <summary>
    /// Releases the managed and unmanaged resources used by the <see cref="FixiClient"/>.
    /// </summary>
    public void Dispose()
    {
      Dispose(true);
    }

    /// <summary>
    /// Creates a new instance of an API.
    /// </summary>
    /// <typeparam name="T">The type of interface that defines the API.</typeparam>
    /// <returns>A new instance of the API.</returns>
    protected virtual T CreateApiInstance<T>()
    {
      return Refit.RestService.For<T>(HttpClient, RefitSettings);
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
    /// Releases the unmanaged resources used by the <see cref="FixiClient"/> and
    /// optionally disposes of the managed resources.
    /// </summary>
    /// <param name="disposing">
    /// <c>true</c> to release both managed and unmanaged resources; <c>false</c>
    /// to releases only unmanaged resources.
    /// </param>
    protected virtual void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (httpClient.IsValueCreated)
          httpClient.Value.Dispose();
      }
    }

    /// <summary>
    /// Represents a URL parameter formatter that formats parameter values
    /// according to ASP.NET/Fixi API expectations.
    /// </summary>
    private class FixiApiUrlParameterFormatter : Refit.IUrlParameterFormatter
    {
      public string Format(object value, ParameterInfo parameterInfo)
      {
        if (value == null)
          return null;

        return Convert.ToString(value, CultureInfo.InvariantCulture);
      }
    }
  }
}