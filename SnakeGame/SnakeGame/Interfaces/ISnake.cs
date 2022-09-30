using SnakeGame.Constants;

namespace SnakeGame.Interfaces
{
    public interface ISnake
    {
        int MaxLength { get; }
        List<IPoint> Body { get; }
        IPoint Head { get; }

        void AddPart();
        void Move(Directions direction);
        void Render();
        void UpdateBodyPosition();
    }
}