using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator.Stats
{
    public class Sprint : IStat
    {
        public int Value { get; set; }
        public string Name { get => GetType().Name; }

        public Sprint(int stat)
        {
            Value = stat;
        }
    }
}
