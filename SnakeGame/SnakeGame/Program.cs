using System.Xml.Linq;
using System.Timers;

namespace SnakeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            var game = Game.GetInstance();

            game.Start();
        }
    }
}