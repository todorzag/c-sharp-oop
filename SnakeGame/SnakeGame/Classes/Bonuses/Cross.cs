using SnakeGame.Classes;
using SnakeGame.Interfaces;

namespace SnakeGame.Classes.Bonuses
{
    public class Cross : Bonus
    {
        public Cross(
            Action<object> onConsumeStrategy,
            int x = 0,
            int y = 0)
                : base(onConsumeStrategy, x, y)
        {
        }

        public override string Symbol => "X";

        public override int ScoreValue => -30;
    }
}