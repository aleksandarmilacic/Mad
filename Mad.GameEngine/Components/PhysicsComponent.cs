﻿
using OpenTK.Mathematics;

namespace Mad.GameEngine.Components
{
    public class PhysicsComponent : IComponent
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
    }

}
