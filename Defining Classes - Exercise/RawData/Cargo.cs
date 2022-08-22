using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    public class Cargo
    {
        public string CargoType { get; }

        public int CargoWeight { get; }

        public Cargo(string cargoType, int cargoWeight)
        {
            CargoType = cargoType;
            CargoWeight = cargoWeight;
        }
    }
}
