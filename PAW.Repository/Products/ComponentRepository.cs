using PAW.Data.MSSQL.ProductDB;
using PAW.Models.Components;
using System.Linq;
using Task = System.Threading.Tasks.Task;

namespace PAW.Repository.Products;

/// <summary>
/// Defines the contract for a repository that manages Component entities.
/// </summary>
public interface IComponentRepository
{
    Task<IEnumerable<Component>> GetAsync(IEnumerable<int> ids);
    Task<bool> SaveAsync(Component entity);
    Task<bool> DeleteAsync(Component entity);
    Task<bool> UpdateManyAsync(IEnumerable<Component> entities);
    Task<IEnumerable<Component>> GetAllComponentsAsync();
}

/// <summary>
/// Provides an implementation of the IComponentRepository for managing Component entities.
/// </summary>
public class ComponentRepository() : ProductsRepositoryBase<Component>, IComponentRepository
{
    public async Task<bool> SaveAsync(Component entity)
    {
        bool exists = await ExistsAsync(entity);
        if (exists)
            return await UpdateAsync(entity);
        return await CreateAsync(entity);
    }

    public async Task<IEnumerable<Component>> GetAsync(IEnumerable<int> ids)
    {
        if (ids != null && ids.Count() == 1)
            return [await FindAsync(ids.FirstOrDefault())];

        Func<Component, bool> predicate = ids == null
            ? x => x.Id > 0
            : x => ids.Contains((int)x.Id);

        var components = await ReadAsync();
        return components.Where(predicate);
    }

    public async Task<IEnumerable<Component>> GetAllComponentsAsync()
    {
        return await Task.FromResult(new List<Component>
        {
            new ComponentImage { Name = "image", Url = "url1", Data = null },
            new ComponentMedia { Name = "media", Url = "url2", Data = null },
            new ComponentChart { Name = "chart", Url = "url3", Data = null }
        });
    }
}
