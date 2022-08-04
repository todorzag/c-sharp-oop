using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    public class Car
    {
        public string Model { get; }

        public Engine Engine { get;  }

        public Cargo Cargo { get; }

        public Tire[] Tires = new Tire[4];

        public Car(string model, int engineSpeed, int enginePower, 
            string cargoType, int cargoWeight, Tire[] tires)
        {
            Model = model;
            Engine = new Engine(engineSpeed, enginePower);
            Cargo = new Cargo(cargoType, cargoWeight);
            Tires = tires;
        }

        public string GetCargoType()
        {
            return Cargo.CargoType;
        }

        public int GetCargoWeight()
        {
            return Cargo.CargoWeight;
        }

        public int GetEngineSpeed()
        {
            return Engine.EnginePower;
        }

        public bool CheckIfTirePressuresUnder1()
        {
            return Tires.Any(tire => tire.Pressure < 1);
        }
    }
}
