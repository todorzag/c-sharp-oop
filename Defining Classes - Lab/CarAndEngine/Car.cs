using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAndEngine
{
    internal class Car
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public Engine Engine { get; set; }

        public Tire[] Tires { get; set; }

        public Car()
        {
            Make = "VW";
            Model = " MK3";
            Year = 1992;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }

        public Car(string make, string model, int year) : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, int fuelQuantity, int fuelConsumption) : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, int fuelQuantity, int fuelConsumption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public void Drive(double distance)
        {
            double result = distance * FuelConsumption;

            if (FuelQuantity - result >= 0)
            {
                FuelQuantity -= result;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            return $"Make: {Make}\n" +
                $"Model: {Model}\n" +
                $"Year: {Year}\n" +
                $"Fuel: {FuelQuantity:F2} L\n" +
                $"With a {Engine.CubicCapacity} L {Engine.HorsePower} Hp Engine\n " +
                $"{Tires[0].Year} year old tires with a pressure of {Tires[0].Pressure}";
        }

    }
}
