using PAW.Business.Factory;
using PAW.Models.Components;
using PAW.Models.Products;
using PAW.Repository.Products;

namespace PAW.Business;

public class ComponentManager
{
    private readonly ComponentFactory _componentFactory;
    private readonly IComponentRepository _componentRepository;

    public ComponentManager(IComponentRepository componentRepository)
    {
        _componentFactory = new ComponentFactory();
        _componentRepository = componentRepository;
    }

    public async Task<IEnumerable<Component>> GetComponentsAsync()
    {
        var components = await _componentRepository.GetAsync(null);

        Component determineComponent(Component c) {
            return c.Name.ToLower() switch
            {
                "image" => _componentFactory.CreateComponent<ComponentImage>(),
                "media" => _componentFactory.CreateComponent<ComponentMedia>(),
                _ => _componentFactory.CreateComponent<ComponentChart>(),
            };
        }

        components.Select(determineComponent)
            .ToList()
            .ForEach(c => {
                _componentFactory.SetProperty(c, "", null)
                    .SetProperty2()
                    .SetProperty3();
                });
    
       return components;
    }
}
