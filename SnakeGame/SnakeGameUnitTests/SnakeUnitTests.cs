using SnakeGame.Constants;
using SnakeGame.Interfaces;
using SnakeGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameUnitTests
{
    internal class SnakeUnitTests
    {
        private ISnake _mockSnake;

        [SetUp]
        public void SetUp()
        {
            _mockSnake = Factory.CreateSnake(5);
        }

        [TestCase(Directions.RightArrow, 1, 5)]
        [TestCase(Directions.UpArrow, 0, 4 )]
        [TestCase(Directions.DownArrow, 2, 4)]
        public void Move_DiresctionIsEntered_SnakeHeadChangePostition(Directions direction, int x, int y)
        {
            _mockSnake.Move(direction);
            IPoint newPosition = Factory.CreatePoint(x, y);

            Assert.That(_mockSnake.Head.EqualsPosition(newPosition), Is.True);
        }
    }
}
