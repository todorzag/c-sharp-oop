using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator
{
    public interface IStat
    {
        public int Value { get; set; }
        public string Name { get; }
    }
}
