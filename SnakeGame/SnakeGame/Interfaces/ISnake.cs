using SnakeGame.Constants;
using SnakeGame.Interfaces;

namespace SnakeGame.Classes
{
    public interface ISnake
    {
        int MaxLength { get; }
        List<IPoint> Body { get; }
        IPoint Head { get; }

        void AddPart();
        void Move(Directions direction, bool hasWalls);
        void Render();
        void UpdateBodyPosition();
    }
}