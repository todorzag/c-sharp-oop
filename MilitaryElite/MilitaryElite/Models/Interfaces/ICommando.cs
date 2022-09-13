using MilitaryElite.Other;

namespace MilitaryElite.Interfaces
{
    internal interface ICommando: ISpecialisedSoldier
    {
        List<Mission> Missions { get; }
        void AddMissions(Mission mission);
    }
}