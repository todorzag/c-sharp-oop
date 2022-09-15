namespace MilitaryElite.Models.Interfaces
{
    internal interface IMission
    {
        string CodeName { get; }
        string State { get; }

        void Complete();
        string ToString();
    }
}