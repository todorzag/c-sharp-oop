using SnakeGame.Interfaces;
using SnakeGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Classes
{
    public class GameConfigCapturer : IGameConfig
    {
        public (IPlayer, bool, int) GetDataFromInput()
        {
            try
            {
                IPlayer player = GetPlayer();
                bool hasWalls = GetHasWalls();
                int snakeLength = GetSnakeLength();

                return (player, hasWalls, snakeLength);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw;
            }
        }

        private IPlayer GetPlayer()
        {
            StandardMessages.PlayerFirstName();
            string firstName = Console.ReadLine();

            StandardMessages.PlayerLastName();
            string lastName = Console.ReadLine();

            return Factory.CreatePlayer(firstName, lastName);
        }

        private bool GetHasWalls()
        {
            StandardMessages.HasWalls();
            string answer = Console.ReadLine();
            bool hasWalls = false;

            if (answer == "Y")
            {
                hasWalls = true;
            }

            return hasWalls;
        }

        private int GetSnakeLength()
        {
            StandardMessages.SnakeLength();
            int SnakeLength = int.Parse(Console.ReadLine());

            if(Validator.ValidateSnakeLength(SnakeLength) == false)
            {
                throw new ArgumentOutOfRangeException(
                    "Snake length must be greater than 0 and less than 10!");
            };

            return SnakeLength;
        }
    }
}
