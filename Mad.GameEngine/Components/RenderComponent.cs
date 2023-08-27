﻿using Mad.GameEngine.ECS;
using Mad.GameEngine.Math;

namespace Mad.GameEngine.Components
{
    public class RenderComponent : IComponent
    {
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        // Add texture, color, etc. as needed
    }
}