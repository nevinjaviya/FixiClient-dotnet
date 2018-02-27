using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Decos.Fixi.Tests
{
  public abstract class FixiClientTest
  {
    public string ApiKey => Parameter("apiKey");
    public string ApiSecret => Parameter("apiSecret");
    public string BaseAddress => Parameter("apiBaseAddress");
    public TestContext TestContext { get; set; }
    public FixiClient FixiClient { get; private set; }

    /// <summary>
    /// Returns the test run parameter with the specified name, or <c>null</c> if
    /// it was not found.
    /// </summary>
    /// <param name="name">The name of the test run parameter.</param>
    /// <returns>
    /// The string value of the test run parameter with the specified name, or a
    /// null reference if there is no test run parameter <paramref name="name"/>.
    /// </returns>
    public string this[string name] => Parameter(name);

    [TestCleanup]
    public void OnTestFinished()
    {
      FixiClient?.Dispose();
    }

    [TestInitialize]
    public void OnTestStarting()
    {
      Assert.IsNotNull(ApiKey, "apiKey is not configured. Make sure a valid test settings file is selected.");
      Assert.IsNotNull(ApiSecret, "apiSecret is not configured. Make sure a valid test settings file is selected.");
      Assert.IsNotNull(BaseAddress, "apiBaseAddress is not configured. Make sure a valid test settings file is selected.");

      FixiClient = new FixiClient(ApiKey, ApiSecret, new Uri(BaseAddress));
    }

    /// <summary>
    /// Returns the test run parameter with the specified name, or <c>null</c> if
    /// it was not found.
    /// </summary>
    /// <param name="name">The name of the test run parameter.</param>
    /// <returns>
    /// The string value of the test run parameter with the specified name, or a
    /// null reference if there is no test run parameter <paramref name="name"/>.
    /// </returns>
    public string Parameter(string name)
    {
      if (TestContext == null)
        throw new InvalidOperationException("Test run parameters cannot be retrieved when the TestContext is not available. Ensure the test is running using the MSTest adapter.");

      if (!TestContext.Properties.Contains(name))
        return null;

      return Convert.ToString(TestContext.Properties[name], CultureInfo.InvariantCulture);
    }
  }
}