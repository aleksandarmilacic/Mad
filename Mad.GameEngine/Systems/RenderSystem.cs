using Mad.GameEngine.Components;
using Mad.GameEngine.ECS;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;

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
        private int LoadTexture(string path)
        {
            int id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, id);

            // Load the image
            Bitmap bmp = new Bitmap(path);
            BitmapData data = bmp.LockBits(
                new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            // Create the texture
            GL.TexImage2D(TextureTarget.Texture2D,
                0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra,
                PixelType.UnsignedByte, data.Scan0);

            bmp.UnlockBits(data);

            // Texture settings
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            return id;
        }

        public void Update(float deltaTime)
        {
            GL.ClearColor(Color.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        
            foreach (var entity in _entities)
            {
                var renderComponent = entity.GetComponent<RenderComponent>();
                if (renderComponent != null)
                {
                    var position = renderComponent.Position;

                    // Clear the screen
                    GL.Clear(ClearBufferMask.ColorBufferBit);

                    // Draw your sprite (assuming you have loaded some kind of OpenGL texture into 'textureID')
                    GL.BindTexture(TextureTarget.Texture2D, renderComponent.TextureID);

                    // Code to draw your sprite at the 'position'...
                    // This will be your OpenGL draw calls.

                    // Unbind the texture
                    GL.BindTexture(TextureTarget.Texture2D, 0);
                }
            }
            // Don't forget to swap buffers if you're using double buffering.
        }
    }
}
