using System;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DDZD
{
    public class MyGame : StartUpDx
    {
        public static Effect Shader;
        public static Texture2D Pixel;
        public static MyGame Instance;
        public static Vector3 Offset;

        public MyGame()
        {
            Instance = this;
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
            Content.RootDirectory = "Content";
        }

        protected override void LoadContent()
        {
            Shader = Content.Load<Effect>("VertexPC");
            Pixel = Content.Load<Texture2D>("p_w");
        }

        protected override void Update(GameTime gameTime)
        {
            if (!IsActive) return;

            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            var totalTime = (float)gameTime.TotalGameTime.TotalSeconds;

            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                Offset.X += 64 * deltaTime;
            }

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                Offset.Y -= 64 * deltaTime;
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                Offset.X -= 64 * deltaTime;
            }

            if (keyboardState.IsKeyDown(Keys.Down))
            {
                Offset.Y += 64 * deltaTime;
            }

            Window.Title = $"{Offset}";
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            var (w, h) = GraphicsDevice.Viewport.Bounds.Size;
            var (hw, hh) = GraphicsDevice.Viewport.Bounds.Size.ToVector2() / 2;

            SpriteBatch.Begin(transformMatrix: Matrix.CreateTranslation(-Offset));

            SpriteBatch.Draw(Pixel, new Rectangle(0, 0, 10, 10), Color.White);

            SpriteBatch.End();
            
            var world = Matrix.Identity;
            var viewPosition = Offset + new Vector3(hw, hh, 0);
            var view = Matrix.CreateLookAt(viewPosition + Vector3.Backward, viewPosition + Vector3.Forward, Vector3.Up);
            var projection = Matrix.CreateOrthographic(w / 1, -h / 1, 0.1f, 10f);

           
           PrimitiveRenderer.DrawCircleH(
               GraphicsDevice,
               Shader,
               world, view, projection,
               Color.Aqua,
               Mouse.GetState().Position.ToVector2(),
               100f, 2f
           );
           
        }

        
    }
}