using PAW.Models.Products;
using System.Linq;

namespace PAW.Repository.Products;

/// <summary>
/// Defines the contract for a repository that manages UserAction entities.
/// </summary>
public interface IUserActionRepository
{
    /// <summary>
    /// Retrieves a collection of UserAction entities asynchronously based on their IDs.
    /// </summary>
    /// <param name="ids">A collection of UserAction IDs.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of UserAction entities.</returns>
    Task<IEnumerable<UserAction>> GetAsync(IEnumerable<int> ids);

    /// <summary>
    /// Saves a UserAction entity asynchronously.
    /// </summary>
    /// <param name="entity">The UserAction entity to be saved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> SaveAsync(UserAction entity);

    /// <summary>
    /// Deletes an existing UserAction entity asynchronously.
    /// </summary>
    /// <param name="entity">The UserAction entity to be deleted.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> DeleteAsync(UserAction entity);

    /// <summary>
    /// Updates multiple UserAction entities asynchronously.
    /// </summary>
    /// <param name="entities">The collection of UserAction entities to be updated.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> UpdateManyAsync(IEnumerable<UserAction> entities);
}

/// <summary>
/// Provides an implementation of the IUserActionRepository for managing UserAction entities.
/// </summary>
public class UserActionRepository() : ProductsRepositoryBase<UserAction>, IUserActionRepository
{
    /// <summary>
    /// Saves a UserAction entity asynchronously. If the entity exists, it updates it; otherwise, it creates a new one.
    /// </summary>
    /// <param name="entity">The UserAction entity to be saved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    public async Task<bool> SaveAsync(UserAction entity)
    {
        bool exists = await ExistsAsync(entity);
        if (exists)
            return await UpdateAsync(entity);
        return await CreateAsync(entity);
    }

    /// <summary>
    /// Retrieves a collection of UserAction entities asynchronously based on their IDs.
    /// </summary>
    /// <param name="ids">A collection of UserAction IDs.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of UserAction entities.</returns>
    public async Task<IEnumerable<UserAction>> GetAsync(IEnumerable<int> ids)
    {
        if (ids != null && ids.Count() == 1)
            return [await FindAsync(ids.FirstOrDefault())];

        Func<UserAction, bool> predicate = ids == null
            ? x => x.Id > 0
            : x => ids.Contains((int)x.Id);

        var categories = await ReadAsync();
        return categories.Where(predicate);
    }
}
