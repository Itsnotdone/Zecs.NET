namespace Zecs{
    public class Entity{
        private List<Component> components;

        public Entity(params Component[] component_array)
        {
            components=component_array.ToList<Component>();
        }

        public void RemoveComponent<T>() where T: Component{
            foreach (Component component in components)
            {
                if (component.GetType().Equals(typeof(T)))
                {
                    components.Remove(component);
                }
            }
        }

        public void AddComponent(Component component)
        {
            components.Add(component);
            component.entity = this;
        }


        public T GetComponent<T>() where T : Component
        {
            foreach (Component component in components)
            {
                if (component.GetType().Equals(typeof(T)))
                {
                    return (T)component;
                }
            }
            return null;
        }

        public bool HasComponent<T>()
        {
            foreach (Component component in components)
            {
                if (component.GetType().Equals(typeof(T)))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasComponent(Type type)
        {
            foreach (Component component in components)
            {
                if (component.GetType().Equals(type))
                {
                    return true;
                }
            }
            return false;
        }

        public T GetComponents<T>(){
            var types = typeof(T).GenericTypeArguments;

            var result = new Component[types.Length];

            for (int i = 0; i < types.Length; i++) {
                var type = types[i];

                if (type.IsInstanceOfType(components[i])) {
                    result[i] = components[i];
                }     
            }

            return (T)Activator.CreateInstance(typeof(T), result);
        }

        public void AddComponents(params Component[] component_list)
        {
            foreach(var component in component_list){
                components.Add(component);
                component.entity = this;
            } 
        }

        public bool HasComponents<T>(){
            var types = typeof(T).GenericTypeArguments;

            for (int i = 0; i < types.Length; i++) {
                var type = types[i];

                if (!type.IsInstanceOfType(components[i])) {
                    return false;
                }
            }

            return true;
        }

    }
}