using MilitaryElite.Models.Items;

namespace MilitaryElite.Models.Interfaces
{
    internal interface ICommando : ISpecialisedSoldier
    {
        List<Mission> Missions { get; }
        void AddMissions(Mission mission);
    }
}