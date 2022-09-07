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

        public void AddMissions(string[] missionsInfo)
        {
            for (int i = 0; i < missionsInfo.Length - 1; i += 2)
            {
                string codeName = missionsInfo[i];
                string state = missionsInfo[i + 1];

                Missions.Add(new Mission(codeName, state));
            }
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
