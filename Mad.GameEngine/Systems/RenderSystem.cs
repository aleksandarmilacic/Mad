using Mad.GameEngine.Components;
using Mad.GameEngine.ECS;
using OpenTK.Graphics.OpenGL;

namespace Mad.GameEngine.Systems
{
    public class RenderSystem : ISystem
    {
        private readonly List<Entity> _entities;

        public RenderSystem(List<Entity> entities)
        {
            _entities = entities;
            // Initialize OpenTK Window and other resources here
        }

        public void Update(float deltaTime)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            foreach (var entity in _entities)
            {
                var renderComponent = entity.GetComponent<RenderComponent>();
                if (renderComponent != null)
                {
                    // Your OpenGL drawing code here. For example:
                    GL.Begin(PrimitiveType.Quads);

                    GL.Vertex2(renderComponent.Position.X, renderComponent.Position.Y);
                    GL.Vertex2(renderComponent.Position.X + 1, renderComponent.Position.Y);
                    GL.Vertex2(renderComponent.Position.X + 1, renderComponent.Position.Y + 1);
                    GL.Vertex2(renderComponent.Position.X, renderComponent.Position.Y + 1);

                    GL.End();
                }
            }
            // Don't forget to swap buffers if you're using double buffering.
        }
    }
}
