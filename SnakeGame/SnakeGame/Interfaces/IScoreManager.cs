namespace SnakeGame.Interfaces
{
    internal interface IScoreManager
    {
        int Score { get; set; }

        void Add(int n);

        void Render();

        void RenderLogo();
    }
}