﻿using Mad.GameEngine.Components;
using System.Drawing;

namespace Mad.GameEngine
{
    public class ColliderComponent : IComponent
    {
        public Rectangle BoundingBox { get; set; }
    }

}
  