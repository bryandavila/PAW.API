using PAW.Data.MSSQL.ProductDB;
using PAW.Models.Products;
using System.Linq;

namespace PAW.Repository.Products;

/// <summary>
/// Defines the contract for a repository that manages Component entities.
/// </summary>
public interface IComponentRepository
{
    /// <summary>
    /// Retrieves a collection of Component entities asynchronously based on their IDs.
    /// </summary>
    /// <param name="ids">A collection of category IDs.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of Component entities.</returns>
    Task<IEnumerable<Component>> GetAsync(IEnumerable<int> ids);

    /// <summary>
    /// Saves a Component entity asynchronously.
    /// </summary>
    /// <param name="entity">The Component entity to be saved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> SaveAsync(Component entity);

    /// <summary>
    /// Deletes an existing Component entity asynchronously.
    /// </summary>
    /// <param name="entity">The Component entity to be deleted.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> DeleteAsync(Component entity);

    /// <summary>
    /// Updates multiple Component entities asynchronously.
    /// </summary>
    /// <param name="entities">The collection of Component entities to be updated.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> UpdateManyAsync(IEnumerable<Component> entities);
}

/// <summary>
/// Provides an implementation of the IComponentRepository for managing Component entities.
/// </summary>
public class ComponentRepository() : ProductsRepositoryBase<Component>, IComponentRepository
{
    /// <summary>
    /// Saves a Component entity asynchronously. If the entity exists, it updates it; otherwise, it creates a new one.
    /// </summary>
    /// <param name="entity">The Component entity to be saved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    public async Task<bool> SaveAsync(Component entity)
    {
        bool exists = await ExistsAsync(entity);
        if (exists)
            return await UpdateAsync(entity);
        return await CreateAsync(entity);
    }

    /// <summary>
    /// Retrieves a collection of Component entities asynchronously based on their IDs.
    /// </summary>
    /// <param name="ids">A collection of component IDs.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of Component entities.</returns>
    public async Task<IEnumerable<Component>> GetAsync(IEnumerable<int> ids)
    {
        if (ids != null && ids.Count() == 1)
            return [await FindAsync(ids.FirstOrDefault())];

        Func<Component, bool> predicate = ids == null
            ? x => x.Id > 0
            : x => ids.Contains((int)x.Id);

        var categories = await ReadAsync();
        return categories.Where(predicate);
    }
}
