using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Decos.Fixi.Http;

namespace Decos.Fixi.Tests
{
  [TestClass]
  public class QueryStringParameterCollectionTests
  {
    [TestMethod]
    public void QueryStringParameterCollectionCanContainMultipleValuesWithTheSameName()
    {
      var collection = new QueryStringParameterCollection();
      collection.Add("a", "1");
      collection.Add("a", "2");

      CollectionAssert.AreEqual(new[] { "1", "2" }, collection.Collection.GetValues("a"));
    }

    [TestMethod]
    public void QueryStringParameterCollectionCanParseMultipleValuesWithTheSameName()
    {
      var collection = QueryStringParameterCollection.Parse("a=1&a=2&a=3");

      CollectionAssert.AreEquivalent(new[] { "1", "2", "3" },
        collection.Collection.GetValues("a"));
    }

    [DataTestMethod]
    [DataRow("value=a%20b", "a b")]
    [DataRow("value=a+b", "a b")]
    [DataRow("value=%f0%9f%92%a9", "💩")]
    public void QueryStringParameterCollectionDecodesParameterValues(string query, string expectedValue)
    {
      var collection = QueryStringParameterCollection.Parse(query);

      Assert.AreEqual(expectedValue, collection.Collection["value"]);
    }

    [DataTestMethod]
    [DataRow("a b", "value=a%20b")]
    [DataRow("a+b", "value=a%2Bb")]
    [DataRow("💩", "value=%F0%9F%92%A9")]
    public void QueryStringParameterCollectionEncodesParameterValues(string value, string expected)
    {
      var collection = new QueryStringParameterCollection();
      collection.Add("value", value);

      Assert.AreEqual(expected, collection.ToString());
    }

    [TestMethod]
    public void QueryStringParameterCollectionIgnoresLeadingQuestionMarkInParseValue()
    {
      var collection = QueryStringParameterCollection.Parse("?name=value");

      CollectionAssert.AreEquivalent(new[] { "name" }, collection.Names.ToArray());
    }

    [TestMethod]
    public void QueryStringParameterCollectionIncludesMultipleValuesWithTheSameNameInStringRepresentation()
    {
      var collection = new QueryStringParameterCollection()
      {
        { "a", "1" },
        { "a", "2" },
        { "b", "3" }
      };

      Assert.AreEqual("a=1&a=2&b=3", collection.ToString());
    }

    [TestMethod]
    public void QueryStringParameterCollectionIgnoresNullValuesWhenConstructingFromObject()
    {
      var collection = QueryStringParameterCollection.FromObject(new { a = (string)null });

      CollectionAssert.DoesNotContain(collection.Names.ToArray(), "a");
    }

    [TestMethod]
    public void QueryStringParameterCollectionAddsMultipleValuesForEnumerableTypes()
    {
      var collection = new QueryStringParameterCollection();
      collection.Add("value", new[] { "1", "2", "3" });

      CollectionAssert.AreEquivalent(new[] { "1", "2", "3" }, collection.Collection.GetValues("value"));
    }
  }
}