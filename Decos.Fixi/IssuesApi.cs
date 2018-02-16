using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Decos.Fixi
{
  public class IssuesApi : RestApi, IIssuesApi
  {
    public IssuesApi(HttpClient httpClient) : base(httpClient)
    {
    }

    public Task<ListPage<IssueListItem>> FindAsync(
        string q = null,
        bool searchPrivateInfo = false,
        string reportedBy = null,
        string assignedTo = null,
        string[] category = null,
        Status[] status = null,
        DateTimeOffset? from = null,
        DateTimeOffset? to = null,
        int page = 1,
        int count = 20,
        CancellationToken cancellationToken = default(CancellationToken))
    {
      var args = new { q, searchPrivateInfo, reportedBy, assignedTo, category, status, from, to, page, count };
      return GetAsync<ListPage<IssueListItem>>("/issues?api-version=2.0", args, cancellationToken);
    }

    public Task<Issue> GetAsync(string id, CancellationToken cancellationToken)
    {
      return GetAsync<Issue>($"/issues/{id}", cancellationToken);
    }

    public Task<Issue> UpdateAsync(string id, IssueChanges issueData, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }
}