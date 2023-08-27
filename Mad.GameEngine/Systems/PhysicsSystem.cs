using Mad.GameEngine.Components;
using Mad.GameEngine.ECS;

namespace Mad.GameEngine.Systems
{
    public class PhysicsSystem : ISystem
    {
        private readonly List<Entity> _entities;

        public PhysicsSystem(List<Entity> entities)
        {
            _entities = entities;
        }

        public void Update(float deltaTime)
        {
            foreach (var entity in _entities)
            {
                var physicsComponent = entity.GetComponent<PhysicsComponent>();
                var renderComponent = entity.GetComponent<RenderComponent>();

                if (physicsComponent != null && renderComponent != null)
                {
                    physicsComponent.Velocity += physicsComponent.Acceleration * deltaTime;
                    renderComponent.Position += physicsComponent.Velocity * deltaTime;
                }
            }
        }
    }
}
