namespace MilitaryElite.Other
{
    internal interface IMission
    {
        string CodeName { get; }
        string State { get; }

        void Complete();
        string ToString();
    }
}