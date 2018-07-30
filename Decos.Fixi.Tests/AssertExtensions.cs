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

    /// <summary>
    /// Tests whether any element in a collection satisfies a condition.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="assert"></param>
    /// <param name="collection">The collection to test.</param>
    /// <param name="predicate">The condition to test for.</param>
    /// <param name="message">A message to include in the exception.</param>
    public static void Any<T>(this Assert assert, IEnumerable<T> collection, Func<T, bool> predicate, string message = null)
    {
      if (collection == null)
        throw new ArgumentNullException(nameof(collection));

      if (!collection.Any(predicate))
        throw new AssertFailedException($"The collection does not contain any elements that satisfy the condition. {message}");
    }

    /// <summary>
    /// Test whether a collection contains any elements.
    /// </summary>
    /// <typeparam name="T">The type of elements in <paramref name="collection"/>.</typeparam>
    /// <param name="collection">The collection to test.</param>
    /// <param name="message">
    /// A message to include in the exception that occurs when <paramref
    /// name="collection"/> is empty.
    /// </param>
    public static void ShouldNotBeEmpty<T>(this IEnumerable<T> collection, string message = null)
    {
      if (collection == null)
        throw new AssertFailedException($"The collection is null. {message}");

      if (!collection.Any())
        throw new AssertFailedException($"The collection does not contain any elements. {message}");
    }

    /// <summary>
    /// Test whether a string is not empty.
    /// </summary>
    /// <param name="value">The string to test.</param>
    /// <param name="message">
    /// A message to include in the exception that occurs when <paramref
    /// name="value"/> is empty.
    /// </param>
    public static void ShouldNotBeEmpty(this string value, string message = null)
    {
      if (value == null)
        throw new AssertFailedException($"The string is null. {message}");

      if (value.Length == 0)
        throw new AssertFailedException($"The string is empty. {message}");
    }
  }
}