using PAW.Models.Products;
using System.Linq;

namespace PAW.Repository.Products;

/// <summary>
/// Defines the contract for a repository that manages UserRole entities.
/// </summary>
public interface IUserRoleRepository
{
    /// <summary>
    /// Retrieves a collection of UserRole entities asynchronously based on their IDs.
    /// </summary>
    /// <param name="ids">A collection of UserRole IDs.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of UserRole entities.</returns>
    Task<IEnumerable<UserRole>> GetAsync(IEnumerable<int> ids);

    /// <summary>
    /// Saves a UserRole entity asynchronously.
    /// </summary>
    /// <param name="entity">The UserRole entity to be saved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> SaveAsync(UserRole entity);

    /// <summary>
    /// Deletes an existing UserRole entity asynchronously.
    /// </summary>
    /// <param name="entity">The UserRole entity to be deleted.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> DeleteAsync(UserRole entity);

    /// <summary>
    /// Updates multiple UserRole entities asynchronously.
    /// </summary>
    /// <param name="entities">The collection of UserRole entities to be updated.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> UpdateManyAsync(IEnumerable<UserRole> entities);
}

/// <summary>
/// Provides an implementation of the IUserRoleRepository for managing UserRole entities.
/// </summary>
public class UserRoleRepository() : ProductsRepositoryBase<UserRole>, IUserRoleRepository
{
    /// <summary>
    /// Saves a UserRole entity asynchronously. If the entity exists, it updates it; otherwise, it creates a new one.
    /// </summary>
    /// <param name="entity">The UserRole entity to be saved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    public async Task<bool> SaveAsync(UserRole entity)
    {
        bool exists = await ExistsAsync(entity);
        if (exists)
            return await UpdateAsync(entity);
        return await CreateAsync(entity);
    }

    /// <summary>
    /// Retrieves a collection of UserRole entities asynchronously based on their IDs.
    /// </summary>
    /// <param name="ids">A collection of UserRole IDs.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of UserRole entities.</returns>
    public async Task<IEnumerable<UserRole>> GetAsync(IEnumerable<int> ids)
    {
        if (ids != null && ids.Count() == 1)
            return [await FindAsync(ids.FirstOrDefault())];

        Func<UserRole, bool> predicate = ids == null
            ? x => x.Id > 0
            : x => ids.Contains((int)x.Id);

        var categories = await ReadAsync();
        return categories.Where(predicate);
    }
}
