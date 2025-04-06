using Microsoft.Extensions.Options;
using PAW.Business.Factory;
using PAW.Models;
using PAW.Models.CustomModels;
using PAW.Repositories;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        var components = await _componentRepository.GetAllComponentsAsync();

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
