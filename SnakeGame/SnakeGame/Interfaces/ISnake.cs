using SnakeGame.Constants;
using SnakeGame.Interfaces;

namespace SnakeGame.Classes
{
    public interface ISnake
    {
        List<IPoint> Body { get; }
        (int, int) CurrentPosition { get; }
        IPoint Head { get; }

        void AddPart();
        void Move(Directions direction, bool hasWalls);
        void Render();
        void UpdateBodyPosition();
    }
}