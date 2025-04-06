using PAW.Models.Products;
using System.Linq;

namespace PAW.Repository.Products;

/// <summary>
/// Defines the contract for a repository that manages User entities.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Retrieves a collection of User entities asynchronously based on their IDs.
    /// </summary>
    /// <param name="ids">A collection of User IDs.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of User entities.</returns>
    Task<IEnumerable<User>> GetAsync(IEnumerable<int> ids);

    /// <summary>
    /// Saves a User entity asynchronously.
    /// </summary>
    /// <param name="entity">The User entity to be saved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> SaveAsync(User entity);

    /// <summary>
    /// Deletes an existing User entity asynchronously.
    /// </summary>
    /// <param name="entity">The User entity to be deleted.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> DeleteAsync(User entity);

    /// <summary>
    /// Updates multiple User entities asynchronously.
    /// </summary>
    /// <param name="entities">The collection of User entities to be updated.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    Task<bool> UpdateManyAsync(IEnumerable<User> entities);
}

/// <summary>
/// Provides an implementation of the IUserRepository for managing User entities.
/// </summary>
public class UserRepository() : ProductsRepositoryBase<User>, IUserRepository
{
    /// <summary>
    /// Saves a User entity asynchronously. If the entity exists, it updates it; otherwise, it creates a new one.
    /// </summary>
    /// <param name="entity">The User entity to be saved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
    public async Task<bool> SaveAsync(User entity)
    {
        bool exists = await ExistsAsync(entity);
        if (exists)
            return await UpdateAsync(entity);
        return await CreateAsync(entity);
    }

    /// <summary>
    /// Retrieves a collection of User entities asynchronously based on their IDs.
    /// </summary>
    /// <param name="ids">A collection of User IDs.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of User entities.</returns>
    public async Task<IEnumerable<User>> GetAsync(IEnumerable<int> ids)
    {
        if (ids != null && ids.Count() == 1)
            return [await FindAsync(ids.FirstOrDefault())];

        Func<User, bool> predicate = ids == null
            ? x => x.UserId > 0
            : x => ids.Contains((int)x.UserId);

        var categories = await ReadAsync();
        return categories.Where(predicate);
    }
}