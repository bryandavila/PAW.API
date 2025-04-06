using PAW.Models.Products;

namespace PAW.Repository.Products;

/// <summary>
/// Defines the contract for a repository that manages Category entities.
/// </summary>
public interface ICategoryRepository
{
    /// <summary>
    /// Retrieves a collection of Category entities asynchronously based on their IDs.
    /// </summary>
    /// <param name="ids">A collection of category IDs.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of Category entities.</returns>
    Task<IEnumerable<Category>> GetAsync(IEnumerable<int> ids);

    /// <summary>
    /// Saves a Category entity asynchronously.
    /// </summary>
    /// <param name="entity">The Category entity to be saved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> SaveAsync(Category entity);

    /// <summary>
    /// Deletes an existing Category entity asynchronously.
    /// </summary>
    /// <param name="entity">The Category entity to be deleted.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> DeleteAsync(Category entity);

    /// <summary>
    /// Updates multiple Category entities asynchronously.
    /// </summary>
    /// <param name="entities">The collection of Category entities to be updated.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> UpdateManyAsync(IEnumerable<Category> entities);
}


/// <summary>
/// Provides an implementation of the ICategoryRepository for managing Category entities.
/// </summary>
public class CategoryRepository : ProductsRepositoryBase<Category>, ICategoryRepository
{
    /// <summary>
    /// Saves a Category entity asynchronously. If the entity exists, it updates it; otherwise, it creates a new one.
    /// </summary>
    /// <param name="entity">The Category entity to be saved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    public async Task<bool> SaveAsync(Category entity)
    {
        bool exists = await ExistsAsync(entity);
        if (exists)
            return await UpdateAsync(entity);
        return await CreateAsync(entity);
    }

    /// <summary>
    /// Retrieves a collection of Category entities asynchronously based on their IDs.
    /// </summary>
    /// <param name="ids">A collection of category IDs.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of Category entities.</returns>
    public async Task<IEnumerable<Category>> GetAsync(IEnumerable<int> ids)
    {
        if (ids != null && ids.Count() == 1)
            return [await FindAsync(ids.FirstOrDefault())];

        Func<Category, bool> predicate = ids == null
            ? x => x.CategoryId > 0
            : x => ids.Contains(x.CategoryId);

        var categories = await ReadAsync();
        return categories.Where(predicate);
    }
}

