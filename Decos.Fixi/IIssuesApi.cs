using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace Decos.Fixi
{
  public interface IIssuesApi
  {
    /// <summary>
    /// Returns the issue with the specified ID.
    /// </summary>
    /// <param name="id">The public issue ID.</param>
    /// <returns>The issue with the specified ID.</returns>
    [Get("/issues/{id}")]
    Task<Issue> GetAsync(string id);

    /// <summary>
    /// Updates an existing issue.
    /// </summary>
    /// <param name="id">The public issue ID.</param>
    /// <param name="issueData">The modified issue data.</param>
    /// <returns>The updated issue.</returns>
    [Patch("/issues/{id}")]
    Task<Issue> UpdateAsync(string id, IssueChanges issueData);
  }
}