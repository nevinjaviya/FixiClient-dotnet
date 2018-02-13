using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decos.Fixi
{
  public class PagedResult<T>
  {
    public int Count { get; set; }
    public IEnumerable<T> Results { get; set; }
  }
}