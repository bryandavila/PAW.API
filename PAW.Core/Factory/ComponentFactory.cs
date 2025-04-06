using PAW.Models.Products;

namespace PAW.Business.Factory
{
    public class ComponentFactory
    {
        public Component CreateComponent<T>() where T : Component, new()
        {
            return new T();
        }

        public ComponentFactory SetProperty(Component component, string url, IEnumerable<Component> items)
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
}
