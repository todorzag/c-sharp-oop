using SnakeGame;

namespace SnakeGameUnitTests
{
    internal class SnakeUnitTests
    {
        private Snake _snake;

        [SetUp]
        public void Setup()
        {
            _snake = new Snake();
        }

        [Test]
        public void CheckifOutOfBounds_NotOutOfBounds_ReturnFalse()
        {
            _snake.Turn("RightArrow");
            _snake.Turn("DownArrow");
            _snake.Turn("RightArrow");

            Assert.IsFalse(_snake.CheckIfOutOfBounds(10, 10));
        }

        [Test]
        public void CheckifOutOfBounds_IsOutOfBoundsUnder0_ReturnTrue()
        {
            _snake.Turn("UpArrow");
            _snake.Turn("UpArrow");

            Assert.IsTrue(_snake.CheckIfOutOfBounds(10, 10));
        }

        [Test]
        public void CheckifOutOfBounds_IsOutOfBoundsOverHeight_ReturnTrue()
        {
            _snake.Turn("DownArrow");
            _snake.Turn("DownArrow");
            _snake.Turn("DownArrow");
            _snake.Turn("DownArrow");
            _snake.Turn("DownArrow");
            _snake.Turn("DownArrow");
            _snake.Turn("DownArrow");

            Assert.IsTrue(_snake.CheckIfOutOfBounds(7, 7));
        }

        [Test]
        public void CheckIfHitItself_NotHit_ReturnFalse()
        {
            _snake.Turn("RightArrow");
            _snake.Turn("DownArrow");
            _snake.Turn("RightArrow");

            Assert.IsFalse(_snake.CheckIfHitItself());
        }

        [Test]
        public void CheckIfHitItself_HitItself_ReturnFalse()
        {
            _snake.Turn("RightArrow");
            _snake.Turn("LeftArrow");

            Assert.IsTrue(_snake.CheckIfHitItself());
        }

        [Test]
        public void OnApple_SnakeIsNotOnApple_ReturnFalse()
        {
            Assert.IsFalse(_snake.OnApple((4, 2)));
        }

        [Test]
        public void OnApple_SnakeIsOnApple_ReturnTrue()
        {
            _snake.Turn("RightArrow");

            Assert.IsTrue(_snake.OnApple((1, 5)));
        }

        [Test]
        public void EatApple_SnakeIsOnApple_AddNewSnakePart()
        {
            _snake.EatApple();

            Assert.That(_snake.SnakePartsCount, Is.EqualTo(4));
        }

        [Test]
        public void CheckSpawnOnSnake_NotSpawnedOnSnake_ReturnFalse()
        {
            Assert.IsFalse(_snake.CheckSpawnOnSnake((4,2)));
        }

        [Test]
        public void CheckSpawnOnSnake_SpawnedOnSnake_ReturnTrue()
        {
            _snake.Turn("RightArrow");

            Assert.IsTrue(_snake.CheckSpawnOnSnake((1, 4)));
        }
    }
}
