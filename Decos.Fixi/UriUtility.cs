using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decos.Fixi
{
  public static class UriUtility
  {
    public static string AddQuery(string uri, QueryStringParameterCollection query)
    {
      var queryFromPath = QueryStringParameterCollection.Parse(uri);

      var queryPosition = uri.LastIndexOf('?');
      if (queryPosition >= 0)
      {
        uri = uri.Substring(0, queryPosition);
      }

      var newQuery = queryFromPath.Add(query);
      return uri + '?' + newQuery;
    }
  }
}