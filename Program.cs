using System;

namespace Millionaires
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Prepare();
            game.Start();
        }
    }
}
