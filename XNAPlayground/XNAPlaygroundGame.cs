using System;
using Microsoft.Xna.Framework;

namespace XNAPlayground
{
    public class XNAPlaygroundGame : Game
    {
        public static void Main(string[] args)
        {
            var game = new XNAPlaygroundGame();
            game.Run();
        }
        private XNAPlaygroundGame()
        {
            var gdm = new GraphicsDeviceManager(this);
        }
    }
}
