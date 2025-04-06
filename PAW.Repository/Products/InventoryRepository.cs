using PAW.Models.Products;

namespace PAW.Repository.Products;

/// <summary>
/// Defines the contract for a repository that manages Inventory entities.
/// </summary>
public interface IInventoryRepository
{
    /// <summary>
    /// Retrieves a collection of Inventory entities asynchronously based on their IDs.
    /// </summary>
    /// <param name="ids">A collection of inventory IDs.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of Inventory entities.</returns>
    Task<IEnumerable<Inventory>> GetAsync(IEnumerable<int> ids);

    /// <summary>
    /// Saves a Inventory entity asynchronously.
    /// </summary>
    /// <param name="entity">The Inventory entity to be saved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> SaveAsync(Inventory entity);

    /// <summary>
    /// Deletes an existing Inventory entity asynchronously.
    /// </summary>
    /// <param name="entity">The Inventory entity to be deleted.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> DeleteAsync(Inventory entity);

    /// <summary>
    /// Updates multiple Inventory entities asynchronously.
    /// </summary>
    /// <param name="entities">The collection of Inventory entities to be updated.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> UpdateManyAsync(IEnumerable<Inventory> entities);
}

/// <summary>
/// Provides an implementation of the IInventoryRepository for managing Inventory entities.
/// </summary>
public class InventoryRepository() : ProductsRepositoryBase<Inventory>, IInventoryRepository
{
    /// <summary>
    /// Saves a Inventory entity asynchronously. If the entity exists, it updates it; otherwise, it creates a new one.
    /// </summary>
    /// <param name="entity">The Inventory entity to be saved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    public async Task<bool> SaveAsync(Inventory entity)
    {
        bool exists = await ExistsAsync(entity);
        if (exists)
            return await UpdateAsync(entity);
        return await CreateAsync(entity);
    }

    /// <summary>
    /// Retrieves a collection of Inventory entities asynchronously based on their IDs.
    /// </summary>
    /// <param name="ids">A collection of Inventory IDs.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of Inventory entities.</returns>
    public async Task<IEnumerable<Inventory>> GetAsync(IEnumerable<int> ids)
    {
        if (ids != null && ids.Count() == 1)
            return [await FindAsync(ids.FirstOrDefault())];

        Func<Inventory, bool> predicate = ids == null
            ? x => x.InventoryId > 0
            : x => ids.Contains((int)x.InventoryId);

        var categories = await ReadAsync();
        return categories.Where(predicate);
    }
}
