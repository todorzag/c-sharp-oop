namespace MilitaryElite
{
    public interface ILieutenantGeneral : IPrivate
    {
        List<ISoldier> CommandingPrivates { get; }

        void AddPrivates(string[] privateIds);
    }
}