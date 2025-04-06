using PAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PAW.Models.Components;


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
