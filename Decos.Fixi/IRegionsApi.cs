using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace Decos.Fixi
{
  public interface IRegionsApi
  {
    [Post("/regions")]
    Task<Region> AddAsync(Region data, CancellationToken cancellationToken);

    [Get("/regions/{region}")]
    Task<Region> GetAsync(string region, CancellationToken cancellationToken);

    [Get("/regions/atlocation")]
    Task<PagedResult<Region>> AtLocationAsync(double latitude, double longitude, int page = 1, int count = 20, CancellationToken cancellationToken = default(CancellationToken));
  }
}