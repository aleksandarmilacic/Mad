using Mad.GameEngine.ECS;
using System.Drawing;

namespace Mad.GameEngine
{
    public class ColliderComponent : IComponent
    {
        public Rectangle BoundingBox { get; set; }
    }

}
  