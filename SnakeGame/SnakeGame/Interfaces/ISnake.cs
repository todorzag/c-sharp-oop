using SnakeGame.Constants;

namespace SnakeGame.Interfaces
{
    public interface ISnake
    {
        bool DiscoMode { get; set; }
        bool IsAlive { get; set; }
        int CurrentLength { get; }
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