using System.Collections.Generic;
using Mad.GameEngine.Components;
using Mad.GameEngine.ECS;
using Mad.GameEngine.Systems;

namespace Mad.UI
{
    public class GameLoop
    {
        private InputManager _inputManager;
        private GameEventSystem _gameEventSystem;
        private CommandBar _commandBar;
        private bool _isRunning;
        private List<Entity> _entities; // moved to class field

        // Add these
        private PhysicsSystem _physicsSystem;
        private RenderSystem _renderSystem;

        public GameLoop()
        {
            _inputManager = new InputManager();
            _isRunning = true;
            _entities = InitializeEntities();  // Initialize entities before using them
            _gameEventSystem = new GameEventSystem(_entities);
            _commandBar = new CommandBar();

            // Initialize these
            _physicsSystem = new PhysicsSystem(_entities);
            _renderSystem = new RenderSystem(_entities);
        }

        private List<Entity> InitializeEntities()
        {
            var unitEntity = new Entity(2);
            unitEntity.AddComponent(new HealthComponent { Health = 100 });
            unitEntity.AddComponent(new AttackComponent { AttackPower = 10 });

            return new List<Entity> { unitEntity };
        }

        public void Update(float deltaTime)
        {
            _inputManager.ProcessInput(_entities[0]);  // We'll assume this is the player entity for now
            _gameEventSystem.Update(deltaTime);

            // Use these
            _physicsSystem.Update(deltaTime);
            _renderSystem.Update(deltaTime);
        }
    }

}
