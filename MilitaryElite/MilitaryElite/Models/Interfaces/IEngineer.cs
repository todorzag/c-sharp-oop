using MilitaryElite.Models.Items;

namespace MilitaryElite.Models.Interfaces
{
    internal interface IEngineer : ISpecialisedSoldier
    {
        List<Repair> Repairs { get; }

        void AddRepairs(Repair repair);
    }
}