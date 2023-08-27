using System.Collections.Generic;
using Mad.GameEngine.Components;
using Mad.GameEngine.ECS;
using Mad.GameEngine.Systems;

namespace Mad.UI
{
    public class GameLoop
    {
        private InputManager _inputManager;
        public bool IsRunning;

        public GameLoop()
        {
            _inputManager = new InputManager();
            IsRunning = true;
        }

        public void Run()
        {
            var entities = new List<Entity>
            {
                new Entity(1)
            };

            var renderSystem = new RenderSystem(entities);
            var physicsSystem = new PhysicsSystem(entities);

            var playerEntity = entities[0];
            playerEntity.AddComponent(new RenderComponent());
            playerEntity.AddComponent(new PhysicsComponent());

            while (IsRunning)
            {
                float deltaTime = 1.0f / 60.0f;  // You can replace this with actual time elapsed later.

                _inputManager.ProcessInput(playerEntity); // Could be made more dynamic to support more entities later.

                physicsSystem.Update(deltaTime);
                renderSystem.Update(deltaTime);

                // Insert any code here to break the loop, perhaps by setting _isRunning = false based on some condition.
            }
        }
    }
}
