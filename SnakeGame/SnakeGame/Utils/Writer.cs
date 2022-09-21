using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Utils
{
    internal class Writer
    {
        public static void WriteAt(int y, int x, string str)
        {
            Console.SetCursorPosition(y, x);
            Console.Write(str);
        }
    }
}
