using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decos.Fixi
{
  public class Team
  {
    public DateTimeOffset? Created { get; set; }

    public string EmailAddress { get; set; }
    public DateTimeOffset? Modified { get; set; }

    public string Name { get; set; }

    public string ShortName { get; set; }
  }
}