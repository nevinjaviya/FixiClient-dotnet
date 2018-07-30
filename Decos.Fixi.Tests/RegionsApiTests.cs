using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Decos.Fixi.Tests
{
  [TestClass]
  public class RegionsApiTests : FixiClientTest
  {
    private string RegionShortName => Parameter("region") ?? "decos";

    [TestMethod]
    public async Task FindReturnsResults()
    {
      var regions = await FixiClient.Regions.FindAsync();

      regions.Results.ShouldNotBeEmpty();
    }

    [TestMethod]
    public async Task FindWithOrganizationReturnsResult()
    {
      var organization = Parameter("organization") ?? "decos";

      var regions = await FixiClient.Regions.FindAsync(organization);
      Assert.That.All(regions.Results, x => x.Organization == organization);
    }

    [TestMethod]
    public async Task RegionSupportsEncodedGeometry()
    {
      var geo = await FixiClient.Regions.GetEncodedGeometryAsync(RegionShortName, CancellationToken.None);

      geo.ShouldNotBeEmpty();
      geo.First().ExteriorRing.ShouldNotBeEmpty();
    }

    [TestMethod]
    public async Task RegionSupportsRawGeometry()
    {
      var geo = await FixiClient.Regions.GetRawGeometryAsync(RegionShortName, CancellationToken.None);

      geo.ShouldNotBeEmpty();
      geo.First().ExteriorRing.ShouldNotBeEmpty();
    }

    [TestMethod]
    public async Task RegionSupportsWkbGeometry()
    {
      var wkb = await FixiClient.Regions.GetWellKnownBinaryAsync(RegionShortName, CancellationToken.None);

      wkb.ShouldNotBeEmpty();
    }

    [TestMethod]
    public async Task RegionSupportsWktGeometry()
    {
      var wkt = await FixiClient.Regions.GetWellKnownTextAsync(RegionShortName, CancellationToken.None);

      wkt.ShouldNotBeEmpty();
    }
  }
}