using SnakeGame.Interfaces;

namespace SnakeGame.Classes
{
    public interface ISnake
    {
        List<IPoint> Body { get; }
        (int, int) CurrentPosition { get; }
        IPoint Head { get; }

        void AddPart();
        void MoveX(int value, bool gameHasWalls);
        void MoveY(int value, bool gameHasWalls);
        void Render();
        void UpdateBodyPosition();
    }
}