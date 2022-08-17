using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator
{
    internal class Validator
    {
        private static Validator validator;

        public static Validator GetInstance()
        {
            if (validator == null)
            {
                validator = new Validator();
            }

            return validator;
        }

        public bool Validate(int stat)
        {
            bool result = true;

            if (stat < 0 || stat > 100)
            {
                result = false;
            }

            return result;
        }
    }
}
