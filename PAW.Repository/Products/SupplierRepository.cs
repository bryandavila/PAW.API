using PAW.Models.Products;
using System.Linq;

namespace PAW.Repository.Products;

/// <summary>
/// Defines the contract for a repository that manages Supplier entities.
/// </summary>
public interface ISupplierRepository
{
    /// <summary>
    /// Retrieves a collection of Supplier entities asynchronously based on their IDs.
    /// </summary>
    /// <param name="ids">A collection of Supplier IDs.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of Supplier entities.</returns>
    Task<IEnumerable<Supplier>> GetAsync(IEnumerable<int> ids);

    /// <summary>
    /// Saves a Supplier entity asynchronously.
    /// </summary>
    /// <param name="entity">The Supplier entity to be saved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> SaveAsync(Supplier entity);

    /// <summary>
    /// Deletes an existing Supplier entity asynchronously.
    /// </summary>
    /// <param name="entity">The Supplier entity to be deleted.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> DeleteAsync(Supplier entity);

    /// <summary>
    /// Updates multiple Supplier entities asynchronously.
    /// </summary>
    /// <param name="entities">The collection of Supplier entities to be updated.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> UpdateManyAsync(IEnumerable<Supplier> entities);
}

/// <summary>
/// Provides an implementation of the ISupplierRepository for managing Supplier entities.
/// </summary>
public class SupplierRepository() : ProductsRepositoryBase<Supplier>, ISupplierRepository
{
    /// <summary>
    /// Saves a Supplier entity asynchronously. If the entity exists, it updates it; otherwise, it creates a new one.
    /// </summary>
    /// <param name="entity">The Supplier entity to be saved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    public async Task<bool> SaveAsync(Supplier entity)
    {
        bool exists = await ExistsAsync(entity);
        if (exists)
            return await UpdateAsync(entity);
        return await CreateAsync(entity);
    }

    /// <summary>
    /// Retrieves a collection of Supplier entities asynchronously based on their IDs.
    /// </summary>
    /// <param name="ids">A collection of Supplier IDs.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of Supplier entities.</returns>
    public async Task<IEnumerable<Supplier>> GetAsync(IEnumerable<int> ids)
    {
        if (ids != null && ids.Count() == 1)
            return [await FindAsync(ids.FirstOrDefault())];

        Func<Supplier, bool> predicate = ids == null
            ? x => x.SupplierId > 0
            : x => ids.Contains((int)x.SupplierId);

        var categories = await ReadAsync();
        return categories.Where(predicate);
    }
}