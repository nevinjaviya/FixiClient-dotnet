using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Decos.Fixi.Tests
{
  [TestClass]
  public static class Configuration
  {
    private static string baseAddress;
    private static string apiKey;
    private static string apiSecret;

    public static Uri BaseAddress => new Uri(baseAddress);
    public static string ApiKey => apiKey;
    public static string ApiSecret => apiSecret;

    [AssemblyInitialize]
    public static void OnStartup(TestContext context)
    {
      baseAddress = context.Properties["apiBaseAddress"] as string;
      apiKey = context.Properties["apiKey"] as string;
      apiSecret = context.Properties["apiSecret"] as string;

      Assert.IsNotNull(baseAddress, "apiBaseAddress is not configured.");
      Assert.IsNotNull(apiKey, "apiKey is not configured.");
      Assert.IsNotNull(apiSecret, "apiSecret is not configured.");
    }
  }
}