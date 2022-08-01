using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAndEngine
{
    internal class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public int HorsePower { get { return horsePower; } set { horsePower = value; } }

        public double CubicCapacity { get { return cubicCapacity; } set { cubicCapacity = value; } }

        public Engine(int horsePower, double cubicCapacity)
        {
            this.horsePower = horsePower;
            this.cubicCapacity = cubicCapacity;
        }
    }
}
