using PAW.Models.Products;
using System.Linq;

namespace PAW.Repository.Products;

/// <summary>
/// Defines the contract for a repository that manages Task entities.
/// </summary>
public interface ITaskRepository
{
    /// <summary>
    /// Retrieves a collection of Task entities asynchronously based on their IDs.
    /// </summary>
    /// <param name="ids">A collection of Task IDs.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of Task entities.</returns>
    Task<IEnumerable<PAW.Models.Products.Task>> GetAsync(IEnumerable<int> ids);

    /// <summary>
    /// Saves a Task entity asynchronously.
    /// </summary>
    /// <param name="entity">The Task entity to be saved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> SaveAsync(PAW.Models.Products.Task entity);

    /// <summary>
    /// Deletes an existing Task entity asynchronously.
    /// </summary>
    /// <param name="entity">The Task entity to be deleted.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> DeleteAsync(PAW.Models.Products.Task entity);

    /// <summary>
    /// Updates multiple Task entities asynchronously.
    /// </summary>
    /// <param name="entities">The collection of Task entities to be updated.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> UpdateManyAsync(IEnumerable<PAW.Models.Products.Task> entities);
}

/// <summary>
/// Provides an implementation of the ITaskRepository for managing Task entities.
/// </summary>
public class TaskRepository() : ProductsRepositoryBase<PAW.Models.Products.Task>, ITaskRepository
{
    /// <summary>
    /// Saves a Task entity asynchronously. If the entity exists, it updates it; otherwise, it creates a new one.
    /// </summary>
    /// <param name="entity">The Task entity to be saved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    public async Task<bool> SaveAsync(PAW.Models.Products.Task entity)
    {
        bool exists = await ExistsAsync(entity);
        if (exists)
            return await UpdateAsync(entity);
        return await CreateAsync(entity);
    }

    /// <summary>
    /// Retrieves a collection of Task entities asynchronously based on their IDs.
    /// </summary>
    /// <param name="ids">A collection of Task IDs.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of Task entities.</returns>
    public async Task<IEnumerable<PAW.Models.Products.Task>> GetAsync(IEnumerable<int> ids)
    {
        if (ids != null && ids.Count() == 1)
            return [await FindAsync(ids.FirstOrDefault())];

        Func<PAW.Models.Products.Task, bool> predicate = ids == null
            ? x => x.Id > 0
            : x => ids.Contains((int)x.Id);

        var categories = await ReadAsync();
        return categories.Where(predicate);
    }
}
