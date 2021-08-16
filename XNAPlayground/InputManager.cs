using Microsoft.Xna.Framework.Input;

namespace XNAPlayground
{
    public class InputManager
    {
        public struct InputState
        {
            public bool Held { get; set; }
            public bool Down { get; set; }
            public bool Released { get; set; }
        }
        internal InputManager()
        {
            mPreviousKeyboardState = mCurrentKeyboardState = new KeyboardState();
            mPreviousMouseState = mCurrentMouseState = new MouseState();
        }
        internal void Update()
        {
            mPreviousKeyboardState = mCurrentKeyboardState;
            mPreviousMouseState = mCurrentMouseState;
            mCurrentKeyboardState = Keyboard.GetState();
            mCurrentMouseState = Mouse.GetState();
        }
        public InputState GetKey(Keys key)
        {
            bool wasHeld = mPreviousKeyboardState.IsKeyDown(key);
            bool isHeld = mCurrentKeyboardState.IsKeyDown(key);
            return new InputState
            {
                Held = isHeld,
                Down = isHeld && !wasHeld,
                Released = !isHeld && wasHeld
            };
        }
        private KeyboardState mPreviousKeyboardState, mCurrentKeyboardState;
        private MouseState mPreviousMouseState, mCurrentMouseState;
    }
}