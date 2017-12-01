using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace Decos.Fixi
{
  public interface ITeamsApi
  {
    [Post("/organizations/{organization}/teams/{team}/members/{emailAddress}")]
    Task<Team> AddMember(string organization, string team, string emailAddress, CancellationToken cancellationToken);
  }
}