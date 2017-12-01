using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decos.Fixi
{
  public class Issue
  {
    public string ID { get; set; }

    public Category Category { get; set; }

    public string RegionName { get; set; }

    public Point Location { get; set; }
  }
}