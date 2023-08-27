using Mad.GameEngine.Systems;

namespace Mad.GameEngine.ECS
{
    public class GameLogicSystem : ISystem
    {
        private readonly List<Entity> _entities;

        public GameLogicSystem(List<Entity> entities)
        {
            _entities = entities;
        }

        public void Update(float deltaTime)
        {
            // Insert your game logic here, like handling combat, resources, etc.
        }
    }
}
