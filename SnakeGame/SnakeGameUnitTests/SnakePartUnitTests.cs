using Moq;
using SnakeGame.Classes;

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
        public void ChangePosition_EverythingIsValid_XAndYAreSet()
        {
            _snakeHead.ChangePosition(3,6);

            Assert.That(_snakeHead.X, Is.EqualTo(3));
            Assert.That(_snakeHead.Y, Is.EqualTo(6));
        }
    }
}