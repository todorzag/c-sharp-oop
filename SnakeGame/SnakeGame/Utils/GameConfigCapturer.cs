using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Utils
{
    public class GameConfigCapturer : IGameConfigCapturer
    {
        public void GetDataFromInput()
        {
            try
            {
                IPlayer player = AskPlayer();
                bool hasWalls = AskHasWalls();
                int snakeLength = AskSnakeLength();

                GameConfig.SetConfigData(player, hasWalls, snakeLength);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw;
            }
        }

        private IPlayer AskPlayer()
        {
            StandardMessagesWriter.PlayerFirstName();
            string firstName = Console.ReadLine();

            StandardMessagesWriter.PlayerLastName();
            string lastName = Console.ReadLine();

            return Factory.CreatePlayer(firstName, lastName);
        }

        private bool AskHasWalls()
        {
            StandardMessagesWriter.HasWalls();
            string answer = Console.ReadLine();
            bool hasWalls = false;

            if (answer == "Y")
            {
                hasWalls = true;
            }

            return hasWalls;
        }

        private int AskSnakeLength()
        {
            StandardMessagesWriter.SnakeLength();
            int SnakeLength = int.Parse(Console.ReadLine());

            if (Validator.ValidateInitalSnakeLength(SnakeLength) == false)
            {
                throw new ArgumentOutOfRangeException();
            };

            return SnakeLength;
        }
    }
}
