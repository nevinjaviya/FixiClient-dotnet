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
    [TestMethod]
    public async Task FindReturnsResults()
    {
      var regions = await FixiClient.Organizations.FindAsync();
      regions.Results.ShouldNotBeEmpty();
    }
  }
}