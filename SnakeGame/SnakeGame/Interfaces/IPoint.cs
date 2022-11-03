namespace SnakeGame.Interfaces
{
    public interface IPoint
    {
        (int, int) Position { get; set; }
        int X { get; set; }
        int Y { get; set; }
        bool EqualsPosition(IPoint point);
    }
}