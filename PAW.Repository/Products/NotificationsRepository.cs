using PAW.Data.MSSQL.ProductDB;
using PAW.Models.Products;
using System.Linq;

namespace PAW.Repository.Products;

/// <summary>
/// Defines the contract for a repository that manages Notification entities.
/// </summary>
public interface INotificationRepository
{
    /// <summary>
    /// Retrieves a collection of Notification entities asynchronously based on their IDs.
    /// </summary>
    /// <param name="ids">A collection of Notification IDs.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of Notification entities.</returns>
    Task<IEnumerable<Notification>> GetAsync(IEnumerable<int> ids);

    /// <summary>
    /// Saves a Notification entity asynchronously.
    /// </summary>
    /// <param name="entity">The Notification entity to be saved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> SaveAsync(Notification entity);

    /// <summary>
    /// Deletes an existing Notification entity asynchronously.
    /// </summary>
    /// <param name="entity">The Notification entity to be deleted.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> DeleteAsync(Notification entity);

    /// <summary>
    /// Updates multiple Notification entities asynchronously.
    /// </summary>
    /// <param name="entities">The collection of Notification entities to be updated.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> UpdateManyAsync(IEnumerable<Notification> entities);
}

/// <summary>
/// Provides an implementation of the INotificationRepository for managing Notification entities.
/// </summary>
public class NotificationRepository() : ProductsRepositoryBase<Notification>(), INotificationRepository
{
    /// <summary>
    /// Saves a Notification entity asynchronously. If the entity exists, it updates it; otherwise, it creates a new one.
    /// </summary>
    /// <param name="entity">The Notification entity to be saved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    public async Task<bool> SaveAsync(Notification entity)
    {
        bool exists = await ExistsAsync(entity);
        if (exists)
            return await UpdateAsync(entity);
        return await CreateAsync(entity);
    }

    /// <summary>
    /// Retrieves a collection of Notification entities asynchronously based on their IDs.
    /// </summary>
    /// <param name="ids">A collection of Notification IDs.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of Notification entities.</returns>
    public async Task<IEnumerable<Notification>> GetAsync(IEnumerable<int> ids)
    {
        if (ids != null && ids.Count() == 1)
            return [await FindAsync(ids.FirstOrDefault())];

        Func<Notification, bool> predicate = ids == null
            ? x => x.Id > 0
            : x => ids.Contains((int)x.Id);

        var categories = await ReadAsync();
        return categories.Where(predicate);
    }
}
