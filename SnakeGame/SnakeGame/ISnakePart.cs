namespace SnakeGame
{
    public interface ISnakePart
    {
        (int, int) Position { get; }
        int X { get; set; }
        int Y { get; set; }
    }
}