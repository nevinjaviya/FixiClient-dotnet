using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Text;
using System.Web;

namespace Decos.Fixi.Http
{
  /// <summary>
  /// Represents a collection of query string parameters.
  /// </summary>
  public class QueryStringParameterCollection : IEnumerable
  {
    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="QueryStringParameterCollection"/> class.
    /// </summary>
    public QueryStringParameterCollection()
      : this(new NameValueCollection())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="QueryStringParameterCollection"/> class that wraps the specified
    /// name value collection.
    /// </summary>
    /// <param name="collection">
    /// The collection that is wrapped by the new collection.
    /// </param>
    public QueryStringParameterCollection(NameValueCollection collection)
    {
      if (collection == null)
        throw new ArgumentNullException(nameof(collection));

      Collection = collection;
    }

    /// <summary>
    /// Gets a collection of the names of parameters in the collection.
    /// </summary>
    public ICollection<string> Names => Collection.AllKeys;

    /// <summary>
    /// Gets the internal collection of parameters.
    /// </summary>
    protected internal NameValueCollection Collection { get; }

    /// <summary>
    /// Creates a new instance of the <see
    /// cref="QueryStringParameterCollection"/> class using the names and values
    /// of public properties from the specified object.
    /// </summary>
    /// <param name="parameters">An object whose public properties to use.</param>
    /// <returns>A new <see cref="QueryStringParameterCollection"/> object.</returns>
    public static QueryStringParameterCollection FromObject(object parameters)
    {
      if (parameters == null)
        throw new ArgumentNullException(nameof(parameters));

      var queryStringParameters = new QueryStringParameterCollection();

      var type = parameters.GetType();
      foreach (var property in type.GetProperties())
      {
        var name = property.Name;
        var value = property.GetValue(parameters);
        if (value != null)
          queryStringParameters.Add(name, value);
      }

      return queryStringParameters;
    }

    /// <summary>
    /// Converts a query string to the equivalent <see
    /// cref="QueryStringParameterCollection"/> class.
    /// </summary>
    /// <param name="query">The string to convert.</param>
    /// <returns>An object that contains the query string that was parsed.</returns>
    public static QueryStringParameterCollection Parse(string query)
    {
      var queryStringParameters = new QueryStringParameterCollection();

      if (query == null)
        throw new ArgumentNullException(nameof(query));

      var queryStart = query.LastIndexOf('?');
      if (queryStart >= 0)
        query = query.Substring(queryStart + 1);

      foreach (var item in query.Split('&'))
      {
        if (string.IsNullOrEmpty(item))
          continue;

        var separator = item.IndexOf('=');
        if (separator >= 0)
        {
          var name = HttpUtility.UrlDecode(item.Substring(0, separator));
          var value = HttpUtility.UrlDecode(item.Substring(separator + 1));
          queryStringParameters.Add(name, value);
        }
        else
        {
          queryStringParameters.Add(item, null);
        }
      }

      return queryStringParameters;
    }

    /// <summary>
    /// Adds an entry with the specified name and value.
    /// </summary>
    /// <param name="name">The name of the entry to add.</param>
    /// <param name="value">The value of the entry to add.</param>
    public QueryStringParameterCollection Add(string name, string value)
    {
      Collection.Add(name, value);
      return this;
    }

    /// <summary>
    /// Adds an entry with the specified name and value using the invariant culture.
    /// </summary>
    /// <param name="name">The name of the entry to add.</param>
    /// <param name="value">The value of the entry to add.</param>
    public QueryStringParameterCollection Add(string name, object value)
    {
      Add(name, value, CultureInfo.InvariantCulture);
      return this;
    }

    /// <summary>
    /// Adds an entry with the specified name and value using the specified
    /// culture-specific formatting information.
    /// </summary>
    /// <param name="name">The name of the entry to add.</param>
    /// <param name="value">The value of the entry to add.</param>
    /// <param name="provider">
    /// An object that specifies culture-specific formatting information.
    /// </param>
    /// <remarks>
    /// If <paramref name="value"/> implements <see cref="IEnumerable"/>, all
    /// values will be added separately with the same name.
    /// </remarks>
    public virtual QueryStringParameterCollection Add(string name, object value, IFormatProvider provider)
    {
      if (value is IEnumerable)
      {
        foreach (var item in (IEnumerable)value)
          Add(name, Convert.ToString(item, provider));
        return this;
      }

      Add(name, Convert.ToString(value, provider));
      return this;
    }

    /// <summary>
    /// Copies the entries in the specified <see
    /// cref="QueryStringParameterCollection"/> to the current collection.
    /// </summary>
    /// <param name="collection">The collection whose entries to copy.</param>
    public QueryStringParameterCollection Add(QueryStringParameterCollection collection)
    {
      Add(collection.Collection);
      return this;
    }

    /// <summary>
    /// Copies the entries in the specified <see
    /// cref="System.Collections.Specialized.NameValueCollection"/> to the
    /// current collection.
    /// </summary>
    /// <param name="collection">The collection whose entries to copy.</param>
    public QueryStringParameterCollection Add(NameValueCollection collection)
    {
      Collection.Add(collection);
      return this;
    }

    /// <summary>
    /// Returns an enumerator that iterates through the names in the collection.
    /// </summary>
    /// <returns>
    /// An <see cref="IEnumerator"/> object that can be used to iterate through
    /// the names in the collection.
    /// </returns>
    public IEnumerator GetEnumerator()
    {
      return Collection.GetEnumerator();
    }

    /// <summary>
    /// Returns a query string that represents the query string parameter collection.
    /// </summary>
    /// <returns>A string that represents the current collection.</returns>
    public override string ToString()
    {
      var queryString = new StringBuilder();
      foreach (var name in Names)
      {
        var values = Collection.GetValues(name);
        if (values == null)
          continue;

        foreach (var value in values)
        {
          queryString.Append(Uri.EscapeDataString(name));
          queryString.Append('=');
          queryString.Append(Uri.EscapeDataString(value));
          queryString.Append('&');
        }
      }

      if (queryString.Length > 0)
        queryString.Remove(queryString.Length - 1, 1);
      return queryString.ToString();
    }
  }
}