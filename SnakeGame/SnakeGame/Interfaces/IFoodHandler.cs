namespace SnakeGame.Interfaces
{
    public interface IFoodHandler 
    {
        void Add(IFood food);
        void Handle(ISnake snake);
        bool SnakeOnFood(IPoint snakeHead);
        bool OnFood(IFood food);
    }
}