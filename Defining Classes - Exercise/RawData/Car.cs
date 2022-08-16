using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    public class Car
    {
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public Tire[] Tires = new Tire[4];

        public Car(string model, int engineSpeed, int enginePower, 
            string cargoType, int cargoWeight, string[] tires)
        {
            Model = model;
            Engine = new Engine(engineSpeed, enginePower);
            Cargo = new Cargo(cargoType, cargoWeight);
            Tires = GenerateTires(tires);
        }

        public static Tire[] GenerateTires(string[] split)
        {
            Tire[] tires = new Tire[4];

            int counter = 0;

            for (int i = 0; i < split.Length; i += 2)
            {
                float tirePressure = float.Parse(split[i]);
                int tireAge = int.Parse(split[i + 1]);

                tires[counter] = new Tire(tirePressure, tireAge);

                counter++;
            }

            return tires;
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
