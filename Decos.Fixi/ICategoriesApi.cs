using Decos.Fixi.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Decos.Fixi
{
  /// <summary>
  /// Defines the methods available in the categories API.
  /// </summary>
  public interface ICategoriesApi
  {
    /// <summary>
    /// Returns a list of categories in a region, ordered by priority and name.
    /// </summary>
    /// <param name="region">The short name of the region.</param>
    /// <param name="includeInactive">
    /// If <c>true</c>, deactivated categories are also retrieved. The default
    /// value is <c>false</c>.
    /// </param>
    /// <param name="page">
    /// An optional non-zero positive integer indicating the number of the page
    /// to retrieve.
    /// </param>
    /// <param name="count">
    /// An optional non-zero positive integer indicating the number of results to
    /// return per page.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns a single page of categories.</returns>
    Task<ListPage<CategoryResponse>> FindAsync(string region, bool? includeInactive = null, int page = 1, int count = 20, CancellationToken cancellationToken = default(CancellationToken));

    /// <summary>
    /// Returns the specified category in a region.
    /// </summary>
    /// <param name="region">The short name of the region.</param>
    /// <param name="category">The short name of the category.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns a specified category.</returns>
    Task<CategoryResponse> GetAsync(string region, string category, CancellationToken cancellationToken = default(CancellationToken));

    /// <summary>
    /// Creates a new category and adds it to the region.
    /// </summary>
    /// <param name="region">The short name of the region.</param>
    /// <param name="data">The category data.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns a created category.</returns>
    Task<CategoryResponse> AddAsync(string region, CategoryData data, CancellationToken cancellationToken = default(CancellationToken));

    /// <summary>
    /// Updates an existing category.
    /// </summary>
    /// <param name="region">The short name of the region.</param>
    /// <param name="category">The short name of the category.</param>
    /// <param name="data">The modified category data.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns the updated category.</returns>
    Task<CategoryResponse> UpdateAsync(string region, string category, CategoryData data, CancellationToken cancellationToken = default(CancellationToken));

    /// <summary>
    /// Returns a list of subcategories in a category, ordered by priority and name.
    /// </summary>
    /// <param name="region">The short name of the region.</param>
    /// <param name="category">The short name of the main category.</param>
    /// <param name="includeInactive">
    /// If <c>true</c>, deactivated categories are also retrieved. The default
    /// value is <c>false</c>.
    /// </param>
    /// <param name="page">
    /// An optional non-zero positive integer indicating the number of the page
    /// to retrieve.
    /// </param>
    /// <param name="count">
    /// An optional non-zero positive integer indicating the number of results to
    /// return per page.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns a single page of subcategories.</returns>
    Task<ListPage<SubcategoryResponse>> FindAsync(string region, string category, bool includeInactive = false, int page = 1, int count = 20, CancellationToken cancellationToken = default(CancellationToken));

    /// <summary>
    /// Returns the specified subcategory in a category.
    /// </summary>
    /// <param name="region">The short name of the region.</param>
    /// <param name="category">The short name of the main category.</param>
    /// <param name="id">The short name of the subcategory.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns a specified subcategory.</returns>
    Task<SubcategoryResponse> GetAsync(string region, string category, string id, CancellationToken cancellationToken = default(CancellationToken));

    /// <summary>
    /// Creates a new subcategory.
    /// </summary>
    /// <param name="region">The short name of the region.</param>
    /// <param name="category">The short name of the main category.</param>
    /// <param name="data">The category data.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns a created subcategory.</returns>
    Task<SubcategoryResponse> AddAsync(string region, string category, CategoryData data, CancellationToken cancellationToken = default(CancellationToken));

    /// <summary>
    /// Updates an existing subcategory.
    /// </summary>
    /// <param name="region">The short name of the region.</param>
    /// <param name="category">The short name of the main category.</param>
    /// <param name="id">The short name of the subcategory to update.</param>
    /// <param name="data">The modified category data.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns the updated subcategory.</returns>
    Task<SubcategoryResponse> UpdateAsync(string region, string category, string id, CategoryData data, CancellationToken cancellationToken = default(CancellationToken));
  }
}