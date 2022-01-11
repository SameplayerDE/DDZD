using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DDZD
{
    public abstract class StartUpDx : Game
    {
        public GraphicsDeviceManager GraphicsDeviceManager;
        public SpriteBatch SpriteBatch;

        protected StartUpDx()
        {
            GraphicsDeviceManager = new GraphicsDeviceManager(this);
        
            if (GraphicsDevice == null)
            {
                GraphicsDeviceManager.ApplyChanges();
            }
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }
    }
}