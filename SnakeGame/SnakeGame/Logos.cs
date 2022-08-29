using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Logos
    {
        private static Dictionary<string, string[]> _scoreLogos 
            = new Dictionary< string, string[]>
            {
                {"0", new string[] {
                    "█▀▀█",
                    "█▄▀█",
                    "█▄▄█" }
                },
                {"1", new string[] {
                    "▄█ ",
                    " █ ",
                    "▄█▄" }
                },
                 {"2", new string[] {
                    "█▀█",
                    " ▄▀",
                    "█▄▄"}
                },
                {"3", new string[] {
                    "█▀▀█",
                    "  ▀▄",
                    "█▄▄█" }
                },
                {"4", new string[] {
                    " █▀█ ",
                    "█▄▄█▄",
                    "   █ "}
                },
                {"5", new string[] {
                    "█▀▀",
                    "▀▀▄",
                    "▄▄▀"}
                },
                {"6", new string[] {
                    "▄▀▀▄",
                    "█▄▄ ",
                    "▀▄▄▀"}
                },
                {"7", new string[] {
                    "▀▀▀█",
                    "  █ ",
                    " ▐▌ "}
                },
                {"8", new string[] {
                    "▄▀▀▄",
                    "▄▀▀▄",
                    "▀▄▄▀" }
            },
                {"9", new string[] {
                    "▄▀▀▄",
                    "▀▄▄█",
                    " ▄▄▀"} 
                },
            };

        public static string GameStartLogo
        {
            get => 
            ("\r\n░██████╗░░█████╗░███╗░░░███╗███████╗  ░██████╗████████╗░█████╗░██████╗░████████╗" +
             "\r\n██╔════╝░██╔══██╗████╗░████║██╔════╝  ██╔════╝╚══██╔══╝██╔══██╗██╔══██╗╚══██╔══╝" +
             "\r\n██║░░██╗░███████║██╔████╔██║█████╗░░  ╚█████╗░░░░██║░░░███████║██████╔╝░░░██║░░░" +
             "\r\n██║░░╚██╗██╔══██║██║╚██╔╝██║██╔══╝░░  ░╚═══██╗░░░██║░░░██╔══██║██╔══██╗░░░██║░░░" +
             "\r\n╚██████╔╝██║░░██║██║░╚═╝░██║███████╗  ██████╔╝░░░██║░░░██║░░██║██║░░██║░░░██║░░░" +
             "\r\n░╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝  ╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░╚═╝░░░╚═╝░░░");
        }

        public static string GameEndLogo
        {
            get =>
            ("\r\n░██████╗░░█████╗░███╗░░░███╗███████╗  ███████╗███╗░░██╗██████╗░" +
             "\r\n██╔════╝░██╔══██╗████╗░████║██╔════╝  ██╔════╝████╗░██║██╔══██╗" +
             "\r\n██║░░██╗░███████║██╔████╔██║█████╗░░  █████╗░░██╔██╗██║██║░░██║" +
             "\r\n██║░░╚██╗██╔══██║██║╚██╔╝██║██╔══╝░░  ██╔══╝░░██║╚████║██║░░██║" +
             "\r\n╚██████╔╝██║░░██║██║░╚═╝░██║███████╗  ███████╗██║░╚███║██████╔╝" +
             "\r\n░╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝  ╚══════╝╚═╝░░╚══╝╚═════╝░");
        }

        public static string ScoreWordLogo
        {
            get =>
            ("\r\n█▀▀▀█ █▀▀ █▀▀█ █▀▀█ █▀▀ ▄ " +
             "\r\n▀▀▀▄▄ █   █  █ █▄▄▀ █▀▀   " +
             "\r\n█▄▄▄█ ▀▀▀ ▀▀▀▀ ▀ ▀▀ ▀▀▀ ▀");
        }

        public static string GenerateScoreLogo(int scoreInt)
        {
            string[] scoreLogo = new string[3];

            string[] scoreString = scoreInt
                .ToString()
                .Select(d => d.ToString())
                .ToArray();

            foreach (string digit in scoreString)
            {
                for (int i = 0; i < scoreLogo.Length; i++)
                {
                    scoreLogo[i] += " " + _scoreLogos[digit][i];
                }
            }

            return String.Join("\r\n", scoreLogo);
        }
    }
}
