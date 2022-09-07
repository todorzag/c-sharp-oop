using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Other
{
    internal class Mission
    {
        public string CodeName { get; }
        public string State { get; private set; }

        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = state;
        }

        public void Complete()
        {
            State = "Finished";
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName}: {State}";
        }
    }
}
