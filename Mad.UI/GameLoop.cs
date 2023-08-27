using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using Mad.GameEngine.Components;
using Mad.GameEngine.ECS;
using Mad.GameEngine.Systems;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace Mad.UI
{
    public class GameLoop
    {
        private InputManager _inputManager;
        private GameEventSystem _gameEventSystem;
        private CommandBar _commandBar;
        private bool _isRunning;
        private List<Entity> _entities; // moved to class field

        // Add these
        private PhysicsSystem _physicsSystem;
        private RenderSystem _renderSystem;

        public GameLoop()
        {
            _inputManager = new InputManager();
            _isRunning = true;
            _entities = InitializeEntities();  // Initialize entities before using them
            _gameEventSystem = new GameEventSystem(_entities);
            _commandBar = new CommandBar();

            // Initialize these
            _physicsSystem = new PhysicsSystem(_entities);
            _renderSystem = new RenderSystem(_entities);
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
        private List<Entity> InitializeEntities()
        {
            var unitEntity = new Entity(2);
            var renderComp = new RenderComponent
            {
                Position = new Vector2(0, 0),
                Size = new Vector2(32, 32),
                TextureID = LoadTexture("Textures\\Slice 84.png")  // Replace with your actual texture loading code
            };
          
            unitEntity.AddComponent(renderComp);
            unitEntity.AddComponent(new HealthComponent { Health = 100 });
            unitEntity.AddComponent(new AttackComponent { AttackPower = 10 });

            return new List<Entity> { unitEntity };
        }

        public void Update(float deltaTime)
        {
            _inputManager.ProcessInput(_entities[0]);  // We'll assume this is the player entity for now
            _gameEventSystem.Update(deltaTime);

            // Use these
            _physicsSystem.Update(deltaTime);
            _renderSystem.Update(deltaTime);
        }
    }

}
