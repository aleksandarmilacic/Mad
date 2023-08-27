
using OpenTK.Mathematics;

namespace Mad.GameEngine.Components
{
    public class RenderComponent : IComponent
    {
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public int TextureID { get; set; }
    }
}
