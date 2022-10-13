using SnakeGame.Constants;

namespace SnakeGame.Interfaces
{
    public interface ISnake
    {
        bool IsAlive { get; set; }
        List<IPoint> Body { get; }
        IPoint Head { get; }
        Directions Direction { get; set; }


        void AddPart();
        void Move();
        void RemoveTail();
        void Render();
        void UpdateBodyPosition();
    }
}