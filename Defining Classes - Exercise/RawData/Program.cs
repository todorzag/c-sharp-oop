using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            string line = Console.ReadLine();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] split = line.Split(" ");

                string model = split[0];
                int engineSpeed = int.Parse(split[1]);
                int enginePower = int.Parse(split[2]);
                int cargoWeight = int.Parse(split[3]);
                string cargoType = split[4];

                Tire[] tires = GetTiresInput(split);

                Car car = new Car(model, engineSpeed, enginePower, cargoType, cargoWeight, tires);

                cars.Add(car);

                line = Console.ReadLine();
            }

            List<Car> filteredCars = new List<Car>();

            switch (line)
            {
                case "fragile":
                    filteredCars = GetFragileCars(cars);
                    break;

                case "flammable":
                    filteredCars = GetFlamableCars(cars);
                    break;
            }

            PrintCars(filteredCars);
        }

        public static List<Car> GetFragileCars(List<Car> cars)
        {
            return cars.Where(c => c.GetCargoType() == "fragile" && c.CheckIfTirePressuresUnder1()).ToList();
        }

        public static List<Car> GetFlamableCars(List<Car> cars)
        {
            return cars.Where(c => c.GetCargoType() == "flammable" && c.GetEngineSpeed() > 250).ToList();
        }

        public static void PrintCars(List<Car> cars)
        {
            foreach (Car car in cars) { Console.WriteLine(car.Model); }
        }

        public static Tire[] GetTiresInput(string[] split)
        {
            Tire[] tires = new Tire[4];

            int counter = 0;

            for (int i = 5; i < split.Length; i += 2)
            {
                float tirePressure = float.Parse(split[i]);
                int tireAge = int.Parse(split[i + 1]);
     
                tires[counter] = new Tire(tireAge, tirePressure);

                counter++;
            }

            return tires;
        }
    }
}