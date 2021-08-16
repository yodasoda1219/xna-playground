using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNAPlayground.Engine;
using XNAPlayground.GameContent;

namespace XNAPlayground
{
    public class XNAPlaygroundGame : Game
    {
        public static AssetManager AssetManager => mInstance.mAssetManager;
        public static InputManager InputManager => mInstance.mInputManager;
        public static Scene Scene => mInstance.mScene;
        static XNAPlaygroundGame()
        {
            mInstance = new XNAPlaygroundGame();
        }
        public static void Main(string[] args)
        {
            mInstance.Run();
        }
        private XNAPlaygroundGame()
        {
            var gdm = new GraphicsDeviceManager(this);
            gdm.PreferredBackBufferWidth = 800;
            gdm.PreferredBackBufferHeight = 600;
            gdm.IsFullScreen = false;
            gdm.SynchronizeWithVerticalRetrace = true;
            mAssetManager = new AssetManager(this, "Content");
            mInputManager = new InputManager();
            mScene = new Scene();
        }
        protected override void LoadContent()
        {
            mBatch = new SpriteBatch(GraphicsDevice);
            mScene.Add(new Player());
        }
        protected override void UnloadContent()
        {
            mBatch?.Dispose();
        }
        protected override void Update(GameTime gameTime)
        {
            mInputManager.Update();
            foreach (Entity entity in mScene)
            {
                entity.Update(gameTime);
            }
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(54, 85, 143));
            if (mBatch != null)
            {
                mBatch.Begin();
                foreach (Entity entity in mScene)
                {
                    entity.Render(mBatch, gameTime);
                }
                mBatch.End();
            }
            base.Draw(gameTime);
        }
        private static XNAPlaygroundGame mInstance;
        private AssetManager mAssetManager;
        private InputManager mInputManager;
        private Scene mScene;
        private SpriteBatch? mBatch;
    }
}
