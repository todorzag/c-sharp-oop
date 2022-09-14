using SnakeGame;

namespace SnakeGameUnitTests
{
    internal class SnakeUnitTests
    {
        private Snake _mockSnake;

        [SetUp]
        public void Setup()
        {
            _mockSnake = new Snake();
        }

        [Test]
        public void CheckifOutOfBounds_NotOutOfBounds_ReturnFalse()
        {
            _mockSnake.Turn("RightArrow");
            _mockSnake.Turn("DownArrow");
            _mockSnake.Turn("RightArrow");

            Assert.IsFalse(_mockSnake.CheckIfOutOfBounds(10, 10));
        }

        [Test]
        public void CheckifOutOfBounds_IsOutOfBoundsUnder0_ReturnTrue()
        {
            _mockSnake.Turn("UpArrow");
            _mockSnake.Turn("UpArrow");

            Assert.IsTrue(_mockSnake.CheckIfOutOfBounds(10, 10));
        }

        [Test]
        public void CheckifOutOfBounds_IsOutOfBoundsOverHeight_ReturnTrue()
        {
            _mockSnake.Turn("DownArrow");
            _mockSnake.Turn("DownArrow");
            _mockSnake.Turn("DownArrow");
            _mockSnake.Turn("DownArrow");
            _mockSnake.Turn("DownArrow");
            _mockSnake.Turn("DownArrow");
            _mockSnake.Turn("DownArrow");

            Assert.IsTrue(_mockSnake.CheckIfOutOfBounds(7, 7));
        }

        [Test]
        public void CheckIfHitItself_NotHit_ReturnFalse()
        {
            _mockSnake.Turn("RightArrow");
            _mockSnake.Turn("DownArrow");
            _mockSnake.Turn("RightArrow");

            Assert.IsFalse(_mockSnake.CheckIfHitItself());
        }

        [Test]
        public void CheckIfHitItself_HitItself_ReturnFalse()
        {
            _mockSnake.Turn("RightArrow");
            _mockSnake.Turn("LeftArrow");

            Assert.IsTrue(_mockSnake.CheckIfHitItself());
        }

        [TestCase("RightArrow", 1, 5)]
        [TestCase("LeftArrow", 1, 3)]
        [TestCase("UpArrow", 0, 4)]
        [TestCase("DownArrow", 2, 4)]
        public void Turn_AllDirections_SnakeTurns(string direction, int x, int y)
        {
            (int, int) position = (x, y);

            _mockSnake.Turn(direction);

            Assert.That(_mockSnake.CurrentPosition, Is.EqualTo(position));
        }

        [Test]
        public void Teleport_UpperBorder_TeleportsToBottomBorder()
        {
            _mockSnake.Turn("UpArrow");
            _mockSnake.Turn("UpArrow");

            _mockSnake.Teleport(5, 5);

            Assert.That(_mockSnake.CurrentPosition, Is.EqualTo((4, 4)));
        }

        [Test]
        public void Teleport_BottomBorder_TeleportsToUpperBorder()
        {
            _mockSnake.Turn("DownArrow");
            _mockSnake.Turn("DownArrow");
            _mockSnake.Turn("DownArrow");
            _mockSnake.Turn("DownArrow");
            _mockSnake.Turn("DownArrow");

            _mockSnake.Teleport(5, 5);

            Assert.That(_mockSnake.CurrentPosition, Is.EqualTo((0, 4)));
        }

        [Test]
        public void Teleport_LeftBorder_TeleportsToRightBorder()
        {
            _mockSnake.Turn("DownArrow");
            _mockSnake.Turn("LeftArrow");
            _mockSnake.Turn("LeftArrow");
            _mockSnake.Turn("LeftArrow");
            _mockSnake.Turn("LeftArrow");
            _mockSnake.Turn("LeftArrow");

            _mockSnake.Teleport(5, 5);

            Assert.That(_mockSnake.CurrentPosition, Is.EqualTo((2, 4)));
        }

        [Test]
        public void Teleport_RightBorder_TeleportsToLeftBorder()
        {
            _mockSnake.Turn("RightArrow");
            _mockSnake.Turn("RightArrow");

            _mockSnake.Teleport(5, 5);

            Assert.That(_mockSnake.CurrentPosition, Is.EqualTo((1, 0)));
        }

        [Test]
        public void OnApple_SnakeIsNotOnApple_ReturnFalse()
        {
            Assert.IsFalse(_mockSnake.OnApple((4, 2)));
        }

        [Test]
        public void OnApple_SnakeIsOnApple_ReturnTrue()
        {
            _mockSnake.Turn("RightArrow");

            Assert.IsTrue(_mockSnake.OnApple((1, 5)));
        }

        [Test]
        public void EatApple_SnakeIsOnApple_AddNewSnakePart()
        {
            _mockSnake.AddSnakePart();

            Assert.That(_mockSnake.SnakePartsCount, Is.EqualTo(4));
        }

        [Test]
        public void CheckSpawnOnSnake_NotSpawnedOnSnake_ReturnFalse()
        {
            Assert.IsFalse(_mockSnake.CheckSpawnOnSnake((4,2)));
        }

        [Test]
        public void CheckSpawnOnSnake_SpawnedOnSnake_ReturnTrue()
        {
            _mockSnake.Turn("RightArrow");

            Assert.IsTrue(_mockSnake.CheckSpawnOnSnake((1, 4)));
        }
    }
}
