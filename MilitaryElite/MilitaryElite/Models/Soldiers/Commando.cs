using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilitaryElite.Interfaces;
using MilitaryElite.Other;

namespace MilitaryElite.Soldiers
{
    internal class Commando : SpecialisedSoldier, ICommando
    {
        public List<Mission> Missions { get; }

        public Commando(int id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            Missions = new List<Mission>();
        }

        public void AddMissions(Mission mission)
        {
            Missions.Add(mission);
        }

        public override string ToString()
        {
            string missionsInfoString = Missions.Count > 0 ? $"\n{PrintMissions()}" : string.Empty;

            return BasicInfo +
                $"\nCorps: {Corps}" +
                $"\nMissions:" +
                missionsInfoString;
        }

        private string PrintMissions()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Mission mission in Missions)
            {
                sb.AppendLine(mission.ToString());
            }

            return sb.ToString();
        }
    }
}
