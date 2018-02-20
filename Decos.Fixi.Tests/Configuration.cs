using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Decos.Fixi.Tests
{
  [TestClass]
  public static class Configuration
  {
    public static string ApiKey => Parameter("apiKey");
    public static string ApiSecret => Parameter("apiSecret");
    public static string BaseAddress => Parameter("apiBaseAddress");
    public static TestContext Context { get; private set; }

    [AssemblyInitialize]
    public static void OnStartup(TestContext context)
    {
      Context = context;

      Assert.IsNotNull(ApiKey, "apiKey is not configured. Make sure a valid test settings file is selected.");
      Assert.IsNotNull(ApiSecret, "apiSecret is not configured. Make sure a valid test settings file is selected.");
      Assert.IsNotNull(BaseAddress, "apiBaseAddress is not configured. Make sure a valid test settings file is selected.");
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
    public static string Parameter(string name)
    {
      if (Context == null)
        throw new InvalidOperationException("Test run parameters cannot be retrieved when the TestContext is not available. Ensure the test is running using the MSTest adapter and that the " + nameof(OnStartup) + " has run.");

      if (!Context.Properties.Contains(name))
        return null;

      return Convert.ToString(Context.Properties[name], CultureInfo.InvariantCulture);
    }
  }
}