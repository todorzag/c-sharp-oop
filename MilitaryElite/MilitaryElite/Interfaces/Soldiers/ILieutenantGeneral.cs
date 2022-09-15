namespace MilitaryElite.Models.Interfaces
{
    public interface ILieutenantGeneral : IPrivate
    {
        List<ISoldier> CommandingPrivates { get; }

        void AddToCommandingPrivates(ISoldier soldier);
    }
}