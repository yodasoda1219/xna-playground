using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XNAPlayground
{
    public class XNAPlaygroundGame : Game
    {
        public static void Main(string[] args)
        {
            using var game = new XNAPlaygroundGame();
            game.Run();
        }
        private XNAPlaygroundGame()
        {
            var gdm = new GraphicsDeviceManager(this);
            gdm.PreferredBackBufferWidth = 800;
            gdm.PreferredBackBufferHeight = 600;
            gdm.IsFullScreen = false;
            gdm.SynchronizeWithVerticalRetrace = true;
            string assetDirectory = "Content";
            ExtractResources(assetDirectory);
            Content.RootDirectory = assetDirectory;
        }
        private void ExtractResources(string assetDirectory)
        {
            var assembly = GetType().Assembly;
            var names = assembly.GetManifestResourceNames();
            foreach (string name in names)
            {
                var sections = name.Split('.');
                if (sections.Length < 3)
                {
                    continue;
                }
                string assetPath = assetDirectory;
                for (int i = 2; i < sections.Length; i++)
                {
                    if (i != sections.Length - 1)
                    {
                        assetPath = Path.Join(assetPath, sections[i]);
                    }
                    else
                    {
                        assetPath += "." + sections[i];
                    }
                }
                Directory.CreateDirectory(Path.GetDirectoryName(assetPath) ?? ".");
                var fileStream = new FileStream(Path.Join(".", assetPath), FileMode.Create);
                Stream? resourceStream = assembly.GetManifestResourceStream(name);
                if (resourceStream == null)
                {
                    throw new NullReferenceException();
                }
                var buffer = new byte[resourceStream.Length];
                resourceStream.Read(buffer);
                fileStream.Write(buffer);
                resourceStream.Close();
                fileStream.Close();
            }
        }
        protected override void LoadContent()
        {
            mBatch = new SpriteBatch(GraphicsDevice);
            mSprite = Content.Load<Texture2D>("Sprites/PlaceholderSprite.png");
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
        private SpriteBatch? mBatch;
        private Texture2D? mSprite;
    }
}
