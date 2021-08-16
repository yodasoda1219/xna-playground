using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNAPlayground.Engine
{
    public abstract class Entity
    {
        public Entity(Vector2? position = null)
        {
            mSprite = LoadSprite();
            mPosition = position ?? Vector2.Zero;
        }
        ~Entity()
        {
            mSprite.Dispose();
        }
        protected virtual Texture2D LoadSprite()
        {
            var assetManager = XNAPlaygroundGame.AssetManager;
            return assetManager.Load<Texture2D>(GetType());
        }
        public abstract void Update(GameTime gameTime);
        public virtual void Render(SpriteBatch batch, GameTime gameTime)
        {
            batch.Draw(mSprite, mPosition, Color.White);
        }
        public int SceneIndex
        {
            get
            {
                Scene scene = XNAPlaygroundGame.Scene;
                for (int i = 0; i < scene.Count; i++)
                {
                    if (scene[i] == this)
                    {
                        return i;
                    }
                }
                throw new InvalidOperationException();
            }
        }
        private Texture2D mSprite;
        protected Vector2 mPosition;
        public Texture2D Sprite => mSprite;
        public Vector2 Position => mPosition;
    }
}