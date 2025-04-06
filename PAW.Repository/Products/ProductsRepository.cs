using PAW.Data.MSSQL.ProductDB;
using PAW.Models.Products;
using System.Linq;

namespace PAW.Repository.Products;

/// <summary>
/// Defines the contract for a repository that manages Product entities.
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Retrieves a collection of Product entities asynchronously based on their IDs.
    /// </summary>
    /// <param name="ids">A collection of Product IDs.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of Product entities.</returns>
    Task<IEnumerable<Product>> GetAsync(IEnumerable<int> ids);

    /// <summary>
    /// Saves a Product entity asynchronously.
    /// </summary>
    /// <param name="entity">The Product entity to be saved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> SaveAsync(Product entity);

    /// <summary>
    /// Deletes an existing Product entity asynchronously.
    /// </summary>
    /// <param name="entity">The Product entity to be deleted.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> DeleteAsync(Product entity);

    /// <summary>
    /// Updates multiple Product entities asynchronously.
    /// </summary>
    /// <param name="entities">The collection of Product entities to be updated.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> UpdateManyAsync(IEnumerable<Product> entities);
}

/// <summary>
/// Provides an implementation of the IProductRepository for managing Product entities.
/// </summary>
public class ProductRepository() : ProductsRepositoryBase<Product>, IProductRepository
{
    /// <summary>
    /// Saves a Product entity asynchronously. If the entity exists, it updates it; otherwise, it creates a new one.
    /// </summary>
    /// <param name="entity">The Product entity to be saved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    public async Task<bool> SaveAsync(Product entity)
    {
        bool exists = await ExistsAsync(entity);
        if (exists)
            return await UpdateAsync(entity);
        return await CreateAsync(entity);
    }

    /// <summary>
    /// Retrieves a collection of Product entities asynchronously based on their IDs.
    /// </summary>
    /// <param name="ids">A collection of Product IDs.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of Product entities.</returns>
    public async Task<IEnumerable<Product>> GetAsync(IEnumerable<int> ids)
    {
        if (ids != null && ids.Count() == 1)
            return [await FindAsync(ids.FirstOrDefault())];

        Func<Product, bool> predicate = ids == null
            ? x => x.ProductId > 0
            : x => ids.Contains((int)x.ProductId);

        var categories = await ReadAsync();
        return categories.Where(predicate);
    }
}
