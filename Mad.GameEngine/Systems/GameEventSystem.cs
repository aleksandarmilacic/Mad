using Mad.GameEngine.ECS;

namespace Mad.GameEngine.Systems
{
    public class GameEventSystem : ISystem
    {
        private readonly List<Entity> _entities;

        public GameEventSystem(List<Entity> entities)
        {
            _entities = entities;
        }

        public void Update(float deltaTime)
        {
            // Here, you would detect and resolve in-game events like a unit reaching 0 health
        }
    }
}
