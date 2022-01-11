using System;

namespace DDZD
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            using var game = new MyGame();
            game.Run();
        }
    }
}