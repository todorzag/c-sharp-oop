namespace SnakeGame.Interfaces
{
    public interface ISnakePart
    {
        (int, int) Position { get; }
        int X { get; set; }
        int Y { get; set; }
    }
}