using Mad.GameEngine.Components;
using Mad.GameEngine;
using Mad.GameEngine.Math;
using System;
namespace Mad.GameEngine.ECS
{


    public class InputManager
    {
        public delegate void InputAction(PhysicsComponent physicsComponent);

        private readonly Dictionary<ConsoleKey, InputAction> keyMappings;

        public InputManager()
        {
            keyMappings = new Dictionary<ConsoleKey, InputAction>
        {
            { ConsoleKey.W, MoveUp },
            { ConsoleKey.S, MoveDown },
            { ConsoleKey.A, MoveLeft },
            { ConsoleKey.D, MoveRight }
        };
        }

        public void ProcessInput(Entity playerEntity, GameLoop isRunning)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true).Key;
                var physicsComponent = playerEntity.GetComponent<PhysicsComponent>();

                if (physicsComponent != null && keyMappings.TryGetValue(key, out var action))
                {
                    action(physicsComponent);
                }

                if (key == ConsoleKey.Escape)
                {
                    isRunning = false;
                    return;
                }
            }
        }

        private void MoveUp(PhysicsComponent physicsComponent)
        {
            physicsComponent.Velocity = new Vector2(physicsComponent.Velocity.X, physicsComponent.Velocity.Y - 1);
        }

        private void MoveDown(PhysicsComponent physicsComponent)
        {
            physicsComponent.Velocity = new Vector2(physicsComponent.Velocity.X, physicsComponent.Velocity.Y + 1);
        }

        private void MoveLeft(PhysicsComponent physicsComponent)
        {
            physicsComponent.Velocity = new Vector2(physicsComponent.Velocity.X - 1, physicsComponent.Velocity.Y);
        }

        private void MoveRight(PhysicsComponent physicsComponent)
        {
            physicsComponent.Velocity = new Vector2(physicsComponent.Velocity.X + 1, physicsComponent.Velocity.Y);
        }

    }
}
