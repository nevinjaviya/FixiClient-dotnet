using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Decos.Fixi.Http
{
  /// <summary>
  /// Represents a RESTful API client to manage categories in Fixi.
  /// </summary>
  public class CategoriesApi : RestApi, ICategoriesApi
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="CategoriesApi"/> class that uses the specified <see cref="HttpClient"/>.
    /// </summary>
    /// <param name="httpClient">An <see cref="HttpClient"/> for sending requests.</param>
    public CategoriesApi(HttpClient httpClient) : base(httpClient)
    {
    }

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
    public Task<ListPage<Category>> FindAsync(string region, bool? includeInactive = null, int page = 1, int count = 20, CancellationToken cancellationToken = default(CancellationToken))
    {
      var args = new { includeInactive, page, count };
      return GetAsync<ListPage<Category>>($"/regions/{Uri.EscapeDataString(region)}/categories?api-version=2.0", args, cancellationToken);
    }

    /// <summary>
    /// Returns the specified category in a region.
    /// </summary>
    /// <param name="region">The short name of the region.</param>
    /// <param name="category">The short name of the category.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns a specified category.</returns>
    public Task<Category> GetAsync(string region, string category, CancellationToken cancellationToken = default(CancellationToken))
    {
      return GetAsync<Category>($"/regions/{Uri.EscapeDataString(region)}/categories/{Uri.EscapeDataString(category)}?api-version=2.0", cancellationToken);
    }

    /// <summary>
    /// Creates a new category and adds it to the region.
    /// </summary>
    /// <param name="region">The short name of the region.</param>
    /// <param name="data">The category data.</param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>A task that returns a created category.</returns>
    public Task<Category> AddAsync(string region, CategoryData data, CancellationToken cancellationToken = default(CancellationToken))
    {
      return PostAsync<CategoryData, Category>($"/regions/{Uri.EscapeDataString(region)}/categories?api-version=2.0", data, cancellationToken);
    }

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
    public Task<Category> UpdateAsync(string region, string category, CategoryData data, CancellationToken cancellationToken = default(CancellationToken))
    {
      return PatchAsync<CategoryData, Category>($"/regions/{Uri.EscapeDataString(region)}/categories/{Uri.EscapeDataString(category)}?api-version=2.0", data, cancellationToken);
    }

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
    public Task<ListPage<Subcategory>> FindAsync(string region, string category, bool includeInactive = false, int page = 1, int count = 20, CancellationToken cancellationToken = default(CancellationToken))
    {
      var args = new { includeInactive, page, count };
      return GetAsync<ListPage<Subcategory>>($"/regions/{Uri.EscapeDataString(region)}/categories/{Uri.EscapeDataString(category)}/subcategories?api-version=2.0", args, cancellationToken);
    }

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
    public Task<Subcategory> GetAsync(string region, string category, string id, CancellationToken cancellationToken = default(CancellationToken))
    {
      return GetAsync<Subcategory>($"/regions/{Uri.EscapeDataString(region)}/categories/{Uri.EscapeDataString(category)}/subcategories/{Uri.EscapeDataString(id)}?api-version=2.0", cancellationToken);
    }

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
    public Task<Subcategory> AddAsync(string region, string category, CategoryData data, CancellationToken cancellationToken = default(CancellationToken))
    {
      return PostAsync<CategoryData, Subcategory>($"/regions/{Uri.EscapeDataString(region)}/categories/{Uri.EscapeDataString(category)}/subcategories?api-version=2.0", data, cancellationToken);
    }

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
    public Task<Subcategory> UpdateAsync(string region, string category, string id, CategoryData data, CancellationToken cancellationToken = default(CancellationToken))
    {
      return PatchAsync<CategoryData, Subcategory>($"/regions/{Uri.EscapeDataString(region)}/categories/{Uri.EscapeDataString(category)}/subcategories/{Uri.EscapeDataString(id)}?api-version=2.0", data, cancellationToken);
    }
  }
}
