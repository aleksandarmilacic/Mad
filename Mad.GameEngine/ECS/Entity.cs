
using Mad.GameEngine.Components;

namespace Mad.GameEngine.ECS
{
    public class Entity
    {
        public int Id { get; set; }
        private Dictionary<System.Type, IComponent> _components;

        public Entity(int id)
        {
            Id = id;
            _components = new Dictionary<System.Type, IComponent>();
        }

        public T GetComponent<T>() where T : IComponent
        {
            if (_components.TryGetValue(typeof(T), out var component))
            {
                return (T)component;
            }
            return default;
        }

        public void AddComponent<T>(T component) where T : IComponent
        {
            _components[typeof(T)] = component;
        }
    }
}
