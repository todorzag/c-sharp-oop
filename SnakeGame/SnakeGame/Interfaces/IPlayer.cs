namespace SnakeGame.Interfaces
{
    public interface IPlayer
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string UserName { get; }
    }
}