using Mad.GameEngine.Components;
using Mad.GameEngine.ECS;

namespace Mad.GameEngine.Systems
{
    public class RenderSystem : ISystem
    {
        private readonly List<Entity> _entities;

        public RenderSystem(List<Entity> entities)
        {
            _entities = entities;
        }

        public void Update(float deltaTime)
        {
            foreach (var entity in _entities)
            {
                var renderComponent = entity.GetComponent<RenderComponent>();
                if (renderComponent != null)
                {
                    // Do the rendering here, e.g., draw the sprite at renderComponent.Position
                }
            }
        }
    }
}
