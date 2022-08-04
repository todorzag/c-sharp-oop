using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    internal class Engine
    {
        public string Model { get; }

        public int Power { get; }

        public int Displacment { get; }

        public string Efficiency { get; }

        public Engine(string model, int power, int displacment, string efficiency)
        {
            Model = model;
            Power = power;
            Displacment = displacment;
            Efficiency = efficiency;
        }
    }
}
