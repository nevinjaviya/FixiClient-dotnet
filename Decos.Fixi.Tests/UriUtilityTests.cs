using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Decos.Fixi.Http;

namespace Decos.Fixi.Tests
{
  [TestClass]
  public class UriUtilityTests
  {
    [TestMethod]
    public void OriginalQueryStringValuesArePreservedWhenAddingEmptyQuery()
    {
      var query = new QueryStringParameterCollection();
      var result = UriUtility.AddQuery("path?a=1", query);

      Assert.AreEqual("path?a=1", result);
    }

    [TestMethod]
    public void QueryStringValuesAreAddedToExistingQuery()
    {
      var query = new QueryStringParameterCollection()
      {
        { "a", "2" }
      };
      var result = UriUtility.AddQuery("path?a=1", query);

      Assert.AreEqual("path?a=1&a=2", result);
    }

    [TestMethod]
    public void QueryStringValuesAreAddedToUri()
    {
      var query = new QueryStringParameterCollection()
      {
        { "a", "1" }
      };
      var result = UriUtility.AddQuery("path", query);

      Assert.AreEqual("path?a=1", result);
    }
  }
}