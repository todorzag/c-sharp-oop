using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class Army
    {
        public static List<ISoldier> soldiers = new List<ISoldier>();

        public static void Add(ISoldier soldier)
        {
            soldiers.Add(soldier);
        }

        public static ISoldier GetPrivateById(int id)
            => soldiers.Find(p => p.Id == id);

        public static void PrintArmy()
        {
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.ToString());
            }
        }
    }
}
