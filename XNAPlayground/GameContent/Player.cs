using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using XNAPlayground.Engine;

namespace XNAPlayground.GameContent
{
    public class Player : Entity
    {
        public Player() : base(new Vector2(100f)) { }
        public override void Update(GameTime gameTime)
        {
            InputManager inputManager = XNAPlaygroundGame.InputManager;
            const float speed = 1f;
            if (inputManager.GetKey(Keys.W).Held)
            {
                mPosition.Y -= speed;
            }
            if (inputManager.GetKey(Keys.S).Held)
            {
                mPosition.Y += speed;
            }
            if (inputManager.GetKey(Keys.A).Held)
            {
                mPosition.X -= speed;
            }
            if (inputManager.GetKey(Keys.D).Held)
            {
                mPosition.X += speed;
            }
        }
    }
}