using Mad.GameEngine.Components;

namespace Mad.GameEngine
{
    public class PhysicsEngine
    {
        private List<PhysicsComponent> physicsComponents;

        public PhysicsEngine()
        {
            physicsComponents = new List<PhysicsComponent>();
        }

        public void Register(PhysicsComponent physicsComponent)
        {
            physicsComponents.Add(physicsComponent);
        }

        public void Update(float deltaTime)
        {
            foreach (var component in physicsComponents)
            {
                // Add your physics logic here. 
                // For now, we're just going to update the position based on velocity and acceleration.
                component.Velocity += component.Acceleration * deltaTime;
                component.Position += component.Velocity * deltaTime;
            }
        }
    }

}