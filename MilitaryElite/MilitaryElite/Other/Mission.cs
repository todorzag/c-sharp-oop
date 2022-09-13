using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Other
{
    internal class Mission
    {
        public enum States
        {
            inProgress,
            Finished
        }

        public string CodeName { get; }
        public States State { get; private set; }

        public Mission(string codeName, string stateString)
        {
            CodeName = codeName;
            State = StateFromString(stateString);
        }

        public void Complete()
        {
            if (State == States.inProgress)
            {
                State = States.Finished;
            }
            else
            {
                Console.WriteLine("Mission is already finished!");
            }
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName}: {State}";
        }

        private States StateFromString(string stateString)
        {
            if (Enum.TryParse(stateString, true, out States state))
            {
                return state;
            }
            else
            {
                throw new ArgumentException("Invalid Mission State!");
            }
        }
    }
}
