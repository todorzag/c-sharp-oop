using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public List<ISoldier> CommandingPrivates { get; }

        public LieutenantGeneral
            (int id, string firstName, string lastName, decimal salary, List<ISoldier> commandingPrivates)
            : base(id, firstName, lastName, salary)
        {
            CommandingPrivates = commandingPrivates;
        }

        public override string ToString()
        {
            return BasicInfo +
                $"\nPrivates:" +
                $"\n{PrintCommandingPrivates()}";
        }

        private string PrintCommandingPrivates()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var privateSoldier in CommandingPrivates)
            {
                sb.AppendLine($" {privateSoldier.ToString()}");
            }

            return sb.ToString();
        }
    }
}
