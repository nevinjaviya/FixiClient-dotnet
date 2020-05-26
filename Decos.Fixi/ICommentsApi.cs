using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Decos.Fixi.Models;
using Refit;

namespace Decos.Fixi
{
  /// <summary>
  /// Defines the methods available in the canned responses API.
  /// </summary>
  public interface ICommentsApi
  {
    /// <summary>
    /// Deletes an existing comment.
    /// </summary>
    /// <param name="issue">The issue identifier.</param>
    /// <param name="id">The comment identifier.</param>
    /// <returns>The result of the action.</returns>
    [Delete("/issues/{issue}/comments/{id}")]
    Task DeleteAsync(string issue, string id);

    /// <summary>
    /// Returns a list of comments for an issue.
    /// </summary>
    /// <param name="issue">The issue identifier.</param>
    /// <param name="sort">Optionally specifies a sort method to use.</param>
    /// <param name="page">An optional non-zero positive integer indicating the number of the page to retrieve.</param>
    /// <param name="count">An optional non-zero positive integer indicating the number of results to return per page.</param>
    /// <returns>The result of the action.</returns>
    [Get("/issues/{issue}/comments")]
    Task<ListPage<CommentListItem>> FindAsync(string issue, CommentsSortMethod sort = CommentsSortMethod.Default, int page = 1, int count = 20);

    /// <summary>
    /// Returns the specified comment.
    /// </summary>
    /// <param name="issue">The issue identifier.</param>
    /// <param name="id">The comment identifier.</param>
    /// <returns>The result of the action.</returns>
    [Get("/issues/{issue}/comments/{id}")]
    Task<CommentListItem> GetAsync(string issue, string id);

    /// <summary>
    /// Updates an existing comment.
    /// </summary>
    /// <param name="issue">The issue identifier.</param>
    /// <param name="id">The comment identifier.</param>
    /// <param name="data">The modified comment.</param>
    /// <returns>The result of the action.</returns>
    [Patch("/issues/{issue}/comments/{id}")]
    Task<CommentListItem> PatchAsync(string issue, string id, CommentDto data);

    /// <summary>
    /// Adds a new comment to an issue.
    /// </summary>
    /// <param name="issue">The issue identifier.</param>
    /// <param name="data">The comment data.</param>
    /// <returns>The result of the action.</returns>
    [Post("/issues/{issue}/comments")]
    Task<CommentListItem> PostAsync(string issue, CommentDto data);
  }
}