using Moq;
using SnakeGame;

namespace SnakeGameUnitTests
{
    public class SnakePartUnitTests
    {
        private SnakePart _snakeHead;

        [SetUp]
        public void Setup()
        {
            _snakeHead = new SnakePart(1,1,"●");
        }

        [Test]
        public void TurnRight_RightArrowPressed_TurnsRight()
        {
            _snakeHead.TurnRight();

            Assert.That(_snakeHead.Y, Is.EqualTo(2));
        }

        [Test]
        public void TurnLeft_LeftArrowPressed_TurnsLeft()
        {
            _snakeHead.TurnLeft();

            Assert.That(_snakeHead.Y, Is.EqualTo(0));
        }

        [Test]
        public void TurnDown_DownArrowPressed_TurnsDown()
        {
            _snakeHead.TurnDown();

            Assert.That(_snakeHead.X, Is.EqualTo(2));
        }

        [Test]
        public void TurnUp_UpArrowPressed_TurnsUp()
        {
            _snakeHead.TurnUp();

            Assert.That(_snakeHead.X, Is.EqualTo(0));
        }

        [Test]
        public void ChangePosition_EverythingIsValid_XAndYAreSet()
        {
            _snakeHead.ChangePosition(3,6);

            Assert.That(_snakeHead.X, Is.EqualTo(3));
            Assert.That(_snakeHead.Y, Is.EqualTo(6));
        }
    }
}