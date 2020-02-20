using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Decos.Fixi.Tests
{
  [TestClass]
  public class OrganizationsApiTests : FixiClientTest
  {
    private string RegionShortName => Parameter("region") ?? "decos";

    [TestMethod]
    public async Task FindReturnsResults()
    {
      var regions = await FixiClient.Organizations.FindAsync();
      regions.Results.ShouldNotBeEmpty();
    }
  }
}