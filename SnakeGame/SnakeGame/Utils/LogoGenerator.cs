using SnakeGame.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Utils
{
    internal class LogoGenerator
    {
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
                    if (digit == "-")
                    {
                        scoreLogo[i] += " " + Logos.ScoreLogos["-"][i];
                    }
                    else
                    {
                        scoreLogo[i] += " " + Logos.ScoreLogos[digit][i];
                    }
                }
            }

            return string.Join("\r\n", scoreLogo);
        }
    }
}
