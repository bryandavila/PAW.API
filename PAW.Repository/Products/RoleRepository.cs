using PAW.Models.Products;
using PAW.Repository.Products;

namespace PAW.Repository.Roles;

/// <summary>
/// Defines the contract for a repository that manages Role entities.
/// </summary>
public interface IRoleRepository
{
    /// <summary>
    /// Retrieves a collection of Role entities asynchronously based on their IDs.
    /// </summary>
    /// <param name="ids">A collection of Role IDs.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of Role entities.</returns>
    Task<IEnumerable<Role>> GetAsync(IEnumerable<int> ids);

    /// <summary>
    /// Saves a Role entity asynchronously.
    /// </summary>
    /// <param name="entity">The Role entity to be saved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> SaveAsync(Role entity);

    /// <summary>
    /// Deletes an existing Role entity asynchronously.
    /// </summary>
    /// <param name="entity">The Role entity to be deleted.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> DeleteAsync(Role entity);

    /// <summary>
    /// Updates multiple Role entities asynchronously.
    /// </summary>
    /// <param name="entities">The collection of Role entities to be updated.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> UpdateManyAsync(IEnumerable<Role> entities);
}

/// <summary>
/// Provides an implementation of the IRoleRepository for managing Role entities.
/// </summary>
public class RoleRepository() : ProductsRepositoryBase<Role>, IRoleRepository
{
    /// <summary>
    /// Saves a Role entity asynchronously. If the entity exists, it updates it; otherwise, it creates a new one.
    /// </summary>
    /// <param name="entity">The Role entity to be saved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    public async Task<bool> SaveAsync(Role entity)
    {
        bool exists = await ExistsAsync(entity);
        if (exists)
            return await UpdateAsync(entity);
        return await CreateAsync(entity);
    }

    /// <summary>
    /// Retrieves a collection of Role entities asynchronously based on their IDs.
    /// </summary>
    /// <param name="ids">A collection of Role IDs.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of Role entities.</returns>
    public async Task<IEnumerable<Role>> GetAsync(IEnumerable<int> ids)
    {
        if (ids != null && ids.Count() == 1)
            return [await FindAsync(ids.FirstOrDefault())];

        Func<Role, bool> predicate = ids == null
            ? x => x.RoleId > 0
            : x => ids.Contains((int)x.RoleId);

        var categories = await ReadAsync();
        return categories.Where(predicate);
    }
}

