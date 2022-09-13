using MilitaryElite.Other;

namespace MilitaryElite.Interfaces
{
    internal interface IEngineer : ISpecialisedSoldier
    {
        List<Repair> Repairs { get; }

        void AddRepairs(Repair repair);
    }
}