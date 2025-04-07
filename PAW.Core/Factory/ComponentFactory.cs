using ComponentModel = PAW.Models.Components.Component;

public class ComponentFactory
{
    public ComponentModel CreateComponent<T>() where T : ComponentModel, new()
    {
        return new T();
    }

    public ComponentFactory SetProperty(ComponentModel component, string url, IEnumerable<ComponentModel> items)
    {
        component.Url = url;
        component.Data = items;
        return this;
    }

    public ComponentFactory SetProperty2()
    {
        return this;
    }

    public ComponentFactory SetProperty3()
    {
        return this;
    }
}
