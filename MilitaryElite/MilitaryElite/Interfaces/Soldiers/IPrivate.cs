namespace MilitaryElite.Models.Interfaces
{
    public interface IPrivate : ISoldier
    {
        decimal Salary { get; }

        string ToString();
    }
}