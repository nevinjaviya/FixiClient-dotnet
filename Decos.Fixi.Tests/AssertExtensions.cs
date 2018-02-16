using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Decos.Fixi.Tests
{
  /// <summary>
  /// Provides a set of static methods to test various conditions within unit tests.
  /// </summary>
  public static class AssertExtensions
  {
    /// <summary>
    /// Tests whether all elements in a collection satisfy a condition.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="assert"></param>
    /// <param name="collection">The collection to test.</param>
    /// <param name="predicate">The condition to test for.</param>
    /// <param name="message">A message to include in the exception.</param>
    public static void All<T>(this Assert assert, IEnumerable<T> collection, Func<T, bool> predicate, string message = null)
    {
      if (collection == null)
        throw new AssertFailedException($"{nameof(collection)} was not set to an instance of an object. {message}");

      var failed = collection.FirstOrDefault(x => !predicate(x));
      var count = collection.Count(x => !predicate(x));

      if (!EqualityComparer<T>.Default.Equals(failed, default(T)))
      {
        throw new AssertFailedException($"{count} element(s) do not satisfy the condition. First mismatch: {failed}. {message}");
      }
    }
  }
}