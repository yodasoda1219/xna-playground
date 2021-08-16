using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XNAPlayground
{
    public class XNAPlaygroundGame : Game
    {
        public static AssetManager AssetManager => mInstance.mAssetManager;
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
        }
        protected override void LoadContent()
        {
            mBatch = new SpriteBatch(GraphicsDevice);
            mSprite = Content.Load<Texture2D>("XNAPlayground/Assets/Sprites/PlaceholderSprite.png");
        }
        protected override void UnloadContent()
        {
            mBatch?.Dispose();
            mSprite?.Dispose();
        }
        protected override void Update(GameTime gameTime)
        {
            // todo: take input
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(0f, 1f, 0f));
            mBatch?.Begin();
            mBatch?.Draw(mSprite ?? throw new NullReferenceException(), Vector2.Zero, Color.White);
            mBatch?.End();
            base.Draw(gameTime);
        }
        private static XNAPlaygroundGame mInstance;
        private AssetManager mAssetManager;
        private SpriteBatch? mBatch;
        private Texture2D? mSprite;
    }
}
