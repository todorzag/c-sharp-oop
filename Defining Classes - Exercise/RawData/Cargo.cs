using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    public class Cargo
    {
        public string CargoType { get; set; }

        public int CargoWeight { get; set; }

        public Cargo(string cargoType, int cargoWeight)
        {
            CargoType = cargoType;
            CargoWeight = cargoWeight;
        }
    }
}
