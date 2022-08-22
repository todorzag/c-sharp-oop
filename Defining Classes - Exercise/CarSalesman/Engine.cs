using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    internal class Engine
    {
        public string Model { get; set; }

        public int Power { get; set; }

        public int Displacment { get; set; }

        public string Efficiency { get; set; }

        public Engine(string model, int power, int displacment, string efficiency)
        {
            Model = model;
            Power = power;
            Displacment = displacment;
            Efficiency = efficiency;
        }
    }
}
